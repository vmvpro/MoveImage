Public Class frm_Test3
	'Private pathDirectory = "d:\Doc\Work\Работа\База данных\TestBD\"
	Private pathDirectory = "d:\Vetal\Access\TestBD\"

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		'SaveMoveImageDB(DataGridView2)
	End Sub

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		'SaveMoveImageDB_SKN()
	End Sub

	'pathDirectory = Environment.CurrentDirectory & "\"

	Private Sub frm_Test3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		loadDataGrid_Sectors(DataGridView2)
        loadRZ(pathDirectory, cbo_id_rz_register_doc, "Служебная записка РЗ")
        load_Izd(pathDirectory, cbo_izd)
		load_AntonovDep_(pathDirectory, cbo_AntonovDep)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim dbe As Object = Nothing

        Dim db1 As Object
        Dim db2 As Object

        Dim ref_doc As Integer

        Try
			IO.Path.Combine(pathDirectory, "ServerDBNew.accdb")

            dbe = CreateObject("DAO.DbEngine.120")

            dbe.BeginTrans()

            'db1 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "MoveImageDB.accdb")
			db1 = dbe.Workspaces(0).OpenDatabase(IO.Path.Combine(pathDirectory, "ServerDBNew.accdb"))

            'db2 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "MoveImageDB _SKN.accdb")
			db2 = dbe.Workspaces(0).OpenDatabase(IO.Path.Combine(pathDirectory, "ServerDBNew _SKN.accdb"))

            Dim num As String = "55100"
            Dim izd As String = "158"
            Dim seria As String = "205-07." & izd

            Dim ListFilesSave As New ArrayList From {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            'ref_doc = SaveMoveImageDB(db1, DataGridView2, "СКН", num & "/" & izd, ListFilesSave.Count)
            SaveMoveImageDB_SKN(db2, ListFilesSave, ref_doc, num, izd, seria)

            dbe.CommitTrans()

        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "При сохранении в базу дааных возникла ошибка. Данные в базе не сохрранились")
            dbe.Rollback()
        End Try

    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        loadRZ(pathDirectory, cbo_id_rz_register_doc, "Служебная записка РЗ")
    End Sub

    Private Sub cbo_id_doc_zapros_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles cbo_id_rz_register_doc.Validating

		cbo_id_rz_register_doc.Tag = cbo_id_rz_register_doc.Text
        If Not SearchRZ(pathDirectory, cbo_id_rz_register_doc) Then
            'id_RZ_RegisterDoc(pathDirectory, cbo_ref_doc.Text)
            loadRZ(pathDirectory, cbo_id_rz_register_doc, "Служебная записка РЗ")
            'loadRZ(pathDirectory, cbo_ref_doc, "Запрос производства")
            cbo_id_rz_register_doc.Text = cbo_id_rz_register_doc.Tag
            MsgBox("Добавление РЗ прошло успешно")
        End If

        'ComboBox2.Text = rzText
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim dbe As Object = Nothing

        Dim db1 As Object
        Dim db2 As Object

        'Dim pathDirectory As String
        'pathDirectory = Environment.CurrentDirectory & "\"

        Dim ref_doc As Integer
        Dim spec As String = "" '= cbo_type_zp.Text
        Dim dep_zp As String '= cbo_AntonovDep.Text
        Dim num As Integer  '= "" 'txt_num_zp.Text
        Dim izd As String = "" 'cbo_izd.Text
        Dim id_rz_register_doc As Integer

        If cbo_type_zp.Text = "" Then
            MsgBox("Укажите тип запроса")
            Exit Sub
        ElseIf cbo_type_zp.Text = "-" Then
            spec = ""
        Else
            spec = cbo_type_zp.Text
        End If

        Try
            dbe = CreateObject("DAO.DbEngine.120")

            dbe.BeginTrans()

            'db1 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "MoveImageDB.accdb")
			db1 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "ServerDBNew.accdb")

            'db2 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "MoveImageDB _SKN.accdb")
			db2 = dbe.Workspaces(0).OpenDatabase(pathDirectory & "ServerDBNew _ZP.accdb")

            'Dim num As String = "55100"
            'Dim izd As String = "158"
            'Dim seria As String = "205-07" & izd

            Dim seria As String = txt_seria.Text
            Dim prim As String = txt_prim.Text

            Dim ListFilesSave As New ArrayList From {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            dep_zp = cbo_AntonovDep.Text
            num = Integer.Parse(txt_num_zp.Text)
            izd = cbo_izd.Text
            id_rz_register_doc = cbo_id_rz_register_doc.SelectedValue

            Dim num_doc As String = spec & "-" & dep_zp & "/" & num & "-" & izd

            'ref_doc = SaveMoveImageDB(db1, dgv, "Запрос производства", num_doc, ListFilesSave.Count)

            SaveMoveImageDB_ZP(db2, ListFilesSave, ref_doc, spec, dep_zp, num, izd, id_rz_register_doc, seria, prim)

            db1.Close()
            db2.Close()

            dbe.CommitTrans()

            MsgBox("Запись запроса производства в базу данных прошло успешно")

        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "При сохранении в базу дааных возникла ошибка. Данные в базе не сохрранились")

            dbe.Rollback()
        End Try
    End Sub

    Private Sub cbo_id_doc_zapros_Validated(sender As Object, e As EventArgs) Handles cbo_id_rz_register_doc.Validated

    End Sub

    Private Sub cbo_ref_doc_SelectedValueChanged(sender As Object, e As EventArgs) Handles cbo_id_rz_register_doc.SelectedValueChanged
        Label8.Text = cbo_id_rz_register_doc.SelectedValue.ToString()
    End Sub

    Dim dgv As DataGridView
    Private Sub cmd_OpenFormSector_Click(sender As Object, e As EventArgs) Handles cmd_OpenFormSector.Click
        'frm_Sector(dataGriView_Sector).ShowDialog()
        


    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim s() As String = Nothing
        Dim d As Data = New Data()

        Dim frm As New frm_Sector(d)

        Dim result As DialogResult = frm.ShowDialog()
        s = d.Value

        For i = 0 To s.Length - 1
            ListBox1.Items.Add(s(i))
        Next

    End Sub
End Class