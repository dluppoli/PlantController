using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using PlantController.Helpers;
using System.Net;

namespace PlantController.UnitTests
{
    [TestFixture]
    class DownloadHelperTests
    {
        [Test]
        public void DownloadFile_DownloadFails_ReturnFalse()
        {
            var mock = new Mock<IFileDownloader>();
            var dh = new DownloadHelper(mock.Object);
            mock.Setup(m => m.DownloadFile(It.IsAny<string>(), It.IsAny<string>())).Throws<WebException>();

            var result = dh.DownloadFile("url", "out.txt");
            Assert.That(result, Is.False);
        }
    }
}
