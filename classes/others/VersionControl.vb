Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

Public Class VersionControl

    Public Sub VersionCheck()

        'Dim aaa As String = String.Join("a", "b")

        Dim updateToVersion As Integer = 0
        Dim version As String = System.Windows.Forms.Application.ProductVersion
        Dim VersionNumber As Integer = Int32.Parse(version.Replace(".", ""))

        'if (VersionNumber == 1000)
        If VersionNumber = 2003 Then
            updateToVersion = 2003
            Version2003(updateToVersion)
        End If

        Dim ExisitingVersion As Integer
        ExisitingVersion = CheckExistingVersion()
        If VersionNumber > ExisitingVersion Then
            updateToVersion = 2004
            If ((updateToVersion > ExisitingVersion) And (VersionNumber > ExisitingVersion)) Then
                Version2004(updateToVersion)
            End If
            ExisitingVersion = updateToVersion
            updateToVersion = 2005
            If ((updateToVersion > ExisitingVersion) And (VersionNumber > ExisitingVersion)) Then
                Version2005(updateToVersion)
            End If
            ExisitingVersion = updateToVersion
            updateToVersion = 2006
            If ((updateToVersion > ExisitingVersion) And (VersionNumber > ExisitingVersion)) Then
                Version2006(updateToVersion)
            End If
        End If
    End Sub
    Private Sub Version2003(ByVal version As Integer)

        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()

        Dim strSQL As String = " "
        strSQL += " if object_id('app_version') is null"
        strSQL += " begin"
        strSQL += " create table [dbo].[app_version]"
        strSQL += "     ("
        strSQL += " [versionautoid] [int] identity(1,1) not null primary key,"
        strSQL += " [versionnumber] [int] null,"
        strSQL += " [insertdate] [datetime] null default getdate()"
        strSQL += " );"
        strSQL += " insert into app_version(versionnumber) values (2003);"
        strSQL += " End"

        Try
            Dim com As New SqlCommand(strSQL, con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try

        strSQL = " ALTER FUNCTION [dbo].[fn_GetQtyByOrderByOtherProduct](@OrderId int)"
        strSQL += " RETURNS(varchar(max))"
        strSQL += " AS"
        strSQL += " BEGIN"
        strSQL += " DECLARE @MyOutput varchar(max);"
        strSQL += " declare @attday numeric(12,2);"
        strSQL += " set @attday=0;"
        strSQL += " set @MyOutput =0;"
        strSQL += " set @MyOutput=(select (stuff("
        strSQL += " ("
        strSQL += " SELECT "
        strSQL += " CASE "
        strSQL += " WHEN isnull(IOI.Fresh,0)>0 and isnull(IOI.Frozen,0)>0 THEN "
        strSQL += " ', '+ IOP.ProductName + ': ' + convert(varchar(10),[Fresh]) +'-fsh, ' + convert(varchar(10),[Frozen]) +'-fzn'"
        strSQL += " WHEN isnull(IOI.Fresh,0)>0 THEN "
        strSQL += " ', '+ IOP.ProductName + ': '+ convert(varchar(10),[Qty]) +'-fsh'"
        strSQL += " WHEN isnull(IOI.Frozen,0)>0 THEN"
        strSQL += " ', '+ IOP.ProductName + ': '+ convert(varchar(10),[Frozen]) +'-fzn' END"
        strSQL += " from tblOrderItems IOI "
        strSQL += " inner join tblProducts IOP on IOP.ProductId=IOI.ProductId"
        strSQL += " where IOI.OrderId=@OrderId and IOP.ProductId not in (select IP.ProductId from tblProducts IP where IP.ProductId>=1 and ProductId<=12) FOR XML PATH('')"
        strSQL += " ),1,1,'') ))"
        strSQL += " RETURN @MyOutput"
        strSQL += " End"

        Try
            Dim com As New SqlCommand(strSQL, con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try

        objCon.Dispose()

    End Sub
    Private Sub Version2004(ByVal version As Integer)

        UpdateVersion(version)
    End Sub
    Private Sub Version2005(ByVal version As Integer)
        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()

        Dim strSQL As String = " "
        strSQL = "alter table tblOrder add InvoiceNumber varchar(50), TotalCartons decimal(15,4) ; "

        Try
            Dim com As New SqlCommand(strSQL, con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try

        objCon.Dispose()
        UpdateVersion(version)
    End Sub
    Private Sub Version2006(ByVal version As Integer)
        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()

        Dim strSQL As String = " "
        strSQL = "alter table tblTask add AssignTo int"

        Try
            Dim com As New SqlCommand(strSQL, con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try

        objCon.Dispose()
        UpdateVersion(version)
    End Sub
    Private Function CheckExistingVersion() As Integer

        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()
        Dim version As Integer = 0
        Try
            Dim com As New SqlCommand("select isnull(max(VersionNumber),0) VersionNumber from App_Version", con)
            version = com.ExecuteScalar
        Catch ex As Exception
        End Try
        objCon.Dispose()
        'string strSQL = @" select isnull(max(VersionNumber),0) VersionNumber from App_Version";
        'SqlConnection con = new SqlConnection(conString);
        'con.Open();
        'SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
        'DataSet ds = new DataSet();
        'adpt.Fill(ds);
        'adpt.Dispose();
        'con.Close();
        'con.Dispose();
        'return Int32.Parse(ds.Tables[0].Rows[0]["VersionNumber"].ToString());
        Return version
    End Function

    Private Sub UpdateVersion(ByVal version As Integer)

        Dim objCon As New clsConnection
        Dim con As SqlConnection = Nothing
        con = objCon.connect()

        Try
            Dim strSQL As String
            strSQL = "update App_Version set VersionNumber=" + version.ToString() + " "
            Dim com As New SqlCommand(strSQL, con)
            com.ExecuteScalar()
        Catch ex As Exception
        End Try
        objCon.Dispose()

        '    Dim strSQL as String= @"update App_Version set VersionNumber=" + version + " ";
        'SqlConnection(con = New SqlConnection(conString))
        '    con.Open();
        '    SqlDataAdapter adpt = new SqlDataAdapter(strSQL, con);
        '    object objResult = null;

        '    SqlCommand dbCommand = adpt.SelectCommand;
        '    dbCommand.CommandText = strSQL;
        '    dbCommand.CommandType = CommandType.Text;

        '    objResult = dbCommand.ExecuteScalar();
    End Sub
End Class
