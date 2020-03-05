Imports System.Text.RegularExpressions

Partial Class cls_TypeDoc
    Public Sub SaveDataBaseCurrentClassImage(db As Object,
                                        ref_doc As Integer,
                                        tableNameDataBase As String,
                                        ListSelectedFiles As ArrayList,
                                        sSingle As Control()())
        Try
            'Dim dbe As DAO.DBEngine
            'Dim db As DAO.Database
            'Dim rsCustomer As DAO.Recordset
            'Dim rsLanguage As DAO.Recordset
            'Dim rs2 As DAO.Recordset2
            'Dim f2 As DAO.Field2

            'Dim dbe As Object
            'Dim db As Object
            Dim rs As Object
            Dim rs2 As Object
            Dim f2 As Object

            Dim fieldName As String
            Dim fieldValue As Object


            'Dim pathDirectory As String
            'pathDirectory = Environment.CurrentDirectory & "\"


            'Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            'dbe = CreateObject("DAO.DbEngine.120")
            'db = dbe.OpenDatabase(pathDirectory & "\ServerDBNew.accdb")


            'Set db = dbe.OpenDatabase(pathDirectory & "WorkBD.accdb")
            'db = CurrentDb
            'rs = db.OpenRecordset(tableNameDataBase, RecordsetTypeEnum.dbOpenDynaset)
            'rsLanguage = db.OpenRecordset("tab_Language", RecordsetTypeEnum.dbOpenDynaset)

            'rs.AddNew()

            rs = rsSearch(db, tableNameDataBase, ref_doc)
            rs.Fields("ref_doc").Value = ref_doc

            For i As Integer = 0 To sSingle.Length - 1
                If Not (Len(sSingle(i)(1).Text) = 0) Then
                    fieldName = sSingle(i)(1).Name
                    fieldValue = sSingle(i)(1).Value

                    Try
                        rs.Fields(fieldName).Value = fieldValue

                    Catch ex As Exception

                    End Try



                End If

            Next

            'rsSKN.Fields("izd").Value = "178"
            'rsSKN.Fields("num").Value = 99
            'rsSKN.Fields("cherteg").Value = "178.00.5603.080.000"
            'rsSKN.Fields("prim").Value = "Примечание по документу"

            rs2 = rs.Fields("image").Value

            Do While Not (CType(rs2.EOF, Boolean))
                rs2.Delete()
                rs2.MoveNext()

            Loop


            For i = 0 To ListFilesSave.Count - 1
                Try
                    rs2.AddNew()

                    Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString()

                    f2 = rs2.Fields("FileData")
                    Call f2.LoadFromFile(temp)
                    rs2.Update()
                Catch ex As Exception

                End Try

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

            rs.Update()

            'var = rsCustomer.Fields("id").Value
            rs.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Function isValidText(text As String, pattern As String) As Boolean
        Dim isMatch As Match = Regex.Match(text, pattern, RegexOptions.IgnoreCase)
        Return isMatch.Success
    End Function

    Function rsSearch(db As Object, tableNameDataBase As String, ref_doc As Integer) As Object
        Dim rs As Object

        rs = db.OpenRecordset("Select * From " & tableNameDataBase & " Where ref_doc = " & ref_doc, RecordsetTypeEnum.dbOpenDynaset)
        Try
            rs.Edit()

            Return rs
        Catch ex As Exception
            rs.AddNew()

            Return rs
        End Try
    End Function

    Function VerificationRecord(db As Object, type As String, num_doc As String) As Object
        Dim rsRegisterDoc As Object
        rsRegisterDoc = db.OpenRecordset("Select * From Register_Doc Where type = '" & type & "' and num_doc = '" & num_doc & "'", RecordsetTypeEnum.dbOpenDynaset)

        Try
            'Dim queryWhere = 
            'Call rsRegisterDoc.FindFirst(queryWhere)
            rsRegisterDoc.Edit()
            rsRegisterDoc.Fields("prim").Value = "Автоматическое изменение через программу MoveImage"
            Return rsRegisterDoc
        Catch ex As Exception
            rsRegisterDoc.AddNew()
            rsRegisterDoc.Fields("prim").Value = "Автоматическая вставка через программу MoveImage"
            Return rsRegisterDoc
        End Try

    End Function

    Function VerificationRecord(db As Object, typeDocInForm As String) As Object
        Dim rsRegisterDoc As Object
        'rsRegisterDoc = db.OpenRecordset("Select * From Register_Doc Where type = '" & type & "' and num_doc = '" & num_doc & "'", RecordsetTypeEnum.dbOpenDynaset)
        rsRegisterDoc = OpenRecordset(db, typeDocInForm)

        Try
            'Dim queryWhere = 
            'Call rsRegisterDoc.FindFirst(queryWhere)
            rsRegisterDoc.Edit()
            rsRegisterDoc.Fields("prim").Value = "Автоматическое изменение через программу MoveImage"
            Return rsRegisterDoc
        Catch ex As Exception
            rsRegisterDoc.AddNew()
            rsRegisterDoc.Fields("prim").Value = "Автоматическая вставка через программу MoveImage"
            Return rsRegisterDoc
        End Try

    End Function

    Function OpenRecordset(db As Object, typeDocInForm As String) As Object

        Select Case nameGroup
            Case "Административная"
                Return db.OpenRecordset("Select * " & _
                                 "From Register_Doc_Administrative " & _
                                 "Where type_doc = '" & typeDocInForm & "' and num_doc = '" & num_doc & "' and dates_doc = #" & dates_doc_string & "#",
                                 RecordsetTypeEnum.dbOpenDynaset)

            Case "Техническая"
                Return db.OpenRecordset("Select * " & _
                                 "From Register_Doc " & _
                                 "Where type = '" & typeDocInForm & "' and num_doc = '" & num_doc & "'", _
                                 RecordsetTypeEnum.dbOpenDynaset)

            Case "Технологическая"
                Return Nothing
        End Select
        Return Nothing


    End Function

    Function rsSearch_Image(db As Object, tableName_Image As String, i_NotImage As Integer) As Object
        Dim rs As Object

        rs = db.OpenRecordset("Select * From " & tableName_Image & " Where id_NotImage = " & i_NotImage, RecordsetTypeEnum.dbOpenDynaset)
        Try
            rs.Edit()

            Return rs
        Catch ex As Exception
            rs.AddNew()

            Return rs
        End Try
    End Function

    Function VerificationRecord_Image(db As Object, tableName_Image As String, i_NotImage As Integer) As Object
        Dim rsRegisterDoc As Object
        rsRegisterDoc = db.OpenRecordset("Select * From " & tableName_Image & " Where id_NotImage = " & i_NotImage, RecordsetTypeEnum.dbOpenDynaset)

        Try
            'Dim queryWhere = 
            'Call rsRegisterDoc.FindFirst(queryWhere)
            rsRegisterDoc.Edit()
            'rsRegisterDoc.Fields("prim").Value = "Автоматическое изменение через программу MoveImage"
            Return rsRegisterDoc
        Catch ex As Exception
            rsRegisterDoc.AddNew()
            'rsRegisterDoc.Fields("prim").Value = "Автоматическая вставка через программу MoveImage"
            Return rsRegisterDoc
        End Try

    End Function

    Function SaveDataBase_RegisterDoc(db As Object, s() As String, type As String, count_list As Integer) As Integer

        Dim rsRegisterDoc As Object
        Dim rsSector As Object
        Dim rs2 As Object
        'Dim f2 As Object

        Dim id As Integer

        'rsRegisterDoc = db.OpenRecordset("Register_Doc", RecordsetTypeEnum.dbOpenDynaset)
        'rsRegisterDoc.AddNew()

        'rsRegisterDoc = VerificationRecord(db, type, num_doc)
        rsRegisterDoc = VerificationRecord(db, type)

        '========================================================================
        ' ЗДЕСЬ ОШИБКА ПРИ РЕГИСТРАЦИИ РАСПОРЯЖЕНИЯ
        '========================================================================
        If nameGroup = "Административная" Then
            rsRegisterDoc.Fields("type_doc").Value = type
            rsRegisterDoc.Fields("num_doc").Value = num_doc
            rsRegisterDoc.Fields("dates_doc").Value = dates_doc_date
            rsRegisterDoc.Fields("count_list").Value = count_list

            id = CType(rsRegisterDoc.Fields("i_administrative_doc").Value, Integer)

        ElseIf nameGroup = "Техническая" Then
            rsRegisterDoc.Fields("type").Value = type
            rsRegisterDoc.Fields("num_doc").Value = num_doc
            rs2 = rsRegisterDoc.Fields("r_sections").Value
            rsSector = db.OpenRecordset("dop_Sector", RecordsetTypeEnum.dbOpenDynaset)

            Dim sector As String

            Do While Not (CType(rs2.EOF, Boolean))
                rs2.Delete()
                rs2.MoveNext()
            Loop

            For i = 0 To s.Length - 1
                Try
                    rs2.AddNew()
                    Call rsSector.FindFirst("sector = '" & s(i) & "'")
                    sector = rsSector.Fields("sector").Value.ToString()
                    rs2.Fields("Value").Value = sector
                    rs2.Update()
                Catch ex As Exception

                End Try
            Next

            rsRegisterDoc.Fields("scan").Value = "Требуется"
            rsSector.Close()

            id = CType(rsRegisterDoc.Fields("id").Value, Integer)

        ElseIf nameGroup = "Технологическая" Then

        End If




        rsRegisterDoc.Update()

        rsRegisterDoc.Close()

        Return id

    End Function

    Function SaveDataBase_TypeDoc(db As Object,
                                    ref_doc As Integer,
                                    tableName_TypeDoc As String,
                                    ByRef sSingle As Control()()) As Integer

        Try

            Dim rs As Object

            Dim fieldName As String
            Dim fieldValue As Object

            Dim i_NotImage As Integer

            rs = rsSearch(db, tableName_TypeDoc, ref_doc)
            rs.Fields("ref_doc").Value = ref_doc

            For i As Integer = 0 To sSingle.Length - 1
                If Not (Len(sSingle(i)(1).Text) = 0) Then
                    fieldName = sSingle(i)(1).Name
                    fieldValue = sSingle(i)(1).Value

                    Try
                        rs.Fields(fieldName).Value = fieldValue

                    Catch ex As Exception

                    End Try

                End If

            Next

            i_NotImage = CType(rs.Fields("i_NotImage").Value, Integer)

            rs.Update()

            'var = rsCustomer.Fields("id").Value
            rs.Close()

            Return i_NotImage

        Catch ex As Exception
            Throw New Exception(ex.Message)
            'MessageBox.Show(ex.Message)
        End Try


    End Function

    Public Sub SaveDataBase_TypeDocImage(db As Object,
                                    i_NotImage As Integer,
                                    tableName_Image As String,
                                    ListSelectedFiles As ArrayList
                                    )


        Try
            'Dim dbe As DAO.DBEngine
            'Dim db As DAO.Database
            'Dim rsCustomer As DAO.Recordset
            'Dim rsLanguage As DAO.Recordset
            'Dim rs2 As DAO.Recordset2
            'Dim f2 As DAO.Field2

            'Dim dbe As Object
            'Dim db As Object
            Dim rs As Object
            Dim rs2 As Object
            Dim f2 As Object

            Dim fieldName As String = ""
            Dim fieldValue As Object = Nothing


            'Dim pathDirectory As String
            'pathDirectory = Environment.CurrentDirectory & "\"


            'Dim fileName() As String = New String() {"003.jpg", "004.jpg", "005.jpg", "007.jpg"}

            'dbe = CreateObject("DAO.DbEngine.120")
            'db = dbe.OpenDatabase(pathDirectory & "\ServerDBNew.accdb")


            'Set db = dbe.OpenDatabase(pathDirectory & "WorkBD.accdb")
            'db = CurrentDb
            'rs = db.OpenRecordset(tableNameDataBase, RecordsetTypeEnum.dbOpenDynaset)
            'rsLanguage = db.OpenRecordset("tab_Language", RecordsetTypeEnum.dbOpenDynaset)

            'rs.AddNew()

            rs = rsSearch_Image(db, tableName_Image, i_NotImage)
            rs.Fields("id_NotImage").Value = i_NotImage

            rs2 = rs.Fields("image").Value

            Do While Not (CType(rs2.EOF, Boolean))
                rs2.Delete()
                rs2.MoveNext()

            Loop


            For i = 0 To ListFilesSave.Count - 1
                Try
                    rs2.AddNew()

                    Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString()

                    f2 = rs2.Fields("FileData")
                    Call f2.LoadFromFile(temp)
                    rs2.Update()
                Catch ex As Exception

                End Try

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

            rs.Update()

            'var = rsCustomer.Fields("id").Value
            rs.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message & vbNewLine & "Ошибка сохранения сканера в базе данных Access")
        End Try


    End Sub



    ''' <summary>
    ''' Сохранение класса в базе данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SaveDataBaseCurrentClass(dbe As Object, DataBaseName As String, TypeDocInForm As String, num_doc As String, s() As String, ListFilesSave As ArrayList)
        Dim db1 As Object = Nothing
        Dim db2 As Object = Nothing
        Dim db3 As Object = Nothing

        Dim err As Integer = 0

        Try

            'dbe.BeginTrans()

            '"ServerDBNew"
            err = 1
            db1 = dbe.Workspaces(0).OpenDatabase(path_DataBase & DataBaseName & ".accdb") ' "ServerDBNew"
            ref_doc = SaveDataBase_RegisterDoc(db1, s, TypeDocInForm, ListFilesSave.Count)
            'MessageBox.Show("Документ зарегистрирован в базе данных (1-й этап)!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information)

            err = 2
            db2 = dbe.Workspaces(0).OpenDatabase(path_DataBase & DataBaseName & ".accdb") ' "ServerDBNew"
            i_NotImage = SaveDataBase_TypeDoc(db2, ref_doc, nameTable_TypeDoc, sSingle)
            'MessageBox.Show("Документ зарегистрирован в базе данных (2-й этап)!", "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information)

            err = 3
            db3 = dbe.Workspaces(0).OpenDatabase(path_DataBase & nameDataBase_Image & ".accdb") ' "ServerDBNew_IZV.accdb"
            SaveDataBase_TypeDocImage(db3, i_NotImage, nameTable_Image, ListFilesSave)

            'SaveDataBaseCurrentClassImage(db3, ref_doc, tableName_TypeDoc, ListFilesSave, sSingle)
            'MessageBox.Show("Регистрация всего документа в базе данных прошла успешно (3-й этап)!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)

            db1.Close()
            db2.Close()
            db3.Close()

            'dbe.CommitTrans()

        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & "При сохранении в базу данных возникла ошибка. Данные в базе не сохранились" & vbNewLine & _
                            "Примечание:" & vbNewLine & _
                            "Об этой ошибке сообщите пожалуйста администратору базы данных." & vbNewLine & _
                            "Примечание: Этап ошибки - " & err, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information)

            'dbe.Rollback()

            If Not db1 Is Nothing Then
                db1.Close()
            End If

            If Not db2 Is Nothing Then
                db2.Close()
            End If

            If Not db3 Is Nothing Then
                db3.Close()
            End If

        End Try
    End Sub

    ''' <summary>
    ''' Переменная предназначена для таблицы Register_Doc И присваевается обозначение в совокупности 
    ''' полей конкретного класса для конкретного документа в процедуре inputFields
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetNumDoc() As String
        Return num_doc
    End Function

    ''' <summary>
    ''' Переменная предназначена для выяснения была ли загружены на форму элементы управления конкретного класса 
    ''' </summary>
    ''' <remarks></remarks>
    Public Function isControlsLoad() As Boolean
        Return field_isControlsLoad
    End Function



End Class
