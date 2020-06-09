using System;
using System.Collections.Generic;
using System.Linq;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Artist
    {
        private List<Song> songs = new List<Song>();
        private List<Video> videos = new List<Video>();
        private List<Karaoke> karaokes = new List<Karaoke>();
        private List<Serie> series = new List<Serie>();

        private string name;

        public Artist(List<Karaoke> karaokes, List<Song> songs, List<Video> videos, string name, List<Serie> series)
        {
            this.songs = songs;
            this.videos = videos;
            this.name = name;
            this.karaokes = karaokes;
            this.series = series; 
        }
        public Artist() { }

        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string Name { get => name; set => name = value; }
        public List<Serie> Series { get => series; set => series = value; }


    }
}
