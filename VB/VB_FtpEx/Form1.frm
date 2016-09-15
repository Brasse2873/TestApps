VERSION 5.00
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   6345
   ClientLeft      =   60
   ClientTop       =   450
   ClientWidth     =   7155
   LinkTopic       =   "Form1"
   ScaleHeight     =   6345
   ScaleWidth      =   7155
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdRename 
      Caption         =   "cmdRename"
      Height          =   495
      Left            =   480
      TabIndex        =   16
      Top             =   5040
      Width           =   2055
   End
   Begin VB.CommandButton cmdGetCurrentDirectory 
      Caption         =   "cmdGetCurrentDirectory"
      Height          =   495
      Left            =   480
      TabIndex        =   12
      Top             =   1800
      Width           =   2055
   End
   Begin VB.TextBox txtFtpSetCurrentDirectory 
      Height          =   285
      Left            =   2760
      TabIndex        =   11
      Text            =   "txtFtpSetCurrentDirectory"
      Top             =   2520
      Width           =   4095
   End
   Begin VB.CommandButton cmdInternetClose 
      Caption         =   "cmdInternetClose"
      Height          =   495
      Left            =   480
      TabIndex        =   4
      Top             =   5640
      Width           =   2055
   End
   Begin VB.CommandButton cmdSetcurrentDirectory 
      Caption         =   "cmdSetcurrentDirectory"
      Height          =   735
      Left            =   480
      TabIndex        =   3
      Top             =   2520
      Width           =   2055
   End
   Begin VB.CommandButton cmdFtpPutFile 
      Caption         =   "cmdFtpPutFile"
      Height          =   495
      Left            =   480
      TabIndex        =   2
      Top             =   4440
      Width           =   2055
   End
   Begin VB.CommandButton cmdInternetConnect 
      Caption         =   "cmdInternetConnect"
      Height          =   495
      Left            =   480
      TabIndex        =   1
      Top             =   1080
      Width           =   2055
   End
   Begin VB.CommandButton cmdInternetOpen 
      Caption         =   "cmdInternetOpen"
      Height          =   495
      Left            =   480
      TabIndex        =   0
      Top             =   360
      Width           =   2055
   End
   Begin VB.Label lblPutFileResult 
      BorderStyle     =   1  'Fixed Single
      Caption         =   "lblPutFileResult"
      Height          =   255
      Left            =   3840
      TabIndex        =   15
      Top             =   4680
      Width           =   975
   End
   Begin VB.Label Label4 
      Caption         =   "Result:"
      Height          =   255
      Left            =   2760
      TabIndex        =   14
      Top             =   4680
      Width           =   975
   End
   Begin VB.Label lblGetCurrentDirectoryValue 
      BorderStyle     =   1  'Fixed Single
      Caption         =   "lblGetCurrentDirectoryValue"
      Height          =   255
      Left            =   2760
      TabIndex        =   13
      Top             =   1800
      Width           =   4095
   End
   Begin VB.Label lblSetDirResult 
      BorderStyle     =   1  'Fixed Single
      Caption         =   "lblSetDirResult"
      Height          =   255
      Left            =   3840
      TabIndex        =   10
      Top             =   3000
      Width           =   975
   End
   Begin VB.Label Label3 
      Caption         =   "Result"
      Height          =   255
      Left            =   2760
      TabIndex        =   9
      Top             =   3000
      Width           =   975
   End
   Begin VB.Label lblhOpenValue 
      BorderStyle     =   1  'Fixed Single
      Caption         =   "lblhOpenValue"
      Height          =   255
      Left            =   3840
      TabIndex        =   8
      Top             =   1080
      Width           =   975
   End
   Begin VB.Label Label2 
      Caption         =   "hOpen:"
      Height          =   255
      Left            =   2760
      TabIndex        =   7
      Top             =   1080
      Width           =   975
   End
   Begin VB.Label lblhConnectionValue 
      BorderStyle     =   1  'Fixed Single
      Caption         =   "lblhConnectionValue"
      Height          =   255
      Left            =   3840
      TabIndex        =   6
      Top             =   360
      Width           =   975
   End
   Begin VB.Label Label1 
      Caption         =   "hConnection:"
      Height          =   255
      Left            =   2760
      TabIndex        =   5
      Top             =   360
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private m_hInternetSession As Long
Private m_hFtpSession As Long


Private Sub cmdFtpPutFile_Click()
    Dim Result As Boolean
    
    Result = FtpPutFile(m_hFtpSession, "c:\temp\moratest.txt", "moratestvms.txt", FTP_TRANSFER_TYPE_ASCII, 0)
    If Result = False Then ErrorOut Err.LastDllError, "cmdFtpPutFile_Click"
    lblPutFileResult = Result
End Sub

Private Sub cmdGetCurrentDirectory_Click()
    Dim sPath As String
    Dim nBuffSize As Long
    
    sPath = String(255, 0)
    nBuffSize = Len(sPath)
    If (FtpGetCurrentDirectory(m_hFtpSession, sPath, nBuffSize) = False) Then ErrorOut Err.LastDllError, "cmdGetCurrentDirectory_Click"
    lblGetCurrentDirectoryValue = Left(sPath, nBuffSize)
End Sub

Private Sub cmdInternetClose_Click()
    If m_hInternetSession <> 0 Then InternetCloseHandle (m_hInternetSession)
    If m_hFtpSession <> 0 Then InternetCloseHandle (m_hFtpSession)
    m_hInternetSession = 0
    m_hFtpSession = 0
    lblhConnectionValue = m_hInternetSession
    lblhOpenValue = m_hFtpSession
End Sub

Private Sub cmdInternetConnect_Click()
    m_hFtpSession = InternetConnect(m_hInternetSession, "10.245.147.234", INTERNET_INVALID_PORT_NUMBER, "schererm", "scarlett1985", INTERNET_SERVICE_FTP, INTERNET_FLAG_PASSIVE, 0)
    If m_hFtpSession = 0 Then ErrorOut Err.LastDllError, "cmdInternetConnect_Click"
    lblhOpenValue = m_hFtpSession
End Sub

Private Sub cmdInternetOpen_Click()
    m_hInternetSession = InternetOpen("ProductName", INTERNET_OPEN_TYPE_DIRECT, vbNullString, vbNullString, 0)
    If m_hInternetSession = 0 Then ErrorOut Err.LastDllError, "cmdInternetOpen_Click"
    lblhConnectionValue = m_hInternetSession
End Sub




Function ErrorOut(dError As Long, szCallFunction As String)
    Dim dwIntError As Long, dwLength As Long
    Dim strBuffer As String
    If dError = ERROR_INTERNET_EXTENDED_ERROR Then
        InternetGetLastResponseInfo dwIntError, vbNullString, dwLength
        strBuffer = String(dwLength + 1, 0)
        InternetGetLastResponseInfo dwIntError, strBuffer, dwLength
        
        MsgBox szCallFunction & " Extd Err: " & dwIntError & " " & strBuffer
    Else
        MsgBox "Faild with error code = " & dError
    End If
    
    
End Function


Private Sub cmdRename_Click()
    If (FtpRenameFile(m_hFtpSession, "zone.ipg", "zone.txt") = False) Then ErrorOut Err.LastDllError, "cmdRename_Click"

End Sub

Private Sub cmdSetcurrentDirectory_Click()
    Dim Result As Boolean
    
    Result = FtpSetCurrentDirectory(m_hFtpSession, txtFtpSetCurrentDirectory)
    If (Result = False) Then ErrorOut Err.LastDllError, "cmdSetcurrentDirectory_Click"
    lblSetDirResult = Result
End Sub

Private Sub Form_Load()
    lblhConnectionValue = 0
    lblhOpenValue = 0
    lblSetDirResult = ""
    lblGetCurrentDirectoryValue = ""
    lblPutFileResult = 0
End Sub


