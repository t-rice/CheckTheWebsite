using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using System.Net;
using MetroFramework.Forms;
using MetroFramework.Controls;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.OleDb;
using System.IO;

namespace сheckTheWebsite
{
    public partial class formCheckWeb : MetroForm
    {
        public formCheckWeb()
        {
            InitializeComponent();
        }

        static bool CheckURL(String url, MetroTextBox textBoxWeb)
        {
            if (String.IsNullOrEmpty(url) || url.Length > 500)
                return false;
            if (url.Length < 7 || url.Substring(0, 7) != "http://")
            {
                if (!(url.Length > 7 && url.Substring(0, 8) == "https://"))
                {
                    url = "http://" + url;
                    textBoxWeb.Text = url;
                }
            }

            if (Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute) == false)
                return false;

            WebRequest request = WebRequest.Create(url);
            try
            {
                HttpWebResponse res = request.GetResponse() as HttpWebResponse;

                if (res.StatusDescription == "OK")
                    return true;
            }
            catch
            {
                MessageBox.Show("Извините, но мы не смогли обработать ваш URL, попробуйте ещё раз..", "Ошибка URL", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);
                return false;
            }
            return false;
        }


        private void buttonStartFastAnalis_Click(object sender, EventArgs e)
        {
            if (CheckURL(textBoxWeb.Text, textBoxWeb))
            {
                if (!textBoxWeb.Text.EndsWith("/"))
                    textBoxWeb.Text += '/';

                textBoxFastReport.Text = extWebFunction.analisWebSite(textBoxWeb.Text, 0);
                metroLabel2.Text = "Отчет о возможном наличии запрещенного контента на веб ресурсе.";
                buttonSaveFastReport.Visible = true;
                this.Refresh();
            }
            else
            {
                textBoxWeb.Text = "Попытайтесь ещё раз ввести URL";
            }
        }

        private void textBoxWeb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (tabControlAnalis.SelectedTab.Name == metroTabPage1.Name)
                {
                    buttonStartFastAnalis.PerformClick();
                }
                else
                {
                    buttonStartFullAnalis.PerformClick();
                }
            }
        }

        private void buttonSaveFastReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "text файлы (*.txt) | *.txt";
            saveFileDialog.InitialDirectory = Settings.Default.saveFilePath;


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(saveFileDialog.FileName);
                tw.WriteLine(textBoxFastReport.Text);
                tw.Close();
            }
        }

        private void buttonSaveFullReport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.Filter = "text файлы (*.txt) | *.txt";
            saveFileDialog.InitialDirectory = Settings.Default.saveFilePath;


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                TextWriter tw = new StreamWriter(saveFileDialog.FileName);
                tw.WriteLine(textBoxFullReport.Text);
                tw.Close();
            }
        }

        private string toMainSite(string longUrl)
        {
            Uri longUri = new Uri(longUrl);
            return longUri.Scheme+"://"+longUri.Host+"/";
        }

        private void buttonStartFullAnalis_Click(object sender, EventArgs e)
        {            
            if (CheckURL(textBoxWebFull.Text, textBoxWebFull))
            {
                textBoxWebFull.Text = toMainSite(textBoxWebFull.Text);
                this.Refresh();
                textBoxFullReport.Text = extWebFunction.analisWebSite(textBoxWebFull.Text, Settings.Default.depthAnalis);
                metroLabel3.Text = "Полный отчет о возможном наличии запрещенного контента на веб ресурсе.";
                buttonSaveFullReport.Visible = true;
                this.Refresh();
            }
            else
            {
                textBoxWebFull.Text = "Попытайтесь ещё раз ввести URL";
            }
        }
    }
   
}
