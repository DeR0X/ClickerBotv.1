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
        CPU CpuLoad = new CPU();
        

        public static int Fcredits = 0;
        string ApplicationNameHelp = Form1.ApplicationName +" - HELP";
        string ApplicationNameCredits = Form1.ApplicationName + " - CREDITS";
        string ApplicationNameStatistics = Form1.ApplicationName + " - Statistics";
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
                    label1.Text = "Developer:\n\nDeroxQQ and Proto 'Patrick'";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    Fcredits = 0;
                    break;//case 1 break;
                case 2://help Window
                    TopMost = true;
                    Text = ApplicationNameHelp;
                    label1.Text = "[HOTKEYS]:\n\n" + Form1._Keyhash + " - Enable/Disable botting\n\n[Information]:\n\nInterval: How fast your bot is clicking!\nPlease choose carefull - a normal Pc can \nhandle everything but it could stuck/freeze later on.\nBest Option is above 25";
                    label2.Text = "";
                    label3.Text = "";
                    label4.Text = "";
                    label5.Text = "";
                    Fcredits = 0;
                    break;//case 2 break;
                case 3://Statistics Window
                    TopMost = true;
                    Text = ApplicationNameStatistics;
                    label1.Text = "Amount of Clicks: " + Form1.clickAmount;

                    if (Form1.ClickInterval != 0 && Form1.CurrentRuntime != 0)
                    {
                        label2.Text = "Runtime:" + Form1.Runtime + " sec.";
                        label3.Text = "CPS: 0" + Form1.CurrentClickAmount / Form1.CurrentRuntime;
                        label4.Text = "Current Runtime: " + Form1.CurrentRuntime + " sec.";
                        label5.Text = "Current Click Amount: " + Form1.CurrentClickAmount;
                    }else
                    {
                        label3.Text = "CPS: UNDEFINED";
                    }
                    break;// case 3 break
            }
        }
        public void Refreshlabel()//gibt Amount of Clicks weiter zum refreshen
        {
            if (Fcredits == 3)
            {
                label1.Text = "Amount of Clicks: " + Form1.clickAmount.ToString();
                label2.Text = "Runtime: " + Form1.Runtime + " sec.";
                if (Form1.ClickInterval != 0 && Form1.CurrentRuntime != 0)
                {
                    label3.Text = "CPS: " + (Form1.CurrentClickAmount / Form1.CurrentRuntime).ToString();
                    label4.Text = "Current Runtime: " + Form1.CurrentRuntime + " sec.";
                    label5.Text = "Current Click Amount: " + Form1.CurrentClickAmount;
                }
                else
                {
                    label3.Text = "CPS: UNDEFINED";

                }
            }

        }
    }
}
