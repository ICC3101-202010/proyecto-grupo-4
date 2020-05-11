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

        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string Name { get => name; set => name = value; }



        public Song ShowArtistSong()
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
                Console.WriteLine("No se encontraron canciones");
                return null;
            }
        }
        public Video ShowArtistVideo()
        {
            int choice = 0;

            if (this.Videos.Count() != 0)
            {

                while (choice != -1)
                {
                    foreach (Video video in this.Videos)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Videos.IndexOf(video) + 1, video.Name);
                    }
                    try
                    {
                            return this.Videos[choice - 1];
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
                Console.WriteLine("No se encontraron videos");
                return null;
            }
        }
    }
}
