using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Playlist 
    {
        List<Song> songs = new List<Song>();
        List<Video> videos = new List<Video>();
        private string playlistName;


        public Playlist(List<Song> songs, string playlistName) 
        {
            this.songs = songs;
            this.playlistName = playlistName;
        }
        public Playlist(List<Video> videos,string playlistName)
        {
            this.playlistName = playlistName;
            this.videos = videos;
        }


        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string PlaylistName { get => playlistName; set => playlistName = value; }

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
    }
}
