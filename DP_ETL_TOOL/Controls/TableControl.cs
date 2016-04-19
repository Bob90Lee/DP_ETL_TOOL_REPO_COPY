﻿using System;
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


        public TableControl()
        {
        }

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

        

    }
}
