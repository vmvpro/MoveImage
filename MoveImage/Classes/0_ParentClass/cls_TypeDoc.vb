Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary.BinaryFormatter
Imports System.Collections.Generic
Imports System.Text.RegularExpressions.Regex

<Serializable>
Public MustInherit Class cls_TypeDoc

	''' <summary>
	''' Путь к папке, где находится база данных "z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\BD\"
	''' </summary>
	''' <remarks></remarks>
    Protected Shared path_DataBase As String

    Protected Shared tag As String = "Проверьте правильность написания Тег-а." & vbNewLine & _
                                     "Тег должен состоять из слова и после него ставится 'точка с запятой' и 'пробел'" & vbNewLine & vbNewLine & _
                                     "Пример написания Тега: " & vbNewLine & _
                                     "срочно; запомнить; помнить; зима 17; весна; май; лето июнь; нужно сделать; " & vbNewLine & vbNewLine & _
                                     "Обратите внимание в конце приложения текста Тега - должен ставиться 'пробел' после 'точки с запятой'"

    'Protected path_DataBase As String = "z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\BD\"

    Shared Sub New()
        If Environment.UserName = "Vetal" Then
            'path_Scaner = "E:\Document\Мои рисунки\"
            'path_SaveDocuments = "d:\TestMoveImage\"
            cls_TypeDoc.path_DataBase = "d:\Doc\Work\Работа\База данных\TestBD\"
        Else
            'Dim sr As StreamReader = New StreamReader("Path.dat")

            'path_Scaner = sr.ReadLine()
            'sr.ReadLine()
            'sr.ReadLine()
            'path_SaveDocuments = sr.ReadLine()
            cls_TypeDoc.path_DataBase = "\\erp\0_\0_App\DataBaseAccess\DataBase\"
            'sr.ReadLine()

            'sr.Close()
        End If
    End Sub


	''' <summary>
    ''' Загрузка в comboBox данных из таблицы RegisterDoc по критерию типа документа 
	''' </summary>
	''' <param name="id_rz_register_doc"></param>
	''' <param name="type_doc"></param>
	''' <remarks></remarks>
	Protected Sub load_RegisterDocParametr(id_rz_register_doc As ComboBox, type_doc As String)
		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(cls_TypeDoc.path_DataBase, "ServerDBNew.accdb")
			}

		'.DataSource = IO.Path.Combine(Application.StartupPath, "MoveImageDB.accdb")

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = "SELECT * FROM Register_Doc Where type = '" & type_doc & "' Order By num_doc"
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

				Dim all As DataRow = dt.NewRow
				all.SetField(Of String)("num_doc", "")
				all.SetField(Of Integer)("id", 0)
				dt.Rows.InsertAt(all, 0)
				dt.AcceptChanges()

			End Using
		End Using

		id_rz_register_doc.DataSource = dt

		id_rz_register_doc.DisplayMember = "num_doc"
		id_rz_register_doc.ValueMember = "id"
	End Sub

#Region "    Загрузка департаментов в comboBox dep_zp"

	Protected Sub load_AntonovDep(pathFolderDataBase As String, cboAntonovDep As ComboBox)
		Dim query As String = "SELECT dop_AntonovDep.dep_name " & _
							  "FROM dop_AntonovDep " & _
							  "ORDER BY dop_AntonovDep.index, dop_AntonovDep.dep_name;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = query
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

			End Using
		End Using

		cboAntonovDep.DataSource = dt

		cboAntonovDep.DisplayMember = "dep_name"
		cboAntonovDep.ValueMember = "dep_name"

	End Sub

#End Region

#Region "    Загрузка изделий в comboBox izd"

	Protected Sub load_izd(pathFolderDataBase As String, cboAntonovDep As ComboBox)
		Dim query As String = "SELECT dop_Izdelia.izd, dop_Izdelia.index, * " & _
							  "FROM dop_Izdelia " & _
							  "WHERE (((dop_Izdelia.izd) Not In ('КОС','Указать'))) " & _
							  "ORDER BY dop_Izdelia.index; "


		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = query
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

			End Using
		End Using

		cboAntonovDep.DataSource = dt

		cboAntonovDep.DisplayMember = "izd"
		cboAntonovDep.ValueMember = "izd"

	End Sub

#End Region

#Region "    Загрузка шифра изделий в документе в comboBox izd_shifr"

	Protected Sub load_izd_shifr(pathFolderDataBase As String, cboAntonovDep As ComboBox)
        Dim query As String = "SELECT dop_Izdelia.izd, dop_Izdelia.index " & _
                              "FROM dop_Izdelia " & _
                              "WHERE (((dop_Izdelia.izd) Not In " & _
                              "('24/26', '32/132', '148/178', '148/158/178', " & _
                              "'158/178', '132/178', '148/158','Указать','КОС'))) " & _
                              "ORDER BY dop_Izdelia.index;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = query
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

			End Using
		End Using

		cboAntonovDep.DataSource = dt

		cboAntonovDep.DisplayMember = "izd"
		cboAntonovDep.ValueMember = "izd"

	End Sub

#End Region

#Region "    Загрузка шифра изделий в документе в comboBox izd_shifr"

	Protected Function load_izd_shifr_(pathFolderDataBase As String, DisplayMember As String, ValueMember As String) As ComboBox
		Dim cboAntonovDep As New ComboBox

		Dim query As String = "SELECT dop_Izdelia.izd, dop_Izdelia.index " & _
							  "FROM dop_Izdelia " & _
							  "WHERE (((dop_Izdelia.izd) Not In " & _
							  "('24/26', '32/132', '148/178', '148/158/178', " & _
							  "'158/178', '132/178', '148/158','Указать','КОС'))) " & _
							  "ORDER BY dop_Izdelia.index;"

		Dim BuilderAccdb As New OleDb.OleDbConnectionStringBuilder With
			{
				.Provider = "Microsoft.ACE.OLEDB.12.0",
				.DataSource = IO.Path.Combine(pathFolderDataBase, "ServerDBNew.accdb")
			}

		Dim dt As New DataTable
		Using cn As New OleDb.OleDbConnection With
			{
				.ConnectionString = BuilderAccdb.ConnectionString
			}

			Using cmd As New OleDb.OleDbCommand With
				{
					.Connection = cn,
					.CommandText = query
				}

				'.CommandText = "SELECT id, type_doc & '' & '1' as type_doc , prim, index FROM dop_Type_Doc"

				cn.Open()
				dt.Load(cmd.ExecuteReader)

			End Using
		End Using

		cboAntonovDep.DataSource = dt

		cboAntonovDep.DisplayMember = DisplayMember
		cboAntonovDep.ValueMember = ValueMember

		Return cboAntonovDep

	End Function

#End Region



    ''' <summary>
    ''' Процедура на проверку обязательных полей на содержимость, если они пустые срабатывает исключение
    ''' </summary>
    Protected Sub IsEmpty(ByVal ParamArray s() As String)
        For Each s1 As String In s
            If s1 = String.Empty Then
                Throw New Exception("Поля со звездочкой должны быть введены обязательно!")
            End If
        Next
    End Sub


    Public Function classFormation() As Boolean
        ' процедура для считывания из элементов управления в поля класса
        writeFields()

        '---------проверка ввода-----------
        If (Not inputFields()) Then Return False
        '----------------------------------

        defineName()

        isInputCorrect(sSingleInputCorrect)

        delegateFlag = True

        'initial()
        CreateNames()

        Return True

    End Function

    ''' <summary>
    ''' Признак сохранения в базу данных
    ''' </summary>
    ''' <remarks></remarks>
	Protected boolDataBase As Boolean

	''' <summary>
	''' Функция предназначена для определения, сохранении в базу данных
	''' </summary>
	''' <returns></returns>
	''' <remarks></remarks>
	Public Function IsSaveDataBase() As Boolean
		Return boolDataBase
	End Function

    ''' <summary>
    ''' Процедура для ввода и форматирования полей для каждого конкретного класса
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Function inputFields() As Boolean

    ''' <summary>
    ''' Формирование имен для картинок, папки и конечной папки
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub defineName()

    ''' <summary>
    ''' Инициализация названия класа и пути 
    ''' </summary>
    ''' <remarks></remarks>
    Public MustOverride Sub initial()

    ''' <summary>
    ''' Настройки при Label-ов при загрузки формы
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub isFormLabels()

    ''' <summary>
    ''' Настройки при Field-ов при загрузки формы
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub isFormFields()

    ''' <summary>
    ''' Финальная настройка элементов управления после функции MoveControls(sSingle) в свою очередь в процедуре LoadPanel(pan As Panel).
    ''' Возможности: можно настроить размещение элементов управления, имена и т.д.
    ''' </summary>
    ''' <remarks></remarks>
    Protected MustOverride Sub FinalSettigControlsInForm()



    'Public MustOverride Function OpenRecordset(db As Object) As Object
        'Public MustOverride Sub SaveDataBaseCurrentClass(dbe As Object, s() As String, ListFilesSave As ArrayList)

End Class
