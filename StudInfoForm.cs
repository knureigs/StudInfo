using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StudInfo
{
    public partial class StudInfoForm : Form
    {
        private readonly IRatingService Rating;

        public StudInfoForm(IRatingService ratingService)
        {
            Rating = ratingService;
            InitializeComponent();
        }

        private void buttonLoadFromFiles_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Multiselect = true
            };
            DialogResult dialogResult = ofd.ShowDialog();
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort || dialogResult == DialogResult.No)
            {
                return;
            }
            Rating.FillFromPDF(ofd.FileNames);

            FillStudRatesGrid(Rating.Students);
        }

        private void FillStudRatesGrid(IReadOnlyList<Student> students)
        {
            foreach (Student stud in students)
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

        private void StudRatingForm_Load(object sender, EventArgs e)
        {
            string[] xmlFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            for (int i = 0; i < xmlFiles.Length; i++)
            {
                xmlFiles[i] = Path.GetFileName(xmlFiles[i]);
            }
            listBox1.Items.AddRange(xmlFiles);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewStudRates.Rows.Clear();
            Rating.FillFromXML(listBox1.SelectedItem.ToString());
            FillStudRatesGrid(Rating.Students);
        }

        private void buttonSaveToXML_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort || dialogResult == DialogResult.No)
            {
                return;
            }
            Rating.SaveToXML(sfd.FileName);
        }

        private void buttonDataGridClear_Click(object sender, EventArgs e)
        {
            Rating.Clear();
            dataGridViewStudRates.Rows.Clear();
        }

        private void buttonGetGroup_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudRates.SelectedRows == null)
            {
                return;
            }

            ClipboardGroup(dataGridViewStudRates.SelectedRows[0]);
        }

        private void ClipboardGroup(DataGridViewRow selectedRow)
        {
            string group = selectedRow.Cells[4].Value.ToString();
            string studInfo = " (" + group + ")";

            textBoxClipboardContent.Text = studInfo;
            Clipboard.SetData(DataFormats.Text, studInfo);
        }

        private void buttonGetFIOGroup_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudRates.SelectedRows == null)
            {
                return;
            }

            ClipboardFIOGroup(dataGridViewStudRates.SelectedRows[0]);
        }

        private void ClipboardFIOGroup(DataGridViewRow selectedRow)
        {
            string surname = selectedRow.Cells[0].Value.ToString();
            char name = selectedRow.Cells[1].Value.ToString()[0];
            char sname = selectedRow.Cells[2].Value.ToString()[0];
            string group = selectedRow.Cells[4].Value.ToString();

            string studInfo = surname + " " + name + "." + sname + ". (" + group + ")";

            textBoxClipboardContent.Text = studInfo;
            Clipboard.SetData(DataFormats.Text, studInfo);
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            string searchString = textBoxFilter.Text.Trim().ToLower();
            for (int i = 0; i < dataGridViewStudRates.RowCount; i++)
            {
                var row = dataGridViewStudRates.Rows[i];
                string searchSurname = row.Cells[0].Value.ToString().ToLower();
                row.Visible = searchSurname.StartsWith(searchString);
            }
        }

        private void StudInfoForm_Activated(object sender, EventArgs e)
        {
            textBoxClipboardContent.Text = "";
        }
    }
}
