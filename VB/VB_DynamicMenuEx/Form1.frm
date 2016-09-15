VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3195
   ClientLeft      =   165
   ClientTop       =   735
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3195
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.Menu menuFile 
      Caption         =   "File"
      Begin VB.Menu sep 
         Caption         =   "-"
      End
      Begin VB.Menu menuOperators 
         Caption         =   "Operator"
         Index           =   0
         Visible         =   0   'False
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()

    Load menuOperators(1)
    menuOperators(1).Caption = "Tele2 Sverige"
    menuOperators(1).Visible = True
    menuOperators(1).Checked = True
    
    Load menuOperators(2)
    menuOperators(2).Caption = "Tele2 Norge"
    menuOperators(2).Visible = True
    Load menuOperators(3)
    menuOperators(3).Caption = "Optimal Telecom"
    menuOperators(3).Visible = True
    
End Sub

