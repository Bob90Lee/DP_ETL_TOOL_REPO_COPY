using DP_ETL_TOOL.Types;
using DP_ETL_TOOL.Entities;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace DP_ETL_TOOL.Controls
{
    class JoinControl : UserControl
    {
        private JoinEntity join;
        private TableControl mainTable;
        private TableControl childTable;

        private int lastMainX;
        private int lastMainY;
        private int lastChildX;
        private int lastChildY;

        private int thresholdX = 20;
        private int thresholdY = 5;

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
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);

            this.Size = new Size(1000, 1000);
            this.BackColor = Color.Transparent;
            this.Enabled = false;
            this.joinType = jt;

            this.join = new JoinEntity(jt, null, null);
        }

        public void SetMainTable(TableControl te)
        {
            mainTable = te;
            join.SetMainTable(te.GetTableEntity());
            join.AddJoinPair(new ColumnPairEntity(te.GetTableEntity(), null, null, null));

            lastMainX = te.Bounds.X + te.Width/2;
            lastMainY = te.Bounds.Y + te.Height/2;
        }

        public void SetChildTable(TableControl te)
        {
            childTable = te;
            join.SetChildTable(te.GetTableEntity());
            ColumnPairEntity columnPair = join.IsMainJoin(mainTable.GetTableEntity().GetName());
            columnPair.SetChildTable(te.GetTableEntity());

            lastChildX = te.Bounds.X + te.Width / 2;
            lastChildY = te.Bounds.Y + te.Height / 2;
        }

        public TableControl GetMainTable()
        {
            return mainTable;
        }

        public TableControl GetChildTable()
        {
            return childTable;
        }

        private bool IsObjectMoved(TableControl mainTable, TableControl childTable, int thresholdX, int thresholdY)
        {
            if (lastMainX != mainTable.Bounds.X || lastMainY != mainTable.Bounds.Y || lastChildX != childTable.Bounds.X || lastChildY != childTable.Bounds.Y)
            {
                int delta = 0;

                delta = lastMainX - mainTable.Bounds.X;
                if (Math.Abs(delta) > thresholdX) { lastMainX = mainTable.Bounds.X;  return true; };

                delta = lastMainY - mainTable.Bounds.Y;
                if (Math.Abs(delta) > thresholdY) { lastMainY = mainTable.Bounds.Y;  return true; };

                delta = lastChildX - childTable.Bounds.X;
                if (Math.Abs(delta) > thresholdX) { lastChildX = childTable.Bounds.X;  return true; };

                delta = lastChildY - childTable.Bounds.Y;
                if (Math.Abs(delta) > thresholdY) { lastChildY = childTable.Bounds.Y;  return true; };

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

            if (mainTable != null && childTable != null && IsObjectMoved(mainTable, childTable, thresholdX, thresholdY))
            {
                Parent.Invalidate(this.Bounds, true);
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, this.BackColor)), bounds);
            }
            else {

                Pen pen;

                switch (joinType)
                {
                    case Enums.JoinType.Left:
                        {
                            pen = new Pen(Color.LightBlue, 2);
                            pen.DashStyle = DashStyle.Dash;
                            break;
                        }
                    case Enums.JoinType.Right:
                        {
                            pen = new Pen(Color.LightGreen, 2);
                            pen.DashStyle = DashStyle.Dash;
                            break;
                        }
                    case Enums.JoinType.Inner:
                        {
                            pen = new Pen(Color.Red, 2);
                            pen.DashStyle = DashStyle.Dot;
                            break;
                        }
                    case Enums.JoinType.Full:
                        {
                            pen = new Pen(Color.Black, 2);
                            pen.DashStyle = DashStyle.Solid;
                            break;
                        }
                    default:
                        {
                            pen = new Pen(Color.Black, 2);
                            break;
                        }

                }

                AdjustableArrowCap bigArrow = new AdjustableArrowCap(7, 7);
                pen.CustomEndCap = bigArrow;

                int startX, startY, finalX, finalY, halfX, halfY;

                startX = mainTable.Bounds.X + mainTable.Width / 2;
                startY = mainTable.Bounds.Y + mainTable.Height / 2;
                finalX = childTable.Bounds.X + childTable.Width / 2;
                finalY = childTable.Bounds.Y + childTable.Height / 2;
                halfX = (finalX + startX) / 2;
                halfY = (finalY + startY) / 2;

                g.DrawLine(pen, startX, startY, halfX, halfY);
                bigArrow = new AdjustableArrowCap(1, 1);
                pen.CustomEndCap = bigArrow;
                g.DrawLine(pen, halfX, halfY, finalX, finalY);

                pen.Dispose();
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
            //base.OnBackColorChanged(e);
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            this.Invalidate();
            //base.OnParentBackColorChanged(e);
        }

        public JoinEntity GetJoinEntity()
        {
            return this.join;
        }

    }
}
