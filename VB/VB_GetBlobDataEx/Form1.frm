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
   Begin VB.CommandButton cmdUpdate 
      Caption         =   "Update"
      Height          =   495
      Left            =   1200
      TabIndex        =   1
      Top             =   1800
      Width           =   1215
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "Save"
      Height          =   495
      Left            =   1200
      TabIndex        =   0
      Top             =   840
      Width           =   1215
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Dim oDC As New ADODB.Connection



Private Sub cmdSave_Click()
    Dim oRs As New ADODB.Recordset
    Dim oFSO As New FileSystemObject
    Dim oTS As TextStream
    Dim sFileName As String
    
    
    Call oRs.Open("select * from tbl_config", oDC, adOpenForwardOnly, adLockOptimistic)
    
    While Not oRs.EOF
        sFileName = App.Path & "\" & oRs("name").Value & ".sql"
        Set oTS = oFSO.OpenTextFile(sFileName, ForWriting, True)
        oTS.Write (oRs("value").Value)
        oTS.Close
        oRs.MoveNext
    Wend
    
    oRs.Close
    Set oRs = Nothing
    Set oFSO = Nothing
    
End Sub



Private Sub cmdUpdate_Click()
    Dim oRs As New ADODB.Recordset
    Dim oFSO As New FileSystemObject
    Dim oTS As TextStream
    Dim sFileName As String


    Call oRs.Open("select value from tbl_config where name = 'BP_SELECT_1'", oDC, adOpenKeyset, adLockOptimistic)
    
    If Not oRs.EOF Then
        sFileName = App.Path & "\BP_SELECT_1.sql"
        Set oTS = oFSO.OpenTextFile(sFileName, ForReading)
        oRs("value").Value = oTS.ReadAll
        oTS.Close
    End If
    oRs.Update
    Set oRs = Nothing
    Set oFSO = Nothing

End Sub

Private Sub Form_Load()
    Call oDC.Open("Provider=OraOLEDB.Oracle;Password=falunprod;User ID=falungong;Data Source=korpen;Persist Security Info=True;PLSQLRSet=1;")
    'Call oDC.Open("Provider=OraOLEDB.Oracle;Password=test;User ID=falungong;Data Source=eagle;Persist Security Info=True;PLSQLRSet=1;")
End Sub

Private Sub Form_Unload(Cancel As Integer)
    Set oDC = Nothing
End Sub
