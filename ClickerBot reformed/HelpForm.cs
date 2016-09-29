using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClickerBot_reformed
{
    public partial class HelpForm : Form
    {
        public static bool Fcredits = false;
        string ApplicationName = "Clicker Bot v.1 - HELP";
        string ApplicationNameCredits = "Clicker Bot v.1 - CREDITS";
        public HelpForm()
        {
            InitializeComponent();
        }

        private void HelpForm_Load(object sender, EventArgs e)
        {
            if(Fcredits == true)//Credits
            {
                TopMost = true;
                ActiveForm.Text = ApplicationNameCredits;
                label1.Text = "Developer:\n\nDeroxQQ & Proto 'Patrick'";
            }
            else
            {
                TopMost = true;
                ActiveForm.Text = ApplicationName;
                label1.Text = "[HOTKEYS]:\n\nESC - Enable & Disable botting\n\n[Information]:\n\nInterval: How fast your bot is clicking!\nPlease choose Carefull - a normal Pc can \nhandle everything but it could stuck/freeze later on.\nBest Option is above 25";

            }
        }
    }
}
