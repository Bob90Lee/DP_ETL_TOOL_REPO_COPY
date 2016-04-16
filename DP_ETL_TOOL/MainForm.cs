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

        private List<TableControl> tables = new List<TableControl>();
        private List<JoinEntity> joins = new List<JoinEntity>();

        private JoinEntity currentJoin = new JoinEntity();

        private bool activatedJoin = false;

        public MainForm()
        {
            InitializeComponent();

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);

            visualPanel.AllowDrop = true;
            visualPanel.MouseClick += new MouseEventHandler(VisualTabClickEvent);

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };

            PopulateObjectList(designerList);

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VisualTabClickEvent(object sender, MouseEventArgs e)
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

            if (e.Button == MouseButtons.Right && designerList.SelectedItem == designerList.Items[1]) // left join
            {
                Control senderControl = (Control)sender;

                if (senderControl != null && senderControl.GetType() == typeof(TableControl) )
                {
                    TableControl tc = (TableControl)senderControl;

                    if (activatedJoin)
                    {
                        currentJoin.setChildEntity(tc.getTableEntity());
                    }
                    else
                    {
                        currentJoin.setMainTable(tc.getTableEntity());
                    }

                    activatedJoin = !activatedJoin;

                    if (activatedJoin)
                    {
                        //designerList.SelectionMode = SelectionMode.None;
                        
                    }
                    else
                    {
                        //designerList.SelectionMode = SelectionMode.One;
                    }

                }
                
                if( currentJoin.getMainTable() != null && currentJoin.getChildTable() != null)
                {
                    joins.Add(currentJoin);
                    currentJoin.setMainTable(null);
                    currentJoin.setChildEntity(null);
                }  
            }   
        }

        private void PopulateObjectList(ListBox b)
        {
            b.Items.Add("Table");
            b.Items.Add("Left join");
            b.Items.Add("Inner join");
            b.Items.Add("Right join");

            b.SelectedItem = b.Items[0];
        }

        private void OnSelectedChangeObjectList(ListBox b)
        {
            activatedJoin = false;
        }

    }
}
