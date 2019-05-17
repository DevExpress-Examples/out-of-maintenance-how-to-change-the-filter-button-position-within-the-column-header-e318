Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils
Imports DevExpress.XtraEditors.Drawing
Imports DevExpress.Utils.Drawing

Namespace GridFilterButton
	Partial Public Class Form1
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Function CreateTable() As DataTable
			Dim table As New DataTable()
			Dim dataRow As DataRow

			table.Columns.Add("Prod_NO", GetType(String))
			table.Columns.Add("Prod_Name", GetType(String))
			table.Columns.Add("Order_Date", GetType(String))
			table.Columns.Add("Quantity", GetType(String))

			dataRow = table.NewRow()
			dataRow("Prod_NO") = "101"
			dataRow("Prod_Name") = "Product1"
			dataRow("Order_Date") = "12/06/2012"
			dataRow("Quantity") = "50"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("Prod_NO") = "102"
			dataRow("Prod_Name") = "Product2"
			dataRow("Order_Date") = "15/06/2012"
			dataRow("Quantity") = "70"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("Prod_NO") = "102"
			dataRow("Prod_Name") = "Product2"
			dataRow("Order_Date") = "15/06/2012"
			dataRow("Quantity") = "70"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("Prod_NO") = "103"
			dataRow("Prod_Name") = "Product3"
			dataRow("Order_Date") = "18/06/2012"
			dataRow("Quantity") = "30"
			table.Rows.Add(dataRow)

			dataRow = table.NewRow()
			dataRow("Prod_NO") = "104"
			dataRow("Prod_Name") = "Product4"
			dataRow("Order_Date") = "25/06/2012"
			dataRow("Quantity") = "20"
			table.Rows.Add(dataRow)

			Return table
		End Function

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			gridControl1.DataSource = CreateTable()
			For Each column As GridColumn In gridView1.Columns
				column.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center
			Next column
		End Sub

		Private Sub gridView1_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles gridView1.CustomDrawColumnHeader
			Dim args As GridFilterButtonInfoArgs = Nothing
			For Each deInfo As DrawElementInfo In e.Info.InnerElements
				If deInfo.ElementInfo.GetType() Is GetType(GridFilterButtonInfoArgs) Then
					args = CType(deInfo.ElementInfo, GridFilterButtonInfoArgs)
					Exit For
				End If
			Next deInfo
			If Nothing Is args Then
				Return
			End If
			Dim x As Integer = e.Bounds.X + 5
			Dim y As Integer = e.Bounds.Y + e.Bounds.Height \ 2 - args.Bounds.Height \ 2
			args.Bounds = New Rectangle(New Point(x, y), args.Bounds.Size)
		End Sub
	End Class
End Namespace