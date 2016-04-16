using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DP_ETL_TOOL.Controls;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {
        ListBox comps = new ListBox();

        List<TableControl> visuals = new List<TableControl>();

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



        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void VisualTabClickEvent(object sender, EventArgs e)
        {
            TableControl tc = new TableControl();
            visuals.Add(tc);
            tc.Text = (comps.SelectedItem.ToString() + visuals.Count.ToString());
            tc.Location = visualTab.PointToClient(Control.MousePosition);
            visualPanel.Controls.Add(tc);
        }

        private void PopulateComps()
        {
            comps.Items.Add("Table");
            comps.Items.Add("Inner join");

            comps.SelectedItem = comps.Items[0];
        }

        

    }
}
