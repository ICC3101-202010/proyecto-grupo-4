using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Admin : Person
    {

        private int code;
        public void Import(MediaFile mediafile) { } 
        public void Remove(MediaFile mediafile) { }

        public Admin(int code) { this.code = code; }
        public int Code { get => code; set => code = value; }


    }
}