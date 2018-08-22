using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace StudInfo
{
    /// <summary>
    /// Предоставляет доступ к данным из стипендиального рейтинга и методам для их получения и сохранения.
    /// </summary>
    class RatingService : IRatingService
    {
        #region Implementation IRatingService.

        /// <summary>
        /// Список объектов, описывающих студентов по имеющимся в рейтинге данным.
        /// </summary>
        private List<Student> students = new List<Student>(0);
        public IReadOnlyList<Student> Students
        {
            get
            {
                return students.AsReadOnly();
            }
        }

        public void FillFromPdf(string[] paths)
        {
            foreach (string path in paths)
            {
                students.AddRange(ReadFromPdf(path));
            }
        }

        public void FillFromXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            students.AddRange((List<Student>)serializer.Deserialize(reader));
            fs.Close();
        }

        public void SaveToXml(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            Stream fs = new FileStream(path, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            serializer.Serialize(writer, students);
            writer.Close();
        }

        public void FillFromDB(string path)
        {
            students.AddRange(DBProvider.GetStudents(path));
        }

        public void SaveToDB(string path)
        {
            DBProvider.CreateRatingDB(path, Students);
        }

        public void Clear()
        {
            students.Clear();
        }
        
        #endregion
        
        /// <summary>
        /// Заполняет коллекцию данных о студентах на основании PDF-файла с данными стипендиального рейтинга.
        /// </summary>
        /// <param name="path">Путь к PDF-файлу с данными стипендиального рейтинга.</param>
        /// <returns>Коллекция данных о студентах.</returns>
        private IEnumerable<Student> ReadFromPdf(string path)
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
                Student stud = new Student
                {
                    Surname = contentFirst[i++],
                    FName = contentFirst[i++],
                    SName = contentFirst[i++]
                };
                // если имен четыре
                if (Char.IsUpper(contentFirst[i][0]) || contentFirst[i] == "-") // костыль для обработки коряво записаного Буй Ван Тунга -
                {
                    stud.SName += " " + contentFirst[i++];
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
                    stud.Rate = contentFirst[i++];
                }
                stud.Group = contentFirst[i++];
                while (Char.IsLower(contentFirst[i][0]))
                {
                    stud.Addition += contentFirst[i++] + " ";
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
}
