using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Teacher : Person
    {
        private string course;
        private string code;
        private string passw;
        public Teacher(string code, string course, string passw)
        {
            this.code = code;
            this.course = course;
            this.passw = passw;
        }
        public string Course { get => course; set => course = value; }
        public string Code { get => code; set => code = value; }
        public string Passw { get => passw; set => passw = value; }
        public Teacher() { }
        public void Import(MediaFile mediafile) { }
        public void Remove(MediaFile mediafile) { }
    }
}
