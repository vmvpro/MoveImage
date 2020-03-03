Imports System.IO
Imports System.Text

Public Class frm_HelpFAQ

    Private Sub HelpFAQ_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim txtHelp As New StreamReader("Help.txt", Encoding.UTF8)
        TextBox1.Text = txtHelp.ReadToEnd
        txtHelp.Close()
        TextBox1.Focus()
        TextBox1.SelectionStart = 0
    End Sub
End Class