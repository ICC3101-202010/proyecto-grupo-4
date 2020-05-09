using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Teacher: Person
    {
        private string course;
        private int code;
        public Teacher(int code, string course,string name, string lastname, int age, string country, string city,string street,int postalCode, string password)
        {
            this.course = course;
            this.name = name;
            this.lastname = lastname;
            this.age = age;
            this.country = country;
            this.city = city;
            this.street = street;
            this.postalCode = postalCode;
            this.password = password;
            this.code = code;
        }
        public string Course { get => course; set => course = value; }
        public int Code { get => code; set => code = value; }
        public Teacher() { }
        public void Import(MediaFile mediafile) { }
        public void Remove(MediaFile mediafile) { }
    }
}
