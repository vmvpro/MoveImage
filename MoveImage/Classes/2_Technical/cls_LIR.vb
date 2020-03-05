Imports System.Text

Public Class cls_LIR
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "ЛИР"
		dirName = "2_Техническая документация\ЛИР - (Лист изменения расцеховки)\"

		rootNameDocument = "IZV_LIR"
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

        sSingle = New Control()() {s01_izd, s02_num, s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s01_izd, s02_num, s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()
        ' izd num cherteg prim

        mas_SaveImages = New String() {"ЛИР ", temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {"ЛИР ", temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp01_izd, "\", "ЛИР ", temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s01_izd
        label01_izd.Text = "Изделие:*"
        load_izd_shifr(cls_TypeDoc.path_DataBase, field01_izd)

        ' Настройка s02_num
        label02_num.Text &= "*"

        ' Настройка s03_cherteg

        ' Настройка s06_prim

    End Sub

    Protected Overrides Sub isFormFields()

        'field4_RZ.Items.Add("")

    End Sub


    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

    End Sub

    Protected Overrides Function inputFields() As Boolean
        IsEmpty(class01_izd, class02_num)

        temp01_izd = class01_izd

        '-----------------------Проверка условий-----------------------------
        'izd  \  num  \  cherteg  \  prim

        temp02_num = class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class02_num & "/" & class01_izd)

        Return True

    End Function

    

End Class

