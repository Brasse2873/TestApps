VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   3075
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5025
   LinkTopic       =   "Form1"
   ScaleHeight     =   3075
   ScaleWidth      =   5025
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdGetConnectionObject 
      Caption         =   "Get connection object"
      Height          =   375
      Left            =   120
      TabIndex        =   7
      Top             =   240
      Width           =   2055
   End
   Begin VB.CommandButton cmdGetRecordSet 
      Caption         =   "Get Record Set"
      Height          =   435
      Left            =   120
      TabIndex        =   2
      Top             =   1980
      Width           =   1635
   End
   Begin VB.CommandButton cmdCloseConnection 
      Caption         =   "Close connection"
      Height          =   435
      Left            =   120
      TabIndex        =   1
      Top             =   1380
      Width           =   1635
   End
   Begin VB.CommandButton cmdOpenConnection 
      Caption         =   "Open connection"
      Height          =   435
      Left            =   120
      TabIndex        =   0
      Top             =   780
      Width           =   1635
   End
   Begin VB.Label lblValue 
      Caption         =   "lblValue"
      Height          =   255
      Left            =   3000
      TabIndex        =   6
      Top             =   2280
      Width           =   1515
   End
   Begin VB.Label Label2 
      Caption         =   "Value:"
      Height          =   255
      Left            =   1800
      TabIndex        =   5
      Top             =   2280
      Width           =   1035
   End
   Begin VB.Label lblFieldCount 
      Caption         =   "lblFieldCount"
      Height          =   255
      Left            =   3000
      TabIndex        =   4
      Top             =   2040
      Width           =   1455
   End
   Begin VB.Label Label1 
      Caption         =   "Field count:"
      Height          =   255
      Left            =   1800
      TabIndex        =   3
      Top             =   2040
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim m_oCABSDBConnection As ADODB.Connection
Dim m_oRS As ADODB.Recordset


Private Sub cmdCloseConnection_Click()
    On Error GoTo err_handler
    m_oCABSDBConnection.Close
    MsgBox "Close OK"
    Exit Sub
err_handler:
    MsgBox "cmdCloseConnection_Click failed. Error: " + Err.Description
End Sub

Private Sub cmdGetConnectionObject_Click()
    On Error GoTo err_handler
    Set m_oCABSDBConnection = New ADODB.Connection
    m_oCABSDBConnection.ConnectionString = "Provider=OraOLEDB.Oracle.1;Password=test;User ID=falungong;Data Source=eagle;Persist Security Info=True;PLSQLRSet=1;"
    MsgBox "Get connection object OK"
    Exit Sub
err_handler:
    MsgBox "cmdGetConnectionObject failed. Error: " + Err.Description
End Sub

Private Sub cmdGetRecordSet_Click()
    Dim sSQL As String
    On Error GoTo err_handler
    sSQL = "select count(*) as recCount from tbl_billplan"
    lblFieldCount = ""
    lblValue = ""
    
    Set m_oRS = New ADODB.Recordset
    Call m_oRS.Open(sSQL, m_oCABSDBConnection)
    
    lblFieldCount = m_oRS.Fields.Count
    lblValue = m_oRS!recCount
    
    Exit Sub
err_handler:
    MsgBox "cmdGetRecordSet_Click failed. Error: " + Err.Description
    
End Sub

Private Sub cmdOpenConnection_Click()
    On Error GoTo err_handler
    m_oCABSDBConnection.Open
    MsgBox "Open OK"
    Exit Sub
err_handler:
    MsgBox "cmdOpenConnection_Click failed. Error: " + Err.Description
End Sub

