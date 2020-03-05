﻿Imports System.Text
Public Class cls_Order
	Inherits cls_TypeDoc

	Public Sub New()
		boolDataBase = True

		nameGroup = "Административная"
		type_doc = "Приказ"
		'type_docRange = New String() {"Распоряжение", "Розпорядження"}
		dirName = "1_Административная документация\Приказы\"

		rootNameDocument = "Order"
		nameDataBase = "ServerDBNew_" & rootNameDocument & ".accdb"
		nameTable_TypeDoc = "Register_" & rootNameDocument & "_NotImage"

		nameDataBase_Image = "ServerDBNew_Image_" & rootNameDocument
		nameTable_Image = "Register_" & rootNameDocument & "_ImageOne"

		' izd \ num \ PI \ cherteg \ prim

	End Sub
	Public Overrides Sub initial()
		'initial()
		'classFormation()
		Initialize()

		isFormLabels()
		isFormFields()

        sSingle = New Control()() {s02_num, s11_Dates, s18_txt1, s19_txt2, s06_prim}
        sSingleInputCorrect = New Control()() {s02_num, s11_Dates, s18_txt1}

		field_isControlsLoad = True
	End Sub

	Protected Overrides Sub field2_Num_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) _
		 Handles field02_num.KeyDown

		e.SuppressKeyPress = True

		nonNumberEntered = True

		' Пропускаем цифровые кнопки
		'If (e.KeyCode >= Keys.D0) And (e.KeyCode <= Keys.D9) Then e.SuppressKeyPress = False
		' Пропускаем цифровые кнопки с NumPad'а
		'If (e.KeyCode >= Keys.NumPad0) And (e.KeyCode <= Keys.NumPad9) Then e.SuppressKeyPress = False
		' Пропускаем Delete, Back, Left и Right
		'If (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back) Or (e.KeyCode = Keys.Left) Or (e.KeyCode = Keys.Right) Or (e.KeyCode = Keys.Subtract) Or (e.KeyCode = 189) Then e.SuppressKeyPress = False

		If (e.KeyCode >= Keys.D0) And (e.KeyCode <= Keys.D9) Then
			e.SuppressKeyPress = False
			nonNumberEntered = False
		End If

		If (e.KeyCode >= Keys.NumPad0) And (e.KeyCode <= Keys.NumPad9) Then
			e.SuppressKeyPress = False
			nonNumberEntered = False
		End If

		If (e.KeyCode = Keys.Delete) Or (e.KeyCode = Keys.Back) Or (e.KeyCode = Keys.Left) Or (e.KeyCode = Keys.Right) Or (e.KeyCode = Keys.Subtract) Or (e.KeyCode = 189) Or (e.KeyCode = 190) Or (e.KeyCode = 191) Then
			e.SuppressKeyPress = False
			nonNumberEntered = False
		End If


	End Sub

	Protected Overrides Sub isFormLabels()
        ' Добавление к полям звездочек для обозначения важности их заполнения

        ' Настройка s02_num
        field02_num.Name = "num"
		label02_num.Text = "Номер в документе*:"

        ' Настройка s11_Dates 
        field11_dates.Name = "dates_doc"
        label11_dates.Text &= "*"

        ' Настройка s18_txt1 
        label18_txt1.Text = "Примечание для файла (кратко):"

        ' Настройка s19_txt2
        label19_txt2.Text = "Тег(для поиска через '; '):"
        field19_txt2.Name = "tag"

        ' Настройка s06_prim 
        label06_prim.Text = "Примечание для базы данных Access:"

    End Sub

    Protected Overrides Sub FinalSettigControlsInForm()
        s06_prim(0).Top += 7
        s06_prim(0).Width = LeftField + WidthField - LeftLabel

        s06_prim(1).Left = LeftLabel
        'field06_prim.Left = LeftLabel
        s06_prim(1).Width = LeftField + WidthField - LeftLabel
        s06_prim(1).Top = s06_prim(0).Top + s06_prim(1).Height
        s06_prim(1).Height *= 3

        field06_prim.Multiline = True
    End Sub

	Protected Overrides Sub isFormFields()


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

        IsEmpty(class02_num, class11_dates)

        temp19_txt2 = ""
        If class19_txt2.Length > 0 Then
            If (Not isValidText(class19_txt2, "; ")) Then
                MessageBox.Show(cls_TypeDoc.tag, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return False
            End If
        End If

        '-----------------------Проверка условий-----------------------------
        'izd  \  num_mash  \  num  \  rz  \  cherteg  \  prim

        temp02_num = class02_num

        '-----------НАЧАЛО - Обработка даты--------------------------------


        Dim str As String = field11_dates.Value.ToShortDateString

        Dim dd As String = str.Substring(0, 2)
        Dim mm As String = str.Substring(3, 2)
        Dim yy As String = str.Substring(8, 2)

        dates_doc_string = mm & "/" & dd & "/" & yy
        temp11_dates = dd & "." & mm & "." & yy
        dates_doc_date = Date.Parse(field11_dates.Value.ToShortDateString)
        '-----------КОНЕЦ - Обработка даты--------------------------------

        temp18_txt1 = ""
        If class18_txt1.Length > 0 Then temp18_txt1 = " - (" & class18_txt1 & ")"

        temp06_prim = ""
        If class06_prim.Length > 0 Then temp06_prim = " - (" & class06_prim & ")"


        num_doc = class02_num
        ' Д 40041.29482 ПИ
        'num_doc = Trim(preffix & izd_shifr & group & "." & [num] & suffix)

        Return True
    End Function

    Protected Overrides Sub defineName()
        ' izd \ num \ PI \ cherteg \ prim

        mas_SaveImages = New String() {"П ", temp02_num, " от ", temp11_dates}
        mas_SaveFolder = New String() {"Приказ ", temp02_num, " от ", temp11_dates, temp18_txt1}
        mas_FullPathFolder = New String() {field11_dates.Value.Year & "\", "Приказ ", temp02_num, " от ", temp11_dates, temp18_txt1}

        str_SaveImages = RenamingStrings(mas_SaveImages)
        str_SaveFolder = RenamingStrings(mas_SaveFolder)
        str_FullPathFolder = RenamingStrings(mas_FullPathFolder)

    End Sub
End Class
