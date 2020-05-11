using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spotflix
{
    [Serializable]
    public abstract class Person
    {
        protected string name;
        protected string lastname;
        protected int age;
        protected string country;
        protected string city;
        protected string street;
        protected string postalCode;
        protected string password;

        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Age { get => age; set => age = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string Street { get => street; set => street = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }


        protected virtual void AddImage() { }//Pendiente
    }
}