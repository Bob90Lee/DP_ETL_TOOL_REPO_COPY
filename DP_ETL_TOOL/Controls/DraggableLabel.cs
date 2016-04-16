using System;
using System.Drawing;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Controls
{
    class DraggableLabel : Label
    {

        bool isDragged = false;
        Point ptOffset;

        private void On_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.isDragged = true;
                Point ptStartPosition = this.PointToScreen(new Point(e.X, e.Y));

                this.ptOffset = new Point();
                this.ptOffset.X = this.Location.X - ptStartPosition.X;
                this.ptOffset.Y = this.Location.Y - ptStartPosition.Y;
            }
            else
            {
                this.isDragged = false;
            }
        }

        private void On_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged)
            {
                Point newPoint = this.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                this.Location = newPoint;
            }
        }

        private void On_MouseUp(object sender, MouseEventArgs e)
        {
            this.isDragged = false; //
        }
    }
}
