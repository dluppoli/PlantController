using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelFileDownloader.Models
{
    public enum DownloadingFileStatus { downloading, paused, cancelled, completed }


    public class DownloadingFile : INotifyPropertyChanged
    {
        #region Binding Properties
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyOfPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Url { get; }

        private DownloadingFileStatus _status;

        public DownloadingFileStatus Status
        {
            get { return _status; }
            set
            {
                _status = value;
                NotifyOfPropertyChanged("Status");
            }
        }

        private double _completionPerc = 0;

        public double CompletionPerc
        {
            get { return _completionPerc; }
            set
            {
                _completionPerc = value;
                NotifyOfPropertyChanged("CompletionPerc");
            }
        }

        private int _fileSize;

        public int FileSize
        {
            get { return _fileSize; }
            set
            {
                _fileSize = value;
                NotifyOfPropertyChanged("FileSize");
            }
        }

        private double _downloadedSize;

        public double DownloadedSize
        {
            get { return _downloadedSize; }
            set
            {
                _downloadedSize = value;
                CompletionPerc = _fileSize != 0 ? (_downloadedSize / _fileSize) * 100.0 : 0;
            }
        }
        #endregion

        #region private fields
        private Task _downloadingTask;
        private bool _canDownload = true;
        private CancellationTokenSource tokensource;
        private CancellationToken ct;
        #endregion

        #region events
        public event EventHandler DownloadCompleted;
        protected virtual void OnDownloadCompleted(EventArgs e)
        {
            DownloadCompleted?.Invoke(this, e);
        }
        #endregion

        public DownloadingFile(string url)
        {
            Url = url;

            var random = new Random();
            FileSize = random.Next(50, 200);

            Start();
        }

        public Task Start()
        {
            tokensource = new CancellationTokenSource();
            ct = tokensource.Token;

            Status = DownloadingFileStatus.downloading;
            DownloadedSize = 0;
            _canDownload = true;
            _downloadingTask = Task.Run(() =>
            {
                try
                {
                    tokensource.CancelAfter(120 * 1000);
                    FakeDownloader();
                }
                catch
                {
                    tokensource.Cancel();
                }
            },ct)
            .ContinueWith((task) => 
            {
                if (ct.IsCancellationRequested)
                    Status = DownloadingFileStatus.cancelled;
                else
                {
                    Status = DownloadingFileStatus.completed;
                    OnDownloadCompleted(new EventArgs());
                }
            });
            return _downloadingTask;
        }

        public void Pause()
        {
            if (Status == DownloadingFileStatus.downloading)
            {
                _canDownload = false;
                Status = DownloadingFileStatus.paused;
            }
        }

        public void Resume()
        {
            if (Status == DownloadingFileStatus.cancelled) Start();

            if (Status == DownloadingFileStatus.paused)
            {
                _canDownload = true;//Monitor.Exit(pauseLock);
                Status = DownloadingFileStatus.downloading;
            }
        }

        public void Stop()
        {
            if (Status == DownloadingFileStatus.downloading || Status == DownloadingFileStatus.paused)
            {
                tokensource.Cancel();
                Status = DownloadingFileStatus.cancelled;
            }
        }

        private void FakeDownloader()
        {
            //Simulo banda di 1MB/sec
            while (CompletionPerc < 100 && ! ct.IsCancellationRequested)
            {
                Thread.Sleep(100);
                if (_canDownload)
                {
                    DownloadedSize += 0.1;
                }
            }
        }
    }
}
