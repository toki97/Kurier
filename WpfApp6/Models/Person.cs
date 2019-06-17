using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp6.Models
{
    public class Person : BaseModel
    {
        private string name;
        private string surname;
        private string street;
        private string localNumber;
        private string city;
        private string postCode;

        public string Name
        {
            get => name;
            set => Set(ref name, value);
        }

        public string Surname
        {
            get => surname;
            set => Set(ref surname, value);
        }

        public string Street
        {
            get => street;
            set => Set(ref street, value);
        }
        public string LocalNumber
        {
            get => localNumber;
            set => Set(ref localNumber, value);
        }
        public string City
        {
            get => city;
            set => Set(ref city, value);
        }
        public string PostCode
        {
            get => postCode;
            set => Set(ref postCode, value);
        }

        public Person() { }

        public Person(Person person) {
            this.Name = string.Copy(person.Name);
            this.Surname = string.Copy(person.Surname);
            this.Street = string.Copy(person.Street);
            this.LocalNumber = string.Copy(person.LocalNumber);
            this.City = string.Copy(person.City);
            this.PostCode = string.Copy(person.PostCode);
        }
    }
}
