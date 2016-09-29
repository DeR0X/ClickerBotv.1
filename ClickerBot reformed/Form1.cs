using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;

//-----------TODO LIST--------------
//* Reading Mousecoords and spam the hell out of it[+]
//* Hotkey for Start and Stop!!![+]
//* Friendly Interface(Icons, Statistics etc.)[-]
//* 
//------------BUGLIST---------------
//• Scrolling Automatically while Window in background if typing in another random application
//
//
namespace ClickerBot_reformed
{
    public partial class Form1 : Form
    {
        Mouseclick mouseevent = new Mouseclick();// Klasse Initialize PUBLIC
        LowLevelKeyboardListener keyboardevent = new LowLevelKeyboardListener();
        NewWindow NewWindow = new NewWindow();


        

#region Gloabal Values
        //---------------------------------------------------------------
        public bool timerSwitch = false;
        public static bool Toggle = true;
        public int pressed = 0;
        public int Keyhash = 13; // 7 = Pause, 13 = Escape
        public static string _Keyhash = "Escape";
        public static int Runtime = 0;
        public static int ClickInterval = 25;
        public string ApplicationName = "Clicker Bot v.1";
        public string LatesVersion_URL = "https://github.com/DeR0X/ClickerBotv.1";
        public static int clickAmount = 0;
        //----------------------------------------------------------------
#endregion
        public Form1()//Hier darf nichts mehr rein...
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ActiveForm.Text = ApplicationName;
            keyboardevent = new LowLevelKeyboardListener();
            keyboardevent.OnKeyPressed += keyboard_OnKeyPressed;
            keyboardevent.HookKeyboard();

            textBox1.Text = ClickInterval.ToString(); // puts in the ClickerInterval Value
            timer2.Enabled = true;
        }

        /// <summary>
        /// _coords[0] x , _coords[1] y; 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            NewWindow.Refreshlabel();
            if(ClickInterval == 0)
            {
                richTextBox1.Text = "PLEASE SET AN INTERVAL FOR THE PROGRAMM!!!!\nOr it wont RUN!";
            }
            else
            {
                clickAmount += 1;//zähler
                timer1.Interval = ClickInterval;
                int[] _coords = { Cursor.Position.X, Cursor.Position.Y };
                richTextBox1.Text += ("\nMouse: X: " + _coords[0] + " Y:" + _coords[1]);
                scrollDown();
                mouseevent.LeftClick(Cursor.Position.X, Cursor.Position.Y);
            }

        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Interval = 1000 *1; //timer runs everysecound
            Runtime++;
            label3.Text = Runtime.ToString();

        }
        /// <summary>
        /// Keylogger funktion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void keyboard_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if(pressed == 1)
            {
                Keyhash = e.KeyPressed.GetHashCode();
                _Keyhash = e.KeyPressed.ToString();
                button1.Text = "Set Hotkey";
                label2.Text = "Hotkey: " + e.KeyPressed.ToString();
                pressed = 0;

            }
            else if (e.KeyPressed.GetHashCode().Equals(Keyhash) && Toggle == true)
            {
                richTextBox1.Clear();
                richTextBox1.Text += ("Process Started...");
                Toggle = false;

            }
            else if (e.KeyPressed.GetHashCode().Equals(Keyhash) && Toggle == false)
            {
                if(ClickInterval == 0)
                {

                }else
                {
                    richTextBox1.Text += ("\nProcess Stoped");
                    Toggle = true;
                }


            }
            switch (e.KeyPressed.GetHashCode().Equals(Keyhash) && Toggle == false)//Toggle pause undso
            {
                case false:
                    timer1.Enabled = false;
                    scrollDown();
                    //richTextBox1.Text += "\nProcess: " + e.KeyPressed.GetHashCode()+ " ("+e.KeyPressed.ToString()+")";
                    break;
                case true:
                    timer1.Enabled = true;
                    scrollDown();
                    break;
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            keyboardevent.UnHookKeyboard();
        }

        /// <summary>
        /// Writes in the richTextBox
        /// </summary>
        /// <param name="Write"></param>
        public static void richTextBox_Write(string Write)
        {
            Form1 form1 = new Form1();
            form1.richTextBox1.Text += Write;
        }
        /// <summary>
        /// Scrolls down in the richTextBox1
        /// USAGE: scrollDown();
        /// </summary>
        public void scrollDown()
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                ClickInterval = Convert.ToInt32(textBox1.Text);
            }catch(Exception) // ex missing here
            {
                richTextBox1.Text += "Numbers >1 will be crashing the programm.";
            }
        }
        /// <summary>
        /// Only numbers in this box hee
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "Press a KEY";
            pressed = 1;
        }
        #region StripMenu


        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)//credits
        {
            NewWindow.Fcredits = 1;
            NewWindow.ShowDialog();
        }
        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)//help
        {
            NewWindow.Fcredits = 2;
            NewWindow.ShowDialog();
        }
        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)//Statistics
        {
            for(int i = 0; i<= 1; i++)
            {
                NewWindow.Refreshlabel();
            }
            NewWindow.Fcredits = 3;
            NewWindow.ShowDialog();
        }
        private void latestVersionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(LatesVersion_URL);//create a new Tab!
        }


        #endregion


    }
}
