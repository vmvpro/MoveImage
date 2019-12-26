Imports System.Text.RegularExpressions
Imports System.Text
Imports CheckComboBox

Partial Class cls_TypeDoc

    '#Region "    Объявление Элементов управления						"

    ' Координаты элементов управления
    Protected LeftLabel As Integer = 3
    Protected WidthLabel As Integer = 162
    Protected HeightLabel As Integer = 13

    Protected LeftField As Integer = 170    ' width 337
    Protected WidthField As Integer = 167
    Protected HeightField As Integer = 21

    ''' <summary>
    ''' Какие Control-ы отображаются на форме, в момент выбора конкретного типа документа и в какой последовательности
    ''' </summary>
    ''' Объявление Массива-контролов
    Public sSingle()() As Control

    ''' <summary>
    ''' Control-ы которые загружаются вначале при загрузке определенного класса
    ''' </summary>
    ''' Объявление Массива-контролов
    Public sSingleLoad()() As Control

    ''' <summary>
    ''' Контролы которые требуется проверить и которые участвуют в сохранении и требуется обезопасить от запрещенных символов
    ''' </summary>
    ''' <remarks></remarks>
    Public sSingleInputCorrect()() As Control

    'Отсчет начинается с 3
    '39-64=25
    '39-90=51
    '64-90=26
    '64-115=51
    '90-115=25
	'Protected LocationY() As Integer = New Integer() {13,
	'												  39, 64,
	'												  90, 115,
	'												  141, 166,
	'												  192, 217,
	'												  233, 258,
	'												  284, 309,
	'												  335, 360,
	'												  386, 411,
	'												  437, 462,
	'												  488, 513}

    ' Наименование Label-ов на форме
    'Protected labelText() As String = New String() {"Шифр изделия в документе:",
    '                                                "Номер документа:",
    '                                                "Номер чертежа:",
    '                                                "Номер РЗ:",
    '                                                "Номер машины:",
    '                                                "Примечание:",
    '                                                "Отдел ОГК:",
    '                                                "Назначение:",
    '                                                "Отдел:",
    '                                                "Год:",
    '                                                "Дата:",
    '                                                "Шифр изделия:",
    '                                                "Серия:",
    '                                                "comboBox1:",
    '                                                "comboBox2:",
    '                                                "comboBox3:"}
    '												16



    ''' <summary>
    ''' Лист предназначен для содержимого переменных класса с префиксом class. Содержимое переменных зависит от конкретного класса 
    ''' </summary>
    ''' <remarks></remarks>
    Protected classVariables As List(Of String)

    Sub testEnabled()
        If (delegateFlag) Then
            cmdSave_EnabledOFF()
            delegateFlag = False
        End If
    End Sub

#Region "    Номер 1 - izd - (Изделие) - ComboBox   "
    '   Номер 1
    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class01_izd As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp01_izd As String

    Protected s01_izd() As Control
    Protected WithEvents label01_izd As New Label
    Public WithEvents field01_izd As New ComboBox

    Sub SettingsControl_01_izd()
        label01_izd.Name = "izd"
        label01_izd.Text = "Шифр изделия в документе:"

        field01_izd.Name = "izd"

        ' Загрузка Поумолчанию
        'field1_izd.DropDownStyle = ComboBoxStyle.DropDown
        Dim ListIzd() As String = New String() {"24", "26", "32", "70", "132", "148", "158", "178", "400"}
        field01_izd.Items.AddRange(ListIzd)
        'load_izd(cls_TypeDoc.path_DataBase, field1_izd)

    End Sub


    Protected Sub field1_izd_Click() Handles field01_izd.SelectedIndexChanged
        class01_izd = field01_izd.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 2 - num - (Номер документа) - TextBox   "
    '   Номер 2
    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class02_num As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp02_num As String

    ''' <summary>
    ''' Массив с контролов - Номер (Label и TextBox)
    ''' </summary>
    ''' <remarks></remarks>
    Protected s02_num() As Control
    Protected label02_num As New Label

    ''' <summary>
    ''' поле num
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field02_num As New TextBox

    Sub SettingsControl_02_num()
        label02_num.Name = "num"
        label02_num.Text = "Номер документа:"

        field02_num.Name = "num"
    End Sub



    'Protected Sub TextChanged2() Handles field2_Num.TextChanged

    'End Sub

    Dim s As String = ""

    Protected nonNumberEntered As Boolean = False

    Protected messegaError As String = "В это поле требуется вводить только цифры" & vbNewLine &
                                       "Если требуется написать какие-то пометки - используйте примечание!"

    ' Handle the KeyDown event to determine the type of character entered into the control.
    Protected Overridable Sub field2_Num_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) _
         Handles field02_num.KeyDown

        nonNumberEntered = False

        If e.KeyCode < Keys.D0 OrElse e.KeyCode > Keys.D9 Then
            If e.KeyCode < Keys.NumPad0 OrElse e.KeyCode > Keys.NumPad9 Then
                If e.KeyCode <> Keys.Back Then
                    nonNumberEntered = True
                End If
            End If
        End If

        If Control.ModifierKeys = Keys.Shift Then
            nonNumberEntered = True
        End If
    End Sub

    Protected Sub field2_Num_KeyPress(obj As Object, e As KeyPressEventArgs) Handles field02_num.KeyPress
        testEnabled()

        If nonNumberEntered = True Then
            e.Handled = True
            MessageBox.Show(messegaError,
                            "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

    End Sub

    Protected Function IsDigitString(text As String) As Boolean
        Return Regex.IsMatch(text, "[0-9]*")
    End Function
#End Region

#Region "    Номер 3 - cherteg - (Номера чертежей) - ComboBox    "

    '   Номер 3
    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class03_cherteg As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp03_cherteg As String

    Protected s03_cherteg() As Control
    Protected label03_Cherteg As New Label

    ''' <summary>
    ''' поле cherteg
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field03_cherteg As New ComboBox

    Sub SettingsControl_03_cherteg()
        label03_Cherteg.Name = "cherteg"
        label03_Cherteg.Text = "Номер чертежа:"

        field03_cherteg.Name = "cherteg"

        Dim sCherteg() As String = New String() {"132.00.", "132.96.", "148.00.", "178.00.", "1.4000."}
        field03_cherteg.Items.AddRange(sCherteg)
    End Sub

    Protected Sub TextChanged3() Handles field03_cherteg.TextChanged
        class03_cherteg = field03_cherteg.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 4 - rz - (rz) - ComboBox   "

    '   Номер 4
    Protected s04_RZ() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class04_rz As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp04_rz As String

    Protected label04_rz As New Label

    ''' <summary>
    ''' поле rz (ComboBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field04_rz As New ComboBox

    Sub SettingsControl_04_rz()
        label04_rz.Name = "rz"
        label04_rz.Text = "Номер РЗ:"

        field04_rz.Name = "rz"

        Dim sRZ() As String = New String() {"РЗ_", "РЗ_ _", "ИЗВ_", "ИЗВ_123"}
        field04_rz.Items.AddRange(sRZ)
    End Sub

    Protected Sub TextChanged4() Handles field04_rz.TextChanged
        class04_rz = field04_rz.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 5 - num_mash - (Номер машины) - ComboBox   "

    '   Номер 5
    Protected s05_NumMash() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class05_num_mash As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp05_num_mash As String

    Protected label05_num_mash As New Label

    ''' <summary>
    ''' поле num_mash (ComboBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field05_num_mash As New ComboBox

    Sub SettingsControl_05_num_mash()
        label05_num_mash.Name = "num_mash"
        label05_num_mash.Text = "Номер машины:"

        field05_num_mash.Name = "num_mash"

        field05_num_mash.DropDownStyle = ComboBoxStyle.DropDownList
        Dim sNumMash() As String = New String() {"001", "002", "003", "004", "005", "006", "007", "008", "009", "010", "011", "012", "013", "014", "000"}
        field05_num_mash.Items.AddRange(sNumMash)
    End Sub

    Protected Sub TextChanged5() Handles field05_num_mash.TextChanged
        class05_num_mash = field05_num_mash.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 6 - prim - (Примечание) - TextBox   "

    '   Номер 6 
    Protected s06_prim() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class06_prim As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp06_prim As String

    Protected label06_prim As New Label

    ''' <summary>
    ''' поле prim (TextBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field06_prim As New TextBox

    Sub SettingsControl_06_prim()
        label06_prim.Name = "prim"
        label06_prim.Text = "Примечание:"

        field06_prim.Name = "prim"
    End Sub

    Protected Sub TextChanged6() Handles field06_prim.TextChanged
        class06_prim = field06_prim.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 7 - ogk - (Отдел для запроса производства) - CheckBox  "

    '   Номер 7
    Protected s07_OGK() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class07_ogk As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp07_ogk As String

    Protected label07_OGK As New Label

    ''' <summary>
    ''' поле ogk (TextBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field07_OGK As New CheckBox

    Sub SettingsControl_07_ogk()
        label07_OGK.Name = "ogk"
        label07_OGK.Text = "Отдел ОГК:"

        field07_OGK.Name = "ogk"
    End Sub

    Protected Sub TextChanged7() Handles field07_OGK.CheckedChanged
        class07_ogk = field07_OGK.CheckState.ToString
        testEnabled()
    End Sub

#End Region

#Region "    Номер 8 - pi - (Назначение извещения суфикс) - ComboBox   "

    '   Номер 8
    Protected s08_pi() As Control

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected class08_pi As String
    Protected temp08_pi As String

    Protected label08_pi As New Label

    ''' <summary>
    ''' поле izv_pi (ComboBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field08_pi As New ComboBox

    Sub SettingsControl_08_pi()
        label08_pi.Name = "pi"
        label08_pi.Text = "Назначение:"

        field08_pi.Name = "pi"

        'Dim sPi() As String = New String() {"", "ПИ", "Д", "ДПИ", "БОР", "ЭТД", "ПКИ"}
        'field08_pi.Items.AddRange(sPi)
    End Sub

    Protected Sub TextChanged8() Handles field08_pi.TextChanged
        testEnabled()
    End Sub

#End Region

#Region "    Номер 9 - dep - (Отдел) - ComboBox   "

    '   Номер 9
    Protected s09_dep() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class09_dep As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp09_dep As String

    Protected label09_dep As New Label

    ''' <summary>
    ''' поле num_mash (ComboBox)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field09_dep As New ComboBox

    Sub SettingsControl_09_dep()
        label09_dep.Name = "dep"
        label09_dep.Text = "Отдел:"

        field09_dep.Name = "dep"
    End Sub

    Protected Sub TextChanged9() Handles field09_dep.TextChanged
        class09_dep = field09_dep.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 10 - years - (Год) - ComboBox   "

    '   Номер 10
    Protected s10_Years() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class10_years As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp10_years As String

    Protected label10_years As New Label
    Public WithEvents field10_years As New ComboBox

    Sub SettingsControl_10_years()
        label10_years.Name = "years"
        label10_years.Text = "Год:"

        field10_years.Name = "years"

        Dim sYears() As String = New String() {"14", "15", "16", "17", "18", "19", "20"}
        field10_years.Items.AddRange(sYears)
    End Sub

    Protected Sub TextChanged10() Handles field10_years.TextChanged
        class10_years = field10_years.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 11 - dates - (Дата) - DateTimePicker   "

    '   Номер 11
    Protected s11_Dates() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола. Короткую запись видв 12.12.12
    ''' </summary>
    ''' <remarks></remarks>
    Protected class11_dates As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp11_dates As String

    Protected label11_dates As New Label

    ''' <summary>
    ''' поле елемент упрравления год (DateTimePicker)
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field11_dates As New DateTimePicker

    Sub SettingsControl_11_dates()
        label11_dates.Name = "dates"
        label11_dates.Text = "Дата в документе:"

        field11_dates.Name = "dates"
    End Sub

    Protected Sub ValueChanged() Handles field11_dates.ValueChanged
        class11_dates = field11_dates.Value.ToShortDateString
        testEnabled()
    End Sub


#End Region

#Region "    Номер 12 - izd_shifr - (Шифр изделия) - ComboBox   "
    '   Номер 12
    ''' <summary>
    ''' Массив контролов Label и ComboBox. |  izd_shifr
    ''' </summary>
    ''' <remarks></remarks>
    Protected s12_izd_shifr() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class12_izd_shifr As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp12_izd_shifr As String

    Protected WithEvents label12_izd_shifr As New Label

    Public WithEvents field12_izd_shifr As New ComboBox

    Sub SettingsControl_12_izd_shifr()
        label12_izd_shifr.Name = "izd_shifr"
        label12_izd_shifr.Text = "Шифр изделия:"

        field12_izd_shifr.Name = "izd_shifr"

        'load_izd_shifr(cls_TypeDoc.path_DataBase, field12_izd_shifr)
    End Sub

    Protected Sub field12_izd_shifr_Click() Handles field12_izd_shifr.SelectedIndexChanged
        class12_izd_shifr = field12_izd_shifr.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 13 - seria - (Номера чертежей) - TextBox   "

    '   Номер 13
    Protected s13_seria() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class13_seria As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp13_seria As String

    Protected label13_seria As New Label
    Public WithEvents field13_seria As New TextBox

    Sub SettingsControl_13_seria()
        label13_seria.Name = "seria"
        label13_seria.Text = "Серия:"

        field13_seria.Name = "seria"
    End Sub

    Protected Sub TextChanged13() Handles field13_seria.TextChanged
        class13_seria = field13_seria.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 14 - comboBox1 - (Резервный ComboBox1) - spec, preffix, let    "

    '   Номер 14

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола: spec, preffix, let
    ''' </summary>
    ''' <remarks></remarks>
    Protected class14_cbo1 As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_... Прототип поля - spec, preffix, let
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp14_cbo1 As String

    ''' <summary>
    ''' Массив контролов Label и ComboBox. |  Запрос производства - spec  |  Извещение - preffix  | БППП - let
    ''' </summary>
    ''' <remarks></remarks>
    Protected s14_cbo1() As Control

    ''' <summary>
    ''' Контрол поля - spec, preffix(ComboBox)
    ''' </summary>
    ''' <remarks></remarks>
    Protected WithEvents label14_cbo1 As New Label

    ''' <summary>
    ''' Вспомогательный ComboBox. Поле spec, preffix, let
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field14_cbo1 As New ComboBox

    Sub SettingsControl_14_cbo1()
        label14_cbo1.Name = "cbo1"
        label14_cbo1.Text = "comboBox1:"

        field14_cbo1.Name = "cbo1"
    End Sub

    Protected Sub field14_cbo1_Click() Handles field14_cbo1.SelectedIndexChanged
        class14_cbo1 = field14_cbo1.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 15 - comboBox2 - (Резервный ComboBox2) - dep_zp   "
    '   Номер 15

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола: поле dep_zp
    ''' </summary>
    ''' <remarks></remarks>
    Protected class15_cbo2 As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Прототип поля - dep_zp
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp15_cbo2 As String

    ''' <summary>
    ''' Массив контролов Label и ComboBox. Поле dep_zp
    ''' </summary>
    ''' <remarks></remarks>
    Protected s15_cbo2() As Control
    ''' <summary>
    ''' поле dep_zp, cbo2
    ''' </summary>
    ''' <remarks></remarks>
    Protected WithEvents label15_cbo2 As New Label

    ''' <summary>
    ''' Вспомогательный ComboBox. Поле dep_zp
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field15_cbo2 As New ComboBox

    Sub SettingsControl_15_cbo2()
        label15_cbo2.Name = "cbo2"
        label15_cbo2.Text = "comboBox2:"

        field15_cbo2.Name = "cbo2"

        'Предназначен для запроса
        'load_AntonovDep(cls_TypeDoc.path_DataBase, field15_cbo2)
    End Sub

    Protected Sub field15_cbo2_Click() Handles field15_cbo2.SelectedIndexChanged
        class15_cbo2 = field15_cbo2.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 16 - comboBox3 - (Резервный ComboBox3) - id_rz_register_doc, group   "
    '   Номер 16

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола: id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected class16_cbo3 As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Прототип поля - id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp16_cbo3 As String

    ''' <summary>
    ''' Массив контролов Label и ComboBox. |  Запрос производства - id_rz_register_doc  |  Извещение - group
    ''' </summary>
    ''' <remarks></remarks>
    Protected s16_cbo3() As Control

    ''' <summary>
    ''' id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected WithEvents label16_cbo3 As New Label

    ''' <summary>
    ''' Вспомогательный ComboBox. Поле id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field16_cbo3 As New ComboBox

    Sub SettingsControl_16_cbo3()
        label16_cbo3.Name = "cbo3"
        label16_cbo3.Text = "comboBox3:"

        field16_cbo3.Name = "cbo3"
    End Sub

    Protected Sub field16_cbo3_Click() Handles field16_cbo3.SelectedIndexChanged
        class16_cbo3 = field16_cbo3.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 17 - tag - (тег для административной документации) - tag"
    '   Номер 16

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола: id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected class17_tag As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Прототип поля - id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp17_tag As String

    ''' <summary>
    ''' Массив контролов Label и ComboBox. |  Запрос производства - id_rz_register_doc  |  Извещение - group
    ''' </summary>
    ''' <remarks></remarks>
    Protected s17_tag() As Control

    ''' <summary>
    ''' id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Protected WithEvents label17_tag As New Label

    ''' <summary>
    ''' Вспомогательный ComboBox. Поле id_rz_register_doc, group
    ''' </summary>
    ''' <remarks></remarks>
    Public WithEvents field17_tag As New CheckedComboBox

    Sub SettingsControl_17_tag()
        label17_tag.Name = "tag"
        label17_tag.Text = "Тег:"

        field17_tag.Name = "tag"
    End Sub

    Protected Sub field17_tag_Click() Handles field17_tag.SelectedIndexChanged
        class17_tag = field17_tag.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 18 - txt1 - (Резервный TextBox1) - TextBox   "

    '   Номер 18
    
    Protected s18_txt1() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class18_txt1 As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp18_txt1 As String

    Protected label18_txt1 As New Label
    Public WithEvents field18_txt1 As New TextBox

    Sub SettingsControl_18_txt1()
        label18_txt1.Name = "txt1"
        label18_txt1.Text = "txt1:"

        field18_txt1.Name = "txt1"
    End Sub

    Protected Sub TextChanged18() Handles field18_txt1.TextChanged
        class18_txt1 = field18_txt1.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 19 - txt2 - (Резервный TextBox2) - TextBox   "

    '   Номер 13
    Protected s19_txt2() As Control

    ''' <summary>
    ''' Получает текстовое значение сразу же при изменении своего контрола
    ''' </summary>
    ''' <remarks></remarks>
    Protected class19_txt2 As String

    ''' <summary>
    ''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
    ''' </summary>
    ''' <remarks></remarks>
    Protected temp19_txt2 As String

    Protected label19_txt2 As New Label
    Public WithEvents field19_txt2 As New TextBox

    Sub SettingsControl_19_txt2()
        label19_txt2.Name = "txt2"
        label19_txt2.Text = "txt2:"

        field19_txt2.Name = "txt2"
    End Sub

    Protected Sub TextChanged19() Handles field19_txt2.TextChanged
		class19_txt2 = field19_txt2.Text
        testEnabled()
    End Sub

#End Region

#Region "    Номер 19 - txt2 - (Резервный TextBox2) - TextBox   "

	'   Номер 13
	Protected s20_btn() As Control

	''' <summary>
	''' Получает текстовое значение сразу же при изменении своего контрола
	''' </summary>
	''' <remarks></remarks>
	Protected class20_btn() As String

	''' <summary>
	''' Переменная участвует только в сохранении файла и папки. Действует совместно с переменной class_...
	''' </summary>
	''' <remarks></remarks>
	Protected temp20_btn As String

	Protected label20_btn As New Label
	Public WithEvents field20_btn As New Button

	Sub SettingsControl_20_btn()
		label20_btn.Name = "btn"
		label20_btn.Text = "Участок:*"

		field20_btn.Name = "btn"
	End Sub

	Protected Sub TextChanged20() Handles field20_btn.Click

		Dim d As Data = New Data()

		Dim frm As New frm_Sector(d)

		Dim result As DialogResult = frm.ShowDialog()
		class20_btn = d.Value

		testEnabled()
	End Sub

#End Region

    Protected Sub LoadedMas()

        s01_izd = New Control() {label01_izd, field01_izd}
        s02_num = New Control() {label02_num, field02_num}
        s03_cherteg = New Control() {label03_Cherteg, field03_cherteg}
        s04_RZ = New Control() {label04_rz, field04_rz}
        s05_NumMash = New Control() {label05_num_mash, field05_num_mash}
        s06_prim = New Control() {label06_prim, field06_prim}
        s07_OGK = New Control() {label07_OGK, field07_OGK}
        s08_pi = New Control() {label08_pi, field08_pi}
        s09_dep = New Control() {label09_dep, field09_dep}
        s10_Years = New Control() {label10_years, field10_years}
        s11_Dates = New Control() {label11_dates, field11_dates}
        s12_izd_shifr = New Control() {label12_izd_shifr, field12_izd_shifr}
        s13_seria = New Control() {label13_seria, field13_seria}
        s14_cbo1 = New Control() {label14_cbo1, field14_cbo1}
        s15_cbo2 = New Control() {label15_cbo2, field15_cbo2}
        s16_cbo3 = New Control() {label16_cbo3, field16_cbo3}
        s17_tag = New Control() {label17_tag, field17_tag}
        s18_txt1 = New Control() {label18_txt1, field18_txt1}
		s19_txt2 = New Control() {label19_txt2, field19_txt2}
		s20_btn = New Control() {label20_btn, field20_btn}

		sSingleLoad = New Control()() {s01_izd, s02_num, s03_cherteg,
									   s04_RZ, s05_NumMash, s06_prim,
									   s07_OGK, s08_pi, s09_dep,
									   s10_Years, s11_Dates, s12_izd_shifr,
									   s13_seria, s14_cbo1, s15_cbo2, s16_cbo3,
									   s17_tag, s18_txt1, s19_txt2, s20_btn}

    End Sub

    ''' <summary>
    ''' Процедура записывает из элементов управления своего класса в переменные под именем class_: Например: class_izd = field1_Izd.Text
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub writeFields()

        class01_izd = field01_izd.Text
        class02_num = field02_num.Text
        class03_cherteg = field03_cherteg.Text
        class04_rz = field04_rz.Text
        class05_num_mash = field05_num_mash.Text
        class06_prim = field06_prim.Text
        class07_ogk = field07_OGK.Checked.ToString()
        class08_pi = field08_pi.Text
        class09_dep = field09_dep.Text
        class10_years = field10_years.Text
        class11_dates = field11_dates.Text
        class12_izd_shifr = field12_izd_shifr.Text
        class13_seria = field13_seria.Text
        class14_cbo1 = field14_cbo1.Text
        class15_cbo2 = field15_cbo2.Text
        class16_cbo3 = field16_cbo3.Text
        class17_tag = field17_tag.Text
        class18_txt1 = field18_txt1.Text
        class19_txt2 = field19_txt2.Text

    End Sub

    Sub SettingsControls()

        SettingsControl_01_izd()
        SettingsControl_02_num()
        SettingsControl_03_cherteg()
        SettingsControl_04_rz()
        SettingsControl_05_num_mash()
        SettingsControl_06_prim()
        SettingsControl_07_ogk()
        SettingsControl_08_pi()
        SettingsControl_09_dep()
        SettingsControl_10_years()
        SettingsControl_11_dates()
        SettingsControl_12_izd_shifr()
        SettingsControl_13_seria()
        SettingsControl_14_cbo1()
        SettingsControl_15_cbo2()
		SettingsControl_16_cbo3()
		SettingsControl_17_tag()
		SettingsControl_18_txt1()
		SettingsControl_19_txt2()
		SettingsControl_20_btn()

    End Sub

    Sub Initialize()
		Dim location As Integer = 0
        SettingsControls()
        LoadedMas()

        LoadLabelList()
        LoadFieldsList()

        For i As Integer = 0 To labelList.Count - 1
			location += 26

			labelList(i).Size = New Size(WidthLabel, HeightLabel)
            labelList(i).Left = LeftLabel
			labelList(i).Top = location

			fieldList(i).Size = New Size(WidthField, HeightField)
			fieldList(i).Left = LeftField
			fieldList(i).Top = location
		Next


    End Sub

    Sub PanelAdd(pan As Panel)

        For ik As Integer = 0 To sSingleLoad.Length - 1
            pan.Controls.AddRange(sSingleLoad(ik))
        Next

    End Sub

#Region "    Загрузка LabelList                         "

    Public labelList As List(Of Control)

    Sub LoadLabelList()
        labelList = New List(Of Control)

        For ik As Integer = 0 To sSingleLoad.Length - 1
            labelList.Add(sSingleLoad(ik)(0))
        Next

    End Sub
#End Region

#Region "    Загрузка FieldList                         "
    Public fieldList As List(Of Control)

    Sub LoadFieldsList()
        fieldList = New List(Of Control)

        For ik As Integer = 0 To sSingleLoad.Length - 1
            fieldList.Add(sSingleLoad(ik)(1))
        Next

    End Sub
#End Region

#Region "    Перемещение элементов управления на форме				"

    ''' <summary>
    ''' Перемещение элементов управления на форме
    ''' </summary>
    ''' <remarks>Примечание</remarks>
	Sub MoveControls(ParamArray params()() As Control)
		Dim location As Integer = 0
		Dim Count As Integer = labelList.Count - 1

		Dim sLabelBox() As String
		Dim sNames()() As String

		sNames = New String(Count)() {}
		Dim i As Integer = 0

		For Each ctl In labelList
			Dim obj1 As Object = TypeOf ctl Is Label

			If obj1 Then
				sLabelBox = New String() {ctl.Name, ctl.Left.ToString(), ctl.Top.ToString()}
				sNames(i) = sLabelBox
				i += 1
			End If
		Next

		For i3 As Integer = 0 To Count
			labelList(i3).Visible = False
			fieldList(i3).Visible = False
		Next

		Dim controlLabel(params.Length - 1) As Control
		Dim controlField(params.Length - 1) As Control

		For ik As Integer = 0 To params.Length - 1
			controlLabel(ik) = params(ik)(0)
			controlField(ik) = params(ik)(1)

		Next

		Dim k As Integer = 0
		Dim j As Integer = 0
		Dim kk(params.Length - 1) As Integer

		Do
			If controlLabel(k).Name = sNames(j)(0) Then
				location += 26
				'kk(k) = LocationY(k)
				kk(k) = location

				k += 1
				j = 0
			Else
				j += 1
			End If

		Loop While params.Length > k

		location = 0
		For ii2 As Integer = 0 To kk.Length - 1
			location += 26
			controlLabel(ii2).Visible = True
			controlLabel(ii2).Top = location

			controlField(ii2).Visible = True
			controlField(ii2).Top = location
			controlField(ii2).TabIndex = 20 + ii2
		Next

	End Sub

#End Region

#Region "    Загрузка элементов управления на панель LoadPanel		"

    Public Sub LoadPanel(pan As Panel)
        pan.Controls.Clear()
        PanelAdd(pan)
        MoveControls(sSingle)
        FinalSettigControlsInForm()
    End Sub


#End Region

#Region "    Функции для получения окончательных имен переименования конкретного класса"

    ''' <summary>
    ''' Функция для получения окончательного имя картинок (без примечания)
    ''' </summary>
    ''' <returns>ЗП 123 - 178.00.5603.080.000 _01</returns>
    ''' <remarks></remarks>
    Public Function NameFilesSaveDoc() As String
		Return fileName
	End Function

	''' <summary>
	''' Функция для получения окончательного имя папки (с примечанием)
	''' </summary>
	''' <returns>ЗП 123 - 178.00.5603.080.000 - (Примечание)</returns>
	''' <remarks></remarks>
	Public Function NameFolderSaveDoc() As String
		Return directoryNameWithComment
	End Function

	''' <summary>
	''' Функция для получения полного пути к конечной папки
	''' </summary>
	''' <returns>ЗП - (Запрос производства)\...\178\178.001\ЗП 123 - 178.00.5603.080.000</returns>
	''' <remarks></remarks>
	Public Function DirectoryEndPathSave() As String
		Return dirName & nameFullPathSave
	End Function

#End Region

#Region "    Процедура для создание имен: nameFilesSave, nameFolderSave, dirEndPathSave"
	''' <summary>
	''' Процедура для создание имен: nameFilesSave, nameFolderSave, dirEndPathSave
	''' </summary>
	''' <remarks></remarks>
	Protected Sub CreateNames()
		fileName = String.Format(str_SaveImages, mas_SaveImages)

		directoryNameWithComment = String.Format(str_SaveFolder, mas_SaveFolder)

		nameFullPathSave = String.Format(str_FullPathFolder, mas_FullPathFolder)
	End Sub
#End Region

#Region "    Процедура, которая проверяет на правильность написания всех активных полей на форме    "

    ''' <summary>
    ''' Процедура, которая проверяет на правильность написания всех активных полей на форме
    ''' </summary>
    ''' <param name="masControl"></param>
    ''' <remarks></remarks>
    Protected Sub isInputCorrect(masControl()() As Control)
        Dim str As String = "[\]|[/]|[:]|[*]|[?]|[<]|[>]|[|]"
        Dim s As String = ""
        Dim err As Boolean = False

        Dim newReg As New Regex(str)

        Try
            For k As Integer = 0 To masControl.Length - 1
                If (newReg.IsMatch(masControl(k)(1).Text)) Then
                    s += masControl(k)(0).Text & "       " & masControl(k)(1).Text & vbNewLine
                    err = True
                End If
            Next

            If err Then
                Dim str2 As String = ""
                str2 = "Веденны запрещенные символы:" & vbNewLine &
                                "\ / | : * ? < >" & " в таких полях:" & vbNewLine & vbNewLine &
                                s & vbNewLine &
                                "Исправьте введенный тект и повторите проверку."

                Throw New Exception(str2)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

#End Region

#Region "    Функция для автоматического создания строки в виде {0}{1}{2}{3}            "

    ''' <summary>
    ''' Функция для автоматического создания строки в виде {0}{1}{2}{3}
    ''' </summary>
    ''' <returns>Принимает массив типа строки</returns>
    Protected Function RenamingStrings(str() As String) As String
        Dim s1 As String = ""
        Dim i As Integer = 0
        For Each s2 As String In str
            s1 &= "{" & i & "}"
            i += 1
        Next
        Return s1
    End Function

#End Region



End Class


