namespace DP_ETL_TOOL.Forms
{
    partial class EditColumnForm
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
            this.lblColumnLength = new System.Windows.Forms.Label();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.tbColumnLength = new System.Windows.Forms.TextBox();
            this.chckIsUnique = new System.Windows.Forms.CheckBox();
            this.combColumnType = new System.Windows.Forms.ComboBox();
            this.tbColumnName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDeleteColumn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblColumnLength
            // 
            this.lblColumnLength.AutoSize = true;
            this.lblColumnLength.Location = new System.Drawing.Point(12, 67);
            this.lblColumnLength.Name = "lblColumnLength";
            this.lblColumnLength.Size = new System.Drawing.Size(78, 13);
            this.lblColumnLength.TabIndex = 41;
            this.lblColumnLength.Text = "Column Length";
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Location = new System.Drawing.Point(12, 41);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(69, 13);
            this.lblColumnType.TabIndex = 40;
            this.lblColumnType.Text = "Column Type";
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Location = new System.Drawing.Point(12, 14);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(73, 13);
            this.lblColumnName.TabIndex = 39;
            this.lblColumnName.Text = "Column Name";
            // 
            // tbColumnLength
            // 
            this.tbColumnLength.Location = new System.Drawing.Point(113, 60);
            this.tbColumnLength.Name = "tbColumnLength";
            this.tbColumnLength.Size = new System.Drawing.Size(158, 20);
            this.tbColumnLength.TabIndex = 38;
            // 
            // chckIsUnique
            // 
            this.chckIsUnique.AutoSize = true;
            this.chckIsUnique.Location = new System.Drawing.Point(200, 86);
            this.chckIsUnique.Name = "chckIsUnique";
            this.chckIsUnique.Size = new System.Drawing.Size(71, 17);
            this.chckIsUnique.TabIndex = 37;
            this.chckIsUnique.Text = "Is Unique";
            this.chckIsUnique.UseVisualStyleBackColor = true;
            // 
            // combColumnType
            // 
            this.combColumnType.FormattingEnabled = true;
            this.combColumnType.Location = new System.Drawing.Point(113, 33);
            this.combColumnType.Name = "combColumnType";
            this.combColumnType.Size = new System.Drawing.Size(158, 21);
            this.combColumnType.TabIndex = 36;
            // 
            // tbColumnName
            // 
            this.tbColumnName.Location = new System.Drawing.Point(113, 7);
            this.tbColumnName.Name = "tbColumnName";
            this.tbColumnName.Size = new System.Drawing.Size(158, 20);
            this.tbColumnName.TabIndex = 35;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 113);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 42;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblDeleteColumn
            // 
            this.lblDeleteColumn.AutoSize = true;
            this.lblDeleteColumn.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteColumn.Location = new System.Drawing.Point(200, 152);
            this.lblDeleteColumn.Name = "lblDeleteColumn";
            this.lblDeleteColumn.Size = new System.Drawing.Size(76, 13);
            this.lblDeleteColumn.TabIndex = 44;
            this.lblDeleteColumn.Text = "Delete Column";
            // 
            // EditColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 174);
            this.Controls.Add(this.lblDeleteColumn);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblColumnLength);
            this.Controls.Add(this.lblColumnType);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.tbColumnLength);
            this.Controls.Add(this.chckIsUnique);
            this.Controls.Add(this.combColumnType);
            this.Controls.Add(this.tbColumnName);
            this.Name = "EditColumnForm";
            this.Text = "Edit Column";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColumnLength;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.TextBox tbColumnLength;
        private System.Windows.Forms.CheckBox chckIsUnique;
        private System.Windows.Forms.ComboBox combColumnType;
        private System.Windows.Forms.TextBox tbColumnName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblDeleteColumn;
    }
}