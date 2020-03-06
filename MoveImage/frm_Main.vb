Imports System.IO
Imports System.Drawing.Printing
Imports System.String
Imports Microsoft.VisualBasic
Imports System.Threading


Public Class frm_Main

    Dim MouseCursor As Integer
    Dim SelectListBox As Integer

    Dim isLoadFromFile = False

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load, btnLoadScaner.Click

#If Not DebugMode Then
        Me.Height = SystemInformation.PrimaryMonitorSize.Height
        Me.Width = SystemInformation.PrimaryMonitorSize.Width
#End If



        Dim currentFile As FileSystemInfo
        Dim Count As Integer = 0

        If isLoadFromFile = False Then
            LoadFromPathFile()
            txtScanerPath.Text = path_Scaner
            subEnabled_Buttons(cmd_MoveUp, cmd_MoveDown, cmd_NextStep, False)
        Else
            If (Not Strings.Right(Strings.Trim(txtScanerPath.Text), 1) = "\") Then
                txtScanerPath.Text += "\"
            End If

            path_Scaner = txtScanerPath.Text
            If Not Directory.Exists(path_Scaner) Then
                MessageBox.Show("Путь к папке сканер не существует. Введите правильный путь к папке сканер, и нажмите перейти!")
                isLoadFromFile = False
                Return
            End If

        End If





        Try
            isLoadFromFile = True

            di_Scaner = New DirectoryInfo(path_Scaner)
            fs_Scaner = di_Scaner.GetDirectories()

            Label3.Text = "Имя папки:" & vbNewLine & di_Scaner.Name

            Label6.Text = "Папка не выбрана: "
            lst_Jpg.Items.Clear()

            lst_Scaner.Items.Clear()
            For Each currentFile In fs_Scaner

                lst_Scaner.Items.Add(currentFile.Name)
                Count += 1

            Next

            lst_Scaner.Sorted = True

            lbl_CountScanner.Text = "Всего: " & Count & " объектов."

            Dim s As Integer = CType(Strings.Right(Count.ToString, 1), Integer)

            subCountImageInfo(Count, lbl_CountScanner, enDirectoryName.Scaner)
        Catch ex As Exception

        End Try

        InitialDAO()


        'frm_Info.ShowDialog()

        BackgroundWorker1.RunWorkerAsync()

    End Sub

    Function DBEngine() As Object
        Dim dbe1 As Object   ' DAO.DBEngine
        dbe1 = CreateObject("DAO.DbEngine.120")

        'Thread.Sleep(15000)

        Return dbe1

        'Dim dbe As Object = Nothing
        'dbe = CreateObject("DAO.DbEngine.120")

        'Return "test"
    End Function

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        dbe = DBEngine()
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        status = statusON
    End Sub

    Sub InitialDAO()

    End Sub

    Private Sub lst_Jpg_Bmp_DoubleClick(sender As Object, e As EventArgs) Handles lst_Jpg.DoubleClick, lst_Bmp.DoubleClick
        listBox_DoubleClick_Image(CType(sender, ListBox), lst_SelectedImages)
    End Sub

    Public Sub listBox_DoubleClick_Image(listBox As ListBox, listBox_Selected As ListBox)

        Try
            If MouseCursor > (listBox.Items.Count * listBox.ItemHeight) Then Exit Sub

            If listBox.Items.Count = 0 Then Exit Sub

            ListSelectedFiles.Add(fullNamePathImage)

            listBox_Selected.Items.Add(listBox.SelectedItem)

            subEnabled_Buttons(cmd_MoveUp, cmd_MoveDown, cmd_NextStep, True)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_Flip270_Click(sender As Object, e As EventArgs) Handles cmd_Flip270.Click
        subFlip_Image(RotateFlipType.Rotate270FlipNone, fullNamePathImage, img_PictureShow)
    End Sub

    Private Sub cmd_Flip90_Click(sender As Object, e As EventArgs) Handles cmd_Flip90.Click
        subFlip_Image(RotateFlipType.Rotate90FlipNone, fullNamePathImage, img_PictureShow)
    End Sub

    Private Sub PictureShow_DoubleClick(sender As Object, e As EventArgs) Handles img_PictureShow.DoubleClick
        If Not IsNothing(lst_SelectedImages.SelectedItem) Or
                                        Not IsNothing(lst_Bmp.SelectedItem) Or
                                        Not IsNothing(lst_Jpg.SelectedItem) Then
            frm_ShowImage1.ShowDialog()
        End If

    End Sub

    Private Sub lst_Scanner_Click(sender As Object, e As EventArgs)
        If Not frm_SaveDoc.listBox_ShowImages.SelectedIndex = -1 Then frm_SaveDoc.listBox_ShowImages.Items.Clear()
        frm_SaveDoc.ShowDialog()
    End Sub

    Private Sub Разработка_Click(sender As Object, e As EventArgs) Handles mnu_TheProgram.Click
        frm_AboutTheProgram.ShowDialog()
    End Sub

    Private Sub lst_SelectedFiles_DoubleClick(sender As Object, e As EventArgs) Handles lst_SelectedImages.DoubleClick
        Try
            If Not lst_SelectedImages.Items.Count = 0 Then

                If MouseCursor > (lst_SelectedImages.Items.Count * lst_SelectedImages.ItemHeight) Then
                    Exit Sub
                Else
                    frm_ShowImage1.Show()
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub lst_Scanner_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_Scaner.SelectedIndexChanged
        loadListBoxScaner(lst_Scaner.SelectedItem)
    End Sub

    Sub loadListBoxScaner(strItem As String)
        Dim Count As Integer = 0
        Try
            di_SelectedListFolder = New DirectoryInfo(String.Concat(di_Scaner.FullName, strItem))

            fs_SelectedListFolder = di_SelectedListFolder.GetFiles()

        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        lst_Jpg.BeginUpdate() : lst_Bmp.BeginUpdate()

        Label6.Text = "Имя папки: " & vbNewLine & di_SelectedListFolder.Name
        lst_Jpg.Items.Clear()
        lst_Bmp.Items.Clear()

        ' Заполнение каждого ListBox-a, соответственно по расширению файла
        For Each currentFile As FileSystemInfo In fs_SelectedListFolder

            Dim lisExt As New List(Of String) From {".JPG", ".JPEG", ".TIF", ".TIFF"}  '".PDF"

            If lisExt.Contains(currentFile.Extension.ToUpper) Then
                lst_Jpg.Items.Add(currentFile)
                Count += 1
            End If

            If currentFile.Extension = ".BMP" Or currentFile.Extension = ".bmp" Then
                lst_Bmp.Items.Add(currentFile)
                Count += 1
            End If

        Next

        subCountImageInfo(Count, lbl_DirectorySelect, enDirectoryName.CurrentDirectoryImages)

        lbl_DirectorySelect.Visible = True

        ' Для включения обновления ListBox'a
        lst_Jpg.EndUpdate() : lst_Bmp.EndUpdate()


    End Sub

    Private Sub ВыборНовогоПутиПапкиToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ВыборНовогоПутиПапкиToolStripMenuItem.Click
        'dirNameScaner = FolderBrowserDialog1.SelectedPath & "\"

        Dim Result As Integer = FolderBrowserDialog1.ShowDialog    'OpenFileDialog1.ShowDialog()

        If Result = DialogResult.OK Then
            My.Settings.path_Scaner = FolderBrowserDialog1.SelectedPath & "\"
            My.Settings.Save()
        End If

        Dim DirInfo As FileSystemInfo
        Dim Count As Integer = 0

        cmd_NextStep.Enabled = False

        Try

            di_Scaner = New DirectoryInfo(My.Settings.path_Scaner)
            fs_Scaner = di_Scaner.GetDirectories()

            Label3.Text = di_Scaner.Name

            Label6.Text = "Имя папки: " & di_Scaner.Name

            lst_Scaner.Items.Clear()
            lst_Bmp.Items.Clear()
            lst_Jpg.Items.Clear()

            For Each DirInfo In fs_Scaner

                lst_Scaner.Items.Add(DirInfo.Name)
                Count += 1

            Next

            lst_Scaner.Sorted = True

            lbl_CountScanner.Text = "Всего: " & Count & " изображений."

        Catch ex As Exception

            MessageBox.Show(ex.Message & vbNewLine & "Выбор папки был не коректным")
            'path_Scaner = FolderBrowserDialog1.SelectedPath & "\"

        End Try

    End Sub

    Private Sub mnc_Delete_Click(sender As Object, e As EventArgs) Handles mnc_Delete.Click
        Dim s As String, i As Integer = 0
        Try
            If lst_SelectedImages.SelectedIndex = -1 Then Exit Sub

            ListSelectedFiles.RemoveAt(lst_SelectedImages.SelectedIndex)

            lst_SelectedImages.Items.Clear()

            If ListSelectedFiles.Count = 0 Then
                subEnabled_Buttons(cmd_MoveUp, cmd_MoveDown, cmd_NextStep, False)
            Else
                For Each s In ListSelectedFiles

                    i = s.LastIndexOf("\") + 2
                    s = Mid(s, i)
                    lst_SelectedImages.Items.Add(s)

                Next
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnc_DeleteAll_Click(sender As Object, e As EventArgs) Handles mnc_DeleteAll.Click
        Try
            lst_SelectedImages.Items.Clear()    ' ListBox
            ListSelectedFiles.Clear()           ' ArrayList
            subEnabled_Buttons(cmd_MoveUp, cmd_MoveDown, cmd_NextStep, False)
        Catch ex As Exception

        End Try
    End Sub


    Private Sub КакПользоватсяПрограммойToolStripMenuItem_Click(sender As Object, e As EventArgs)
        frm_HelpFAQ.ShowDialog()
    End Sub

    Private Sub mnc_ShowImage_Click_1(sender As Object, e As EventArgs) Handles mnc_ShowImage.Click
        frm_ShowImage1.ShowDialog()
    End Sub

    Dim indexListBoxCurrent As Integer
    Private Sub btn_NextStep_Click(sender As Object, e As EventArgs) Handles cmd_NextStep.Click
        Try
            frm_SaveDoc.ShowDialog()
            loadListBoxScaner(lst_Scaner.SelectedItem)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub mnc_AddImage_Click(sender As Object, e As EventArgs) Handles mnc_AddImage.Click
        Dim listBox As ListBox
        listBox = CType(ContextMenuStrip2.SourceControl, ListBox)
        Dim s As String = listBox.Name

        listBox_DoubleClick_Image(listBox, lst_SelectedImages)

    End Sub

#Region "    lst_Jpg_MouseDown"

    'Private Sub lst_Jpg_MouseDown(sender As Object, e As MouseEventArgs) Handles lst_Jpg.MouseDown
    '    lst_Jpg.Focus()
    '    Try
    '        If e.Button = Windows.Forms.MouseButtons.Right Then
    '            If lst_Jpg.Items.Count = 0 Then
    '                mnc_AddImage.Visible = False
    '                mnc_ShowImage.Visible = False

    '                Exit Sub
    '            Else
    '                ' Определение при нажатии правой кнопки вне элемента
    '                If e.Y > lst_Jpg.Items.Count * 13 Then
    '                    mnc_AddImage.Visible = False
    '                    mnc_ShowImage.Visible = False
    '                    Exit Sub
    '                End If

    '                mnc_AddImage.Visible = True
    '                mnc_ShowImage.Visible = True

    '                Dim test1 As Integer = lst_Jpg.Height
    '                Dim test2 As Integer = e.Y
    '                'Dim test3 As Integer = e.Locatio

    '                'Dim test2 As String = ContextMenuStrip2.SourceControl.ToString

    '                lst_Jpg.SelectedIndex = Fix(e.Y / lst_Jpg.ItemHeight)
    '                lst_Jpg.SelectedItem = Fix(e.Y / lst_Jpg.ItemHeight)

    '                'pic_PictureShow.ImageLocation = FileNamePic
    '                Me.pic_PictureShow.Visible = True

    '            End If
    '        End If

    '        If e.Button = Windows.Forms.MouseButtons.Left Then
    '            If e.Y > lst_Jpg.Items.Count * lst_Jpg.ItemHeight Then
    '                MouseCursor = e.Y
    '                Exit Sub
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    MouseCursor = 0

    'End Sub

    'Private Sub lst_Bmp_MouseDown(sender As Object, e As MouseEventArgs) Handles lst_Bmp.MouseDown
    '    lst_Bmp.Focus()
    '    Try
    '        If e.Button = Windows.Forms.MouseButtons.Right Then
    '            If lst_Bmp.Items.Count = 0 Then
    '                ContextMenuStrip1.Visible = False
    '                mnc_AddImage.Visible = False
    '                mnc_ShowImage.Visible = False

    '                Exit Sub
    '            Else
    '                ' Определение при нажатии правой кнопки вне элемента
    '                If e.Y > lst_Bmp.Items.Count * 13 Then
    '                    mnc_AddImage.Visible = False
    '                    mnc_ShowImage.Visible = False
    '                    Exit Sub
    '                End If
    '                mnc_AddImage.Visible = True
    '                mnc_ShowImage.Visible = True
    '                lst_Bmp.SelectedIndex = Fix(e.Y / lst_Bmp.ItemHeight)
    '                lst_Bmp.SelectedItem = Fix(e.Y / lst_Bmp.ItemHeight)

    '                'ListFiles.Add(FileNamePic)
    '                Me.pic_PictureShow.Visible = True
    '            End If
    '        End If

    '        If e.Button = Windows.Forms.MouseButtons.Left Then
    '            If e.Y > lst_Bmp.Items.Count * lst_Bmp.ItemHeight Then
    '                MouseCursor = e.Y
    '                Exit Sub
    '            End If
    '        End If
    '    Catch ex As Exception

    '    End Try
    '    MouseCursor = 0
    'End Sub

#End Region
#Region "    lst_SelectedFiles_MouseDown"
    'Private Sub lst_SelectedFiles_MouseDown(sender As Object, e As MouseEventArgs) Handles lst_SelectedImages.MouseDown
    '    lst_SelectedImages.Focus()
    '    Try
    '        If e.Button = Windows.Forms.MouseButtons.Right Then
    '            If lst_SelectedImages.Items.Count = 0 Then
    '                ContextMenuStrip1.Visible = False
    '                mnc_Delete.Visible = False
    '                mnc_DeleteAll.Visible = False

    '                Exit Sub

    '            End If
    '        End If

    '        If e.Button = Windows.Forms.MouseButtons.Left Then
    '            If e.Y > lst_SelectedImages.Items.Count * lst_SelectedImages.ItemHeight Then
    '                MouseCursor = e.Y
    '                Exit Sub
    '            Else
    '                If lst_SelectedImages.Items.Count = 0 Then Exit Sub
    '                If lst_SelectedImages.Text = "" Then Exit Sub
    '                fullNamePathImage = lst_SelectedImages.SelectedItem 'dirNameScaner & lst_Scanner.Text & "\" & lst_SelectedFiles.Text

    '                pic_PictureShow.ImageLocation = fullNamePathImage
    '                pic_PictureShow.Refresh()
    '                Me.pic_PictureShow.Visible = True
    '            End If
    '        End If

    '    Catch ex As Exception

    '    End Try
    '    MouseCursor = 0
    'End Sub
#End Region

    Private Sub lst_SelectedFiles_Enter(sender As Object, e As EventArgs)
        Try
            lst_SelectedImages.SelectedIndex = 0
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmd_MoveUp_Click(sender As Object, e As EventArgs) Handles cmd_MoveUp.Click
        subClick_Move(lst_SelectedImages, -1)
    End Sub

    Private Sub cmd_MoveDown_Click(sender As Object, e As EventArgs) Handles cmd_MoveDown.Click
        subClick_Move(lst_SelectedImages, +1)
    End Sub

    Private Sub lst_SelectedFiles_DragEnter(sender As Object, e As DragEventArgs) Handles lst_SelectedImages.DragEnter
        e.Effect = DragDropEffects.All
    End Sub

    Private Sub lst_SelectedFiles_DragDrop(sender As Object, e As DragEventArgs) Handles lst_SelectedImages.DragDrop

        Dim i As Integer
        Dim DirInfo2() As String = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

        For Each str As String In DirInfo2
            ListSelectedFiles.Add(str)

            i = str.LastIndexOf("\") + 2
            str = Mid(str, i, 20).Trim

            lst_SelectedImages.Items.Add(str)
        Next

        cmd_NextStep.Enabled = True
    End Sub

    Private Sub lst_SelectedImages_Click(sender As Object, e As EventArgs) Handles lst_SelectedImages.Click
        ListBox_Click(sender)

    End Sub

    Private Sub lst_Bmp_Click(sender As Object, e As EventArgs) Handles lst_Bmp.Click
        ListBox_Click(sender)
    End Sub


    Private Sub ListBox_Click(sender As Object)
        Dim listBox As ListBox
        listBox = CType(sender, ListBox)
        Try
            fullNamePathImage = di_SelectedListFolder.FullName & "\" & listBox.Text

            subListBox_Click(listBox, fullNamePathImage, img_PictureShow)
            img_PictureShow.ImageLocation = fullNamePathImage

            lbl_CurrentImage.Text = "Текущее изображение: " & listBox.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lst_Jpg_Click(sender As Object, e As EventArgs) Handles lst_Jpg.Click
        Try
            fullNamePathImage = di_SelectedListFolder.FullName & "\" & lst_Jpg.Text

            subListBox_Click(lst_Jpg, fullNamePathImage, img_PictureShow)
            img_PictureShow.ImageLocation = fullNamePathImage
            lbl_CurrentImage.Text = "Текущее изображение: " & lst_Jpg.Text
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Testing.ShowDialog()
        frm_Test2.Show()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'dbe = CreateObject("DAO.DbEngine.120")
        'Timer2.Stop()
        'MessageBox.Show("DAO LOAD")
    End Sub

End Class
