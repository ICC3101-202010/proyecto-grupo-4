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
        private int numberVideos;
        List<Video> videos = new List<Video>();
        private string playlistName;



        public Playlist(int numberSongs, List<Song> songs, string playlistName) 
        {
            this.numberSongs  =  numberSongs;
            this.songs = songs;
            this.playlistName = playlistName;
        }
        public Playlist(int numberVideos, List<Video> videos, string playlistName)
        {
            this.numberVideos = numberVideos;
            this.videos = videos;
            this.playlistName = playlistName;
        }


        public int NumberSongs { get => numberSongs; set => numberSongs = value; }
        public List<Song> Songs { get => songs; set => songs = value; }
        public int NumberVideos { get => numberVideos; set => numberVideos = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string PlaylistName { get => playlistName; set => playlistName = value; }

        public void Mixture (int seconds, string mediaFile) //Método no listo
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

        public void AddSong(Song song)
        {
            int counter = 0;
            foreach (Song s in songs)
            {
                if (song==s)
                {
                    counter +=  1;
                }
            }
            if (counter == 0)
            {
                songs.Add(song);
                Console.WriteLine($"Se ha agregado la canción {song.Name} a su Playlist {playlistName}");
            }
            else
            {
                Console.WriteLine("La canción ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    songs.Add(song);
                    Console.WriteLine($"Se ha agregado la canción {song.Name} a su Playlist {playlistName}");
                }
            }
        }
        
        public void DeleteSong (Song song)
        {
            foreach (Song s in songs)
            {
                if (s == song)
                {
                    songs.Remove(song);
                    Console.WriteLine($"Se ha eliminado la canción {song.Name} de su Playlist {playlistName}");
                }
            }
        }

        public void AddVideo(Video video)
        {
            int counter = 0;
            foreach (Video v in videos)
            {
                if (video == v)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                videos.Add(video);
                Console.WriteLine($"Se ha agregado el video {video.Name} a su Playlist {playlistName}");
            }
            else
            {
                Console.WriteLine("El video ya se encuentra en su playList. ¿Desea agregarlo de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    videos.Add(video);
                    Console.WriteLine($"Se ha agregado el video {video.Name} a su Playlist {playlistName}");
                }
            }
        }

        public void DeleteVideo(Video video)
        {
            foreach (Video v in videos)
            {
                if (v == video)
                {
                    videos.Remove(video);
                    Console.WriteLine($"Se ha eliminado el video {video.Name} de su Playlist {playlistName}");
                }
            }
        }

        public void OrderByAlphabet(bool up, string mediaFile)
        {
            if (mediaFile=="song")
            {
                if (songs.Count != 0)
                {
                    if (up)
                    {
                        this.songs = songs.OrderBy(song => song.Name).ToList();
                    }
                    else
                    {
                        this.songs = songs.OrderByDescending(song => song.Name).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (mediaFile=="video")
            {
                if (videos.Count != 0)
                {
                    if (up)
                    {
                        this.videos = videos.OrderBy(video => video.Name).ToList();
                    }
                    else
                    {
                        this.videos = videos.OrderByDescending(video => video.Name).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado videos");
            }
        }

        public void OrderByDate(bool up, string mediaFile)
        {
            if (mediaFile == "song")
            {
                if (songs.Count != 0)
                {
                    if (up)
                    {
                        this.songs = songs.OrderBy(song => song.Year).ToList();
                    }
                    else
                    {
                        this.songs = songs.OrderByDescending(song => song.Year).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (mediaFile =="video")
            {
                if (videos.Count != 0)
                {
                    if (up)
                    {
                        this.videos = videos.OrderBy(video => video.Year).ToList();
                    }
                    else
                    {
                        this.videos = videos.OrderByDescending(video => video.Year).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado videos");
            }
        }

        public void OrderByLength(bool up, string mediaFile)
        {
            if (mediaFile == "song")
            {
                if (songs.Count != 0)
                {
                    if (up)
                    {
                        this.songs = songs.OrderBy(song => song.Length).ToList();
                    }
                    else
                    {
                        this.songs = songs.OrderByDescending(song => song.Length).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (mediaFile == "video")
            {
                if (videos.Count != 0)
                {
                    if (up)
                    {
                        this.videos = videos.OrderBy(video => video.Length).ToList();
                    }
                    else
                    {
                        this.videos = videos.OrderByDescending(video => video.Length).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado videos");
            }
        }

        public void OrderByQualification(bool up, string mediaFile)
        {
            if (mediaFile == "song")
            {
                if (songs.Count != 0)
                {
                    if (up)
                    {
                        this.songs = songs.OrderBy(song => song.Qualification).ToList();
                    }
                    else
                    {
                        this.songs = songs.OrderByDescending(song => song.Qualification).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado canciones");
            }
            else if (mediaFile == "video")
            {
                if (videos.Count != 0)
                {
                    if (up)
                    {
                        this.videos = videos.OrderBy(video => video.Qualification).ToList();
                    }
                    else
                    {
                        this.videos = videos.OrderByDescending(video => video.Qualification).ToList();
                    }
                }
                else Console.WriteLine("No se han encontrado videos");
            }
        }
    }
}
