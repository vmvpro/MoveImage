Imports System.Text

Public Class cls_PSO
    Inherits cls_TypeDoc

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
        ' izd num cherteg prim

        mas_SaveImages = New String() {temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Public Sub New()
        boolDataBase = False

        type_doc = "ПШО"
        dirName = "2_Техническая документация\ПШО - (Плазово-шаблонна оснастка)\"
        nameTable_TypeDoc = "tbl_PSO"



    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        label02_num.Text &= "*"

    End Sub

    Protected Overrides Sub isFormFields()

        'field4_RZ.Items.Add("")

    End Sub


    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

    End Sub

    Protected Overrides Function inputFields() As Boolean
        IsEmpty(class02_num)


        '-----------------------Проверка условий-----------------------------
        'izd  \  num  \  cherteg  \  prim

        temp02_num = "ПШО " & class02_num

        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        Return True

    End Function

    

End Class

