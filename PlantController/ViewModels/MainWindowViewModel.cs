using PlantController.Helpers;
using PlantController.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PlantController.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ItemsList _itemsList;
        public ItemsList ItemsList
        {
            get
            {
                return _itemsList;
            }
            set
            {
                _itemsList = value;
                NotifyOfPropertyChanged("ItemsList");
            }
        }

        public MainWindowViewModel()
        {
            ItemsList = new ItemsList();
            loadData();
        }

        private void loadData()
        {
            ItemsList = Items.getAllItems();
        }

        public void ExtractCSV()
        {
            ItemsList items = new ItemsList(ItemsList.Where(q => q.IsSelected == true).ToList());
            Items.WriteCsv(items, "out.txt");
            MessageBox.Show("Esportazione effettuata!");
            loadData();
        }

        internal void DownloadUpdates()
        {
            string url = @"https://www.dropbox.com/s/00rx255iiymcxiw/latest.zip?dl=1";
            string outFile = @".\latest.zip";

            DownloadHelper dh = new DownloadHelper();

            if (dh.DownloadFile(url, outFile))
                MessageBox.Show("Download Completato.");
            else
                MessageBox.Show("Download Fallito.","",MessageBoxButton.OK,MessageBoxImage.Error);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyOfPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
