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

        public Admin(int code) { this.code = code; }
        public int Code { get => code; set => code = value; }
        public void Import(Song song) 
        {
            foreach(Song i in MediaPlayer.Songs)
        } 
        public void Remove(MediaFile mediafile) 
        {

        }

    }
}