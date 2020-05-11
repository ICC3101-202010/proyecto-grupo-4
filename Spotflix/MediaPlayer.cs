using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using WMPLib;
using System.IO;
using System.Timers;
using System.Configuration;

namespace Spotflix
{
    public class MediaPlayer 
    {
        private List<Song> songs = new List<Song>();
        private List<Video> videos = new List<Video>();
        private List<Lesson> lessons = new List<Lesson>();
        private List<Playlist> playlists = new List<Playlist>();
        private List<Series> series = new List<Series>();
        private List<Artist> artists = new List<Artist>();
        private List<Karaoke> karaokes = new List<Karaoke>();
        private List<Album> albums = new List<Album>();
        WindowsMediaPlayer player;

        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public List<Lesson> Lessons { get => lessons; set => lessons = value; }
        public List<Playlist> Playlists { get => playlists; set => playlists = value; }
        public List<Series> Series { get => series; set => series = value; }
        public List<Artist> Artists { get => artists; set => artists = value; }
        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Album> Albums { get => albums; set => albums = value; }

        

        //Creo el evento AddVideoSerie
        public delegate void AddVideoSerieHandler(object source, VideoSerieEventArgs args);
        public event AddVideoSerieHandler AddVideoSerie;
        protected virtual void OnAddVideoSerie(Video video, Series serie, MediaPlayer mediaPlayer)
        {
            // Verifica si hay alguien suscrito al evento
            if (AddVideoSerie != null)
            {
                // Engatilla el evento
                AddVideoSerie(this, new VideoSerieEventArgs() { Video = video, Serie = serie, Mediaplayer = mediaPlayer });
            }
        }

        //Creo el evento DeleteVideoSerie
        public delegate void DeleteVideoSerieHandler(object source, VideoSerieEventArgs args);
        public event DeleteVideoSerieHandler DeleteVideoSerie;
        protected virtual void OnDeleteVideoSerie(Video video, Series serie, MediaPlayer mediaPlayer)
        {
            // Verifica si hay alguien suscrito al evento
            if (DeleteVideoSerie != null)
            {
                // Engatilla el evento
                DeleteVideoSerie(this, new VideoSerieEventArgs() { Video = video, Serie = serie, Mediaplayer = mediaPlayer });
            }
        }

        public void VideoSerieStarter(string option, string serieName, string videoName, MediaPlayer mediaPlayer)
        {
            Series serie = null;
            Video video = null;
            int count = 0;
            foreach (Series s in series)
            {
                foreach (Video v in s.Episodes)
                {
                    if (s.SerieName == serieName && v.Name == videoName)
                    {
                        count += 1;
                        serie = s;
                        video = v;

                    }
                }
            }
            if (count != 0 && option == "Add")
            {
                Console.WriteLine($"El video {videoName} ya existe en la serie {serieName}");
            }
            else if (count == 0 && option == "Add")
            {
                OnAddVideoSerie(video, serie, mediaPlayer);
            }

            else if (count != 0 && option == "Delete")
            {
                OnDeleteVideoSerie(video, serie, mediaPlayer);
            }
            else if (count == 0 && option == "Delete")
            {
                Console.WriteLine($"El video {videoName} no existe en la serie {serieName}");
            }
            else Console.WriteLine("No se reconoce esa opción");
        }



        //Creo el evento Add Song
        public delegate void AddSongHandler(object source, SongEventArgs args);
        public event AddSongHandler AddSong;
        protected virtual void OnAddSong(Song song, Playlist playList)
        {
            // Verifica si hay alguien suscrito al evento
            if (AddSong != null)
            {
                // Engatilla el evento
                AddSong(this, new SongEventArgs() { Song = song, PlayList = playList });
            }
        }

        //Creo el evento Delete Song
        public delegate void DeleteSongHandler(object source, SongEventArgs args);
        public event DeleteSongHandler DeleteSong;
        protected virtual void OnDeleteSong(Song song, Playlist playList)
        {
            // Verifica si hay alguien suscrito al evento
            if (DeleteSong != null)
            {
                // Engatilla el evento
                DeleteSong(this, new SongEventArgs() { Song = song, PlayList = playList });
            }
        }

        public void SongStarter(string name, string namePlayList, string what)
        {
            int counterp = 0;
            Playlist newPlaylist = null;
            foreach (Playlist playList in playlists)
            {
                if (namePlayList == playList.PlaylistName)
                {
                    counterp += 1;
                    newPlaylist = playList;
                }
            }
            Song newSong = null;

            int counter = 0;
            foreach (Song s in songs)
            {
                if (name == s.Name)
                {
                    counter += 1;
                    newSong = s;
                }
            }
            if (counter != 0 && counterp != 0)
            {
                if (what == "agregar")
                {
                    //Disparo el evento
                    OnAddSong(newSong, newPlaylist);
                }
                else if (what == "eliminar")
                {
                    OnDeleteSong(newSong, newPlaylist);
                }

            }
            else if (counter == 0)
            {
                Console.WriteLine("La canción ingresada no existe en la base de datos");
            }
            else if (counter != 0 && counterp == 0)
            {
                if (what == "agregar")
                {
                    Console.WriteLine("La PlayList no existe. ¿Desea crearla?\nOpción 1: Sí\nOpción 2: No");
                    string option = Console.ReadLine();
                    if (option == "1" || option == "Sí")
                    {
                        newPlaylist.PlaylistName = namePlayList;
                        playlists.Add(newPlaylist);
                        OnAddSong(newSong, newPlaylist);
                    }
                }
                else Console.WriteLine("No se ha podido eliminar la canción. La PlayList no existe");
            }
        }

        //Creo el evento Add Video
        public delegate void AddVideoHandler(object source, VideoEventArgs args);
        public event AddVideoHandler AddVideo;
        protected virtual void OnAddVideo(Video video, Playlist playList)
        {
            // Verifica si hay alguien suscrito al evento
            if (AddVideo != null)
            {
                // Engatilla el evento
                AddVideo(this, new VideoEventArgs() { Video = video, PlayList = playList });
            }
        }

        //Creo el evento Delete Video
        public delegate void DeleteVideoHandler(object source, VideoEventArgs args);
        public event DeleteVideoHandler DeleteVideo;
        protected virtual void OnDeleteVideo(Video video, Playlist playList)
        {
            // Verifica si hay alguien suscrito al evento
            if (DeleteVideo != null)
            {
                // Engatilla el evento
                DeleteVideo(this, new VideoEventArgs() { Video = video, PlayList = playList });
            }
        }

        public void VideoStarter(string name, string namePlayList, string what)
        {
            int counterp = 0;
            Playlist newPlaylist = null;
            foreach (Playlist playList in playlists)
            {
                if (namePlayList == playList.PlaylistName)
                {
                    counterp += 1;
                    newPlaylist = playList;
                }
            }
            Video newVideo = null;

            int counter = 0;
            foreach (Video s in videos)
            {
                if (name == s.Name)
                {
                    counter += 1;
                    newVideo = s;
                }
            }
            if (counter != 0 && counterp != 0)
            {
                if (what == "agregar")
                {
                    //Disparo el evento
                    OnAddVideo(newVideo, newPlaylist);
                }
                else if (what == "eliminar")
                {
                    OnDeleteVideo(newVideo, newPlaylist);
                }

            }
            else if (counter == 0)
            {
                Console.WriteLine("El video ingresado no existe en la base de datos");
            }
            else if (counter != 0 && counterp == 0)
            {
                if (what == "agregar")
                {
                    Console.WriteLine("La PlayList no existe. ¿Desea crearla?\nOpción 1: Sí\nOpción 2: No");
                    string option = Console.ReadLine();
                    if (option == "1" || option == "Sí")
                    {
                        newPlaylist.PlaylistName = namePlayList;
                        playlists.Add(newPlaylist);
                        OnAddVideo(newVideo, newPlaylist);
                    }
                }
                else Console.WriteLine("No se ha podido eliminar el video. La PlayList no existe");
            }
        }

        //Creo el evento OrderBy
        public delegate void OrderByHandler(object source, OrderByEventArgs args);
        public event OrderByHandler OrderBy;
        protected virtual void OnOrderBy(bool up, Playlist playList, string mediaFile, string option)
        {
            // Verifica si hay alguien suscrito al evento
            if (OrderBy != null)
            {
                // Engatilla el evento
                OrderBy(this, new OrderByEventArgs() { Up = up, PlayList = playList, MediaFile = mediaFile, Option = option });
            }
        }

        public void PlayListStarter(string mediaFile, string playListName, bool up, string option)
        {
            Playlist newPlayList = null;
            int count = 0;
            foreach (Playlist p in playlists)
            {

                if (p.PlaylistName == playListName)
                {
                    count += 1;
                    newPlayList = p;
                }
            }
            if (count != 0)
            {
                OnOrderBy(up, newPlayList, mediaFile, option);
            }
            else
            {
                Console.WriteLine("La PlayList no existe. ¿Desea crearla?\nOpción 1: Sí\nOpción 2: No");
                string option2 = Console.ReadLine();
                if (option2 == "1" || option2 == "Sí")
                {
                    newPlayList.PlaylistName = playListName;
                    playlists.Add(newPlayList);
                }
            }
        }

        //Creo el evento OrderByA
        public delegate void OrderByAHandler(object source, OrderByAEventArgs args);
        public event OrderByAHandler OrderByA;
        protected virtual void OnOrderByA(bool up, Album album, string option)
        {
            // Verifica si hay alguien suscrito al evento
            if (OrderByA != null)
            {
                // Engatilla el evento
                OrderByA(this, new OrderByAEventArgs() { Up = up, Album = album, Option = option });
            }
        }

        public void AlbumStarter(string albumName, bool up, string option)
        {
            Album newAlbum = null;
            int count = 0;
            foreach (Song a in songs)
            {

                if (a.Album == albumName)
                {
                    count += 1;
                    newAlbum.Songs.Add(a);
                }
            }
            if (count != 0)
            {
                OnOrderByA(up, newAlbum, option);
            }
            else
            {
                Console.WriteLine("El Album no existe.");
            }
        }


        public List<Song> CreateRecommendedListS(User user)
        {
            var random = new Random();
            List<Song> song = new List<Song>();
            if (user.FollowAlbums.Count!=0&& user.FollowArtist.Count != 0&& user.FollowPlaylist.Count != 0&&user.FollowSeries.Count != 0&&user.FollowUsers.Count != 0)
            {
                while (song.Count<15)
                {
                    int rand = random.Next(0, this.Songs.Count());
                    if (song.Contains(this.Songs[rand]))
                    {
                        continue;
                    }
                    else
                    {
                        song.Add(this.Songs[rand]);
                    }
                }
            }
            else
            {
                if (user.FollowAlbums.Count!=0)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int bigindex = random.Next(0, user.FollowAlbums.Count());
                        int smallindex = random.Next(0, user.FollowAlbums[bigindex].Songs.Count());
                        song.Add(user.FollowAlbums[bigindex].Songs[smallindex]);
                    }
                }
            }
            return song;
        }

        Stopwatch stopper = new Stopwatch();
        public void Play(Song song)// Listo
        {
            song.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(song.Route));
            player.URL = song.Route;
            player.controls.play();
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds!=song.Length.TotalSeconds&&bruteforce)
            {
                Console.WriteLine("(1)Pausar cancion\n(2)Detener cancion\nIngrese cualquier otro caracter para salir\n");
                string switcher=Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        player.controls.pause();
                        stopper.Stop();
                        Console.WriteLine("(1)Reaundar cancion\nIngrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            player.controls.stop();
                            stopper.Reset();
                            bruteforce = false;
                        }            
                        break;
                    case "2":
                        player.controls.stop();
                        stopper.Reset();
                        Console.WriteLine("(1)Empezar cancion nuevamente\nIngrese cualquier caracter para salir\n");
                        choice = Console.ReadLine();
                        if (choice=="1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            bruteforce = false;
                        }
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }
        }
        public void Play(Video video) //Listo
        {
            video.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Video\", Path.GetFileName(video.Route));
            player.URL = video.Route;
            player.controls.play();
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds != video.Length.TotalSeconds && bruteforce)
            {
                Console.WriteLine("(1)Pausar video\n(2)Detener video\nIngrese cualquier otro caracter para salir\n");
                string switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        player.controls.pause();
                        stopper.Stop();
                        Console.WriteLine("(1)Reaundar video\nIngrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            player.controls.stop();
                            stopper.Reset();
                            bruteforce = false;
                        }
                        break;
                    case "2":
                        player.controls.stop();
                        stopper.Reset();
                        Console.WriteLine("(1)Empezar video nuevamente\nIngrese cualquier caracter para salir\n");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            bruteforce = false;
                        }
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }

        }
        public void Play(Series serie)
        {
            if (serie.Episodes.Count()!=0)
            {
                for (int i = 0; i < serie.NofVideos; i++)
                {
                    serie.Episodes[i].Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Videos\", Path.GetFileName(serie.Episodes[i].Route));
                    player.URL = serie.Episodes[i].Route;
                    player.controls.play();
                    stopper.Start();
                    bool bruteforce = true;
                    while (stopper.Elapsed.TotalSeconds != serie.Episodes[i].Length.TotalSeconds && bruteforce)
                    {
                        Console.WriteLine("(1)Pausar video\n(2)Detener video\n(3)Siguiente video\n(4)Video anterior\nIngrese cualquier otro caracter para salir\n");
                        string switcher = Console.ReadLine();
                        Console.Clear();
                        switch (switcher)
                        {
                            case "1":
                                player.controls.pause();
                                stopper.Stop();
                                Console.WriteLine("(1)Reaundar cancion\nIngrese cualquier caracter para detener y salir\n");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    player.controls.stop();
                                    stopper.Reset();
                                    bruteforce = false;
                                }
                                break;
                            case "2":
                                player.controls.stop();
                                stopper.Reset();
                                Console.WriteLine("(1)Empezar cancion nuevamente\nIngrese cualquier caracter para salir\n");
                                choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    bruteforce = false;
                                }
                                break;
                            case "3":
                                i++;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            case "4":
                                i--;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            default:
                                bruteforce = false;
                                break;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Serie vacia, volviendo al menu...\n");
                Console.Clear();
            }
        }
        //Listo
        public void Play(Playlist playlist)
        {
            if (playlist.Videos.Count() != 0)
            {
                for (int i = 0; i < playlist.Videos.Count(); i++)
                {
                    playlist.Videos[i].Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Videos\", Path.GetFileName(playlist.Videos[i].Route));
                    player.URL = playlist.Videos[i].Route;
                    player.controls.play();
                    stopper.Start();
                    bool bruteforce = true;
                    while (stopper.Elapsed.TotalSeconds != playlist.Videos[i].Length.TotalSeconds && bruteforce)
                    {
                        Console.WriteLine("(1)Pausar video\n(2)Detener video\n(3)Siguiente video\n(4)Video anterior\nIngrese cualquier otro caracter para salir\n");
                        string switcher = Console.ReadLine();
                        Console.Clear();
                        switch (switcher)
                        {
                            case "1":
                                player.controls.pause();
                                stopper.Stop();
                                Console.WriteLine("(1)Reaundar video\nIngrese cualquier caracter para detener y salir\n");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    player.controls.stop();
                                    stopper.Reset();
                                    bruteforce = false;
                                }
                                break;
                            case "2":
                                player.controls.stop();
                                stopper.Reset();
                                Console.WriteLine("(1)Empezar video nuevamente\nIngrese cualquier caracter para salir\n");
                                choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    bruteforce = false;
                                }
                                break;
                            case "3":
                                i++;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            case "4":
                                i--;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            default:
                                bruteforce = false;
                                break;
                        }

                    }
                }
            }
            if (playlist.Songs.Count() != 0)
            {
                for (int i = 0; i < playlist.Songs.Count(); i++)
                {
                    playlist.Songs[i].Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(playlist.Songs[i].Route));
                    player.URL = playlist.Songs[i].Route;
                    player.controls.play();
                    stopper.Start();
                    bool bruteforce = true;
                    while (stopper.Elapsed.TotalSeconds != playlist.Songs[i].Length.TotalSeconds && bruteforce)
                    {
                        Console.WriteLine("(1)Pausar cancion\n(2)Detener cancion\n(3)Siguiente cancion\n(4)Cancionanterior\nIngrese cualquier otro caracter para salir\n");
                        string switcher = Console.ReadLine();
                        Console.Clear();
                        switch (switcher)
                        {
                            case "1":
                                player.controls.pause();
                                stopper.Stop();
                                Console.WriteLine("(1)Reaundar cancion\nIngrese cualquier caracter para detener y salir\n");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    player.controls.stop();
                                    stopper.Reset();
                                    bruteforce = false;
                                }
                                break;
                            case "2":
                                player.controls.stop();
                                stopper.Reset();
                                Console.WriteLine("(1)Empezar cancion nuevamente\nIngrese cualquier caracter para salir\n");
                                choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    bruteforce = false;
                                }
                                break;
                            case "3":
                                i++;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            case "4":
                                i--;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            default:
                                bruteforce = false;
                                break;
                        }

                    }
                }
            }
            if (playlist.Videos.Count() == 0 && playlist.Songs.Count() == 0)
            {
                Console.WriteLine("Playlist vacia, volviendo al menu...\n");
                Console.Clear();
            }
        }
        public void Play(Lesson lessons)
        {
            lessons.Lessons.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Videos\", Path.GetFileName(lessons.Lessons.Route));
            player.URL = lessons.Lessons.Route;
            player.controls.play();
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds != lessons.Lessons.Length.TotalSeconds && bruteforce)
            {
                Console.WriteLine("(1)Pausar clasen(2)Detener clase\nIngrese cualquier otro caracter para salir\n");
                string switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        player.controls.pause();
                        stopper.Stop();
                        Console.WriteLine("(1)Reaundar clase\nIngrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            player.controls.stop();
                            stopper.Reset();
                            bruteforce = false;
                        }
                        break;
                    case "2":
                        player.controls.stop();
                        stopper.Reset();
                        Console.WriteLine("(1)Empezar clase nuevamente\nIngrese cualquier caracter para salir\n");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            bruteforce = false;
                        }
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }

            

        }
             //Listo
        public void Play(Album album)
        {
            if (album.Songs.Count() != 0)
            {
                for (int i = 0; i < album.Songs.Count(); i++)
                {
                    album.Songs[i].Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(album.Songs[i].Route));
                    player.URL = album.Songs[i].Route;
                    player.controls.play();
                    stopper.Start();
                    bool bruteforce = true;
                    while (stopper.Elapsed.TotalSeconds != album.Songs[i].Length.TotalSeconds && bruteforce)
                    {
                        Console.WriteLine("(1)Pausar cancion\n(2)Detener cancion\n(3)Siguiente cancion\n(4)Cancionanterior\nIngrese cualquier otro caracter para salir\n");
                        string switcher = Console.ReadLine();
                        Console.Clear();
                        switch (switcher)
                        {
                            case "1":
                                player.controls.pause();
                                stopper.Stop();
                                Console.WriteLine("(1)Reaundar cancion\nIngrese cualquier caracter para detener y salir\n");
                                string choice = Console.ReadLine();
                                Console.Clear();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    player.controls.stop();
                                    stopper.Reset();
                                    bruteforce = false;
                                }
                                break;
                            case "2":
                                player.controls.stop();
                                stopper.Reset();
                                Console.WriteLine("(1)Empezar cancion nuevamente\nIngrese cualquier caracter para salir\n");
                                choice = Console.ReadLine();
                                if (choice == "1")
                                {
                                    player.controls.play();
                                    stopper.Start();
                                }
                                else
                                {
                                    bruteforce = false;
                                }
                                break;
                            case "3":
                                i++;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            case "4":
                                i--;
                                bruteforce = false;
                                stopper.Reset();
                                player.controls.stop();
                                break;
                            default:
                                bruteforce = false;
                                break;
                        }

                    }
                }
            }
            else
            {
                Console.WriteLine("Album vacio, volviendo al menu...\n");
                Console.Clear();
            }
        }
        public void Play(Karaoke karaoke)
        {
            karaoke.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(karaoke.Route));
            player.URL = karaoke.Route;
            player.controls.play();
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds != karaoke.Length.TotalSeconds && bruteforce)
            {
                foreach (string l in karaoke.Lyrics)
                {
                    Console.WriteLine(l);
                }
                Console.WriteLine("(1)Pausar cancion\n(2)Detener cancion\nIngrese cualquier otro caracter para salir\n");
                string switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        player.controls.pause();
                        stopper.Stop();
                        Console.WriteLine("(1)Reaundar cancion\nIngrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            player.controls.stop();
                            stopper.Reset();
                            bruteforce = false;
                        }
                        break;
                    case "2":
                        player.controls.stop();
                        stopper.Reset();
                        Console.WriteLine("(1)Empezar cancion nuevamente\nIngrese cualquier caracter para salir\n");
                        choice = Console.ReadLine();
                        if (choice == "1")
                        {
                            player.controls.play();
                            stopper.Start();
                        }
                        else
                        {
                            bruteforce = false;
                        }
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }
        }
        


      

        public Video ShowVideos()
        {
            int choice = 0;

            if (this.Videos.Count() != 0)
            {
                Console.WriteLine("Seleccione un video:\n");
                while (choice != -1)
                {
                    foreach (Video video in this.Videos)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Videos.IndexOf(video) + 1, video.Name);
                    }
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice == -1)
                        {
                            return null;
                        }
                        try
                        {
                            return this.Videos[choice - 1];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ingrese un valor valido\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar o -1 para salir\n");
                    }
                }
                return null;
            }
            else
            {
                Console.WriteLine("No se encontraron videos");
                return null;
            }
        }//Listo
        public Song ShowSongs()
        {
            int choice = 0;

            if (Songs.Count() != 0)
            {
                Console.WriteLine("Seleccione una cancion:\n");
                while (choice != -1)
                {
                    foreach (Song song in this.Songs)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Songs.IndexOf(song) + 1, song.Name);
                    }
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice == -1)
                        {
                            return null;
                        }
                        try
                        {
                            return this.Songs[choice - 1];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ingrese un valor valido\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar o -1 para salir\n");
                    }
                }
                return null;
            }
            else
            {
                Console.WriteLine("No se encontraron canciones");
                return null;
            }
        }//Listo
        public Playlist ShowPlaylists()
        {
            int choice = 0;

            if (this.Playlists.Count() != 0)
            {
                Console.WriteLine("Seleccione una playlist:\n");
                while (choice != -1)
                {
                    foreach (Playlist playlist in this.Playlists)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Playlists.IndexOf(playlist) + 1, playlist.PlaylistName);
                    }
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice == -1)
                        {
                            return null;
                        }
                        try
                        {
                            return this.Playlists[choice - 1];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ingrese un valor valido\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar o -1 para salir\n");
                    }
                }
                return null;
            }
            else
            {
                Console.WriteLine("No se encontraron playlists");
                return null;
            }
        }//Listo
        public Series ShowSeries()
        {
            int choice = 0;

            if (this.Series.Count() != 0)
            {
                Console.WriteLine("Seleccione una serie:\n");
                while (choice != -1)
                {
                    foreach (Series series in this.Series)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.Series.IndexOf(series) + 1, series.SerieName);
                    }
                    try
                    {
                        choice = int.Parse(Console.ReadLine());
                        if (choice == -1)
                        {
                            return null;
                        }
                        try
                        {
                            return this.Series[choice - 1];
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            Console.WriteLine("Ingrese un valor valido\n");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar o -1 para salir\n");
                    }
                }
                return null;
            }
            else
            {
                Console.WriteLine("No se encontraron series");
                return null;
            }
        }//Listo


        public List<int> GenericSearch()
        {
            List<int> choice = new List<int>();
            int c1=0;
            int c2;

            Console.WriteLine("Ingrese la busqueda del archivo o -1 para salir\n");
            string filter = Console.ReadLine().ToLower();
            if (filter == "-1")
            {
                choice.Add(-1);
                return choice;
            }
            List<Video> catchsv = new List<Video>();
            List<Song> catchss = new List<Song>();
            List<Lesson> catchl = new List<Lesson>();
            List<Karaoke> catchk = new List<Karaoke>();
            List<Playlist> catchp = new List<Playlist>();
            List<Album> catchsa = new List<Album>();
            List<Series> catchse = new List<Series>();
            foreach (Video video in this.Videos)
            {
                if (video.Name.ToLower().Contains(filter) && (!(catchsv.Contains(video)))) catchsv.Add(video);
                if (video.Gender.ToLower().Contains(filter) && (!(catchsv.Contains(video)))) catchsv.Add(video);
                if (video.Studio.ToLower().Contains(filter) && (!(catchsv.Contains(video)))) catchsv.Add(video);
                if (video.Director.ToLower().Contains(filter) && (!(catchsv.Contains(video)))) catchsv.Add(video);
                foreach (string actor in video.Actors)
                {
                    if (actor.ToLower().Contains(filter) && (!(catchsv.Contains(video)))) catchsv.Add(video);
                }
            }
            foreach (Song song in this.Songs)
            {
                if (song.Name.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                if (song.Gender.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                if (song.Artist.ToLower().Contains(filter) && (!(catchss.Contains(song))))catchss.Add(song);
                if (song.Album.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
            }

            foreach (Series serie in this.Series)
            {
                if (serie.SerieName.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                foreach (Video video in serie.Episodes)
                {
                    if (video.Name.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                    if (video.Director.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                    if (video.Gender.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                    if (video.Studio.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                    foreach (string actor in video.Actors)
                    {
                        if (actor.ToLower().Contains(filter) && (!catchse.Contains(serie))) catchse.Add(serie);
                    }
                }
            }
            foreach (Playlist playlist in this.Playlists)
            {
                if (playlist.PlaylistName.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                foreach (Song song in playlist.Songs)
                {
                    if (song.Name.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                }
                foreach (Video video in playlist.Videos)
                {
                    if (video.Name.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                }
            }
            foreach (Album album in this.Albums)
            {
                if (album.Name.ToLower().Contains(filter) && (!(catchsa.Contains(album)))) catchsa.Add(album);
                foreach (Song song in album.Songs)
                {
                    if (song.Name.ToLower().Contains(filter) && (!(catchsa.Contains(album)))) catchsa.Add(album);
                }
            }

            foreach (Lesson lesson in this.lessons)
            {
                if (lesson.Teacher.Code.ToLower().Contains(filter) && (!(catchl.Contains(lesson)))) catchl.Add(lesson);
                if (lesson.Subject.ToLower().Contains(filter) && (!(catchl.Contains(lesson)))) catchl.Add(lesson);
                if (lesson.Name.ToLower().Contains(filter) && (!(catchl.Contains(lesson)))) catchl.Add(lesson);
            }

            foreach (Karaoke karaoke in this.karaokes)
            {
                if (karaoke.Gender.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                if (karaoke.Name.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                if (karaoke.Artist.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                if (karaoke.Album.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);

            }
            int n = 1;
            if (catchsv.Count() != 0)
            {
                foreach (Video video in catchsv)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}\n", n, catchsv.IndexOf(video) + 1, video.Name,video.Director,video.Gender);
                }
                n++;
            }
            if (catchss.Count() != 0)
            {
                foreach (Song song in catchss)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}\n", n,catchss.IndexOf(song) + 1, song.Name,song.Artist, song.Gender);
                }
                n++;
            }
            if (catchl.Count() != 0)
            {
                foreach (Lesson lesson in catchl)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}\n", n, catchl.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
                }
                n++;
            }
            if (catchk.Count() != 0)
            {
                foreach (Karaoke karaoke in catchk)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}\n", n,catchk.IndexOf(karaoke) + 1, karaoke.Name,karaoke.Artist,karaoke.Gender);
                }
                n++;
            }
            if (catchp.Count() != 0)
            {
                foreach (Playlist playlist in catchp)
                {
                    Console.WriteLine("{0}{1}{2}{3}{4}\n", n,catchp.IndexOf(playlist) + 1, playlist.PlaylistName, playlist.Userowner.Name, playlist.Userowner.Lastname);
                }
                n++;
            }
            if (catchsa.Count() != 0)
            {
                foreach (Album album in catchsa)
                {
                    Console.WriteLine("{0}{1}{2}{3}\n", n,catchsa.IndexOf(album) + 1, album.Name, album.NumberSongs);
                }
                n++;
            }
            if (catchse.Count() != 0)
            {
                foreach (Series serie in catchse)
                {
                    Console.WriteLine("{0}{1}{2}{3}\n", n,catchse.IndexOf(serie) + 1, serie.SerieName,serie.NofVideos);
                }
            }
            while (c1 != -1)
            {
                while (c1 == 0)
                {
                    try
                    {
                        c1 = int.Parse(Console.ReadLine());
                        choice.Add(c1);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar la categoría deseada\n");
                    }
                    
                }
                
                if (c1 == 1) //if lista[0]==1 usar videos
                {
                    foreach (Video video in catchsv)
                    {
                        Console.WriteLine("{0}{1}{2}{3}\n", catchsv.IndexOf(video) + 1, video.Name,video.Director,video.Gender);
                    }
                    Console.WriteLine("Ingrese el número de video que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 >catchsv.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.Videos.IndexOf(catchsv[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 2) //if lista[0]==2 usar canciones
                {
                    foreach (Song song in catchss)
                    {
                        Console.WriteLine("{0}{1}{2}{3}\n", catchss.IndexOf(song) + 1, song.Name,song.Artist, song.Gender);
                    }
                    Console.WriteLine("Ingrese el número de canción que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchss.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.Songs.IndexOf(catchss[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 3)  //if lista[0]==3 usar lessons
                {
                    foreach (Lesson lesson in catchl)
                    {
                        Console.WriteLine("{0}{1}{2}{3}\n", catchl.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
                    }
                    Console.WriteLine("Ingrese el número de clase que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchl.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.Lessons.IndexOf(catchl[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 4) //if lista[0]==4 usar karaokes
                {
                    foreach (Karaoke karaoke in catchk)
                    {
                        Console.WriteLine("{0}{1}{2}{3}\n", catchk.IndexOf(karaoke) + 1, karaoke.Name,karaoke.Artist,karaoke.Gender);
                    }
                    Console.WriteLine("Ingrese el número de karaoke que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchk.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.karaokes.IndexOf(catchk[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 5) //if lista[0]==5 usar playlist
                {
                    foreach (Playlist playlist in catchp)
                    {
                        Console.WriteLine("{0}{1}{2}{3}\n", catchp.IndexOf(playlist) + 1, playlist.PlaylistName,playlist.Userowner.Name,playlist.Userowner.Lastname);
                    }
                    Console.WriteLine("Ingrese el número de PlayList que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchp.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.playlists.IndexOf(catchp[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 6) //if lista[0]==6 usar albums
                {
                    foreach (Album album in catchsa)
                    {
                        Console.WriteLine("{0}{1}{2}\n", catchsa.IndexOf(album) + 1, album.Name,album.NumberSongs);
                    }
                    Console.WriteLine("Ingrese el número de álbum que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchsa.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.albums.IndexOf(catchsa[c2 - 1]));
                        return choice;
                    }
                }
                else if (c1 == 7) //if lista[0]==7 usar series
                {
                    foreach (Series serie in catchse)
                    {
                        Console.WriteLine("{0}{1}{2}\n", catchse.IndexOf(serie) + 1, serie.SerieName,serie.NofVideos);
                    }
                    Console.WriteLine("Ingrese el número de serie que desee");
                    c2 = int.Parse(Console.ReadLine());
                    if (c2 < 1 || c2 > catchse.Count())
                    {
                        choice.Add(-1);
                        Console.WriteLine("Input invalido, volviendo al menú");
                        return choice;
                    }
                    else
                    {
                        choice.Add(this.series.IndexOf(catchse[c2 - 1]));
                        return choice;
                    }
                }

                else //if lista.cointains(-1) salir
                {
                    choice.Add(-1);
                    Console.WriteLine("Input invalido, volviendo al menú");
                    return choice;
                }
            }
            Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
            Thread.Sleep(1000);
            choice.Add(-1);
            return choice;
        }


        public int Search(string switcher)
        {
            int choice = 0;
            string choice2;

            switch (switcher)
            {
                case "1": //Videos
                    if (this.Videos.Count == 0)
                    {
                        Console.WriteLine("No se encontaron videos\n");
                        return -1;
                    }
                    List<Video> catchs = new List<Video>();
                    foreach (Video video in this.Videos)
                    {
                        catchs.Add(video);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para el video");
                    Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Génerico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Video video in catchs)
                            {
                                if (!(video.Name.ToLower().Contains(filter))) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Video video in catchs)
                            {
                                if (!(video.Gender.ToLower().Contains(filter))) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Video video in catchs)
                            {

                                if (!(video.Director.ToLower().Contains(filter))) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Video video in catchs)
                            {
                                foreach (string actor in video.Actors)
                                {
                                    if (!(actor.ToLower().Contains(filter))) catchs.Remove(video);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "6")
                        {
                            foreach (Video video in catchs)
                            {
                                if (!(video.Studio.ToLower().Contains(filter))) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Director\n5: Actor\n6:Estudio");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchs.Count() != 0)
                    {
                        foreach (Video video in catchs)
                        {
                            Console.WriteLine("{0}{1}{2}{3}\n", catchs.IndexOf(video) + 1, video.Name, video.Director, video.Gender);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar video\n");
                                }
                            }
                            try
                            {
                                return this.Videos.IndexOf(catchs[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione un video dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "2": //Canciones
                    if (this.Songs.Count() == 0)
                    {
                        Console.WriteLine("No se encontaron canciones\n");
                        return -1;
                    }
                    List<Song> catchsSongs = new List<Song>();
                    foreach (Song song in this.Songs)
                    {
                        catchsSongs.Add(song);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para la canción");
                    Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5: Album\n6: Explicit\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Song song in catchsSongs) if (!(song.Name.ToLower().Contains(filter))) catchsSongs.Remove(song);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "3")
                        {
                            foreach (Song song in catchsSongs) if (!(song.Gender.ToLower().Contains(filter))) catchsSongs.Remove(song);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Song song in catchsSongs) if (!(song.Artist.ToLower().Contains(filter))) catchsSongs.Remove(song);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Song song in catchsSongs) if (!(song.Album.ToLower().Contains(filter))) catchsSongs.Remove(song);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "6")
                        {
                            bool ex;
                            if (filter.ToLower() == "true")
                            {
                                ex = true;
                                foreach (Song song in catchsSongs)
                                {
                                    if ((song.ExpliciT != ex)) catchsSongs.Remove(song);
                                }
                            }
                            else if (filter.ToLower() == "false")
                            {
                                ex = false;
                                foreach (Song song in catchsSongs)
                                {
                                    if ((song.ExpliciT != ex)) catchsSongs.Remove(song);
                                }
                            }
                            else Console.WriteLine("El filtro no es válido para esta categoría");
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre\n3: Género\n4: Artista\n5:Album\n6: Explicit");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }

                    }
                    if (catchsSongs.Count() != 0)
                    {
                        foreach (Song song in catchsSongs)
                        {
                            Console.WriteLine("{0}{1}{2}{3}\n", catchsSongs.IndexOf(song) + 1, song.Name, song.Artist, song.Gender);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar canción\n");
                                }
                            }
                            try
                            {
                                return this.Songs.IndexOf(catchsSongs[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione una canción dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;


                case "3": //Series
                    if (this.Series.Count == 0)
                    {
                        Console.WriteLine("No se encontaron series\n");
                        return -1;
                    }
                    List<Series> catchsSeries = new List<Series>();

                    foreach (Series serie in this.Series)
                    {
                        catchsSeries.Add(serie);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para la serie");
                    Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Series serie in catchsSeries)
                            {
                                if (!(serie.SerieName.ToLower().Contains(filter))) catchsSeries.Remove(serie);
                                Console.WriteLine("Ingrese otro filtro o -1 para salir");
                                Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                                choice2 = Console.ReadLine().ToLower();
                            }
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Series serie in catchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Name.ToLower().Contains(filter))) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Series serie in catchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Director.ToLower().Contains(filter))) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Series serie in catchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    foreach (string actor in video.Actors)
                                    {
                                        if (!(actor.ToLower().Contains(filter))) catchsSeries.Remove(serie);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "6")
                        {
                            foreach (Series serie in catchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Gender.ToLower().Contains(filter))) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre serie\n3: Nombre capítulo\n4: Director\n5: Actor\n6: Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsSeries.Count() != 0)
                    {
                        foreach (Series serie in catchsSeries)
                        {
                            Console.WriteLine("{0}{1}{2}\n", catchsSeries.IndexOf(serie) + 1, serie.SerieName, serie.NofVideos);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar serie\n");
                                }
                            }
                            try
                            {
                                return this.Series.IndexOf(catchsSeries[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice - 1;
                                }
                                Console.WriteLine("Seleccione una serie dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "4": //Playlist
                    if (this.Playlists.Count == 0)
                    {
                        Console.WriteLine("No se encontaron playlists\n");
                        return -1;
                    }
                    List<Playlist> catchsPlaylists = new List<Playlist>();

                    foreach (Playlist playlist in this.Playlists)
                    {
                        catchsPlaylists.Add(playlist);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para la playlist");
                    Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción o video contenido\n4: Artista (compositor/director/actor)\n5: Género contenido\n6: NickName del creador\n7: Canciones\n8: Videos\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                if (!(playlist.PlaylistName.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                Console.WriteLine("Ingrese otro filtro o -1 para salir");
                                Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                                choice2 = Console.ReadLine().ToLower();

                            }
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Name.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Name.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "4")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Artist.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Director.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                    foreach (string actor in video.Actors)
                                    {
                                        if (!(actor.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "5")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Gender.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Gender.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "6")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                if (!(playlist.Userowner.Nickname.ToLower().Contains(filter))) catchsPlaylists.Remove(playlist);
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "7")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                if (playlist.Songs.Count == 0 && playlist.Videos.Count != 0) catchsPlaylists.Remove(playlist);
                                else
                                {
                                    foreach (Video video in playlist.Videos)
                                    {
                                        playlist.Videos.Remove(video);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "8")
                        {
                            foreach (Playlist playlist in catchsPlaylists)
                            {
                                if ((playlist.Songs.Count != 0 && playlist.Videos.Count == 0)) catchsPlaylists.Remove(playlist);
                                else
                                {
                                    foreach (Song song in playlist.Songs)
                                    {
                                        playlist.Songs.Remove(song);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre playlist\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n6: NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }

                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }

                    if (catchsPlaylists.Count() != 0)
                    {
                        foreach (Playlist playlist in catchsPlaylists)
                        {
                            Console.WriteLine("{0}{1}{2}{3}\n", catchsPlaylists.IndexOf(playlist) + 1, playlist.PlaylistName, playlist.Userowner.Name, playlist.Userowner.Lastname);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar una Playlist\n");
                                }
                            }
                            try
                            {
                                return this.Playlists.IndexOf(catchsPlaylists[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione una Playlist dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }

                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "5": //Albums 
                    if (this.Albums.Count == 0)
                    {
                        Console.WriteLine("No se encontaron Albums\n");
                        return -1;
                    }
                    List<Album> catchsAlbum = new List<Album>();
                    foreach (Album album in this.Albums)
                    {
                        catchsAlbum.Add(album);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para el album");
                    Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenido\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {

                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Album album in catchsAlbum) if (!(album.Name.ToLower().Contains(filter))) catchsAlbum.Remove(album);

                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Album album in catchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Name.ToLower().Contains(filter))) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Album album in catchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Artist.ToLower().Contains(filter))) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Album album in catchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Gender.ToLower().Contains(filter))) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsAlbum.Count() != 0)
                    {
                        foreach (Album album in catchsAlbum)
                        {
                            Console.WriteLine("{0}{1}{2}\n", catchsAlbum.IndexOf(album) + 1, album.Name, album.NumberSongs);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar un álbum\n");
                                }
                            }
                            try
                            {
                                return this.Albums.IndexOf(catchsAlbum[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione un álbum dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "6": //Karaoke
                    if (this.Karaokes.Count == 0)
                    {
                        Console.WriteLine("No se encontaron Karaokes\n");
                        return -1;
                    }
                    List<Karaoke> catchsKaraoke = new List<Karaoke>();
                    foreach (Karaoke karaoke in this.Karaokes)
                    {
                        catchsKaraoke.Add(karaoke);
                    }
                    Console.WriteLine("Ingrese el criterio de filtro para el Karaoke");
                    Console.WriteLine("1: Genérico\n2: Nombre canción\n3: Artista canción\n4: Género canción\n5: Álbum canción\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();

                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Karaoke karaoke in catchsKaraoke) if (!(karaoke.Name.ToLower().Contains(filter))) catchsKaraoke.Remove(karaoke);

                        }
                        else if (choice2 == "3")
                        {
                            foreach (Karaoke karaoke in catchsKaraoke) if (!(karaoke.Artist.ToLower().Contains(filter))) catchsKaraoke.Remove(karaoke);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Karaoke karaoke in catchsKaraoke) if (!(karaoke.Gender.ToLower().Contains(filter))) catchsKaraoke.Remove(karaoke);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Karaoke karaoke in catchsKaraoke) if (!(karaoke.Album.ToLower().Contains(filter))) catchsKaraoke.Remove(karaoke);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre álbum\n3: Canción contenida\n4: Artista contenido\n5: Género contenidor");
                            choice2 = Console.ReadLine().ToLower();
                        }

                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsKaraoke.Count() != 0)
                    {
                        foreach (Karaoke karaoke in catchsKaraoke)
                        {
                            Console.WriteLine("{0}{1}{2}{3}\n", catchsKaraoke.IndexOf(karaoke) + 1, karaoke.Name, karaoke.Artist, karaoke.Gender);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar un karaoke\n");
                                }
                            }
                            try
                            {
                                return this.Karaokes.IndexOf(catchsKaraoke[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione un karaoke dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "7": //Lessons
                    if (this.Lessons.Count == 0)
                    {
                        Console.WriteLine("No se encontaron clases\n");
                        return -1;
                    }
                    List<Lesson> catchsLessons = new List<Lesson>();
                    foreach (Lesson lesson in this.Lessons)
                    {
                        catchsLessons.Add(lesson);
                    }

                    Console.WriteLine("Ingrese el criterio de filtro para el clases");
                    Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor\n-1 para salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1")
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1") //Genérico
                        {
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Lesson lesson in catchsLessons) if (!(lesson.Name.ToLower().Contains(filter))) catchsLessons.Remove(lesson);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Lesson lesson in catchsLessons) if (!(lesson.Subject.ToLower().Contains(filter))) catchsLessons.Remove(lesson);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Lesson lesson in catchsLessons) if (!(lesson.Course.ToLower().Contains(filter))) catchsLessons.Remove(lesson);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Lesson lesson in catchsLessons) if (!(lesson.Teacher.Code.ToLower().Contains(filter))) catchsLessons.Remove(lesson);
                            Console.WriteLine("Ingrese otro filtro o -1 para salir");
                            Console.WriteLine("1: Genérico\n2: Nombre clase\n3: Asignatura\n4: Curso (PK,K,1-8,I,II,II,IV)\n5: Código profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }

                    }
                    if (catchsLessons.Count() != 0)
                    {
                        foreach (Lesson lesson in catchsLessons)
                        {
                            Console.WriteLine("{0}{1}{2}{3}\n", catchsLessons.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
                        }
                        while (choice != -1)
                        {
                            while (choice == 0)
                            {
                                try
                                {
                                    choice = int.Parse(Console.ReadLine());
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("Ingrese un numero para seleccionar una clase\n");
                                }
                            }
                            try
                            {
                                return this.Lessons.IndexOf(catchsLessons[choice - 1]);
                            }
                            catch (ArgumentOutOfRangeException)
                            {
                                if (choice == -1)
                                {
                                    return choice;
                                }
                                Console.WriteLine("Seleccione una clase dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                default:
                    Console.WriteLine("Opcion invalida, volviendo al menu...");
                    Thread.Sleep(1000);
                    return -1;
            }

        }

        public void CreatePlaylistS(User user) //AGREGAR USUARIO
        {
            List<Song> tempsongs = new List<Song>();
            bool checker = true;
            foreach (Song song in this.Songs)
            {
                Console.WriteLine("{0}: {1}\n", songs.IndexOf(song) + 1, song.Name);
            }
            while (checker)
            {
                Console.WriteLine("Seleccione las canciones que desea anadir en el siguiente formato: 1,2,3,4,5\n Ingrese 0 para dejar de añadir canciones\n");
                string aux = Console.ReadLine();
                string[] words = aux.Split(',');
                if (aux == "0")
                {
                    checker = false;
                    if (tempsongs.Count() != 0)
                    {
                        Console.WriteLine("Que nombre tendra la playlist?\n");
                        string name = Console.ReadLine();
                        Playlists.Add(new Playlist(tempsongs, name,user));
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

        public void CreatePlaylistV(User user)
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
                        Playlists.Add(new Playlist(tempvideo, name,user));
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

        public void AddToQueue()//Pendeinte
        {
            throw new NotImplementedException();
        }

        public void Qualify(Song song)
        {
            Console.WriteLine("Ingrese la calificacion que desea darle a la cancion {0} entre 1 y 5\n",song.Name);
            try
            {
                int q= int.Parse(Console.ReadLine());
                if (q>=1 && q<=5)
                {
                    song.Qualification.Add(q);
                }
                else
                {
                    Console.WriteLine("Calificacion invalida, volviendo al menu...");
                    Thread.Sleep(1000);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Calificacion invalida, volviendo al menu...");
                Thread.Sleep(1000);
            }
        }
        public void Qualify(Video video)
        {
            Console.WriteLine("Ingrese la calificacion que desea darle al video {0} entre 1 y 5\n", video.Name);
            try
            {
                int q = int.Parse(Console.ReadLine());
                if (q >= 1 && q <= 5)
                {
                    video.Qualification.Add(q);
                }
                else
                {
                    Console.WriteLine("Calificacion invalida, volviendo al menu...");
                    Thread.Sleep(1000);
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Calificacion invalida, volviendo al menu...");
                Thread.Sleep(1000);
            }
        }

        public double GetQualification(Video video)//listo
        {
            return video.Qualification.Average();
        }
        public double GetQualification(Song song)//listo
        {
            return song.Qualification.Average();
        }

        public void GetMetadata(Song song)
        {
            Console.WriteLine("{0}\n", song.Name);
            Console.WriteLine("\t El artista de la cancion solicitada es: {0}\n", song.Artist);
            Console.WriteLine("\t El album de la cancion solicitada es: {0}\n", song.Album);
            Console.WriteLine("\t El genero de la cancion solicitada es: {0}\n", song.Gender);
            Console.WriteLine("\t El año de la cancion solicitada es: {0}\n", song.Year);
        }//Listo
        public void GetMetadata(Video video)
        {
            Console.WriteLine("{0}\n",video.Name);
            Console.WriteLine("\t Los actores en el video solicitado son:\n\t ");
            foreach (string actor in video.Actors)
            {
                Console.WriteLine("{0}\t",actor);
            }
            Console.WriteLine("\n\tEl director del video solicitado es:{0}\n",video.Director);
            Console.WriteLine("El estudio del video solicitado es:{0}\n", video.Studio);
            Console.WriteLine("\t El genero del video solicitado es: {0}\n", video.Gender);
            Console.WriteLine("\t El año del video solicitado es: {0}\n", video.Year);

        }//listo
        public void GetInstrinsicInformation(Video video)
        {
            Console.WriteLine("{0}\n", video.Name);
            Console.WriteLine("\tLa duracion del video solicitado es{0}\n", video.Length);
            Console.WriteLine("\tEl tamaño del video solictado es:{0}\n", video.FileSize);
        }//listo

        public void GetInstrinsicInformation(Song song)
        {
            Console.WriteLine("{0}\n",song.Name);
            Console.WriteLine("\tLa duracion de la cancion solicitada es{0}\n",song.Length);
            Console.WriteLine("\tEl tamaño de la cancion solictada es:{0}\n",song.FileSize);
        }//listo

        public void GetPlataformInformation(Video video)
        {
            Console.WriteLine("{0}\n", video.Name);
            Console.WriteLine("\tEl numero de reproducciones del video solicitado es:{0}\n", video.NumberOfReproductions);
            Console.WriteLine("\tLa cantidad de likes del video solicitado es:{0}\n",video.Likes);
            Console.WriteLine("\tLa calificacion que posee el video solicitado es:{0}\n",this.GetQualification(video));
        }//listo
        public void GetPlataformInformation(Song song)
        {
            Console.WriteLine("{0}\n", song.Name);
            Console.WriteLine("\tEl numero de reproducciones de la cancion solicitada es:{0}\n", song.NumberOfReproductions);
            Console.WriteLine("\tLa cantidad de likes de la cancion solicitada es:{0}\n", song.Likes);
            Console.WriteLine("\tLa calificacion que posee la cancion solicitada es:{0\n}", this.GetQualification(song));
        }//listo

        public void Follow(string key, List<User> users, User caller)//Falta Trabajo
        {
            bool succes = false;
            int choice;
            switch (key)
            {
                case "Users":
                    Console.WriteLine("Seleccione el usuario que quiere seguir");
                    foreach (User user in users)
                    {
                        Console.WriteLine("{0}{1}\n", users.IndexOf(user) + 1, user.Name);
                    }
                    succes = int.TryParse(Console.ReadLine(), out choice);
                    if (succes && users.Count() >= choice - 1)
                    {
                        if (caller.FollowUsers.Contains(users[choice - 1]))
                        {
                            Console.WriteLine("Ya esta siguiendo a este album, volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            caller.FollowUsers.Add(users[choice - 1]);
                            Console.WriteLine("Follow realizado correctamente");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Formato invalido, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;
                case "Albums":
                    Console.WriteLine("Seleccione el album que quiere seguir");
                    foreach (Album album in this.Albums)
                    {
                        Console.WriteLine("{0}{1}\n", this.Albums.IndexOf(album) + 1, album.Name);
                    }
                    succes = int.TryParse(Console.ReadLine(), out choice);
                    if (succes && this.Albums.Count() >= choice - 1)
                    {
                        if (caller.FollowAlbums.Contains(this.Albums[choice - 1]))
                        {
                            Console.WriteLine("Ya esta siguiendo a este album, volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            caller.FollowAlbums.Add(this.Albums[choice - 1]);
                            Console.WriteLine("Follow realizado correctamente");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Formato invalido, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;
                case "Playlists":
                    Console.WriteLine("Seleccione la playlist que quiere seguir");
                    foreach (Playlist playlist in this.Playlists)
                    {
                        Console.WriteLine("{0}{1}\n", this.Playlists.IndexOf(playlist) + 1, playlist.PlaylistName);
                    }
                    succes = int.TryParse(Console.ReadLine(), out choice);
                    if (succes && this.Albums.Count() >= choice - 1)
                    {
                        if (caller.FollowPlaylist.Contains(this.Playlists[choice - 1]))
                        {
                            Console.WriteLine("Ya esta siguiendo a esta playlist, volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            caller.FollowAlbums.Add(this.Albums[choice - 1]);
                            Console.WriteLine("Follow realizado correctamente");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }

                    }
                    else
                    {
                        Console.WriteLine("Formato invalido, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;
                case "Artists":
                    Console.WriteLine("Seleccione al artista que quiere seguir");
                    foreach (Artist artist in this.Artists)
                    {
                        Console.WriteLine("{0}{1}\n", this.Artists.IndexOf(artist) + 1, artist.Name);
                    }
                    succes = int.TryParse(Console.ReadLine(), out choice);
                    if (succes && this.Artists.Count() >= choice - 1)
                    {
                        if (caller.FollowArtist.Contains(this.Artists[choice - 1]))
                        {
                            Console.WriteLine("Ya esta siguiendo a este artista, volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            caller.FollowAlbums.Add(this.Albums[choice - 1]);
                            Console.WriteLine("Follow realizado correctamente");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        caller.FollowPlaylist.Add(this.Playlists[choice - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Formato invalido, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;
                case "Series":
                    Console.WriteLine("Seleccione la Serie que quiere seguir");
                    foreach (Series serie in this.Series)
                    {
                        Console.WriteLine("{0}{1}\n", this.Series.IndexOf(serie) + 1, serie.SerieName);
                    }
                    succes = int.TryParse(Console.ReadLine(), out choice);
                    if (succes && this.Series.Count() >= choice - 1)
                    {
                        if (caller.FollowSeries.Contains(this.Series[choice - 1]))
                        {
                            Console.WriteLine("Ya esta siguiendo a esta Serie, volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        else
                        {
                            caller.FollowAlbums.Add(this.Albums[choice - 1]);
                            Console.WriteLine("Follow realizado correctamente");
                            Thread.Sleep(1000);
                            Console.Clear();
                        }
                        caller.FollowPlaylist.Add(this.Playlists[choice - 1]);
                    }
                    else
                    {
                        Console.WriteLine("Formato invalido, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                    }
                    break;

                default:
                    Console.WriteLine("Formato invalido, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }
        public void Download(Song song)//listo
        {
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string source = song.Route;
            System.IO.File.Copy(source, destination, true);

            
        }
    }

}
