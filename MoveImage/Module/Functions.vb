Imports System.IO
Imports System.Windows.Forms

Module Functions

    Function FullPathName(s As String, obj As Object) As String
        Return s & obj.ToString
    End Function

    Sub subCountImageInfo(Count As Integer, lbl_DirectorySelect As Label, ByVal i As Integer)

        Dim Images() As String = {" изображение.", " изображений.", " изображения."}
        Dim Folders() As String = {" папка.", " папок.", " папки."}

        If i = 2 Then
            Dim s As Integer = CType(Strings.Right(Count.ToString, 1), Integer)

            If Count = 1 Then
                lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Images(0)
                Exit Sub
            End If

            If Count = 11 Or Count = 12 Or Count = 13 Or Count = 14 Then
                lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Images(1)
                Exit Sub
            End If

            Select Case s
                Case 0, 5, 6, 7, 8, 9
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Images(1)
                Case 2, 3, 4
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Images(2)
                Case 1
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Images(0)
            End Select

        ElseIf i = 1 Then
            Dim s As Integer = CType(Strings.Right(Count.ToString, 1), Integer)

            If Count = 1 Then
                lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Folders(0)
                Exit Sub
            End If

            If Count = 11 Or Count = 12 Or Count = 13 Or Count = 14 Then
                lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Folders(1)
                Exit Sub
            End If

            Select Case s
                Case 0, 5, 6, 7, 8, 9
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Folders(1)
                Case 2, 3, 4
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Folders(2)
                Case 1
                    lbl_DirectorySelect.Text = "Всего в папке:" & vbNewLine & Count & Folders(0)
            End Select
        End If




    End Sub

    Sub subListBox_Click(listBox As ListBox, pathFile As String, pct_Image As PictureBox)

        Try

            Dim str As String = di_SelectedListFolder.FullName

            If listBox.Text = "" Then Exit Sub

            fullNamePathImage = di_SelectedListFolder.FullName & "\" & listBox.Text

            pct_Image.ImageLocation = fullNamePathImage
            pct_Image.Refresh()
            pct_Image.Visible = True

        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

    End Sub

    Sub subEnabled_Buttons(cmdUp As Button, cmdDown As Button, cmdNextStep As Button, Enabled As Boolean)
        If Enabled Then
            cmdNextStep.Enabled = True
            cmdUp.Enabled = True
            cmdDown.Enabled = True
        Else
            cmdNextStep.Enabled = False
            cmdUp.Enabled = False
            cmdDown.Enabled = False
        End If
    End Sub

    Public Sub subClick_Move(listBox_SelectedImages As ListBox, move As Integer)
        listBox_SelectedImages.BeginUpdate()
        Try

            Dim index As Integer = listBox_SelectedImages.SelectedIndex

            Dim x As Object = listBox_SelectedImages.Items(index)
            Dim s As String = ListSelectedFiles.Item(index)

            ListSelectedFiles.Item(index) = ListSelectedFiles.Item(index + move)
            listBox_SelectedImages.Items(index) = listBox_SelectedImages.Items(index + move)

            ListSelectedFiles.Item(index + move) = s
            listBox_SelectedImages.Items(index + move) = x

            listBox_SelectedImages.SelectedIndex = index + move

        Catch ex As Exception

        End Try

        listBox_SelectedImages.EndUpdate()
    End Sub

    Public Sub subFlip_Image(RotateFlip As Integer, pathImage As String, pictureBox As PictureBox)
        Dim image As Image
        Try

            image = New Bitmap(pathImage)

			image.RotateFlip(CType(RotateFlip, RotateFlipType))
            image.Save(fullNamePathImage, System.Drawing.Imaging.ImageFormat.Jpeg)


            pictureBox.ImageLocation = fullNamePathImage
            pictureBox.Refresh()
            image.Dispose()

        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Непосредственно процедура для сохранения картинок в конечную 
    ''' папку конкретного документа
    ''' </summary>
    ''' <param name="ListSelectedFiles">Полный путь картинок картинок  с папки Сканер</param>
    ''' <param name="dirNameSave">Конечная папка конкретного документа на сервере</param>
    ''' <remarks></remarks>
	Sub SaveImagesEndPath(ListSelectedFiles As ArrayList, dirNameSave As String)
		Dim k As Integer = 0
		Try
			For Each s As String In ListFilesSave
				Dim temp As String = dirNameSave & "\" & ListFilesSave(k).ToString


				Dim drInfo1 As DirectoryInfo = New DirectoryInfo(temp)
				Dim drInfo2 As DirectoryInfo = New DirectoryInfo(ListSelectedFiles(k).ToString)

				File.Copy(ListSelectedFiles(k).ToString, temp)
				k += 1

				My.Computer.FileSystem.RenameFile(drInfo2.FullName, drInfo1.Name)


			Next
		Catch ex As Exception
			For iss As Integer = k To ListFilesSave.Count - 1

				Dim temp As String = dirNameSave & "\" & ListFilesSave(iss).ToString

				Dim drInfo1 As DirectoryInfo = New DirectoryInfo(temp)
				Dim drInfo2 As DirectoryInfo = New DirectoryInfo(ListSelectedFiles(iss).ToString)

				File.Copy(ListSelectedFiles(iss).ToString, temp)

			Next
		End Try
		
    End Sub

    ''' <summary>
    ''' Непосредственно процедура для сохранения записи в базу данных 
    ''' </summary>
    ''' <param name="ListFilesSave"></param>
    ''' <param name="currentSelectClass">Текущий класс Тип документа выбранный из cbc_TypeDoc</param>
    ''' <remarks></remarks>
    Sub SaveDataBase(ListFilesSave As ArrayList, currentSelectClass As cls_TypeDoc)
        Try
            'Dim dbe As Object	' DAO.DBEngine
            Dim db As Object    ' DAO.Database
            Dim rs As Object    ' DAO.Recordset
            Dim rs2 As Object   ' DAO.Recordset2
            Dim f2 As Object    ' DAO.Field2

            Dim fieldName As String
            Dim fieldValue As String

            Dim pathDirectory As String
            pathDirectory = Environment.CurrentDirectory & "\"

            'dbe = CreateObject("DAO.DbEngine.120")
            db = dbe.OpenDatabase(pathDirectory & "\MoveImageDB.accdb")

            rs = db.OpenRecordset(currentSelectClass.nameTable_TypeDoc, RecordsetTypeEnum.dbOpenDynaset)

            rs.AddNew()
            For i As Integer = 0 To currentSelectClass.sSingle.Length - 1
                fieldName = currentSelectClass.sSingle(i)(1).Name
                fieldValue = currentSelectClass.sSingle(i)(1).Text

                rs.Fields(fieldName).Value = fieldValue
                
            Next

            rs2 = rs.Fields("image").Value

            For i = 0 To ListFilesSave.Count - 1
                rs2.AddNew()
                Dim temp As String = dirNameSave & "\" & ListFilesSave(i).ToString

                f2 = rs2.Fields("FileData")
                Call f2.LoadFromFile(temp)
                rs2.Update()
            Next

            rs.Update()

            rs.Close()

            db.Close()
            'dbe.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message & Environment.NewLine & _
                            "При этой ошибке сообщите Администратору Базы данных!" & Environment.NewLine & _
                            "Спасибо", "Ошибка")
        End Try
    End Sub

    ''' <summary>
    ''' Загрузка путей из файла для, где находятся изображения сканера и по какому относительному пути будет все соранятся
    ''' </summary>
    ''' <remarks></remarks>
    Sub LoadFromPathFile()
        Dim sw As StreamWriter
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

        If Environment.UserName = "Vetal" Then
            path_Scaner = "E:\Document\Мои рисунки\"
            path_SaveDocuments = "d:\TestMoveImage\"
            path_DataBase = "d:\Doc\Work\Работа\База данных\TestBD\"
        Else

            path_Scaner = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
            path_SaveDocuments = "\\erp\0_\0_App\540\"
            path_DataBase = "\\erp\0_\0_App\DataBaseAccess\DataBase\"

            'sr = New StreamReader("Path.dat")

            'path_Scaner = sr.ReadLine()
            'path_SaveDocuments = sr.ReadLine()
            'path_DataBase = sr.ReadLine()

            'sr.Close()
        End If

        'Public path_Scaner As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub

End Module