using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace StudInfo
{
    /// <summary>
    /// Представляет окно пользовательского интерфейса приложения для работы информацией о студентах.
    /// </summary>
    public partial class StudInfoForm : Form
    {
        #region Enums.

        /// <summary>
        /// Задает идентификаторы, определяющие используемые колонки рейтинга.
        /// </summary>
        enum RatingDataCells : int { Surname, FName, SName, Rate, Group, Addition }

        #endregion

        #region Properties and fields.

        /// <summary>
        /// Экземпляр класса для работы с стипендиальным рейтингом.
        /// </summary>
        private readonly IRatingService _rating;

        #endregion

        #region Constructors.

        /// <summary>
        /// Инициализирует новый экземпляр класса StudInfoForm.
        /// </summary>
        /// <param name="ratingService">Сервис для работы со стипендиальным рейтингом.</param>
        public StudInfoForm(IRatingService ratingService)
        {
            _rating = ratingService;
            InitializeComponent();
        }

        #endregion

        #region Events.

        private void StudRatingForm_Load(object sender, EventArgs e)
        {
            FillSavedFileListBox();
        }

        private void listBoxXmlFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _rating.FillFromXml(listBoxXmlFiles.SelectedItem.ToString());
            FillStudRatesGrid(_rating.Students);
        }

        private void buttonLoadFromFiles_Click(object sender, EventArgs e)
        {
            LoadRatingFromPdf();
        }

        private void buttonSaveToXml_Click(object sender, EventArgs e)
        {
            SaveRatingDataToXml();
        }

        private void buttonDataGridClear_Click(object sender, EventArgs e)
        {
            _rating.Clear();
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

        private void buttonGetFIOGroup_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudRates.SelectedRows == null)
            {
                return;
            }

            ClipboardFIOGroup(dataGridViewStudRates.SelectedRows[0]);
        }

        private void dataGridViewStudRates_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewStudRates.SelectedRows == null)
            {
                return;
            }

            ClipboardFIOGroup(dataGridViewStudRates.SelectedRows[0]);
        }

        private void textBoxFilter_TextChanged(object sender, EventArgs e)
        {
            // для независимости от регистра при поиске.
            string searchString = textBoxFilter.Text.Trim().ToLower();

            for (int i = 0; i < dataGridViewStudRates.RowCount; i++)
            {
                var row = dataGridViewStudRates.Rows[i];
                string searchSurname = row.Cells[(int)RatingDataCells.Surname].Value.ToString().ToLower();
                row.Visible = searchSurname.StartsWith(searchString);
            }
        }

        private void StudInfoForm_Activated(object sender, EventArgs e)
        {
            // Сброс отображения текущего содержимого буфера обмена при получении фокуса приложением.
            // Нас интересует только то содержимое буфера, которое сформировано этой программой.
            textBoxClipboardContent.Text = "";
        }

        #endregion

        /// <summary>
        /// Заполняет отображаемый список именами XML-файлов, содержащих ранее сохраненные данные. 
        /// </summary>
        private void FillSavedFileListBox()
        {
            string[] xmlFiles = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.xml");
            for (int i = 0; i < xmlFiles.Length; i++)
            {
                xmlFiles[i] = Path.GetFileName(xmlFiles[i]);
            }
            listBoxXmlFiles.Items.AddRange(xmlFiles);
        }

        /// <summary>
        /// Загружает данные из рейтинга, представленного в PDF-файлах.
        /// </summary>
        private void LoadRatingFromPdf()
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

            _rating.FillFromPdf(ofd.FileNames);

            FillStudRatesGrid(_rating.Students);
        }

        /// <summary>
        /// Сохраняет обработанные данные из рейтинга в XML.
        /// </summary>
        private void SaveRatingDataToXml()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            DialogResult dialogResult = sfd.ShowDialog();
            if (dialogResult == DialogResult.Cancel || dialogResult == DialogResult.Abort || dialogResult == DialogResult.No)
            {
                return;
            }

            _rating.SaveToXml(sfd.FileName);
        }

        /// <summary>
        /// Заполняет таблицу по коллекции данных о студентах.
        /// </summary>
        /// <param name="students">Коллекция объектов, описывающих студентов.</param>
        private void FillStudRatesGrid(IReadOnlyList<Student> students)
        {
            dataGridViewStudRates.Rows.Clear();

            foreach (Student stud in students)
            {
                DataGridViewTextBoxCell cellSurname = new DataGridViewTextBoxCell
                {
                    Value = stud.Surname
                };
                DataGridViewTextBoxCell cellFName = new DataGridViewTextBoxCell
                {
                    Value = stud.FName
                };
                DataGridViewTextBoxCell cellSName = new DataGridViewTextBoxCell
                {
                    Value = stud.SName
                };
                DataGridViewTextBoxCell cellRate = new DataGridViewTextBoxCell
                {
                    Value = stud.Rate
                };
                DataGridViewTextBoxCell cellGroup = new DataGridViewTextBoxCell
                {
                    Value = stud.Group
                };
                DataGridViewTextBoxCell cellAddition = new DataGridViewTextBoxCell
                {
                    Value = stud.Addition
                };

                DataGridViewRow row = new DataGridViewRow();
                row.Cells.Add(cellSurname);
                row.Cells.Add(cellFName);
                row.Cells.Add(cellSName);
                row.Cells.Add(cellRate);
                row.Cells.Add(cellGroup);
                row.Cells.Add(cellAddition);

                dataGridViewStudRates.Rows.Add(row);
            }
        }

        /// <summary>
        /// Заполняет буфер обмена подготовленными данными о ФИО и академической группе выбранного студента.
        /// </summary>
        /// <param name="selectedRow">Строка таблицы, соответствующая выбранному студенту.</param>
        private void ClipboardFIOGroup(DataGridViewRow selectedRow)
        {
            string surname = selectedRow.Cells[(int)RatingDataCells.Surname].Value.ToString();
            char name = selectedRow.Cells[(int)RatingDataCells.FName].Value.ToString()[0];
            char sname = selectedRow.Cells[(int)RatingDataCells.SName].Value.ToString()[0];
            string group = selectedRow.Cells[(int)RatingDataCells.Group].Value.ToString();

            string studInfo = surname + " " + name + "." + sname + ". (" + group + ")";

            textBoxClipboardContent.Text = studInfo;
            Clipboard.SetData(DataFormats.Text, studInfo);
        }

        /// <summary>
        /// Заполняет буфер обмена подготовленными данными об академической группе выбранного студента.
        /// </summary>
        /// <param name="selectedRow">Строка таблицы, соответствующая выбранному студенту.</param>
        private void ClipboardGroup(DataGridViewRow selectedRow)
        {
            string group = selectedRow.Cells[(int)RatingDataCells.Group].Value.ToString();
            string studInfo = " (" + group + ")";

            textBoxClipboardContent.Text = studInfo;
            Clipboard.SetData(DataFormats.Text, studInfo);
        }
    }
}
