using System;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Controls
{
    class JoinControl : UserControl
    {
        private TableControl mainTable;
        private TableControl childTable;

        private int lastMainX;
        private int lastMainY;
        private int lastChildX;
        private int lastChildY;

        Control thisParent = null;

        Enums.JoinType joinType = Enums.JoinType.Left;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle = cp.ExStyle | 0x20;
                return cp;
            }
        }

        public JoinControl(Control parent, Enums.JoinType jt)
        {
            Size = new Size(1000, 1000);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);

            this.BackColor = Color.Transparent;
            this.Enabled = false;

            thisParent = parent;

            this.joinType = jt;
        }

        public void setMainTable(TableControl te)
        {
            mainTable = te;

            lastMainX = te.Bounds.X + te.Width/2;
            lastMainY = te.Bounds.Y + te.Height/2;
        }

        public void setChildEntity(TableControl te)
        {
            childTable = te;

            lastChildX = te.Bounds.X + te.Width / 2;
            lastChildY = te.Bounds.Y + te.Height / 2;
        }

        public TableControl getMainTable()
        {
            return mainTable;
        }

        public TableControl getChildTable()
        {
            return childTable;
        }

        private bool isTableObjectMove(TableControl mainTable, TableControl childTable)
        {
            if (lastMainX != mainTable.Bounds.X || lastMainY != mainTable.Bounds.Y || lastChildX != childTable.Bounds.X || lastChildY != childTable.Bounds.Y)
            {
                int delta = 0;

                delta = lastMainX - mainTable.Bounds.X;
                if (Math.Abs(delta) > 20) { lastMainX = mainTable.Bounds.X;  return true; };

                delta = lastMainY - mainTable.Bounds.Y;
                if (Math.Abs(delta) > 5) { lastMainY = mainTable.Bounds.Y;  return true; };

                delta = lastChildX - childTable.Bounds.X;
                if (Math.Abs(delta) > 20) { lastChildX = childTable.Bounds.X;  return true; };

                delta = lastChildY - childTable.Bounds.Y;
                if (Math.Abs(delta) > 5) { lastChildY = childTable.Bounds.Y;  return true; };

                return false;
            }
            else
            {
                return false;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle bounds = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            if (mainTable != null && childTable != null && isTableObjectMove(mainTable, childTable))
            {
                thisParent.Invalidate(this.Bounds, true);

                g.FillRectangle(new SolidBrush(Color.FromArgb(255, this.BackColor)), bounds);
            }
            else {

                Pen pen;

                switch (joinType)
                {
                    case Enums.JoinType.Left :
                        {
                            pen = new Pen(Color.Red, 2);
                            break;
                        }
                    case Enums.JoinType.Inner:
                        {
                            pen = new Pen(Color.Green, 2);
                            break;
                        }
                    default:
                        {
                            pen = new Pen(Color.Black, 2);
                            break;
                        }

                }

                g.DrawLine(pen, mainTable.Bounds.X + mainTable.Width / 2, mainTable.Bounds.Y + mainTable.Height / 2, childTable.Bounds.X + childTable.Width / 2, childTable.Bounds.Y + childTable.Height / 2);
            }


            g.Dispose();
            base.OnPaint(e);
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                Parent.Invalidate(this.Bounds, true);
            }
            base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.Invalidate();
            base.OnParentBackColorChanged(e);
        }

    }
}
