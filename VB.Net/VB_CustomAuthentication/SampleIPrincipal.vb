Imports System.Security.Principal

Public Class SampleIPrincipal
    Implements System.Security.Principal.IPrincipal

    Private identityValue As SampleIIdentity
    Private descValue As String

    Public ReadOnly Property Identity As System.Security.Principal.IIdentity Implements System.Security.Principal.IPrincipal.Identity
        Get
            Return identityValue
        End Get
    End Property

    Public Function IsInRole(ByVal role As String) As Boolean Implements System.Security.Principal.IPrincipal.IsInRole
        Return role = identityValue.Role.ToString
    End Function

    Public ReadOnly Property Desc() As String
        Get
            Return descValue
        End Get
    End Property

    Public Sub New(ByVal name As String, ByVal password As String)
        identityValue = New SampleIIdentity(name, password)
    End Sub

End Class
