Imports System.Web
Imports System.Diagnostics
Imports System.Text


Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim subject As String
        Dim body As String



        subject = "Subject för test av åäöÅÄÖ"
        subject = Replace(HttpUtility.UrlEncode(subject, System.Text.Encoding.UTF8), "+", " ")

        body = "Hej," & vbCrLf & "" & vbCrLf & "" & vbCrLf & "" & vbCrLf & "Med vänliga hälsningar, " & vbCrLf & "__________________________________ " & vbCrLf & "Logica | CABS operation & support " & vbCrLf & "Augustendalsvägen 21, 131 85 Stockholm | Sweden " & vbCrLf & "T: +46 85 17 67 744 " & vbCrLf & "t2.mobil.drift@logica.com | www.logica.se  " & vbCrLf & ""
        body = Replace(HttpUtility.UrlEncode(body, System.Text.Encoding.UTF8), "+", " ")

        Dim mail As String = String.Format("mailto:mikael.scherer@logica.com?subject={0}&body={1}", subject, body)
        System.Diagnostics.Process.Start(mail)



    End Sub
End Class
