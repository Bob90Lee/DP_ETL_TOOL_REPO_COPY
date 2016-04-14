using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();


        }
        



    }
}
