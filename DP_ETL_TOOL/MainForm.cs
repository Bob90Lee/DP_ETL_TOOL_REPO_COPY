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

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();

            
        }

        private void workplaceTab_Click(object sender, EventArgs e)
        {
            Button b = new Button();
            b.Text = "XXX";
            b.BackColor = Color.Red;
            b.Visible = true;
            b.SetBounds(this.Width - 300, this.Height - 100, 100, 50);
            
            workplaceTab.Controls.Add(b);
        }


    }
}
