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
            this.buttonLoadFromFiles = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRates)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLoadFromFiles
            // 
            this.buttonLoadFromFiles.Location = new System.Drawing.Point(23, 46);
            this.buttonLoadFromFiles.Name = "buttonLoadFromFiles";
            this.buttonLoadFromFiles.Size = new System.Drawing.Size(75, 23);
            this.buttonLoadFromFiles.TabIndex = 0;
            this.buttonLoadFromFiles.Text = "Загрузить";
            this.buttonLoadFromFiles.UseVisualStyleBackColor = true;
            this.buttonLoadFromFiles.Click += new System.EventHandler(this.buttonLoadFromFiles_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 75);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(55, 212);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // dataGridViewStudRates
            // 
            this.dataGridViewStudRates.AllowUserToAddRows = false;
            this.dataGridViewStudRates.AllowUserToDeleteRows = false;
            this.dataGridViewStudRates.AllowUserToResizeRows = false;
            this.dataGridViewStudRates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStudRates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudRates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSurname,
            this.ColumnFName,
            this.ColumnSName,
            this.ColumnRate,
            this.ColumnGroup,
            this.ColumnAddition});
            this.dataGridViewStudRates.Location = new System.Drawing.Point(73, 76);
            this.dataGridViewStudRates.MultiSelect = false;
            this.dataGridViewStudRates.Name = "dataGridViewStudRates";
            this.dataGridViewStudRates.ReadOnly = true;
            this.dataGridViewStudRates.RowHeadersVisible = false;
            this.dataGridViewStudRates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStudRates.ShowCellErrors = false;
            this.dataGridViewStudRates.ShowCellToolTips = false;
            this.dataGridViewStudRates.ShowEditingIcon = false;
            this.dataGridViewStudRates.ShowRowErrors = false;
            this.dataGridViewStudRates.Size = new System.Drawing.Size(648, 215);
            this.dataGridViewStudRates.TabIndex = 2;
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
            this.buttonGetFIOGroup.Location = new System.Drawing.Point(147, 17);
            this.buttonGetFIOGroup.Name = "buttonGetFIOGroup";
            this.buttonGetFIOGroup.Size = new System.Drawing.Size(146, 23);
            this.buttonGetFIOGroup.TabIndex = 3;
            this.buttonGetFIOGroup.Text = "Фамилия И.О. (Группа)";
            this.buttonGetFIOGroup.UseVisualStyleBackColor = true;
            this.buttonGetFIOGroup.Click += new System.EventHandler(this.buttonGetFIOGroup_Click);
            // 
            // buttonSaveToXML
            // 
            this.buttonSaveToXML.Location = new System.Drawing.Point(23, 17);
            this.buttonSaveToXML.Name = "buttonSaveToXML";
            this.buttonSaveToXML.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToXML.TabIndex = 4;
            this.buttonSaveToXML.Text = "SaveToXML";
            this.buttonSaveToXML.UseVisualStyleBackColor = true;
            this.buttonSaveToXML.Click += new System.EventHandler(this.buttonSaveToXML_Click);
            // 
            // buttonDataGridClear
            // 
            this.buttonDataGridClear.Location = new System.Drawing.Point(337, 13);
            this.buttonDataGridClear.Name = "buttonDataGridClear";
            this.buttonDataGridClear.Size = new System.Drawing.Size(75, 23);
            this.buttonDataGridClear.TabIndex = 5;
            this.buttonDataGridClear.Text = "Clear";
            this.buttonDataGridClear.UseVisualStyleBackColor = true;
            this.buttonDataGridClear.Click += new System.EventHandler(this.buttonDataGridClear_Click);
            // 
            // buttonGetGroup
            // 
            this.buttonGetGroup.Location = new System.Drawing.Point(147, 46);
            this.buttonGetGroup.Name = "buttonGetGroup";
            this.buttonGetGroup.Size = new System.Drawing.Size(146, 23);
            this.buttonGetGroup.TabIndex = 3;
            this.buttonGetGroup.Text = " (Группа)";
            this.buttonGetGroup.UseVisualStyleBackColor = true;
            this.buttonGetGroup.Click += new System.EventHandler(this.buttonGetGroup_Click);
            // 
            // textBoxFilter
            // 
            this.textBoxFilter.Location = new System.Drawing.Point(337, 46);
            this.textBoxFilter.Name = "textBoxFilter";
            this.textBoxFilter.Size = new System.Drawing.Size(100, 20);
            this.textBoxFilter.TabIndex = 6;
            this.textBoxFilter.TextChanged += new System.EventHandler(this.textBoxFilter_TextChanged);
            // 
            // StudRatingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(733, 303);
            this.Controls.Add(this.textBoxFilter);
            this.Controls.Add(this.buttonDataGridClear);
            this.Controls.Add(this.buttonSaveToXML);
            this.Controls.Add(this.buttonGetGroup);
            this.Controls.Add(this.buttonGetFIOGroup);
            this.Controls.Add(this.dataGridViewStudRates);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonLoadFromFiles);
            this.Name = "StudRatingForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.StudRatingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudRates)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLoadFromFiles;
        private System.Windows.Forms.ListBox listBox1;
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
    }
}

