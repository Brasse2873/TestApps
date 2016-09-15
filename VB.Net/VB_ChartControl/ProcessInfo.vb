Imports System
Imports System.Diagnostics
Imports System.Linq

Public Class ProcessInfo

    Private _name As String
    Public Property name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _id As Integer
    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _workingSet
    Public Property workingSet As Long
        Get
            Return _workingSet
        End Get
        Set(ByVal value As Long)
            _workingSet = value
        End Set
    End Property

End Class


Public Class ProcessList
    Public Shared Function GetTopWoringSet(ByVal topN As Integer) As IEnumerable(Of ProcessInfo)
        Return (
            From process In process.GetProcesses()
            Order By process.WorkingSet64 Descending
            Select New ProcessInfo With
            {
                .name = process.ProcessName,
                .workingSet = process.WorkingSet64,
                .id = process.Id
            }
        ).Take(topN)

    End Function

End Class
