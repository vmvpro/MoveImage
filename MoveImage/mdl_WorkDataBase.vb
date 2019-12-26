Imports System.Data.OleDb

Module mdl_WorkDataBase
    Public Enum RecordsetTypeEnum
        dbOpenTable = 1
        dbOpenDynaset = 2
        dbOpenSnapshot = 4
        dbOpenForwardOnly = 8
        dbOpenDynamic = 16
    End Enum
    Sub WorkSaveDataBase()
        Try
            'Dim dbe As DAO.DBEngine
            'Dim db As DAO.Database
            'Dim rsCustomer As DAO.Recordset
            'Dim rsLanguage As DAO.Recordset
            'Dim rs2 As DAO.Recordset2
            'Dim f2 As DAO.Field2

            Dim dbe As Object
            Dim db As Object
            Dim rsSKN As Object
            Dim rs2 As Object
            Dim f2 As Object

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"


            Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}
            
            dbe = CreateObject("DAO.DbEngine.120")
            db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB.accdb")


            'Set db = dbe.OpenDatabase(pathDirectory & "WorkBD.accdb")
            'db = CurrentDb
            rsSKN = db.OpenRecordset("tbl_SKN", RecordsetTypeEnum.dbOpenDynaset)
            'rsLanguage = db.OpenRecordset("tab_Language", RecordsetTypeEnum.dbOpenDynaset)

            rsSKN.AddNew()
            rsSKN.Fields("izd").Value = "178"
            rsSKN.Fields("num").Value = 99
            rsSKN.Fields("cherteg").Value = "178.00.5603.080.000"
            rsSKN.Fields("prim").Value = "Примечание по документу"

            rs2 = rsSKN.Fields("image").Value

            For i = 0 To fileName.Length - 1
                rs2.AddNew()
                f2 = rs2.Fields("FileData")
                Call f2.LoadFromFile(pathDirectory & fileName(i))
                rs2.Update()
            Next

            'rs2 = rsCustomer.Fields("language").Value

            'For i = 0 To 1
            '    rs2.AddNew()
            '    Call rsLanguage.FindFirst("language = '" & language(i) & "'")
            '    f2 = rs2.Fields("Value")
            '    f2.Value = rsLanguage.Fields("id").Value
            '    'f2.Value = i + 3
            '    rs2.Update()
            'Next
            'rsLanguage.Close

            'var = rsCustomer.Fields("id").Value

            rsSKN.Update()

            'var = rsCustomer.Fields("id").Value
            rsSKN.Close()


        Catch ex As Exception

        End Try
    End Sub

    Sub WorkSaveDataBaseTest(ListSelectedFiles As ArrayList, sSingle As Control()())
        Try
            'Dim dbe As DAO.DBEngine
            'Dim db As DAO.Database
            'Dim rsCustomer As DAO.Recordset
            'Dim rsLanguage As DAO.Recordset
            'Dim rs2 As DAO.Recordset2
            'Dim f2 As DAO.Field2

            Dim dbe As Object
            Dim db As Object
            Dim rsSKN As Object
            Dim rs2 As Object
            Dim f2 As Object

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"


            Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            dbe = CreateObject("DAO.DbEngine.120")
            db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB.accdb")


            'Set db = dbe.OpenDatabase(pathDirectory & "WorkBD.accdb")
            'db = CurrentDb
            rsSKN = db.OpenRecordset("tbl_SKN", RecordsetTypeEnum.dbOpenDynaset)
            'rsLanguage = db.OpenRecordset("tab_Language", RecordsetTypeEnum.dbOpenDynaset)

            rsSKN.AddNew()
            For i As Integer = 0 To sSingle.Length - 1
                rsSKN.Fields(sSingle(i)(1).Name).Value = sSingle(i)(1).Text
                'str1 = ss(i)(1).Name
                'ii = ss(i)(1).Text
            Next

            'rsSKN.Fields("izd").Value = "178"
            'rsSKN.Fields("num").Value = 99
            'rsSKN.Fields("cherteg").Value = "178.00.5603.080.000"
            'rsSKN.Fields("prim").Value = "Примечание по документу"

            rs2 = rsSKN.Fields("image").Value

            For i = 0 To ListSelectedFiles.Count - 1
                rs2.AddNew()
                f2 = rs2.Fields("FileData")
                Call f2.LoadFromFile(ListSelectedFiles(i).ToString())
                rs2.Update()
            Next

            'rs2 = rsCustomer.Fields("language").Value

            'For i = 0 To 1
            '    rs2.AddNew()
            '    Call rsLanguage.FindFirst("language = '" & language(i) & "'")
            '    f2 = rs2.Fields("Value")
            '    f2.Value = rsLanguage.Fields("id").Value
            '    'f2.Value = i + 3
            '    rs2.Update()
            'Next
            'rsLanguage.Close

            'var = rsCustomer.Fields("id").Value

            rsSKN.Update()

            'var = rsCustomer.Fields("id").Value
            rsSKN.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Sub WorkSaveDataBase_RegisterDoc_Test(DataGridView2 As DataGridView, num_doc As String)
        Try

            Dim dbe As Object
            Dim db As Object
            Dim rsRegisterDoc As Object
            Dim rsSector As Object
            Dim rs2 As Object
            Dim f2 As Object


            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"

            dbe = CreateObject("DAO.DbEngine.120")
            db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB.accdb")

            rsRegisterDoc = db.OpenRecordset("Register_Doc", RecordsetTypeEnum.dbOpenDynaset)
            rsSector = db.OpenRecordset("dop_Sector", RecordsetTypeEnum.dbOpenDynaset)

            rsRegisterDoc.AddNew()
            rsRegisterDoc.Fields("type").Value = "СКН"
            rsRegisterDoc.Fields("num_doc").Value = num_doc
            rsRegisterDoc.Fields("count_list").Value = 3

            'Dim s As String() = New String() {"2.1", "1.1"}

            Dim s As String() = listChekedSectors(DataGridView2).ToArray

            rs2 = rsRegisterDoc.Fields("r_sections").Value

            For i = 0 To s.Length - 1
                rs2.AddNew()
                Call rsSector.FindFirst("sector = '" & s(i) & "'")
                f2 = rs2.Fields("Value")
                'f2.Value = rsSector.Fields("id").Value sector
                f2.Value = rsSector.Fields("sector").Value

                rs2.Update()
            Next

            rsRegisterDoc.Fields("scan").Value = "Требуется"
            rsRegisterDoc.Fields("prim").Value = "Привет из VS"

            rsSector.Close()
            rsRegisterDoc.Update()

            rsRegisterDoc.Close()

        Catch ex As Exception

        End Try
	End Sub

    Function listChekedSectors(DataGridView2 As DataGridView) As List(Of String)
        Dim listChecked As List(Of DataRow) = DataGridView2.DataTable().CheckedRows("Выбор")
        Dim listSectors As New List(Of String)

        If (listChecked.Count() > 0) Then
            For Each row As DataRow In listChecked
                listSectors.Add(row.Field(Of String)("Участок"))
            Next
        End If

        Return listSectors
    End Function

    Sub loadTable_dopSector()
        'Dim connStringBuilder As New OleDb.OleDbConnectionStringBuilder
        'connStringBuilder.Provider = "Microsoft.ACE.OLEDB.12.0"
        'connStringBuilder.DataSource = Environment.CurrentDirectory & "\MoveImageDB.accdb"

        'Dim conn As OleDb.OleDbConnection = New OleDb.OleDbConnection(connStringBuilder.ConnectionString)

        'Dim cmd As OleDb.OleDbCommand = New OleDbCommand("Select ")

    End Sub

    Function LoadDataGridView_Sectors() As DataTable
        Dim dt As DataTable = New DataTable()

        dt.Columns.Add("Выбор_", GetType(Integer))
        dt.Columns.Add("Участок", GetType(String))  ' Room
        dt.Columns.Add("Кто за участком", GetType(String))

        dt.Rows.Add(1, "?.?", "Неизвестно (К цеху относится)")
        dt.Rows.Add(2, "1.1", "Михаил Леонидович")
        dt.Rows.Add(3, "2.1", "Ирина Сергеевна")
        dt.Rows.Add(4, "2.2", "Наталья Ивановна")
        dt.Rows.Add(5, "2.4", "Не закреплен")
        dt.Rows.Add(6, "3.1", "Сборочный участок")
        dt.Rows.Add(10, "1.3", "Механический участок")
        dt.Rows.Add(11, "Не наш", "К цеху не относится")
        dt.Rows.Add(12, "Косвенно", "На сборку или для информации")

        dt.Columns.Add("Выбор", GetType(Boolean))   ' Available
        dt.Columns("Выбор").SetOrdinal(0)
        dt.Columns("Выбор_").ColumnMapping = MappingType.Hidden

        For Each row As DataRow In dt.Rows
            row.SetField(Of Boolean)("Выбор", False)
        Next

        Return dt
    End Function

    Function LoadDataGridView_Sectors_(pathFolderDataBase As String) As DataTable
        Dim query As String = "SELECT dop_Sector.index as [Выбор_], dop_Sector.sector as [Участок], dop_Sector.name as [Кто за участком] " & _
                              "FROM dop_Sector " & _
                              "ORDER BY index;"

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

        dt.Columns.Add("Выбор", GetType(Boolean))   ' Available
        dt.Columns("Выбор").SetOrdinal(0)
        dt.Columns("Выбор_").ColumnMapping = MappingType.Hidden

        For Each row As DataRow In dt.Rows
            row.SetField(Of Boolean)("Выбор", False)
        Next

        Return dt

        ''Dim dt As DataTable = New DataTable()

        'dt.Columns.Add("Выбор_", GetType(Integer))
        'dt.Columns.Add("Участок", GetType(String))  ' Room
        'dt.Columns.Add("Кто за участком", GetType(String))

        'dt.Rows.Add(1, "?.?", "Неизвестно (К цеху относится)")
        'dt.Rows.Add(2, "1.1", "Михаил Леонидович")
        'dt.Rows.Add(3, "2.1", "Ирина Сергеевна")
        'dt.Rows.Add(4, "2.2", "Наталья Ивановна")
        'dt.Rows.Add(5, "2.4", "Не закреплен")
        'dt.Rows.Add(6, "3.1", "Сборочный участок")
        'dt.Rows.Add(10, "1.3", "Механический участок")
        'dt.Rows.Add(11, "Не наш", "К цеху не относится")
        'dt.Rows.Add(12, "Косвенно", "На сборку или для информации")

        'dt.Columns.Add("Выбор", GetType(Boolean))   ' Available
        'dt.Columns("Выбор").SetOrdinal(0)
        'dt.Columns("Выбор_").ColumnMapping = MappingType.Hidden

        'For Each row As DataRow In dt.Rows
        '    row.SetField(Of Boolean)("Выбор", False)
        'Next

        'Return dt
    End Function

    Public Sub loadDataGrid_Sectors(DataGridView2 As DataGridView)

        DataGridView2.DataSource = LoadDataGridView_Sectors_(path_DataBase)

        DataGridView2.Columns("Выбор").Width = 45
        DataGridView2.Columns("Выбор").Resizable = DataGridViewTriState.False

        DataGridView2.Columns("Кто за участком").Width = 180
        DataGridView2.Columns("Кто за участком").ReadOnly = True
        DataGridView2.Columns("Кто за участком").Resizable = DataGridViewTriState.False

        DataGridView2.Columns("Участок").Width = 70
        DataGridView2.Columns("Участок").ReadOnly = True
        DataGridView2.Columns("Участок").Resizable = DataGridViewTriState.False

        DataGridView2.AllowUserToAddRows = False
    End Sub

    

    


End Module
