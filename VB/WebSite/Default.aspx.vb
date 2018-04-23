Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls
Imports System.Text
Imports System.Collections.Generic

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Private Function GetData() As DataTable
		Dim table As DataTable
		If Session("table") Is Nothing Then
			table = New DataTable()

			Dim column As DataColumn = table.Columns.Add("id", GetType(Int32))
			table.Columns.Add("parent_id", GetType(Int32))
			table.Columns.Add("text", GetType(String))
			table.PrimaryKey = New DataColumn() { column }

			Dim key As Int32 = 0
			For i As Int32 = 0 To 9
				table.Rows.Add(New Object() { key, Nothing, String.Format("Test{0}", key) })
				Dim parent As Int32 = key
				For j As Int32 = 0 To 19
					key += 1
					table.Rows.Add(New Object() { key, parent, String.Format("Test{0}", key) })
				Next j
				key += 1
			Next i

			Session("table") = table
		Else
			table = CType(Session("table"), DataTable)
		End If

		Return table
	End Function

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		tree.DataSource = GetData()
		tree.DataBind()
	End Sub

	Private keys As List(Of Int32) = New List(Of Int32)()
	Private deleted As Boolean = False

	Protected Sub tree_NodeDeleting(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletingEventArgs)
		keys.Add(Convert.ToInt32(e.Keys(0)))
	End Sub

	Protected Sub tree_NodeDeleted(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataDeletedEventArgs)
		e.ExceptionHandled = True
		deleted = True
	End Sub

	Protected Sub tree_DataBinding(ByVal sender As Object, ByVal e As EventArgs)
		If deleted Then
			Dim table As DataTable = GetData()

			For Each key As Int32 In keys
				table.Rows.Remove(table.Rows.Find(key))
			Next key

			Session("table") = table

			tree.DataSource = table
		End If
	End Sub

	Protected Sub tree_CustomJSProperties(ByVal sender As Object, ByVal e As DevExpress.Web.ASPxTreeList.TreeListCustomJSPropertiesEventArgs)
		If deleted Then
            Dim a() As Int32 = keys.ToArray()
            Dim strArray() As String = Array.ConvertAll(a, New Converter(Of Int32, String)(AddressOf Convert.ToString))
			e.Properties("cpKeys") = String.Join(", ", strArray)
		End If
	End Sub
End Class
