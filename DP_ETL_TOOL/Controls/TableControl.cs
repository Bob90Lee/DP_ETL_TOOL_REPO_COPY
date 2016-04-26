using System;
using System.Drawing;
using System.Windows.Forms;
using DP_ETL_TOOL.Entities;
using DP_ETL_TOOL.Types;

namespace DP_ETL_TOOL.Controls
{
    class TableControl : Label
    {

        private bool isDragged = false;
        private Point offset;

        private TableEntity tableEntity;

        private Color tableColor;
        private Color textColor;
        private Color hoverColor;

        public TableControl(TableEntity tableEntity, Enums.TableType tableType, int posX, int posY)
        {
            if (tableEntity != null)
            {
                this.tableEntity = tableEntity;
            }
            else{
                this.tableEntity = new TableEntity(tableType);
            }

            switch (tableType)
            {
                case ( Enums.TableType.Source_Table ) : 
                    {
                        this.tableColor = Color.FromArgb(192, 57, 43);
                        this.textColor = Color.White;
                        this.hoverColor = Color.FromArgb(231, 76, 60);
                        break;
                    };
                case (Enums.TableType.Extraction_Table):
                    {
                        this.tableColor = Color.FromArgb(44, 62, 80);
                        this.textColor = Color.White;
                        this.hoverColor = Color.FromArgb(52, 73, 94);
                        break;
                    };
                case (Enums.TableType.Load_Table):
                    {
                        this.tableColor = Color.FromArgb(41, 128, 185);
                        this.textColor = Color.White;
                        this.hoverColor = Color.FromArgb(52, 152, 219);
                        break;
                    };
                case (Enums.TableType.Destination_Table):
                    {
                        this.tableColor = Color.FromArgb(211, 84, 0);
                        this.textColor = Color.White;
                        this.hoverColor = Color.FromArgb(230, 126, 34);
                        break;
                    };
            }

            //this.SetBounds(posX, posY, 100, 20);
        }

        protected override void OnCreateControl()
        {            
            this.Text = tableEntity.GetSchema() + "." + tableEntity.GetName();

            this.AutoSize = true;

            Padding p = new Padding();
            p.All = 5;
            this.Padding = p;

            this.ForeColor = textColor;
            this.BackColor = tableColor;
            this.TextAlign = ContentAlignment.MiddleLeft;            
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.BackColor = hoverColor;


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

            SetGuiCoords();

        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(offset);
                this.Location = newPoint;
            }

            SetGuiCoords();

        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            this.BackColor = tableColor;

            this.isDragged = false;

            SetGuiCoords();

        }

        protected override void OnMouseHover(EventArgs e)
        {
            this.BackColor = hoverColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            this.BackColor = tableColor;
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


        public void SetGuiCoords()
        {
            GUICoordsEntity coords = this.tableEntity.GetCoords();
            coords.SetPosX(this.Bounds.X);
            coords.SetPosY(this.Bounds.Y);
            coords.SetWidth(this.Width);
            coords.SetHeight(this.Height);
        }
        

    }
}
