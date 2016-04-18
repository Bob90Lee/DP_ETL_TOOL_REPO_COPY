using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_ETL_TOOL
{
    static class Program
    {
        /// <summary>
        /// Boris Ledecky - Diplomova praca - ETL Toolkit
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form main = new MainForm();
            main.Text = "ETL Toolkit";

            Application.Run(main);

        }


    }
}
