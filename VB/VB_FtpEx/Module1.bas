Attribute VB_Name = "Module1"
Option Explicit

Public Declare Function FtpPutFile Lib "WinInet.dll" Alias "FtpPutFileA" _
(ByVal hFtpSession As Long, ByVal lpszLocalFile As String, _
      ByVal lpszRemoteFile As String, _
      ByVal dwFlags As Long, ByVal dwContext As Long) As Boolean

Public Declare Function FtpSetCurrentDirectory Lib "WinInet.dll" Alias "FtpSetCurrentDirectoryA" _
    (ByVal hFtpSession As Long, ByVal lpszDirectory As String) As Boolean
    
' Initializes an application's use of the Win32 Internet functions
Public Declare Function InternetOpen Lib "WinInet.dll" Alias "InternetOpenA" _
(ByVal sAgent As String, ByVal lAccessType As Long, ByVal sProxyName As String, _
ByVal sProxyBypass As String, ByVal lFlags As Long) As Long

' Use registry access settings.
Public Const INTERNET_OPEN_TYPE_PRECONFIG = 0
Public Const INTERNET_OPEN_TYPE_DIRECT = 1
Public Const INTERNET_OPEN_TYPE_PROXY = 3
Public Const INTERNET_INVALID_PORT_NUMBER = 0

Public Const FTP_TRANSFER_TYPE_BINARY = &H2
Public Const FTP_TRANSFER_TYPE_ASCII = &H1
Public Const INTERNET_FLAG_PASSIVE = &H8000000

' Opens a HTTP session for a given site.
Public Declare Function InternetConnect Lib "WinInet.dll" Alias "InternetConnectA" _
(ByVal hInternetSession As Long, ByVal sServerName As String, ByVal nServerPort As Integer, _
ByVal sUsername As String, ByVal sPassword As String, ByVal lService As Long, _
ByVal lFlags As Long, ByVal lContext As Long) As Long
                
Public Const ERROR_INTERNET_EXTENDED_ERROR = 12003
Public Declare Function InternetGetLastResponseInfo Lib "WinInet.dll" Alias "InternetGetLastResponseInfoA" ( _
    lpdwError As Long, _
    ByVal lpszBuffer As String, _
    lpdwBufferLength As Long) As Boolean

' Number of the TCP/IP port on the server to connect to.
Public Const INTERNET_DEFAULT_FTP_PORT = 21
Public Const INTERNET_DEFAULT_GOPHER_PORT = 70
Public Const INTERNET_DEFAULT_HTTP_PORT = 80
Public Const INTERNET_DEFAULT_HTTPS_PORT = 443
Public Const INTERNET_DEFAULT_SOCKS_PORT = 1080

Public Const INTERNET_OPTION_CONNECT_TIMEOUT = 2
Public Const INTERNET_OPTION_RECEIVE_TIMEOUT = 6
Public Const INTERNET_OPTION_SEND_TIMEOUT = 5

Public Const INTERNET_OPTION_USERNAME = 28
Public Const INTERNET_OPTION_PASSWORD = 29
Public Const INTERNET_OPTION_PROXY_USERNAME = 43
Public Const INTERNET_OPTION_PROXY_PASSWORD = 44

' Type of service to access.
Public Const INTERNET_SERVICE_FTP = 1
Public Const INTERNET_SERVICE_GOPHER = 2
Public Const INTERNET_SERVICE_HTTP = 3

' Brings the data across the wire even if it locally cached.
Public Const INTERNET_FLAG_RELOAD = &H80000000
Public Const INTERNET_FLAG_KEEP_CONNECTION = &H400000
Public Const INTERNET_FLAG_MULTIPART = &H200000

Public Const GENERIC_READ = &H80000000
Public Const GENERIC_WRITE = &H40000000

' Closes a single Internet handle or a subtree of Internet handles.
Public Declare Function InternetCloseHandle Lib "WinInet.dll" _
(ByVal hInet As Long) As Integer

Public Declare Function FtpGetCurrentDirectory Lib "WinInet.dll" Alias "FtpGetCurrentDirectoryA" (ByVal hFtpSession _
As Long, ByVal lpszCurrentDirectory As String, lpdwCurrentDirectory As Long) As Long

Public Declare Function GetLastError Lib "kernel32" () As Long

Declare Function FtpRenameFile _
    Lib "WinInet.dll" _
    Alias "FtpRenameFileA" ( _
    ByVal hConnect As Long, _
    ByVal lpszExisting As String, _
    ByVal lpszNew As String) As Long


