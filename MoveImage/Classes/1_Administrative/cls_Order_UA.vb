Imports System.Text
Public Class cls_Order_UA
	Inherits cls_Order


	Public Sub New()
		boolDataBase = True

		nameGroup = "Административная"
		type_doc = "Наказ"
		'type_docRange = New String() {"Распоряжение", "Розпорядження"}
		dirName = "1_Административная документация\Приказы\"

		rootNameDocument = "Order"
		nameDataBase = "ServerDBNew_" & rootNameDocument & ".accdb"
		nameTable_TypeDoc = "Register_" & rootNameDocument & "_NotImage"

		nameDataBase_Image = "ServerDBNew_Image_" & rootNameDocument
		nameTable_Image = "Register_" & rootNameDocument & "_ImageOne"


	End Sub

End Class
