using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.Utils;
using DevExpress.XtraEditors.Drawing;
using DevExpress.Utils.Drawing;

namespace GridFilterButton
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
            this.carsTableAdapter.Fill(this.carsDBDataSet.Cars);
            foreach (GridColumn column in gridView1.Columns)
                column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
        }

        private void gridView1_CustomDrawColumnHeader(object sender, DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs e)
        {
            GridFilterButtonInfoArgs args = null;
            foreach (DrawElementInfo deInfo in e.Info.InnerElements)
                if (deInfo.ElementInfo.GetType() == typeof(GridFilterButtonInfoArgs))
                {
                    args = (GridFilterButtonInfoArgs)deInfo.ElementInfo;
                    break;
                }
            if (null == args) return;
            int x = e.Bounds.X + 5;
            int y = e.Bounds.Y + e.Bounds.Height / 2 - args.Bounds.Height / 2;
            args.Bounds = new Rectangle(new Point(x, y), args.Bounds.Size);
        }
    }
}