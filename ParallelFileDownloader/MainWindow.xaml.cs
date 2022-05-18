using ParallelFileDownloader.ViewModels;
using ParallelFileDownloader.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ParallelFileDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _viewmodel;

        public MainWindow()
        {
            InitializeComponent();
            _viewmodel = new MainWindowViewModel();
            this.DataContext = _viewmodel;
        }

        private void Download_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.NewDownload();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.Play();
        }

        private void pause_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.Pause();
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.Stop();
        }
    }
}
