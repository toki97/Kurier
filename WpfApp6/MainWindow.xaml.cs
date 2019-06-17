using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfApp6.Models;

namespace WpfApp6
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public uint PackageNumber { get; set; }

        public ObservableCollection<Package> PackageList { get; set; } = new ObservableCollection<Package>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Package result = null;

            foreach (var package in PackageList) {
                if (package.PackageNumber == PackageNumber) {
                    result = package;
                    break;
                }
            }

            if (result == null) {
                MessageBox.Show("Nieznaleziono paczki o podanym numerze!", "Brak paczki!", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK);
                return;
            }

            DetailsDialog detailsDialog = new DetailsDialog();
            detailsDialog.SelectedPackage = result;
            detailsDialog.DoCopyForOriginal();
            bool? dialogResult = detailsDialog.ShowDialog();

            if (dialogResult == false) {
                PackageList.Remove(result);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewDialog newDialog = new NewDialog();
            bool? dialogResult = newDialog.ShowDialog();
            
            if (dialogResult == true)
            {
                Package newPackage = newDialog.NewPackage;
                
                if (newPackage != null)
                {
                    PackageList.Add(newPackage);
                }
            }
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e) {
            DetailsDialog detailsDialog = new DetailsDialog();
            detailsDialog.SelectedPackage = (Package)orderTxtBox.SelectedItem;
            detailsDialog.DoCopyForOriginal();

            if (detailsDialog.ShowDialog() == false) {
                PackageList.Remove(detailsDialog.SelectedPackage);
            }
        }
    }
}
