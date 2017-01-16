using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Components;
using MetroFramework.Controls;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Data.OleDb;

namespace сheckTheWebsite
{
    public partial class formSetting : MetroForm
    {

        public formSetting()
        {
            InitializeComponent();
            textBoxDir.Text = Settings.Default.saveFilePath;
            textBoxMinCount.Text = Settings.Default.estimateMinFreq.ToString();
            textBoxGreatCount.Text = Settings.Default.estimateGreatFreq.ToString();
            textBoxMinFreq.Text = Settings.Default.minFreqValue.ToString();
            textBoxGreatFreq.Text = Settings.Default.greatFreqValue.ToString();
            textBoxDephtFull.Text = Settings.Default.depthAnalis.ToString();
            textBoxCountProof.Text = Settings.Default.countProf.ToString();
        }


        private void formSetting_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "categoryKeyWordsDataSet.Category". При необходимости она может быть перемещена или удалена.
            this.categoryTableAdapter.Fill(this.categoryKeyWordsDataSet.Category);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "keyWordsDataSet.keyWord". При необходимости она может быть перемещена или удалена.
            this.keyWordTableAdapter.Fill(this.keyWordsDataSet.keyWord);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "keyWordsDataSet.aKeyWord". При необходимости она может быть перемещена или удалена.
            this.aKeyWordTableAdapter.Fill(this.keyWordsDataSet.aKeyWord);
        }

        private void buttonSaveDB_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.keyWordsDataSetBindingSource.EndEdit();
                if (toggleKeyAKey.Checked == false)
                {
                    this.keyWordTableAdapter.Update(this.keyWordsDataSet.keyWord);
                }
                else
                {
                    this.aKeyWordTableAdapter.Update(this.keyWordsDataSet.aKeyWord);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Сохранение не удалось.");
            }
        }


        private void toggleKeyAKey_CheckedChanged(object sender, EventArgs e)
        {
            if (toggleKeyAKey.Checked == false)
            {
                dataGridView.DataSource = keyWordsDataSet.keyWord;
                metroLabel2.Text = "База ключевых слов для поиска по страницам сайта.";
            }
            else
            {
                dataGridView.DataSource = keyWordsDataSet.aKeyWord;
                metroLabel2.Text = "База ключевых, уменьщающих вероятность опасного контента. \nВ данный момент таблица не используется для анализа, будет добавлена в следующих версиях.";
            }
        }

        private void buttonSaveSetting_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.categoryBindingSource.EndEdit();
                this.categoryTableAdapter.Update(this.categoryKeyWordsDataSet.Category);
            
                Settings.Default.saveFilePath = textBoxDir.Text;
                Settings.Default.estimateMinFreq = Convert.ToDouble(textBoxMinCount.Text);
                Settings.Default.estimateGreatFreq = Convert.ToDouble(textBoxGreatCount.Text);
                Settings.Default.minFreqValue = Convert.ToDouble(textBoxMinFreq.Text);
                Settings.Default.greatFreqValue = Convert.ToDouble(textBoxGreatFreq.Text);

                Properties.Settings.Default.Save();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Сохранение не удалось.");
            }
        }

        private void buttonView_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.SelectedPath = Settings.Default.saveFilePath;
            if(folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void t_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            MetroFramework.Controls.MetroTextBox tBox = (MetroFramework.Controls.MetroTextBox)sender;
            if (ch == '.')
            {
                ch = ',';
                e.KeyChar = ',';
            }
            if (e.KeyChar != 22)
            {
                if (ch == ',' && (tBox.Text.IndexOf(",") != -1 || tBox.Text=="") )
                {
                    e.Handled = true;
                    return;
                }
                if (!Char.IsDigit(ch) && ch != 8 && ch != ',')
                {
                    e.Handled = true;
                }
            }
            else
            {
                double d;
                Clipboard.SetText(Clipboard.GetText().Replace('.', ','));
                if (!double.TryParse(Clipboard.GetText(), out d) || d < 0)
                {
                    MessageBox.Show("Не удалось вставить содержимое буфера обмена"); 
                    e.Handled = true;
                }
            }
        }

        private void t_KeyPressInt(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 22)
            {
                if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                {
                    e.Handled = true;
                }
            }
            else
            {
                int d;
                if(!int.TryParse(Clipboard.GetText(), out d) || d<0)
                {
                    MessageBox.Show("Не удалось вставить содержимое буфера обмена");
                    e.Handled = true;
                }
            }
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveSettingFull_Click(object sender, EventArgs e)
        {
            try
            {
                Settings.Default.depthAnalis = Convert.ToInt32(textBoxDephtFull.Text);
                Settings.Default.countProf = Convert.ToInt32(textBoxCountProof.Text);

                Properties.Settings.Default.Save();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Сохранение не удалось.");
            }
        }
    }
}
