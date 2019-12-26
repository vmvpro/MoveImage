Imports System.Text

Public Class cls_ZP
	Inherits cls_TypeDoc

    ' Объявление полей вточности как в базе данных
    'Dim ref_doc As Integer

	Dim spec As String = ""	'= cbo_type_zp.Text
	Dim temp_spec As String

	Dim dep_zp As String '= cbo_AntonovDep.Text
	Dim temp_dep_zp As String

	Dim num As String	'= "" 'txt_num_zp.Text
    Dim izd As String = "" 'cbo_izd.Text

    Dim id_rz_register_doc As Integer
    Dim temp_id_rz_register_doc As Integer

    Dim seria As String
    Dim prim As String

    Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "Запрос производства"
        dirName = "2_Техническая документация\ЗП - (Запрос производства)\Запрос производства (Предприятия)\"

        rootNameDocument = "ZP"
		nameDataBase = "ServerDBNew_" & rootNameDocument & ".accdb"
        nameTable_TypeDoc = "Register_" & rootNameDocument & "_NotImage"

		nameDataBase_Image = "ServerDBNew_Image_" & rootNameDocument
        nameTable_Image = "Register_" & rootNameDocument & "_ImageOne"

        
    End Sub

    Public Overrides Sub initial()
        'initial()
        'classFormation()
        Initialize()

        isFormLabels()
        isFormFields()

        sSingle = New Control()() {s14_cbo1, s15_cbo2, s02_num, s01_izd, s16_cbo3, s03_cherteg, s13_seria, s06_prim}
        sSingleInputCorrect = New Control()() {s14_cbo1, s15_cbo2, s02_num, s01_izd, s13_seria, s06_prim, s03_cherteg}

        field_isControlsLoad = True

    End Sub

    Protected Overrides Sub defineName()

        mas_SaveImages = New String() {"ЗП " & num, " - ", spec, "-" & dep_zp, "-", num, temp03_cherteg}        ' ЗП 123 | - |О|01|-|
        mas_SaveFolder = New String() {"ЗП " & num, " - ", spec, "-" & dep_zp, "-", num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {izd & "\", "ЗП " & num, " - ", spec, "-" & dep_zp, "-", num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)

    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

#Region "    Загрузка и подготовка элементов управления isFormLabels                    "

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s14_cbo1 - spec
        label14_cbo1.Text = "Тип запроса:*"
        field14_cbo1.Name = "spec"
        Dim sTypeZP() As String = New String() {"-", "К", "М", "О", "П", "Т"}
        field14_cbo1.Items.AddRange(sTypeZP)

        ' Настройка s15_cbo2 - dep_zp
        label15_cbo2.Text = "Отдел:*"
        field15_cbo2.Name = "dep_zp"
        load_AntonovDep(cls_TypeDoc.path_DataBase, field15_cbo2)

        ' Настройка s02_num

        ' Настройка s01_izd
        field01_izd.Name = "izd"
        load_izd_shifr(cls_TypeDoc.path_DataBase, field01_izd)

        ' Настройка s16_cbo3 - id_rz_register_doc
        label16_cbo3.Text = "Документ РЗ:"
        field16_cbo3.Name = "id_rz_register_doc"
        field16_cbo3.DropDownStyle = ComboBoxStyle.DropDownList
        load_RegisterDocParametr(field16_cbo3, "Служебная записка РЗ")


        ' Настройка s13_seria

        ' Настройка s06_prim

        ' Настройка s03_cherteg


    End Sub

#End Region

    Protected Overrides Function inputFields() As Boolean
        ' Проверка, выбрано изделие 178 или 132
        ' если выбрано предполакается указать на форме номер машины 132.001 или 178.001, 178.006 и т.д.
        '      If class_izd = "178" Or class_izd = "132" Then
        '          IsEmpty(class_num, class_num_mash)

        '      Else
        '	IsEmpty(class_izd, class_num, class_cbo1, class_cbo2)
        '          class_num_mash = ""
        'End If

        IsEmpty(class14_cbo1, class15_cbo2, class02_num, class01_izd)

        '-----------------------Проверка условий-----------------------------
        'izd  \   num  \  spec  \  dep_zp  \  prim  \

        'Dim sss As String = temp_num + temp_cbo1 + temp_cbo2 + temp_num + "prim"

        ' ===============================================

        spec = ""
        If field14_cbo1.Text = "" Then
            MsgBox("Укажите тип запроса")
            Return False
        ElseIf field14_cbo1.Text = "-" Then
            spec = ""
        Else
            spec = field14_cbo1.Text
        End If

        ' ===============================================

        dep_zp = class15_cbo2

        num = class02_num
        izd = class01_izd
        id_rz_register_doc = Integer.Parse(field16_cbo3.SelectedValue.ToString())

        seria = field13_seria.Text

        prim = "" : temp06_prim = ""
        If Len(field06_prim.Text) > 0 Then
            prim = field06_prim.Text
            temp06_prim = " - (" & field06_prim.Text & ")"
        End If

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        num_doc = spec & "-" & dep_zp & "/" & num & "-" & izd

        Return True

    End Function

    Protected Overrides Sub isFormFields()

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged
        'If field1_izd.Text = "178" Or field1_izd.Text = "132" Then
        '    MoveControls(s01_izd, s02_Num, s04_RZ, s03_Cherteg, s05_NumMash, s06_Prim, s07_OGK)
        'Else
        '    MoveControls(s01_izd, s02_Num, s04_RZ, s03_Cherteg, s06_Prim, s07_OGK)
        'End If
    End Sub



    'Public Overrides Sub SaveDataBaseCurrentClass(dbe As Object, s() As String, ListFilesSave As ArrayList)

    '    Dim db1 As Object = Nothing
    '    Dim db2 As Object = Nothing

    '    Try

    '        dbe.BeginTrans()

	'        db1 = dbe.Workspaces(0).OpenDatabase(path_DataBase & "ServerDBNew.accdb")
    '        'tableNameDataBase
    '        db2 = dbe.Workspaces(0).OpenDatabase(path_DataBase & tableNameDataBase)
	'        'db2 = dbe.Workspaces(0).OpenDatabase(path_DataBase & "ServerDBNew _ZP.accdb")




    '        ref_doc = SaveMoveImageDB(db1, s, Me.name, num_doc, ListFilesSave.Count)

    '        SaveDataBaseCurrentClassImage(db2, ref_doc, tableNameDataBase, ListFilesSave, sSingle)

    '        'SaveMoveImageDB_ZP(db2, ListFilesSave, ref_doc, spec, dep_zp, num, izd, id_rz_register_doc, seria, prim)

    '        db1.Close()
    '        db2.Close()

    '        dbe.CommitTrans()

    '        MsgBox("Запись запроса производства в базу данных прошло успешно")

    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message & Environment.NewLine & "При сохранении в базу данных возникла ошибка. Данные в базе не сохранились")

    '        db1.Close()
    '        db2.Close()

    '        dbe.Rollback()
    '    End Try
    'End Sub

    Sub SaveMoveImageDB_ZP(db As Object, ListFilesSave As ArrayList,
                           ref_doc As Integer,
                           spec As String,
                           dep_zp As String,
                           num As String,
                           izd As String,
                           id_rz_register_doc As Integer,
                           seria As String,
                           prim As String)
        Try

            Dim rsRegisterZPImage As Object
            Dim rs2 As Object
            Dim f2 As Object

            rsRegisterZPImage = db.OpenRecordset("Register_ZP_Image", RecordsetTypeEnum.dbOpenDynaset)

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

            rs2 = rsRegisterZPImage.Fields("image").Value

            For i = 0 To ListFilesSave.Count - 1
                rs2.AddNew()

                Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString()

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

End Class
