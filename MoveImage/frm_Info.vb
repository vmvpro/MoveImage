Public Class frm_Info

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Me.Close()
	End Sub

	Private Sub frm_Info_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		'Dim fff As Bitmap
		'fff = My.Resources.NewPossibilities
		'fff.
		PictureBox1.Image = Global.MoveImage.My.Resources.Resources.Новые_возможности2
	End Sub
End Class