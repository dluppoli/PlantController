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
    class ItemsListTests
    {
        private ItemsList _items;

        [SetUp]
        public void SetUp()
        {
            _items = new ItemsList();

           _items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
           _items.Add(new Item { Id = 2, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 1 });
           _items.Add(new Item { Id = 3, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 3, StateId = 2 });
           _items.Add(new Item { Id = 4, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 4, StateId = 2 });
           _items.Add(new Item { Id = 5, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 5, StateId = 3 });
           _items.Add(new Item { Id = 6, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 6, StateId = 3 });
        }

        [TearDown]
        public void TearDown()
        { }

        [Test]
        public void CsvFormat_WhenCalled_ReturnCsvArray()
        {
            var items = new ItemsList();
            Item i1 = new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 3 };
            Item i2 = new Item { Id = 2, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 3 };
            Item i3 = new Item { Id = 3, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 3 };

            items.Add(i1);
            items.Add(i2);
            items.Add(i3);

            var result = items.CsvFormat;

            Assert.That(result.Count(), Is.EqualTo(3));
            Assert.That(result, Does.Contain(i1.CsvFormat));
            Assert.That(result, Does.Contain(i2.CsvFormat));
            Assert.That(result, Does.Contain(i3.CsvFormat));
            Assert.That(result, Is.Unique);

            Assert.That(result.FirstOrDefault(), Is.EqualTo(i1.CsvFormat));
            Assert.That(result.Skip(0).Take(1).FirstOrDefault(), Is.EqualTo(i1.CsvFormat));
        }

        [Test]
        [TestCase(1,3)]
        [TestCase(2, 7)]
        [TestCase(3, 11)]
        public void TotalByState_InRangeState_ReturnCount(int state, int expectedResult)
        {
            /*var items = new ItemsList();
            items.Add(new Item { Id = 1, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 1, StateId = 1 });
            items.Add(new Item { Id = 2, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 2, StateId = 1 });
            items.Add(new Item { Id = 3, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 3, StateId = 2 });
            items.Add(new Item { Id = 4, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 4, StateId = 2 });
            items.Add(new Item { Id = 5, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 5, StateId = 3 });
            items.Add(new Item { Id = 6, Code = "A", Name = "B", OrderDate = new DateTime(2021, 12, 31), Quantity = 6, StateId = 3 });
            */
            var result = _items.TotalByState(state);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(0)]
        [TestCase(4)]
        public void TotalByState_OutOfRangeState_ThrowsOutOfrangeException(int state)
        {
            //var result = _items.TotalByState(state);

            Assert.That(() => _items.TotalByState(state), Throws.InstanceOf<ArgumentOutOfRangeException>());
        }
    }
}
