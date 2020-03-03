Imports System.Text

Public Class cls_RZ
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "Служебная записка РЗ"
		dirName = "2_Техническая документация\РЗ - (Служебная записка РЗ)\"

		rootNameDocument = "RZ"
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

		sSingle = New Control()() {s01_izd, s02_num, s03_cherteg, s13_seria, s06_prim}
        sSingleInputCorrect = New Control()() {s01_izd, s02_num, s03_cherteg, s06_prim}

        field_isControlsLoad = True
    End Sub

    Protected Overrides Sub defineName()

        mas_SaveImages = New String() {temp02_num, temp03_cherteg}
        mas_SaveFolder = New String() {temp02_num, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {temp01_izd, temp02_num, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)

    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения


        label01_izd.Text &= "*"
        label02_num.Text &= "*"


    End Sub

    Protected Overrides Sub isFormFields()

        load_izd_shifr(cls_TypeDoc.path_DataBase, field01_izd)
        'field4_RZ.Items.Add("")

    End Sub

    'При изменении ComboBox на форме
    Public Sub Change_Izd() Handles field01_izd.SelectedIndexChanged

        'If field1_Izd.Text = "178" Or field1_Izd.Text = "132" Then
        '	MoveControls(s1_Izd, s2_Num, s4_RZ, s3_Cherteg, s5_NumMash, s6_Prim, s7_OGK)
        'Else
        '	MoveControls(s1_Izd, s2_Num, s4_RZ, s3_Cherteg, s6_Prim, s7_OGK)
        'End If
    End Sub

    Protected Overrides Function inputFields() As Boolean
        ' Проверка, выбрано изделие 178 или 132
        ' если выбрано предполакается указать на форме номер машины 132.001 или 178.001, 178.006 и т.д.

        IsEmpty(class01_izd, class02_num)

        '-----------------------Проверка условий-----------------------------
        'izd  \   num   \  cherteg  \  prim

        temp01_izd = class01_izd & "\"

        temp02_num = "РЗ " & class02_num

        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class02_num & "/" & class01_izd)

        Return True
    End Function

   



End Class
