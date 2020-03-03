<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Test3
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmd_OpenFormSector = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txt_num_zp = New System.Windows.Forms.TextBox()
        Me.cbo_type_zp = New System.Windows.Forms.ComboBox()
        Me.cbo_AntonovDep = New System.Windows.Forms.ComboBox()
        Me.cbo_izd = New System.Windows.Forms.ComboBox()
        Me.cbo_id_rz_register_doc = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_prim = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txt_seria = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "MoveImageDB"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(144, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "MoveImageDB _SKN"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(12, 99)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.RowHeadersWidth = 20
        Me.DataGridView2.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White
        Me.DataGridView2.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridView2.Size = New System.Drawing.Size(317, 221)
        Me.DataGridView2.TabIndex = 28
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 70)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(144, 23)
        Me.Button3.TabIndex = 29
        Me.Button3.Text = "SaveDabaseTransactions"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmd_OpenFormSector)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txt_num_zp)
        Me.GroupBox1.Controls.Add(Me.cbo_type_zp)
        Me.GroupBox1.Controls.Add(Me.cbo_AntonovDep)
        Me.GroupBox1.Controls.Add(Me.cbo_izd)
        Me.GroupBox1.Controls.Add(Me.cbo_id_rz_register_doc)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txt_prim)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txt_seria)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(349, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(329, 303)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Запрос производства"
        '
        'cmd_OpenFormSector
        '
        Me.cmd_OpenFormSector.Location = New System.Drawing.Point(24, 219)
        Me.cmd_OpenFormSector.Name = "cmd_OpenFormSector"
        Me.cmd_OpenFormSector.Size = New System.Drawing.Size(253, 23)
        Me.cmd_OpenFormSector.TabIndex = 40
        Me.cmd_OpenFormSector.Text = "Указать участок"
        Me.cmd_OpenFormSector.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(287, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 13)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Label8"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(29, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Номер документа:*"
        '
        'txt_num_zp
        '
        Me.txt_num_zp.Location = New System.Drawing.Point(140, 88)
        Me.txt_num_zp.Name = "txt_num_zp"
        Me.txt_num_zp.Size = New System.Drawing.Size(141, 20)
        Me.txt_num_zp.TabIndex = 42
        Me.txt_num_zp.Text = "17000"
        '
        'cbo_type_zp
        '
        Me.cbo_type_zp.FormattingEnabled = True
        Me.cbo_type_zp.Items.AddRange(New Object() {"-", "К", "М", "О", "П", "Т"})
        Me.cbo_type_zp.Location = New System.Drawing.Point(140, 31)
        Me.cbo_type_zp.Name = "cbo_type_zp"
        Me.cbo_type_zp.Size = New System.Drawing.Size(141, 21)
        Me.cbo_type_zp.TabIndex = 41
        '
        'cbo_AntonovDep
        '
        Me.cbo_AntonovDep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_AntonovDep.FormattingEnabled = True
        Me.cbo_AntonovDep.Location = New System.Drawing.Point(140, 60)
        Me.cbo_AntonovDep.Name = "cbo_AntonovDep"
        Me.cbo_AntonovDep.Size = New System.Drawing.Size(141, 21)
        Me.cbo_AntonovDep.TabIndex = 40
        '
        'cbo_izd
        '
        Me.cbo_izd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbo_izd.FormattingEnabled = True
        Me.cbo_izd.Location = New System.Drawing.Point(140, 114)
        Me.cbo_izd.Name = "cbo_izd"
        Me.cbo_izd.Size = New System.Drawing.Size(141, 21)
        Me.cbo_izd.TabIndex = 39
        '
        'cbo_id_rz_register_doc
        '
        Me.cbo_id_rz_register_doc.FormattingEnabled = True
        Me.cbo_id_rz_register_doc.Location = New System.Drawing.Point(140, 140)
        Me.cbo_id_rz_register_doc.Name = "cbo_id_rz_register_doc"
        Me.cbo_id_rz_register_doc.Size = New System.Drawing.Size(141, 21)
        Me.cbo_id_rz_register_doc.TabIndex = 36
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(24, 248)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(253, 23)
        Me.Button4.TabIndex = 12
        Me.Button4.Text = "Записать в базу данных"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(29, 196)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(73, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Примечание:"
        '
        'txt_prim
        '
        Me.txt_prim.Location = New System.Drawing.Point(140, 193)
        Me.txt_prim.Name = "txt_prim"
        Me.txt_prim.Size = New System.Drawing.Size(141, 20)
        Me.txt_prim.TabIndex = 10
        Me.txt_prim.Text = "Hello VS MoveImage"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(29, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Серия:"
        '
        'txt_seria
        '
        Me.txt_seria.Location = New System.Drawing.Point(140, 167)
        Me.txt_seria.Name = "txt_seria"
        Me.txt_seria.Size = New System.Drawing.Size(141, 20)
        Me.txt_seria.TabIndex = 8
        Me.txt_seria.Text = "001.178"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Отдел:*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(29, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Документ РЗ:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Изделие:*"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Тип запроса:*"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(461, 323)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(100, 20)
        Me.TextBox3.TabIndex = 4
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(348, 321)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(107, 23)
        Me.Button14.TabIndex = 38
        Me.Button14.Text = "Загрузка РЗ"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(349, 377)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(212, 23)
        Me.Button5.TabIndex = 39
        Me.Button5.Text = "Открыть форму Участок"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(349, 406)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(120, 95)
        Me.ListBox1.TabIndex = 40
        '
        'frm_Test3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 559)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox3)
        Me.Name = "frm_Test3"
        Me.Text = "frm_Test3"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_prim As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txt_seria As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents cbo_id_rz_register_doc As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_izd As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbo_AntonovDep As System.Windows.Forms.ComboBox
    Friend WithEvents cbo_type_zp As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txt_num_zp As System.Windows.Forms.TextBox
    Friend WithEvents cmd_OpenFormSector As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
End Class
