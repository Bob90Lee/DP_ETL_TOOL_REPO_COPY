namespace DP_ETL_TOOL.Forms
{
    partial class EditTableForm
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
            this.btnEditColumn = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.tbColumnName = new System.Windows.Forms.TextBox();
            this.combColumn = new System.Windows.Forms.ComboBox();
            this.combColumnType = new System.Windows.Forms.ComboBox();
            this.chckIsUnique = new System.Windows.Forms.CheckBox();
            this.tbColumnLength = new System.Windows.Forms.TextBox();
            this.lblJoins = new System.Windows.Forms.Label();
            this.combJoins = new System.Windows.Forms.ComboBox();
            this.lblColumnName = new System.Windows.Forms.Label();
            this.lblColumnType = new System.Windows.Forms.Label();
            this.lblColumnLength = new System.Windows.Forms.Label();
            this.lblSelectedColumn = new System.Windows.Forms.Label();
            this.lblSelectedJoin = new System.Windows.Forms.Label();
            this.btnEditJoin = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblIndexes = new System.Windows.Forms.Label();
            this.btnEditIndexes = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDeleteTable = new System.Windows.Forms.Label();
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
            this.tbTableName.Size = new System.Drawing.Size(157, 20);
            this.tbTableName.TabIndex = 1;
            // 
            // lblSchemaName
            // 
            this.lblSchemaName.AutoSize = true;
            this.lblSchemaName.Location = new System.Drawing.Point(12, 39);
            this.lblSchemaName.Name = "lblSchemaName";
            this.lblSchemaName.Size = new System.Drawing.Size(77, 13);
            this.lblSchemaName.TabIndex = 2;
            this.lblSchemaName.Text = "Schema Name";
            // 
            // tbSchemaName
            // 
            this.tbSchemaName.Location = new System.Drawing.Point(113, 32);
            this.tbSchemaName.Name = "tbSchemaName";
            this.tbSchemaName.Size = new System.Drawing.Size(158, 20);
            this.tbSchemaName.TabIndex = 3;
            // 
            // lblColumns
            // 
            this.lblColumns.AutoSize = true;
            this.lblColumns.Location = new System.Drawing.Point(12, 65);
            this.lblColumns.Name = "lblColumns";
            this.lblColumns.Size = new System.Drawing.Size(47, 13);
            this.lblColumns.TabIndex = 4;
            this.lblColumns.Text = "Columns";
            // 
            // btnEditColumn
            // 
            this.btnEditColumn.Location = new System.Drawing.Point(210, 219);
            this.btnEditColumn.Name = "btnEditColumn";
            this.btnEditColumn.Size = new System.Drawing.Size(62, 23);
            this.btnEditColumn.TabIndex = 6;
            this.btnEditColumn.Text = "Edit";
            this.btnEditColumn.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(210, 163);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // tbColumnName
            // 
            this.tbColumnName.Location = new System.Drawing.Point(113, 84);
            this.tbColumnName.Name = "tbColumnName";
            this.tbColumnName.Size = new System.Drawing.Size(158, 20);
            this.tbColumnName.TabIndex = 8;
            // 
            // combColumn
            // 
            this.combColumn.FormattingEnabled = true;
            this.combColumn.Location = new System.Drawing.Point(114, 192);
            this.combColumn.Name = "combColumn";
            this.combColumn.Size = new System.Drawing.Size(158, 21);
            this.combColumn.TabIndex = 9;
            // 
            // combColumnType
            // 
            this.combColumnType.FormattingEnabled = true;
            this.combColumnType.Location = new System.Drawing.Point(113, 110);
            this.combColumnType.Name = "combColumnType";
            this.combColumnType.Size = new System.Drawing.Size(158, 21);
            this.combColumnType.TabIndex = 11;
            // 
            // chckIsUnique
            // 
            this.chckIsUnique.AutoSize = true;
            this.chckIsUnique.Location = new System.Drawing.Point(113, 169);
            this.chckIsUnique.Name = "chckIsUnique";
            this.chckIsUnique.Size = new System.Drawing.Size(71, 17);
            this.chckIsUnique.TabIndex = 12;
            this.chckIsUnique.Text = "Is Unique";
            this.chckIsUnique.UseVisualStyleBackColor = true;
            // 
            // tbColumnLength
            // 
            this.tbColumnLength.Location = new System.Drawing.Point(113, 137);
            this.tbColumnLength.Name = "tbColumnLength";
            this.tbColumnLength.Size = new System.Drawing.Size(158, 20);
            this.tbColumnLength.TabIndex = 15;
            // 
            // lblJoins
            // 
            this.lblJoins.AutoSize = true;
            this.lblJoins.Location = new System.Drawing.Point(12, 251);
            this.lblJoins.Name = "lblJoins";
            this.lblJoins.Size = new System.Drawing.Size(31, 13);
            this.lblJoins.TabIndex = 16;
            this.lblJoins.Text = "Joins";
            // 
            // combJoins
            // 
            this.combJoins.FormattingEnabled = true;
            this.combJoins.Location = new System.Drawing.Point(113, 270);
            this.combJoins.Name = "combJoins";
            this.combJoins.Size = new System.Drawing.Size(159, 21);
            this.combJoins.TabIndex = 19;
            // 
            // lblColumnName
            // 
            this.lblColumnName.AutoSize = true;
            this.lblColumnName.Location = new System.Drawing.Point(12, 91);
            this.lblColumnName.Name = "lblColumnName";
            this.lblColumnName.Size = new System.Drawing.Size(73, 13);
            this.lblColumnName.TabIndex = 30;
            this.lblColumnName.Text = "Column Name";
            // 
            // lblColumnType
            // 
            this.lblColumnType.AutoSize = true;
            this.lblColumnType.Location = new System.Drawing.Point(12, 118);
            this.lblColumnType.Name = "lblColumnType";
            this.lblColumnType.Size = new System.Drawing.Size(69, 13);
            this.lblColumnType.TabIndex = 31;
            this.lblColumnType.Text = "Column Type";
            // 
            // lblColumnLength
            // 
            this.lblColumnLength.AutoSize = true;
            this.lblColumnLength.Location = new System.Drawing.Point(12, 144);
            this.lblColumnLength.Name = "lblColumnLength";
            this.lblColumnLength.Size = new System.Drawing.Size(78, 13);
            this.lblColumnLength.TabIndex = 32;
            this.lblColumnLength.Text = "Column Length";
            // 
            // lblSelectedColumn
            // 
            this.lblSelectedColumn.AutoSize = true;
            this.lblSelectedColumn.Location = new System.Drawing.Point(12, 200);
            this.lblSelectedColumn.Name = "lblSelectedColumn";
            this.lblSelectedColumn.Size = new System.Drawing.Size(87, 13);
            this.lblSelectedColumn.TabIndex = 33;
            this.lblSelectedColumn.Text = "Selected Column";
            // 
            // lblSelectedJoin
            // 
            this.lblSelectedJoin.AutoSize = true;
            this.lblSelectedJoin.Location = new System.Drawing.Point(12, 278);
            this.lblSelectedJoin.Name = "lblSelectedJoin";
            this.lblSelectedJoin.Size = new System.Drawing.Size(71, 13);
            this.lblSelectedJoin.TabIndex = 34;
            this.lblSelectedJoin.Text = "Selected Join";
            // 
            // btnEditJoin
            // 
            this.btnEditJoin.Location = new System.Drawing.Point(211, 295);
            this.btnEditJoin.Name = "btnEditJoin";
            this.btnEditJoin.Size = new System.Drawing.Size(61, 23);
            this.btnEditJoin.TabIndex = 35;
            this.btnEditJoin.Text = "Edit";
            this.btnEditJoin.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 395);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 13;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // lblIndexes
            // 
            this.lblIndexes.AutoSize = true;
            this.lblIndexes.Location = new System.Drawing.Point(12, 349);
            this.lblIndexes.Name = "lblIndexes";
            this.lblIndexes.Size = new System.Drawing.Size(44, 13);
            this.lblIndexes.TabIndex = 36;
            this.lblIndexes.Text = "Indexes";
            // 
            // btnEditIndexes
            // 
            this.btnEditIndexes.Location = new System.Drawing.Point(209, 339);
            this.btnEditIndexes.Name = "btnEditIndexes";
            this.btnEditIndexes.Size = new System.Drawing.Size(62, 23);
            this.btnEditIndexes.TabIndex = 37;
            this.btnEditIndexes.Text = "Edit";
            this.btnEditIndexes.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 395);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 38;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDeleteTable
            // 
            this.lblDeleteTable.AutoSize = true;
            this.lblDeleteTable.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteTable.Location = new System.Drawing.Point(203, 436);
            this.lblDeleteTable.Name = "lblDeleteTable";
            this.lblDeleteTable.Size = new System.Drawing.Size(68, 13);
            this.lblDeleteTable.TabIndex = 39;
            this.lblDeleteTable.Text = "Delete Table";
            this.lblDeleteTable.Click += new System.EventHandler(this.lblDeleteTable_Click);
            // 
            // EditTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 458);
            this.Controls.Add(this.lblDeleteTable);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnEditIndexes);
            this.Controls.Add(this.lblIndexes);
            this.Controls.Add(this.btnEditJoin);
            this.Controls.Add(this.lblSelectedJoin);
            this.Controls.Add(this.lblSelectedColumn);
            this.Controls.Add(this.lblColumnLength);
            this.Controls.Add(this.lblColumnType);
            this.Controls.Add(this.lblColumnName);
            this.Controls.Add(this.combJoins);
            this.Controls.Add(this.lblJoins);
            this.Controls.Add(this.tbColumnLength);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.chckIsUnique);
            this.Controls.Add(this.combColumnType);
            this.Controls.Add(this.combColumn);
            this.Controls.Add(this.tbColumnName);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEditColumn);
            this.Controls.Add(this.lblColumns);
            this.Controls.Add(this.tbSchemaName);
            this.Controls.Add(this.lblSchemaName);
            this.Controls.Add(this.tbTableName);
            this.Controls.Add(this.lblTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditTableForm";
            this.ShowIcon = false;
            this.Text = "Edit Table";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.TextBox tbTableName;
        private System.Windows.Forms.Label lblSchemaName;
        private System.Windows.Forms.TextBox tbSchemaName;
        private System.Windows.Forms.Label lblColumns;
        private System.Windows.Forms.Button btnEditColumn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox tbColumnName;
        private System.Windows.Forms.ComboBox combColumn;
        private System.Windows.Forms.ComboBox combColumnType;
        private System.Windows.Forms.CheckBox chckIsUnique;
        private System.Windows.Forms.TextBox tbColumnLength;
        private System.Windows.Forms.Label lblJoins;
        private System.Windows.Forms.ComboBox combJoins;
        private System.Windows.Forms.Label lblColumnName;
        private System.Windows.Forms.Label lblColumnType;
        private System.Windows.Forms.Label lblColumnLength;
        private System.Windows.Forms.Label lblSelectedColumn;
        private System.Windows.Forms.Label lblSelectedJoin;
        private System.Windows.Forms.Button btnEditJoin;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Label lblIndexes;
        private System.Windows.Forms.Button btnEditIndexes;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDeleteTable;
    }
}