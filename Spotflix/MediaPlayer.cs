using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;

namespace Spotflix
{
    public static class MediaPlayer
    {
        private static List<Song> songs = new List<Song>();
        private static List<Video> videos = new List<Video>();
        private static List<Lesson> lessons = new List<Lesson>();
        private static List<Playlist> playlists = new List<Playlist>();
        private static List<Series> series = new List<Series>();

        public static List<Song> Songs { get => songs; set => songs = value; }

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
            foreach (Song song_T in Songs)
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
            foreach (Song song_T in Songs)
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
        /*
        public static MediaFile Search(string filter)
        {
            string switcher = "0";
            string stopper = "7";
            while (switcher!=stopper)
            {
                Console.WriteLine("Desea buscar por:\n\t(1)Videos\n\t(2)Canciones\n\t(3)Series\n\t(4)Playlist\n\t(5)salir de la busqueda\n");
                switcher = Console.ReadLine();
                string[] aux=filter.Split(' ');
                switch (switcher)
                {
                    case "1":
                        foreach (Video video in videos)
                        {

                        }
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;           
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;
                }
            }
            
        }
        */
        public static void CreatePlaylist(List<Song> songs)
        {
            List<Song> tempsongs = new List<Song>();
            bool checker = true;
            foreach (Song song in songs)
            {
                Console.WriteLine("{0}: {1}\n",songs.IndexOf(song)+1,song.Name);
            }
            while (checker)
            {
                Console.WriteLine("Seleccione las canciones que desea anadir en el siguiente formato: 1,2,3,4,5\n Ingrese 0 para dejar de añadir canciones\n");
                string aux = Console.ReadLine();
                string[] words = aux.Split(',');
                if (aux=="0")
                {
                    checker = false;
                    if (tempsongs.Count()!=0)
                    {
                        Console.WriteLine("Que nombre tendra la playlist?\n");
                        string name = Console.ReadLine();
                        playlists.Add(new Playlist(tempsongs, name));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No se selecciono ninguna cancion, no se creara la playlist\n");
                        break;
                    }
                }
                if (((aux.Length + 1) / 2) != words.Length)
                {
                    int index = 0;
                    foreach (String letter in words)
                    {
                        try
                        {
                            index=Int32.Parse(letter);
                            index++;
                            tempsongs.Add(songs[index]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato invalido");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Formato invalido");
                }
            }
        }

        public static void CreatePlaylist(List<Video> videos)
        {
            List<Video> tempvideo = new List<Video>();
            bool checker = true;
            foreach (Video video in videos)
            {
                Console.WriteLine("{0}: {1}\n", videos.IndexOf(video) + 1, video.Name);
            }
            while (checker)
            {
                Console.WriteLine("Seleccione los videos que desea anadir en el siguiente formato: 1,2,3,4,5\n Ingrese 0 para dejar de añadir videos\n");
                string aux = Console.ReadLine();
                string[] words = aux.Split(',');
                if (aux == "0")
                {
                    checker = false;
                    if (tempvideo.Count() != 0)
                    {
                        Console.WriteLine("Que nombre tendra la playlist?\n");
                        string name = Console.ReadLine();
                        playlists.Add(new Playlist(tempvideo, name));
                        break;
                    }
                    else
                    {
                        Console.WriteLine("No se selecciono ninguna cancion, no se creara la playlist\n");
                        break;
                    }
                }
                if (((aux.Length + 1) / 2) != words.Length)
                {
                    int index = 0;
                    foreach (String letter in words)
                    {
                        try
                        {
                            index = Int32.Parse(letter);
                            index++;
                            tempvideo.Add(videos[index]);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Formato invalido");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Formato invalido");
                }
            }
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
