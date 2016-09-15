VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Form1"
   ClientHeight    =   2070
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   3135
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2070
   ScaleWidth      =   3135
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Increment Field value"
      Height          =   495
      Left            =   120
      TabIndex        =   2
      Top             =   1200
      Width           =   2655
   End
   Begin VB.Label lblFieldValue 
      BorderStyle     =   1  'Fixed Single
      Height          =   375
      Left            =   1200
      TabIndex        =   1
      Top             =   480
      Width           =   975
   End
   Begin VB.Label Label1 
      Caption         =   "Field value"
      Height          =   255
      Left            =   120
      TabIndex        =   0
      Top             =   480
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private WithEvents Model As Class1
Attribute Model.VB_VarHelpID = -1

Private Sub Form_Load()
    Set Model = New Class1
    lblFieldValue = Model.Field
End Sub

Private Sub Model_OnFieldChange()
    lblFieldValue = Model.Field
End Sub

Private Sub Command1_Click()
    Model.Field = Model.Field + 1
End Sub


