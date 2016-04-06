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

            MenuStrip menuBar = new MenuStrip();


            menuBar.Items.Add("Exit", null, new EventHandler(MenuBarClickHandler));
            menuBar.Items.Add("Fuck off");
            menuBar.Items.Add("monkey");

            this.Controls.Add(menuBar);
        }

        private void MenuBarClickHandler(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
