Imports System.Text

Public Class cls_SKN
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "СКН"
		dirName = "2_Техническая документация\СКН - (Сигнал конструктивной неувязки)\"

		rootNameDocument = "SKN"
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

        sSingle = New Control()() {s01_izd, s12_izd_shifr, s02_num, s03_cherteg, s13_seria, s06_prim}

        sSingleInputCorrect = New Control()() {s12_izd_shifr, s02_num, s06_prim, s03_cherteg}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()
        ' izd num cherteg prim

        mas_SaveImages = New String() {temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp12_izd_shifr & "\", temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s01_izd
        label01_izd.Text = "На какие изделия относится СКН:*"
        load_izd(cls_TypeDoc.path_DataBase, field01_izd)

        ' Настройка s12_izd_shifr
        label12_izd_shifr.Text = "Шифр изделия в документе:*"
        load_izd_shifr(cls_TypeDoc.path_DataBase, field12_izd_shifr)

        ' Настройка s02_num
        label02_num.Text &= "*"

        ' Настройка s03_cherteg


        ' Настройка s13_seria
        label13_seria.Text &= "*"

        ' Настройка s06_prim
        label12_izd_shifr.Text &= "*"

    End Sub

    Protected Overrides Sub isFormFields()

        'field4_RZ.Items.Add("")

    End Sub


    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

    End Sub

    Protected Overrides Function inputFields() As Boolean
        IsEmpty(class12_izd_shifr, class01_izd, class02_num, class13_seria)


        '-----------------------Проверка условий-----------------------------
        'izd  \  num  \  cherteg  \  prim

        temp01_izd = class01_izd

        temp12_izd_shifr = class12_izd_shifr

        temp02_num = "СКН " & class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class02_num & "/" & class12_izd_shifr)

        Return True
    End Function

   

End Class

