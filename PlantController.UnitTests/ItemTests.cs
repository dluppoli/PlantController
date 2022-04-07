using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlantController.Models;

namespace PlantController.UnitTests
{
    [TestFixture]
    public class ItemTests
    {
        [Test]
        [TestCase(-1,1)]
        [TestCase(1, 0)]
        [TestCase(0, 0)]
        public void DaysOld_WhenCalled_ReturnDaysDiff(int daysToAdd, int expectedResult)
        {
            // AAA
            //Arrange
            var item = new Item { OrderDate = DateTime.Today.AddDays(daysToAdd) };

            //Act
            var result = item.DaysOld;

            //Assert
            //Assert.AreEqual(expectedResult, result);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /*[Test]
        public void DaysOld_OrderDateGreaterThanToday_ReturnZero()
        {
            //Arrange
            var item = new Item { OrderDate = DateTime.Today.AddDays(1) };

            //Act
            var result = item.DaysOld;

            //Assert
            Assert.AreEqual(0, result);
        }

        [Test]
        public void DaysOld_OrderDateEqualsToday_ReturnZero()
        {
            //Arrange
            var item = new Item { OrderDate = DateTime.Today };

            //Act
            var result = item.DaysOld;

            //Assert
            Assert.AreEqual(0, result);
        }*/


        [Test]
        public void CsvFormat_WhenCalled_ReturnCsvString()
        {
            var item = new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 3 };

            var result = item.CsvFormat;

            Assert.That(result, Is.EqualTo("1;A;B;2;20211231;3;"));
            Assert.That(result, Does.EndWith(";"));
        }

        [Test]
        [TestCase(1, "Da produrre")]
        [TestCase(2, "In produzione")]
        [TestCase(3, "Prodotto")]
        [TestCase(4, "Non definito")]
        public void State_WhenGetter_ReturnStateString(int state, string expectedResult)
        {
            var item = new Item { StateId = state };
            var result = item.State;
            Assert.That(result, Does.Contain(expectedResult).IgnoreCase);
        }
    }
}
