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
        ListBox comps = new ListBox();


        public MainForm()
        {
            InitializeComponent();

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);

            visualPanel.AllowDrop = true;
            visualPanel.Click += new EventHandler(VisualTabClickEvent);

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };

            comps.SetBounds(designerTab.Bounds.X, designerTab.Bounds.Y, designerTab.Bounds.Width - 10, designerTab.Bounds.Height -10);
            designerTab.Controls.Add(comps);
            PopulateComps();

            /* l1.MouseMove += new MouseEventHandler(l1_MouseMove);
            l1.MouseDown += new MouseEventHandler(l1_MouseDown);
            l1.MouseUp += new MouseEventHandler(l1_MouseUp);*/

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void VisualTabClickEvent(object sender, EventArgs e)
        {
            //l1.BorderStyle = BorderStyle.FixedSingle;
            //l1.Text = "HABADABA";
            //visualPanel.Controls.Add( l1 );
        }

        private void PopulateComps()
        {
            comps.Items.Add("Table");
            comps.Items.Add("Inner join");
        }

        

    }
}
