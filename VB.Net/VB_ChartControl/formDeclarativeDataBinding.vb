Public Class formDeclarativeDataBinding


    Private Sub formDeclarativeDataBinding_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProcessInfoBindingSource.DataSource = ProcessList.GetTopWoringSet(10)
    End Sub

End Class