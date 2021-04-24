using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GGAO.Engine;
namespace StartPoint
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
            //Application.Run(new GGAO.GGAOWindow());
            Application.Run(new GGAO.LoginWindow());
            //Application.Run(new GGAO.Reports.Form1() );
        }
    }
}
