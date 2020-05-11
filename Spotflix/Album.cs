using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
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
        public Album ShowAlbumsSong()
        {
            int choice = 0;
            int choice2 = 0;
            if (songs.Count() != 0)
            {

                foreach (Song s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", songs.IndexOf(s) + 1, s.Name, s.Artist, s.Gender);
                }

                Console.WriteLine($"¿Desea agregar ese álbum o desea ver más opciones\nOpción 1: Agregar album {name}\nOpción 2: Ver más albumes");

                while (choice2 == 0)
                {
                    try
                    {
                        choice2 = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar su decisión\n");
                    }
                }
                try
                {
                    if (choice2 == 1)
                    {
                        return this;
                    }

                    else return null;

                }
                catch (ArgumentOutOfRangeException)
                {
                    if (choice == -1)
                    {
                        return null;
                    }
                    Console.WriteLine("Seleccione una opción  dentro del rango o ingrese -1 para salir\n");
                    choice = 0;
                }
                return null;

            }
            else
            {
                Console.WriteLine("No se encontraron canciones");
                return null;
            }
        }
    }
}
