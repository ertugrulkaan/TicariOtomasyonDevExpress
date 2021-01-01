using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyonDevExpress
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // MY COMPUTER -> DETAILS -> YOUR PC NAME
            if (System.Environment.MachineName == "DESKTOP-674NP11")
            {
                Application.Run(new frmMain());
            }
            // PW IS MD5 CRYPTED. USE DECRYPT METHOD TO FIND USER PW'S.
            else
            {
                Application.Run(new frmUserLogin());
            }
        }
    }
}
