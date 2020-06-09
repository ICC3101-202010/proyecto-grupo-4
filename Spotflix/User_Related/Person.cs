using System;

namespace Spotflix.User_Related
{
    [Serializable]
    public abstract class Person
    {
        protected string name;
        protected string lastname;
        protected int age;
        protected string password;

        public string Password { get => password; set => password = value; }
        public string Name { get => name; set => name = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public int Age { get => age; set => age = value; }
    }
}
