using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spotflix
{
    public abstract class Person
    {
        private string name;
        private string lastname;
        private int age;
        private string country;
        private string city;
        private string street;
        private string postalCode;//Compuesto de ints        

        protected string Name { get => name; set => name = value; }
        protected string Lastname { get => lastname; set => lastname = value; }
        protected int Age { get => age; set => age = value; }
        protected string Country { get => country; set => country = value; }
        protected string City { get => city; set => city = value; }
        protected string Street { get => street; set => street = value; }
        protected string PostalCode { get => postalCode; set => postalCode = value; }


        protected virtual void AddImage() { }//Pendiente
    }
}