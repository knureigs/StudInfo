using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace StudInfo
{
    class RatingService: IRatingService
    {
        private List<Student> students;
        public IReadOnlyList<Student> Students
        {
            get
            {
                return students.AsReadOnly();
            }
        }

        public void FillFromPDF(string[] paths)
        {
            foreach (string path in paths)
            {
                students.AddRange(ReadFromPDF(path));
            }
        }

        public void FillFromXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            students = (List<Student>)serializer.Deserialize(reader);
            fs.Close();
        }

        public void SaveToXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            Stream fs = new FileStream(path, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            serializer.Serialize(writer, students);
            writer.Close();
        }

        public void Clear()
        {
            students.Clear();
        }

        private IEnumerable<Student> ReadFromPDF(string path)
        {
            List<Student> students = new List<Student>();
            string text = "";

            PDDocument document = PDDocument.load(path);
            PDFTextStripper stripper = new PDFTextStripper();
            text = stripper.getText(document);

            List<string> contentFirst = new List<string>();
            string[] separated = text.Split(null);
            foreach (string str in separated)
            {
                if (str != "")
                {
                    contentFirst.Add(str);
                }
            }
            int indexPIB = contentFirst.IndexOf("П.І.Б");
            contentFirst.RemoveRange(0, indexPIB);
            for (int i = 5; i < contentFirst.Count; i++)
            {
                if (Char.IsLower(contentFirst[i][0]))
                {
                    i++;
                    continue;
                }
                Student stud = new Student();
                stud.Surname = contentFirst[i];
                i++;
                stud.FName = contentFirst[i];
                i++;
                stud.SName = contentFirst[i];
                i++;
                // если имен четыре
                if (Char.IsUpper(contentFirst[i][0]) || contentFirst[i] == "-") // костыль для обработки коряво записаного Буй Ван Тунга -
                {
                    stud.SName += " " + contentFirst[i];
                    i++;
                }

                if (contentFirst[i] == "не")
                {
                    if (Char.IsUpper(contentFirst[i + 1][0])) // ячейка разделена разрывом страницы
                    {
                        stud.Rate = contentFirst[i] + " " + contentFirst[i + 3];
                        contentFirst.RemoveAt(i + 3);
                    }
                    else
                    {
                        stud.Rate = contentFirst[i] + " " + contentFirst[++i];
                    }
                    i++;
                }
                else
                {
                    stud.Rate = contentFirst[i];
                    i++;
                }
                stud.Group = contentFirst[i];
                i++;
                while (Char.IsLower(contentFirst[i][0]))
                {
                    stud.Addition += contentFirst[i] + " ";
                    i++;
                    if (i == contentFirst.Count)
                    {
                        break;
                    }
                }
                if (stud.Addition != null)
                    stud.Addition.Trim();
                i--;
                students.Add(stud);
            }
            return students;
        }
    }

    public struct Student
    {
        public string Surname;
        public string FName;
        public string SName;
        public string Rate;
        public string Group;
        public string Addition;

        public Student(string surname, string fname, string sname, string rate, string group, string addition)
        {
            FName = fname;
            Surname = surname;
            SName = sname;
            Rate = rate;
            Group = group;
            Addition = addition;
        }

        public override string ToString()
        {
            return Surname + " " + FName + " " + SName + " " + Rate + " " + Group + " " + Addition;
        }
    }
}
