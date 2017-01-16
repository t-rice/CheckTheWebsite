namespace сheckTheWebsite
{
    partial class formCheckWeb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCheckWeb));
            this.tabControlAnalis = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.buttonSaveFastReport = new MetroFramework.Controls.MetroButton();
            this.textBoxFastReport = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.buttonStartFastAnalis = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.textBoxWeb = new MetroFramework.Controls.MetroTextBox();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.buttonSaveFullReport = new MetroFramework.Controls.MetroButton();
            this.textBoxFullReport = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.buttonStartFullAnalis = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.textBoxWebFull = new MetroFramework.Controls.MetroTextBox();
            this.keyWordsDataSet1 = new сheckTheWebsite.keyWordsDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.keyWordTableAdapter1 = new сheckTheWebsite.keyWordsDataSetTableAdapters.keyWordTableAdapter();
            this.aKeyWordTableAdapter1 = new сheckTheWebsite.keyWordsDataSetTableAdapters.aKeyWordTableAdapter();
            this.tableAdapterManager1 = new сheckTheWebsite.keyWordsDataSetTableAdapters.TableAdapterManager();
            this.tabControlAnalis.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyWordsDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlAnalis
            // 
            this.tabControlAnalis.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlAnalis.Controls.Add(this.metroTabPage1);
            this.tabControlAnalis.Controls.Add(this.metroTabPage2);
            this.tabControlAnalis.Location = new System.Drawing.Point(1, 33);
            this.tabControlAnalis.Name = "tabControlAnalis";
            this.tabControlAnalis.SelectedIndex = 0;
            this.tabControlAnalis.Size = new System.Drawing.Size(798, 566);
            this.tabControlAnalis.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControlAnalis.Style = MetroFramework.MetroColorStyle.White;
            this.tabControlAnalis.TabIndex = 10;
            this.tabControlAnalis.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControlAnalis.UseStyleColors = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.metroTabPage1.Controls.Add(this.buttonSaveFastReport);
            this.metroTabPage1.Controls.Add(this.textBoxFastReport);
            this.metroTabPage1.Controls.Add(this.metroLabel2);
            this.metroTabPage1.Controls.Add(this.buttonStartFastAnalis);
            this.metroTabPage1.Controls.Add(this.metroLabel1);
            this.metroTabPage1.Controls.Add(this.textBoxWeb);
            this.metroTabPage1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(790, 527);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Быстрый анализ";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            // 
            // buttonSaveFastReport
            // 
            this.buttonSaveFastReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSaveFastReport.Location = new System.Drawing.Point(659, 114);
            this.buttonSaveFastReport.Name = "buttonSaveFastReport";
            this.buttonSaveFastReport.Size = new System.Drawing.Size(113, 26);
            this.buttonSaveFastReport.Style = MetroFramework.MetroColorStyle.Red;
            this.buttonSaveFastReport.TabIndex = 15;
            this.buttonSaveFastReport.Text = "Сохранить отчет";
            this.buttonSaveFastReport.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonSaveFastReport.Visible = false;
            this.buttonSaveFastReport.Click += new System.EventHandler(this.buttonSaveFastReport_Click);
            // 
            // textBoxFastReport
            // 
            this.textBoxFastReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFastReport.Location = new System.Drawing.Point(18, 146);
            this.textBoxFastReport.Multiline = true;
            this.textBoxFastReport.Name = "textBoxFastReport";
            this.textBoxFastReport.PromptText = "Место отчета";
            this.textBoxFastReport.ReadOnly = true;
            this.textBoxFastReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFastReport.Size = new System.Drawing.Size(754, 363);
            this.textBoxFastReport.TabIndex = 14;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(18, 114);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(408, 19);
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "В окне ниже будет показан отчет о результате быстрого анализа.";
            // 
            // buttonStartFastAnalis
            // 
            this.buttonStartFastAnalis.Location = new System.Drawing.Point(673, 25);
            this.buttonStartFastAnalis.Name = "buttonStartFastAnalis";
            this.buttonStartFastAnalis.Size = new System.Drawing.Size(99, 48);
            this.buttonStartFastAnalis.Style = MetroFramework.MetroColorStyle.Red;
            this.buttonStartFastAnalis.TabIndex = 12;
            this.buttonStartFastAnalis.Text = "Начать анализ";
            this.buttonStartFastAnalis.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonStartFastAnalis.Click += new System.EventHandler(this.buttonStartFastAnalis_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(18, 25);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(528, 19);
            this.metroLabel1.TabIndex = 11;
            this.metroLabel1.Text = "Введите название проверяемого сайта/страницы в формате http://www.customsite.ru";
            // 
            // textBoxWeb
            // 
            this.textBoxWeb.Location = new System.Drawing.Point(18, 50);
            this.textBoxWeb.Name = "textBoxWeb";
            this.textBoxWeb.PromptText = "http:\\\\www.customsite.ru";
            this.textBoxWeb.Size = new System.Drawing.Size(613, 23);
            this.textBoxWeb.TabIndex = 0;
            this.textBoxWeb.Text = "http://";
            this.textBoxWeb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxWeb_KeyDown);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.buttonSaveFullReport);
            this.metroTabPage2.Controls.Add(this.textBoxFullReport);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.buttonStartFullAnalis);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.textBoxWebFull);
            this.metroTabPage2.ForeColor = System.Drawing.SystemColors.Control;
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 35);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(790, 527);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Полный анализ";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            // 
            // buttonSaveFullReport
            // 
            this.buttonSaveFullReport.Location = new System.Drawing.Point(659, 114);
            this.buttonSaveFullReport.Name = "buttonSaveFullReport";
            this.buttonSaveFullReport.Size = new System.Drawing.Size(113, 26);
            this.buttonSaveFullReport.Style = MetroFramework.MetroColorStyle.Red;
            this.buttonSaveFullReport.TabIndex = 21;
            this.buttonSaveFullReport.Text = "Сохранить отчет";
            this.buttonSaveFullReport.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonSaveFullReport.Visible = false;
            this.buttonSaveFullReport.Click += new System.EventHandler(this.buttonSaveFullReport_Click);
            // 
            // textBoxFullReport
            // 
            this.textBoxFullReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFullReport.Location = new System.Drawing.Point(18, 146);
            this.textBoxFullReport.Multiline = true;
            this.textBoxFullReport.Name = "textBoxFullReport";
            this.textBoxFullReport.PromptText = "Место полного отчета";
            this.textBoxFullReport.ReadOnly = true;
            this.textBoxFullReport.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxFullReport.Size = new System.Drawing.Size(754, 363);
            this.textBoxFullReport.TabIndex = 20;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(18, 114);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(403, 19);
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "В окне ниже будет показан отчет о результате полного анализа.";
            // 
            // buttonStartFullAnalis
            // 
            this.buttonStartFullAnalis.Location = new System.Drawing.Point(673, 25);
            this.buttonStartFullAnalis.Name = "buttonStartFullAnalis";
            this.buttonStartFullAnalis.Size = new System.Drawing.Size(99, 48);
            this.buttonStartFullAnalis.Style = MetroFramework.MetroColorStyle.Red;
            this.buttonStartFullAnalis.TabIndex = 18;
            this.buttonStartFullAnalis.Text = "Начать анализ";
            this.buttonStartFullAnalis.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonStartFullAnalis.Click += new System.EventHandler(this.buttonStartFullAnalis_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(18, 25);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(464, 19);
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Введите название проверяемого сайта в формате http://www.customsite.ru";
            // 
            // textBoxWebFull
            // 
            this.textBoxWebFull.Location = new System.Drawing.Point(18, 50);
            this.textBoxWebFull.Name = "textBoxWebFull";
            this.textBoxWebFull.PromptText = "www.customsite.ru";
            this.textBoxWebFull.Size = new System.Drawing.Size(613, 23);
            this.textBoxWebFull.TabIndex = 16;
            this.textBoxWebFull.Text = "http://";
            // 
            // keyWordsDataSet1
            // 
            this.keyWordsDataSet1.DataSetName = "keyWordsDataSet";
            this.keyWordsDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = this.keyWordsDataSet1;
            this.bindingSource1.Position = 0;
            // 
            // keyWordTableAdapter1
            // 
            this.keyWordTableAdapter1.ClearBeforeFill = true;
            // 
            // aKeyWordTableAdapter1
            // 
            this.aKeyWordTableAdapter1.ClearBeforeFill = true;
            // 
            // tableAdapterManager1
            // 
            this.tableAdapterManager1.aKeyWordTableAdapter = this.aKeyWordTableAdapter1;
            this.tableAdapterManager1.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager1.keyWordTableAdapter = this.keyWordTableAdapter1;
            this.tableAdapterManager1.UpdateOrder = сheckTheWebsite.keyWordsDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // formCheckWeb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.tabControlAnalis);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "formCheckWeb";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "formCheckWeb";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControlAnalis.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.metroTabPage1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.keyWordsDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl tabControlAnalis;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTextBox textBoxFastReport;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton buttonStartFastAnalis;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroButton buttonSaveFastReport;
        private MetroFramework.Controls.MetroButton buttonSaveFullReport;
        private MetroFramework.Controls.MetroTextBox textBoxFullReport;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroButton buttonStartFullAnalis;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox textBoxWebFull;
        private MetroFramework.Controls.MetroTextBox textBoxWeb;
        public System.Windows.Forms.BindingSource bindingSource1;
        public keyWordsDataSet keyWordsDataSet1;
        public keyWordsDataSetTableAdapters.keyWordTableAdapter keyWordTableAdapter1;
        public keyWordsDataSetTableAdapters.aKeyWordTableAdapter aKeyWordTableAdapter1;
        public keyWordsDataSetTableAdapters.TableAdapterManager tableAdapterManager1;
    }
}