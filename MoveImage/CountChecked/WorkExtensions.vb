'Imports CountChecked
Imports MoveImage.Extensions

Module WorkExtensions

	Public Sub loadDataGridView(dataGridView1 As DataGridView)
		dataGridView1.AllowUserToAddRows = False
		dataGridView1.DataSource = GetMockedData()
		dataGridView1.Columns("Rate").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
	End Sub

	Public Function GetMockedData() As DataTable
		Dim dt As DataTable = New DataTable()
		dt.Columns.Add("Identifier", GetType(Integer))
		dt.Columns.Add("Room", GetType(String))
		dt.Columns.Add("RoomType", GetType(String))
		dt.Columns.Add("Rate", GetType(Decimal))

		'// data mock up coming from a database table
		dt.Rows.Add(10, "201A", "Suite", 98.99)
		dt.Rows.Add(20, "101A", "Suite", 120.99)
		dt.Rows.Add(30, "201B", "Suite", 99.99)

		dt.Columns.Add("Available", GetType(Boolean))

		dt.Columns("Available").SetOrdinal(0)

		dt.Columns("Identifier").ColumnMapping = MappingType.Hidden

		For Each row As DataRow In dt.Rows
			row.SetField(Of Boolean)("Available", False)
		Next

		Return dt
	End Function

    Sub checkList(dataGridView1 As DataGridView)

        Dim listChecked As List(Of DataRow) = dataGridView1.DataTable().CheckedRows("Available")

        If (listChecked.Count() > 0) Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            For Each row As DataRow In listChecked
                sb.AppendLine(row.Field(Of String)("Room"))
            Next
            MessageBox.Show(sb.ToString())
        Else
            MessageBox.Show("No rooms checked")
        End If

    End Sub

    Sub checkCount(dataGridView1 As DataGridView)
        Dim checkRowCount As Integer = dataGridView1.DataTable().CheckedRowCount("Available")
        If (checkRowCount > 0) Then
            MessageBox.Show("Rooms checked count: " + checkRowCount.ToString())
        Else

            MessageBox.Show("No rooms checked")

        End If
    End Sub
End Module
