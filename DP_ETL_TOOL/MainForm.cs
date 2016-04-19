using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DP_ETL_TOOL.Controls;
using System.Drawing;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {

        private List<TableControl> tables = new List<TableControl>();
        private List<JoinControl> joins = new List<JoinControl>();

        private JoinControl currentJoin;

        Control dummy = new Control();

        private bool activatedJoin = false;

        public MainForm()
        {
            InitializeComponent();

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);

            visualPanel.AllowDrop = true;
            visualPanel.MouseClick += new MouseEventHandler(VisualPanelClickEvent);

            visualPanel.BackgroundImage = Image.FromFile(@"C:\Users\BORIS\Documents\Visual Studio 2015\Projects\DP_ETL_TOOL\DP_ETL_TOOL\Graphics\background.png");           

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };

            PopulateObjectList(designerList);

            designerList.SelectedValueChanged += new EventHandler(DesignerListValueChanged);

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VisualPanelClickEvent(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Right && designerList.SelectedItem == designerList.Items[0]) // table
            {

                TableControl tc = new TableControl();
                tc.MouseClick += new MouseEventHandler(TableClick);
                tables.Add(tc);
                tc.Location = visualTab.PointToClient(Control.MousePosition);
                visualPanel.Controls.Add(tc);
            }

        }

        private void TableClick(object sender, MouseEventArgs e)
        {            

            if (e.Button == MouseButtons.Right && designerList.SelectedItem != designerList.Items[0]) // join
            {
                Control senderControl = (Control)sender;

                if (senderControl != null && senderControl.GetType() == typeof(TableControl) )
                {
                    TableControl tc = (TableControl)senderControl;

                    if (activatedJoin)
                    {
                        currentJoin.setChildEntity(tc);
                        activatedJoin = false;
                    }
                    else
                    {
                        Enums.JoinType jt;

                        if (designerList.SelectedItem == designerList.Items[1])
                        {
                            jt = Enums.JoinType.Left;
                        }
                        else if (designerList.SelectedItem == designerList.Items[2])
                        {
                            jt = Enums.JoinType.Inner;
                        }
                        else if (designerList.SelectedItem == designerList.Items[3])
                        {
                            jt = Enums.JoinType.Right;
                        }
                        else
                        {
                            jt = Enums.JoinType.Full;
                        }

                        currentJoin = new JoinControl(visualPanel, jt);
                        currentJoin.setMainTable(tc);
                        activatedJoin = true;
                    }

                }
                
                if( currentJoin.getMainTable() != null && currentJoin.getChildTable() != null)
                {
                    joins.Add(currentJoin);
                    visualPanel.Controls.Add(currentJoin);
                    activatedJoin = false;
                }  
            }

        }

        private void PopulateObjectList(ListBox b)
        {
            b.Items.Add("Table");
            b.Items.Add("Left join");
            b.Items.Add("Inner join");
            b.Items.Add("Right join");
            b.Items.Add("Full join");

            b.SelectedItem = b.Items[0];
        }

        private void DesignerListValueChanged(object sender, EventArgs e)
        {
            visualPanel.BringToFront();

            foreach (Control c in visualPanel.Controls){
                if (c is JoinControl)
                {
                    c.Enabled = false;
                }
            }
        }
    }
}
