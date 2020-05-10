using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Artist
    {
        private List<Song> songs = new List<Song>();
        private List<Video> videos = new List<Video>();
        private string name;

        public Artist(List<Song> songs, List<Video> videos,string name)
        {
            this.songs = songs;
            this.videos = videos;
            this.name = name;
        }

        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string Name { get => name; set => name = value; }
    }
}
