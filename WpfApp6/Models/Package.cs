using System;
using WpfApp6.Enums;

namespace WpfApp6.Models
{
    public class Package : BaseModel
    {
        private uint packageNumber;
        private Person sender;
        private Person receiver;
        private PackageStatus status;
        private PaymentMethod payment;
        private float weight;
        private float price;
        private DateTime shipmentDate;
        private DateTime deliveryDate;

        public uint PackageNumber
        {
            get => packageNumber;
            set => Set(ref packageNumber, value);
        }
        public Person Sender
        {
            get => sender;
            set => Set(ref sender, value);
        }
        public Person Receiver
        {
            get => receiver;
            set => Set(ref receiver, value);
        }
        public float Weight
        {
            get => weight;
            set => Set(ref weight, value);
        }
        public float Price
        {
            get => price;
            set => Set(ref price, value);
        }
        public DateTime ShipmentDate
        {
            get => shipmentDate;
            set => Set(ref shipmentDate, value);
        }
        public DateTime DeliveryDate
        {
            get => deliveryDate;
            set => Set(ref deliveryDate, value);
        }
        public PackageStatus Status
        {
            get => status;
            set => Set(ref status, value);
        }
        public PaymentMethod Payment
        {
            get => payment;
            set => Set(ref payment, value);
        }

        public Package() {
            DeliveryDate = ShipmentDate.AddDays(2).Date;
        }

        public Package(Package package) {
            PackageNumber = package.PackageNumber;
            Sender = new Person() {
                Name = package.Sender.Name,
                Surname = package.Sender.Surname,
                Street = package.Sender.Street,
                LocalNumber = package.Sender.LocalNumber,
                City = package.Sender.City,
                PostCode = package.Sender.PostCode
            };
            Receiver = new Person() {
                Name = package.Receiver.Name,
                Surname = package.Receiver.Surname,
                Street = package.Receiver.Street,
                LocalNumber = package.Receiver.LocalNumber,
                City = package.Receiver.City,
                PostCode = package.Receiver.PostCode
            };
            Status = package.Status;
            Payment = package.Payment;
            Weight = package.Weight;
            Price = package.Price;
            ShipmentDate = package.ShipmentDate;
            DeliveryDate = package.DeliveryDate;
        }
    }
}
