Imports System.Text

Public Class cls_IZV_KOS
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "Извещение КОС"
		dirName = "2_Техническая документация\ИЗВ_КОС - (Извещение по ОСТ)\"

		rootNameDocument = "IZV_KOS"
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

		sSingle = New Control()() {s16_cbo3, s09_dep, s02_num, s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s02_num, s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()
        ' izd num cherteg prim

        mas_SaveImages = New String() {"ИЗВ_КОС " & temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {"ИЗВ_КОС " & temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {"ИЗВ_КОС " & temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s16_cbo3
        field16_cbo3.Name = "group"
        label16_cbo3.Text = "Группа:*"

        field16_cbo3.DropDownStyle = ComboBoxStyle.DropDown
        Dim cbo3() As String = New String() {"", "И624"}
        field16_cbo3.Items.AddRange(cbo3)

        ' Настройка s09_Dep
        field09_dep.Name = "dep"
        label09_dep.Text = "Отдел:*"

        field09_dep.DropDownStyle = ComboBoxStyle.DropDown
        Dim cbo5() As String = New String() {"", "060"}
        field09_dep.Items.AddRange(cbo5)

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

        IsEmpty(class16_cbo3, class09_dep, class02_num)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num  \  cherteg  \  prim

        temp16_cbo3 = class16_cbo3


        temp09_dep = class09_dep

        temp02_num = class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class16_cbo3 & "-" & class09_dep & "-" & class02_num)

        Return True

    End Function

   

End Class

