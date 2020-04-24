using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Album
    {
        private string artist;
        private int nofSongs;
        private List<Song> songs = new List<Song>();
        public Album(int nofSongs,string artist) 
        {
            this.nofSongs = nofSongs;
            this.artist = artist;
        }
        public int NofSongs { get => nofSongs; set => nofSongs = value; }
        public string Artist { get => artist; set => artist = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
    }
}
