Imports System.Data.OleDb

Public Class DBUtils
    Public ConnectionString As String
    Public QueryString As String
    Public cpnm

    Public Function GetDataTable() As DataTable
        Dim conn As New OleDb.OleDbConnection(ConnectionString)
        Dim da As New OleDbDataAdapter(QueryString, conn)
        Dim dt As New DataTable

        conn.Open()
        da.Fill(dt)

        conn.Close()
        da.Dispose()

        Return dt
    End Function

    Public Sub ExecuteNonQuery()
        Dim conn As New OleDb.OleDbConnection(ConnectionString)
        conn.Open()
        Dim cmd As New OleDbCommand(QueryString, conn)
        cmd.ExecuteNonQuery()
        conn.Close()
    End Sub


End Class
