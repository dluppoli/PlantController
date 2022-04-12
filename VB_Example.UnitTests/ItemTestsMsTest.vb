Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VB_Example


<TestClass>
Public Class ItemTestsMsTest

    <TestMethod>
    Public Sub DaysOld_OrderDateSmallerThanToday_ReturnDaysDiff()
        'Arrange
        Dim window As New MainWindow
        Dim OrderDate As Date
        OrderDate = DateTime.Today.AddDays(-1)

        'Act
        Dim result = window.DaysOld(OrderDate)

        'Assert
        Assert.AreEqual(1, result)

    End Sub

    <TestMethod>
    Public Sub DaysOld_OrderDateGreaterThanToday_ReturnZero()
        'Arrange
        Dim window As New MainWindow
        Dim OrderDate As Date
        OrderDate = DateTime.Today.AddDays(1)

        'Act
        Dim result = window.DaysOld(OrderDate)

        'Assert
        Assert.AreEqual(0, result)

    End Sub

    <TestMethod>
    Public Sub DaysOld_OrderDateEqualsToday_ReturnZero()
        'Arrange
        Dim window As New MainWindow
        Dim OrderDate As Date
        OrderDate = DateTime.Today.AddDays(0)

        'Act
        Dim result = window.DaysOld(OrderDate)

        'Assert
        Assert.AreEqual(0, result)

    End Sub

End Class