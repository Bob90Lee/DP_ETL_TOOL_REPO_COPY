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
using System.Runtime.Serialization;
using System.Xml;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {
        private ProjectEntity project;

        private JoinControl currentJoin;

        private bool activatedJoin = false;

        public MainForm()
        {
            InitializeComponent();

            project = new ProjectEntity();

            visualPanel.AllowDrop = true;
            visualPanel.MouseClick += new MouseEventHandler(VisualPanelClickEvent);
            visualPanel.BackgroundImage = Image.FromFile(@"C:\Users\BORIS\Documents\Visual Studio 2015\Projects\DP_ETL_TOOL\DP_ETL_TOOL\Graphics\background.png");

            codeEdit.SelectionTabs = new int[] { 30, 60, 90, 120 };

            PopulateModesList(lbDesignerMode);
            PopulateObjectList(lbDesignerList, lbDesignerMode);

            exitToolStripMenuItem.Click += new EventHandler(ExitApplication);
            lbDesignerList.SelectedValueChanged += new EventHandler(DesignerListValueChanged);
            lbDesignerMode.SelectedValueChanged += new EventHandler(DesignerModeValueChanged);

            //rightTabs. += new EventHandler(RightTabsSelectedChanged);

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
                    TableControl tableControl = new TableControl(null);
                    tableControl.MouseClick += new MouseEventHandler(OnTableClick);
                    tableControl.DoubleClick += new EventHandler(OnTableDoubleClick);
                    project.AddTable(tableControl);
                    tableControl.Location = workspaceTab.PointToClient(Control.MousePosition);
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

                        selectColumnForm.Controls["btnOk"].Click += (s, a) =>
                        {
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
                                currentJoin.GetJoinEntity().GetJoinPairs()[0].SetChildColumn(column);
                                activatedJoin = false;
                            }
                            else
                            {
                                Enums.JoinType jt = Enums.JoinType.Inner; // default join type

                                currentJoin = new JoinControl(null);
                                currentJoin.SetMainTable(tc);
                                currentJoin.GetJoinEntity().AddJoinPair(new ColumnPairEntity(column, null));
                                activatedJoin = true;
                            }

                        }

                        if (currentJoin.GetMainTable() != null && currentJoin.GetChildTable() != null)
                        {
                            if (te.GetJoins() != null && te.GetJoins().Count > 0)
                            {
                                JoinEntity[] copy = new JoinEntity[te.GetJoins().Count];
                                te.GetJoins().CopyTo(copy);

                                foreach (JoinEntity je in copy)
                                {
                                    ColumnPairEntity currentJoinPair = currentJoin.GetJoinEntity().GetJoinPairs()[0];
                                    if (!je.FindExistingJoinPair(currentJoinPair.GetParentColumn().GetColumnName(), currentJoinPair.GetChildColumn().GetColumnName()))
                                    {
                                        project.AddJoin(currentJoin);
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
                                project.AddJoin(currentJoin);
                                te.AddJoinEntity(currentJoin.GetJoinEntity());
                                visualPanel.Controls.Add(currentJoin);
                                currentJoin.GetJoinEntity().RefreshNames();
                            }

                            activatedJoin = false;
                            currentJoin = new JoinControl(null);
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

                CodeParser parser = new CodeParser(Enums.ModeType.View, project.GetTables(), project.GetJoins());
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
            populateComboBoxJoins((ComboBox)editForm.Controls["combJoins"], project.GetJoins(), te.GetName());

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

                        foreach (JoinControl jc in project.GetJoins())
                        {
                            JoinEntity join = jc.GetJoinEntity();

                            string i = join.GetChildTable().GetName().ToString().ToUpper();
                            string j = content[content.Length - 1].ToUpper();

                            if (i.Equals(j))
                            {
                                currentJoin = join;
                                break;
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

                    foreach (ColumnPairEntity columnPair in joinEntity.GetJoinPairs())
                    {
                        String s = columnPair.GetParentColumn().GetColumnName() + " ( " + joinEntity.GetJoinType().ToString() + " ) " + columnPair.GetChildColumn().GetColumnName();
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

        private bool NewFileAvailable()
        {
            if (project.GetTables().Count > 0 || project.GetJoins().Count > 0)
            {
                return false;
            }

            return true;
        }

        private void NewFile(object sender, EventArgs e)
        {
            if (NewFileAvailable())
            {
                this.project = null;
                this.project = new ProjectEntity();

                currentJoin = null;
                activatedJoin = false;
            }
        }

        private bool SaveToFile()
        {
            DataContractSerializer writer = new DataContractSerializer(typeof(ProjectEntity));

            //ColumnEntity ce = project.GetTables()[0].GetTableEntity().GetColumns()[0];

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ETL Tool File|*.etf";
            saveFileDialog.Title = "Save project";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog.OpenFile();

                XmlWriter xmlWriter = XmlWriter.Create(fs, new XmlWriterSettings { Indent = true });

                writer.WriteObject(xmlWriter, project);

                xmlWriter.Close();
                fs.Close();
            }

            return true; // success
        }

        private bool LoadFromFile()
        {
            DataContractSerializer deserializer = new DataContractSerializer(typeof(ProjectEntity));

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "ETL Tool File|*.etf";
            openFileDialog.Title = "Open project";

            openFileDialog.ShowDialog();

            if (openFileDialog.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)openFileDialog.OpenFile();

                XmlReader xmlReader = XmlReader.Create(fs);

                project = (ProjectEntity)deserializer.ReadObject(xmlReader);

            }

            return true; // success
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            project.PrepareForSerializationToXML();
            SaveToFile();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.project = null;
            GC.Collect();
            this.project = new ProjectEntity();
            visualPanel.Controls.Clear();

            LoadFromFile();
            project.DeserializeFromXML();

            foreach (TableControl tc in project.GetTables())
            {
                tc.MouseClick += new MouseEventHandler(OnTableClick);
                tc.DoubleClick += new EventHandler(OnTableDoubleClick);

                GUICoordsEntity guiCoords = tc.GetTableEntity().GetCoords();
                tc.SetBounds(guiCoords.GetPosX(), guiCoords.GetPosY(), guiCoords.GetWidth(), guiCoords.GetHeight());

                visualPanel.Controls.Add(tc);
            }

            foreach (JoinControl jc in project.GetJoins())
            {
                GUICoordsEntity guiCoords = jc.GetJoinEntity().GetCoords();
                jc.SetBounds(guiCoords.GetPosX(), guiCoords.GetPosY(), guiCoords.GetWidth(), guiCoords.GetHeight());

                foreach (TableControl tc in project.GetTables())
                {
                    if (jc.GetJoinEntity().GetMainTableName() == tc.GetTableEntity().GetName())
                    {
                        jc.SetMainTable(tc);
                    }
                    else if (jc.GetJoinEntity().GetChildTableName() == tc.GetTableEntity().GetName())
                    {
                        jc.SetChildTable(tc);
                    }
                }

                visualPanel.Controls.Add(jc);
            }

            this.Invalidate();
        }



        private void codeDecoration_Click(object sender, EventArgs e)
        {
            codeEdit.Focus();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.project = null;
            GC.Collect();
            this.project = new ProjectEntity();
            visualPanel.Controls.Clear();
        }
    }
}
