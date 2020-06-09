using System;
using System.Collections.Generic;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Album
    {
        private string name;
        private List<string> artists = new List<string>();
        private int numberSongs;
        private List<Song> songs = new List<Song>();

        public Album(string name, List<string> artists, int numberSongs, List<Song> songs)
        {
            this.name = name;
            this.artists = artists;
            this.numberSongs = numberSongs;
            this.songs = songs;
        }
        public Album() { }

        public string Name { get => name; set => name = value; }
        public List<string> Artists { get => artists; set => artists = value; }
        public int NumberSongs { get => numberSongs; set => numberSongs = value; }
        public List<Song> Songs { get => songs; set => songs = value; }

    }
}
