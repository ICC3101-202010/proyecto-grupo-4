using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Spotflix
{
    public static class MediaPlayer
    {
        private static List<Song> songs = new List<Song>();
        private static List<Video> videos = new List<Video>();
        private static List<Lesson> lessons = new List<Lesson>();
        private static List<Playlist> playlists = new List<Playlist>();
        private static List<Series> series = new List<Series>();

        public static void play(MediaFile mediaFile)
        {
            
        }
        public static void CreateRecommendedList()
        {
            Console.WriteLine("Metodo muy dificil pa pensarlo ahora\n");
        }

        public static void Play(Song song)
        {
            System.Diagnostics.Process.Start(song.Route);
        }
        public static void Play(Video video)
        {
            System.Diagnostics.Process.Start(video.Route);
        }

        //Pendiente
        public static void Stop(Song song)
        {
            foreach (Song song_T in songs)
            {
                if (song.MediaId == song_T.MediaId)
                {
                    Console.WriteLine("Este metodo para las canciones y las parte desde 0\n");
                }
            }
            
        }
        //Pendiente
        public static void Stop(Video video)
        {
            foreach (Video video_T in videos)
            {
                if (video.MediaId == video_T.MediaId)
                {
                    Console.WriteLine("Este metodo para los videos y las parte desde 0\n");
                }
            }
            
        }
        //Pendiente
        public static void Pause(Song song)
        {
            foreach (Song song_T in songs)
            {
                if (song.MediaId == song_T.MediaId)
                {
                    Console.WriteLine("Este metodo le pone pausa a las canciones\n");
                }
            }
        }
        //Pendiente
        public static void Pause(Video video)
        {
            foreach (Video video_T in videos)
            {
                if (video.MediaId == video_T.MediaId)
                {
                    Console.WriteLine("Este metodo le pone pausa a los videos\n");
                }
            }
        }



        public static MediaFile Search(List<string> filters, bool condition)
        {
            throw new NotImplementedException();
        }

        public static void CreatePlaylist(List<Song> songs)
        {
            throw new NotImplementedException();
        }

        public static void CreatePlaylist(List<Video> videos)
        {
            throw new NotImplementedException();
        }

        public static void AddToQueue(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public static void Qualify(int qualification)
        {
            throw new NotImplementedException();
        }

        public static double GetQualification()
        {
            throw new NotImplementedException();
        }

        public static object[] GetMetadata(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetPlataformInformation()
        {
            throw new NotImplementedException();
        }

        public static List<string> GetIntrinsicInformation()
        {
            throw new NotImplementedException();
        }

        public static void Follow()
        {
            throw new NotImplementedException();
        }
    }


    /*public int GenderSearch(List<string> genders)
    {
        int count = 0;
        foreach (Song song in Songs)
        {
            foreach (string gender in genders)
            {
                if (song.Gender == gender)
                {
                    count += 1;
                }
            }
        }
        Console.WriteLine($"Se han encontrado {count} canciones de ese género");
        return count;
    }
    public int ArtistSearch(List<string> artists)
    {
        int count = 0;
        foreach (Song song in Songs)
        {
            foreach (string artist in artists)
            {
                if (song.Artist == artist)
                {
                    count += 1;
                }
            }
        }
        Console.WriteLine($"Se han encontrado {count} canciones de ese artista");
        return count;
    }

    public Song Downnload(Song song) //Método no listo
    {
            
        //client.DownloadFile("http://example.com/file/song/a.mpeg", "a.mpeg");
        Console.WriteLine("Guardando canción");
        return song;
     }
    */

}
