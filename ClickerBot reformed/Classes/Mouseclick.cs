using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace ClickerBot_reformed
{
    class Mouseclick
    {
        public int CursorX = 0;
        public int CursorY = 0;

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseActionAdresses
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        public void LeftClick(int x, int y)
        {
        Cursor.Position = new Point(x, y);
            mouse_event((int)(MouseActionAdresses.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseActionAdresses.LEFTUP), 0, 0, 0, 0);
        }

        /// <summary>
        /// fwefwe
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void RightClick(int x, int y)
        {
            Cursor.Position = new Point(x, y);
            mouse_event((int)(MouseActionAdresses.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseActionAdresses.RIGHTUP), 0, 0, 0, 0);
        }
        public void MouseMove1(int x, int y)//Contro.MouseMove
        {
            Cursor.Position = new Point(x, y);
            mouse_event((int)(MouseActionAdresses.MOVE), 0, 0, 0, 0);
        }
    }
}
