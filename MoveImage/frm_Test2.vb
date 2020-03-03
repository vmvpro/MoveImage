Imports System.Data
Public Class frm_Test2

    Private Sub frm_Test2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = Date.Now
        Debug.WriteLine(DateTimePicker1.Value.Year.ToString())

        cbx_GroupDoc.ValueMember = "Text"

		loadDataGrid_Sectors(DataGridView2)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim s As String = ""
        s = DateTimePicker1.Value.ToShortDateString

        TextBox1.Text = s
    End Sub


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        'nonNumberEntered = False

        'e.SuppressKeyPress = True
        '' Пропускаем цифровые кнопки
        'If (e.KeyCode >= Keys.D0) And (e.KeyCode <= Keys.D9) Then e.SuppressKeyPress = False
        '' Пропускаем цифровые кнопки с NumPad'а
        'If (e.KeyCode >= Keys.NumPad0) And (e.KeyCode <= Keys.NumPad9) Then e.SuppressKeyPress = False
        '' Пропускаем Delete, Back, Left и Right
        'If (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back) Or (e.KeyCode = Keys.Left) Or (e.KeyCode = Keys.Right) Or (e.KeyCode = Keys.Subtract) Or (e.KeyCode = 189) Then e.SuppressKeyPress = False

		MessageBox.Show(e.KeyCode.ToString())

        'If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
        '	If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
        '		If e.KeyCode <> Keys.Back Then
        '			e.Handled = False
        '			'nonNumberEntered = True
        '		End If
        '	End If
        'End If

        'If Control.ModifierKeys = Keys.Shift Then
        '	'nonNumberEntered = True
        'End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        WorkSaveDataBase()
    End Sub

    Dim label1 As New Label
    Dim label2 As New Label

    Dim txt1 As New TextBox
    Dim txt2 As New TextBox


    Dim ctl1() As Control = New Control() {label1, txt1}
    Dim ctl2() As Control = New Control() {label2, txt2}

    Dim ss()() As Control
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'sSingle = New Control()() {s02_Num, s08_Pi, s10_Years, s03_Cherteg, s06_Prim}
        'Protected s02_Num() As Control
        's02_Num = New Control() {label2_Num, field2_Num}

        init()
    End Sub
    Sub init()
        Dim str1 As String
        Dim str2 As String
        Dim str3 As String
        Dim str4 As String


        label1.Name = "lbl1"
        label2.Name = "lbl2"

        txt1.Name = "txt1"
        txt1.Text = "1"

        txt2.Name = "txt2"
        txt2.Text = "2"

        Dim ss()() As Control = New Control()() {ctl1, ctl2}
        str1 = ss(0)(0).Name    'lbl1'
        str2 = ss(0)(1).Name    'txt1'
        str3 = ss(1)(0).Name    'lbl2'
        str4 = ss(1)(1).Name    'txt2'

        Dim ii As String

        For i As Integer = 0 To ss.Length - 1
            str1 = ss(i)(1).Name
            ii = ss(i)(1).Text
        Next

    End Sub
    Sub ddd(sSingle As Control()())

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        loadDataGridView(DataGridView1)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        checkList(DataGridView1)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        checkCount(DataGridView1)
    End Sub

    

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim dt As New DataTable
        dt = LoadDataGridView_Sectors()
        DataGridView2.DataSource = dt

    End Sub

	


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        MessageBox.Show(DataGridView2.Columns(0).Width.ToString() + vbNewLine + _
                        DataGridView2.Columns(1).Width.ToString() + vbNewLine + _
                        DataGridView2.Columns(2).Width.ToString() + vbNewLine)
        'DataGridView1.Columns(3).Width.ToString(+vbNewLine + _
        '            DataGridView1.Columns(4).Width.ToString())

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        WorkSaveDataBase_RegisterDoc_Test(DataGridView2, TextBox2.Text)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim listChecked As List(Of DataRow) = DataGridView2.DataTable().CheckedRows("Выбор")
        Dim listSectors As New List(Of String)

        If (listChecked.Count() > 0) Then
            Dim sb As System.Text.StringBuilder = New System.Text.StringBuilder()
            For Each row As DataRow In listChecked
                listSectors.Add(row.Field(Of String)("Участок"))
                sb.AppendLine(row.Field(Of String)("Участок"))
            Next
            MessageBox.Show(sb.ToString())
        Else
            MessageBox.Show("No rooms checked")
		End If

	End Sub

	Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        loadRZ(cbo_id_doc_zapros, "Служебная записка РЗ")
	End Sub

	

	Private Sub cbo_id_doc_zapros_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbo_id_doc_zapros.Validating
		MsgBox("проверка")
	End Sub

	Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
		
		

	End Sub

	Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
		loadRZ(ComboBox2, "Служебная записка РЗ")
	End Sub

	Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

        SearchRZBackgroundWorker(ComboBox2)
	End Sub

    Function SearchRZBackgroundWorker(ComboBox2 As ComboBox) As Boolean
        Try
            Dim readerDB As OleDb.OleDbDataReader
            'Dim rzText As String = ComboBox2.Text
            ComboBox2.Tag = ComboBox2.Text

			If Len(ComboBox2.Text) = 0 Then
				Return True
				Exit Function
			End If

            Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
                {
                    .Provider = "Microsoft.ACE.OLEDB.12.0",
                    .DataSource = IO.Path.Combine(Application.StartupPath, "MoveImageDB.accdb")
                }

            Dim dt As New DataTable
            Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = BuilderAccdb.ConnectionString
                }

                Using cmd As New OleDb.OleDbCommand With
                    {
                        .Connection = cn,
                        .CommandText = "SELECT * FROM Register_Doc_ Where type = 'Служебная записка РЗ' and num_doc = '" & ComboBox2.Text & "'"
                    }

                    cn.Open()

                    readerDB = cmd.ExecuteReader()

                    If readerDB.HasRows Then
                        Do While readerDB.Read
                            MessageBox.Show(readerDB(0).ToString)
                        Loop

                    Else
                        Dim result As DialogResult
                        result = MessageBox.Show("Запись не найдена", "Сообщение", MessageBoxButtons.YesNo)
                        If result = DialogResult.Yes Then
                            ProgressBar1.Visible = True

                            'BackgroundWorker1.RunWorkerAsync(ComboBox2)

                            BackgroundWorker1.RunWorkerAsync(ComboBox2.Text)

                            'id_RZ_RegisterDoc(ComboBox2.Text)




                            'loadRZ(ComboBox2, "Служебная записка РЗ")
                            'ComboBox2.Text = rzText

                        End If
                    End If

                End Using
            End Using

            Return True
        Catch ex As Exception
            MessageBox.Show("Запись не найдена Ошибка")
            Return False
        End Try
    End Function

	Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

		Dim str As String
		str = e.Argument

		'Dim cbo As ComboBox
		'Dim cbo2 As Object
		'cbo2 = ComboBox2

		'cbo = cbo2

        id_RZ_RegisterDoc(str)

		'loadRZ(ComboBox2, "Служебная записка РЗ")
		'ComboBox2.Text = rzText
	End Sub

	Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
		loadRZ(ComboBox2, "Служебная записка РЗ")
		ProgressBar1.Visible = False
		ComboBox2.Text = ComboBox2.Tag
	End Sub

	Dim vvv As Integer = 0
	Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
		'If vvv > 0 Then
		'	Label3.Text = ComboBox2.SelectedValue.ToString
		'Else
		'	vvv += 1
		'End If
	End Sub

	Private Sub ComboBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles ComboBox2.MouseClick

	End Sub

	Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
		

	End Sub
End Class