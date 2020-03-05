<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_SaveDoc
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

    'Является обязательной для конструктора форм Windows Forms

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Public Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_SaveDoc))
		Me.listBox_ShowImages = New System.Windows.Forms.ListBox()
		Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
		Me.СправкаToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
		Me.cmd_PreViem = New System.Windows.Forms.Button()
		Me.GroupBox2 = New System.Windows.Forms.GroupBox()
		Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
		Me.cmd_SectorShow = New System.Windows.Forms.Button()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.cbx_GroupDoc = New System.Windows.Forms.ComboBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.cbx_TypeDoc = New System.Windows.Forms.ComboBox()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.cmd_SaveDoc = New System.Windows.Forms.Button()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.lbl_DirName = New System.Windows.Forms.Label()
		Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
		Me.Label4 = New System.Windows.Forms.Label()
		Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
		Me.lbl_NameImage = New System.Windows.Forms.Label()
		Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
		Me.statusStripLabel = New System.Windows.Forms.ToolStripStatusLabel()
		Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
		Me.img_PictureShow = New System.Windows.Forms.PictureBox()
		Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
		Me.MenuStrip1.SuspendLayout()
		Me.GroupBox2.SuspendLayout()
		Me.StatusStrip1.SuspendLayout()
		CType(Me.img_PictureShow, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'listBox_ShowImages
		'
		Me.listBox_ShowImages.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.listBox_ShowImages.FormattingEnabled = True
		Me.listBox_ShowImages.HorizontalScrollbar = True
		Me.listBox_ShowImages.Location = New System.Drawing.Point(10, 487)
		Me.listBox_ShowImages.Name = "listBox_ShowImages"
		Me.listBox_ShowImages.ScrollAlwaysVisible = True
		Me.listBox_ShowImages.Size = New System.Drawing.Size(350, 82)
		Me.listBox_ShowImages.TabIndex = 0
		'
		'MenuStrip1
		'
		Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.СправкаToolStripMenuItem})
		Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
		Me.MenuStrip1.Name = "MenuStrip1"
		Me.MenuStrip1.Size = New System.Drawing.Size(950, 24)
		Me.MenuStrip1.TabIndex = 29
		Me.MenuStrip1.Text = "MenuStrip1"
		'
		'СправкаToolStripMenuItem
		'
		Me.СправкаToolStripMenuItem.Name = "СправкаToolStripMenuItem"
		Me.СправкаToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
		Me.СправкаToolStripMenuItem.Text = "Справка"
		'
		'cmd_PreViem
		'
		Me.cmd_PreViem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.cmd_PreViem.Location = New System.Drawing.Point(4, 364)
		Me.cmd_PreViem.Name = "cmd_PreViem"
		Me.cmd_PreViem.Size = New System.Drawing.Size(341, 27)
		Me.cmd_PreViem.TabIndex = 9
		Me.cmd_PreViem.Text = "ПРОВЕРИТЬ"
		Me.cmd_PreViem.UseVisualStyleBackColor = True
		'
		'GroupBox2
		'
		Me.GroupBox2.Controls.Add(Me.ProgressBar1)
		Me.GroupBox2.Controls.Add(Me.cmd_SectorShow)
		Me.GroupBox2.Controls.Add(Me.Label1)
		Me.GroupBox2.Controls.Add(Me.cbx_GroupDoc)
		Me.GroupBox2.Controls.Add(Me.Label3)
		Me.GroupBox2.Controls.Add(Me.cbx_TypeDoc)
		Me.GroupBox2.Controls.Add(Me.cmd_PreViem)
		Me.GroupBox2.Controls.Add(Me.Panel1)
		Me.GroupBox2.Location = New System.Drawing.Point(10, 27)
		Me.GroupBox2.Name = "GroupBox2"
		Me.GroupBox2.Size = New System.Drawing.Size(350, 397)
		Me.GroupBox2.TabIndex = 24
		Me.GroupBox2.TabStop = False
		Me.GroupBox2.Text = "Основные поля сохранения документа"
		'
		'ProgressBar1
		'
		Me.ProgressBar1.Location = New System.Drawing.Point(176, 46)
		Me.ProgressBar1.Name = "ProgressBar1"
		Me.ProgressBar1.Size = New System.Drawing.Size(103, 21)
		Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
		Me.ProgressBar1.TabIndex = 24
		Me.ProgressBar1.Visible = False
		'
		'cmd_SectorShow
		'
		Me.cmd_SectorShow.Location = New System.Drawing.Point(5, 73)
		Me.cmd_SectorShow.Name = "cmd_SectorShow"
		Me.cmd_SectorShow.Size = New System.Drawing.Size(339, 23)
		Me.cmd_SectorShow.TabIndex = 23
		Me.cmd_SectorShow.Text = "Указать участок"
		Me.cmd_SectorShow.UseVisualStyleBackColor = True
		'
		'Label1
		'
		Me.Label1.AutoSize = True
		Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.Label1.Location = New System.Drawing.Point(8, 22)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(124, 13)
		Me.Label1.TabIndex = 22
		Me.Label1.Text = "Группа документа:*"
		'
		'cbx_GroupDoc
		'
		Me.cbx_GroupDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbx_GroupDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.cbx_GroupDoc.FormattingEnabled = True
		Me.cbx_GroupDoc.Items.AddRange(New Object() {"Административная", "Техническая", "Технологическая"})
		Me.cbx_GroupDoc.Location = New System.Drawing.Point(176, 19)
		Me.cbx_GroupDoc.Name = "cbx_GroupDoc"
		Me.cbx_GroupDoc.Size = New System.Drawing.Size(167, 21)
		Me.cbx_GroupDoc.TabIndex = 21
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.Label3.Location = New System.Drawing.Point(8, 49)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(105, 13)
		Me.Label3.TabIndex = 19
		Me.Label3.Text = "Тип документа:*"
		'
		'cbx_TypeDoc
		'
		Me.cbx_TypeDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cbx_TypeDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.cbx_TypeDoc.FormattingEnabled = True
		Me.cbx_TypeDoc.Location = New System.Drawing.Point(176, 46)
		Me.cbx_TypeDoc.Name = "cbx_TypeDoc"
		Me.cbx_TypeDoc.Size = New System.Drawing.Size(167, 21)
		Me.cbx_TypeDoc.TabIndex = 0
		'
		'Panel1
		'
		Me.Panel1.Location = New System.Drawing.Point(5, 99)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(339, 259)
		Me.Panel1.TabIndex = 20
		'
		'cmd_SaveDoc
		'
		Me.cmd_SaveDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmd_SaveDoc.Location = New System.Drawing.Point(10, 575)
		Me.cmd_SaveDoc.Name = "cmd_SaveDoc"
		Me.cmd_SaveDoc.Size = New System.Drawing.Size(350, 39)
		Me.cmd_SaveDoc.TabIndex = 1
		Me.cmd_SaveDoc.Text = "Сохранить документ в соответствующую папку" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "на сервер"
		Me.cmd_SaveDoc.UseVisualStyleBackColor = True
		'
		'Label2
		'
		Me.Label2.AutoSize = True
		Me.Label2.Location = New System.Drawing.Point(12, 427)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(234, 13)
		Me.Label2.TabIndex = 22
		Me.Label2.Text = "Наименование каталога (папки) на сервере:"
		'
		'lbl_DirName
		'
		Me.lbl_DirName.Location = New System.Drawing.Point(12, 440)
		Me.lbl_DirName.Name = "lbl_DirName"
		Me.lbl_DirName.Size = New System.Drawing.Size(348, 27)
		Me.lbl_DirName.TabIndex = 21
		'
		'ToolTip1
		'
		Me.ToolTip1.AutoPopDelay = 10000
		Me.ToolTip1.InitialDelay = 100
		Me.ToolTip1.ReshowDelay = 100
		'
		'Label4
		'
		Me.Label4.Location = New System.Drawing.Point(12, 467)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(348, 18)
		Me.Label4.TabIndex = 31
		Me.Label4.Text = "Наименование изображения со сканера:"
		'
		'lbl_NameImage
		'
		Me.lbl_NameImage.AutoSize = True
		Me.lbl_NameImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
		Me.lbl_NameImage.Location = New System.Drawing.Point(366, 31)
		Me.lbl_NameImage.Name = "lbl_NameImage"
		Me.lbl_NameImage.Size = New System.Drawing.Size(139, 17)
		Me.lbl_NameImage.TabIndex = 32
		Me.lbl_NameImage.Text = "Текущая картинка: "
		'
		'StatusStrip1
		'
		Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusStripLabel})
		Me.StatusStrip1.Location = New System.Drawing.Point(0, 622)
		Me.StatusStrip1.Name = "StatusStrip1"
		Me.StatusStrip1.Size = New System.Drawing.Size(950, 22)
		Me.StatusStrip1.TabIndex = 33
		Me.StatusStrip1.Text = "StatusStrip1"
		'
		'statusStripLabel
		'
		Me.statusStripLabel.Name = "statusStripLabel"
		Me.statusStripLabel.Size = New System.Drawing.Size(138, 17)
		Me.statusStripLabel.Text = "Идет загрузка объекта..."
		'
		'Timer1
		'
		Me.Timer1.Enabled = True
		'
		'img_PictureShow
		'
		Me.img_PictureShow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.img_PictureShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.img_PictureShow.Location = New System.Drawing.Point(366, 49)
		Me.img_PictureShow.Name = "img_PictureShow"
		Me.img_PictureShow.Size = New System.Drawing.Size(572, 563)
		Me.img_PictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.img_PictureShow.TabIndex = 30
		Me.img_PictureShow.TabStop = False
		'
		'BackgroundWorker1
		'
		'
		'frm_SaveDoc
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(950, 644)
		Me.Controls.Add(Me.StatusStrip1)
		Me.Controls.Add(Me.lbl_NameImage)
		Me.Controls.Add(Me.GroupBox2)
		Me.Controls.Add(Me.Label4)
		Me.Controls.Add(Me.img_PictureShow)
		Me.Controls.Add(Me.listBox_ShowImages)
		Me.Controls.Add(Me.MenuStrip1)
		Me.Controls.Add(Me.cmd_SaveDoc)
		Me.Controls.Add(Me.Label2)
		Me.Controls.Add(Me.lbl_DirName)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frm_SaveDoc"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Форма сохранения"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.MenuStrip1.ResumeLayout(False)
		Me.MenuStrip1.PerformLayout()
		Me.GroupBox2.ResumeLayout(False)
		Me.GroupBox2.PerformLayout()
		Me.StatusStrip1.ResumeLayout(False)
		Me.StatusStrip1.PerformLayout()
		CType(Me.img_PictureShow, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub
    Friend WithEvents img_PictureShow As System.Windows.Forms.PictureBox
    Friend WithEvents listBox_ShowImages As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents СправкаToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmd_PreViem As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents cmd_SaveDoc As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbl_DirName As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Private components As System.ComponentModel.IContainer
    Friend WithEvents cbx_TypeDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbl_NameImage As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbx_GroupDoc As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusStripLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents cmd_SectorShow As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
