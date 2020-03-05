<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'frm_Screensaver.ShowDialog()

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.mnu_Settings = New System.Windows.Forms.ToolStripMenuItem()
        Me.ВыборНовогоПутиПапкиToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lst_SelectedImages = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnc_Delete = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnc_DeleteAll = New System.Windows.Forms.ToolStripMenuItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.mnu_TheProgram = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_NextStep = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lst_Bmp = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnc_AddImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnc_ShowImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbl_CountScanner = New System.Windows.Forms.Label()
        Me.lst_Scaner = New System.Windows.Forms.ListBox()
        Me.lbl_DirectorySelect = New System.Windows.Forms.Label()
        Me.lst_Jpg = New System.Windows.Forms.ListBox()
        Me.ContextMenuStrip3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.lbl_CurrentImage = New System.Windows.Forms.Label()
        Me.cmd_MoveDown = New System.Windows.Forms.Button()
        Me.cmd_MoveUp = New System.Windows.Forms.Button()
        Me.cmd_Next = New System.Windows.Forms.Button()
        Me.cmd_Previos = New System.Windows.Forms.Button()
        Me.cmd_Flip90 = New System.Windows.Forms.Button()
        Me.img_PictureShow = New System.Windows.Forms.PictureBox()
        Me.cmd_Flip270 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.lblPathScan = New System.Windows.Forms.Label()
        Me.btnLoadScaner = New System.Windows.Forms.Button()
        Me.txtScanerPath = New System.Windows.Forms.TextBox()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.img_PictureShow, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnu_Settings
        '
        Me.mnu_Settings.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ВыборНовогоПутиПапкиToolStripMenuItem})
        Me.mnu_Settings.Name = "mnu_Settings"
        Me.mnu_Settings.Size = New System.Drawing.Size(79, 20)
        Me.mnu_Settings.Text = "Настройки"
        '
        'ВыборНовогоПутиПапкиToolStripMenuItem
        '
        Me.ВыборНовогоПутиПапкиToolStripMenuItem.Name = "ВыборНовогоПутиПапкиToolStripMenuItem"
        Me.ВыборНовогоПутиПапкиToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.ВыборНовогоПутиПапкиToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ВыборНовогоПутиПапкиToolStripMenuItem.Text = "Путь к сканеру"
        '
        'lst_SelectedImages
        '
        Me.lst_SelectedImages.AllowDrop = True
        Me.lst_SelectedImages.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst_SelectedImages.ContextMenuStrip = Me.ContextMenuStrip1
        Me.lst_SelectedImages.FormattingEnabled = True
        Me.lst_SelectedImages.Location = New System.Drawing.Point(9, 20)
        Me.lst_SelectedImages.Name = "lst_SelectedImages"
        Me.lst_SelectedImages.Size = New System.Drawing.Size(347, 82)
        Me.lst_SelectedImages.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnc_Delete, Me.mnc_DeleteAll})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(192, 48)
        '
        'mnc_Delete
        '
        Me.mnc_Delete.Name = "mnc_Delete"
        Me.mnc_Delete.Size = New System.Drawing.Size(191, 22)
        Me.mnc_Delete.Text = "Удалить выделенный"
        '
        'mnc_DeleteAll
        '
        Me.mnc_DeleteAll.Name = "mnc_DeleteAll"
        Me.mnc_DeleteAll.Size = New System.Drawing.Size(191, 22)
        Me.mnc_DeleteAll.Text = "Удалить все"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'mnu_TheProgram
        '
        Me.mnu_TheProgram.Name = "mnu_TheProgram"
        Me.mnu_TheProgram.Size = New System.Drawing.Size(97, 20)
        Me.mnu_TheProgram.Text = "О программе!"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_Settings, Me.mnu_TheProgram})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(754, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.lst_SelectedImages)
        Me.GroupBox1.Controls.Add(Me.cmd_NextStep)
        Me.GroupBox1.Location = New System.Drawing.Point(316, 386)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(365, 151)
        Me.GroupBox1.TabIndex = 46
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Выбранные файлы:"
        '
        'cmd_NextStep
        '
        Me.cmd_NextStep.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_NextStep.Enabled = False
        Me.cmd_NextStep.Location = New System.Drawing.Point(9, 107)
        Me.cmd_NextStep.Name = "cmd_NextStep"
        Me.cmd_NextStep.Size = New System.Drawing.Size(347, 38)
        Me.cmd_NextStep.TabIndex = 1
        Me.cmd_NextStep.Text = "Перейти на другую форму для сохранения выбранных файлов"
        Me.cmd_NextStep.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label6.Location = New System.Drawing.Point(152, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 31)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Имя папки"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(152, 316)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(126, 16)
        Me.Label5.TabIndex = 39
        Me.Label5.Text = "Формат картинок BMP"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(152, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 16)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Формат картинок JPG"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lst_Bmp
        '
        Me.lst_Bmp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst_Bmp.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lst_Bmp.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lst_Bmp.FormattingEnabled = True
        Me.lst_Bmp.Location = New System.Drawing.Point(152, 335)
        Me.lst_Bmp.Name = "lst_Bmp"
        Me.lst_Bmp.Size = New System.Drawing.Size(158, 173)
        Me.lst_Bmp.Sorted = True
        Me.lst_Bmp.TabIndex = 3
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnc_AddImage, Me.mnc_ShowImage})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip2"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(251, 48)
        '
        'mnc_AddImage
        '
        Me.mnc_AddImage.Name = "mnc_AddImage"
        Me.mnc_AddImage.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.mnc_AddImage.Size = New System.Drawing.Size(250, 22)
        Me.mnc_AddImage.Text = "Добавить в список"
        '
        'mnc_ShowImage
        '
        Me.mnc_ShowImage.Name = "mnc_ShowImage"
        Me.mnc_ShowImage.Size = New System.Drawing.Size(250, 22)
        Me.mnc_ShowImage.Text = "Показать выделенную картинку"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(14, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(134, 31)
        Me.Label3.TabIndex = 36
        Me.Label3.Text = "Label3"
        '
        'lbl_CountScanner
        '
        Me.lbl_CountScanner.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_CountScanner.Location = New System.Drawing.Point(10, 524)
        Me.lbl_CountScanner.Name = "lbl_CountScanner"
        Me.lbl_CountScanner.Size = New System.Drawing.Size(136, 32)
        Me.lbl_CountScanner.TabIndex = 35
        Me.lbl_CountScanner.Text = "lbl_CountScanner"
        '
        'lst_Scaner
        '
        Me.lst_Scaner.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst_Scaner.FormattingEnabled = True
        Me.lst_Scaner.Location = New System.Drawing.Point(15, 88)
        Me.lst_Scaner.Name = "lst_Scaner"
        Me.lst_Scaner.Size = New System.Drawing.Size(133, 420)
        Me.lst_Scaner.Sorted = True
        Me.lst_Scaner.TabIndex = 1
        '
        'lbl_DirectorySelect
        '
        Me.lbl_DirectorySelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lbl_DirectorySelect.Location = New System.Drawing.Point(152, 524)
        Me.lbl_DirectorySelect.Name = "lbl_DirectorySelect"
        Me.lbl_DirectorySelect.Size = New System.Drawing.Size(136, 32)
        Me.lbl_DirectorySelect.TabIndex = 33
        Me.lbl_DirectorySelect.Text = "lbl_DirectorySelect"
        Me.lbl_DirectorySelect.Visible = False
        '
        'lst_Jpg
        '
        Me.lst_Jpg.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lst_Jpg.ContextMenuStrip = Me.ContextMenuStrip2
        Me.lst_Jpg.FormattingEnabled = True
        Me.lst_Jpg.Location = New System.Drawing.Point(155, 101)
        Me.lst_Jpg.Name = "lst_Jpg"
        Me.lst_Jpg.Size = New System.Drawing.Size(158, 212)
        Me.lst_Jpg.Sorted = True
        Me.lst_Jpg.TabIndex = 2
        '
        'ContextMenuStrip3
        '
        Me.ContextMenuStrip3.Name = "ContextMenuStrip3"
        Me.ContextMenuStrip3.Size = New System.Drawing.Size(61, 4)
        '
        'lbl_CurrentImage
        '
        Me.lbl_CurrentImage.AutoSize = True
        Me.lbl_CurrentImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.lbl_CurrentImage.Location = New System.Drawing.Point(313, 51)
        Me.lbl_CurrentImage.Name = "lbl_CurrentImage"
        Me.lbl_CurrentImage.Size = New System.Drawing.Size(158, 17)
        Me.lbl_CurrentImage.TabIndex = 49
        Me.lbl_CurrentImage.Text = "Текущее изображение"
        '
        'cmd_MoveDown
        '
        Me.cmd_MoveDown.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_MoveDown.Image = Global.MoveImage.My.Resources.Resources.стрелка_вниз2_1
        Me.cmd_MoveDown.Location = New System.Drawing.Point(687, 439)
        Me.cmd_MoveDown.Name = "cmd_MoveDown"
        Me.cmd_MoveDown.Size = New System.Drawing.Size(38, 27)
        Me.cmd_MoveDown.TabIndex = 48
        Me.cmd_MoveDown.UseVisualStyleBackColor = True
        '
        'cmd_MoveUp
        '
        Me.cmd_MoveUp.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_MoveUp.Image = Global.MoveImage.My.Resources.Resources.стрелка_вверх2_1
        Me.cmd_MoveUp.Location = New System.Drawing.Point(687, 406)
        Me.cmd_MoveUp.Name = "cmd_MoveUp"
        Me.cmd_MoveUp.Size = New System.Drawing.Size(38, 27)
        Me.cmd_MoveUp.TabIndex = 47
        Me.cmd_MoveUp.UseVisualStyleBackColor = True
        '
        'cmd_Next
        '
        Me.cmd_Next.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_Next.Image = CType(resources.GetObject("cmd_Next.Image"), System.Drawing.Image)
        Me.cmd_Next.Location = New System.Drawing.Point(612, 348)
        Me.cmd_Next.Name = "cmd_Next"
        Me.cmd_Next.Size = New System.Drawing.Size(33, 32)
        Me.cmd_Next.TabIndex = 45
        Me.cmd_Next.UseVisualStyleBackColor = True
        Me.cmd_Next.Visible = False
        '
        'cmd_Previos
        '
        Me.cmd_Previos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_Previos.Image = CType(resources.GetObject("cmd_Previos.Image"), System.Drawing.Image)
        Me.cmd_Previos.Location = New System.Drawing.Point(573, 348)
        Me.cmd_Previos.Name = "cmd_Previos"
        Me.cmd_Previos.Size = New System.Drawing.Size(33, 32)
        Me.cmd_Previos.TabIndex = 44
        Me.cmd_Previos.UseVisualStyleBackColor = True
        Me.cmd_Previos.Visible = False
        '
        'cmd_Flip90
        '
        Me.cmd_Flip90.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_Flip90.Image = CType(resources.GetObject("cmd_Flip90.Image"), System.Drawing.Image)
        Me.cmd_Flip90.Location = New System.Drawing.Point(355, 347)
        Me.cmd_Flip90.Name = "cmd_Flip90"
        Me.cmd_Flip90.Size = New System.Drawing.Size(36, 33)
        Me.cmd_Flip90.TabIndex = 5
        Me.cmd_Flip90.UseVisualStyleBackColor = True
        '
        'img_PictureShow
        '
        Me.img_PictureShow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.img_PictureShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.img_PictureShow.ErrorImage = Global.MoveImage.My.Resources.Resources.Нет_изображения
        Me.img_PictureShow.Location = New System.Drawing.Point(316, 71)
        Me.img_PictureShow.Name = "img_PictureShow"
        Me.img_PictureShow.Size = New System.Drawing.Size(430, 271)
        Me.img_PictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.img_PictureShow.TabIndex = 41
        Me.img_PictureShow.TabStop = False
        '
        'cmd_Flip270
        '
        Me.cmd_Flip270.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cmd_Flip270.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.cmd_Flip270.ForeColor = System.Drawing.SystemColors.ScrollBar
        Me.cmd_Flip270.Image = CType(resources.GetObject("cmd_Flip270.Image"), System.Drawing.Image)
        Me.cmd_Flip270.Location = New System.Drawing.Point(316, 347)
        Me.cmd_Flip270.Name = "cmd_Flip270"
        Me.cmd_Flip270.Size = New System.Drawing.Size(36, 33)
        Me.cmd_Flip270.TabIndex = 4
        Me.cmd_Flip270.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.cmd_Flip270.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(666, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 20)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "Test"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'Timer2
        '
        '
        'BackgroundWorker1
        '
        '
        'lblPathScan
        '
        Me.lblPathScan.AutoSize = True
        Me.lblPathScan.Location = New System.Drawing.Point(12, 27)
        Me.lblPathScan.Name = "lblPathScan"
        Me.lblPathScan.Size = New System.Drawing.Size(85, 13)
        Me.lblPathScan.TabIndex = 51
        Me.lblPathScan.Text = "Путь сканенра:"
        '
        'btnLoadScaner
        '
        Me.btnLoadScaner.Location = New System.Drawing.Point(583, 22)
        Me.btnLoadScaner.Name = "btnLoadScaner"
        Me.btnLoadScaner.Size = New System.Drawing.Size(75, 23)
        Me.btnLoadScaner.TabIndex = 53
        Me.btnLoadScaner.Text = "Перейти"
        Me.btnLoadScaner.UseVisualStyleBackColor = True
        '
        'txtScanerPath
        '
        Me.txtScanerPath.Location = New System.Drawing.Point(103, 24)
        Me.txtScanerPath.Name = "txtScanerPath"
        Me.txtScanerPath.Size = New System.Drawing.Size(476, 20)
        Me.txtScanerPath.TabIndex = 54
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(754, 558)
        Me.Controls.Add(Me.txtScanerPath)
        Me.Controls.Add(Me.btnLoadScaner)
        Me.Controls.Add(Me.lblPathScan)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lbl_CurrentImage)
        Me.Controls.Add(Me.cmd_MoveDown)
        Me.Controls.Add(Me.cmd_MoveUp)
        Me.Controls.Add(Me.cmd_Next)
        Me.Controls.Add(Me.cmd_Previos)
        Me.Controls.Add(Me.cmd_Flip90)
        Me.Controls.Add(Me.img_PictureShow)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmd_Flip270)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lst_Bmp)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lbl_CountScanner)
        Me.Controls.Add(Me.lst_Scaner)
        Me.Controls.Add(Me.lbl_DirectorySelect)
        Me.Controls.Add(Me.lst_Jpg)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Форма выбора отсканированных изображений"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.img_PictureShow, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmd_Next As System.Windows.Forms.Button
    Friend WithEvents cmd_Previos As System.Windows.Forms.Button
    Friend WithEvents cmd_Flip90 As System.Windows.Forms.Button
    Friend WithEvents mnu_Settings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents img_PictureShow As System.Windows.Forms.PictureBox
    Friend WithEvents lst_SelectedImages As System.Windows.Forms.ListBox
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnc_Delete As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog2 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog2 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents mnu_TheProgram As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_NextStep As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmd_Flip270 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lst_Bmp As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lbl_CountScanner As System.Windows.Forms.Label
    Friend WithEvents lst_Scaner As System.Windows.Forms.ListBox
    Friend WithEvents lbl_DirectorySelect As System.Windows.Forms.Label
    Friend WithEvents lst_Jpg As System.Windows.Forms.ListBox
    Friend WithEvents ВыборНовогоПутиПапкиToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnc_ShowImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContextMenuStrip3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnc_DeleteAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnc_AddImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_MoveUp As System.Windows.Forms.Button
    Friend WithEvents cmd_MoveDown As System.Windows.Forms.Button
    Friend WithEvents lbl_CurrentImage As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents lblPathScan As System.Windows.Forms.Label
    Friend WithEvents btnLoadScaner As Button
    Friend WithEvents txtScanerPath As System.Windows.Forms.TextBox
End Class
