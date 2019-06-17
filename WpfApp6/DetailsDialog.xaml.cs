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

namespace WpfApp6 {
    /// <summary>
    /// Logika interakcji dla klasy DetailsDialog.xaml
    /// </summary>
    public partial class DetailsDialog : Window {
        public Package SelectedPackage { get; set; }
        private Package original;

        public DetailsDialog() {
            InitializeComponent();
            DataContext = this;
        }

        public void DoCopyForOriginal() {
            original = new Package(SelectedPackage);

            switch(SelectedPackage.Status) {
                case Enums.PackageStatus.InProgress:
                    inProgressRadio.IsChecked = true;
                    break;
                case Enums.PackageStatus.Sent:
                    sentRadio.IsChecked = true;
                    break;
                case Enums.PackageStatus.ReceivedByCourier:
                    receivedByCourierRadio.IsChecked = true;
                    break;
                case Enums.PackageStatus.Delivered:
                    deliveredRadio.IsChecked = true;
                    break;
            }
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e) {
            var printDialog = new PrintDialog();

            if (printDialog.ShowDialog() == true) {
                var doc = new FlowDocument();
                doc.Blocks.Add(new Paragraph(new Run("Przesyłka nr " + SelectedPackage.PackageNumber)));


                doc.Blocks.Add(new Paragraph(new Run("Data nadania: " + SelectedPackage.ShipmentDate.ToShortDateString())));
                if (SelectedPackage.Status == Enums.PackageStatus.Delivered) {
                    doc.Blocks.Add(new Paragraph(new Run("Data dostarczenia: " + SelectedPackage.DeliveryDate.ToShortDateString())));              
                }
                else {
                    doc.Blocks.Add(new Paragraph(new Run("Status: " + Enums.PackageStatusExtensions.GetDescription(SelectedPackage.Status))));
                }

                doc.Blocks.Add(new Paragraph(new Bold(new Run("Nadawca:"))));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Sender.Name + " " + SelectedPackage.Sender.Surname)));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Sender.Street + "/" + SelectedPackage.Sender.LocalNumber)));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Sender.PostCode + " " + SelectedPackage.Sender.City)));

                doc.Blocks.Add(new Paragraph(new Bold(new Run("Odbiorca:"))));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Receiver.Name + " " + SelectedPackage.Receiver.Surname)));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Receiver.Street + "/" + SelectedPackage.Receiver.LocalNumber)));
                doc.Blocks.Add(new Paragraph(new Run(SelectedPackage.Receiver.PostCode + " " + SelectedPackage.Receiver.City)));

                doc.Blocks.Add(new Paragraph(new Run("Waga: " + SelectedPackage.Weight + " kg")));

                IDocumentPaginatorSource idpSource = doc;
                printDialog.PrintDocument(idpSource.DocumentPaginator, "Nie wiem co to jest więc wpisze byle co");
            }          
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) {
            //SelectedPackage = this.original;
            BackToOriginal();
            this.DialogResult = true;
            this.Close();
        }

        private void BackToOriginal()
        {
            SelectedPackage.PackageNumber = original.PackageNumber;

            SelectedPackage.Sender = new Person()
            {
                Name = original.Sender.Name,
                Surname = original.Sender.Surname,
                Street = original.Sender.Street,
                LocalNumber = original.Sender.LocalNumber,
                City = original.Sender.City,
                PostCode = original.Sender.PostCode
            };
            SelectedPackage.Receiver = new Person()
            {
                Name = original.Receiver.Name,
                Surname = original.Receiver.Surname,
                Street = original.Receiver.Street,
                LocalNumber = original.Receiver.LocalNumber,
                City = original.Receiver.City,
                PostCode = original.Receiver.PostCode
            };
            SelectedPackage.Status = original.Status;
            SelectedPackage.Payment = original.Payment;
            SelectedPackage.Weight = original.Weight;
            SelectedPackage.Price = original.Price;
            SelectedPackage.ShipmentDate = original.ShipmentDate;
            SelectedPackage.DeliveryDate = original.DeliveryDate;
        }

        private void CheckStatus() {
            if(inProgressRadio.IsChecked == true) {
                SelectedPackage.Status = Enums.PackageStatus.InProgress;
            }
            else if (receivedByCourierRadio.IsChecked == true) {
                SelectedPackage.Status = Enums.PackageStatus.ReceivedByCourier;
            }
            else if (deliveredRadio.IsChecked == true) {
                SelectedPackage.Status = Enums.PackageStatus.Delivered;
            }
            else if (sentRadio.IsChecked == true) {
                SelectedPackage.Status = Enums.PackageStatus.Sent;
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            this.CheckStatus();
            this.DialogResult = true;
            this.Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) {
            this.DialogResult = false;
        }
    }
}
