Imports System.Runtime.CompilerServices




Module Extensions

    Interface IExtension
        Overloads Function Value() As Object

    End Interface

    <Extension> _
    Public Function DataTable(sender As DataGridView) As DataTable
        ' public static DataTable DataTable(this DataGridView sender) {	return (DataTable)sender.DataSource;		}
        Return DirectCast(sender.DataSource, DataTable)
    End Function

    <Extension> _
    Public Function CheckedRows(sender As DataTable, ColumnName As String) As List(Of DataRow)
        ' public static List<DataRow> CheckedRows(this DataTable sender, string ColumnName)
        ' {	return (from T in sender.AsEnumerable() where T.Field<bool>(ColumnName) == true select T).ToList();		}

        Return (From T In sender.AsEnumerable() Where T.Field(Of Boolean)(ColumnName) = True).ToList()
    End Function

    <Extension> _
    Public Function CheckedRowCount(sender As DataTable, ColumnName As String) As Integer
        ' public static int CheckedRowCount(this DataTable sender, string ColumnName)
        ' {	return sender.AsEnumerable().Where(row => row.Field<bool>(ColumnName) == true).Select(row => row).Count();		}

        Return sender.AsEnumerable().Where(Function(row) row.Field(Of Boolean)(ColumnName) = True).[Select](Function(row) row).Count()
    End Function

    <Extension> _
    Public Function Value(sender As Control) As Object

        If TypeOf sender Is ComboBox Then
            Dim cbo As ComboBox = DirectCast(sender, ComboBox)
            If Not cbo.SelectedValue Is Nothing Then
                Return cbo.SelectedValue
            Else
                Return cbo.Text
            End If
        End If

        If TypeOf sender Is TextBox Then
            Dim txt As TextBox = DirectCast(sender, TextBox)
            If Not txt Is Nothing Then
                Return txt.Text
            End If
        End If

        If TypeOf sender Is DateTimePicker Then
            Dim dtp As DateTimePicker = DirectCast(sender, DateTimePicker)
            If Not dtp Is Nothing Then
                Return dtp.Value.ToShortDateString
            End If
        End If

        Return Nothing
    End Function

End Module
