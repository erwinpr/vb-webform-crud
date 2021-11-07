Imports System.Data.OleDb


Public Class index
    Inherits System.Web.UI.Page

    'global vars
    Public conn As New OleDb.OleDbConnection("Provider=MSOLEDBSQL;Server=localhost;Database=SECURITY;UID=sa;PWD=P@ssw0rd;")
    Public du As New DBUtils
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        du.ConnectionString = "Provider=MSOLEDBSQL;Server=localhost;Database=TEST;UID=sa;PWD=P@ssw0rd;"
        FillDGR()
    End Sub

    Protected Sub FillDGR()

        'Dim dt As New DataTable
        'Dim QueryString = "select * from M_USERS"
        'Dim da As New OleDbDataAdapter(QueryString, conn)

        'conn.Open()
        'da.Fill(dt)
        'DGR_USERS.DataSource = dt
        'DGR_USERS.DataBind()

        'conn.Close()
        'da.Dispose()

        du.QueryString = "select * from PRODUCT"
        DGR_USERS.DataSource = du.GetDataTable()
        DGR_USERS.DataBind()

        For i As Integer = 0 To DGR_USERS.Items.Count - 1
            Dim lb As LinkButton = DGR_USERS.Items(i).FindControl("LB_PRODUCT_CD")
            lb.Text = DGR_USERS.Items(i).Cells(1).Text
        Next

    End Sub

    Protected Sub DGR_USERS_PageIndexChanged(source As Object, e As DataGridPageChangedEventArgs)
        DGR_USERS.CurrentPageIndex = e.NewPageIndex
        FillDGR()
    End Sub

    Protected Sub BT_SAVE_Click(sender As Object, e As EventArgs)
        du.QueryString = "exec SP_PRODUCT_UPSERT '" + TXT_CD.Text + "','" + TXT_NAME.Text + "','LOAN'"
        du.ExecuteNonQuery()
        FillDGR()
    End Sub

    Protected Sub DGR_USERS_ItemCommand(source As Object, e As DataGridCommandEventArgs)
        If e.CommandName = "Edit" Then
            TXT_CD.Text = e.Item.Cells(1).Text
            TXT_NAME.Text = e.Item.Cells(2).Text
        End If
    End Sub
End Class