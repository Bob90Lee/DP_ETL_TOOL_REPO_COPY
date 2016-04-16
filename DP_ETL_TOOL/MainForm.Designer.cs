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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.snippetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.designerTab = new System.Windows.Forms.TabPage();
            this.leftTabs = new System.Windows.Forms.TabControl();
            this.rightTabs = new System.Windows.Forms.TabControl();
            this.visualTab = new System.Windows.Forms.TabPage();
            this.codeTab = new System.Windows.Forms.TabPage();
            this.codeEdit = new System.Windows.Forms.RichTextBox();
            this.codeControl = new System.Windows.Forms.RichTextBox();
            this.visualPanel = new System.Windows.Forms.Panel();
            this.MainMenu.SuspendLayout();
            this.leftTabs.SuspendLayout();
            this.rightTabs.SuspendLayout();
            this.visualTab.SuspendLayout();
            this.codeTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.snippetsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(880, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // applicationToolStripMenuItem
            // 
            this.applicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.applicationToolStripMenuItem.Name = "applicationToolStripMenuItem";
            this.applicationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.applicationToolStripMenuItem.Text = "Application";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // snippetsToolStripMenuItem
            // 
            this.snippetsToolStripMenuItem.Name = "snippetsToolStripMenuItem";
            this.snippetsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.snippetsToolStripMenuItem.Text = "Snippets";
            // 
            // designerTab
            // 
            this.designerTab.BackColor = System.Drawing.Color.White;
            this.designerTab.Location = new System.Drawing.Point(4, 22);
            this.designerTab.Name = "designerTab";
            this.designerTab.Padding = new System.Windows.Forms.Padding(3);
            this.designerTab.Size = new System.Drawing.Size(137, 449);
            this.designerTab.TabIndex = 0;
            this.designerTab.Text = "Designer";
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
            this.rightTabs.Controls.Add(this.visualTab);
            this.rightTabs.Controls.Add(this.codeTab);
            this.rightTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightTabs.Location = new System.Drawing.Point(145, 24);
            this.rightTabs.Name = "rightTabs";
            this.rightTabs.SelectedIndex = 0;
            this.rightTabs.Size = new System.Drawing.Size(735, 475);
            this.rightTabs.TabIndex = 2;
            this.rightTabs.TabStop = false;
            // 
            // visualTab
            // 
            this.visualTab.AutoScroll = true;
            this.visualTab.BackColor = System.Drawing.Color.White;
            this.visualTab.Controls.Add(this.visualPanel);
            this.visualTab.Location = new System.Drawing.Point(4, 22);
            this.visualTab.Name = "visualTab";
            this.visualTab.Padding = new System.Windows.Forms.Padding(3);
            this.visualTab.Size = new System.Drawing.Size(727, 449);
            this.visualTab.TabIndex = 0;
            this.visualTab.Text = "Visual";
            // 
            // codeTab
            // 
            this.codeTab.Controls.Add(this.codeEdit);
            this.codeTab.Controls.Add(this.codeControl);
            this.codeTab.Location = new System.Drawing.Point(4, 22);
            this.codeTab.Name = "codeTab";
            this.codeTab.Size = new System.Drawing.Size(727, 449);
            this.codeTab.TabIndex = 1;
            this.codeTab.Text = "Code";
            this.codeTab.UseVisualStyleBackColor = true;
            // 
            // codeEdit
            // 
            this.codeEdit.AcceptsTab = true;
            this.codeEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.codeEdit.Location = new System.Drawing.Point(40, 0);
            this.codeEdit.Name = "codeEdit";
            this.codeEdit.Size = new System.Drawing.Size(687, 449);
            this.codeEdit.TabIndex = 0;
            this.codeEdit.Text = "";
            // 
            // codeControl
            // 
            this.codeControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.codeControl.Location = new System.Drawing.Point(0, 0);
            this.codeControl.Name = "codeControl";
            this.codeControl.ReadOnly = true;
            this.codeControl.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.codeControl.Size = new System.Drawing.Size(40, 449);
            this.codeControl.TabIndex = 0;
            this.codeControl.Text = "";
            // 
            // visualPanel
            // 
            this.visualPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.visualPanel.Location = new System.Drawing.Point(3, 3);
            this.visualPanel.Name = "visualPanel";
            this.visualPanel.Size = new System.Drawing.Size(721, 443);
            this.visualPanel.TabIndex = 0;
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
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "ETL Tool";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.leftTabs.ResumeLayout(false);
            this.rightTabs.ResumeLayout(false);
            this.visualTab.ResumeLayout(false);
            this.codeTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.TabControl rightTabs;
        private System.Windows.Forms.TabPage visualTab;
        private System.Windows.Forms.TabControl leftTabs;
        private System.Windows.Forms.TabPage designerTab;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem snippetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabPage codeTab;
        private System.Windows.Forms.RichTextBox codeEdit;
        private System.Windows.Forms.RichTextBox codeControl;
        private System.Windows.Forms.Panel visualPanel;
    }
}

