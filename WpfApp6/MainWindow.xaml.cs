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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public uint PackageNumber { get; set; }

        private Package selectedPackage;

        public Package SelectedPackage
        {
            get => selectedPackage;
            set
            {
                selectedPackage = value;
                NotifyOfPropertyChanged("SelectedPackage");
            }
        }

        private ObservableCollection<Package> packageList = new ObservableCollection<Package>();
        public ObservableCollection<Package> PackageList
        {
            get => packageList;
            set
            {
                packageList = value;
                NotifyOfPropertyChanged("PackageList");
            }
        }

        private void NotifyOfPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
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
                    originalPackages = new List<Package>(PackageList);

                }
            }
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            DetailsDialog detailsDialog = new DetailsDialog();
            detailsDialog.SelectedPackage = (Package)orderTxtBox.SelectedItem;
            detailsDialog.DoCopyForOriginal();

            if (detailsDialog.ShowDialog() == false)
            {
                PackageList.Remove(detailsDialog.SelectedPackage);
                originalPackages = new List<Package>(PackageList);
            }
        }

        private List<Package> originalPackages = new List<Package>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void PackageNoTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox senderTextBox)
            {
                string filterText = senderTextBox.Text;

                if (!string.IsNullOrWhiteSpace(filterText))
                {
                    PackageList = new ObservableCollection<Package>(originalPackages.Where(x => x.PackageNumber.ToString().Contains(filterText)));
                }
                else
                {
                    PackageList = new ObservableCollection<Package>(originalPackages);
                }
            }
        }
    }
}
