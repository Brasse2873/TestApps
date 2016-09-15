VERSION 5.00
Object = "{5E9E78A0-531B-11CF-91F6-C2863C385E30}#1.0#0"; "MSFLXGRD.OCX"
Object = "{0ECD9B60-23AA-11D0-B351-00A0C9055D8E}#6.0#0"; "MSHFLXGD.OCX"
Begin VB.Form Form1 
   Caption         =   "Form1"
   ClientHeight    =   5655
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   5385
   LinkTopic       =   "Form1"
   ScaleHeight     =   5655
   ScaleWidth      =   5385
   StartUpPosition =   3  'Windows Default
   Begin MSHierarchicalFlexGridLib.MSHFlexGrid MSHFlexGrid2 
      Height          =   1335
      Left            =   120
      TabIndex        =   2
      Top             =   2280
      Width           =   3735
      _ExtentX        =   6588
      _ExtentY        =   2355
      _Version        =   393216
      _NumberOfBands  =   1
      _Band(0).Cols   =   2
   End
   Begin MSHierarchicalFlexGridLib.MSHFlexGrid MSHFlexGrid1 
      Height          =   1215
      Left            =   120
      TabIndex        =   1
      Top             =   4200
      Width           =   3735
      _ExtentX        =   6588
      _ExtentY        =   2143
      _Version        =   393216
      FixedCols       =   0
      _NumberOfBands  =   1
      _Band(0).Cols   =   2
   End
   Begin MSFlexGridLib.MSFlexGrid MSFlexGrid1 
      Height          =   1815
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3735
      _ExtentX        =   6588
      _ExtentY        =   3201
      _Version        =   393216
      SelectionMode   =   1
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Private objSource As clsDataSource
Private objBindingCollection As BindingCollection


Private Sub Form_Load()
    manualFormat
    
    manualFormat2
    
    dataSourceFormat
End Sub

Private Sub manualFormat()
    MSFlexGrid1.Rows = 4
    MSFlexGrid1.Cols = 2
    
    MSFlexGrid1.TextMatrix(0, 0) = "Col 1"
    MSFlexGrid1.TextMatrix(0, 1) = "Col 2"
    
    MSFlexGrid1.TextMatrix(1, 0) = "A value 1"
    MSFlexGrid1.TextMatrix(1, 1) = "321"
    
    MSFlexGrid1.TextMatrix(2, 0) = "B value 2"
    MSFlexGrid1.TextMatrix(2, 1) = "123"
    
    MSFlexGrid1.TextMatrix(3, 0) = "C value 3"
    MSFlexGrid1.TextMatrix(3, 1) = "999"
    
    
    MSFlexGrid1.Sort = 0

End Sub


Private Sub manualFormat2()
    MSHFlexGrid2.Rows = 4
    MSHFlexGrid2.Cols = 2
    MSHFlexGrid2.FixedCols = 1
    
    
    MSHFlexGrid2.TextMatrix(0, 0) = "Col 1"
    MSHFlexGrid2.TextMatrix(0, 1) = "Col 2"
    
    MSHFlexGrid2.TextMatrix(1, 0) = "A value 1"
    MSHFlexGrid2.TextMatrix(1, 1) = "321"
    
    MSHFlexGrid2.TextMatrix(2, 0) = "B value 2"
    MSHFlexGrid2.TextMatrix(2, 1) = "123"
    
    MSHFlexGrid2.TextMatrix(3, 0) = "C value 3"
    MSHFlexGrid2.TextMatrix(3, 1) = "999"
    
    
    MSHFlexGrid2.Sort = 0

End Sub


Private Sub dataSourceFormat()
    Dim myObjects As New Collection
    Dim obj1 As New myClass
    Dim obj2 As New myClass

    obj1.Name = "Obj1"
    obj1.Description = "Desc 1"
    myObjects.Add obj1

    obj2.Name = "Obj2"
    obj2.Description = "Desc 2"
    myObjects.Add obj2

    Set objSource = New clsDataSource
    Call objSource.Initialize(myObjects)
    
    MSHFlexGrid1.Cols = 2
    
    Set MSHFlexGrid1.DataSource = objSource
    
    
End Sub

Private Sub MSFlexGrid1_KeyPress(KeyAscii As Integer)
    Select Case KeyAscii
    Case 3:
        'MSFlexGrid1.ColSel
        Clipboard.Clear
        Clipboard.SetText MSFlexGrid1.Clip
        
    End Select
    
End Sub
