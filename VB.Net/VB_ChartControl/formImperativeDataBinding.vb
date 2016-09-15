Imports System.Windows.Forms.DataVisualization.Charting


Public Class formImperativeDataBinding

    Private Sub formImperativeDataBinding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'Using Add()
        Chart1.Series(0).Points.Add(New DataPoint(1, 2))
        Chart1.Series(0).Points.Add(New DataPoint(2, 2))
        Chart1.Series(0).Points.Add(New DataPoint(3, 3))
        Chart1.Series(0).Points.Add(New DataPoint(8, 1))

        'Using AddXY()
        Chart2.Series(0).Points.AddXY(1, 4)
        Chart2.Series(0).Points.AddXY(2, 1)
        Chart2.Series(0).Points.AddXY(3, 7)

        'Using AddY()
        Chart3.Series(0).Points.AddY(1)
        Chart3.Series(0).Points.AddY(2)
        Chart3.Series(0).Points.AddY(3)
        Chart3.Series(0).Points.AddY(4)

    End Sub
End Class