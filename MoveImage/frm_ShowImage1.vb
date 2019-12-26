Public Class frm_ShowImage1

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Height = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height
        Me.Width = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Width

        Me.pic_PictureShow.Image = frm_Main.img_PictureShow.Image

    End Sub

    Private Sub cmd_Flip270_Click(sender As Object, e As EventArgs) Handles cmd_Flip270.Click
        subFlip_Image(RotateFlipType.Rotate270FlipNone, fullNamePathImage, pic_PictureShow)

    End Sub

    Private Sub cmd_Flip90_Click(sender As Object, e As EventArgs) Handles cmd_Flip90.Click
        subFlip_Image(RotateFlipType.Rotate90FlipNone, fullNamePathImage, pic_PictureShow)

    End Sub
End Class