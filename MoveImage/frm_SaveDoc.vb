Imports System.Data.OleDb
Imports System.Windows.Forms
'Imports Microsoft.Office.Interop.Access.Dao
Imports System.IO
Imports System.Collections
Imports System.Collections.Generic
Imports System.Threading

Public Class frm_SaveDoc

#Region "    Объявление переменных			"
    Dim a, b, c As String
    Dim CountImage As Integer = 0
    Dim s() As String

    Dim ListGroupDoc() As String = New String() {"Административная", "Техническая", "Технологическая"}

    ''' <summary>
    ''' Имя папки конкретного документа в конечной папке Технческой документации:
    ''' ЗП - (Запрос производства)\...
    ''' </summary>
    ''' <remarks></remarks>
    Dim dirEndPathSave As String

    ''' <summary>
    ''' Имена картинок
    ''' </summary>
    ''' <remarks></remarks>
    Dim nameFilesSave As String

    Dim dataGridView_Sector As DataGridView

#End Region

	Function ListsClassesLoad(groupName As String) As List(Of cls_TypeDoc)
		Dim NewClasses As New List(Of cls_TypeDoc)
		Select Case groupName
			Case "Административная"
				'NewClasses = New List(Of cls_TypeDoc)() From {New cls_SZ}
				'Dim ddd As New cls_ExecutiveOrder
                NewClasses = New List(Of cls_TypeDoc)() From {New cls_SZ, New cls_Akt,
                                                              New cls_ExecutiveOrder, New cls_ExecutiveOrder_UA,
                                                              New cls_Order, New cls_Order_UA, New cls_Protocol,
                                                              New cls_DZ}

			Case "Техническая"
				NewClasses = New List(Of cls_TypeDoc)() From {New cls_BPPP, New cls_SKN, New cls_VD,
															  New cls_ZP, New cls_IZV, New cls_IZV_KOS,
															  New cls_IZV_OIR, New cls_KTSP, New cls_LIR,
															  New cls_NGO, New cls_PSO, New cls_RZ,
															  New cls_USP, New cls_ZM}

			Case "Технологическая"
				NewClasses = New List(Of cls_TypeDoc)() From {New cls_Cherteg}

		End Select

		Return NewClasses
	End Function

#Region "    Заполнение классов в список		"

	'Dim ListClasses As List(Of cls_TypeDoc) = New List(Of cls_TypeDoc)() From {New cls_BPPP, New cls_SKN, New cls_VD,
	'                                                                           New cls_ZP, New cls_IZV, New cls_IZV_KOS,
	'                                                                           New cls_IZV_OIR, New cls_KTSP, New cls_LIR,
	'                                                                           New cls_NGO, New cls_PSO, New cls_RZ,
	'                                                                           New cls_USP, New cls_ZM, New cls_SZ}

#End Region

	Dim ListClasses As List(Of cls_TypeDoc)
	Private Sub frm_SaveDoc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Array.Sort(ListTypeDoc)

		statusStripLabel.Text = status
		cmd_SectorShow.Enabled = False

		Me.Height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height
		Me.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width

		cmd_PreViem.Enabled = False
		cmd_SaveDoc.Enabled = False

		cbx_TypeDoc.Items.Clear()
		cbx_TypeDoc.Enabled = False

		'For Each ss As cls_TypeDoc In ListClasses
		'cbx_TypeDoc.Items.Add(ss.name)
		'Next

		Panel1.Controls.Clear()


		listBox_ShowImages.Items.Clear()
		ListFilesSave.Clear()

		Dim s As String
		Dim i As Integer

		For Each s In ListSelectedFiles

			i = s.LastIndexOf("\") + 2
			s = Mid(s, i, 20).Trim

			listBox_ShowImages.Items.Add(s)

		Next
		cbx_GroupDoc.Text = "Выберите группу документа"
		cbx_TypeDoc.Text = "Выберите тип документа"

		listBox_ShowImages.SelectedIndex = 0
	End Sub

    Function DBEngine777() As Object
        Dim dbe1 As Object   ' DAO.DBEngine
        dbe1 = CreateObject("DAO.DbEngine.120")

        'Thread.Sleep(15000)

        Return dbe1

        'Dim dbe As Object = Nothing
        'dbe = CreateObject("DAO.DbEngine.120")

        'Return "test"
    End Function

	' Происходит когда срабатывает метод BackgroundWorker1.RunWorkerAsync()
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

		'ListClasses = ListsClassesLoad(cbx_GroupDoc.Text)
		ListClasses = ListsClassesLoad(e.Argument.ToString)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ProgressBar1.Visible = False
		cbx_TypeDoc.Visible = True

		Try
			'cbx_TypeDoc.Visible = False
			'ProgressBar1.Visible = True

			'BackgroundWorker1.RunWorkerAsync()

			cmd_PreViem.Enabled = False
			Panel1.Controls.Clear()
			cbx_TypeDoc.Items.Clear()
			'ListClasses = ListsClassesLoad(cbx_GroupDoc.Text)
            ListClasses.Sort(Function(name1 As cls_TypeDoc, name2 As cls_TypeDoc) name1.type_doc.CompareTo(name2.type_doc))

            For Each ss As cls_TypeDoc In ListClasses
				cbx_TypeDoc.Items.Add(ss.type_doc)
				'cbx_TypeDoc.Items.AddRange(ss.type_docRange)
            Next

            cbx_TypeDoc.Enabled = True
        Catch ex As Exception
            MessageBox.Show("По данной группе нет ни одного типа документа")
            cbx_TypeDoc.Enabled = False
        End Try

    End Sub
    Private Sub cbx_GroupDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_GroupDoc.SelectedIndexChanged
        'cbx_TypeDoc.Visible = False
        'ProgressBar1.Visible = True

        'BackgroundWorker1.RunWorkerAsync(cbx_GroupDoc.Text)

        Try
            'cbx_TypeDoc.Visible = False
            'ProgressBar1.Visible = True

            'BackgroundWorker1.RunWorkerAsync()

            cmd_PreViem.Enabled = False
            Panel1.Controls.Clear()
            cbx_TypeDoc.Items.Clear()
            ListClasses = ListsClassesLoad(cbx_GroupDoc.Text)
            ListClasses.Sort(Function(name1 As cls_TypeDoc, name2 As cls_TypeDoc) name1.type_doc.CompareTo(name2.type_doc))

            For Each ss As cls_TypeDoc In ListClasses
				'cbx_TypeDoc.Items.AddRange(ss.type_docRange)
				cbx_TypeDoc.Items.Add(ss.type_doc)
            Next

            cbx_TypeDoc.Enabled = True
        Catch ex As Exception
            MessageBox.Show("По данной группе нет ни одного типа документа")
            cbx_TypeDoc.Enabled = False
        End Try

        'If (Debugger.IsAttached) Then
        '    Debugger.Break()
        'End If

		'If cbx_GroupDoc.Text = "Техническая" Then
		'cmd_SectorShow.Enabled = True
		'End If

    End Sub

    

    Sub cmdEnabled(asd As Boolean)
        cmd_SaveDoc.Enabled = asd
    End Sub

#Region "    Успешность выполнения сохранения						"


    ''' <summary>
    ''' Процедура выдает успешность выполнения сохранения
    ''' </summary>
    ''' <remarks></remarks>
    Sub Success()
        MsgBox("Папка с файлом успешно созданны!!!" & vbNewLine & vbNewLine & _
               "Папка находится: " & vbNewLine & _
               dirNameSave, MsgBoxStyle.Information, "Сообщение")

        Debug.Write("")

        cmd_SaveDoc.Enabled = False

        listBox_ShowImages.Items.Clear()

        MessageBox.Show("Операция прошла успешно!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()

        frm_Main.lst_SelectedImages.Items.Clear()
        ListFilesSave.Clear()
        ListSelectedFiles.Clear()

        frm_Main.cmd_NextStep.Enabled = False

        frm_ShowImage2.Dispose()
        Me.Dispose()
    End Sub

#End Region


#Region "    Кнопка для сохранения			"

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles cmd_SaveDoc.Click
        Dim Result As Integer

        If status = statusOFF Then
            MessageBox.Show("Подождите, идет идентификация программы..." & Environment.NewLine & _
                            "Статус идентификации можно просмотреть в левой нижней части текущего окна программы!")
            Exit Sub
        End If

        Try
            Result = MessageBox.Show("Желаете продолжить сохранение?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If Result = vbNo Then Exit Sub

            If Not Directory.Exists(path_SaveDocuments) Then
                MsgBox("Это сообщение означает, что конечная папка куда нужно сохранить файлы, не указана системой и ее требуется назначить вручную", MsgBoxStyle.Information, "Указать путь")
                Result = FolderBrowserDialog1.ShowDialog
                If Result = DialogResult.OK Then
                    path_SaveDocuments = FolderBrowserDialog1.SelectedPath & "\"
                Else
                    Exit Sub
                End If
            End If

            'DirectoryInfo fs = new DirectoryInfo(pathFile);
            'pathFile = fs.CreateSubdirectory(dtp_dateSZ.Value.Year.ToString()).FullName;

            Dim nnn As String = path_SaveDocuments & currentSelectClass.class_DirName & currentSelectClass.class_DirectoryFullName

            Dim fs As DirectoryInfo = New DirectoryInfo(path_SaveDocuments & currentSelectClass.class_DirName)
            dirNameSave = fs.CreateSubdirectory(currentSelectClass.class_FullPathSave).FullName

            'doc.SaveAs(pathFile + "\\" + fileName + ".docx", WdSaveFormat.wdFormatDocumentDefault);

            ' Окончательная папка для сохранения dirNameSave
            'dirNameSave = path_SaveDocuments & dirEndPathSave

            'Dim fs As DirectoryInfo = New DirectoryInfo(dirNameSave)

            'If fs.Exists Then
            'My.Computer.FileSystem.DeleteDirectory(dirNameSave, FileIO.DeleteDirectoryOption.DeleteAllContents)
            'End If

            'Directory.CreateDirectory(dirNameSave)

            SaveImagesEndPath(ListSelectedFiles, dirNameSave)


            If currentSelectClass.IsSaveDataBase() Then

                Dim message As String = "Теперь для типа документа '" & currentSelectClass.type_doc & "' имеется возможность сохранять сразу в базу данных!" & vbNewLine & _
                    "Сохранить в базу данных продолжить?"

                Dim resultDialog As DialogResult = MessageBox.Show(message, "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                If resultDialog = DialogResult.Yes Then
                    Dim type_doc = cbx_TypeDoc.Text
                    Dim num_doc = currentSelectClass.GetNumDoc()

                    currentSelectClass.SaveDataBaseCurrentClass(dbe, "ServerDBNew", type_doc, num_doc, s, ListFilesSave)
                End If

            End If

            'SaveDataBase(ListFilesSave, currentSelectClass)

            Success()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

    End Sub

#End Region

#Region "    Кнопка предварительный просмотр				"

	Private Sub cmd_PreViem_Click(sender As Object, e As EventArgs) Handles cmd_PreViem.Click

		'DirectoryInfo di = new DirectoryInfo(@"d:\1_test");	' создаем каталог

		' ищем в каталоге папку под именем если таковая иммется переменной var 
		' присваевается массив найденных папок тип переменной DirecoryInfo
		'var d = di.EnumerateDirectories("СКН 53961*");			

		'If cbx_GroupDoc.Text = "Техническая" Then
		'	If currentSelectClass.IsSaveDataBase() Then
		'		If s Is Nothing Then
		'			'Dim result As DialogResult
		'			MessageBox.Show("Укажите пожалуйста участок, которому относится документ!", "Сообщение")
		'			Exit Sub
		'		End If
		'	End If
		'End If
		

		Try
			dataPreviem_(ListClasses(cbx_TypeDoc.SelectedIndex))
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information)
			cmd_SaveDoc.Enabled = False
		End Try

	End Sub

#End Region

#Region "    Оббощенная процедура при нажатии на кнопку предварительный просмотр переименованных данных конкретного класса"

	''' <summary>
	''' Оббощенная процедура при нажатии на кнопку предварительный просмотр переименованных данных конкретного класса
	''' </summary>
	''' <param name="typeDoc"></param>
	''' <remarks></remarks>
	Sub dataPreviem(typeDoc As cls_TypeDoc)
		typeDoc.classFormation()

		nameFilesSave = typeDoc.NameFilesSaveDoc()
		nameFolderSaveDoc = typeDoc.NameFolderSaveDoc()
		dirEndPathSave = typeDoc.DirectoryEndPathSave()

		If TEST(path_SaveDocuments, dirEndPathSave, nameFilesSave) Then
			cmd_SaveDoc.Enabled = False
			Throw New Exception("Возможно, слишком длинное поле чертеж или примечание. Пересмотрите ввод и продолжите снова")
		End If

		lbl_DirName.Text = nameFolderSaveDoc
		RanameImages(nameFilesSave)
		cmd_SaveDoc.Enabled = True
	End Sub

#End Region

#Region "    Оббощенная процедура при нажатии на кнопку предварительный просмотр переименованных данных конкретного класса"

	''' <summary>
	''' Оббощенная процедура при нажатии на кнопку предварительный просмотр переименованных данных конкретного класса
	''' </summary>
	''' <param name="typeDoc"></param>
	''' <remarks></remarks>
	Sub dataPreviem_(typeDoc As cls_TypeDoc)

        If (Not typeDoc.classFormation()) Then Return

		Dim fileName As String = typeDoc.class_FileName
		Dim directoryName As String = typeDoc.class_FullPathSave
		Dim dirName As String = typeDoc.class_DirName

		nameFolderSaveDoc = typeDoc.NameFolderSaveDoc()
		dirEndPathSave = typeDoc.DirectoryEndPathSave()
		'nameFullPathSave вместо  directoryName
		If TEST(path_SaveDocuments, dirName + directoryName, fileName) Then
			cmd_SaveDoc.Enabled = False
			Throw New Exception("Возможно, слишком длинное поле чертеж или примечание. Пересмотрите ввод и продолжите снова")
		End If

		lbl_DirName.Text = nameFolderSaveDoc
		RanameImages_(typeDoc)
		cmd_SaveDoc.Enabled = True
	End Sub

#End Region

    Private Sub SelectedClassType(Of T As {cls_TypeDoc})(classType As T)
        AddHandler classType.delegateEnabledOFF, AddressOf cmdEnabled
        classType.LoadPanel(Panel1)
    End Sub

    Private Sub cbx_TypeDoc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbx_TypeDoc.SelectedIndexChanged
        Try
            currentSelectClass = ListClasses(cbx_TypeDoc.SelectedIndex)

            If Not currentSelectClass.isControlsLoad() Then
                currentSelectClass.initial()
            End If

            SelectedClassType(currentSelectClass)

			cmd_PreViem.Enabled = True

			If cbx_GroupDoc.Text = "Техническая" Then
				cmd_SectorShow.Enabled = currentSelectClass.IsSaveDataBase()
			End If

		Catch ex As Exception
			MessageBox.Show(ex.Message)

		End Try
    End Sub

    Private Sub СправкаToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles СправкаToolStripMenuItem.Click
        frm_HelpFAQ.ShowDialog()
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles listBox_ShowImages.SelectedIndexChanged
		img_PictureShow.ImageLocation = ListSelectedFiles(listBox_ShowImages.SelectedIndex).ToString()
        img_PictureShow.Refresh()
        img_PictureShow.Visible = True
        lbl_NameImage.Text = "Текущая картинка: " & listBox_ShowImages.SelectedItem.ToString
    End Sub

    Private Sub pic_PictureShow_DoubleClick(sender As Object, e As EventArgs) Handles img_PictureShow.DoubleClick
        frm_ShowImage2.Show()
    End Sub

#Region "    Проверка на допустимость длины сохранения полного пути файлов		"

    ''' <summary>
    ''' Проверка на допустимость длины сохранения полного пути файлов
    ''' </summary>
    ''' <param name="path_SaveDocuments"></param>
    ''' <param name="SaveDocuments"></param>
    ''' <param name="nameFile"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function TEST(path_SaveDocuments As String, SaveDocuments As String, nameFile As String) As Boolean
        Dim result As Boolean = False
		Dim temp As String = "0000000"
        Dim testString As String = path_SaveDocuments & SaveDocuments & nameFile & temp
        If testString.Length > 248 Then
            result = True
        End If

        Return result
    End Function

#End Region

#Region "    Процедура переименования картинок и помещение в ListBox на форме    "

    ''' <summary>
    ''' Процедура переименования картинок и помещие в ListBox на форме
    ''' </summary>
    ''' <param name="nameFolderSaveDoc"></param>
    ''' <remarks></remarks>
    Sub RanameImages(nameFolderSaveDoc As String)
        listBox_ShowImages.Items.Clear()
        ListFilesSave.Clear()

        Dim nameImage As String

        If ListSelectedFiles.Count = 1 Then
            nameImage = nameFolderSaveDoc
            listBox_ShowImages.Items.Add(nameImage & ".jpg")
            ListFilesSave.Add(nameImage & ".jpg")

            Exit Sub
        End If

		Do

			For i As Integer = 1 To ListSelectedFiles.Count
				nameImage = nameFolderSaveDoc & " _" & Format(i, "00")

				listBox_ShowImages.Items.Add(nameImage & ".jpg")
				ListFilesSave.Add(nameImage & ".jpg")
			Next

		Loop

	End Sub

#End Region

#Region "    Процедура переименования картинок и помещение в ListBox на форме    "

	






    ''' <summary>
    ''' Процедура переименования картинок и помещие в ListBox на форме
    ''' </summary>
    ''' <param name="typeDoc"></param>
    ''' <remarks></remarks>
    Sub RanameImages_(typeDoc As cls_TypeDoc)

        listBox_ShowImages.Items.Clear()
        ListFilesSave.Clear()

        Dim fileName As String = typeDoc.class_FileName
		Dim directoryName As String = typeDoc.class_FullPathSave
        Dim dirName As String = typeDoc.class_DirName

        Dim suffixIndex As Integer = 0
        Dim suffixText As String = ""

        Dim nameImage As String

        Dim di As DirectoryInfo = New DirectoryInfo(path_SaveDocuments & dirName & directoryName)

        If ListSelectedFiles.Count = 1 Then
            Do
				nameImage = fileName & suffixText
				Dim pathFile As String = path_SaveDocuments & dirName & directoryName & "\" & nameImage & ".jpg"
                If (File.Exists(pathFile)) Then
                    suffixIndex += 1
                    suffixText = "(" & suffixIndex & ")"
				Else
					Exit Do
                End If
			Loop
        End If


        Dim bool As Boolean = True

        Dim k As Integer = 1

		Do

			For i As Integer = 1 To ListSelectedFiles.Count
				nameImage = fileName & suffixText & " _" & Format(i, "00")

				Dim pathFile As String = path_SaveDocuments & dirName & directoryName & "\" & nameImage & ".jpg"
				If (File.Exists(pathFile)) Then
					suffixIndex += 1
					suffixText = "(" & suffixIndex & ")"
					bool = False
					Exit For
				Else
					bool = True
				End If
			Next

			If bool Then Exit Do

		Loop


		'Dim pathFile As String = path_SaveDocuments & dirName & directoryName & "\" & ListSelectedFiles

		If ListSelectedFiles.Count = 1 Then
			nameImage = fileName & suffixText

			listBox_ShowImages.Items.Add(nameImage & ".jpg")
			ListFilesSave.Add(nameImage & ".jpg")

			Exit Sub
		End If



		For i As Integer = 1 To ListSelectedFiles.Count
			nameImage = fileName & suffixText & " _" & Format(i, "00")

			listBox_ShowImages.Items.Add(nameImage & ".jpg")
			ListFilesSave.Add(nameImage & ".jpg")
		Next



	End Sub

#End Region

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If status = statusON Then
            'status = "Идет загрузка объекта..."
            statusStripLabel.Text = status
            'Button4.Enabled = True
            Timer1.Stop()
            'Me.Dispose()
        End If
    End Sub

    Private Sub cmd_OpenFormSector_Click(sender As Object, e As EventArgs) Handles cmd_SectorShow.Click
        cmd_SaveDoc.Enabled = False

        Dim d As Data = New Data()

        Dim frm As New frm_Sector(d)

        Dim result As DialogResult = frm.ShowDialog()
        s = d.Value


    End Sub


End Class