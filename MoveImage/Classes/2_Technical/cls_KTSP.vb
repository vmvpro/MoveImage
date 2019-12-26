Imports System.Text

Public Class cls_KTSP
    Inherits cls_TypeDoc
    'Protected Overrides

    Public Overrides Sub initial()
        'initial()
        Initialize()

        isFormLabels()
        isFormFields()

        sSingle = New Control()() {s02_num, s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s02_num, s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()

        mas_SaveImages = New String() {temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}


        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Public Sub New()
        boolDataBase = False

        type_doc = "КТСП"
        dirName = "2_Техническая документация\КТСП - (Карта технологического согласования поставки)\КТСП (Подписанные)\"
        nameTable_TypeDoc = "tbl_KTSP"

    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения
        label02_num.Text = "Номер КТСП:"

    End Sub

    Protected Overrides Sub isFormFields()

        'field9_Dep.Items.AddRange(New String() {"ОМО", "ОГМет"})

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

    End Sub

    'Public Event delegateCommand As cmd_SaveEnabledOff

    Protected Overrides Function inputFields() As Boolean
        'IsEmpty(class_num, class_izd, class_dep)

        If class02_num = "" And class03_cherteg = "" Then Throw New Exception("Должно хоть одно поле быть заполненным обязательно: Номер КТСП или Чертеж")

        '-----------------------Проверка условий-----------------------------
        'num  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp02_num = ""
        If class02_num.Length > 0 Then temp02_num = "КТСП " & class02_num Else temp02_num = ""

        temp03_cherteg = ""

        If class03_cherteg.Length > 0 Then
            If class02_num.Length > 0 Then temp03_cherteg = " - " & class03_cherteg Else temp03_cherteg = "КТСП " & class03_cherteg
        End If

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        Return True
    End Function

  

End Class
