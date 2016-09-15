VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3030
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   4560
   LinkTopic       =   "Form1"
   ScaleHeight     =   3030
   ScaleWidth      =   4560
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   855
      Left            =   1440
      TabIndex        =   0
      Top             =   1440
      Width           =   1695
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Private Sub Command1_Click()

 
    Call func("key1", "value1", "key2", "value2")
    
End Sub


Public Function func(ParamArray args() As Variant)
    Dim ix As Integer
    Dim key As String
    Dim value As String
    
    For ix = 0 To UBound(args) Step 2
        key = args(ix)
        value = args(ix + 1)
    Next
End Function

