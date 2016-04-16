using System;
using System.Drawing;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Controls
{
    class TableControl : Label
    {

        bool isDragged = false;
        Point offset;

        protected override void OnMouseDown(MouseEventArgs e)
        {
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
            this.isDragged = false;
        }


         
    }
}
