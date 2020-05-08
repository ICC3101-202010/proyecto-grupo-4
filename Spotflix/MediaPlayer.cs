using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;

namespace Spotflix
{
    public class MediaPlayer
    {
        private List<Song> songs = new List<Song>();
        private List<Video> videos = new List<Video>();
        private List<Lesson> lessons = new List<Lesson>();
        private List<Playlist> playlists = new List<Playlist>();
        private List<Series> series = new List<Series>();
        private List<Teacher> Teachers = new List<Teacher>();

        public  List<Song> Songs { get => songs; set => songs = value; }
        public  List<Video> Videos { get => videos; set => videos = value; }
        public List<Teacher> Teachers1 { get => Teachers; set => Teachers = value; }

        //Creo el evento Add Song
        public delegate void AddSongHandler(object source, AddSongArgs args);
        public event AddSongHandler AddSong;

        protected virtual void OnAddSong(MediaFile mediaFile)
        {
            // Verifica si hay alguien suscrito al evento
            if (AddSong != null)
            {
                // Engatilla el evento
                AddSong(this, new AddSongArgs()  {Mediafile  = mediaFile  });
            }
        }

        public void AddSong()
        {
            // Pedimos todos los datos necesarios
            Console.Write("Bienvenido! Ingrese el artista de la canción: ");
            string artist = Console.ReadLine();
            Console.Write("Álbum: ");
            string album = Console.ReadLine();
            Console.Write("Explicit: ");
            bool expliciT = Convert.ToBoolean(Console.ReadLine());
            Console.Write("Nombre: ");
            string name = Console.ReadLine();
            Console.Write("Género: ");
            string gender = Console.ReadLine();
            Console.Write("Year: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Route: ");
            string route = Console.ReadLine();
            Console.WriteLine("¿Dese agregar imagen?\nOpcion 1: Si\nOpcion 2:No");
            string answer = Console.ReadLine();
            if (answer=="1"|| answer == "Si")
            {
                Console.WriteLine("Cargue la imagen");
                object image Console.ReadLine();
            }

 

        }




        /*
            // Intenta agregar el usuario a la bdd. Si retorna null, se registro correctamente,
            // sino, retorna un string de error, que es el que se muestra al usuario
            string result = Data.AddUser(new List<string>()
                {usr, email, psswd, verificationLink, Convert.ToString(DateTime.Now), number});
            if (result == null)
            {
                // Disparamos el evento
                OnRegistered(usr, psswd, verificationlink: verificationLink, email: email);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }

        */

        public  void CreateRecommendedList()
        {
            Console.WriteLine("Metodo muy dificil pa pensarlo ahora\n");
        }

        public  void Play(Song song)// Listo
        {
           System.Diagnostics.Process.Start(song.Route);
        }
        public  void Play(Video video) //Listo
        {
            System.Diagnostics.Process.Start(video.Route);
        }
        
        //Pendiente
        public  void Stop(Song song) { }//Pendiente
        //Pendiente
        public  void Stop(Video video) { }//Pendiente

        public void Pause(Song song) { }//Pendiente

        public void Pause(Video video) { }//Pendiente
     
        public MediaFile Search(string filter)
        {
            string switcher = "0";
            string stopper = "7";
            while (switcher!=stopper)
            {
                Console.WriteLine("Desea buscar por:\n\t(1)Videos\n\t(2)Canciones\n\t(3)Series\n\t(4)Playlist\n\t(5)salir de la busqueda\n");
                switcher = Console.ReadLine();
                string[] filters = null;
                try
                {
                    filters = filter.Split(' ');
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Formato de filtro no aceptado");
                    continue;
                }
                switch (switcher)
                {
                    case "1":
                        List<Video> catchs = new List<Video>();
                        foreach (string words in filters)
                        {
                            foreach (Video video in this.Videos)
                            {
                                if (video.Name==words&& (!(this.Videos.Contains(video))))
                                {
                                    catchs.Add(video);
                                }
                                if (video.Gender==words&& (!(this.Videos.Contains(video))))
                                {
                                    catchs.Add(video);
                                }
                                if (video.Studio==words&& (!(this.Videos.Contains(video))))
                                {
                                    catchs.Add(video);
                                }
                                if (video.Director == words && (!(this.Videos.Contains(video))))
                                {
                                    catchs.Add(video);
                                }
                                foreach (string actor in video.Actors)
                                {
                                    if (actor == words && (!(this.Videos.Contains(video))))
                                    {
                                        catchs.Add(video);
                                    }
                                }
                            }
                        }
                        if (catchs.Count() != 0)
                        {
                            foreach (Video video in catchs)
                            {
                                Console.WriteLine("{0}{1}\n",catchs.IndexOf(video), video.Name);
                            }
                        }
                        break;
                    case "2":
                        List<Song> catchsSongs = new List<Song>();
                        foreach (string words in filters)
                        {
                            foreach (Song song in this.Songs)
                            {
                                if (song.Name == words && (!(this.Songs.Contains(song))))
                                {
                                    catchsSongs.Add(song);
                                }
                                if (song.Gender == words && (!(this.Songs.Contains(song))))
                                {
                                    catchsSongs.Add(song);
                                }
                                if (song.Artist == words && (!(this.song.Contains(song))))
                                {
                                    catchsSongs.Add(song);
                                }
                                if (song.Album == words && (!(this.song.Contains(song))))
                                {
                                    catchsSongs.Add(song);
                                }

                            }
                        }
                        if (catchsSongs.Count() != 0)
                        {
                            foreach (Song song in catchs)
                            {
                                Console.WriteLine("{0}{1}\n", catchs.IndexOf(song), song.Name);
                            }
                        }
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
        
        public  void CreatePlaylist(List<Song> songs)
        {
            List<Song> tempsongs = new List<Song>();
            bool checker = true;
            foreach (Song song in this.Songs)
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
        }//Listo

        public  void CreatePlaylist(List<Video> videos)
        {
            List<Video> tempvideo = new List<Video>();
            bool checker = true;
            foreach (Video video in this.Videos)
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
        }//Listo

        public  void AddToQueue(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public  void Qualify(int qualification)
        {
            throw new NotImplementedException();
        }

        public  double GetQualification()
        {
            throw new NotImplementedException();
        }

        public  object[] GetMetadata(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public  List<string> GetPlataformInformation()
        {
            throw new NotImplementedException();
        }

        public  List<string> GetIntrinsicInformation()
        {
            throw new NotImplementedException();
        }

        public  void Follow()
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
