using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace plugin_hipoqih
{
    static class Program
    {
        public static hipoqih frmMain = null;
        public static splash frmSplash = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmSplash = new splash();
            frmSplash.Show();
            frmMain = new hipoqih();
            frmSplash.Refresh();
            Application.Run(frmMain);
        }
    }
}