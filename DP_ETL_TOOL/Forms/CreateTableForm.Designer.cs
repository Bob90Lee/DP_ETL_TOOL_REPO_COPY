namespace DP_ETL_TOOL.Forms
{
    partial class CreateTableForm
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
            this.btnNew = new System.Windows.Forms.Button();
            this.chListBoxTableList = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnCance = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(12, 141);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(120, 23);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // chListBoxTableList
            // 
            this.chListBoxTableList.FormattingEnabled = true;
            this.chListBoxTableList.Location = new System.Drawing.Point(12, 12);
            this.chListBoxTableList.Name = "chListBoxTableList";
            this.chListBoxTableList.Size = new System.Drawing.Size(372, 109);
            this.chListBoxTableList.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(138, 141);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(120, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Show Selected";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnCance
            // 
            this.btnCance.Location = new System.Drawing.Point(264, 141);
            this.btnCance.Name = "btnCance";
            this.btnCance.Size = new System.Drawing.Size(120, 23);
            this.btnCance.TabIndex = 3;
            this.btnCance.Text = "Cancel";
            this.btnCance.UseVisualStyleBackColor = true;
            // 
            // CreateTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 176);
            this.Controls.Add(this.btnCance);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.chListBoxTableList);
            this.Controls.Add(this.btnNew);
            this.Name = "CreateTableForm";
            this.Text = "Create Table";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.CheckedListBox chListBoxTableList;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnCance;
    }
}