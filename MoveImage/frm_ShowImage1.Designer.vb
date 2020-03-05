<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_ShowImage1
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
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_ShowImage1))
		Me.cmd_Flip90 = New System.Windows.Forms.Button()
		Me.pic_PictureShow = New System.Windows.Forms.PictureBox()
		Me.cmd_Flip270 = New System.Windows.Forms.Button()
		CType(Me.pic_PictureShow, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'cmd_Flip90
		'
		Me.cmd_Flip90.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmd_Flip90.Image = CType(resources.GetObject("cmd_Flip90.Image"), System.Drawing.Image)
		Me.cmd_Flip90.Location = New System.Drawing.Point(51, 572)
		Me.cmd_Flip90.Name = "cmd_Flip90"
		Me.cmd_Flip90.Size = New System.Drawing.Size(33, 33)
		Me.cmd_Flip90.TabIndex = 43
		Me.cmd_Flip90.UseVisualStyleBackColor = True
		'
		'pic_PictureShow
		'
		Me.pic_PictureShow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
			Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.pic_PictureShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.pic_PictureShow.Location = New System.Drawing.Point(12, 12)
		Me.pic_PictureShow.Name = "pic_PictureShow"
		Me.pic_PictureShow.Size = New System.Drawing.Size(758, 554)
		Me.pic_PictureShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
		Me.pic_PictureShow.TabIndex = 44
		Me.pic_PictureShow.TabStop = False
		'
		'cmd_Flip270
		'
		Me.cmd_Flip270.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
		Me.cmd_Flip270.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
		Me.cmd_Flip270.ForeColor = System.Drawing.SystemColors.ScrollBar
		Me.cmd_Flip270.Image = CType(resources.GetObject("cmd_Flip270.Image"), System.Drawing.Image)
		Me.cmd_Flip270.Location = New System.Drawing.Point(12, 572)
		Me.cmd_Flip270.Name = "cmd_Flip270"
		Me.cmd_Flip270.Size = New System.Drawing.Size(33, 33)
		Me.cmd_Flip270.TabIndex = 42
		Me.cmd_Flip270.TextAlign = System.Drawing.ContentAlignment.TopLeft
		Me.cmd_Flip270.UseVisualStyleBackColor = True
		'
		'frm_ShowImage1
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(782, 617)
		Me.Controls.Add(Me.cmd_Flip90)
		Me.Controls.Add(Me.pic_PictureShow)
		Me.Controls.Add(Me.cmd_Flip270)
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.Name = "frm_ShowImage1"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Изображение"
		Me.TopMost = True
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		CType(Me.pic_PictureShow, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub
    Friend WithEvents cmd_Flip90 As System.Windows.Forms.Button
    Friend WithEvents pic_PictureShow As System.Windows.Forms.PictureBox
    Friend WithEvents cmd_Flip270 As System.Windows.Forms.Button
End Class
