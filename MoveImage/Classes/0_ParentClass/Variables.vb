Partial Class cls_TypeDoc

#Region "    Объявление делегата     "
    Public Delegate Sub cmd_SaveEnabledOff(cmd_Save As Boolean)

    Public Event delegateEnabledOFF As cmd_SaveEnabledOff

    Public Sub cmdSave_EnabledOFF()
        RaiseEvent delegateEnabledOFF(False)
    End Sub

    ''' <summary>
    ''' Переменная флаг, предназначена для выявления требуется выключить кнопку или нет, были ли произведены изменения на элементах управления, и если 
    ''' были то значение переменной равняется False, и при этом обновления уже не происходят
    ''' </summary>
    ''' <remarks></remarks>
    Protected delegateFlag As Boolean

#End Region

#Region "    Объявление переменных класса						"

    ''' <summary>
    ''' Имя таблицы в базе данных ServerDBNew, для предназначения изначальной регистрации документов. 
    ''' Для Административной это Register_Doc_Administrative, 
    ''' Пример Register_IZV_NotImage
    ''' </summary>
    ''' <remarks></remarks>
    Public nameTable_RegisterDoc As String

    ''' <summary>
	''' Имя таблицы в базе данных ServerDBNew, каждого конкретного класса. Пример Register_IZV_NotImage
    ''' </summary>
    ''' <remarks></remarks>
    Public nameTable_TypeDoc As String

	''' <summary>
	''' Имя таблицы в базе данных со сканером, каждого конкретного класса
	''' </summary>
	''' <remarks></remarks>
    Public nameTable_Image As String

    ''' <summary>
	''' Имя базы данных, каждого конкретного класса: Пример ServerDBNew.accdb
    ''' </summary>
    ''' <remarks></remarks>
	Public nameDataBase As String

	''' <summary>
	''' Имя базы данных, каждого конкретного класса: Пример ServerDBNew_Image_IZV.accdb
	''' </summary>
	''' <remarks></remarks>
	Public nameDataBase_Image As String

    ''' <summary>
    ''' При закрывании формы происходит очистка формы, если форма хоть раз открывалась то в переменную записывается эта информация 
    ''' </summary>
    ''' <remarks></remarks>
    Protected isEmptyFilds As Boolean = False

	''' <summary>
	''' Строка сохранения картинок (без примечания): {0}{1}{2}{3}
	''' </summary>
	''' <remarks></remarks>
    Protected str_SaveImages As String

	''' <summary>
	''' Строка сохранения папки (с примечанием {4}): {0}{1}{2}{3}{4}
	''' </summary>
	''' <remarks></remarks>
	Protected str_SaveFolder As String

	''' <summary>
	''' Строка полного пути папки (все использующие поля): {0}{1}{2}{3}{4}{5}{6}
	''' </summary>
	''' <remarks></remarks>
	Protected str_FullPathFolder As String

	''' <summary>
	''' Массив полей класса, для сохранения картинок (без примечания): {0}{1}{2}{3}
	''' </summary>
	''' <remarks></remarks>
    Protected mas_SaveImages() As String

	''' <summary>
	''' Массив полей класса, для сохранения папки (с примечанием): {0}{1}{2}{3}{4}
	''' </summary>
	''' <remarks></remarks>
    Protected mas_SaveFolder() As String

	''' <summary>
	''' Массив полей класса, для сохранения полного пути папки: {0}{1}{2}{3}{4}{5}{6}
	''' </summary>
	''' <remarks></remarks>
    Protected mas_FullPathFolder() As String

#End Region

    ''' <summary>
	''' Свойство: Окончательное имя картинок (без примечания): ЗП 456 - РЗ_7285 - 148.00.5603.080.000  
    ''' </summary>
    ''' <remarks></remarks>
	Protected fileName As String

	''' <summary>
	''' Окончательное имя картинок (без примечания): ЗП 456 - РЗ_7285 - 148.00.5603.080.000  
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property class_FileName() As String
		Get
			Return fileName
		End Get
	End Property


	''' <summary>
	''' Окончательное имя папки (с примечанием): ЗП 456 - РЗ_7285 - 148.00.5603.080.000 - (Примечание)
	''' </summary>
	''' <remarks></remarks>
	Protected directoryNameWithComment As String

	''' <summary>
	''' Свойство: Окончательное имя папки (с примечанием): ЗП 456 - РЗ_7285 - 148.00.5603.080.000 - (Примечание)
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property class_DirectoryNameWithComment() As String
		Get
			Return directoryNameWithComment
		End Get
	End Property

    ''' <summary>
	''' Окончательный полный путь сохранения данного документа после переменной класса dirName имени папки в конкретном классе : 178\178.001\ЗП 456 - РЗ_7285 - 148.00.5603.080.000 
	''' как задана переменная класса mas_FullPathFolder (в основном с примечанием)
    ''' </summary>
    ''' <remarks></remarks>
	Protected nameFullPathSave As String

	'nameFullPathSave = String.Format(str_FullPathFolder, mas_FullPathFolder)

	Public ReadOnly Property class_FullPathSave() As String
		Get
			Return nameFullPathSave
		End Get
	End Property


	''' <summary>
	''' Свойство: Окончательный полный путь сохранения данного документа после переменной класса dirName имени папки в конкретном классе : 178\178.001\ЗП 456 - РЗ_7285 - 148.00.5603.080.000 
	''' как задана переменная класса mas_FullPathFolder (в основном с примечанием)
	''' </summary>
	''' <value></value>
	''' <returns></returns>
	''' <remarks></remarks>
	Public ReadOnly Property class_DirectoryFullName() As String
		Get
			Return directoryNameWithComment
		End Get
	End Property

    ''' <summary>
    ''' Имя папки конкретного документа: 
    ''' "ЗП - (Запрос производства)\Запрос производства (Предприятия)\"
    ''' </summary>
    ''' <remarks></remarks>
	Protected dirName As String

	Public ReadOnly Property class_DirName() As String
		Get
			Return dirName
		End Get
	End Property

    ' Конечная папка сохранения 
    ' Пример на ЗП:
    ' 178\178.001\ЗП 123 - РЗ_7557 - 148.00.5603.080.000

    '''' <summary>
    '''' Массив список изделий: 24, 32 .. 132, 148 .. 400
    '''' </summary>
    '''' <remarks></remarks>
    'Protected ListIzd() As String = New String() {"24", "26", "32", "70", "132", "148", "158", "178", "400"}

    'Protected ListIzdShifr() As String = New String() {"24", "26", "32", "32/132", "70", "132", "148", "158", "148/158", "178", "400"}

	''' <summary>
	''' Переменная обозначающаяся корень конкретного типа документа. Пример Register_SKN_NotImage - корень SKN
	''' </summary>
	''' <remarks></remarks>
	Public rootNameDocument As String

    ''' <summary>
    ''' Переменная наименования группы, куда относится класс 
    ''' Административная, Техническая, Технологическая
    ''' </summary>
    ''' <remarks></remarks>
    Public nameGroup As String

    ''' <summary>
    ''' Переменная наименования класса, предназначена для фильтрации в базе данных 
    ''' при регистрации в таблице Register_Doc, (Тип документа в таблице)
    ''' </summary>
    ''' <remarks></remarks>
	Public type_doc As String

	''' <summary>
	''' Массив, типа документов используется для совместимости с Адиминистративной документацией
	''' </summary>
	''' <remarks></remarks>
	Public type_docRange() As String

    ''' <summary>
    ''' Переменная вточности как в базе данных предназначена для таблицы Register_Doc каждого 
    ''' конкретного класса и присваеваается при функции SaveMoveImageDB
    ''' </summary>
    ''' <remarks></remarks>
    Protected ref_doc As Integer

    ''' <summary>
    ''' Переменная вточности как в базе данных предназначена для базы данных со сканером  конкретного класса . Пример Register_IZV_ImageOne
    ''' </summary>
    ''' <remarks></remarks>
    Protected i_NotImage As Integer


    ''' <summary>
    ''' Переменная предназначена для таблицы Register_Doc И присваевается обозначение в совокупности 
    ''' полей конкретного класса для конкретного документа в процедуреinputFields
    ''' </summary>
    ''' <remarks></remarks>
    Protected num_doc As String

    ''' <summary>
    ''' Переменная предназначена для таблицы Register_Doc_Administrative 
    ''' Представлена в текстовом виде и подстановки в SQL запрос Access
    ''' </summary>
    ''' <remarks></remarks>
	Protected dates_doc_string As String

	''' <summary>
	''' Переменная предназначена для таблицы Register_Doc_Administrative 
	''' Необходимо для присвоения значения в таблиуе поля dates_doc
	''' </summary>
	''' <remarks></remarks>
	Protected dates_doc_date As Date


    Public ReadOnly Property NameClass() As String
        Get
            Return type_doc
        End Get
    End Property

    ''' <summary>
    ''' Переменная предназначена для выяснения была ли загружены на форму элементы управления конкретного класса 
    ''' </summary>
    ''' <remarks></remarks>
    Protected field_isControlsLoad As Boolean = False




    
End Class
