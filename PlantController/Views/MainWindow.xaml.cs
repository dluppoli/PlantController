using MahApps.Metro.Controls;
using PlantController.ViewModels;
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

namespace PlantController
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private MainWindowViewModel _viewmodel;

        public MainWindow()
        {
            InitializeComponent();
            _viewmodel = new MainWindowViewModel();
            this.DataContext = _viewmodel;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.ExtractCSV();
        }

        private void DownloadUpdates_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.DownloadUpdates();
        }

        private void CreateException_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.CreateException();
        }

        private void BadTimer_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.BadTimer();
        }

        private void ReloadData_Click(object sender, RoutedEventArgs e)
        {
            _viewmodel.ReloadData();
        }
    }
}
