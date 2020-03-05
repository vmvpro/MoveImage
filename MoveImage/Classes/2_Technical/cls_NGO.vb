Imports System.Text

Public Class cls_NGO
    Inherits cls_TypeDoc

    Public Overrides Sub initial()
        'initial()
        Initialize()

        isFormLabels()
        isFormFields()

		sSingle = New Control()() {s02_num, s09_dep, s01_izd, s03_cherteg, s06_prim}
		sSingleInputCorrect = New Control()() {s02_num, s09_dep, s01_izd, s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()
        ' num \ dep \ izd \  cherteg \ prim

        mas_SaveImages = New String() {temp02_num, temp09_dep, " - " & temp01_izd, temp03_cherteg}

        mas_SaveFolder = New String() {temp02_num, temp09_dep, " - " & temp01_izd, temp03_cherteg, temp06_prim}

        mas_FullPathFolder = New String() {temp01_izd & "\", temp02_num, temp09_dep, " - " & temp01_izd, temp03_cherteg, temp06_prim}

        'classVariables = New List(Of String)() From {class_num, class_dep, class_izd, class_cherteg, class_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Public Sub New()
        boolDataBase = False

        type_doc = "НГО"
        dirName = "2_Техническая документация\НГО - (Номенклатурный график оснастки)\"
        nameTable_TypeDoc = "tbl_NGO"



    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения
        label01_izd.Text &= "*:"
        label02_num.Text &= "*:"
        label09_dep.Text &= "*:"

    End Sub

    Protected Overrides Sub isFormFields()

        field09_dep.DropDownStyle = ComboBoxStyle.DropDownList
        field09_dep.Items.AddRange(New String() {"ОМО", "ОГМет"})

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

    End Sub

    'Public Event delegateCommand As cmd_SaveEnabledOff

    Protected Overrides Function inputFields() As Boolean
        IsEmpty(class02_num, class01_izd, class09_dep)

        '-----------------------Проверка условий-----------------------------
        'num  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp01_izd = class01_izd

        temp02_num = "НГО " & class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        temp09_dep = ""
        If class09_dep.Length > 0 Then temp09_dep = " " & class09_dep

        Return True

    End Function

   

End Class
