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
using System.Windows.Shapes;
using WpfApp6.Models;

namespace WpfApp6
{
    /// <summary>
    /// Logika interakcji dla klasy NewDialog.xaml
    /// </summary>
    public partial class NewDialog : Window
    {
        public Package NewPackage { get; set; }

        public NewDialog()
        {
            InitializeComponent();
            DataContext = this;

            NewPackage = new Package()
            {
                Receiver = new Person(),
                Sender = new Person(),
            };

            NewPackage.ShipmentDate = DateTime.Now.Date;

        }
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(Validate())
            {
                this.DialogResult = true;
                this.Close(); 
            }
            else
            {
                ErrorDialog errorDialog = new ErrorDialog();
                errorDialog.ShowDialog();
            }
        }

        private bool Validate()
        {
            if (PackageNumberText.Text == string.Empty || senderName.Text == string.Empty || senderSurname.Text == string.Empty
                || senderCity.Text == string.Empty || senderStreet.Text == string.Empty || senderApartmentNumber.Text == string.Empty
                || senderZipCode.Text == string.Empty || receiverName.Text == string.Empty || receiverSurname.Text == string.Empty
                || receiverCity.Text == string.Empty || receiverStreet.Text == string.Empty || receiverApartamentNumber.Text == string.Empty 
                || receiverZipCode.Text == string.Empty || weight.Text == string.Empty || price.Text == string.Empty || dayOfPosting.Text == string.Empty) {

                return false;
            }

            return true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
