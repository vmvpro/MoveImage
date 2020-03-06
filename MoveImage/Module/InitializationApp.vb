Imports System.IO
Imports System.Drawing.Printing
'Imports Microsoft.Office.Interop.Access.Dao
Imports System.Data.OleDb

Module InitializationApp

    ''' <summary>
    ''' Путь папки, где находяться иображения от сканера | Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\Сканер\
    ''' </summary>
    ''' <remarks></remarks>
    Public path_Scaner As String
    'Public path_Scaner As String '= "Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\Сканер\"

    ' Сканер
    Public di_Scaner As DirectoryInfo
    Public fs_Scaner() As FileSystemInfo

    ''' <summary>
    ''' Выбранный каталог в lst_Scaner
    ''' </summary>
    ''' <remarks></remarks>
    Public di_SelectedListFolder As DirectoryInfo

    ''' <summary>
    ''' Перечень файлов у выбраном каталоге в lst_Scaner
    ''' </summary>
    ''' <remarks></remarks>
    Public fs_SelectedListFolder() As FileSystemInfo

    Public fs1() As FileSystemInfo

    ''' <summary>
    ''' Перечисление определяет текущую папку для подсчета количеста элементов в ListBox-e
    ''' </summary>
    ''' <remarks></remarks>
    Enum enDirectoryName
        Scaner = 1
        CurrentDirectoryImages = 2
    End Enum

    'Public DirInfo As FileSystemInfo

    ''' <summary>
    ''' Данный лист содержит полный путь каждой конкретной картинки. Картинки находятся в папке Сканер
    ''' </summary>
    ''' <remarks></remarks>
    Public ListSelectedFiles As New List(Of FileInfo)

    ''' <summary>
    ''' Данный лист содержит только имя каждой конкретной картинки. Хорошо действует совместно с dirNameSave - Конечный путь сохранения
    ''' </summary>
    ''' <remarks></remarks>
    Public ListFilesSave As New ArrayList()

    ' Переменная предназначена для сохранения картинок по имени папки, только без примечания
    'Public nameFilesSave As String

    ''' <summary>
    ''' Полное имя картинки из папки Сканер
    ''' </summary>
    ''' <remarks></remarks>
    Public fullNamePathImage As String

    ''' <summary>
    ''' Переменная для обозначения папки конкретного документа Например: ЗП 123 - РЗ_7803 - 178.00.5603.000.000 - (Тест)
    ''' </summary>
    ''' <remarks></remarks>
    Public nameFolderSaveDoc As String

    ''' <summary>
    ''' Окончательная папка для сохранения: Z\...\Техническая документация\...\178\178.001\РЗ 123 - ...(В конце без знака \)
    ''' </summary>
    ''' <remarks></remarks>
    Public dirNameSave As String

    ''' <summary>
    ''' Путь к папке, где сохраняется Техническая документация "Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\") 
    ''' </summary>
    ''' <remarks></remarks>
    Public path_SaveDocuments As String

    ''' <summary>
    ''' Путь папки, где находится база данных Access "z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\BD\") 
    ''' </summary>
    ''' <remarks></remarks>
    Public path_DataBase As String


    Public PS As PrinterSettings = New PrinterSettings

    Public PictureLoad As Image
    Public PictureCopy As Image

    ''' <summary>
    ''' Текущее состояние выбранного класса из ComboBox Тип документа
    ''' </summary>
    ''' <remarks></remarks>
    Public currentSelectClass As cls_TypeDoc

    '======================POLE============================
    '=======================================================

    Public pIzd As String
    Public pNum As String
    Public pCerteg As String
    Public pRZ As String


    '======================DATA BASE===========================
    '==========================================================

    'Public NameAccessDB = "Attach.accdb"
    'Public con As OleDbConnection = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;" & _
    '                                                "Data Source = " & NameAccessDB)
    Public commandString As String
    Public recordString As String

    '=========================DAO==============================
    '==========================================================

    Public dbe As Object   ' DAO.DBEngine

    Public statusOFF As String = "Идет идентификация программы..."
    Public statusON As String = "Идентификация выполнена успешно"

    Public status As String = statusOFF

    'Public dbe As DBEngine = New DBEngine
    'Public db As Database
    'Public rs As Recordset


    ''' <summary>
    ''' Загрузка путей из файла для, где находятся изображения сканера и по какому относительному пути будет все соранятся
    ''' </summary>
    ''' <remarks></remarks>
    Sub LoadFromPathFile()

        Dim sr As StreamReader

        If Not File.Exists("Path.dat") Then
            'sw = New StreamWriter("Path.dat")
            'sw.WriteLine("Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\Сканер\")
            'sw.WriteLine("Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\")
            'sw.WriteLine("z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\BD\")

            'sw.WriteLine("Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\Сканер\")
            'sw.WriteLine("\\erp\0_\0_App\DataBaseAccess\")
            'sw.WriteLine("\\erp\0_\0_App\DataBaseAccess\DataBase\")

            'sw.WriteLine("Z:\023 Цех23\ТБ\_ОБЩАЯ ПАПКА\База данных ТБ Ц23\2_Техническая документация\")
            'sw.Close()
        End If

        If Environment.UserName.ToLower() = "vetal" Then
            path_Scaner = "E:\Document\Мои рисунки\"
            path_SaveDocuments = "d:\Doc\Work\1_MyApplication\MoveImage\MoveImage (Git)\0_DirectoryFilesTestMoveImage\"
            path_DataBase = "d:\Doc\Work\Работа\База данных\TestDB\"
        ElseIf Environment.UserName.ToLower() = "mww54001" Then
            path_Scaner = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
            path_SaveDocuments = "\\erp\0_\0_App\540\"
            path_DataBase = "\\erp\0_\0_App\DataBaseAccess\DataBase\"
        Else
            sr = New StreamReader("Path.dat")

            path_Scaner = sr.ReadLine()
            path_SaveDocuments = sr.ReadLine()
            path_DataBase = sr.ReadLine()

            sr.Close()

        End If

        'Public path_Scaner As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub




    'Public PathD As String = "d:\Doc\Загальне\Visual Basic. Net\Работа с файлами\2015\Глава19.2.12\"
End Module
