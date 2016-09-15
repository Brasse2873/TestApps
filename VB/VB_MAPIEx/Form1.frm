VERSION 5.00
Object = "{20C62CAE-15DA-101B-B9A8-444553540000}#1.1#0"; "MSMAPI32.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3090
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   ScaleHeight     =   3090
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin MSMAPI.MAPIMessages MAPIMessages1 
      Left            =   3840
      Top             =   480
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      AddressEditFieldCount=   1
      AddressModifiable=   0   'False
      AddressResolveUI=   0   'False
      FetchSorted     =   0   'False
      FetchUnreadOnly =   0   'False
   End
   Begin MSMAPI.MAPISession MAPISession1 
      Left            =   3240
      Top             =   480
      _ExtentX        =   1005
      _ExtentY        =   1005
      _Version        =   393216
      DownloadMail    =   -1  'True
      LogonUI         =   -1  'True
      NewSession      =   0   'False
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   615
      Left            =   1200
      TabIndex        =   0
      Top             =   1320
      Width           =   1575
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
Send
End Sub

Private Sub Send()


MAPISession1.SignOn

MAPIMessages1.SessionID = MAPISession1.SessionID


'Start by telling the control that we are composing an e-mail

MAPIMessages1.Compose

'Use whatever is in the Textboxes as the information for our e-mail.

MAPIMessages1.RecipDisplayName = "mikael.scherer@logica.com"

MAPIMessages1.MsgSubject = "Subject, Test MAPI"

MAPIMessages1.MsgNoteText = "Text, Test MAPI"

MAPIMessages1.ResolveName

'Send the e-mail message to the Recipient

MAPIMessages1.Send

End Sub
