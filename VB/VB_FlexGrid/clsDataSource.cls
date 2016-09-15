VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 1  'vbDataSource
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsDataSource"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit
Private WithEvents rs As ADODB.Recordset
Attribute rs.VB_VarHelpID = -1
Private myObjects As Collection


Private Sub Class_GetDataMember(DataMember As String, Data As Object)
   Set Data = rs
End Sub

Private Sub Class_Initialize()
   Dim strPath As String, strName As String
   Dim i As Integer

   ' Create an instance of the Recordset.
   Set rs = New ADODB.Recordset

   ' Set the properties of the Recordset.
   With rs
      .Fields.Append "Name", adVarChar, 50
      .Fields.Append "Description", adVarChar, 255
      .CursorType = adOpenStatic
      .LockType = adLockOptimistic
      .Open
   End With

End Sub

Public Sub Initialize(myObjects As Collection)
    Dim myObject As myClass
       
    For Each myObject In myObjects
        With rs
           .AddNew
           .Fields.Item("Name") = myObject.Name
           .Fields.Item("Description") = myObject.Description
           .Update
        End With
    Next

    rs.MoveFirst
End Sub


Public Sub Cycle()
   ' Cycle through the Recordset.
   rs.MoveNext
   If rs.EOF = True Then
      rs.MoveFirst
   End If
End Sub

