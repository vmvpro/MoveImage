Imports System.Text

Public Class cls_USP
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = False

        nameGroup = "Техническая"
        type_doc = "УСП"
		dirName = "2_Техническая документация\УСП - (Унивирсальное сборочное приспособление)\УСП - (ТБ ц.23)\"
		
		rootNameDocument = "USP"
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

        sSingle = New Control()() {s03_cherteg, s08_pi, s06_prim}
        sSingleInputCorrect = New Control()() {s03_cherteg, s08_pi, s06_prim}

        field_isControlsLoad = True
    End Sub

	Protected Overrides Sub defineName()
		' izd \ num \ PI \ cherteg \ prim

        mas_SaveImages = New String() {temp03_cherteg, temp08_pi}
        mas_SaveFolder = New String() {temp03_cherteg, temp08_pi, temp06_prim}
        mas_FullPathFolder = New String() {temp03_cherteg, temp08_pi, temp06_prim}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)
    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()

    End Sub

    Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения
        label03_Cherteg.Text &= "*"

    End Sub

    Protected Overrides Sub isFormFields()
        field08_pi.Items.Clear()
        field08_pi.Items.AddRange(New String() {"Контрольная", "Разметочная", "Расточная", "Сверлильная", "Слесарная", "Токарная", "Фрезерная", "Фрезерная с ЧПУ", "Центровальная"})
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
        IsEmpty(class03_cherteg)

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp03_cherteg = "УСП " & class03_cherteg

        temp08_pi = ""
        If class08_pi.Length > 0 Then temp08_pi = " - " & class08_pi

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"

        Return True
    End Function

    

End Class

