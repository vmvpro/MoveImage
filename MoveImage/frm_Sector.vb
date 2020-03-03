Public Class frm_Sector

    Dim s() As String = Nothing
    Dim d1 As Data
	Sub New()

		' Этот вызов является обязательным для конструктора.
		InitializeComponent()

		' Добавьте все инициализирующие действия после вызова InitializeComponent().

	End Sub

	Dim dataGridView As DataGridView



    Public Sub New(d As Data)
        InitializeComponent()

        'Me.dataGridView = New DataGridView() ' = dataGridView
        '
        loadDataGrid_Sectors(DataGridView2)
        d1 = d

        'Me.s = s
        'dataGridView = DataGridView2

    End Sub

	Private Sub frm_Sector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadDataGrid_Sectors(DataGridView2)
	End Sub

	Private Sub cmd_Ok_Click(sender As Object, e As EventArgs) Handles cmd_Ok.Click
        d1.Value = listChekedSectors(DataGridView2).ToArray

        Me.Close()
	End Sub

    Private Sub cmd_Cancel_Click(sender As Object, e As EventArgs) Handles cmd_Cancel.Click
        Me.Close()
    End Sub
End Class