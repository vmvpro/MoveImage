Module mdl_Test3
    Function SaveMoveImageDB(db As Object, s() As String, type As String, num_doc As String, count_list As Integer) As Integer

        Dim rsRegisterDoc As Object
        Dim rsSector As Object
        Dim rs2 As Object
        Dim f2 As Object

        Dim id As Integer

        rsRegisterDoc = db.OpenRecordset("Register_Doc", RecordsetTypeEnum.dbOpenDynaset)
        rsSector = db.OpenRecordset("dop_Sector", RecordsetTypeEnum.dbOpenDynaset)

        rsRegisterDoc.AddNew()
        rsRegisterDoc.Fields("type").Value = type
        rsRegisterDoc.Fields("num_doc").Value = num_doc

        'Dim s As String() = New String() {"2.1", "1.1"}

        'Dim s As String() = listChekedSectors(DataGridView2).ToArray
        rsRegisterDoc.Fields("count_list").Value = count_list

        rs2 = rsRegisterDoc.Fields("r_sections").Value

        For i = 0 To s.Length - 1
            rs2.AddNew()
            Call rsSector.FindFirst("sector = '" & s(i) & "'")
            f2 = rs2.Fields("Value")

            f2.Value = rsSector.Fields("sector").Value

            rs2.Update()
        Next

        rsRegisterDoc.Fields("scan").Value = "Требуется"
        rsRegisterDoc.Fields("prim").Value = "VS. Test3 Transactions"

        id = rsRegisterDoc.Fields("id").Value

        rsSector.Close()
        rsRegisterDoc.Update()

        rsRegisterDoc.Close()

        Return id

    End Function

	Sub SaveMoveImageDB_SKN(db As Object, ListFilesSave As ArrayList, ref_doc As Integer, num As String, izd As String, seria As String)
		Try

			'Dim dbe As Object
			'Dim db As Object
			Dim rsRegisterSKNImage As Object
			Dim rs2 As Object
			Dim f2 As Object

			'Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

			Dim pathDirectory As String
			pathDirectory = Environment.CurrentDirectory & "\"

			'dbe = CreateObject("DAO.DbEngine.120")
			'db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB _SKN.accdb")

			rsRegisterSKNImage = db.OpenRecordset("Register_SKN_Image", RecordsetTypeEnum.dbOpenDynaset)
			'rsSector = db.OpenRecordset("dop_Sector", RecordsetTypeEnum.dbOpenDynaset)

			rsRegisterSKNImage.AddNew()
			rsRegisterSKNImage.Fields("ref_doc").Value = ref_doc
			rsRegisterSKNImage.Fields("izd").Value = izd

			rsRegisterSKNImage.Fields("num").Value = num
			rsRegisterSKNImage.Fields("izd_shifr").Value = izd
			rsRegisterSKNImage.Fields("seria").Value = seria
			rsRegisterSKNImage.Fields("prim").Value = "VS. Test3 Transactions"

			rs2 = rsRegisterSKNImage.Fields("image").Value

			For i = 0 To ListFilesSave.Count - 1
				rs2.AddNew()

				'Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString
				Dim temp As String = pathDirectory & ListFilesSave(i)

				f2 = rs2.Fields("FileData")
				Call f2.LoadFromFile(temp)
				rs2.Update()
			Next

			rsRegisterSKNImage.Update()
			rsRegisterSKNImage.Close()

		Catch ex As Exception

		End Try
    End Sub

    Sub SaveMoveImageDB_ZP(db As Object, ListFilesSave As ArrayList,
                           ref_doc As Integer,
                           spec As String,
                           dep_zp As String,
                           num As Integer,
                           izd As Integer,
                           id_rz_register_doc As Integer,
                           seria As String,
                           prim As String)
        Try

            'Dim dbe As Object
            'Dim db As Object
            Dim rsRegisterZPImage As Object
            Dim rs2 As Object
            Dim f2 As Object

            'Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"

            'dbe = CreateObject("DAO.DbEngine.120")
            'db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB _SKN.accdb")

            rsRegisterZPImage = db.OpenRecordset("Register_ZP_Image", RecordsetTypeEnum.dbOpenDynaset)
            'rsSector = db.OpenRecordset("dop_Sector", RecordsetTypeEnum.dbOpenDynaset)

            rsRegisterZPImage.AddNew()
            rsRegisterZPImage.Fields("ref_doc").Value = ref_doc

            rsRegisterZPImage.Fields("spec").Value = spec
            rsRegisterZPImage.Fields("dep_zp").Value = dep_zp
            rsRegisterZPImage.Fields("num").Value = num
            rsRegisterZPImage.Fields("izd").Value = izd

            If (id_rz_register_doc > 0) Then
                rsRegisterZPImage.Fields("id_rz_register_doc").Value = id_rz_register_doc
            End If

            rsRegisterZPImage.Fields("seria").Value = seria
            rsRegisterZPImage.Fields("prim").Value = prim

            'rsRegisterZPImage.Fields("izd").Value = izd

            'rsRegisterZPImage.Fields("num").Value = num
            'rsRegisterZPImage.Fields("izd_shifr").Value = izd
            'rsRegisterZPImage.Fields("seria").Value = seria
            'rsRegisterZPImage.Fields("prim").Value = "VS. Test3 Transactions"

            rs2 = rsRegisterZPImage.Fields("image").Value

            For i = 0 To ListFilesSave.Count - 1
                rs2.AddNew()

                'Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString
                Dim temp As String = pathDirectory & ListFilesSave(i)

                f2 = rs2.Fields("FileData")
                Call f2.LoadFromFile(temp)
                rs2.Update()
            Next

            rsRegisterZPImage.Update()
            rsRegisterZPImage.Close()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    

    Sub load_Izd(pathFolderDataBase As String, comboBoxIzd As ComboBox)
        Dim query As String = "SELECT dop_Izdelia.ID, dop_Izdelia.izd, dop_Izdelia.index " &
            "FROM dop_Izdelia " & _
            "WHERE (((dop_Izdelia.izd) Not In ('Указать','КОС','148/158')))" & _
            "ORDER BY dop_Izdelia.index;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

        Dim dt As New DataTable
        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = query
                }

                '.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

                cn.Open()
                dt.Load(cmd.ExecuteReader)

            End Using
        End Using

        comboBoxIzd.DataSource = dt

        comboBoxIzd.DisplayMember = "izd"
        comboBoxIzd.ValueMember = "id"

    End Sub



	Sub load_AntonovDep_(pathDataBase As String, cboAntonovDep As ComboBox)
		Dim query As String = "SELECT dop_AntonovDep.dep_name " & _
							  "FROM dop_AntonovDep " & _
							  "ORDER BY dop_AntonovDep.index, dop_AntonovDep.dep_name;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathDataBase, "ServerDBNew.accdb")
			}

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = query
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

			End Using
		End Using

		cboAntonovDep.DataSource = dt

		cboAntonovDep.DisplayMember = "dep_name"
		cboAntonovDep.ValueMember = "dep_name"

	End Sub

    Sub load_ShifrIzd(pathFolderDataBase As String, comboBoxShifrIzd As ComboBox)
        Dim query As String = "SELECT dop_Izdelia.ID, dop_Izdelia.izd, dop_Izdelia.index " &
            "FROM dop_Izdelia " & _
            "ORDER BY dop_Izdelia.index;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

        Dim dt As New DataTable
        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = query
                }

                '.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

                cn.Open()
                dt.Load(cmd.ExecuteReader)

            End Using
        End Using

        comboBoxShifrIzd.DataSource = dt

        comboBoxShifrIzd.DisplayMember = "izd"
        comboBoxShifrIzd.ValueMember = "id"

    End Sub

    Sub loadRZ(cbo_id_doc_zapros As ComboBox, type_doc As String)
        Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
            {
                .Provider = "Microsoft.ACE.OLEDB.12.0",
                .DataSource = IO.Path.Combine(Application.StartupPath, "MoveImageDB.accdb")
            }

        '.DataSource = IO.Path.Combine(Application.StartupPath, "MoveImageDB.accdb")

        Dim dt As New DataTable
        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT * FROM Register_Doc Where type = '" & type_doc & "' Order By num_doc"
                }

                '.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

                cn.Open()
                dt.Load(cmd.ExecuteReader)

            End Using
        End Using

        cbo_id_doc_zapros.DataSource = dt

        cbo_id_doc_zapros.DisplayMember = "num_doc"
        cbo_id_doc_zapros.ValueMember = "id"
    End Sub

    Sub loadRZ(pathFolderDataBase As String, cbo_id_doc_zapros As ComboBox, type_doc As String)
		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

        '.DataSource = IO.Path.Combine(Application.StartupPath, "MoveImageDB.accdb")

        Dim dt As New DataTable
        Using cn As New OleDb.OleDbConnection With
            {
                .ConnectionString = BuilderAccdb.ConnectionString
            }

            Using cmd As New OleDb.OleDbCommand With
                {
                    .Connection = cn,
                    .CommandText = "SELECT * FROM Register_Doc Where type = '" & type_doc & "' Order By num_doc"
                }

                '.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

                cn.Open()
                dt.Load(cmd.ExecuteReader)

                Dim all As DataRow = dt.NewRow
                all.SetField(Of String)("num_doc", "")
                all.SetField(Of Integer)("id", 0)
                dt.Rows.InsertAt(all, 0)
                dt.AcceptChanges()

            End Using
        End Using

        cbo_id_doc_zapros.DataSource = dt

        cbo_id_doc_zapros.DisplayMember = "num_doc"
        cbo_id_doc_zapros.ValueMember = "id"
    End Sub
    Function id_RZ_RegisterDoc(num_doc As String) As Integer
        Try
            Dim dbe As Object
            Dim db As Object
            Dim rsRegisterDoc As Object
            Dim id As Integer

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"

            dbe = CreateObject("DAO.DbEngine.120")
            db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB.accdb")

            rsRegisterDoc = db.OpenRecordset("Register_Doc_", RecordsetTypeEnum.dbOpenDynaset)

            rsRegisterDoc.AddNew()
            rsRegisterDoc.Fields("type").Value = "Служебная записка РЗ"
            rsRegisterDoc.Fields("num_doc").Value = num_doc
            rsRegisterDoc.Fields("count_list").Value = 0
            rsRegisterDoc.Fields("prim").Value = "Регистрация документа произошла из формы программы MoveImage"

			id = CType(rsRegisterDoc.Fields("id").Value, Integer)

            rsRegisterDoc.Update()
            rsRegisterDoc.Close()

            Return id
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function

    Public Function SearchRZ(ComboBox2 As ComboBox) As Boolean
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
                        'Do While readerDB.Read
                        'MessageBox.Show(readerDB(0).ToString)
                        'Loop
                        Return True

                    Else
                        Dim result As DialogResult
                        result = MessageBox.Show("Запись не найдена. Желаете зарегистрировать данный документ РЗ?", "Сообщение", MessageBoxButtons.YesNo)
                        If result = DialogResult.Yes Then
                            'ProgressBar1.Visible = True

                            'BackgroundWorker1.RunWorkerAsync(ComboBox2)

                            'BackgroundWorker1.RunWorkerAsync(ComboBox2.Text)


                            id_RZ_RegisterDoc(ComboBox2.Text)

                            Return False


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

    Public Function SearchRZ(pathFolderDataBase As String, ComboBox2 As ComboBox) As Boolean
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
					.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
				}

            Dim dt As New DataTable
            Using cn As New OleDb.OleDbConnection With
                {
                    .ConnectionString = BuilderAccdb.ConnectionString
                }

                Using cmd As New OleDb.OleDbCommand With
                    {
                        .Connection = cn,
                        .CommandText = "SELECT * FROM Register_Doc Where type = 'Служебная записка РЗ' and num_doc = '" & ComboBox2.Text & "'"
                    }

                    cn.Open()

                    readerDB = cmd.ExecuteReader()

                    If readerDB.HasRows Then
                        'Do While readerDB.Read
                        'MessageBox.Show(readerDB(0).ToString)
                        'Loop
                        Return True

                    Else
                        Dim result As DialogResult
                        result = MessageBox.Show("Запись не найдена. Желаете зарегистрировать данный документ РЗ?", "Сообщение", MessageBoxButtons.YesNo)
                        If result = DialogResult.Yes Then
                            'ProgressBar1.Visible = True

                            'BackgroundWorker1.RunWorkerAsync(ComboBox2)

                            'BackgroundWorker1.RunWorkerAsync(ComboBox2.Text)


                            id_RZ_RegisterDoc(pathFolderDataBase, ComboBox2.Text)

                            Return False


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
    Function id_RZ_RegisterDoc(pathFolderDataBase As String, num_doc As String) As Integer
        Try
            Dim dbe As Object
            Dim db As Object
            Dim rsRegisterDoc As Object
            Dim id As Integer

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"

            dbe = CreateObject("DAO.DbEngine.120")
			db = dbe.OpenDatabase(pathFolderDataBase & "\ServerDBNew.accdb")

            rsRegisterDoc = db.OpenRecordset("Register_Doc", RecordsetTypeEnum.dbOpenDynaset)

            rsRegisterDoc.AddNew()
            rsRegisterDoc.Fields("type").Value = "Служебная записка РЗ"
            rsRegisterDoc.Fields("num_doc").Value = num_doc
            rsRegisterDoc.Fields("count_list").Value = 0
            rsRegisterDoc.Fields("prim").Value = "Регистрация документа произошла из формы программы MoveImage"

            id = rsRegisterDoc.Fields("id").Value

            rsRegisterDoc.Update()
            rsRegisterDoc.Close()

            Return id
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return 0
        End Try
    End Function

    Sub DataSource_ShifrIzd()
        Dim ddd As String = "SELECT dop_Izdelia.ID, dop_Izdelia.izd, dop_Izdelia.index " &
            "FROM dop_Izdelia " & _
            "WHERE (((dop_Izdelia.izd) Not In ('Указать','КОС','148/158')))" & _
            "ORDER BY dop_Izdelia.index;"

    End Sub

End Module
