Imports System.Text

Public Class cls_BPPP
    Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

        nameGroup = "Техническая"
        type_doc = "Служебная записка БППП"
		dirName = "2_Техническая документация\БППП - (Служебная записка БППП)\"
		
		rootNameDocument = "BPPP"
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

		sSingle = New Control()() {s02_num, s14_cbo1, s10_Years, s06_prim}
		sSingleInputCorrect = New Control()() {s02_num, s10_Years, s06_prim}

		field_isControlsLoad = True
	End Sub

    Protected Overrides Sub defineName()
        ' izd \ num \ PI \ cherteg \ prim

        '2118 БППП - 15\

        mas_SaveImages = New String() {"БППП " & temp02_num, temp14_cbo1, temp10_years, temp03_cherteg}
        mas_SaveFolder = New String() {"БППП " & temp02_num, temp14_cbo1, temp10_years, temp03_cherteg, temp06_prim}
        mas_FullPathFolder = New String() {"БППП " & temp02_num, temp14_cbo1, temp10_years, temp03_cherteg, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub


    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Добавление к полям звездочек для обозначения важности их заполнения


        ' Настройка s02_num
        label02_num.Text &= "*"

        ' Настройка field10_years
        label10_years.Text &= "*"
        field10_years.DropDownStyle = ComboBoxStyle.DropDownList


        ' Настройка s14_cbo1 - let
        label14_cbo1.Text = "Назначение:"
        field14_cbo1.Name = "let"
        field14_cbo1.DropDownStyle = ComboBoxStyle.DropDownList
        Dim range() As String = New String() {"", "А"}
        field14_cbo1.Items.AddRange(range)



        ' Настройка s03_cherteg - Чертеж

        ' Настройка s06_prim

    End Sub

    Protected Overrides Sub isFormFields()
        'field08_pi.Items.Clear()

        'field08_pi.Items.Add("")
        'field08_pi.Items.Add("A")
        'field08_pi.Items.Add("(3)")
        'field08_pi.Items.Add("(А)")

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
        IsEmpty(class02_num, class10_years)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp02_num = class02_num

        temp14_cbo1 = ""
        If class14_cbo1.Length > 0 Then temp14_cbo1 = class14_cbo1

        temp10_years = "-" & class10_years


        temp03_cherteg = ""
        If class03_cherteg.Length > 0 Then temp03_cherteg = " - " & class03_cherteg

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        num_doc = Trim(class02_num & "/БППП-" & class10_years)

        Return True

    End Function

    



End Class

