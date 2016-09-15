VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   4140
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   4140
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   360
      Width           =   1695
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private m_oFSO As Scripting.FileSystemObject

Private Sub Command1_Click()
    Dim oInFile As TextStream
    Dim oOutFile As TextStream
    
    Set oInFile = m_oFSO.OpenTextFile("C:\Temp\InFile.Txt", ForReading)
    Set oOutFile = m_oFSO.OpenTextFile("C:\Temp\OutFile.Txt", ForWriting, True)
    
    Do While Not oInFile.AtEndOfStream
        oOutFile.WriteLine oInFile.ReadLine
    Loop
    
    oInFile.Close
    oOutFile.Close
    
End Sub

Private Sub Form_Load()
    Set m_oFSO = New Scripting.FileSystemObject
End Sub
