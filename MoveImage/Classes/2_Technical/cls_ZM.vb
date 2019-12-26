Imports System.Text

Public Class cls_ZM
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "СЗ на замену материала"
		dirName = "2_Техническая документация\ЗМ - (Служебная записка на замену материала)\"
		
		rootNameDocument = "ZM"
		nameDataBase = "ServerDBNew_" & rootNameDocument & ".accdb"
        nameTable_TypeDoc = "Register_" & rootNameDocument & "_NotImage"

		nameDataBase_Image = "ServerDBNew_Image_" & rootNameDocument
        nameTable_Image = "Register_" & rootNameDocument & "_ImageOne"


	End Sub

    Public Overrides Sub initial()
        'initial()
        Initialize()

        isFormLabels()
        isFormFields()

		sSingle = New Control()() {s01_izd, s09_dep, s02_num, s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s01_izd, s02_num, s03_cherteg, s06_prim}

        field_isControlsLoad = True

    End Sub

	Protected Overrides Sub defineName()
		' izd \ num \ PI \ cherteg \ prim

        mas_SaveImages = New String() {"ЗМ ", temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {"ЗМ ", temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp01_izd, "\", "ЗМ ", temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s01_izd
        label01_izd.Text &= "*"
        load_izd_shifr(cls_TypeDoc.path_DataBase, field01_izd)


        ' Настройка s09_dep
        label09_dep.Text &= "*"

        field09_dep.DropDownStyle = ComboBoxStyle.DropDown
        Dim range() As String = New String() {"", "КОС", "ВО", "Г", "ДТО", "СНО", "СУ", "Ф1", "Ф3", "ШУ"}
        field09_dep.Items.AddRange(range)

        ' Настройка s02_num

        label02_num.Text &= "*"

        ' Настройка s03_cherteg

        ' Настройка s06_prim



    End Sub

    Protected Overrides Sub isFormFields()

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
        IsEmpty(class01_izd, class09_dep, class02_num)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp01_izd = class01_izd

        temp09_dep = class09_dep

        temp02_num = class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class01_izd & "-" & class09_dep & "-" & class02_num)

        Return True

    End Function

  



End Class

