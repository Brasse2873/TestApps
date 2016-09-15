VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "Model"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Private m_field As Integer

Public Event OnFieldChanged()
Public Sub FireFieldChange()
    RaiseEvent OnFieldChanged
End Sub


Public Property Get Field() As Variant
    Field = m_field
End Property

Public Property Let Field(ByVal vNewValue As Variant)
    m_field = vNewValue
    FireFieldChange
End Property


Public Sub IncreaseField()
    Field = Field + 1
End Sub
