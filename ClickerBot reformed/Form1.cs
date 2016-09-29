using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.Threading;

//-----------TODO LIST--------------
//* Reading Mousecoords and spam the hell out of it[+]
//* Hotkey for Start and Stop!!![+]
//* Friendly Interface(Icons, Statistics etc.)[-]
//* 
//* 
//* 
//* 

namespace ClickerBot_reformed
{
    public partial class Form1 : Form
    {
        Mouseclick mouseevent = new Mouseclick();// Klasse Initialize PUBLIC
        LowLevelKeyboardListener keyboardevent = new LowLevelKeyboardListener();
#region Gloabal Protos
        //---------------------------------------------------------------
        public bool timerSwitch = false;
        public bool Toggle = true;
        public int Keyhash = 13; // 7 = Pause, 13 = Escape
        public int ClickInterval = 25;
        public string ApplicationName = "Clicker Bot v.1";
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

            textBox1.Text = ClickInterval.ToString();

        }

        /// <summary>
        /// _coords[0] x , _coords[1] y; 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = ClickInterval;
            int[] _coords = { Cursor.Position.X, Cursor.Position.Y };
            richTextBox1.Text += ("\nMouse: X: "+_coords[0] +" Y:"+ _coords[1]);
            scrollDown();
            mouseevent.LeftClick(_coords[0], _coords[1]);
        }

        /// <summary>
        /// Keylogger funktion
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        void keyboard_OnKeyPressed(object sender, KeyPressedArgs e)
        {
            if (e.KeyPressed.GetHashCode().Equals(Keyhash) && Toggle == true)
            {
                richTextBox1.Clear();
                richTextBox1.Text += ("Process Started...");
                Toggle = false;
                timerSwitch = true;

            }
            else if (e.KeyPressed.GetHashCode().Equals(Keyhash) && timerSwitch == true)
            {
                richTextBox1.Text += ("\nProcess Stoped");
                timerSwitch = false;
                Toggle = true;

            }
            switch (e.KeyPressed.GetHashCode().Equals(Keyhash) && Toggle == false)//Pause Key
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
            }catch(Exception ex)
            {
                richTextBox1.Text += "NUR ZIFFERN\n";
            }
        }
    }
}
