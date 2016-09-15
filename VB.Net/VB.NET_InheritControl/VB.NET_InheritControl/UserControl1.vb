Imports C1.Win.C1FlexGrid.C1FlexGrid
Imports System.Math


Public Class UserControl1
    Inherits C1.Win.C1FlexGrid.C1FlexGrid
    Protected Overrides Sub OnMouseWheel(ByVal e As MouseEventArgs)
        Const DELTA_MIN As Integer = 120
        If Math.Abs(e.Delta) < DELTA_MIN Then
            Dim delta As Integer = Math.Sign(e.Delta) * DELTA_MIN
            e = New MouseEventArgs(e.Button, e.Clicks, e.X, e.Y, delta)
        End If
        MyBase.OnMouseWheel(e)
    End Sub
End Class
