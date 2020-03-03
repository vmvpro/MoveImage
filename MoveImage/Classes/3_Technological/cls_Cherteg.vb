Imports System.Text

Public Class cls_Cherteg
	Inherits cls_TypeDoc

    Public Overrides Sub initial()
        'initial()
        Initialize()

        isFormLabels()
        isFormFields()

        sSingle = New Control()() {s03_cherteg, s06_prim}
        sSingleInputCorrect = New Control()() {s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

	Protected Overrides Sub defineName()

        mas_SaveImages = New String() {temp03_cherteg, temp06_prim}
        mas_SaveFolder = New String() {temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Public Sub New()
        boolDataBase = False

        type_doc = "Чертеж"
        dirName = "3_Технологическая документация\Ч - (Чертежи)\Номера чертежей\"
        nameTable_TypeDoc = "tbl_Cherteg"

    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения
        'label1_Izd.Text &= "*:"
        'label2_Num.Text &= "*:"
        'label5_NumMash.Text &= "*:"

        label06_prim.Text = "Наименование чертежа:"

    End Sub

    Protected Overrides Sub isFormFields()

        'field4_RZ.Items.Add("")

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

        'If field1_Izd.Text = "178" Or field1_Izd.Text = "132" Then
        '	MoveControls(s01_Izd, s02_Num, s04_RZ, s03_Cherteg, s05_NumMash, s06_Prim, s07_OGK)
        'Else
        '	MoveControls(s01_Izd, s02_Num, s04_RZ, s03_Cherteg, s06_Prim, s07_OGK)
        'End If
    End Sub

    Protected Overrides Function inputFields() As Boolean
        ' Проверка, выбрано изделие 178 или 132
        ' если выбрано предполакается указать на форме номер машины 132.001 или 178.001, 178.006 и т.д.

        IsEmpty(class03_cherteg)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        'temp_izd = class_izd & "\"

        temp03_cherteg = class03_cherteg


        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - " & class06_prim

        Return True


    End Function

    


End Class

