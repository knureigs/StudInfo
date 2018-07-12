using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.apache.pdfbox.pdmodel;
using org.apache.pdfbox.util;

namespace StudInfo
{
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

    public partial class StudInfoForm : Form
    {
        //string path = "test.pdf";
        List<Student> StudRates = new List<Student>();
        public StudInfoForm()
        {
            InitializeComponent();
        }

        private void buttonLoadFromFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true
            };
            DialogResult dialogResult  = ofd.ShowDialog();
            if(dialogResult== DialogResult.Cancel || dialogResult== DialogResult.Abort || dialogResult== DialogResult.No)
            {
                return;
            }

            foreach(string path in ofd.FileNames)
            {
                StudRates.AddRange(ReadFromPDF(path));
            }
            FillStudRatesGrid();            
        }

        private void FillStudRatesGrid()
        {
            foreach (Student stud in StudRates)
            {
                DataGridViewTextBoxCell cellSurname = new DataGridViewTextBoxCell();
                cellSurname.Value = stud.Surname;
                DataGridViewTextBoxCell cellFName = new DataGridViewTextBoxCell();
                cellFName.Value = stud.FName;
                DataGridViewTextBoxCell cellSName = new DataGridViewTextBoxCell();
                cellSName.Value = stud.SName;
                DataGridViewTextBoxCell cellRate = new DataGridViewTextBoxCell();
                cellRate.Value = stud.Rate;
                DataGridViewTextBoxCell cellGroup = new DataGridViewTextBoxCell();
                cellGroup.Value = stud.Group;
                DataGridViewTextBoxCell cellAddition = new DataGridViewTextBoxCell();
                cellAddition.Value = stud.Addition;

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cellSurname);
                row.Cells.Add(cellFName);
                row.Cells.Add(cellSName);
                row.Cells.Add(cellRate);
                row.Cells.Add(cellGroup);
                row.Cells.Add(cellAddition);
                dataGridViewStudRates.Rows.Add(row);
                //listBox1.Items.Add(stud.ToString());
            }
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
                if (Char.IsUpper(contentFirst[i][0]) || contentFirst[i]=="-") // костыль для обработки коряво записаного Буй Ван Тунга -
                {
                    stud.SName += " " + contentFirst[i];
                    i++;
                }

                if (contentFirst[i] == "не")
                {
                    if (Char.IsUpper(contentFirst[i + 1][0])) // ячейка разделена разрывом страницы
                    {
                        stud.Rate = contentFirst[i] + " " + contentFirst[i+3];
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

        private void buttonGetFIOGroup_Click(object sender, EventArgs e)
        {
            string selected = "";
            if (dataGridViewStudRates.SelectedRows != null)
            {
                selected = dataGridViewStudRates.SelectedRows[0].Cells[0].Value.ToString()
                    + " " + dataGridViewStudRates.SelectedRows[0].Cells[1].Value.ToString()[0]
                    + "." + dataGridViewStudRates.SelectedRows[0].Cells[2].Value.ToString()[0]
                    + ". ("+ dataGridViewStudRates.SelectedRows[0].Cells[4].Value.ToString() + ")";
                //MessageBox.Show(selected);
                Clipboard.SetData(DataFormats.Text, (Object)selected);
            }
        }

        private void StudRatingForm_Load(object sender, EventArgs e)
        {
            string[] xmlFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            for(int i=0;i< xmlFiles.Length;i++)
            {
                xmlFiles[i] = Path.GetFileName(xmlFiles[i]);
            }
            listBox1.Items.AddRange(xmlFiles);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewStudRates.Rows.Clear();
            ReadFromXML(listBox1.SelectedItem.ToString());
            FillStudRatesGrid();
        }

        private void ReadFromXML(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            FileStream fs = new FileStream(path, FileMode.Open);
            XmlReader reader = XmlReader.Create(fs);
            StudRates = (List<Student>)serializer.Deserialize(reader);
            fs.Close();
        }

        private void buttonSaveToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort || dialogResult == DialogResult.No)
            {
                return;
            }

            SerializeObject(sfd.FileName);
        }

        private void SerializeObject(string filename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));
            Stream fs = new FileStream(filename, FileMode.Create);
            XmlWriter writer = new XmlTextWriter(fs, Encoding.Unicode);
            serializer.Serialize(writer, StudRates);
            writer.Close();
        }

        private void buttonDataGridClear_Click(object sender, EventArgs e)
        {
            StudRates.Clear();
            dataGridViewStudRates.Rows.Clear();
        }

        private void buttonGetGroup_Click(object sender, EventArgs e)
        {
            string selected = "";
            if (dataGridViewStudRates.SelectedRows != null)
            {
                selected = " (" + dataGridViewStudRates.SelectedRows[0].Cells[4].Value.ToString() + ")";
                //MessageBox.Show(selected);
                Clipboard.SetData(DataFormats.Text, (Object)selected);
            }
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            for (int u = 0; u < dataGridViewStudRates.RowCount; u++)
            {
                if (dataGridViewStudRates.Rows[u].Cells[0].Value.ToString().StartsWith(textBoxFilter.Text))
                {
                    dataGridViewStudRates.Rows[u].Visible = true;
                }
                else
                {
                    dataGridViewStudRates.Rows[u].Visible = false;
                }
            }
        }
    }
}
