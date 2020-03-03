Imports System.Text.RegularExpressions

Public Class Testing

	Dim fieldsControls As Collection

	Dim s() As String = New String() {"izd", "num", "cherteg", "prim", "rz", "num_mash"}


	Sub groupFields()
		fieldsControls.Add(s(0), "izd")
		fieldsControls.Add(s(1), "num")
		fieldsControls.Add(s(2), "cherteg")
		fieldsControls.Add(s(3), "prim")
		fieldsControls.Add(s(4), "rz")
		fieldsControls.Add(s(5), "num_mash")
	End Sub

	Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
		Dim zp As New cls_ZP



	End Sub

	Dim asd As New Dictionary(Of String, Control)

	Dim izd As String

	Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
		asd.Add("txt1", TextBox1)
		asd.Add("txt2", TextBox2)

		Dim obj As TextBox

		obj = CType(asd.Item("txt1"), TextBox)
		'MessageBox.Show()
	End Sub

	Dim s1() As Control
	Dim s2() As Control
	Dim s3() As Control
	Dim s4() As Control
	Dim s5() As Control
	Dim s6() As Control


	Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

		'Dim s1 As New List(Of Control) : s1.Add(Label1) : s1.Add(txt1)



		Dim sSingle()() As Control = New Control()() {s1, s2, s3, s4, s5, s6}

		Dim sInt1 As Integer = sSingle.Length
		Dim sInt2 As Integer = sSingle.Count


		vvv(s5, s2)

		'vvv(txt3, txt2)


	End Sub

	Dim sLabelBox() As String
	Dim sLabel() As String
	Dim sNames()() As String
	Dim ss() As Integer

	Sub Loaded()
		's1 = New Control() {Label1, txt1}
		's2 = New Control() {Label2, txt2}
		's3 = New Control() {Label3, txt3}
		's4 = New Control() {Label4, txt4}
		's5 = New Control() {Label5, txt5}
		's6 = New Control() {Label6, txt6}

		s1 = New Control() {lbl1, bu1}
		s2 = New Control() {lbl2, text2}
		s3 = New Control() {lbl3, cbx3}
		s4 = New Control() {lbl4, chk4}
		s5 = New Control() {lbl5, text5}
		s6 = New Control() {lbl6, cbx6}

		ss = New Integer() {45, 71, 97, 122, 145, 167}


	End Sub


	Sub ss2()
		Dim Count As Integer = Panel1.Controls.Count / 2 - 1
		ss = New Integer(Count) {}
		Dim i As Integer = 0
		For Each ctl As Control In Panel1.Controls
			Dim obj1 As Object = TypeOf ctl Is Label

			If obj1 Then

				ss(i) = ctl.Top
				i += 1
			End If
		Next

		Array.Sort(ss)
	End Sub

	Sub vvv(ParamArray params()() As Control)

		Dim Count As Integer = Panel1.Controls.Count / 2 - 1
		sNames = New String(Count)() {}
		Dim i As Integer = 0


		For Each ctl As Control In Panel1.Controls
			Dim obj1 As Object = TypeOf ctl Is Label

			If obj1 Then
				sLabelBox = New String() {ctl.Name, ctl.Left, ctl.Top}
				sNames(i) = sLabelBox
				i += 1
			End If
		Next

		For Each ctl As Control In Panel1.Controls
			ctl.Visible = True
		Next

		For Each ctl As Control In Panel1.Controls
			ctl.Visible = False
		Next


		Dim controlTxt(params.Length - 1) As Control
		Dim controlLabel(params.Length - 1) As Control

		For ik As Integer = 0 To params.Length - 1
			controlLabel(ik) = params(ik)(0)
			controlTxt(ik) = params(ik)(1)

		Next

		'ss = New Integer(sNames.Length - 1) {}
		'For ii As Integer = 0 To sNames.Length - 1

		'ss2(ii) = sNames(ii)(2)

		'Next



		Dim k As Integer = 0
		Dim j As Integer = 0
		Dim kk(controlLabel.Length - 1) As Integer

		Do
			If controlLabel(k).Name = sNames(j)(0) Then
				kk(k) = ss(k)

				k += 1
				j = 0
			Else
				j += 1
			End If

		Loop While controlLabel.Count > k

		For ii2 As Integer = 0 To kk.Length - 1
			controlLabel(ii2).Visible = True
			controlLabel(ii2).Top = ss(ii2)

			controlTxt(ii2).Visible = True
			controlTxt(ii2).Top = ss(ii2)
		Next

	End Sub


	Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

		vvv(s4, s6, s5, s2)
	End Sub

	Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click


		vvv(s1, s6, s3, s5)
	End Sub

	Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

		vvv(s6, s5, s4, s3, s2)
	End Sub

	Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

		vvv(s5, s6, s4, s2, s3, s1)
	End Sub

	Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click

		For i As Integer = 0 To Panel1.Controls.Count - 1
			'Dim obj1 As Object = TypeOf ctl Is TextBox
			Panel1.Controls(i).Visible = True
			Panel1.Controls(i).Top = ss(i)
		Next
	End Sub

	Private Sub Testing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Loaded()
		'ss2()
	End Sub

	Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
		vvv(s1, s2, s3, s5, s4)
	End Sub

	Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
		vvv(s1, s3, s5, s2, s4, s6)
	End Sub

	Dim reg As Regex

	Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click

        Dim str As String = "[\]|[/]|[:]|[*]|[?]|[<]|[>]|[|]"
        Dim testText() As String = New String() {"Робота", "Имя", "Самолет*"}
        Dim testFilds() As String = New String() {"Хорошая", "Виталий", "Ан-178*"}

        If IsMatch(str, testText, testFilds) Then

        End If

    End Sub

    Dim newReg As Regex

    Function IsMatch(pattern As String, textText() As String, textFilds() As String) As Boolean
        Dim s As String = ""
        Dim IsMatch_ As Boolean = False

        newReg = New Regex(pattern)

        Try
            For k As Integer = 0 To textFilds.Length - 1
                If (newReg.IsMatch(textFilds(k))) Then

                    MessageBox.Show("")
                    IsMatch_ = True

                Else

                    s = "Пересмотрите правильность ввода!!!"
                    IsMatch_ = False

                End If

            Next

        Catch ex As Exception
            s = "Ошибка в выражении!!!"
            IsMatch_ = False
        End Try

        Return IsMatch_
    End Function
       
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim mas_SaveImages() As String = New String() {"string1", "string2", "string3", "string4"}
        'str_SaveImages = "{0}{1}{2}{3}"
        Dim str_SaveImages As String = RenamingStrings(mas_SaveImages)
    End Sub

    'RenamingStrings
    Protected Function RenamingStrings(str() As String) As String
        Dim s1 As String = ""
        Dim i As Integer = 0
        For Each s2 As String In str
            s1 &= "{" & i & "}"
            i += 1
        Next
        Return s1
    End Function


    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click

        'Dim MyObject As Object = "Hello World"
		'Dim bb As b
		'Dim cc As c

        'DisplayBaseClass(Of b)(bb)
		'bb.Show()

        'DisplayBaseClass(Of c)(cc)
		'cc.Show()

		'DisplayBaseClass(Of b)(bb)
		'bb.Show()

        'DisplayBaseClass(Of b)(a)

    End Sub

    Private Sub DisplayBaseClass1(Of T As {a, New})(ByRef classType As T)

        Dim aaa As a = New T

        Dim obj As a

        obj = TryCast(classType, a)


        'If Not TypeOf classType Is a Then
        '    classType = New T
        '    classType.
        'End If

    End Sub


    Private Function DisplayBaseClass(Of T As New)(bb As T) As T

        If Not TypeOf bb Is a Then
            Return New T
        Else
            Return bb
        End If

    End Function

    Private Shared Sub Test(o As b)
        Dim bb As Object
        'Dim obj As Object

        'obj = CType(New o, a)

        If TypeOf o Is a Then
            bb = DirectCast(o, a)
        End If
    End Sub

	Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
		TextBox3.Text = Date.Parse(DateTimePicker1.Value.ToShortDateString)
	End Sub
End Class


Public Class a
    Protected s As String = ""
    Sub New()
        s = "class a"
    End Sub

    Sub Show()
        MessageBox.Show(s)
    End Sub

End Class

Public Class b
    Inherits a
    Sub New()
        s = "class b"
    End Sub



End Class

Class c
    Inherits a
    Sub New()
        s = "class c"
    End Sub
End Class

