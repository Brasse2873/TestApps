VERSION 5.00
Begin VB.Form View 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Form1"
   ClientHeight    =   3030
   ClientLeft      =   45
   ClientTop       =   375
   ClientWidth     =   4560
   ForeColor       =   &H00000000&
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3030
   ScaleWidth      =   4560
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Command1 
      Caption         =   "Increment Field"
      Height          =   495
      Left            =   1080
      TabIndex        =   0
      Top             =   360
      Width           =   2295
   End
   Begin VB.Label lblFieldValue 
      Caption         =   "lblFieldValue"
      Height          =   255
      Left            =   1680
      TabIndex        =   2
      Top             =   1320
      Width           =   1815
   End
   Begin VB.Label Label1 
      Caption         =   "Field value"
      Height          =   255
      Left            =   360
      TabIndex        =   1
      Top             =   1320
      Width           =   975
   End
End
Attribute VB_Name = "View"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private WithEvents m_presenter As Presenter

Private Sub Form_Load()
    Set m_presenter = New Presenter
    Call m_presenter.Initialize(Me)
    lblFieldValue = m_presenter.Field
End Sub

Private Sub Command1_Click()
    m_presenter.IncreaseField
End Sub

Private Sub m_presenter_OnFieldChanged()
    lblFieldValue = m_presenter.Field
End Sub

'View interface
Public Sub SetCollor(collor As Integer)
    lblFieldValue.ForeColor = collor
End Sub

