Imports System.Windows.Forms.DataVisualization.Charting


Public Class formMain

    Const colnameNAME As String = "Name"
    Const colnameSCORE As String = "Score"
    Const colnameINVALIDS As String = "Invalids"

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim xdata() As String = {"Noll", "Ett", "Två", "Tre"}
        Dim ydata1() As Integer = {0, 1, 2, 3}
        Dim ydata2() As Integer = {4, 5, 6, 7}

        Chart1.Titles.Clear()
        Chart1.Series.Clear()

        Chart1.Titles.Add("Test Chart with array content")
        Chart1.Titles.Add("Int values")

        Chart1.Series.Add("ydata1")
        Chart1.Series("ydata1").Color = Color.Blue
        Chart1.Series("ydata1").Points.DataBindXY(xdata, ydata1)

        Chart1.Series.Add("ydata2")
        Chart1.Series("ydata2").Color = Color.Red
        Chart1.Series("ydata2").Points.DataBindXY(xdata, ydata2)



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'reset chart control                
        Chart2.ChartAreas.Clear()
        Chart2.Series.Clear()
        Chart2.Titles.Clear()
        Chart2.ChartAreas.Add("Area1")

        Dim dt As DataTable = New DataTable()
        createDB(dt)

        'connect data source to series
        Chart2.Titles.Add("Test Chart with DataTable content")
        Chart2.Series.Add("series0")
        Chart2.Series(0).IsXValueIndexed = True
        Chart2.Series(0).YValueMembers = dt.Columns(1).ColumnName
        Chart2.Series(0).XValueMember = dt.Columns(0).ColumnName
        Chart2.Series(0).ChartArea = "Area1"
        Chart2.Series(0).ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column

        'bind
        Chart2.DataSource = dt
        Chart2.DataBind()
    End Sub

    Private Sub createDB(ByVal dt As DataTable)
        'create dummy data source to bind                

        dt.Columns.Add(colnameNAME, GetType(String))
        dt.Columns.Add(colnameSCORE, GetType(Int32))
        dt.Columns.Add(colnameINVALIDS, GetType(Int32))
        Dim dr As DataRow = dt.NewRow()
        dr(colnameNAME) = "Jhon Doe 1"
        dr(colnameSCORE) = 10
        dr(colnameINVALIDS) = 2
        dt.Rows.Add(dr)
        dr = dt.NewRow()
        dr(colnameNAME) = "Jane Doe 2"
        dr(colnameSCORE) = 20
        dr(colnameINVALIDS) = 44
        dt.Rows.Add(dr)
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        formStaticData.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        formTitleLegent.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        form3D.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        formImperativeDataBinding.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        formDeclarativeDataBinding.Show()
    End Sub
End Class
