<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Sector
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
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmd_Ok = New System.Windows.Forms.Button()
        Me.cmd_Cancel = New System.Windows.Forms.Button()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 29)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView2.Size = New System.Drawing.Size(317, 221)
        Me.DataGridView2.TabIndex = 29
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(0, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(99, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Выберите участок"
        '
        'cmd_Ok
        '
        Me.cmd_Ok.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.cmd_Ok.Location = New System.Drawing.Point(164, 256)
        Me.cmd_Ok.Name = "cmd_Ok"
        Me.cmd_Ok.Size = New System.Drawing.Size(75, 23)
        Me.cmd_Ok.TabIndex = 31
        Me.cmd_Ok.Text = "Ок"
        Me.cmd_Ok.UseVisualStyleBackColor = True
        '
        'cmd_Cancel
        '
        Me.cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmd_Cancel.Location = New System.Drawing.Point(245, 256)
        Me.cmd_Cancel.Name = "cmd_Cancel"
        Me.cmd_Cancel.Size = New System.Drawing.Size(75, 23)
        Me.cmd_Cancel.TabIndex = 32
        Me.cmd_Cancel.Text = "Отмена"
        Me.cmd_Cancel.UseVisualStyleBackColor = True
        '
        'frm_Sector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmd_Cancel
        Me.ClientSize = New System.Drawing.Size(324, 283)
        Me.Controls.Add(Me.cmd_Cancel)
        Me.Controls.Add(Me.cmd_Ok)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Name = "frm_Sector"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Выбор участка"
        Me.TopMost = True
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
	Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
	Friend WithEvents Label1 As System.Windows.Forms.Label
	Friend WithEvents cmd_Ok As System.Windows.Forms.Button
	Friend WithEvents cmd_Cancel As System.Windows.Forms.Button
End Class
