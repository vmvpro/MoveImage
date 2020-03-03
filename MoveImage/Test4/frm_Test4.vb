Public Class frm_Test4

    Dim listPathFile As List(Of String)
    Dim DataGridView_Sector As DataGridView
    Private Sub frm_Test4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listPathFile = New List(Of String)() From {"e:\Document\Мои рисунки\2011-11-27 - копия\ЗП 123456 ОГК - РЗ_7894 _05.jpg",
                                                   "e:\Document\Мои рисунки\2011-11-27 - копия\КТСП 123456 - 132.00.5555.456.456 _01.jpg",
                                                   "e:\Document\Мои рисунки\2011-11-27 - копия\КТСП 123456 - 132.00.5555.456.456 _02.jpg"}




    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Dim s As String() = listChekedSectors(DataGridView_Sector).ToArray

        'frm()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim str As String = "456/789"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim FirstName As String = "Melnyk"
        Dim LastName As String = "Vitliy"
        Dim FullName As String = String.Concat(FirstName, " ", LastName)
        Dim result As String

        Dim izv As String = "14859.12301"
        Dim zp As String = "О-01/1221-178"

        ' Возвращает: 4
        Dim posLeft As Integer = zp.IndexOf("/")
        Debug.WriteLine(posLeft)

        ' Эквивалент Left(zp, pos)
        Debug.WriteLine(zp.Substring(0, posLeft))

        ' Эквивалент Left(zp, 4) - "О-01/1221-178" => О-01
        Debug.WriteLine(zp.Substring(0, 4))

        ' Эквивалент Right(zp, 3) - "О-01/1221-178" => 178
        Debug.WriteLine(zp.Substring(zp.Length - 3))

        Dim posRight As Integer = zp.IndexOf("/")
        Debug.WriteLine(zp.Substring(posLeft + 1))

        Dim zp3 As String = "О-01/1221/178"
        Dim pos3 As Integer = zp3.IndexOf("/") + 1
        Dim pos4 As Integer = zp3.IndexOf("/", pos3)
        ' Функция работае следующим образом
        ' 
        Debug.WriteLine(zp3.Substring(pos3, pos4 - pos3))

        Dim zp4 As String = "О-01/1221/178 - (Примечание от документа).docx"
        Dim pos4_1 As Integer = zp4.IndexOf("(") + 1
        Dim pos4_2 As Integer = zp4.IndexOf(")")
        ' Функция работае следующим образом
        result = ("    " & zp4.Substring(pos4_1, pos4_2 - pos4_1) & "    ").Trim

        Debug.WriteLine(result)
        Debug.WriteLine("")
        Debug.WriteLine("")
        Debug.WriteLine("")
        Debug.WriteLine("")

        '------------Пример 5--------------------------------------------------------
        ' Сделаем функцию на определения, хоть одного пробела строки в комментариях
        Dim zp5 As String = "О-01/1221-178 - (Примечание_от-документа).docx"
        Dim pos5_1 As Integer = zp5.IndexOf("(") + 1
        Dim pos5_2 As Integer = zp5.IndexOf(")")

        result = zp5.Substring(pos5_1, pos5_2 - pos5_1)

        Dim bool As Boolean = False
        For i As Integer = 0 To result.Length - 1
            Dim ch As Char = result.Chars(i)
            If Not (Char.IsLetterOrDigit(ch) Or ch.ToString = "_") Then
                'Debug.WriteLine("Поле не должно содержать 'пробелы', знаки пунктуации и прочие символы, кроме символа подчеркивания(_).")
                'Набирается в таком порядке через знак 'нижнее подчеркивание(_)': номер и аббревиатура отдела куда направляется данный документ.")

                ' Пример: 059_УТК")
                ' Примечание: Если в момент набора документа по каким-то причинам не известно номер и/или аббреавиатуру отдела - запишите в произвольной форме текст который максимально отражает введенную информацию за действительность и по возможности сообщите разработчику.
                bool = True
                Exit For
            Else
                bool = False
                'Debug.WriteLine("Пробелов не обнаружено")
            End If
            'Debug.Write("")
        Next

        If bool Then
            Debug.WriteLine("Поле не должно содержать 'пробелы'")
        Else
            Debug.WriteLine("Пробелов не обнаружено")
        End If

        'Debug.WriteLine(result)

    End Sub

    Function ddd(s As String) As Boolean
        Dim bool As Boolean = False
        For i As Integer = 0 To s.Length - 1
            Dim ch As Char = s.Chars(i)
            If Not (Char.IsLetterOrDigit(ch) Or ch.ToString = "_") Then
                'Debug.WriteLine("Поле не должно содержать 'пробелы', знаки пунктуации и прочие символы, кроме символа подчеркивания(_).")
                'Набирается в таком порядке через знак 'нижнее подчеркивание(_)': номер и аббревиатура отдела куда направляется данный документ.")

                ' Пример: 059_УТК")
                ' Примечание: Если в момент набора документа по каким-то причинам не известно номер и/или аббреавиатуру отдела - запишите в произвольной форме текст который максимально отражает введенную информацию за действительность и по возможности сообщите разработчику.
                bool = True
                Exit For
            Else
                bool = False
                'Debug.WriteLine("Пробелов не обнаружено")
            End If
            'Debug.Write("")
        Next

        If bool Then
            'Debug.WriteLine("Поле не должно содержать 'пробелы'")
            Return True
        Else
            Return False
            'Debug.WriteLine("Пробелов не обнаружено")
        End If
    End Function
End Class