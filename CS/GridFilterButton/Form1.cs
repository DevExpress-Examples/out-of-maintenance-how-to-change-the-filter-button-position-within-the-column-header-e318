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

        DataTable CreateTable()
        {
            DataTable table = new DataTable();
            DataRow dataRow;

            table.Columns.Add("Prod_NO", typeof(string));
            table.Columns.Add("Prod_Name", typeof(string));
            table.Columns.Add("Order_Date", typeof(string));
            table.Columns.Add("Quantity", typeof(string));

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "101";
            dataRow["Prod_Name"] = "Product1";
            dataRow["Order_Date"] = "12/06/2012";
            dataRow["Quantity"] = "50";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "102";
            dataRow["Prod_Name"] = "Product2";
            dataRow["Order_Date"] = "15/06/2012";
            dataRow["Quantity"] = "70";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "102";
            dataRow["Prod_Name"] = "Product2";
            dataRow["Order_Date"] = "15/06/2012";
            dataRow["Quantity"] = "70";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "103";
            dataRow["Prod_Name"] = "Product3";
            dataRow["Order_Date"] = "18/06/2012";
            dataRow["Quantity"] = "30";
            table.Rows.Add(dataRow);

            dataRow = table.NewRow();
            dataRow["Prod_NO"] = "104";
            dataRow["Prod_Name"] = "Product4";
            dataRow["Order_Date"] = "25/06/2012";
            dataRow["Quantity"] = "20";
            table.Rows.Add(dataRow);

            return table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = CreateTable();
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