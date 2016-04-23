namespace DP_ETL_TOOL.Forms
{
    partial class SelectColumnForm
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
            this.lblColumnForJoin = new System.Windows.Forms.Label();
            this.combColumnName = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblColumnForJoin
            // 
            this.lblColumnForJoin.AutoSize = true;
            this.lblColumnForJoin.Location = new System.Drawing.Point(12, 9);
            this.lblColumnForJoin.Name = "lblColumnForJoin";
            this.lblColumnForJoin.Size = new System.Drawing.Size(115, 13);
            this.lblColumnForJoin.TabIndex = 0;
            this.lblColumnForJoin.Text = "Select Column For Join";
            // 
            // combColumnName
            // 
            this.combColumnName.FormattingEnabled = true;
            this.combColumnName.Location = new System.Drawing.Point(15, 39);
            this.combColumnName.Name = "combColumnName";
            this.combColumnName.Size = new System.Drawing.Size(256, 21);
            this.combColumnName.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(151, 79);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 79);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(120, 23);
            this.btnOk.TabIndex = 44;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // SelectColumnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 116);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.combColumnName);
            this.Controls.Add(this.lblColumnForJoin);
            this.Name = "SelectColumnForm";
            this.Text = "SelectColumnForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblColumnForJoin;
        private System.Windows.Forms.ComboBox combColumnName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
    }
}