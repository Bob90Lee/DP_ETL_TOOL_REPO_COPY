using System;
using System.Drawing;
using System.Windows.Forms;
using DP_ETL_TOOL.Entities;

namespace DP_ETL_TOOL.Controls
{
    class TableControl : Label
    {

        private bool isDragged = false;
        private Point offset;

        private TableEntity tableEntity = new TableEntity();


        public TableControl()
        {
        }

        protected override void OnCreateControl()
        {            
            this.Text = tableEntity.GetName(); //+ "\n ( \t xxx, \n \t xxx )";

            this.AutoSize = true;

            Padding p = new Padding();
            p.All = 5;
            this.Padding = p;
           
            this.ForeColor = Color.White;
            this.BackColor = Color.DarkBlue;
            this.TextAlign = ContentAlignment.MiddleLeft;            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.BackColor = Color.LightBlue;


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

        protected override void OnMouseHover(EventArgs e)
        {
            this.BackColor = Color.LightBlue;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = Color.DarkBlue;
        }

        public TableEntity GetTableEntity()
        {
            return tableEntity;
        }

        private void ChangeTableName(object sender, EventArgs e)
        {
            Control senderControl = (Control) sender;
            tableEntity.SetTableName(senderControl.Text);
            this.Text = tableEntity.GetName();
            
        }

        private void DeleteTable(object sender, EventArgs e) {
            this.Dispose();
            Control senderControl = (Control)sender;
            senderControl.Parent.Parent.Dispose();
        }

        

    }
}
