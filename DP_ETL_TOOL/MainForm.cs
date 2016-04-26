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
using System.Data;

namespace DP_ETL_TOOL
{
    public partial class MainForm : Form
    {
        private ProjectEntity project;
        private JoinControl currentJoin;
        private bool activatedJoin = false;
        private int mouseX = 0;
        private int mouseY = 0;

        private string lastSelectedMode;
        private Enums.Layer layer = Enums.Layer.Extraction_Layer;
        private int objectCount = 0;

        private bool objectWasDeleted = false;

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
            rightTabs.SelectedIndexChanged += new EventHandler(OnRightTabsChanged);

            foreach (ToolStripMenuItem tsItem in menuStripObjectsOverview.Items)
            {
                if (tsItem.Name.Substring(0, 2) == "ts")
                {
                    foreach (ToolStripDropDownItem ddItem in tsItem.DropDownItems)
                    {
                        ddItem.Click += new EventHandler(ObjectsOverviewSelect);
                    }
                }
            }

            tsSave.Click += new EventHandler(OnClickObjectPropertiesSave);

        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void VisualPanelClickEvent(object sender, MouseEventArgs e)
        {
            if (lbDesignerList.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Right && lbDesignerList.SelectedItem.ToString().ToUpper().Contains("TABLE")) // table
                {
                    var coordinates = visualPanel.PointToClient(Cursor.Position);

                    CreateTableForm createTableForm = new CreateTableForm();
                    CheckedListBox tableList = (CheckedListBox)createTableForm.Controls["chListBoxTableList"];
                    List<TableControl> tcList = new List<TableControl>();

                    foreach (Control c in project.GetTables())
                    {
                        if (c.GetType() == typeof(TableControl))
                        {
                            tcList.Add((TableControl)c);
                        }
                    }

                    foreach (TableControl tc in tcList)
                    {
                        tableList.Items.Add((tc.GetTableEntity().GetSchema() + " " + tc.GetTableEntity().GetName() + " " + tc.GetTableEntity().GetTableType())/*.Trim()*/);
                    }

                    createTableForm.Show();
                    createTableForm.Location = this.PointToClient(Control.MousePosition);

                    createTableForm.Controls["btnNew"].Click += (s, a) =>
                    {

                        TableControl tableControl = new TableControl(null, SelectTableType(lbDesignerList), mouseX, mouseY);
                        tableControl.MouseClick += new MouseEventHandler(OnTableClick);
                        tableControl.DoubleClick += new EventHandler(OnTableDoubleClick);
                        project.AddTable(tableControl);
                        tableControl.Location = coordinates;
                        visualPanel.Controls.Add(tableControl);

                        LayerMemberEntity member = new LayerMemberEntity(tableControl.GetTableEntity().GetName(), Enums.Layer.All_Tables, Enums.ModeType.Table);
                        List<Control> controls = new List<Control>();
                        controls.Add(tableControl);
                        member.ClassifyControlTypes(controls);
                        project.AddLayerMember(member, Enums.Layer.All_Tables);

                        createTableForm.Dispose();

                    };

                    createTableForm.Controls["btnAdd"].Click += (s, a) =>
                    {
                        visualPanel.Controls.Clear();
                        foreach (var item in tableList.CheckedItems)
                        {
                            string[] tableArraySplit = ((string)item).Split();
                            foreach (TableControl tc in project.GetTables())
                            {
                                TableEntity te = tc.GetTableEntity();

                                string schema = te.GetSchema();

                                if (schema == null)
                                {
                                    schema = "";
                                }

                                if (te.GetName().ToUpper().Equals(tableArraySplit[1].ToUpper()) && schema.Equals(tableArraySplit[0].ToUpper()))
                                {
                                    visualPanel.Controls.Add(tc);
                                }
                            }
                        }

                        createTableForm.Dispose();

                    };

                    createTableForm.Controls["btnCancel"].Click += (s, a) =>
                    {
                        createTableForm.Dispose();
                    };
                }
            }
        }

        private Enums.TableType SelectTableType(ListBox listBoxDesignerList)
        {
            Enums.TableType tableType = Enums.TableType.Source_Table;

            if (listBoxDesignerList.SelectedItem.ToString() == "Source Table")
            {
                tableType = Enums.TableType.Source_Table;
            }
            else if (listBoxDesignerList.SelectedItem.ToString() == "Extraction Table")
            {
                tableType = Enums.TableType.Extraction_Table;
            }
            else if (listBoxDesignerList.SelectedItem.ToString() == "Load Table")
            {
                tableType = Enums.TableType.Load_Table;
            }
            else if (listBoxDesignerList.SelectedItem.ToString() == "Destination Table")
            {
                tableType = Enums.TableType.Destination_Table;
            }

            return tableType;
        }

        private void OnTableClick(object sender, MouseEventArgs e)
        {
            if (lbDesignerList.Items.Count > 0)
            {
                if (e.Button == MouseButtons.Right && lbDesignerList.SelectedItem.ToString().ToUpper().Contains("JOIN")) // join
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
                        PopulateComboBoxColumn(comboColumn, te);

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
                        selectColumnForm.Location = this.PointToClient(Control.MousePosition);


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

            if (mode.SelectedItem.ToString() == "Table")
            {
                box.Items.Add("Source Table");
                box.Items.Add("Extraction Table");
                box.Items.Add("Load Table");
                box.Items.Add("Destination Table");
            }

            else if (mode.SelectedItem.ToString() == "Extraction Procedure")
            {
                box.Items.Add("Source Table");
                box.Items.Add("Extraction Table");
            }

            else if (mode.SelectedItem.ToString() == "Transformation View")
            {
                box.Items.Add("Extraction Table");
                box.Items.Add("Join");
            }

            else if (mode.SelectedItem.ToString() == "Transformation Procedure")
            {
                box.Items.Add("Load Table");
                box.Items.Add("Destination Table");
                box.Items.Add("Transformation View");
            }

            else if (mode.SelectedItem.ToString() == "Destination View")
            {
                box.Items.Add("Destination Table");
                box.Items.Add("Join");
            }

            box.SelectedItem = box.Items[0];

        }

        private void PopulateModesList(ListBox b)
        {
            b.Items.Add("Table");
            b.Items.Add("Extraction Procedure");
            b.Items.Add("Transformation View");
            b.Items.Add("Transformation Procedure");
            b.Items.Add("Destination View");

            b.SelectedItem = b.Items[0];
            lastSelectedMode = b.SelectedItem.ToString();

            if (b.SelectedItem.ToString().ToUpper() == "TABLE")
            {
                tsObjectProperties.Enabled = false;
            }
            else
            {
                tsObjectProperties.Enabled = true;
            }
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

            if (visualPanel.Controls.Count > 0 && lb.SelectedItem.ToString() != lastSelectedMode)
            {

                var confirmResult = MessageBox.Show("Are you sure you want to change designer mode? Changing so results will result in clearing of current workspace ( Your object will not be lost. ).",
                         "Confirm mode change!",
                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    lbDesignerList.Items.Clear();
                    visualPanel.Controls.Clear();
                    PopulateObjectList(lbDesignerList, lb);


                }
                else
                {
                    lb.SelectedItem = lastSelectedMode;
                }
            }
            else
            {
                PopulateObjectList(lbDesignerList, lb);
            }

            lastSelectedMode = lb.SelectedItem.ToString();

            if (lb.SelectedItem.ToString().ToUpper() == "TABLE")
            {
                tsObjectProperties.Enabled = false;
            }
            else
            {
                tsObjectProperties.Enabled = true;
            }
        }

        private void ParseObjectsToCode(Enums.ModeType modeType, List<Control> ctrls)
        {

            codeEdit.Clear();

            CodeParser parser = new CodeParser(modeType, ctrls);
            codeEdit.AppendText(parser.GetCode());

            codeEdit.Focus();
        }

        ///

        private void CreateTableEditGUI(TableControl tc)
        {
            TableEntity te = tc.GetTableEntity();

            StringBuilder sb = new StringBuilder();

            EditTableForm editForm = new EditTableForm();
            editForm.Text = this.Text;

            // not implemented yet
            editForm.Controls["chckIsUnique"].Enabled = false;
            editForm.Controls["btnEditIndexes"].Enabled = false;

            if (te.GetTableType() == Enums.TableType.Source_Table)
            {
                editForm.Controls["combJoins"].Enabled = false;
                editForm.Controls["btnEditJoin"].Enabled = false;
            }

            PopulateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
            PopulateComboBoxColumnType((ComboBox)editForm.Controls["combColumnType"]);
            PopulateComboBoxJoins((ComboBox)editForm.Controls["combJoins"], project.GetJoins(), te);

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

                    PopulateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
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

                    PopulateComboBoxColumnType((ComboBox)editColumnForm.Controls["combColumnType"]);

                    editColumnForm.Controls["btnOk"].Click += (innerSender, innerArgs) =>
                    {
                        int length = 0;
                        int.TryParse(editColumnForm.Controls["tbColumnLength"].Text, out length);

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

                    editColumnForm.Controls["lblDeleteColumn"].Click += (innerSender, innerArgs) =>
                    {
                        var confirmResult = MessageBox.Show("Are you sure you want to delete column? Doing so, will remove column and all its join deendencies. Only use when you know what are you doing.",
                         "Confirm join deletion!",
                         MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.Yes)
                        {
                            List<JoinControl> jc = project.DeleteColumnAndAllDependencies(te, column);
                            if (jc != null && jc.Count > 0)
                            {
                                foreach (JoinControl join in jc)
                                {
                                    visualPanel.Controls.Remove(join);
                                }
                            }
                            editColumnForm.Dispose();
                        }
                    };

                    editColumnForm.ShowDialog(this);
                    editColumnForm.Location = this.PointToClient(Control.MousePosition);

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

                        PopulateComboBoxColumn((ComboBox)editJoinForm.Controls["combMainColumn"], currentJoin.GetMainTable());
                        PopulateComboBoxColumn((ComboBox)editJoinForm.Controls["combChilColumn"], currentJoin.GetChildTable());

                        editJoinForm.Controls["btnAddPair"].Click += (e, a) =>
                        {
                            TableEntity main = currentJoin.GetMainTable();
                            TableEntity child = currentJoin.GetChildTable();

                            ComboBox cbMain = (ComboBox)editJoinForm.Controls["combMainColumn"];
                            ComboBox cbChild = (ComboBox)editJoinForm.Controls["combChilColumn"];

                            ColumnEntity mainSelectedColumn = main.GetColumnByName(cbMain.SelectedItem.ToString());
                            ColumnEntity childSelectedColumn = main.GetColumnByName(cbChild.SelectedItem.ToString());

                            currentJoin.AddJoinPair(new ColumnPairEntity(mainSelectedColumn, childSelectedColumn));

                            columnPairsList.Items.Clear();
                            foreach (ColumnPairEntity columnPair in currentJoin.GetJoinPairs())
                            {
                                columnPairsList.Items.Add(columnPair.GetParentColumn().GetColumnName() + " on " + columnPair.GetChildColumn().GetColumnName());
                            }
                        };

                        editJoinForm.Controls["btnOk"].Click += (e, a) =>
                        {
                            editJoinForm.Dispose();
                        };

                        editJoinForm.Controls["btnCancel"].Click += (e, a) =>
                        {
                            editJoinForm.Dispose();
                        };

                        editJoinForm.Controls["lblDeleteJoinPair"].Click += (e, a) =>
                        {
                            editJoinForm.Dispose();
                        };

                        editJoinForm.ShowDialog(this);
                        editJoinForm.Location = this.PointToClient(Control.MousePosition);

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

            editForm.Controls["lblDeleteTable"].Click += (sender, args) =>
            {
                var confirmResult = MessageBox.Show("Are you sure you want to delete table? Doing so, will remove object and all its dependencies. Only use when you know what are you doing.",
                         "Confirm table deletion!",
                         MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    project.DeleteTableAndAllDependenciesByTableName(te.GetSchema(), te.GetName());
                    objectWasDeleted = true;
                    editForm.Dispose();
                    visualPanel.Controls.Remove(tc);
                }
            };

            editForm.ShowDialog(this);
            editForm.Location = this.PointToClient(Control.MousePosition);

        }

        private void PopulateComboBoxColumnType(ComboBox cb)
        {
            cb.Items.Add("VARCHAR2");
            cb.Items.Add("NUMBER");
        }

        private void PopulateComboBoxColumn(ComboBox cb, TableEntity te)
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

        private void PopulateComboBoxJoins(ComboBox cb, List<JoinControl> jc, TableEntity mainTable)
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
                        if (joinEntity.GetMainTable() == mainTable)
                        {
                            String s = columnPair.GetParentColumn().GetColumnName() + " ( " + joinEntity.GetJoinType().ToString() + " ) " + columnPair.GetChildColumn().GetColumnName() + " " + joinEntity.GetChildTableName();
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

        private void SaveToolStripMenuItemClick(object sender, EventArgs e)
        {
            project.PrepareForSerializationToXML();
            SaveToFile();
        }

        private void OpenToolStripMenuItemClick(object sender, EventArgs e)
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

                //visualPanel.Controls.Add(tc);
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

                //visualPanel.Controls.Add(jc);
            }

            this.Invalidate();
        }



        private void CodeDecorationClick(object sender, EventArgs e)
        {
            codeEdit.Focus();
        }

        private void NewToolStripMenuItemClick(object sender, EventArgs e)
        {
            this.project = null;
            GC.Collect();
            this.project = new ProjectEntity();
            visualPanel.Controls.Clear();
        }

        private void TSButtonGenerateCodeClick(object sender, EventArgs e)
        {
            // parser mode
            Enums.ModeType mode = GetSelectedModeType(lbDesignerMode);
            ParseObjectsToCode(mode, GetActiveDesignerObjectList());
            codeEdit.RefreshSyntax();
        }

        private List<Control> GetActiveDesignerObjectList()
        {
            List<Control> ctrls = new List<Control>();

            foreach (Control ctrl in visualPanel.Controls)
            {
                ctrls.Add(ctrl);
            }

            return ctrls;
        }

        private Enums.ModeType GetSelectedModeType(ListBox lbDesignerMode)
        {
            string mode = lbDesignerMode.SelectedItem.ToString();

            switch (mode.ToUpper())
            {
                case ("TABLE"):
                    {
                        return Enums.ModeType.Table;
                    }
                case ("EXTRACTION PROCEDURE"):
                    {
                        return Enums.ModeType.Extraction_Procedure;
                    }
                case ("TRANSFORMATION VIEW"):
                    {
                        return Enums.ModeType.Transformation_View;
                    }
                case ("TRANSFORMATION PROCEDURE"):
                    {
                        return Enums.ModeType.Transformation_Procedure;
                    }
                case ("DESTINATION VIEW"):
                    {
                        return Enums.ModeType.Destination_View;
                    }
            }

            return Enums.ModeType.NULL;
        }

        private Enums.Layer GetSelectedLayer(ListBox lbDesignerMode)
        {
            string mode = lbDesignerMode.SelectedItem.ToString();

            switch (mode.ToUpper())
            {
                case ("TABLE"):
                    {
                        Enums.TableType tableType = SelectTableType(lbDesignerList);
                        switch (tableType)
                        {
                            case (Enums.TableType.Extraction_Table):
                                {
                                    return Enums.Layer.Extraction_Layer;
                                };
                            case (Enums.TableType.Source_Table):
                                {
                                    return Enums.Layer.Extraction_Layer;
                                };
                            case (Enums.TableType.Load_Table):
                                {
                                    return Enums.Layer.Transformation_Layer;
                                };
                            case (Enums.TableType.Destination_Table):
                                {
                                    return Enums.Layer.Load_Layer;
                                };
                            case (Enums.TableType.NULL):
                                {
                                    return Enums.Layer.NULL;
                                };
                        }

                        break;
                    }
                case ("EXTRACTION PROCEDURE"):
                    {
                        return Enums.Layer.Extraction_Layer;
                    }
                case ("TRANSFORMATION VIEW"):
                    {
                        return Enums.Layer.Transformation_Layer;

                    }
                case ("TRANSFORMATION PROCEDURE"):
                    {
                        return Enums.Layer.Transformation_Layer;

                    }
                case ("DESTINATION VIEW"):
                    {
                        return Enums.Layer.Load_Layer;

                    }
            }

            return Enums.Layer.NULL;
        }

        private void OnRightTabsChanged(object sender, EventArgs e)
        {
            TabControl tabControl = (TabControl)sender;

            if (tabControl.SelectedIndex == 1 && objectWasDeleted)
            {
                dataTableView.Columns.Clear();
                dataTableView.Rows.Clear();

                objectWasDeleted = false;
            }
        }

        private void OnClickObjectPropertiesSave(object sender, EventArgs e)
        {
            List<Control> controls = GetActiveDesignerObjectList();
            string s = tsTextBoxObjectName.Text.Trim().ToUpper();
            if (s.Length > 0)
            {
                LayerMemberEntity member = new LayerMemberEntity(s, GetSelectedLayer(lbDesignerMode), GetSelectedModeType(lbDesignerMode));
                member.ClassifyControlTypes(controls);
                project.AddLayerMember(member, GetSelectedLayer(lbDesignerMode));
            }

        }

        private void ObjectsOverviewSelect(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            switch (clickedItem.Text.ToUpper())
            {
                // TABLES
                case ("SOURCE TABLES"):
                    {
                        ObjectOverviewFillTables(Enums.TableType.Source_Table);
                        break;
                    }
                case ("EXTRACTION TABLES"):
                    {
                        ObjectOverviewFillTables(Enums.TableType.Extraction_Table);
                        break;
                    }
                case ("LOAD TABLES"):
                    {
                        ObjectOverviewFillTables(Enums.TableType.Load_Table);
                        break;
                    }
                case ("DESTINATION TABLES"):
                    {
                        ObjectOverviewFillTables(Enums.TableType.Destination_Table);
                        break;
                    }
                case ("ALL TABLES"):
                    {
                        ObjectOverviewFillTables(Enums.TableType.NULL);
                        break;
                    }
                //VIEWS
                case ("TRANSFORMATION VIEWS"):
                    {
                        break;
                    }
                case ("DESTINATION VIEWS"):
                    {
                        break;
                    }
                //PROCEDURES
                case ("EXTRACTION PROCEDURES"):
                    {
                        break;
                    }
                case ("TRANSFORMATION PROCEDURES"):
                    {
                        break;
                    }
                case ("ALL PROCEDURES"):
                    {
                        break;
                    }
                //OTHER
                case ("ALL OBJECT"):
                    {
                        break;
                    }
                default:
                    {
                        dataTableView.Rows.Clear();
                        dataTableView.Columns.Clear();
                        break;
                    }
            }

        }

        private void ObjectOverviewFillTables(Enums.TableType tableType)
        {
            dataTableView.Rows.Clear();
            dataTableView.Columns.Clear();

            dataTableView.Columns.Add("schemaName", "Schema Name");
            dataTableView.Columns.Add("tableName", "Table Name");

            DataGridViewButtonColumn buttonColumnEdit = new DataGridViewButtonColumn();
            buttonColumnEdit.Name = "";

            DataGridViewButtonColumn buttonColumnShow = new DataGridViewButtonColumn();
            buttonColumnEdit.Name = "";

            dataTableView.Columns.Add(buttonColumnEdit);
            dataTableView.Columns.Add(buttonColumnShow);


            foreach (LayerMemberEntity member in project.GetLayerMembers(Enums.Layer.All_Tables))
            {
                List<TableEntity> te = member.GetTables();

                foreach (TableEntity t in te)
                {
                    if (tableType != Enums.TableType.NULL && t.GetTableType() == tableType)
                    {
                        dataTableView.Rows.Add(t.GetSchema(), t.GetName(), "Edit", "Show");
                    }
                    else if (tableType == Enums.TableType.NULL)
                    {
                        dataTableView.Rows.Add(t.GetSchema(), t.GetName(), "Edit", "Show");
                    }
                }
            }
        }

        private void ObjectOverviewFillViews(Enums.ModeType objectType)
        {
            dataTableView.Rows.Clear();
            dataTableView.Columns.Clear();

            dataTableView.Columns.Add("viewName", "View Name");
            dataTableView.Columns.Add("viewDescription", "Description");

            DataGridViewButtonColumn buttonColumnDetail = new DataGridViewButtonColumn();
            buttonColumnDetail.Name = "";

            DataGridViewButtonColumn buttonColumnShow = new DataGridViewButtonColumn();
            buttonColumnDetail.Name = "";

            dataTableView.Columns.Add(buttonColumnDetail);
            dataTableView.Columns.Add(buttonColumnShow);

            if (objectType == Enums.ModeType.Transformation_View)
            {

            }
        }

    }
}
