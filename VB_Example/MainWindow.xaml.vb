Public Class MainWindow
    Public Function DaysOld(OrderDate As Date) As Integer

        If (OrderDate > DateTime.Today) Then
            DaysOld = 0
        Else
            DaysOld = (DateTime.Today - OrderDate).Days
        End If

    End Function

End Class
