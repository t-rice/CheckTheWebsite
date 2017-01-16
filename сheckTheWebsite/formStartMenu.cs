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
using MetroFramework.Properties;
using MetroFramework.Fonts;
using MetroFramework.Components;

namespace сheckTheWebsite
{
    public partial class formStartMenu : MetroForm
    {
        public formStartMenu()
        {
            InitializeComponent();
            
            
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

 
        private void formStartMenu_FormClosing_1(object sender, FormClosingEventArgs e)
        {

        }

        private void formStartMenu_Load(object sender, EventArgs e)
        {

        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            formAbout fAbout = new formAbout();
            if (Application.OpenForms["formAbout"] == null)
                fAbout.Show();
            else
                Application.OpenForms["formAbout"].BringToFront();
        }

        private void buttonSetting_Click(object sender, EventArgs e)
        {
            formSetting fSetting = new formSetting();
            if (Application.OpenForms["formSetting"] == null)
                fSetting.Show();
            else
                 Application.OpenForms["formSetting"].BringToFront();
        }

        private void buttonCheckWeb_Click(object sender, EventArgs e)
        {
            formCheckWeb fCheckWeb = new formCheckWeb();
            if (Application.OpenForms["formCheckWeb"] == null)
                fCheckWeb.Show();
            else
            {
                Application.OpenForms["formCheckWeb"].BringToFront();
            }
        }
    }
}
