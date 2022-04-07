using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PlantController.Models;
using PlantController.ViewModels;

namespace PlantController.UnitTests
{
    [TestFixture]
    class MainWindowViewModelTests
    {
        [Test]
        public void ItemsList_WhenSetter_RaiseINotifyPropertyChanged()
        {
            var vm = new MainWindowViewModel();
            var result = new PropertyChangedEventArgs("");
            vm.PropertyChanged += (sender, args) => { result = args; };

            vm.ItemsList = new ItemsList();
            Assert.That(result.PropertyName, Is.EqualTo("ItemsList"));
        }
    }
}
