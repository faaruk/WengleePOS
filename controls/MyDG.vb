#Const VERSION = "1.0.0"
#Const DevelopedBy = "Bidyut Das"
#Const LastEditedDate = "15th September, 2014 10.45 AM"
'***************************
'This is a Property of Bidyut Das
'To use it your code, obtain proper copyright from the developer/coder.
'
'Thanks for using by Code.
'Bidyut Das || Email : das.bidyut12345@gmail.com || Skype : bidyut12345
'***************************


Imports System.Data.SerializationFormat

Public Class MyDG
    Inherits DataGridView
    Dim MyFileName As String = ""
    Dim Isloaded As Boolean = False

    Dim _RememberColumnWidths As Boolean = True
    Public Property RememberColumnWidths As Boolean
        Get
            Return _RememberColumnWidths
        End Get
        Set(value As Boolean)
            _RememberColumnWidths = value
        End Set
    End Property

    Dim _RememberSortedColumn As Boolean = True
    Public Property RememberSortedColumn As Boolean
        Get
            Return _RememberSortedColumn
        End Get
        Set(value As Boolean)
            _RememberSortedColumn = value
        End Set
    End Property


    Dim _RememberColumnDisplayedIndex As Boolean = True
    Public Property RememberColumnDisplayedIndex As Boolean
        Get
            Return _RememberColumnDisplayedIndex
        End Get
        Set(value As Boolean)
            _RememberColumnDisplayedIndex = value
        End Set
    End Property

    Dim _RememberVisibleColumns As Boolean = True
    Public Property RememberVisibleColumns As Boolean
        Get
            Return _RememberVisibleColumns
        End Get
        Set(value As Boolean)
            _RememberVisibleColumns = value
        End Set
    End Property

    <Serializable()> _
    Structure ValuesToBeSaved
        Dim SortedColumnIndex As Integer
        Dim VisibleColumns As List(Of Integer)
        'Dim InvisibleColumns As List(Of Integer)
        Dim ColumnsWidth As Generic.Dictionary(Of Integer, Integer)
        Dim ColumnsDisplayedIndex As Generic.Dictionary(Of Integer, Integer)
        ''' <summary>
        ''' Creates a new instance of the Structure
        ''' </summary>
        ''' <param name="_SortedColumnIndex">Index of the Column that is being used to sort the DatagridView</param>
        ''' <param name="_VisibleColumns">List of Visible columns indices</param>
        ''' <param name="_ColumnsWidth">List of Columns Indices and their respective widths</param>
        ''' <param name="_ColumnsDisplayedIndex">List of Columns Indices and their respective DisplayedIndex</param>
        ''' <remarks></remarks>
        Sub New(_SortedColumnIndex As Integer, _VisibleColumns As List(Of Integer), _ColumnsWidth As Generic.Dictionary(Of Integer, Integer), _ColumnsDisplayedIndex As Generic.Dictionary(Of Integer, Integer))
            SortedColumnIndex = _SortedColumnIndex
            VisibleColumns = _VisibleColumns
            'InvisibleColumns = _InvisibleColumns  '_InvisibleColumns As List(Of Integer),
            ColumnsWidth = _ColumnsWidth
            ColumnsDisplayedIndex = _ColumnsDisplayedIndex
        End Sub
        Sub Reset()
            SortedColumnIndex = -1
            VisibleColumns = New List(Of Integer)
            'InvisibleColumns = New List(Of Integer)
            ColumnsWidth = New Generic.Dictionary(Of Integer, Integer)
            ColumnsDisplayedIndex = New Generic.Dictionary(Of Integer, Integer)
        End Sub
    End Structure

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        MyFileName = My.Computer.FileSystem.CombinePath(My.Application.Info.DirectoryPath, My.Application.Info.AssemblyName & "_" & Me.FindForm.Name & "_" & Me.Name & ".dgValues")
        ' Add any initialization after the InitializeComponent() call.
        'Dim ColumnsWidth As New Generic.Dictionary(Of Integer, Integer)
        'ColumnsWidth.Add(0, 340)
    End Sub
    Private Sub MyDG_ColumnAdded(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnAdded
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_ColumnDisplayIndexChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnDisplayIndexChanged
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_ColumnNameChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnNameChanged
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_ColumnRemoved(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnRemoved
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_ColumnSortModeChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnSortModeChanged
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_ColumnWidthChanged(sender As Object, e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles Me.ColumnWidthChanged
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_DataBindingComplete(sender As Object, e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles Me.DataBindingComplete
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub MyDG_Sorted(sender As Object, e As System.EventArgs) Handles Me.Sorted
        If Not Isloaded Then
            TimerLoad.Start()
        Else
            TimerSave.Start()
        End If
    End Sub

    Private Sub TimerSave_Tick(sender As System.Object, e As System.EventArgs) Handles TimerSave.Tick
        Save()
        TimerSave.Stop()
    End Sub

    Private Sub TimerLoad_Tick(sender As System.Object, e As System.EventArgs) Handles TimerLoad.Tick
        Load()
        TimerLoad.Stop()
    End Sub

    Sub Load()
        If MyFileName <> "" Then
            If My.Computer.FileSystem.FileExists(MyFileName) Then






                Isloaded = True
            Else
                Save()
            End If
        End If
    End Sub

    Sub Save()
        If MyFileName <> "" Then
            Dim obj As New ValuesToBeSaved
            'Save the Visible Columns
            Dim NewListOfVisibleColumns As New List(Of Integer)
            Dim NewListOfColumnWidth As New Dictionary(Of Integer, Integer)
            Dim NewListOfColumnDisplayedIndex As New Dictionary(Of Integer, Integer)

            For Each dc As DataGridViewColumn In Me.Columns
                Try
                    If dc.Visible Then
                        NewListOfVisibleColumns.Add(dc.Index)
                    End If
                Catch ex As Exception
                End Try
                Try
                    NewListOfColumnWidth.Add(dc.Index, dc.Width)
                Catch ex As Exception
                End Try
                Try
                    NewListOfColumnWidth.Add(dc.Index, dc.DisplayIndex)
                Catch ex As Exception
                End Try
            Next
            obj.SortedColumnIndex = Me.SortedColumn.Index
            obj.ColumnsWidth = NewListOfColumnWidth
            obj.ColumnsDisplayedIndex = NewListOfColumnDisplayedIndex

        End If
    End Sub
End Class
