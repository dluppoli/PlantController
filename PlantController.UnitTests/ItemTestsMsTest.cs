using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlantController.Models;

namespace PlantController.UnitTests
{
    [TestClass]
    public class ItemTestsMsTest
    {
        [TestMethod]
        public void DaysOld_OrderDateSmallerThanToday_ReturnDaysDiff()
        {
            // AAA
            //Arrange
            var item = new Item { OrderDate = DateTime.Today.AddDays(-1) };

            //Act
            var result = item.DaysOld;

            //Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DaysOld_OrderDateGreaterThanToday_ReturnZero()
        {
            //Arrange
            var item = new Item { OrderDate = DateTime.Today.AddDays(1) };

            //Act
            var result = item.DaysOld;

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DaysOld_OrderDateEqualsToday_ReturnZero()
        {
            //Arrange
            var item = new Item { OrderDate = DateTime.Today };

            //Act
            var result = item.DaysOld;

            //Assert
            Assert.AreEqual(0, result);
        }
    }
}
