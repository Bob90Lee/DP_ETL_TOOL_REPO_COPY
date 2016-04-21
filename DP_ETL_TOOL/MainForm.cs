using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DP_ETL_TOOL.Controls;
using DP_ETL_TOOL.Entities;
using System.Drawing;
using DP_ETL_TOOL.Types;
using DP_ETL_TOOL.Modules;
using System.Text;
using DP_ETL_TOOL.Forms;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {

        private List<TableControl> tables = new List<TableControl>();
        private List<JoinControl> joins = new List<JoinControl>();
        private JoinControl currentJoin;

        private bool activatedJoin = false;

        public MainForm()
        {
            InitializeComponent();

            visualPanel.AllowDrop = true;
            visualPanel.MouseClick += new MouseEventHandler(VisualPanelClickEvent);
            visualPanel.BackgroundImage = Image.FromFile(@"C:\Users\BORIS\Documents\Visual Studio 2015\Projects\DP_ETL_TOOL\DP_ETL_TOOL\Graphics\background.png");

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };

            PopulateObjectList(lbDesignerList);
            PopulateModesList(lbDesignerMode);

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);
            lbDesignerList.SelectedValueChanged += new EventHandler(DesignerListValueChanged);
            lbDesignerMode.SelectedValueChanged += new EventHandler(DesignerModeValueChanged);
            rightTabs.SelectedIndexChanged += new EventHandler(RightTabsSelectedChanged);
            codeEdit.GotFocus += new EventHandler(CodeEditRefresh);
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VisualPanelClickEvent(object sender, MouseEventArgs e)
        {
            if (lbDesignerList.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Right && lbDesignerList.SelectedItem == lbDesignerList.Items[0]) // table
                {
                    TableControl tableControl = new TableControl();
                    tableControl.MouseClick += new MouseEventHandler(OnTableClick);
                    tableControl.DoubleClick += new EventHandler(OnTableDoubleClick);
                    tables.Add(tableControl);
                    tableControl.Location = visualTab.PointToClient(Control.MousePosition);
                    visualPanel.Controls.Add(tableControl);
                }
            }
        }

        private void OnTableClick(object sender, MouseEventArgs e)
        {
            if (lbDesignerList.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Right && lbDesignerList.SelectedItem != lbDesignerList.Items[0]) // join
                {
                    Control senderControl = (Control)sender;

                    if (senderControl != null && senderControl.GetType() == typeof(TableControl))
                    {
                        TableControl tc = (TableControl)senderControl;

                        if (activatedJoin)
                        {
                            currentJoin.SetChildTable(tc);
                            activatedJoin = false;
                        }
                        else
                        {
                            Enums.JoinType jt;

                            if (lbDesignerList.SelectedItem == lbDesignerList.Items[1])
                            {
                                jt = Enums.JoinType.Left;
                            }
                            else if (lbDesignerList.SelectedItem == lbDesignerList.Items[2])
                            {
                                jt = Enums.JoinType.Inner;
                            }
                            else if (lbDesignerList.SelectedItem == lbDesignerList.Items[3])
                            {
                                jt = Enums.JoinType.Right;
                            }
                            else
                            {
                                jt = Enums.JoinType.Full;
                            }

                            currentJoin = new JoinControl(visualPanel, jt);
                            currentJoin.SetMainTable(tc);
                            activatedJoin = true;
                        }

                    }

                    if (currentJoin.GetMainTable() != null && currentJoin.GetChildTable() != null)
                    {
                        joins.Add(currentJoin);
                        visualPanel.Controls.Add(currentJoin);
                        activatedJoin = false;
                    }
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

        private void PopulateModesList(ListBox b)
        {
            b.Items.Add("Create Table");
            b.Items.Add("Create View");
            b.Items.Add("Create Extraction Procedure");
            b.SelectedItem = b.Items[1];
        }

        private void DesignerListValueChanged(object sender, EventArgs e)
        {
            visualPanel.BringToFront();

            foreach (Control c in visualPanel.Controls)
            {
                if (c is JoinControl)
                {
                    c.Enabled = false;
                }
            }
        }

        private void DesignerModeValueChanged(object sender, EventArgs e)
        {
            ListBox lb = (ListBox)sender;

            lbDesignerList.Items.Clear();

            if (lb.SelectedItem == lb.Items[1])
            {
                PopulateObjectList(lbDesignerList);
            }

        }

        private void RightTabsSelectedChanged(object sender, EventArgs e)
        {
            TabControl tc = (TabControl)sender;

            if (tc.SelectedIndex == 1)
            {
                codeEdit.Clear();

                CodeParser parser = new CodeParser(Enums.ModeType.View, tables, joins);
                codeEdit.AppendText(parser.GetCode());

                codeEdit.Focus();
            }
        }

        private void CodeEditRefresh(object sender, EventArgs e)
        {
            SyntaxTextBoxControl te = (SyntaxTextBoxControl)sender;
            te.RefreshSyntax();
        }

        ///

        private void CreateTableEditGUI(TableControl tc)
        {
            TableEntity te = tc.getTableEntity();

            StringBuilder sb = new StringBuilder();

            EditObjectForm editForm = new EditObjectForm();
            editForm.Text = this.Text;

            populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
            populateComboBoxColumnType((ComboBox)editForm.Controls["combColumnType"]);
            populateComboBoxJoins((ComboBox)editForm.Controls["combJoins"], joins, te.GetName());

            editForm.Controls["tbTableName"].Text = te.GetName();
            editForm.Controls["tbSchemaName"].Text = te.GetSchema();

            editForm.Controls["chckIsKey"].Click += (sender, args) =>
            {

            };

            editForm.Controls["chckIsUnique"].Click += (sender, args) =>
            {

            };

            editForm.Controls["btnAdd"].Click += (sender, args) =>
            {
                ComboBox cb = (ComboBox)editForm.Controls["combColumnType"];

                if (editForm.Controls["tbColumnName"].Text.ToString().Length > 0 && cb.SelectedItem != null && editForm.Controls["tbColumnLength"].Text.ToString().Length > 0)
                {
                    int length = 0;
                    int.TryParse(editForm.Controls["tbColumnLength"].Text, out length);

                    CheckBox check = (CheckBox)editForm.Controls["chckIsKey"];

                    te.AddColumn(editForm.Controls["tbColumnName"].Text.ToString(), cb.SelectedText, length, check.Checked);

                    populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
                }
            };


            editForm.Controls["btnRemove"].Click += (sender, args) =>
            {
                ComboBox cb = (ComboBox)editForm.Controls["combColumn"];

                if (cb.SelectedItem != null)
                {

                    //te.removeColumn(cb.SelectedItem.ToString());

                    populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
                }

            };

            editForm.Controls["btnOk"].Click += (sender, args) =>
            { // save form
                te.SetTableName(editForm.Controls["tbTableName"].Text);
                te.SetSchemaName(editForm.Controls["tbSchemaName"].Text);

                tc.Text = te.GetName();

                editForm.Dispose();

            };

            editForm.Controls["btnCancel"].Click += (sender, args) =>
            { // close form
                editForm.Dispose();
            };

            editForm.Controls["btnDeleteTable"].Click += (sender, args) =>
            { // delete table and everything including her entity




                editForm.Dispose();


            };

            editForm.ShowDialog(this);
        }

        private void populateComboBoxColumnType(ComboBox cb)
        {
            cb.Items.Add("VARCHAR2");
            cb.Items.Add("NUMBER");
        }

        private void populateComboBoxColumn(ComboBox cb, TableEntity te)
        {
            cb.Items.Clear();

            List<ColumnEntity> columns = te.GetColumns();

            if (columns != null)
            {
                foreach (ColumnEntity c in columns)
                {
                    cb.Items.Add(c.GetColumnName());
                }
            }
        }

        private void populateComboBoxJoins(ComboBox cb, List<JoinControl> jc, string tableName)
        {
            cb.Items.Clear();

            List<JoinControl> joins = jc;

            if (joins != null)
            {
                foreach (JoinControl j in joins)
                {


                    if (j.GetMainTable() != null)
                    {
                        String s = j.GetMainTable().getTableEntity().GetName();
                        if (s == tableName)
                        {
                            cb.Items.Add(s);

                        }

                    }
                }
            }
        }

        private void OnTableDoubleClick(object sender, EventArgs e)
        {
            TableControl tc = (TableControl)sender;
            CreateTableEditGUI(tc);
        }

    }
}
