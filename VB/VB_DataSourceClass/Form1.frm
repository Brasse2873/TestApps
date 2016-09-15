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
   Begin VB.CommandButton cmdCycle 
      Caption         =   "Cycle"
      Height          =   375
      Left            =   2880
      TabIndex        =   1
      Top             =   840
      Width           =   1215
   End
   Begin VB.TextBox txtConsumer 
      Height          =   285
      Left            =   360
      TabIndex        =   0
      Top             =   840
      Width           =   2055
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private objSource As MySource
Private objBindingCollection As BindingCollection

Private Sub cmdCycle_Click()
   objSource.Cycle
End Sub

Private Sub Form_Load()
   Set objSource = New MySource
   Set objBindingCollection = New BindingCollection

   ' Assign the source class to the Binding
   ' Collection’s DataSource property.
   Set objBindingCollection.DataSource = objSource
   ' Add a binding.
   objBindingCollection.Add txtConsumer, "Text", "Directory"

End Sub
