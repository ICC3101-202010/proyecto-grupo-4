using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
    public class Teacher : Person
    {
        private string namet;
        private string gmailp;
        private string course;
        private string code;
        private string passw;
        
        public Teacher(string namet, string gmailp, string code, string course, string passw)
        {
            this.namet = namet;
            this.gmailp = gmailp;
            this.code = code;
            this.course = course;
            this.passw = passw;
        }
        public string Namet { get => namet; set => namet = value; }
        public string Gmailp { get => gmailp; set => gmailp = value; }
        public string Course { get => course; set => course = value; }
        public string Code { get => code; set => code = value; }
        public string Passw { get => passw; set => passw = value; }
        public Teacher() { }
        public void Import(MediaFile mediafile) { }
        public void Remove(MediaFile mediafile) { }
    }
}
