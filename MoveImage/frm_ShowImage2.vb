Public Class frm_ShowImage2

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height
        Me.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width
		Me.PictureBox1.Image = frm_SaveDoc.img_PictureShow.Image
    End Sub
End Class