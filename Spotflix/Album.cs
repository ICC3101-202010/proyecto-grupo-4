using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
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

        public void OnOrderByA(object source, OrderByAEventArgs a)
        {
            if (a.Option == "Alphabet")
            {
                if (a.Album.Songs.Count != 0)
                {
                    if (a.Up)
                    {
                        this.songs = a.Album.songs.OrderBy(song => song.Name).ToList();
                    }
                    else
                    {
                        this.songs = a.Album.songs.OrderByDescending(song => song.Name).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");

            }
            else if (a.Option == "Date")
            {

                if (a.Album.Songs.Count != 0)
                {
                    if (a.Up)
                    {
                        this.songs = a.Album.songs.OrderBy(song => song.Year).ToList();
                    }
                    else
                    {
                        this.songs = a.Album.songs.OrderByDescending(song => song.Year).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (a.Option == "Length")
            {
                if (a.Album.Songs.Count != 0)
                {
                    if (a.Up)
                    {
                        this.songs = a.Album.songs.OrderBy(song => song.Length).ToList();
                    }
                    else
                    {
                        this.songs = a.Album.songs.OrderByDescending(song => song.Length).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }

            else if (a.Option == "Qualification")
            {
                if (a.Album.Songs.Count != 0)
                {
                    if (a.Up)
                    {
                        this.songs = a.Album.songs.OrderBy(song => song.Qualification).ToList();
                    }
                    else
                    {
                        this.songs = a.Album.songs.OrderByDescending(song => song.Qualification).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }    
        }
        public Song ShowAlbumSong()
        {
            int choice = 0;

            if (this.Songs.Count() != 0)
            {
                while (choice != -1)
                {
                    foreach (Song song in this.Songs)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Songs.IndexOf(song) + 1, song.Name);
                    }
                    try
                    {
                            return this.Songs[choice - 1];
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese -1 para salir\n");
                    }
                }
                return null;
            }
            else
            {
                Console.WriteLine("No se encontraron series");
                return null;
            }
        }
    }
}
