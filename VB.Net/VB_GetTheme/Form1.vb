Imports System.Text

'Declare Unicode Function GetCurrentThemeName Lib "uxtheme.dll" (ByVal stringThemeName As StringBuilder, ByVal lengthThemeName As Integer, ByVal stringColorName As StringBuilder, ByVal lengthColorName As Integer, ByVal stringSizeName As StringBuilder, ByVal lengthSizeName As Integer) As Int32



Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim stringThemeName As New StringBuilder(260)
        Dim stringColorName As New StringBuilder(260)
        Dim stringSizeName As New StringBuilder(260)

        Dim s As Int32 = GetCurrentThemeName(stringThemeName, 260, stringColorName, 260, stringSizeName, 260)


    End Sub
End Class
