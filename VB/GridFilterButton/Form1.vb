Imports Microsoft.VisualBasic
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

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' TODO: This line of code loads data into the 'carsDBDataSet.Cars' table. You can move, or remove it, as needed.
			Me.carsTableAdapter.Fill(Me.carsDBDataSet.Cars)
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
			Dim y As Integer = e.Bounds.Y + e.Bounds.Height / 2 - args.Bounds.Height / 2
			args.Bounds = New Rectangle(New Point(x, y), args.Bounds.Size)
		End Sub
	End Class
End Namespace