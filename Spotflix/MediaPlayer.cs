using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;

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


        public void CreateRecommendedList()
        {
            Console.WriteLine("Metodo muy dificil pa pensarlo ahora\n");
        }

        public void Play(Song song)// Listo
        {
            System.Diagnostics.Process.Start(song.Route);
        }
        public void Play(Video video) //Listo
        {
            System.Diagnostics.Process.Start(video.Route);
            Thread.Sleep(video.Length);
        }
        public void Play(Series serie)
        {
            foreach (Video video in serie.Episodes)
            {
                System.Diagnostics.Process.Start(video.Route);
                Thread.Sleep(video.Length);
            }
        }//Listo
        public void Play(Playlist playlist)
        {
            foreach (Song song in playlist.Songs)
            {
                System.Diagnostics.Process.Start(song.Route);
                Thread.Sleep(song.Length);
            }
        }//Listo

        //Pendiente
        public void Stop(Song song) { }//Pendiente
        //Pendiente
        public void Stop(Video video) { }//Pendiente

        public void Pause(Song song) { }//Pendiente

        public void Pause(Video video) { }//Pendiente

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
                Console.WriteLine("No se encontraron playlists");
                return null;
            }
        }//Listo
        //Shows listos
        public int Search(string switcher)
        {
            int choice = 0;
            Console.WriteLine("Ingrese la busqueda del archivo a reproducir o -1 para salir\n");
            string filter = Console.ReadLine().ToLower();
            if (filter == "-1")
            {
                return -1;
            }
            switch (switcher)
            {
                case "1":
                    if (this.Videos.Count == 0)
                    {
                        Console.WriteLine("No se encontaron videos\n");
                        return -1;
                    }
                    List<Video> catchs = new List<Video>();
                    foreach (Video video in this.Videos)
                    {
                        if (video.Name.ToLower().Contains(filter) && (!(catchs.Contains(video))))
                        {
                            catchs.Add(video);
                        }
                        if (video.Gender.ToLower().Contains(filter) && (!(catchs.Contains(video))))
                        {
                            catchs.Add(video);
                        }
                        if (video.Studio.ToLower().Contains(filter) && (!(catchs.Contains(video))))
                        {
                            catchs.Add(video);
                        }
                        if (video.Director.ToLower().Contains(filter) && (!(catchs.Contains(video))))
                        {
                            catchs.Add(video);
                        }
                        foreach (string actor in video.Actors)
                        {
                            if (actor.ToLower().Contains(filter) && (!(catchs.Contains(video))))
                            {
                                catchs.Add(video);
                            }
                        }
                    }
                    if (catchs.Count() != 0)
                    {
                        foreach (Video video in catchs)
                        {
                            Console.WriteLine("{0}{1}\n", catchs.IndexOf(video) + 1, video.Name);
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
                                    Console.WriteLine("Ingrese un numero para seleccionar\n");
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
                case "2":
                    if (this.Songs.Count() == 0)
                    {
                        Console.WriteLine("No se encontaron canciones\n");
                        return -1;
                    }
                    List<Song> catchsSongs = new List<Song>();
                    foreach (Song song in this.Songs)
                    {
                        if (song.Name.ToLower().Contains(filter) && (!(catchsSongs.Contains(song))))
                        {
                            catchsSongs.Add(song);
                        }
                        if (song.Gender.ToLower().Contains(filter) && (!(catchsSongs.Contains(song))))
                        {
                            catchsSongs.Add(song);
                        }
                        if (song.Artist.ToLower().Contains(filter) && (!(catchsSongs.Contains(song))))
                        {
                            catchsSongs.Add(song);
                        }
                        if (song.Album.ToLower().Contains(filter) && (!(catchsSongs.Contains(song))))
                        {
                            catchsSongs.Add(song);
                        }

                    }
                    if (catchsSongs.Count() != 0)
                    {
                        foreach (Song song in catchsSongs)
                        {
                            Console.WriteLine("{0}{1}\n", catchsSongs.IndexOf(song) + 1, song.Name);
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
                                    Console.WriteLine("Ingrese un numero para seleccionar\n");
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
                                Console.WriteLine("Seleccione una cancion dentro del rango o ingrese -1 para salir\n");
                                choice = 0;
                            }
                        }
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;
                case "3":
                    if (this.Series.Count == 0)
                    {
                        Console.WriteLine("No se encontaron series\n");
                        return -1;
                    }
                    List<Series> catchsSeries = new List<Series>();
                    foreach (Series serie in this.Series)
                    {
                        if (serie.SerieName.ToLower().Contains(filter) && (!(catchsSeries.Contains(serie))))
                        {
                            catchsSeries.Add(serie);
                        }
                        foreach (Video video in serie.Episodes)
                        {
                            if (video.Name.ToLower().Contains(filter) && (!(catchsSeries.Contains(serie))))
                            {
                                catchsSeries.Add(serie);
                            }
                        }
                    }
                    if (catchsSeries.Count() != 0)
                    {
                        foreach (Series serie in catchsSeries)
                        {
                            Console.WriteLine("{0}{1}\n", catchsSeries.IndexOf(serie) + 1, serie.SerieName);
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
                                    Console.WriteLine("Ingrese un numero para seleccionar\n");
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
                case "4":
                    if (this.Playlists.Count == 0)
                    {
                        Console.WriteLine("No se encontaron playlists\n");
                        return -1;
                    }
                    List<Playlist> catchsPlaylists = new List<Playlist>();
                    foreach (Playlist playlist in this.Playlists)
                    {
                        if (playlist.PlaylistName.ToLower().Contains(filter) && (!(catchsPlaylists.Contains(playlist))))
                        {
                            catchsPlaylists.Add(playlist);
                        }
                        foreach (Song song in playlist.Songs)
                        {
                            if (song.Name.ToLower().Contains(filter) && (!(catchsPlaylists.Contains(playlist))))
                            {
                                catchsPlaylists.Add(playlist);
                            }
                        }
                    }
                    if (catchsPlaylists.Count() != 0)
                    {
                        foreach (Playlist playlist in catchsPlaylists)
                        {
                            Console.WriteLine("{0}{1}\n", catchsPlaylists.IndexOf(playlist) + 1, playlist.PlaylistName);
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
                                    Console.WriteLine("Ingrese un numero para seleccionar\n");
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
                                Console.WriteLine("Seleccione una playlist dentro del rango o ingrese -1 para salir\n");
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

        }//Listo
        public void CreatePlaylistS()
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
                        Playlists.Add(new Playlist(tempsongs, name));
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

        public void CreatePlaylistV()
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
                        Playlists.Add(new Playlist(tempvideo, name));
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

        public void Follow()//pendiente
        {
            throw new NotImplementedException();
        }
        public void Download(Song song)//listo
        {
            string destination = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            string source = song.Route;
            System.IO.File.Copy(source, destination, true);

        }
    }

}
