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

            PopulateModesList(lbDesignerMode);
            PopulateObjectList(lbDesignerList, lbDesignerMode);

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
                if (e.Button == MouseButtons.Right /* && lbDesignerList.SelectedItem != lbDesignerList.Items[0] */) // join
                {
                    int numCols = 0;

                    Control senderControl = (Control)sender;
                    TableControl tc = null;
                    TableEntity te = null;

                    if (senderControl != null)
                    {
                        tc = (TableControl)senderControl;
                        te = tc.GetTableEntity();

                        List<ColumnEntity> ce = te.GetColumns();
                        numCols = ce.Count;
                    }

                    if (numCols > 0)
                    {
                        SelectColumnForm selectColumnForm = new SelectColumnForm();
                        ComboBox comboColumn = (ComboBox)selectColumnForm.Controls["combColumnName"];
                        ColumnEntity column = null;
                        populateComboBoxColumn(comboColumn, te);

                        selectColumnForm.Controls["btnOk"].Click += (s, a) => {
                            if (comboColumn.SelectedItem != null)
                            {
                                string[] columnName = comboColumn.SelectedItem.ToString().Split(null);
                                column = te.GetColumnByName(columnName[0]);

                                selectColumnForm.Dispose();
                            }
                        };

                        selectColumnForm.ShowDialog(this);

                        if (senderControl.GetType() == typeof(TableControl) && column != null)
                        {

                            if (activatedJoin)
                            {
                                currentJoin.SetChildTable(tc);
                                currentJoin.GetJoinEntity().GetJoinPairs()[0].SetChildTable(te);
                                currentJoin.GetJoinEntity().GetJoinPairs()[0].SetChildColumn(column);
                                activatedJoin = false;
                            }
                            else
                            {
                                Enums.JoinType jt = Enums.JoinType.Inner; // default join type

                                currentJoin = new JoinControl(visualPanel, jt);
                                currentJoin.SetMainTable(tc);
                                currentJoin.GetJoinEntity().AddJoinPair(new ColumnPairEntity(te, null, column, null));
                                activatedJoin = true;
                            }

                        }

                        if (currentJoin.GetMainTable() != null && currentJoin.GetChildTable() != null)
                        {
                            if (te.GetJoins() != null && te.GetJoins().Count > 0)
                            {

                                foreach (JoinEntity je in te.GetJoins())
                                {
                                    ColumnPairEntity currentJoinPair = currentJoin.GetJoinEntity().GetJoinPairs()[0];
                                    if (!je.FindExistingJoinPair(currentJoinPair.GetParentColumn().GetColumnName(), currentJoinPair.GetChildColumn().GetColumnName()))
                                    {
                                        joins.Add(currentJoin);
                                        te.AddJoinEntity(currentJoin.GetJoinEntity());
                                        visualPanel.Controls.Add(currentJoin);
                                    }
                                    else {
                                        MessageBox.Show("Can not create join! Join already exists on " + tc.GetTableEntity().GetName() + "! Add join columns instead!", "ETL Tool", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                                    }
                                }
                            }
                            else
                            {
                                joins.Add(currentJoin);
                                te.AddJoinEntity(currentJoin.GetJoinEntity());
                                visualPanel.Controls.Add(currentJoin);
                            }

                            activatedJoin = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Can not create join! First, add columns to the table " + tc.GetTableEntity().GetName() + "!", "ETL Tool", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void PopulateObjectList(ListBox box, ListBox mode)
        {
            box.Items.Clear();

            if (mode.SelectedItem.ToString() == "Transformation Layer")
            {
                box.Items.Add("View");
                box.SelectedItem = box.Items[0];
            }
        }

        private void PopulateModesList(ListBox b)
        {
            b.Items.Add("Extraction Layer");
            b.Items.Add("Transformation Layer");
            b.Items.Add("Load Layer");

            b.SelectedItem = b.Items[0];
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
                PopulateObjectList(lbDesignerList, lb);
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
            TableEntity te = tc.GetTableEntity();

            StringBuilder sb = new StringBuilder();

            EditTableForm editForm = new EditTableForm();
            editForm.Text = this.Text;

            populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
            populateComboBoxColumnType((ComboBox)editForm.Controls["combColumnType"]);
            populateComboBoxJoins((ComboBox)editForm.Controls["combJoins"], joins, te.GetName());

            editForm.Controls["tbTableName"].Text = te.GetName();
            editForm.Controls["tbSchemaName"].Text = te.GetSchema();

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

                    CheckBox check = (CheckBox)editForm.Controls["chckIsUnique"];

                    te.AddColumn(editForm.Controls["tbColumnName"].Text.ToString(), cb.SelectedItem.ToString(), length, check.Checked);

                    populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
                }
            };


            editForm.Controls["btnEditColumn"].Click += (sender, args) =>
            {
                EditColumnForm editColumnForm = new EditColumnForm();

                ComboBox cb = (ComboBox)editForm.Controls["combColumn"];

                if (cb.SelectedItem != null)
                {
                    ColumnEntity column = te.GetColumnByName(cb.SelectedItem.ToString());

                    editColumnForm.Controls["tbColumnName"].Text = column.GetColumnName();
                    editColumnForm.Controls["combColumnType"].Text = column.GetColumnType();
                    editColumnForm.Controls["tbColumnLength"].Text = column.GetColumnLength().ToString();
                    CheckBox check = (CheckBox)editColumnForm.Controls["chckIsUnique"];

                    check.Checked = column.GetColumnIsUnique();

                    populateComboBoxColumnType((ComboBox)editColumnForm.Controls["combColumnType"]);

                    editColumnForm.Controls["btnOk"].Click += (innerSender, innerArgs) =>
                    {
                        int length = 0;
                        int.TryParse(editForm.Controls["tbColumnLength"].Text, out length);

                        column.SetColumnName(editColumnForm.Controls["tbColumnName"].Text);
                        column.SetColumnLength(length);
                        column.SetColumnType(editColumnForm.Controls["combColumnType"].Text);
                        column.SetIsUnique(check.Checked);

                        editColumnForm.Dispose();
                    };

                    editColumnForm.Controls["btnCancel"].Click += (innerSender, innerArgs) =>
                    {
                        editColumnForm.Dispose();
                    };

                    editColumnForm.ShowDialog(this);
                }

            };

            editForm.Controls["btnEditJoin"].Click += (sender, args) =>
            {
                ComboBox combJoins = (ComboBox)editForm.Controls["combJoins"];

                if (combJoins.SelectedItem != null)
                {
                    string s = combJoins.SelectedItem.ToString();
                    JoinEntity currentJoin = null;

                    if (s != null)
                    {
                        string[] content = s.Split(null);

                        foreach (JoinControl jc in joins)
                        {
                            JoinEntity join = jc.GetJoinEntity();
                            if (join.IsMainJoin(content[0].ToString()) != null)
                            {
                                string i = join.GetChildTable().GetName().ToString().ToUpper();
                                string j = content[content.Length - 1].ToUpper();

                                if (i.Equals(j))
                                {
                                    currentJoin = join;
                                    break;
                                }
                            }
                        }

                        EditJoinForm editJoinForm = new EditJoinForm();

                        ListBox columnPairsList = (ListBox)editJoinForm.Controls["lbColumnPairs"];
                        columnPairsList.Items.Clear();

                        foreach (ColumnPairEntity columnPair in currentJoin.GetJoinPairs())
                        {
                            columnPairsList.Items.Add(columnPair.GetParentColumn().GetColumnName() + " on " + columnPair.GetChildColumn().GetColumnName());
                        }

                        editJoinForm.ShowDialog(this);

                    }
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
                    JoinEntity joinEntity = j.GetJoinEntity();
                    ColumnPairEntity columnPair = joinEntity.IsMainJoin(tableName);
                    if (columnPair != null)
                    {
                        String s = columnPair.GetParentTable().GetName() + " ( " + joinEntity.GetJoinType().ToString() + " ) " + columnPair.GetChildTable().GetName();
                        cb.Items.Add(s);
                    }
                }
            }
        }

        private void OnTableDoubleClick(object sender, EventArgs e)
        {
            TableControl tc = (TableControl)sender;
            CreateTableEditGUI(tc);
        }

        private bool NewFileAvailable() {
            if (tables.Count > 0 || joins.Count > 0)
            {
                return false;
            }

            return true;
        }

        private void NewFile(object sender, EventArgs e)
        {
            if (NewFileAvailable())
            {
                this.tables = null;
                this.tables = new List<TableControl>();

                this.joins = null;
                this.joins = new List<JoinControl>();

                currentJoin = null;
                activatedJoin = false;
            }
        }

        private bool SaveToFile()
        {
            return true; // success
        }

        private bool LoadFromFile()
        {
            return true; // success
        }

    }
}
