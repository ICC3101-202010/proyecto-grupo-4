using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Playlist : IOrderPlaylist
    {
        private int numberSongs;
        List<Song> songs = new List<Song>();
        public int ArtistSearch(List<string> artists)
        {
            int count  =  0;
            foreach (Song song in songs)
            {
                foreach (string artist in artists)
                {
                    if (song.Artist == artist)
                    {
                        count+=1;
                    }
                }
            }
            return count;
        }
        public int GenderSearch(List<string> genders)
        {
            int count = 0;
            foreach (Song song in songs)
            {
                foreach (string gender in genders)
                {
                    if (song.Gender == gender)
                    {
                        count += 1;
                    }
                }
            }
            return count;
        }

        public void Mixture (int seconds)
        {
            //FALTA
        }

        public void Add(Song song)
        {
            int counter = 0;
            foreach (Song s in songs)
            {
                if (song==s)
                {
                    counter +=  1;
                }
            }
            if (counter == 0) songs.Add(song);
            else
            {
                Console.WriteLine("La canción ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer ==  "Sí") songs.Add(song);
            }
        }
        
        public void Delete (Song song)
        {
            foreach (Song s in songs)
            {
                if (s == song)
                {
                    songs.Remove(song);
                }
            }
        }
        public void Next()
        {
            throw new NotImplementedException();
        }

        public void OrderAlphabet()        {

            List<string> names = new List<string>();
            List<Song> newSongs = new List<Song>();
            foreach (Song song in songs)
            {
                names.Add(song.Name);
            }
            names.Sort();

            foreach (Song song in songs)
            {
                foreach (string name in names)
                {
                    if (song.Name == name)
                    {
                        newSongs.Add(song);
                    }
                }
            }
            songs = newSongs;        }

        public void OrderByLength()
        {
              List<int> lenghts = new List<int>();
            List<Song> newSongs = new List<Song>();
            foreach (Song song in songs)
            {
                lenghts.Add(song.Length);
            }
            lenghts.Sort();

            foreach (Song song in songs)
            {
                foreach (int lenght in lenghts)
                {
                    if (song.Length == lenght)
                    {
                        newSongs.Add(song);
                    }
                }
            }
            songs = newSongs;
      }


        public void OrderPlaylist(MediaFile mediaFile, int posicion)
        {
            throw new NotImplementedException();
        }

        public void Previous()
        {
            throw new NotImplementedException();
        }

    }
}
