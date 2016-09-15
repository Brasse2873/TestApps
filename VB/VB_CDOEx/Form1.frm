VERSION 5.00
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
   Begin VB.CommandButton Command1 
      Caption         =   "Command1"
      Height          =   615
      Left            =   1440
      TabIndex        =   0
      Top             =   840
      Width           =   1575
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Command1_Click()
    Call SendMail("Error mail from VB, Body", "Error in Mora")
End Sub

Private Sub SendMail(tBody As String, tSubject As String)

    Dim objSession As MAPI.Session
    Dim objmessage As MAPI.Message
    Dim objRecipient As MAPI.Recipient
    Dim objAttach As MAPI.Attachment


    'Create the Session Object
    Set objSession = CreateObject("mapi.session")
  
    'Logon using the session object
    'Specify a valid profile name if you want to
    'Avoid the logon dialog box
    'If you don't include a profilename then a dialog is popup requesting one
    objSession.Logon profileName:="%USERNAME%"


    'Add a new message object to the OutBox
    Set objmessage = objSession.Outbox.Messages.Add

    'Set the properties of the message object
    objmessage.Subject = tSubject
    objmessage.Text = tBody
    
    Set objRecipient = objmessage.Recipients.Add
    objRecipient.Name = "mikael.scherer@logica.com"
    objRecipient.Type = 1
    objRecipient.Resolve
    
    objmessage.Update
        
    'Popup the global addresslist to select your recipients
    'Force the resoluion of the named recipients
'    Set objmessage.Recipients = objSession.AddressBook(, "Select Recipients", , True, , ">>")
  
    'To add attachments
'    Set objAttach = objmessage.Attachments.Add
'          objAttach.Name = "testing" 'Pass your own name
'          objAttach.Source = "C:\Boot.ini" 'Pass in your own filename
'          objAttach.Type = CdoFileData 'This is the Default

    'Send the message
    objmessage.Send showDialog:=False
    
    'Logoff using the session object
    objSession.Logoff

End Sub
