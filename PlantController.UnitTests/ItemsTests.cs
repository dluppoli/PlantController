using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using PlantController.Models;

namespace PlantController.UnitTests
{

    [TestFixture]
    public class ItemsTest
    {
        [Test]
        public void getAllWithShippingDate_WhenCalled_ReturnShipingDatePlus10DaysNoWeekend()
        {
            var mock = new Mock<IDBContext>();
            mock.Setup(m => m.Items).Returns(new List<Item> {
                new Item { OrderDate = new DateTime(2022,01,01)},
                new Item { OrderDate = new DateTime(2022,01,05)},
                new Item { OrderDate = new DateTime(2022,01,06)}
            });

            var result = Items.getAllWithShippingDate(mock.Object);

            Assert.That(result.Skip(0).Take(1).FirstOrDefault().ShippingDate, Is.EqualTo(new DateTime(2022, 01, 11)));
            Assert.That(result.Skip(1).Take(1).FirstOrDefault().ShippingDate, Is.EqualTo(new DateTime(2022, 01, 17)));
            Assert.That(result.Skip(2).Take(1).FirstOrDefault().ShippingDate, Is.EqualTo(new DateTime(2022, 01, 17)));
        }
    }
}
