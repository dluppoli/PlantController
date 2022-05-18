using ParallelFileDownloader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ParallelFileDownloader.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {

        #region Binding Properties
        private string _newUrl;

        public string NewUrl
        {
            get { return _newUrl; }
            set
            {
                _newUrl = value;
                NotifyOfPropertyChanged("NewUrl");
            }
        }

        private ObservableCollection<DownloadingFile> _fileList;
        public ObservableCollection<DownloadingFile> FileList
        {
            get
            {
                return _fileList;
            }
            set
            {
                _fileList = value;
                NotifyOfPropertyChanged("ItemsList");
            }
        }

        private DownloadingFile _selectedFile;

        public DownloadingFile SelectedFile
        {
            get { return _selectedFile; }
            set
            {
                _selectedFile = value;
                NotifyOfPropertyChanged("SelectedFile");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyOfPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            FileList = new ObservableCollection<DownloadingFile>();
        }
        #endregion


        public void NewDownload()
        {
            if (  !String.IsNullOrEmpty(NewUrl) && !String.IsNullOrWhiteSpace(NewUrl) )
            {
                Console.WriteLine(DateTime.Now);
                DownloadingFile df = new DownloadingFile(NewUrl);
                df.DownloadCompleted += DownloadCompleted;
                FileList.Add(df);
                NewUrl = String.Empty;
            }
        }

        public void Play()
        {
            SelectedFile.Resume();
        }

        public void Pause()
        {
            SelectedFile.Pause();
        }

        public void Stop()
        {
            SelectedFile.Stop();
        }

        private void DownloadCompleted(object sender, EventArgs e)
        {
            MessageBox.Show($"Terminato download di: {((DownloadingFile)sender).Url}");
        }
    }
}
