Public Class frm_Screensaver

    Dim k As Integer = 0
    Private Sub frm_Screensaver_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
		If k = 2 Then
			Timer1.Stop()
			Me.Dispose()
		End If

		k += 1
		'dbe = CreateObject("DAO.DbEngine.120")
		'Timer1.Stop()
		'Me.Dispose()
    End Sub
End Class