using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIDT
{
    public static class Debug
    {
        static int logLine = 0;
        public static void Log(string text)
        {
            Program.window.AppendLogText(text);
            logLine++;
        }

        public static void BeginUpdate()
        {
            Program.window.BeginLogUpdate();
        }

        public static void EndUpdate()
        {
            Program.window.EndLogUpdate();
        }
    }
}
