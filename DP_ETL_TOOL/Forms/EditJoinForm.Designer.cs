namespace DP_ETL_TOOL.Forms
{
    partial class EditJoinForm
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
            this.lblColumnPairs = new System.Windows.Forms.Label();
            this.lbColumnPairs = new System.Windows.Forms.ListBox();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.combMainColumn = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.combChilColumn = new System.Windows.Forms.ComboBox();
            this.btnAddPair = new System.Windows.Forms.Button();
            this.lblDeleteJoinPair = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblColumnPairs
            // 
            this.lblColumnPairs.AutoSize = true;
            this.lblColumnPairs.Location = new System.Drawing.Point(12, 9);
            this.lblColumnPairs.Name = "lblColumnPairs";
            this.lblColumnPairs.Size = new System.Drawing.Size(68, 13);
            this.lblColumnPairs.TabIndex = 0;
            this.lblColumnPairs.Text = "Column Pairs";
            // 
            // lbColumnPairs
            // 
            this.lbColumnPairs.FormattingEnabled = true;
            this.lbColumnPairs.Location = new System.Drawing.Point(12, 25);
            this.lbColumnPairs.Name = "lbColumnPairs";
            this.lbColumnPairs.Size = new System.Drawing.Size(261, 121);
            this.lbColumnPairs.TabIndex = 1;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Location = new System.Drawing.Point(153, 152);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(120, 23);
            this.btnDeleteSelected.TabIndex = 44;
            this.btnDeleteSelected.Text = "Delete Selected";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Location = new System.Drawing.Point(12, 189);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(98, 13);
            this.lblColumnType.TabIndex = 46;
            this.lblColumnType.Text = "Main Table Column";
            // 
            // combMainColumn
            // 
            this.combMainColumn.FormattingEnabled = true;
            this.combMainColumn.Location = new System.Drawing.Point(115, 181);
            this.combMainColumn.Name = "combMainColumn";
            this.combMainColumn.Size = new System.Drawing.Size(158, 21);
            this.combMainColumn.TabIndex = 45;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Child Table Column";
            // 
            // combChilColumn
            // 
            this.combChilColumn.FormattingEnabled = true;
            this.combChilColumn.Location = new System.Drawing.Point(115, 208);
            this.combChilColumn.Name = "combChilColumn";
            this.combChilColumn.Size = new System.Drawing.Size(158, 21);
            this.combChilColumn.TabIndex = 47;
            // 
            // btnAddPair
            // 
            this.btnAddPair.Location = new System.Drawing.Point(153, 235);
            this.btnAddPair.Name = "btnAddPair";
            this.btnAddPair.Size = new System.Drawing.Size(120, 23);
            this.btnAddPair.TabIndex = 49;
            this.btnAddPair.Text = "Add Column Pair";
            this.btnAddPair.UseVisualStyleBackColor = true;
            // 
            // lblDeleteJoinPair
            // 
            this.lblDeleteJoinPair.AutoSize = true;
            this.lblDeleteJoinPair.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteJoinPair.Location = new System.Drawing.Point(192, 335);
            this.lblDeleteJoinPair.Name = "lblDeleteJoinPair";
            this.lblDeleteJoinPair.Size = new System.Drawing.Size(81, 13);
            this.lblDeleteJoinPair.TabIndex = 52;
            this.lblDeleteJoinPair.Text = "Delete Join Pair";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 51;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(17, 293);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 50;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // EditJoinForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 357);
            this.Controls.Add(this.lblDeleteJoinPair);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAddPair);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.combChilColumn);
            this.Controls.Add(this.lblColumnType);
            this.Controls.Add(this.combMainColumn);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.lbColumnPairs);
            this.Controls.Add(this.lblColumnPairs);
            this.Name = "EditJoinForm";
            this.Text = "Edit Join";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColumnPairs;
        private System.Windows.Forms.ListBox lbColumnPairs;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.ComboBox combMainColumn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combChilColumn;
        private System.Windows.Forms.Button btnAddPair;
        private System.Windows.Forms.Label lblDeleteJoinPair;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}