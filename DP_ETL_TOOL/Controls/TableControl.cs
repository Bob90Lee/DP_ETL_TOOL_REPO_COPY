using System;
using System.Drawing;
using System.Windows.Forms;
using DP_ETL_TOOL.Forms;
using System.Text;
using System.Collections.Generic;

namespace DP_ETL_TOOL.Controls
{
    class TableControl : Label
    {

        private bool isDragged = false;
        private Point offset;

        private TableEntity tableEntity = new TableEntity();


        protected override void OnCreateControl()
        {            
            this.Text = tableEntity.getName(); //+ "\n ( \t xxx, \n \t xxx )";

            this.AutoSize = true;

            Padding p = new Padding();
            p.All = 5;
            this.Padding = p;
           
            this.ForeColor = Color.White;
            this.BackColor = Color.DarkBlue;
            this.TextAlign = ContentAlignment.MiddleLeft;            
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            CreateTableEditGUI(tableEntity);            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.BackColor = Color.Red;


            if (e.Button == MouseButtons.Left)
            {
                

                this.isDragged = true;
                Point startPosition = this.PointToScreen(new Point(e.X, e.Y));

                this.offset = new Point();
                this.offset.X = this.Location.X - startPosition.X;
                this.offset.Y = this.Location.Y - startPosition.Y;


            }
            else
            {
                this.isDragged = false;

            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(offset);
                this.Location = newPoint;
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.BackColor = Color.DarkBlue;

            this.isDragged = false;
        }



        public TableEntity getTableEntity()
        {
            return tableEntity;
        }

        private void changeTableName(object sender, EventArgs e)
        {
            Control senderControl = (Control) sender;
            tableEntity.setName(senderControl.Text);
            this.Text = tableEntity.getName();
            
        }

        private void deleteTable(object sender, EventArgs e) {
            this.Dispose();
            Control senderControl = (Control)sender;
            senderControl.Parent.Parent.Dispose();
        }

        private void DialogKeyEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Control s = (Control)sender;
                s.Parent.Parent.Dispose(); // this is not very nice, but works
            }
        }

        private void CreateTableEditGUI(TableEntity te)
        {

            StringBuilder sb = new StringBuilder();

            EditObjectForm editForm = new EditObjectForm();
            editForm.Text = this.Text;

            populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
            populateComboBoxColumnType((ComboBox)editForm.Controls["combColumnType"]);

            editForm.Controls["tbTableName"].Text = te.getName();
            editForm.Controls["tbSchemaName"].Text = te.getSchema();

            editForm.Controls["btnAdd"].Click += (sender, args) => {
                ComboBox cb = (ComboBox)editForm.Controls["combColumnType"];

                if (editForm.Controls["tbColumnName"].Text.ToString().Length > 0 && cb.SelectedItem != null && editForm.Controls["tbColumnLength"].Text.ToString().Length > 0)
                {
                    int length = 0;
                    int.TryParse(editForm.Controls["tbColumnLength"].Text, out length);

                    te.addColumn(editForm.Controls["tbColumnName"].Text.ToString(), cb.SelectedText, length);

                    populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
                }
            };


            editForm.Controls["btnRemove"].Click += (sender, args) =>
            {
                ComboBox cb = (ComboBox)editForm.Controls["combColumn"];

                if (cb.SelectedItem != null)
                {

                    te.removeColumn(cb.SelectedItem.ToString());

                    populateComboBoxColumn((ComboBox)editForm.Controls["combColumn"], te);
                }

                Console.WriteLine("IT WORKS");
            };

            editForm.KeyDown += new KeyEventHandler(DialogKeyEvent);

            editForm.ShowDialog(this);
        }

        private void populateComboBoxColumnType(ComboBox cb)
        {
            cb.Items.Add("VARCHAR2");
            cb.Items.Add("NUMBER");
        }

        private void populateComboBoxColumn(ComboBox cb, TableEntity te)
        {
            cb.Items.Clear();

            List<Column> columns = te.getColumns();

            if( columns != null)
            {
                foreach (Column c in columns)
                {
                    cb.Items.Add(c.getName());
                }
            }


        }

    }
}
