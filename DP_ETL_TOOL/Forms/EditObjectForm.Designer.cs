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
            this.tbColumnLength = new System.Windows.Forms.TextBox();
            this.lblJoins = new System.Windows.Forms.Label();
            this.combParent = new System.Windows.Forms.ComboBox();
            this.combJoins = new System.Windows.Forms.ComboBox();
            this.btnJoinRemove = new System.Windows.Forms.Button();
            this.lbConnections = new System.Windows.Forms.ListBox();
            this.combChild = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddConnection = new System.Windows.Forms.Button();
            this.lblParentColumn = new System.Windows.Forms.Label();
            this.lblChildColumn = new System.Windows.Forms.Label();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.btnOk.Size = new System.Drawing.Size(106, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
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
            // combParent
            // 
            this.combParent.FormattingEnabled = true;
            this.combParent.Location = new System.Drawing.Point(18, 355);
            this.combParent.Name = "combParent";
            this.combParent.Size = new System.Drawing.Size(116, 21);
            this.combParent.TabIndex = 17;
            // 
            // combJoins
            // 
            this.combJoins.FormattingEnabled = true;
            this.combJoins.Location = new System.Drawing.Point(114, 213);
            this.combJoins.Name = "combJoins";
            this.combJoins.Size = new System.Drawing.Size(128, 21);
            this.combJoins.TabIndex = 19;
            // 
            // btnJoinRemove
            // 
            this.btnJoinRemove.Location = new System.Drawing.Point(248, 211);
            this.btnJoinRemove.Name = "btnJoinRemove";
            this.btnJoinRemove.Size = new System.Drawing.Size(24, 23);
            this.btnJoinRemove.TabIndex = 20;
            this.btnJoinRemove.Text = "X";
            this.btnJoinRemove.UseVisualStyleBackColor = true;
            // 
            // lbConnections
            // 
            this.lbConnections.FormattingEnabled = true;
            this.lbConnections.Location = new System.Drawing.Point(18, 240);
            this.lbConnections.Name = "lbConnections";
            this.lbConnections.Size = new System.Drawing.Size(253, 82);
            this.lbConnections.TabIndex = 21;
            // 
            // combChild
            // 
            this.combChild.FormattingEnabled = true;
            this.combChild.Location = new System.Drawing.Point(153, 355);
            this.combChild.Name = "combChild";
            this.combChild.Size = new System.Drawing.Size(118, 21);
            this.combChild.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(152, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 24;
            this.button1.Text = "Remove Selected";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAddConnection
            // 
            this.btnAddConnection.Location = new System.Drawing.Point(15, 382);
            this.btnAddConnection.Name = "btnAddConnection";
            this.btnAddConnection.Size = new System.Drawing.Size(119, 23);
            this.btnAddConnection.TabIndex = 23;
            this.btnAddConnection.Text = "Add Conection";
            this.btnAddConnection.UseVisualStyleBackColor = true;
            // 
            // lblParentColumn
            // 
            this.lblParentColumn.AutoSize = true;
            this.lblParentColumn.Location = new System.Drawing.Point(15, 331);
            this.lblParentColumn.Name = "lblParentColumn";
            this.lblParentColumn.Size = new System.Drawing.Size(106, 13);
            this.lblParentColumn.TabIndex = 25;
            this.lblParentColumn.Text = "Parent Table Column";
            // 
            // lblChildColumn
            // 
            this.lblChildColumn.AutoSize = true;
            this.lblChildColumn.Location = new System.Drawing.Point(154, 331);
            this.lblChildColumn.Name = "lblChildColumn";
            this.lblChildColumn.Size = new System.Drawing.Size(98, 13);
            this.lblChildColumn.TabIndex = 26;
            this.lblChildColumn.Text = "Child Table Column";
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(247, 439);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(24, 23);
            this.btnDeleteTable.TabIndex = 28;
            this.btnDeleteTable.Text = "X";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(132, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(106, 23);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditObjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 474);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.lblChildColumn);
            this.Controls.Add(this.lblParentColumn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnAddConnection);
            this.Controls.Add(this.combChild);
            this.Controls.Add(this.lbConnections);
            this.Controls.Add(this.btnJoinRemove);
            this.Controls.Add(this.combJoins);
            this.Controls.Add(this.combParent);
            this.Controls.Add(this.lblJoins);
            this.Controls.Add(this.tbColumnLength);
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
        private System.Windows.Forms.TextBox tbColumnLength;
        private System.Windows.Forms.Label lblJoins;
        private System.Windows.Forms.ComboBox combJoins;
        private System.Windows.Forms.ComboBox combParent;
        private System.Windows.Forms.Button btnJoinRemove;
        private System.Windows.Forms.ListBox lbConnections;
        private System.Windows.Forms.ComboBox combChild;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddConnection;
        private System.Windows.Forms.Label lblParentColumn;
        private System.Windows.Forms.Label lblChildColumn;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnCancel;
    }
}