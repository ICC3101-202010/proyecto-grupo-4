using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
    public class Playlist 
    {
        List<Song> songs = new List<Song>();
        List<Video> videos = new List<Video>();
        private string playlistName;
        User userowner; 

        public Playlist(List<Song> songs, string playlistName, User user) 
        {
            this.userowner = user;
            this.songs = songs;
            this.playlistName = playlistName;
        }
        public Playlist(List<Video> videos, string playlistName, User user)
        {
            this.userowner = user;
            this.playlistName = playlistName;
            this.videos = videos;
        }
        public Playlist() { }


        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string PlaylistName { get => playlistName; set => playlistName = value; }
        public User Userowner { get => userowner; set => userowner = value; }

        //Este método lo vamos a hacer bien para la próxima entrega. Cuanto le queden seconds segundos a una, empiezo a reproducir la otra
        public void Mixture (int seconds, string mediaFile) 
        {
            if (mediaFile== "song")
            {
                Console.WriteLine($"Mezclando la canción {seconds} segundos");
            }
            else if (mediaFile =="video")
            {
                Console.WriteLine("Los videos no se pueden mezclar");
            }
        }

        
        public void OnOrderBy(object source,  OrderByEventArgs o)
        {
            if (o.Option == "Alphabet")
            {
                if (o.MediaFile == "song")
                {
                    if (o.PlayList.Songs.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.songs = o.PlayList.songs.OrderBy(song => song.Name).ToList();
                        }
                        else
                        {
                            this.songs = o.PlayList.songs.OrderByDescending(song => song.Name).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado canciones");
                }
                else if (o.MediaFile == "video")
                {
                    if (o.PlayList.Videos.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.videos = o.PlayList.videos.OrderBy(video => video.Name).ToList();
                        }
                        else
                        {
                            this.videos = o.PlayList.videos.OrderByDescending(video => video.Name).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado videos");
                }

            }
            else if (o.Option == "Date")
            {
                if (o.MediaFile == "song")
                {
                    if (o.PlayList.Songs.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.songs = o.PlayList.songs.OrderBy(song => song.Year).ToList();
                        }
                        else
                        {
                            this.songs = o.PlayList.songs.OrderByDescending(song => song.Year).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado canciones");
                }
                else if (o.MediaFile == "video")
                {
                    if (o.PlayList.Videos.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.videos = o.PlayList.videos.OrderBy(video => video.Year).ToList();
                        }
                        else
                        {
                            this.videos = o.PlayList.videos.OrderByDescending(video => video.Year).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado videos");

                }
            }
            else if (o.Option == "Length")
            {
                if (o.MediaFile == "song")
                {
                    if (o.PlayList.Songs.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.songs = o.PlayList.songs.OrderBy(song => song.Length).ToList();
                        }
                        else
                        {
                            this.songs = o.PlayList.songs.OrderByDescending(song => song.Length).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado canciones");
                }
                else if (o.MediaFile == "video")
                {
                    if (o.PlayList.Videos.Count != 0)
                    {
                        if (o.Up)
                        {
                            this.videos = o.PlayList.videos.OrderBy(video => video.Length).ToList();
                        }
                        else
                        {
                            this.videos = o.PlayList.videos.OrderByDescending(video => video.Length).ToList();
                        }
                    }
                    else Console.WriteLine("No se han encontrado videos");
                }
            } 
            else if (o.Option == "Qualification")
            {

            }
            if (o.MediaFile == "song")
            {
                if (o.PlayList.Songs.Count != 0)
                {
                    if (o.Up)
                    {
                        this.songs = o.PlayList.songs.OrderBy(song => song.Qualification).ToList();
                    }
                    else
                    {
                        this.songs = o.PlayList.songs.OrderByDescending(song => song.Qualification).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (o.MediaFile == "video")
            {
                if (o.PlayList.Videos.Count != 0)
                {
                    if (o.Up)
                    {
                        this.videos = o.PlayList.videos.OrderBy(video => video.Qualification).ToList();
                    }
                    else
                    {
                        this.videos = o.PlayList.videos.OrderByDescending(video => video.Qualification).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado videos");
            }

        }
        public Playlist ShowPlaylist()
        {
            int choice = 0;
            int choice2 = 0;
            if (songs.Count() != 0 || videos.Count!=0)
            {

                foreach (Song s in songs)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", songs.IndexOf(s) + 1, s.Name, s.Artist, s.Gender);
                }
                foreach (Video v in videos)
                {
                    Console.WriteLine("{0} {1} {2} {3}\n", videos.IndexOf(v) + 1, v.Name, v.Director, v.Gender);
                }

                Console.WriteLine($"¿Desea agregar esa playlist o desea ver más opciones\nOpción 1: Agregar playlist {playlistName}\nOpción 2: Ver más palylists");

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
                Console.WriteLine("No se encontraron canciones y videos en la playlist");
                return null;
            }
        }
    }
}
