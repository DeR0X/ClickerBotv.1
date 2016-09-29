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
    public partial class NewWindow : Form
    {
        public static int Fcredits = 0;
        string ApplicationName = "Clicker Bot v.1 - HELP";
        string ApplicationNameCredits = "Clicker Bot v.1 - CREDITS";
        string ApplicationNameStatistics = "Clicker Bot v.1 - Statistics";
        public NewWindow()
        {
            InitializeComponent();
        }

        public void HelpForm_Load(object sender, EventArgs e)
        {
            
            switch (Fcredits)//Which Window is used
            {
                case 1://Credits Window
                    TopMost = true;
                    Text = ApplicationNameCredits;
                    label1.Text = "Developer:\n\nDeroxQQ & Proto 'Patrick'";
                    Fcredits = 0;
                    break;
                case 2://help Window
                    TopMost = true;
                    Text = ApplicationName;
                    label1.Text = "[HOTKEYS]:\n\n" + Form1._Keyhash + " - Enable/Disable botting\n\n[Information]:\n\nInterval: How fast your bot is clicking!\nPlease choose carefull - a normal Pc can \nhandle everything but it could stuck/freeze later on.\nBest Option is above 25";
                    Fcredits = 0;
                    break;
                case 3://Statistics Window
                    TopMost = true;
                    label1.Text = "Amount of Clicks: " + Form1.clickAmount;
                    if(Form1.ClickInterval != 0)
                    {
                        label1.Text += "\n\nCPS: " + 100 / Form1.ClickInterval;
                    }else
                    {
                        label1.Text += "\n\nCPS: UNDEFINED";
                    }

                    Text = ApplicationNameStatistics;
                    break;
            }
        }
        public void Refreshlabel()//gibt Amount of Clicks weiter zum refreshen
        {
            if (Form1.Toggle == false)
            {
                if (Fcredits == 3)
                {
                    label1.Text = "Amount of Clicks: " + Form1.clickAmount.ToString();
                    if (Form1.ClickInterval != 0)
                    {

                        label1.Text += "\n\nCPS: " + (100 / Form1.ClickInterval).ToString();
                    }
                    else
                    {
                        label1.Text = "Amount of Clicks: " + Form1.clickAmount.ToString();
                        label1.Text += "\n\nCPS : UNDEFINED";
                       // Form1.richTextBox_Write("PLEASE SET AN INTERVAL FOR THE PROGRAMM!!!!");
                        
                    }
                }
            }

        }
    }
}
