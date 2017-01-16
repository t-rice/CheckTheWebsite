namespace сheckTheWebsite
{
    partial class formStartMenu
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formStartMenu));
            this.buttonCheckWeb = new MetroFramework.Controls.MetroButton();
            this.buttonSetting = new MetroFramework.Controls.MetroButton();
            this.buttonExit = new MetroFramework.Controls.MetroButton();
            this.buttonAbout = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // buttonCheckWeb
            // 
            this.buttonCheckWeb.Location = new System.Drawing.Point(58, 98);
            this.buttonCheckWeb.Name = "buttonCheckWeb";
            this.buttonCheckWeb.Size = new System.Drawing.Size(165, 75);
            this.buttonCheckWeb.TabIndex = 0;
            this.buttonCheckWeb.Text = "Анализ веб-ресурса";
            this.buttonCheckWeb.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonCheckWeb.Click += new System.EventHandler(this.buttonCheckWeb_Click);
            // 
            // buttonSetting
            // 
            this.buttonSetting.Location = new System.Drawing.Point(58, 204);
            this.buttonSetting.Name = "buttonSetting";
            this.buttonSetting.Size = new System.Drawing.Size(165, 75);
            this.buttonSetting.TabIndex = 1;
            this.buttonSetting.Text = "Настройки и правила";
            this.buttonSetting.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonSetting.Click += new System.EventHandler(this.buttonSetting_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(177, 426);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(75, 23);
            this.buttonExit.TabIndex = 2;
            this.buttonExit.Text = "Выход";
            this.buttonExit.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(58, 310);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(165, 75);
            this.buttonAbout.TabIndex = 3;
            this.buttonAbout.Text = "О программе";
            this.buttonAbout.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // formStartMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(275, 472);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonSetting);
            this.Controls.Add(this.buttonCheckWeb);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formStartMenu";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroForm.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Red;
            this.Text = "Стартовое меню";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.formStartMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton buttonCheckWeb;
        private MetroFramework.Controls.MetroButton buttonSetting;
        private MetroFramework.Controls.MetroButton buttonExit;
        private MetroFramework.Controls.MetroButton buttonAbout;

    }
}

