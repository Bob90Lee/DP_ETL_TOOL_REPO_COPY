using System;
using System.Drawing;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Controls
{
    class JoinControl : Control
    {
        private TableControl mainTable;
        private TableControl childTable;

        public JoinControl()
        {
            Size = new Size(1024, 1024);
        }

        public void setMainTable(TableControl te)
        {
            mainTable = te;
        }

        public void setChildEntity(TableControl te)
        {
            childTable = te;
        }

        public TableControl getMainTable()
        {
            return mainTable;
        }

        public TableControl getChildTable()
        {
            return childTable;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if ( mainTable != null && childTable != null)
            {
                //e.Graphics.

                Pen pen = new Pen(Color.Red, 5);
                e.Graphics.DrawLine(pen, mainTable.Bounds.X, mainTable.Bounds.Y, childTable.Bounds.X, childTable.Bounds.Y);
                pen.Dispose();
            }
        }
    }
}
