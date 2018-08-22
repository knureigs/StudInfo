namespace StudInfo
{
    partial class StudInfoForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonLoadFromPdf = new System.Windows.Forms.Button();
            this.listBoxXmlFiles = new System.Windows.Forms.ListBox();
            this.dataGridViewStudRates = new System.Windows.Forms.DataGridView();
            this.ColumnSurname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnAddition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonGetFIOGroup = new System.Windows.Forms.Button();
            this.buttonSaveToXML = new System.Windows.Forms.Button();
            this.buttonDataGridClear = new System.Windows.Forms.Button();
            this.buttonGetGroup = new System.Windows.Forms.Button();
            this.textBoxFilter = new System.Windows.Forms.TextBox();
            this.labelClipboardContent = new System.Windows.Forms.Label();
            this.textBoxClipboardContent = new System.Windows.Forms.TextBox();
            this.buttonSaveToDB = new System.Windows.Forms.Button();
            this.buttonLoadFromDB = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRates)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadFromPdf
            // 
            this.buttonLoadFromPdf.Location = new System.Drawing.Point(12, 12);
            this.buttonLoadFromPdf.Name = "buttonLoadFromPdf";
            this.buttonLoadFromPdf.Size = new System.Drawing.Size(109, 23);
            this.buttonLoadFromPdf.TabIndex = 0;
            this.buttonLoadFromPdf.Text = "Загрузить из PDF";
            this.buttonLoadFromPdf.UseVisualStyleBackColor = true;
            this.buttonLoadFromPdf.Click += new System.EventHandler(this.buttonLoadFromPdf_Click);
            // 
            // listBoxXmlFiles
            // 
            this.listBoxXmlFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listBoxXmlFiles.FormattingEnabled = true;
            this.listBoxXmlFiles.HorizontalScrollbar = true;
            this.listBoxXmlFiles.Location = new System.Drawing.Point(12, 131);
            this.listBoxXmlFiles.Name = "listBoxXmlFiles";
            this.listBoxXmlFiles.Size = new System.Drawing.Size(109, 160);
            this.listBoxXmlFiles.TabIndex = 1;
            this.listBoxXmlFiles.SelectedIndexChanged += new System.EventHandler(this.listBoxXmlFiles_SelectedIndexChanged);
            // 
            // dataGridViewStudRates
            // 
            this.dataGridViewStudRates.AllowUserToAddRows = false;
            this.dataGridViewStudRates.AllowUserToDeleteRows = false;
            this.dataGridViewStudRates.AllowUserToResizeRows = false;
            this.dataGridViewStudRates.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSurname,
            this.ColumnFName,
            this.ColumnSName,
            this.ColumnRate,
            this.ColumnGroup,
            this.ColumnAddition});
            this.dataGridViewStudRates.Location = new System.Drawing.Point(127, 70);
            this.dataGridViewStudRates.MultiSelect = false;
            this.dataGridViewStudRates.Name = "dataGridViewStudRates";
            this.dataGridViewStudRates.ReadOnly = true;
            this.dataGridViewStudRates.RowHeadersVisible = false;
            this.dataGridViewStudRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudRates.ShowCellErrors = false;
            this.dataGridViewStudRates.ShowCellToolTips = false;
            this.dataGridViewStudRates.ShowEditingIcon = false;
            this.dataGridViewStudRates.ShowRowErrors = false;
            this.dataGridViewStudRates.Size = new System.Drawing.Size(592, 221);
            this.dataGridViewStudRates.TabIndex = 2;
            this.dataGridViewStudRates.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStudRates_CellContentDoubleClick);
            // 
            // ColumnSurname
            // 
            this.ColumnSurname.Frozen = true;
            this.ColumnSurname.HeaderText = "Surname";
            this.ColumnSurname.Name = "ColumnSurname";
            this.ColumnSurname.ReadOnly = true;
            // 
            // ColumnFName
            // 
            this.ColumnFName.Frozen = true;
            this.ColumnFName.HeaderText = "FirstName";
            this.ColumnFName.Name = "ColumnFName";
            this.ColumnFName.ReadOnly = true;
            // 
            // ColumnSName
            // 
            this.ColumnSName.Frozen = true;
            this.ColumnSName.HeaderText = "SecondName";
            this.ColumnSName.Name = "ColumnSName";
            this.ColumnSName.ReadOnly = true;
            // 
            // ColumnRate
            // 
            this.ColumnRate.Frozen = true;
            this.ColumnRate.HeaderText = "Rate";
            this.ColumnRate.Name = "ColumnRate";
            this.ColumnRate.ReadOnly = true;
            // 
            // ColumnGroup
            // 
            this.ColumnGroup.Frozen = true;
            this.ColumnGroup.HeaderText = "Group";
            this.ColumnGroup.Name = "ColumnGroup";
            this.ColumnGroup.ReadOnly = true;
            // 
            // ColumnAddition
            // 
            this.ColumnAddition.Frozen = true;
            this.ColumnAddition.HeaderText = "Addition";
            this.ColumnAddition.Name = "ColumnAddition";
            this.ColumnAddition.ReadOnly = true;
            // 
            // buttonGetFIOGroup
            // 
            this.buttonGetFIOGroup.Location = new System.Drawing.Point(239, 12);
            this.buttonGetFIOGroup.Name = "buttonGetFIOGroup";
            this.buttonGetFIOGroup.Size = new System.Drawing.Size(146, 23);
            this.buttonGetFIOGroup.TabIndex = 3;
            this.buttonGetFIOGroup.Text = "Фамилия И.О. (Группа)";
            this.buttonGetFIOGroup.UseVisualStyleBackColor = true;
            this.buttonGetFIOGroup.Click += new System.EventHandler(this.buttonGetFIOGroup_Click);
            // 
            // buttonSaveToXML
            // 
            this.buttonSaveToXML.Location = new System.Drawing.Point(12, 99);
            this.buttonSaveToXML.Name = "buttonSaveToXML";
            this.buttonSaveToXML.Size = new System.Drawing.Size(109, 23);
            this.buttonSaveToXML.TabIndex = 4;
            this.buttonSaveToXML.Text = "Сохранить в XML";
            this.buttonSaveToXML.UseVisualStyleBackColor = true;
            this.buttonSaveToXML.Click += new System.EventHandler(this.buttonSaveToXml_Click);
            // 
            // buttonDataGridClear
            // 
            this.buttonDataGridClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDataGridClear.Location = new System.Drawing.Point(629, 12);
            this.buttonDataGridClear.Name = "buttonDataGridClear";
            this.buttonDataGridClear.Size = new System.Drawing.Size(90, 52);
            this.buttonDataGridClear.TabIndex = 5;
            this.buttonDataGridClear.Text = "Очистить данные рейтинга";
            this.buttonDataGridClear.UseVisualStyleBackColor = true;
            this.buttonDataGridClear.Click += new System.EventHandler(this.buttonDataGridClear_Click);
            // 
            // buttonGetGroup
            // 
            this.buttonGetGroup.Location = new System.Drawing.Point(239, 41);
            this.buttonGetGroup.Name = "buttonGetGroup";
            this.buttonGetGroup.Size = new System.Drawing.Size(146, 23);
            this.buttonGetGroup.TabIndex = 3;
            this.buttonGetGroup.Text = " (Группа)";
            this.buttonGetGroup.UseVisualStyleBackColor = true;
            this.buttonGetGroup.Click += new System.EventHandler(this.buttonGetGroup_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(127, 44);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilter.TabIndex = 6;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // labelClipboardContent
            // 
            this.labelClipboardContent.AutoSize = true;
            this.labelClipboardContent.Location = new System.Drawing.Point(391, 22);
            this.labelClipboardContent.Name = "labelClipboardContent";
            this.labelClipboardContent.Size = new System.Drawing.Size(83, 13);
            this.labelClipboardContent.TabIndex = 7;
            this.labelClipboardContent.Text = "Буфер обмена:";
            // 
            // textBoxClipboardContent
            // 
            this.textBoxClipboardContent.Enabled = false;
            this.textBoxClipboardContent.Location = new System.Drawing.Point(391, 44);
            this.textBoxClipboardContent.Name = "textBoxClipboardContent";
            this.textBoxClipboardContent.Size = new System.Drawing.Size(141, 20);
            this.textBoxClipboardContent.TabIndex = 8;
            // 
            // buttonSaveToDB
            // 
            this.buttonSaveToDB.Location = new System.Drawing.Point(12, 70);
            this.buttonSaveToDB.Name = "buttonSaveToDB";
            this.buttonSaveToDB.Size = new System.Drawing.Size(109, 23);
            this.buttonSaveToDB.TabIndex = 0;
            this.buttonSaveToDB.Text = "Сохранить в БД";
            this.buttonSaveToDB.UseVisualStyleBackColor = true;
            this.buttonSaveToDB.Click += new System.EventHandler(this.buttonSaveToDB_Click);
            // 
            // buttonLoadFromDB
            // 
            this.buttonLoadFromDB.Location = new System.Drawing.Point(12, 41);
            this.buttonLoadFromDB.Name = "buttonLoadFromDB";
            this.buttonLoadFromDB.Size = new System.Drawing.Size(109, 23);
            this.buttonLoadFromDB.TabIndex = 0;
            this.buttonLoadFromDB.Text = "Загрузить из БД";
            this.buttonLoadFromDB.UseVisualStyleBackColor = true;
            this.buttonLoadFromDB.Click += new System.EventHandler(this.buttonLoadFromDB_Click);
            // 
            // labelSearch
            // 
            this.labelSearch.AutoSize = true;
            this.labelSearch.Location = new System.Drawing.Point(127, 28);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(106, 13);
            this.labelSearch.TabIndex = 7;
            this.labelSearch.Text = "Поиск по фамилии:";
            // 
            // StudInfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 303);
            this.Controls.Add(this.textBoxClipboardContent);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.labelClipboardContent);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonDataGridClear);
            this.Controls.Add(this.buttonSaveToXML);
            this.Controls.Add(this.buttonGetGroup);
            this.Controls.Add(this.buttonGetFIOGroup);
            this.Controls.Add(this.dataGridViewStudRates);
            this.Controls.Add(this.listBoxXmlFiles);
            this.Controls.Add(this.buttonLoadFromDB);
            this.Controls.Add(this.buttonSaveToDB);
            this.Controls.Add(this.buttonLoadFromPdf);
            this.Name = "StudInfoForm";
            this.Text = "StudInfo";
            this.Activated += new System.EventHandler(this.StudInfoForm_Activated);
            this.Load += new System.EventHandler(this.StudRatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFromPdf;
        private System.Windows.Forms.ListBox listBoxXmlFiles;
        private System.Windows.Forms.DataGridView dataGridViewStudRates;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSurname;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnRate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnAddition;
        private System.Windows.Forms.Button buttonGetFIOGroup;
        private System.Windows.Forms.Button buttonSaveToXML;
        private System.Windows.Forms.Button buttonDataGridClear;
        private System.Windows.Forms.Button buttonGetGroup;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.Label labelClipboardContent;
        private System.Windows.Forms.TextBox textBoxClipboardContent;
        private System.Windows.Forms.Button buttonSaveToDB;
        private System.Windows.Forms.Button buttonLoadFromDB;
        private System.Windows.Forms.Label labelSearch;
    }
}

