Imports System.Text

Public Class cls_IZV
    Inherits cls_TypeDoc

	Public Sub New()
        boolDataBase = False

        nameGroup = "Техническая"
        type_doc = "Извещение"
		dirName = "2_Техническая документация\ИЗВ - (Извещения)\Извещения (Предприятия)\"

		rootNameDocument = "IZV"
		nameDataBase = "ServerDBNew_" & rootNameDocument & ".accdb"
        nameTable_TypeDoc = "Register_" & rootNameDocument & "_NotImage"

		nameDataBase_Image = "ServerDBNew_Image_" & rootNameDocument
        nameTable_Image = "Register_" & rootNameDocument & "_ImageOne"


		' izd \ num \ PI \ cherteg \ prim

	End Sub

    Public Overrides Sub initial()
        'initial()
        'classFormation()
        Initialize()

        isFormLabels()
        isFormFields()

        sSingle = New Control()() {s01_izd, s14_cbo1, s12_izd_shifr, s16_cbo3, s02_num, s08_pi, s13_seria, s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s02_num, s08_pi, s06_prim, s03_cherteg}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
		' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s01_izd
        label01_izd.Text = "На какие изделия:*"
        load_izd(cls_TypeDoc.path_DataBase, field01_izd)

        ' Настройка s14_cbo1 - preffix
        label14_cbo1.Text = "Дополнительно:"
        field14_cbo1.Name = "preffix"
        Dim cbo1() As String = New String() {"", "Д"}
        field14_cbo1.Items.AddRange(cbo1)

        ' Настройка s12_izd_shifr
        label12_izd_shifr.Text &= "Шифр изделия:*"

        ' Настройка s16_cbo3 - group
        label16_cbo3.Text = "Группа УГК:*"
        field16_cbo3.Name = "group"
        field16_cbo3.DropDownStyle = ComboBoxStyle.DropDown
        Dim cbo3() As String = New String() {"", "40", "41", "56", "57", "58", "61", "62", "97", "БОР", "ЭТД"}
        field16_cbo3.Items.AddRange(cbo3)

        ' Настройка s2_num
        label02_num.Text &= "*"

        ' Настройка s08_pi - Назначение
        label08_pi.Text = "Назначение:"
        field08_pi.Name = "suffix"
        Dim sPi() As String = New String() {"", "ПИ", "Д", "ДПИ", "БОР", "ЭТД", "ПКИ"}
		field08_pi.Items.AddRange(sPi)

		' Настройка s13_seria
		label13_seria.Text &= "*"

        ' Настройка s03_cherteg - Чертеж




    End Sub

    Protected Overrides Sub isFormFields()

        'field4_RZ.Items.Add("")
        'field12_izd_shifr.Items.AddRange(ListIzdShifr)
        'field1_izd.Items.Clear()




        'field12_izd_shifr.Items.Clear()
        load_izd_shifr(cls_TypeDoc.path_DataBase, field12_izd_shifr)

        field08_pi.Name = "suffix"
        'load_izd_shifr(cls_TypeDoc.path_DataBase, field15_cbo2)

        

        'field15_cbo2.DataSource = ""

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

        'If field1_Izd.Text = "178" Or field1_Izd.Text = "132" Then
        'MoveControls(s1_Izd, s2_Num, s4_RZ, s3_Cherteg, s5_NumMash, s6_Prim, s7_OGK)
        'Else
        'MoveControls(s1_Izd, s2_Num, s4_RZ, s3_Cherteg, s6_Prim, s7_OGK)
        'End If
    End Sub

    Protected Overrides Function inputFields() As Boolean
        ' Проверка, выбрано изделие 178 или 132
        ' если выбрано предполакается указать на форме номер машины 132.001 или 178.001, 178.006 и т.д.
        IsEmpty(class01_izd, class12_izd_shifr, class16_cbo3, class02_num, class13_seria)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim
        Dim preffix As String = ""
        If Len(class14_cbo1) > 0 Then preffix = class14_cbo1 & " "

        temp01_izd = class01_izd

        temp12_izd_shifr = class12_izd_shifr
        Dim izd_shifr As String = temp12_izd_shifr

        Dim group As String = class16_cbo3

        Dim num As String = class02_num
        temp02_num = "ИЗВ " & class02_num

        Dim suffix As String = ""
        temp08_pi = ""
        If class08_pi.Length > 0 Then
            temp08_pi = " " & class08_pi
            suffix = " " & class08_pi
        End If

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        ' Д 40041.29482 ПИ
        num_doc = Trim(preffix & izd_shifr & group & "." & [num] & suffix)

        Return True
    End Function

    Protected Overrides Sub defineName()
        ' izd \ num \ PI \ cherteg \ prim

        mas_SaveImages = New String() {temp02_num, temp08_pi, temp03_cherteg}
        mas_SaveFolder = New String() {temp02_num, temp08_pi, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp12_izd_shifr & "\", temp02_num, temp08_pi, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)

    End Sub
    


End Class

