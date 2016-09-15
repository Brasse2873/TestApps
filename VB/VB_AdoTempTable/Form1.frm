VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   8475
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   8250
   LinkTopic       =   "Form1"
   ScaleHeight     =   8475
   ScaleWidth      =   8250
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdBeginTransaction 
      Caption         =   "Begin Transaction"
      Height          =   375
      Left            =   6240
      TabIndex        =   14
      Top             =   240
      Width           =   1695
   End
   Begin VB.CommandButton cmdEndTransaction 
      Caption         =   "End transaction"
      Height          =   375
      Left            =   6240
      TabIndex        =   13
      Top             =   840
      Width           =   1695
   End
   Begin VB.CommandButton cmdIsTempTableExisting 
      Caption         =   "Is temp table existing"
      Height          =   495
      Left            =   1920
      TabIndex        =   12
      Top             =   1920
      Width           =   1695
   End
   Begin VB.TextBox txtRecordSet 
      Height          =   5775
      Left            =   120
      ScrollBars      =   3  'Both
      TabIndex        =   11
      Text            =   "Text1"
      Top             =   2520
      Width           =   7935
   End
   Begin VB.CommandButton cmdTrucate 
      Caption         =   "Truncate"
      Height          =   375
      Left            =   1920
      TabIndex        =   10
      Top             =   1440
      Width           =   1695
   End
   Begin VB.CommandButton cmdDeleteTmpTable 
      Caption         =   "Delete temp table"
      Height          =   375
      Left            =   1920
      TabIndex        =   9
      Top             =   840
      Width           =   1695
   End
   Begin VB.CommandButton cmdInsert 
      Caption         =   "Insert"
      Height          =   375
      Left            =   3840
      TabIndex        =   8
      Top             =   240
      Width           =   1695
   End
   Begin VB.CommandButton cmdCreateTempTable 
      Caption         =   "Create temp table"
      Height          =   375
      Left            =   1920
      TabIndex        =   7
      Top             =   240
      Width           =   1695
   End
   Begin VB.CommandButton cmdGetRecordSet 
      Caption         =   "Get Record Set"
      Height          =   435
      Left            =   3840
      TabIndex        =   2
      Top             =   1380
      Width           =   1635
   End
   Begin VB.CommandButton cmdCloseConnection 
      Caption         =   "Close connection"
      Height          =   435
      Left            =   120
      TabIndex        =   1
      Top             =   780
      Width           =   1635
   End
   Begin VB.CommandButton cmdOpenConnection 
      Caption         =   "Open connection"
      Height          =   435
      Left            =   120
      TabIndex        =   0
      Top             =   180
      Width           =   1635
   End
   Begin VB.Label lblValue 
      Caption         =   "lblValue"
      Height          =   255
      Left            =   6720
      TabIndex        =   6
      Top             =   1680
      Width           =   1515
   End
   Begin VB.Label Label2 
      Caption         =   "Value:"
      Height          =   255
      Left            =   5520
      TabIndex        =   5
      Top             =   1680
      Width           =   1035
   End
   Begin VB.Label lblFieldCount 
      Caption         =   "lblFieldCount"
      Height          =   255
      Left            =   6720
      TabIndex        =   4
      Top             =   1440
      Width           =   1455
   End
   Begin VB.Label Label1 
      Caption         =   "Field count:"
      Height          =   255
      Left            =   5520
      TabIndex        =   3
      Top             =   1440
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim m_oConnection As ADODB.Connection
Dim m_oRS As ADODB.Recordset


Private Sub cmdBeginTransaction_Click()
    m_oConnection.BeginTrans
End Sub

Private Sub cmdCloseConnection_Click()
    On Error GoTo err_handler
    m_oConnection.Close
    Exit Sub
    
err_handler:
    MsgBox "cmdCloseConnection_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdCreateTempTable_Click()
    Dim rs As New ADODB.Recordset
    
    On Error GoTo err_handler
    Call rs.Open("create global temporary table tmp_table (bp varchar2(50)) ON COMMIT DELETE ROWS", m_oConnection)
    Exit Sub
    
err_handler:
    MsgBox "cmdCreateTempTable_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdDeleteTmpTable_Click()
    Dim rs As New Recordset
    
    On Error GoTo err_handler
    Call rs.Open("drop table tmp_table", m_oConnection)
    Exit Sub

err_handler:
    MsgBox "cmdDeleteTmpTable_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdEndTransaction_Click()
    m_oConnection.CommitTrans
End Sub

Private Sub cmdGetRecordSet_Click()
    Dim rs As New Recordset
    Dim ix As Integer
    
    On Error GoTo err_handler
    lblFieldCount = ""
    lblValue = ""
    Call rs.Open("select count(*) as bpCount from tmp_table", m_oConnection)
    lblFieldCount = rs.Fields.Count
    lblValue = rs.Fields("bpCount")
    
    Set rs = New Recordset
    Call rs.Open("select * from tmp_table", m_oConnection)
    
    txtRecordSet = ""
    Do While Not rs.EOF
        txtRecordSet = txtRecordSet & rs("bp").Value & ", "
        rs.MoveNext
    Loop
    
    Exit Sub
    
err_handler:
    MsgBox "cmdGetRecordSet_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdInsert_Click()
    Dim rs As New Recordset
     
    On Error GoTo err_handler
    
    Call rs.Open("insert into tmp_table select bp from tbl_billplan", m_oConnection)
    Exit Sub
     
err_handler:
    MsgBox "cmdInsert_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdIsTempTableExisting_Click()
    Dim rs As New Recordset
     
    On Error GoTo err_handler
    Call rs.Open("select count(table_name) as tableExist from user_tables where table_name ='TMP_TABLE'", m_oConnection)
    If rs("tableExist") Then
        MsgBox ("temp table exist")
    Else
        MsgBox ("temp table does not exist")
    End If
    Exit Sub
     
err_handler:
    MsgBox "cmdIsTempTableExisting_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdOpenConnection_Click()
    On Error GoTo err_handler
    m_oConnection.Open
    Exit Sub
    
err_handler:
    MsgBox "cmdOpenConnection_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdTrucate_Click()
    Dim rs As New Recordset
    
    On Error GoTo err_handler
    Call rs.Open("truncate table tmp_table", m_oConnection)
    Exit Sub

err_handler:
    MsgBox "cmdTrucate_Click failed. Error: " + Err.Description
End Sub

Private Sub Form_Load()
    On Error GoTo err_handler
    Set m_oConnection = New ADODB.Connection
    m_oConnection.ConnectionString = "Provider=OraOLEDB.Oracle.1;Password=test;User ID=falungong;Data Source=eagle;Persist Security Info=True;PLSQLRSet=1;"
    
    Exit Sub
err_handler:
    MsgBox "Load_form failed. Error: " + Err.Description
End Sub
