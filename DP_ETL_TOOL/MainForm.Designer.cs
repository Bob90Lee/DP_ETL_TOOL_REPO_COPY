namespace DP_ETL_TOOL
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asXMLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designerTab = new System.Windows.Forms.TabPage();
            this.tableLay3 = new System.Windows.Forms.TableLayoutPanel();
            this.grpDesigneDown = new System.Windows.Forms.GroupBox();
            this.lbDesignerList = new System.Windows.Forms.ListBox();
            this.grpDesigneUp = new System.Windows.Forms.GroupBox();
            this.lbDesignerMode = new System.Windows.Forms.ListBox();
            this.leftTabs = new System.Windows.Forms.TabControl();
            this.rightTabs = new System.Windows.Forms.TabControl();
            this.workspaceTab = new System.Windows.Forms.TabPage();
            this.tableLay1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLay2 = new System.Windows.Forms.TableLayoutPanel();
            this.tsCodeTools = new System.Windows.Forms.ToolStrip();
            this.tsButtonGenerateCode = new System.Windows.Forms.ToolStripButton();
            this.btnClearCode = new System.Windows.Forms.ToolStripButton();
            this.tsButtonExport = new System.Windows.Forms.ToolStripButton();
            this.talbeLay4 = new System.Windows.Forms.TableLayoutPanel();
            this.visualPanel = new System.Windows.Forms.Panel();
            this.tsObjectProperties = new System.Windows.Forms.ToolStrip();
            this.tsLabelObjectName = new System.Windows.Forms.ToolStripLabel();
            this.tsTextBoxObjectName = new System.Windows.Forms.ToolStripTextBox();
            this.tsDropDownOperations = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsNew = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.objectsTab = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStripObjectsOverview = new System.Windows.Forms.MenuStrip();
            this.tsExtraction = new System.Windows.Forms.ToolStripMenuItem();
            this.eSourceTables = new System.Windows.Forms.ToolStripMenuItem();
            this.eExtractionTables = new System.Windows.Forms.ToolStripMenuItem();
            this.eExtractionProcedures = new System.Windows.Forms.ToolStripMenuItem();
            this.tsTransformation = new System.Windows.Forms.ToolStripMenuItem();
            this.tTransformationViews = new System.Windows.Forms.ToolStripMenuItem();
            this.tTransformationProcedures = new System.Windows.Forms.ToolStripMenuItem();
            this.tsLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.lLoadTables = new System.Windows.Forms.ToolStripMenuItem();
            this.lDestinationTables = new System.Windows.Forms.ToolStripMenuItem();
            this.lDestinationViews = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAll = new System.Windows.Forms.ToolStripMenuItem();
            this.aAll = new System.Windows.Forms.ToolStripMenuItem();
            this.aTables = new System.Windows.Forms.ToolStripMenuItem();
            this.aProcedures = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTableView = new System.Windows.Forms.DataGridView();
            this.codeEdit = new DP_ETL_TOOL.Controls.SyntaxTextBoxControl();
            this.MainMenu.SuspendLayout();
            this.designerTab.SuspendLayout();
            this.tableLay3.SuspendLayout();
            this.grpDesigneDown.SuspendLayout();
            this.grpDesigneUp.SuspendLayout();
            this.leftTabs.SuspendLayout();
            this.rightTabs.SuspendLayout();
            this.workspaceTab.SuspendLayout();
            this.tableLay1.SuspendLayout();
            this.tableLay2.SuspendLayout();
            this.tsCodeTools.SuspendLayout();
            this.talbeLay4.SuspendLayout();
            this.tsObjectProperties.SuspendLayout();
            this.objectsTab.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.menuStripObjectsOverview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(880, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.applicationToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New Project";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.NewToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open Project";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save Project";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.asXMLToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exportToolStripMenuItem.Text = "Export As";
            // 
            // asXMLToolStripMenuItem
            // 
            this.asXMLToolStripMenuItem.Name = "asXMLToolStripMenuItem";
            this.asXMLToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.asXMLToolStripMenuItem.Text = "As XML";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // designerTab
            // 
            this.designerTab.BackColor = System.Drawing.Color.White;
            this.designerTab.Controls.Add(this.tableLay3);
            this.designerTab.Location = new System.Drawing.Point(4, 22);
            this.designerTab.Name = "designerTab";
            this.designerTab.Padding = new System.Windows.Forms.Padding(3);
            this.designerTab.Size = new System.Drawing.Size(137, 449);
            this.designerTab.TabIndex = 0;
            this.designerTab.Text = "Designer";
            // 
            // tableLay3
            // 
            this.tableLay3.ColumnCount = 1;
            this.tableLay3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLay3.Controls.Add(this.grpDesigneDown, 0, 1);
            this.tableLay3.Controls.Add(this.grpDesigneUp, 0, 0);
            this.tableLay3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLay3.Location = new System.Drawing.Point(3, 3);
            this.tableLay3.Name = "tableLay3";
            this.tableLay3.RowCount = 2;
            this.tableLay3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLay3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLay3.Size = new System.Drawing.Size(131, 443);
            this.tableLay3.TabIndex = 0;
            // 
            // grpDesigneDown
            // 
            this.grpDesigneDown.Controls.Add(this.lbDesignerList);
            this.grpDesigneDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDesigneDown.Location = new System.Drawing.Point(3, 224);
            this.grpDesigneDown.Name = "grpDesigneDown";
            this.grpDesigneDown.Size = new System.Drawing.Size(125, 216);
            this.grpDesigneDown.TabIndex = 5;
            this.grpDesigneDown.TabStop = false;
            this.grpDesigneDown.Text = "Designer Tools";
            // 
            // lbDesignerList
            // 
            this.lbDesignerList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDesignerList.FormattingEnabled = true;
            this.lbDesignerList.Location = new System.Drawing.Point(3, 16);
            this.lbDesignerList.Name = "lbDesignerList";
            this.lbDesignerList.Size = new System.Drawing.Size(119, 197);
            this.lbDesignerList.TabIndex = 0;
            // 
            // grpDesigneUp
            // 
            this.grpDesigneUp.Controls.Add(this.lbDesignerMode);
            this.grpDesigneUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpDesigneUp.Location = new System.Drawing.Point(3, 3);
            this.grpDesigneUp.Name = "grpDesigneUp";
            this.grpDesigneUp.Size = new System.Drawing.Size(125, 215);
            this.grpDesigneUp.TabIndex = 3;
            this.grpDesigneUp.TabStop = false;
            this.grpDesigneUp.Text = "Designer Mode";
            // 
            // lbDesignerMode
            // 
            this.lbDesignerMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDesignerMode.FormattingEnabled = true;
            this.lbDesignerMode.Location = new System.Drawing.Point(3, 16);
            this.lbDesignerMode.Name = "lbDesignerMode";
            this.lbDesignerMode.Size = new System.Drawing.Size(119, 196);
            this.lbDesignerMode.TabIndex = 1;
            // 
            // leftTabs
            // 
            this.leftTabs.Controls.Add(this.designerTab);
            this.leftTabs.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftTabs.Location = new System.Drawing.Point(0, 24);
            this.leftTabs.Name = "leftTabs";
            this.leftTabs.SelectedIndex = 0;
            this.leftTabs.Size = new System.Drawing.Size(145, 475);
            this.leftTabs.TabIndex = 1;
            this.leftTabs.TabStop = false;
            // 
            // rightTabs
            // 
            this.rightTabs.Controls.Add(this.workspaceTab);
            this.rightTabs.Controls.Add(this.objectsTab);
            this.rightTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTabs.Location = new System.Drawing.Point(145, 24);
            this.rightTabs.Name = "rightTabs";
            this.rightTabs.SelectedIndex = 0;
            this.rightTabs.Size = new System.Drawing.Size(735, 475);
            this.rightTabs.TabIndex = 2;
            this.rightTabs.TabStop = false;
            // 
            // workspaceTab
            // 
            this.workspaceTab.AutoScroll = true;
            this.workspaceTab.BackColor = System.Drawing.Color.White;
            this.workspaceTab.Controls.Add(this.tableLay1);
            this.workspaceTab.Location = new System.Drawing.Point(4, 22);
            this.workspaceTab.Name = "workspaceTab";
            this.workspaceTab.Padding = new System.Windows.Forms.Padding(3);
            this.workspaceTab.Size = new System.Drawing.Size(727, 449);
            this.workspaceTab.TabIndex = 0;
            this.workspaceTab.Text = "Workspace";
            // 
            // tableLay1
            // 
            this.tableLay1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLay1.ColumnCount = 2;
            this.tableLay1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLay1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLay1.Controls.Add(this.tableLay2, 1, 0);
            this.tableLay1.Controls.Add(this.talbeLay4, 0, 0);
            this.tableLay1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLay1.Location = new System.Drawing.Point(3, 3);
            this.tableLay1.Name = "tableLay1";
            this.tableLay1.RowCount = 1;
            this.tableLay1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLay1.Size = new System.Drawing.Size(721, 443);
            this.tableLay1.TabIndex = 2;
            // 
            // tableLay2
            // 
            this.tableLay2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLay2.ColumnCount = 2;
            this.tableLay2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLay2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLay2.Controls.Add(this.codeEdit, 1, 1);
            this.tableLay2.Controls.Add(this.tsCodeTools, 1, 0);
            this.tableLay2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLay2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tableLay2.Location = new System.Drawing.Point(435, 4);
            this.tableLay2.Name = "tableLay2";
            this.tableLay2.RowCount = 2;
            this.tableLay2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLay2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLay2.Size = new System.Drawing.Size(282, 435);
            this.tableLay2.TabIndex = 2;
            // 
            // tsCodeTools
            // 
            this.tsCodeTools.BackColor = System.Drawing.SystemColors.Control;
            this.tsCodeTools.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsCodeTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsCodeTools.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsCodeTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonGenerateCode,
            this.btnClearCode,
            this.tsButtonExport});
            this.tsCodeTools.Location = new System.Drawing.Point(32, 1);
            this.tsCodeTools.Name = "tsCodeTools";
            this.tsCodeTools.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsCodeTools.Size = new System.Drawing.Size(249, 30);
            this.tsCodeTools.TabIndex = 4;
            this.tsCodeTools.Text = "toolStrip1";
            // 
            // tsButtonGenerateCode
            // 
            this.tsButtonGenerateCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButtonGenerateCode.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonGenerateCode.Image")));
            this.tsButtonGenerateCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonGenerateCode.Name = "tsButtonGenerateCode";
            this.tsButtonGenerateCode.Size = new System.Drawing.Size(89, 27);
            this.tsButtonGenerateCode.Text = "Generate Code";
            this.tsButtonGenerateCode.Click += new System.EventHandler(this.TSButtonGenerateCodeClick);
            // 
            // btnClearCode
            // 
            this.btnClearCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnClearCode.Image = ((System.Drawing.Image)(resources.GetObject("btnClearCode.Image")));
            this.btnClearCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClearCode.Name = "btnClearCode";
            this.btnClearCode.Size = new System.Drawing.Size(38, 27);
            this.btnClearCode.Text = "Clear";
            // 
            // tsButtonExport
            // 
            this.tsButtonExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsButtonExport.Image = ((System.Drawing.Image)(resources.GetObject("tsButtonExport.Image")));
            this.tsButtonExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonExport.Name = "tsButtonExport";
            this.tsButtonExport.Size = new System.Drawing.Size(44, 27);
            this.tsButtonExport.Text = "Export";
            // 
            // talbeLay4
            // 
            this.talbeLay4.ColumnCount = 1;
            this.talbeLay4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.talbeLay4.Controls.Add(this.visualPanel, 0, 1);
            this.talbeLay4.Controls.Add(this.tsObjectProperties, 0, 0);
            this.talbeLay4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.talbeLay4.Location = new System.Drawing.Point(4, 4);
            this.talbeLay4.Name = "talbeLay4";
            this.talbeLay4.RowCount = 2;
            this.talbeLay4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.talbeLay4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.talbeLay4.Size = new System.Drawing.Size(424, 435);
            this.talbeLay4.TabIndex = 3;
            // 
            // visualPanel
            // 
            this.visualPanel.AutoScroll = true;
            this.visualPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualPanel.Location = new System.Drawing.Point(3, 33);
            this.visualPanel.Name = "visualPanel";
            this.visualPanel.Size = new System.Drawing.Size(418, 401);
            this.visualPanel.TabIndex = 2;
            // 
            // tsObjectProperties
            // 
            this.tsObjectProperties.BackColor = System.Drawing.SystemColors.Control;
            this.tsObjectProperties.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tsObjectProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsObjectProperties.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tsObjectProperties.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabelObjectName,
            this.tsTextBoxObjectName,
            this.tsDropDownOperations});
            this.tsObjectProperties.Location = new System.Drawing.Point(0, 0);
            this.tsObjectProperties.Name = "tsObjectProperties";
            this.tsObjectProperties.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsObjectProperties.Size = new System.Drawing.Size(424, 30);
            this.tsObjectProperties.TabIndex = 3;
            this.tsObjectProperties.Text = "toolStrip1";
            // 
            // tsLabelObjectName
            // 
            this.tsLabelObjectName.Name = "tsLabelObjectName";
            this.tsLabelObjectName.Size = new System.Drawing.Size(77, 27);
            this.tsLabelObjectName.Text = "Object Name";
            // 
            // tsTextBoxObjectName
            // 
            this.tsTextBoxObjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tsTextBoxObjectName.Name = "tsTextBoxObjectName";
            this.tsTextBoxObjectName.Size = new System.Drawing.Size(100, 30);
            // 
            // tsDropDownOperations
            // 
            this.tsDropDownOperations.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsDropDownOperations.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsNew,
            this.tsOpen,
            this.tsSave});
            this.tsDropDownOperations.Image = ((System.Drawing.Image)(resources.GetObject("tsDropDownOperations.Image")));
            this.tsDropDownOperations.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDropDownOperations.Name = "tsDropDownOperations";
            this.tsDropDownOperations.Size = new System.Drawing.Size(116, 27);
            this.tsDropDownOperations.Text = "Object Operations";
            // 
            // tsNew
            // 
            this.tsNew.Name = "tsNew";
            this.tsNew.Size = new System.Drawing.Size(103, 22);
            this.tsNew.Text = "New";
            // 
            // tsOpen
            // 
            this.tsOpen.Name = "tsOpen";
            this.tsOpen.Size = new System.Drawing.Size(103, 22);
            this.tsOpen.Text = "Open";
            // 
            // tsSave
            // 
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(103, 22);
            this.tsSave.Text = "Save";
            // 
            // objectsTab
            // 
            this.objectsTab.Controls.Add(this.tableLayoutPanel1);
            this.objectsTab.Location = new System.Drawing.Point(4, 22);
            this.objectsTab.Name = "objectsTab";
            this.objectsTab.Padding = new System.Windows.Forms.Padding(3);
            this.objectsTab.Size = new System.Drawing.Size(727, 449);
            this.objectsTab.TabIndex = 1;
            this.objectsTab.Text = "Objects Overview";
            this.objectsTab.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.menuStripObjectsOverview, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataTableView, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(721, 443);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // menuStripObjectsOverview
            // 
            this.menuStripObjectsOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuStripObjectsOverview.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsExtraction,
            this.tsTransformation,
            this.tsLoad,
            this.tsAll});
            this.menuStripObjectsOverview.Location = new System.Drawing.Point(0, 0);
            this.menuStripObjectsOverview.Name = "menuStripObjectsOverview";
            this.menuStripObjectsOverview.Size = new System.Drawing.Size(721, 30);
            this.menuStripObjectsOverview.TabIndex = 0;
            this.menuStripObjectsOverview.Text = "menuStrip1";
            // 
            // tsExtraction
            // 
            this.tsExtraction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eSourceTables,
            this.eExtractionTables,
            this.eExtractionProcedures});
            this.tsExtraction.Name = "tsExtraction";
            this.tsExtraction.Size = new System.Drawing.Size(71, 26);
            this.tsExtraction.Text = "Extraction";
            // 
            // eSourceTables
            // 
            this.eSourceTables.Name = "eSourceTables";
            this.eSourceTables.Size = new System.Drawing.Size(188, 22);
            this.eSourceTables.Text = "Source Tables";
            // 
            // eExtractionTables
            // 
            this.eExtractionTables.Name = "eExtractionTables";
            this.eExtractionTables.Size = new System.Drawing.Size(188, 22);
            this.eExtractionTables.Text = "Extraction Tables";
            // 
            // eExtractionProcedures
            // 
            this.eExtractionProcedures.Name = "eExtractionProcedures";
            this.eExtractionProcedures.Size = new System.Drawing.Size(188, 22);
            this.eExtractionProcedures.Text = "Extraction Procedures";
            // 
            // tsTransformation
            // 
            this.tsTransformation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tTransformationViews,
            this.tTransformationProcedures});
            this.tsTransformation.Name = "tsTransformation";
            this.tsTransformation.Size = new System.Drawing.Size(100, 26);
            this.tsTransformation.Text = "Transformation";
            // 
            // tTransformationViews
            // 
            this.tTransformationViews.Name = "tTransformationViews";
            this.tTransformationViews.Size = new System.Drawing.Size(217, 22);
            this.tTransformationViews.Text = "Transformation Views";
            // 
            // tTransformationProcedures
            // 
            this.tTransformationProcedures.Name = "tTransformationProcedures";
            this.tTransformationProcedures.Size = new System.Drawing.Size(217, 22);
            this.tTransformationProcedures.Text = "Transformation Procedures";
            // 
            // tsLoad
            // 
            this.tsLoad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lLoadTables,
            this.lDestinationTables,
            this.lDestinationViews});
            this.tsLoad.Name = "tsLoad";
            this.tsLoad.Size = new System.Drawing.Size(45, 26);
            this.tsLoad.Text = "Load";
            // 
            // lLoadTables
            // 
            this.lLoadTables.Name = "lLoadTables";
            this.lLoadTables.Size = new System.Drawing.Size(170, 22);
            this.lLoadTables.Text = "Load Tables";
            // 
            // lDestinationTables
            // 
            this.lDestinationTables.Name = "lDestinationTables";
            this.lDestinationTables.Size = new System.Drawing.Size(170, 22);
            this.lDestinationTables.Text = "Destination Tables";
            // 
            // lDestinationViews
            // 
            this.lDestinationViews.Name = "lDestinationViews";
            this.lDestinationViews.Size = new System.Drawing.Size(170, 22);
            this.lDestinationViews.Text = "Destination Views";
            // 
            // tsAll
            // 
            this.tsAll.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aAll,
            this.aTables,
            this.aProcedures});
            this.tsAll.Name = "tsAll";
            this.tsAll.Size = new System.Drawing.Size(33, 26);
            this.tsAll.Text = "All";
            // 
            // aAll
            // 
            this.aAll.Name = "aAll";
            this.aAll.Size = new System.Drawing.Size(150, 22);
            this.aAll.Text = "All Objects";
            // 
            // aTables
            // 
            this.aTables.Name = "aTables";
            this.aTables.Size = new System.Drawing.Size(150, 22);
            this.aTables.Text = "All Tables";
            // 
            // aProcedures
            // 
            this.aProcedures.Name = "aProcedures";
            this.aProcedures.Size = new System.Drawing.Size(150, 22);
            this.aProcedures.Text = "All Procedures";
            // 
            // dataTableView
            // 
            this.dataTableView.AllowUserToOrderColumns = true;
            this.dataTableView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataTableView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataTableView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTableView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTableView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataTableView.Location = new System.Drawing.Point(3, 33);
            this.dataTableView.Name = "dataTableView";
            this.dataTableView.Size = new System.Drawing.Size(715, 407);
            this.dataTableView.TabIndex = 1;
            // 
            // codeEdit
            // 
            this.codeEdit.AcceptsTab = true;
            this.codeEdit.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.codeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEdit.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.codeEdit.ForeColor = System.Drawing.Color.Black;
            this.codeEdit.Location = new System.Drawing.Point(35, 35);
            this.codeEdit.Name = "codeEdit";
            this.codeEdit.Size = new System.Drawing.Size(243, 396);
            this.codeEdit.TabIndex = 3;
            this.codeEdit.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(880, 499);
            this.Controls.Add(this.rightTabs);
            this.Controls.Add(this.leftTabs);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "ETL Tool";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.designerTab.ResumeLayout(false);
            this.tableLay3.ResumeLayout(false);
            this.grpDesigneDown.ResumeLayout(false);
            this.grpDesigneUp.ResumeLayout(false);
            this.leftTabs.ResumeLayout(false);
            this.rightTabs.ResumeLayout(false);
            this.workspaceTab.ResumeLayout(false);
            this.tableLay1.ResumeLayout(false);
            this.tableLay2.ResumeLayout(false);
            this.tableLay2.PerformLayout();
            this.tsCodeTools.ResumeLayout(false);
            this.tsCodeTools.PerformLayout();
            this.talbeLay4.ResumeLayout(false);
            this.talbeLay4.PerformLayout();
            this.tsObjectProperties.ResumeLayout(false);
            this.tsObjectProperties.PerformLayout();
            this.objectsTab.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.menuStripObjectsOverview.ResumeLayout(false);
            this.menuStripObjectsOverview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTableView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.TabControl rightTabs;
        private System.Windows.Forms.TabPage workspaceTab;
        private System.Windows.Forms.TabControl leftTabs;
        private System.Windows.Forms.TabPage designerTab;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asXMLToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLay1;
        private System.Windows.Forms.TableLayoutPanel tableLay2;
        private Controls.SyntaxTextBoxControl codeEdit;
        private System.Windows.Forms.TableLayoutPanel tableLay3;
        private System.Windows.Forms.GroupBox grpDesigneDown;
        private System.Windows.Forms.ListBox lbDesignerList;
        private System.Windows.Forms.GroupBox grpDesigneUp;
        private System.Windows.Forms.ListBox lbDesignerMode;
        private System.Windows.Forms.TabPage objectsTab;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.MenuStrip menuStripObjectsOverview;
        private System.Windows.Forms.ToolStripMenuItem tsExtraction;
        private System.Windows.Forms.ToolStripMenuItem tsTransformation;
        private System.Windows.Forms.ToolStripMenuItem eSourceTables;
        private System.Windows.Forms.ToolStripMenuItem eExtractionTables;
        private System.Windows.Forms.ToolStripMenuItem eExtractionProcedures;
        private System.Windows.Forms.ToolStripMenuItem tTransformationViews;
        private System.Windows.Forms.ToolStripMenuItem tTransformationProcedures;
        private System.Windows.Forms.ToolStripMenuItem tsLoad;
        private System.Windows.Forms.ToolStripMenuItem lLoadTables;
        private System.Windows.Forms.ToolStripMenuItem tsAll;
        private System.Windows.Forms.ToolStripMenuItem aAll;
        private System.Windows.Forms.ToolStripMenuItem aTables;
        private System.Windows.Forms.ToolStripMenuItem aProcedures;
        private System.Windows.Forms.DataGridView dataTableView;
        private System.Windows.Forms.TableLayoutPanel talbeLay4;
        private System.Windows.Forms.Panel visualPanel;
        private System.Windows.Forms.ToolStrip tsObjectProperties;
        private System.Windows.Forms.ToolStripLabel tsLabelObjectName;
        private System.Windows.Forms.ToolStripTextBox tsTextBoxObjectName;
        private System.Windows.Forms.ToolStripMenuItem lDestinationTables;
        private System.Windows.Forms.ToolStripMenuItem lDestinationViews;
        private System.Windows.Forms.ToolStrip tsCodeTools;
        private System.Windows.Forms.ToolStripButton tsButtonGenerateCode;
        private System.Windows.Forms.ToolStripButton tsButtonExport;
        private System.Windows.Forms.ToolStripDropDownButton tsDropDownOperations;
        private System.Windows.Forms.ToolStripMenuItem tsNew;
        private System.Windows.Forms.ToolStripMenuItem tsOpen;
        private System.Windows.Forms.ToolStripMenuItem tsSave;
        private System.Windows.Forms.ToolStripButton btnClearCode;
    }
}

