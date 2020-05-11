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
        private List<Karaoke> karaokes = new List<Karaoke>();

        private string name;

        public Artist(List<Karaoke> karaokes, List<Song> songs, List<Video> videos, string name)
        {
            this.songs = songs;
            this.videos = videos;
            this.name = name;
            this.karaokes = karaokes;
        }
        public Artist() { }

        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string Name { get => name; set => name = value; }



        public Artist ShowArtist()
        {
            int choice = 0;
            int choice2 = 0;
            if (karaokes.Count() != 0|| songs.Count!=0 || videos.Count!=0)
            {

                foreach (Song s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", songs.IndexOf(s) + 1, s.Name, s.Artist, s.Gender);
                }
                foreach (Video v in videos)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", videos.IndexOf(v) + 1, v.Name, v.Director, v.Gender);
                }
                foreach (Karaoke k in karaokes)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", karaokes.IndexOf(k) + 1, k.Name, k.Artist, k.Gender);
                }

                Console.WriteLine($"¿Desea agregar este artista o desea ver más opciones\nOpción 1: Agregar artista {name}\nOpción 2: Ver más artistas");

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
                Console.WriteLine("No se encontraron archivos dentro del artista");
                return null;
            }
        }
        
    }
}
