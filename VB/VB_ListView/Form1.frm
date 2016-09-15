VERSION 5.00
Object = "{831FDD16-0C5C-11D2-A9FC-0000F8754DA1}#2.1#0"; "MSCOMCTL.OCX"
Begin VB.Form Form1 
   BackColor       =   &H80000005&
   Caption         =   "Form1"
   ClientHeight    =   4260
   ClientLeft      =   120
   ClientTop       =   450
   ClientWidth     =   3780
   LinkTopic       =   "Form1"
   ScaleHeight     =   4260
   ScaleWidth      =   3780
   StartUpPosition =   3  'Windows Default
   Begin MSComctlLib.ListView ListView1 
      Height          =   2775
      Left            =   0
      TabIndex        =   1
      Top             =   0
      Width           =   3735
      _ExtentX        =   6588
      _ExtentY        =   4895
      View            =   3
      LabelWrap       =   -1  'True
      HideSelection   =   -1  'True
      FullRowSelect   =   -1  'True
      GridLines       =   -1  'True
      _Version        =   393217
      ForeColor       =   -2147483640
      BackColor       =   -2147483643
      BorderStyle     =   1
      Appearance      =   1
      NumItems        =   0
   End
   Begin VB.Label lblSelected 
      BackColor       =   &H80000005&
      BorderStyle     =   1  'Fixed Single
      Height          =   495
      Left            =   0
      TabIndex        =   2
      Top             =   3120
      Width           =   3735
      WordWrap        =   -1  'True
   End
   Begin VB.Label Label1 
      BackColor       =   &H80000005&
      Caption         =   "Selected:"
      Height          =   255
      Left            =   0
      TabIndex        =   0
      Top             =   2880
      Width           =   975
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub Form_Load()
    Dim item As ListItem

    ListView1.AllowColumnReorder = True
    ListView1.Appearance = cc3D
    ListView1.BackColor = &HFFFF&
    ListView1.BorderStyle = ccNone
    ListView1.FlatScrollBar = True
    ListView1.ForeColor = &HFF0000
    ListView1.FullRowSelect = True
    ListView1.GridLines = True
    ListView1.LabelEdit = lvwManual
    ListView1.MultiSelect = True
    ListView1.Sorted = True
    ListView1.SortKey = 0
    ListView1.SortOrder = lvwAscending
    ListView1.View = lvwReport
    
    Call ListView1.ColumnHeaders.Add(, , "col1")
    Call ListView1.ColumnHeaders.Add(, , "col2")
    Call ListView1.ColumnHeaders.Add(, , "col3")

    Set item = ListView1.ListItems.Add(, , "Hej")
    item.SubItems(1) = "Hopp"
    item.SubItems(2) = "123"
    item.Selected = False

    Set item = ListView1.ListItems.Add(, , "A")
    item.SubItems(1) = "Ö"
    item.SubItems(2) = "5"
    item.Selected = False

    Set item = ListView1.ListItems.Add(, , "D")
    item.SubItems(1) = "B"
    item.SubItems(2) = "11"
    item.Selected = False
    
    ListView1.SelectedItem = ListView1.ListItems(1)
    ListView1.SelectedItem.EnsureVisible
    
    ListView1_Click


End Sub

Private Sub ListView1_Click()
    Dim item As ListItem
    lblSelected = ""
    For Each item In ListView1.ListItems
        If item.Selected Then lblSelected = lblSelected & item & "  "
    Next
End Sub

Private Sub ListView1_ColumnClick(ByVal ColumnHeader As MSComctlLib.ColumnHeader)
    ListView1.SortKey = ColumnHeader.Index - 1
    ListView1.SortOrder = (Not ListView1.SortOrder) And 1
    
End Sub
