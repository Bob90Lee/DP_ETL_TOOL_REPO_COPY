namespace DP_ETL_TOOL.Forms
{
    partial class EditObjectForm
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
            this.lblTableName = new System.Windows.Forms.Label();
            this.tbTableName = new System.Windows.Forms.TextBox();
            this.lblSchemaName = new System.Windows.Forms.Label();
            this.tbSchemaName = new System.Windows.Forms.TextBox();
            this.lblColumns = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbColumnName = new System.Windows.Forms.TextBox();
            this.combColumn = new System.Windows.Forms.ComboBox();
            this.chckIsKey = new System.Windows.Forms.CheckBox();
            this.combColumnType = new System.Windows.Forms.ComboBox();
            this.chckIsUnique = new System.Windows.Forms.CheckBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbColumnLength = new System.Windows.Forms.TextBox();
            this.lblJoins = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(12, 9);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(65, 13);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Table Name";
            // 
            // tbTableName
            // 
            this.tbTableName.Location = new System.Drawing.Point(114, 6);
            this.tbTableName.Name = "tbTableName";
            this.tbTableName.Size = new System.Drawing.Size(158, 20);
            this.tbTableName.TabIndex = 1;
            // 
            // lblSchemaName
            // 
            this.lblSchemaName.AutoSize = true;
            this.lblSchemaName.Location = new System.Drawing.Point(12, 35);
            this.lblSchemaName.Name = "lblSchemaName";
            this.lblSchemaName.Size = new System.Drawing.Size(77, 13);
            this.lblSchemaName.TabIndex = 2;
            this.lblSchemaName.Text = "Schema Name";
            // 
            // tbSchemaName
            // 
            this.tbSchemaName.Location = new System.Drawing.Point(114, 32);
            this.tbSchemaName.Name = "tbSchemaName";
            this.tbSchemaName.Size = new System.Drawing.Size(158, 20);
            this.tbSchemaName.TabIndex = 3;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(15, 62);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 4;
            this.lblColumns.Text = "Columns";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(18, 143);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(62, 23);
            this.btnRemove.TabIndex = 6;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(18, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tbColumnName
            // 
            this.tbColumnName.Location = new System.Drawing.Point(114, 90);
            this.tbColumnName.Name = "tbColumnName";
            this.tbColumnName.Size = new System.Drawing.Size(158, 20);
            this.tbColumnName.TabIndex = 8;
            // 
            // combColumn
            // 
            this.combColumn.FormattingEnabled = true;
            this.combColumn.Location = new System.Drawing.Point(114, 145);
            this.combColumn.Name = "combColumn";
            this.combColumn.Size = new System.Drawing.Size(158, 21);
            this.combColumn.TabIndex = 9;
            // 
            // chckIsKey
            // 
            this.chckIsKey.AutoSize = true;
            this.chckIsKey.Location = new System.Drawing.Point(18, 182);
            this.chckIsKey.Name = "chckIsKey";
            this.chckIsKey.Size = new System.Drawing.Size(55, 17);
            this.chckIsKey.TabIndex = 10;
            this.chckIsKey.Text = "Is Key";
            this.chckIsKey.UseVisualStyleBackColor = true;
            // 
            // combColumnType
            // 
            this.combColumnType.FormattingEnabled = true;
            this.combColumnType.Location = new System.Drawing.Point(114, 116);
            this.combColumnType.Name = "combColumnType";
            this.combColumnType.Size = new System.Drawing.Size(101, 21);
            this.combColumnType.TabIndex = 11;
            // 
            // chckIsUnique
            // 
            this.chckIsUnique.AutoSize = true;
            this.chckIsUnique.Location = new System.Drawing.Point(114, 182);
            this.chckIsUnique.Name = "chckIsUnique";
            this.chckIsUnique.Size = new System.Drawing.Size(71, 17);
            this.chckIsUnique.TabIndex = 12;
            this.chckIsUnique.Text = "Is Unique";
            this.chckIsUnique.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 439);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(119, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(153, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(119, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbColumnLength
            // 
            this.tbColumnLength.Location = new System.Drawing.Point(221, 116);
            this.tbColumnLength.Name = "tbColumnLength";
            this.tbColumnLength.Size = new System.Drawing.Size(50, 20);
            this.tbColumnLength.TabIndex = 15;
            // 
            // lblJoins
            // 
            this.lblJoins.AutoSize = true;
            this.lblJoins.Location = new System.Drawing.Point(15, 216);
            this.lblJoins.Name = "lblJoins";
            this.lblJoins.Size = new System.Drawing.Size(31, 13);
            this.lblJoins.TabIndex = 16;
            this.lblJoins.Text = "Joins";
            // 
            // EditObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 474);
            this.Controls.Add(this.lblJoins);
            this.Controls.Add(this.tbColumnLength);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chckIsUnique);
            this.Controls.Add(this.combColumnType);
            this.Controls.Add(this.chckIsKey);
            this.Controls.Add(this.combColumn);
            this.Controls.Add(this.tbColumnName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.tbSchemaName);
            this.Controls.Add(this.lblSchemaName);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.lblTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditObjectForm";
            this.ShowIcon = false;
            this.Text = "Edit";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label lblSchemaName;
        private System.Windows.Forms.TextBox tbSchemaName;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbColumnName;
        private System.Windows.Forms.ComboBox combColumn;
        private System.Windows.Forms.CheckBox chckIsKey;
        private System.Windows.Forms.ComboBox combColumnType;
        private System.Windows.Forms.CheckBox chckIsUnique;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbColumnLength;
        private System.Windows.Forms.Label lblJoins;
    }
}