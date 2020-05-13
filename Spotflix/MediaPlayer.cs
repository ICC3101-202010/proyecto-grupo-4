﻿using System;
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
using System.Windows.Forms;

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

        public void VideoSerieStarter(string option, string serieName, string videoName, string videoDirector,  MediaPlayer mediaPlayer)
        {
            Series serie = new Series();
            Video video = new Video();
            int count = 0;
            int cont2 = 0;
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
                if (s.SerieName == serieName)
                {
                    cont2++;
                }
            }
            if (count != 0 && option == "add")
            {
                Console.WriteLine($"El video {videoName} ya existe en la serie {serieName}");
            }
            else if (count == 0 && option == "add")
            {
                int count4=0;
                foreach (Video v in videos)
                {
                    if (videoName==v.Name || videoDirector == v.Director)
                    {
                        video = v;
                        count4++;
                    }
                }
                if (count4 != 0) OnAddVideoSerie(video, serie, mediaPlayer);
                else Console.WriteLine("No se ha encontrado el video deseado");
            }

            else if (count != 0 && option == "delete")
            {
                OnDeleteVideoSerie(video, serie, mediaPlayer);
            }
            else if (count == 0 && option == "delete")
            {
                Console.WriteLine($"El video {videoName} no existe en la serie {serieName}");
            }
            else if (cont2==0 && option  =="add")
            {
                Console.WriteLine("La serie no existe, ¿desea crearla?\n Opción 1: Si\n Opción 2: No");
                string optionc = Console.ReadLine(); 
                if (optionc=="1" || optionc.ToLower()=="si")
                {
                    int counter = 0;
                    List<Video> vid = new List<Video>();
                    Console.WriteLine("Ingrese el nombre de la serie");
                    string name = Console.ReadLine();
                    Series s = new Series(0,vid,name);
                    series.Add(s);
                    foreach (Video v in videos)
                    {
                        if (v.Director == videoDirector && v.Name == videoName)
                        {
                            video = v;
                            counter++;
                        }
                    }
                    if (counter != 0) OnAddVideoSerie(video, s, mediaPlayer); 
                }
                else
                {
                    Console.WriteLine("Saliendo");
                }
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
        

        public void CreatePlaylistS(User user,string what)
        {
            int choice = 0;
            Console.WriteLine("Ingrese el nombre de su playlist\n");
            string namePlayList = Console.ReadLine();
            

            while (choice == 0)
            {
                Console.WriteLine("Ingrese el nombre de la canción\n");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese el artista de la canción\n");
                string artist = Console.ReadLine();
                int counterp = 0;
                Playlist newPlaylist = new Playlist();
                foreach (Playlist playList in user.MyPlaylist)
                {
                    if (namePlayList == playList.PlaylistName)
                    {
                        counterp += 1;
                        newPlaylist = playList;
                    }
                }
                Song newSong = new Song() ;

                int counter = 0;
                foreach (Song s in songs)
                {
                    if (name == s.Name && artist == s.Artist)
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
                            Console.WriteLine("Ingrese si su playlist es publica o privada\n(1) Publica\n(2) Privada");
                            string choice5 = Console.ReadLine();
                            string type;
                            if (choice5 == "1" || choice5.ToLower() == "publica")
                            {
                                if (user.MembershipType == "pago")
                                {
                                    type = "public";

                                }
                                else
                                {
                                    Console.WriteLine("Usted no es premium por lo tanto no puede añadir playlist públicas. Se añadirá su playlist como privada.");
                                    type = "private";
                                }
                            }
                            else if (choice5 == "2" || choice5.ToLower() == "privada")
                            {
                                type = "private";
                            }
                            else
                            {
                                Console.WriteLine("Error, opción inválida. Su playlist se guardará como privada");
                                type = "private";
                            }
                           
                            newPlaylist.PlaylistName = namePlayList;
                            newPlaylist.Publicornot = type;
                            playlists.Add(newPlaylist);
                            user.MyPlaylist.Add(newPlaylist);
                            OnAddSong(newSong, newPlaylist);
                        }
                        else Console.WriteLine("No se ha creado la playlist");

                    }
                    else Console.WriteLine("No se ha podido eliminar la canción. La PlayList no existe");
                }
                Console.WriteLine($"¿Desea agregar otra canción a su playlist {newPlaylist.PlaylistName}\n1: Si\n2: No");
                string ans = Console.ReadLine();
                if (ans == "1" || ans.ToLower() == "si")
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    break;
                }
            }
            Console.Clear();
            Thread.Sleep(1000);

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

        public void CreatePlaylistV(User user, string what)
        {
            int choice = 0;
            Console.WriteLine("Ingrese el nombre de su playlist");
            string namePlayList = Console.ReadLine();
            while (choice == 0)
            {
                Console.WriteLine("Ingrese el nombre del video");
                string name = Console.ReadLine();
                Console.WriteLine("Ingrese el director del video");
                string director = Console.ReadLine();
                int counterp = 0;
                Playlist newPlaylist = new Playlist();
                foreach (Playlist playList in user.MyPlaylist)
                {
                    if (namePlayList == playList.PlaylistName)
                    {
                        counterp += 1;
                        newPlaylist = playList;
                    }
                }
                Video newVideo = new Video();

                int counter = 0;
                foreach (Video v in videos)
                {
                    if (name == v.Name && director == v.Director)
                    {
                        counter += 1;
                        newVideo = v;
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

                            Console.WriteLine("Ingrese si su playlist es publica o privada\n(1) Publica\n(2) Privada");
                            string choice5 = Console.ReadLine();
                            string type;
                            if (choice5 == "1" || choice5.ToLower() == "publica")
                            {
                                if (user.MembershipType == "pago")
                                {
                                    type = "public";

                                }
                                else
                                {
                                    Console.WriteLine("Usted no es premium por lo tanto no puede añadir playlist públicas. Se añadirá su playlist como privada.");
                                    type = "private";
                                }
                            }
                            else if (choice5 == "2" || choice5.ToLower() == "privada")
                            {
                                type = "private";
                            }
                            else
                            {
                                Console.WriteLine("Error, opción inválida. Su playlist se guardará como privada");
                                type = "private";
                            }

                            newPlaylist.PlaylistName = namePlayList;
                            newPlaylist.Publicornot = type;
                            playlists.Add(newPlaylist);
                            user.MyPlaylist.Add(newPlaylist);
                            OnAddVideo(newVideo, newPlaylist);
                        }
                        else Console.WriteLine("No se ha creado la playlist");
                    }
                    else Console.WriteLine("No se ha podido eliminar el video. La PlayList no existe");
                }
                Console.WriteLine($"¿Desea agregar otro video a su playlist {newPlaylist.PlaylistName}\n1: Si\n2: No");
                string ans = Console.ReadLine();
                if (ans == "1" || ans.ToLower() == "si")
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    continue;
                }
                else
                {
                    Console.Clear();
                    Thread.Sleep(1000);
                    break;
                }
            }
            Console.Clear();
            Thread.Sleep(1000);
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

        public void PlayListStarter(string mediaFile, string playListName, bool up, string option,User user)
        {
            Playlist newPlayList = new Playlist();
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
                    user.MyPlaylist.Add(newPlayList);
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
            Album newAlbum = new Album();
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
            if (user.FollowAlbums.Count() == 0 && user.FollowArtist.Count() == 0 && user.FollowPlaylist.Count() == 0 && user.FollowUsers.Count() == 0)
            {
                while (song.Count() < 15)
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
                return song;
            }
            else
            {
                if (user.FollowAlbums.Count() != 0)
                {
                    if (user.FollowAlbums.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowAlbums.Count());
                            int smallindex = random.Next(0, user.FollowAlbums[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowAlbums[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowAlbums[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowAlbums.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowAlbums.Count());
                            int smallindex = random.Next(0, user.FollowAlbums[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowAlbums[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowAlbums[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                }
                if (user.FollowArtist.Count() != 0)
                {
                    if (user.FollowArtist.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowArtist.Count());
                            int smallindex = random.Next(0, user.FollowArtist[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowArtist[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowArtist[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowArtist.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowArtist.Count());
                            int smallindex = random.Next(0, user.FollowArtist[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowArtist[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowArtist[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                }

                if (user.FollowPlaylist.Count() != 0)
                {
                    if (user.FollowPlaylist.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowPlaylist.Count());
                            int smallindex = random.Next(0, user.FollowPlaylist[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowArtist[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowPlaylist[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowPlaylist.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowPlaylist.Count());
                            int smallindex = random.Next(0, user.FollowPlaylist[bigindex].Songs.Count());
                            if (!song.Contains(user.FollowArtist[bigindex].Songs[smallindex]))
                            {
                                song.Add(user.FollowPlaylist[bigindex].Songs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                }
                if (user.FollowUsers.Count() != 0)
                {
                    if (user.FollowUsers.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowUsers.Count());
                            int smallindex = random.Next(0, user.FollowUsers[bigindex].LikedSongs.Count());
                            if (!song.Contains(user.FollowUsers[bigindex].LikedSongs[smallindex]))
                            {
                                song.Add(user.FollowUsers[bigindex].LikedSongs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowUsers.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowUsers.Count());
                            int smallindex = random.Next(0, user.FollowUsers[bigindex].LikedSongs.Count());
                            if (!song.Contains(user.FollowUsers[bigindex].LikedSongs[smallindex]))
                            {
                                song.Add(user.FollowUsers[bigindex].LikedSongs[smallindex]);
                            }
                            else
                            {
                                i--;
                            }
                        }
                    }
                }
            }
            return song;
        }

        public List<Video> CreateRecommendedListV(User user)
        {
            var random = new Random();
            List<Video> video = new List<Video>();
            if (user.FollowArtist.Count() == 0 || user.FollowPlaylist.Count() == 0 || user.FollowUsers.Count()== 0)
            {
                while (video.Count() < this.videos.Count())
                {
                    int rand = random.Next(0, this.Songs.Count());
                    if (video.Contains(this.Videos[rand]))
                    {
                        continue;
                    }
                    else
                    {
                        video.Add(this.Videos[rand]);
                    }
                }
            }            
            else
            {

                if (user.FollowArtist.Count() != 0)
                {
                    if (user.FollowArtist.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowArtist.Count());
                            int smallindex = random.Next(0, user.FollowArtist[bigindex].Videos.Count());
                            if (!video.Contains(user.FollowArtist[bigindex].Videos[smallindex]))
                            video.Add(user.FollowArtist[bigindex].Videos[smallindex]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowArtist.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowArtist.Count());
                            int smallindex = random.Next(0, user.FollowArtist[bigindex].Songs.Count());
                            video.Add(user.FollowArtist[bigindex].Videos[smallindex]);

                        }
                    }
                }
                if (user.FollowPlaylist.Count != 0)
                {
                    if (user.FollowPlaylist.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowPlaylist.Count());
                            int smallindex = random.Next(0, user.FollowPlaylist[bigindex].Videos.Count());
                            videos.Add(user.FollowPlaylist[bigindex].Videos[smallindex]);
                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowPlaylist.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowPlaylist.Count());
                            int smallindex = random.Next(0, user.FollowPlaylist[bigindex].Videos.Count());
                            video.Add(user.FollowPlaylist[bigindex].Videos[smallindex]);

                        }
                    }
                }
                if (user.FollowUsers.Count() != 0)
                {
                    if (user.FollowUsers.Count() > 5)
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            int bigindex = random.Next(0, user.FollowUsers.Count());
                            int smallindex = random.Next(0, user.FollowUsers[bigindex].LikedVideos.Count());
                            video.Add(user.FollowUsers[bigindex].LikedVideos[smallindex]);

                        }
                    }
                    else
                    {
                        for (int i = 0; i < user.FollowUsers.Count(); i++)
                        {
                            int bigindex = random.Next(0, user.FollowUsers.Count());
                            int smallindex = random.Next(0, user.FollowUsers[bigindex].LikedVideos.Count());
                            video.Add(user.FollowUsers[bigindex].LikedVideos[smallindex]);

                        }
                    }
                }
            }
            return video;
        }
        Stopwatch stopper = new Stopwatch();
        System.Media.SoundPlayer SoundPlayer = new SoundPlayer();
        public void Play(Song song, User user)// Listo
        {
            song.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(song.Route));
            SoundPlayer.SoundLocation = song.Route;
            SoundPlayer.Play();
            song.NumberOfReproductions += 1;
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds != song.Length.TotalSeconds && bruteforce)
            {
                Console.WriteLine("(1)Detener cancion\n(2)Ponerle me gusta a la cancion\n()Ingrese cualquier otro caracter para salir\n");
                string switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        SoundPlayer.Stop();
                        stopper.Stop();
                        Console.WriteLine("(1)Volver a empezar cancion\n()Ingrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            SoundPlayer.Play();
                            stopper.Start();
                        }
                        else
                        {
                            stopper.Reset();
                            bruteforce = false;
                        }
                        break;
                    case "2":
                        user.AddToFavorite(song);
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }
        }
        public void Play(Video video, User user) //Listo
        {
            Console.WriteLine("ADVERTENCIA\n una vez incializado el video no podra detenerlo desde la consola, Desea continuar Y/N");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                video.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Videos\", Path.GetFileName(video.Route));
                System.Diagnostics.Process.Start(video.Route);
                video.NumberOfReproductions += 1;
                Console.WriteLine("Desea darle me gusta al video Y/N");
                string like = Console.ReadLine();
                if (like == "Y")
                {
                    user.AddToFavorite(video);
                }
            }
            else if (choice == "N")
            {
                Console.WriteLine("Selecciono no, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Opcion invalida, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();

            }
        }
        public void Play(Series serie, User user)
        {
            if (serie.Episodes.Count() != 0)
            {
                Console.WriteLine("ADVERTENCIA\n una vez incializado un video no podra detenerlo desde la consola, Desea continuar Y/N");
                string choice = Console.ReadLine();
                if (choice == "Y")
                {
                    for (int i = 0; i < serie.NofVideos; i++)
                    {
                        serie.Episodes[i].Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Video\", Path.GetFileName(serie.Episodes[i].Route));
                        System.Diagnostics.Process.Start(serie.Episodes[i].Route);
                        serie.Episodes[i].NumberOfReproductions += 1;
                        bool bruteforce = true;
                        while (stopper.Elapsed.TotalSeconds != serie.Episodes[i].Length.TotalSeconds && bruteforce)
                        {
                            Console.WriteLine("\n(1)Siguiente video\n(2)Video anterior\n(3)Darle me gusta al video\n()Ingrese cualquier otro caracter para salir\n");
                            string switcher = Console.ReadLine();
                            Console.Clear();
                            switch (switcher)
                            {
                                case "1":
                                    i++;
                                    bruteforce = false;
                                    stopper.Reset();
                                    break;
                                case "2":
                                    i--;
                                    bruteforce = false;
                                    stopper.Reset();
                                    break;
                                case "3":
                                    user.AddToFavorite(serie.Episodes[i]);
                                    break;
                                default:
                                    bruteforce = false;
                                    break;
                            }

                        }
                        if (i == serie.NofVideos-1)
                        {
                            i = 0;
                        }
                    }

                }
                if (choice == "N")
                {
                    Console.WriteLine("Selecciono no, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Opcion invalida, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    Console.Clear();

                }
            }
            else
            {
                Console.WriteLine("Serie vacia, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }

        public void Play(Playlist playlist, User user)
        {
           if (playlist.Videos.Count() > 0)
            {
                foreach (Video item in playlist.Videos)
                {
                    this.Play(item, user);
                    Console.WriteLine("Reproduciendo Siguiente video\n");
                }
            }
            else if (playlist.Songs.Count() > 0)
            {
                foreach (Song item in playlist.Songs)
                {
                    this.Play(item, user);
                    Console.WriteLine("Reproduciendo Siguiente cancion\n");
                }
            }
            else
            {
                Console.WriteLine("Playlist vacia, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
        public void Play(Lesson lessons, User user)
        {
            Console.WriteLine("ADVERTENCIA\n una vez incializado la clase no podra detenerlo desde la consola, Desea continuar Y/N");
            string choice = Console.ReadLine();
            if (choice == "Y")
            {
                lessons.Lessons.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"Videos\", Path.GetFileName(lessons.Lessons.Route));
                Console.WriteLine(lessons.Lessons.Route);
                System.Diagnostics.Process.Start(lessons.Lessons.Route);
                lessons.Lessons.NumberOfReproductions += 1;
                Console.WriteLine("Desea darle me gusta al video Y/N");
                string like = Console.ReadLine();
                if (like == "Y")
                {
                    user.AddToFavorite(lessons.Lessons);
                }
            }
            if (choice == "N")
            {
                Console.WriteLine("Selecciono no, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Opcion invalida, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();

            }
        }
        public void Play(Album album, User user)
        {
            if (album.Songs.Count()>0)
            {
                foreach (Song item in album.Songs)
                {
                    this.Play(item,user );
                    Console.WriteLine("Reproduciendo Siguiente cancion\n");
                }
            }
            else
            {
                Console.WriteLine("Album vacio, volviendo al menu...\n");
                Console.Clear();
            }
        }

        public void Play(Karaoke karaoke, User user)
        {
            karaoke.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(karaoke.Route));
            SoundPlayer.SoundLocation = karaoke.Route;
            SoundPlayer.Play();
            karaoke.NumberOfReproductions += 1;
            foreach (string l in karaoke.Lyrics)
            {
                Console.WriteLine(l);
            }
            Console.WriteLine("\n");
            stopper.Start();
            bool bruteforce = true;
            while (stopper.Elapsed.TotalSeconds != karaoke.Length.TotalSeconds && bruteforce)
            {
                Console.WriteLine("(1)Detener cancion\n(2)Darle me gusta a la cancion\n()Ingrese cualquier otro caracter para salir\n");
                string switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1":
                        SoundPlayer.Stop();
                        stopper.Stop();
                        Console.WriteLine("(1)Volver a empezar cancion\n()Ingrese cualquier caracter para detener y salir\n");
                        string choice = Console.ReadLine();
                        Console.Clear();
                        if (choice == "1")
                        {
                            SoundPlayer.Play();
                            stopper.Start();
                            foreach (string l in karaoke.Lyrics)
                            {
                                Console.WriteLine(l);
                            }
                            Console.WriteLine("\n");
                        }
                        else
                        {
                            stopper.Reset();
                            bruteforce = false;
                        }
                        break;
                    case "2":
                        user.AddToFavorite(karaoke);
                        break;
                    default:
                        bruteforce = false;
                        break;
                }

            }
        }
        public void Play(User user)
        {
            int choice = 0;
            bool checker = false;
            Console.WriteLine("Seleccione una cancion para comenzar la reproduccion en cola: \n");
            if (this.Songs.Count() != 0)
            {
                while (!checker)
                {
                    foreach (Song song in this.Songs)
                    {
                        Console.WriteLine("{0} {1}\n", this.Songs.IndexOf(song) + 1, song.Name);
                    }
                    checker = int.TryParse(Console.ReadLine(), out choice);
                    if (!checker)
                    {
                        Console.WriteLine("Ingrese un numero\n");
                    }
                    else if (choice > this.Songs.Count())
                    {
                        checker = false;
                        Console.WriteLine("Ingrese una opcion dentro del rango\n");
                    }
                    Thread.Sleep(1000);
                    Console.Clear();
                }
                this.AddToQueue(user, this.Songs[choice - 1]);
                bool bigbruteforce = true;
                bool fixer = true;
                while (fixer)
                {
                    foreach (Song song in user.Queque)
                    {
                        bool smallbruteforce = true;
                        if (!bigbruteforce)
                        {
                            Console.WriteLine("Volviendo al menu...");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }
                        stopper.Restart();
                        song.Route = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + @"\Songs\", Path.GetFileName(song.Route));
                        SoundPlayer.SoundLocation = song.Route;
                        SoundPlayer.Play();
                        song.NumberOfReproductions += 1;
                        stopper.Start();
                        while (stopper.Elapsed.TotalSeconds != song.Length.TotalSeconds && smallbruteforce)
                        {
                            Console.WriteLine("(1)Detener la cancion\n(2)Siguiente cancion en cola\n(3)Agregar cancion a la cola\n(4)Darle me gusta a la cancion'\n()Ingrese cualquier otro caracter para salir\n");
                            string submenu = Console.ReadLine();
                            string inside;
                            switch (submenu)
                            {
                                case "1":
                                    SoundPlayer.Stop();
                                    stopper.Stop();
                                    Console.WriteLine("(1)Volver a empezar cancion\n(2)Siguiente cancion en cola\n(3)Agregar cancion a la cola\n(4)Darle me gusta a la cancion\n()Ingrese cualquier caracter para salir\n");
                                    inside = Console.ReadLine();
                                    Console.Clear();
                                    if (inside == "1")
                                    {
                                        SoundPlayer.Play();
                                        stopper.Start();
                                    }
                                    if (inside == "2")
                                    {
                                        
                                        smallbruteforce = false;
                                        break;
                                    }
                                    if (inside == "3")
                                    {
                                        bool insidechecker = false;
                                        Console.WriteLine("Seleccione una cancion para añadir a la reproduccion en cola: \n");
                                        while (!insidechecker)
                                        {
                                            foreach (Song s in this.Songs)
                                            {
                                                Console.WriteLine("{0} {1}\n", this.Songs.IndexOf(s) + 1, s.Name);
                                            }
                                            insidechecker = int.TryParse(Console.ReadLine(), out choice);
                                            if (!insidechecker)
                                            {
                                                Console.WriteLine("Ingrese un numero\n");
                                            }
                                            else if (choice > this.Songs.Count())
                                            {
                                                insidechecker = false;
                                                Console.WriteLine("Ingrese una opcion dentro del rango\n");
                                            }
                                            Thread.Sleep(1000);
                                            Console.Clear();
                                        }
                                        this.AddToQueue(user, this.Songs[choice - 1]);
                                    }
                                    if (inside == "4")
                                    {
                                        user.AddToFavorite(song);
                                    }
                                    else
                                    {
                                        fixer = false;
                                        stopper.Reset();
                                        bigbruteforce = false;
                                    }
                                    break;
                                case "2":
                                    smallbruteforce = false;
                                    break;
                                case "3":
                                    bool biginsidechecker = false;
                                    Console.WriteLine("Seleccione una cancion para añadir a la reproduccion en cola: \n");
                                    while (!biginsidechecker)
                                    {
                                        foreach (Song s in this.Songs)
                                        {
                                            Console.WriteLine("{0} {1}\n", this.Songs.IndexOf(s) + 1, s.Name);
                                        }
                                        biginsidechecker = int.TryParse(Console.ReadLine(), out choice);
                                        if (!biginsidechecker)
                                        {
                                            Console.WriteLine("Ingrese un numero\n");
                                        }
                                        else if (choice > this.Songs.Count())
                                        {
                                            biginsidechecker = false;
                                            Console.WriteLine("Ingrese una opcion dentro del rango\n");
                                        }
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    }
                                    this.AddToQueue(user, this.Songs[choice - 1]);
                                    break;
                                case "4":
                                    user.AddToFavorite(song);
                                    break;
                                default:
                                    fixer = false;
                                    stopper.Reset();
                                    bigbruteforce = false;
                                    break;
                            }
                        }
                        break;

                    }
                }
                
            }
            else
            {
                Console.WriteLine("No existen canciones en el Database\nVolviendo al menu...");
                Thread.Sleep(1000);
                Console.Clear();
            }

            user.Queque.Clear();

        }
        public List<int> GenericSearch()
        {
            List<int> choice = new List<int>();
            int c1=0;
            int c2;

            Console.WriteLine("Ingrese la busqueda del archivo o (-1) para salir\n");
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
            if (this.Videos.Count()>0)
            {
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
            }
            if (this.Songs.Count() > 0)
            {
                foreach (Song song in this.Songs)
                {
                    if (song.Name.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                    if (song.Gender.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                    if (song.Artist.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                    if (song.Album.ToLower().Contains(filter) && (!(catchss.Contains(song)))) catchss.Add(song);
                }
            }

            if (this.Series.Count() > 0)
            {
                foreach (Series serie in this.Series)
                {
                    if (serie.SerieName.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                    if (serie.Episodes.Count() > 0)
                    {
                        foreach (Video video in serie.Episodes)
                        {
                            if (video.Name.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                            if (video.Director.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                            if (video.Gender.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                            if (video.Studio.ToLower().Contains(filter) && (!(catchse.Contains(serie)))) catchse.Add(serie);
                            if (video.Actors.Count()>0)
                            {
                                foreach (string actor in video.Actors)
                                {
                                    if (actor.ToLower().Contains(filter) && (!catchse.Contains(serie))) catchse.Add(serie);
                                }
                            }
                            
                        }
                    }
                    
                }
            }
            if (this.Playlists.Count() > 0)
            {
                foreach (Playlist playlist in this.Playlists)
                {
                    if (playlist.PlaylistName.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                    if (playlist.Songs.Count() > 0)
                    {
                        foreach (Song song in playlist.Songs)
                        {
                            if (song.Name.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                        }
                    }

                    if (playlist.Videos.Count() > 0)
                    {
                        foreach (Video video in playlist.Videos)
                        {
                            if (video.Name.ToLower().Contains(filter) && (!(catchp.Contains(playlist)))) catchp.Add(playlist);
                        }
                    }

                }
            }
            if (this.Albums.Count() > 0)
            {
                foreach (Album album in this.Albums)
                {
                    if (album.Name.ToLower().Contains(filter) && (!(catchsa.Contains(album)))) catchsa.Add(album);
                    if (album.Songs.Count() > 0)
                    {
                        foreach (Song song in album.Songs)
                        {
                            if (song.Name.ToLower().Contains(filter) && (!(catchsa.Contains(album)))) catchsa.Add(album);
                        }
                    }

                }
            }

            if (this.Lessons.Count() > 0)
            {
                foreach (Lesson lesson in this.Lessons)
                {
                    if (lesson.Subject.ToLower().Contains(filter) && (!(catchl.Contains(lesson)))) catchl.Add(lesson);
                    if (lesson.Name.ToLower().Contains(filter) && (!(catchl.Contains(lesson)))) catchl.Add(lesson);
                }
            }
            
            if (this.karaokes.Count() > 0)
            {
                foreach (Karaoke karaoke in this.karaokes)
                {
                    if (karaoke.Gender.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                    if (karaoke.Name.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                    if (karaoke.Artist.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);
                    if (karaoke.Album.ToLower().Contains(filter) && (!(catchk.Contains(karaoke)))) catchk.Add(karaoke);

                }
            }
            
            int n = 1;
            if (catchsv.Count() > 0)
            {
                Console.WriteLine("(1) Categoria Videos\n");
                foreach (Video video in catchsv)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}-{4}\n", n, catchsv.IndexOf(video) + 1, video.Name,video.Director,video.Gender);
                }
                n++;
            }
            if (catchss.Count() > 0)
            {
                Console.WriteLine("(2) Categoria Canciones\n");
                foreach (Song song in catchss)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}-{4}\n", n,catchss.IndexOf(song) + 1, song.Name,song.Artist, song.Gender);
                }
                n++;
            }
            if (catchl.Count() > 0)
            {
                Console.WriteLine("(3) Categoria Lessons\n");
                foreach (Lesson lesson in catchl)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}-{4}\n", n, catchl.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
                }
                n++;
            }
            if (catchk.Count() > 0)
            {
                Console.WriteLine("(4) Categoria Karaoke\n");
                foreach (Karaoke karaoke in catchk)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}-{4}\n", n,catchk.IndexOf(karaoke) + 1, karaoke.Name,karaoke.Artist,karaoke.Gender);
                }
                n++;
            }
            if (catchp.Count() > 0)
            {
                Console.WriteLine("(5) Categoria Playlist\n");
                foreach (Playlist playlist in catchp)
                {
                    Console.WriteLine("{0}: {1}-{2}\n", n,catchp.IndexOf(playlist) + 1, playlist.PlaylistName);
                }
                n++;
            }
            if (catchsa.Count() > 0)
            {
                Console.WriteLine("(6) Categoria Album\n");
                foreach (Album album in catchsa)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}\n", n,catchsa.IndexOf(album) + 1, album.Name, album.NumberSongs);
                }
                n++;
            }
            if (catchse.Count() > 0)
            {
                Console.WriteLine("(7) Categoria Serie\n");
                foreach (Series serie in catchse)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}\n", n,catchse.IndexOf(serie) + 1, serie.SerieName,serie.NofVideos);
                }
            }
            if (catchse.Count() == 0&& catchsa.Count()==0&&catchp.Count()==0&&catchk.Count()==0&&catchl.Count()==0&&catchss.Count()==0&&catchsv.Count()==0)
            {
                Console.WriteLine("No se han encontrado coincidencias, volviendo al menu...\n");
                Thread.Sleep(1000);
                Console.Clear();
                c1 = -1;

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
                    if (catchsv.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Video video in catchsv)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchsv.IndexOf(video) + 1, video.Name, video.Director, video.Gender);
                        }
                        Console.WriteLine("Ingrese el número de video que desee");
                        c2 = int.Parse(Console.ReadLine());
                        if (c2 < 1 || c2 > catchsv.Count())
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ningún video");
                        choice.Add(-1);
                        return choice;
                    }
                   
                }
                else if (c1 == 2) //if lista[0]==2 usar canciones
                {
                    if (catchss.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Song song in catchss)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchss.IndexOf(song) + 1, song.Name, song.Artist, song.Gender);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ninguna canción");
                        choice.Add(-1);
                        return choice;
                    }
                        
                }
                else if (c1 == 3)  //if lista[0]==3 usar lessons
                {
                    if (catchl.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Lesson lesson in catchl)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchl.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ninguna clase");
                        choice.Add(-1);
                        return choice;
                    }
                }
                else if (c1 == 4) //if lista[0]==4 usar karaokes
                {
                    if (catchk.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Karaoke karaoke in catchk)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchk.IndexOf(karaoke) + 1, karaoke.Name, karaoke.Artist, karaoke.Gender);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ningún karaoke");
                        choice.Add(-1);
                        return choice;
                    }                  
                }
                else if (c1 == 5) //if lista[0]==5 usar playlist
                {
                    if (catchp.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Playlist playlist in catchp)
                        {
                            Console.WriteLine("{0}: {1}\n", catchp.IndexOf(playlist) + 1, playlist.PlaylistName);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ninguna playlist");
                        choice.Add(-1);
                        return choice;
                    }                    
                }
                else if (c1 == 6) //if lista[0]==6 usar albums
                {
                    if (catchsa.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Album album in catchsa)
                        {
                            Console.WriteLine("{0}: {1}-{2}\n", catchsa.IndexOf(album) + 1, album.Name, album.NumberSongs);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ningún álbum");
                        choice.Add(-1);
                        return choice;
                    }
                    
                }
                else if (c1 == 7) //if lista[0]==7 usar series
                {
                    if (catchse.Count() > 0)
                    {
                        Console.WriteLine("A continuación se muestran las opciones disponible");
                        foreach (Series serie in catchse)
                        {
                            Console.WriteLine("{0}: {1}-{2}\n", catchse.IndexOf(serie) + 1, serie.SerieName, serie.NofVideos);
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
                    else
                    {
                        Console.WriteLine("No se ha encontrado ninguna serie");
                        choice.Add(-1);
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
            Thread.Sleep(1000);
            choice.Add(-1);
            return choice;
        }


        public int Search(string switcher)
        {
            int choice = 0;
            string choice2;
            bool baduser = false;
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
                    Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    List<Video> copycatchs = new List<Video>(catchs);
                    while (choice2 != "-1" && catchs.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Video video in copycatchs)
                            {
                                if (!(video.Name.ToLower().Contains(filter)) && catchs.Contains(video)) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Video video in copycatchs)
                            {
                                if (!(video.Gender.ToLower().Contains(filter)) && catchs.Contains(video)) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Video video in copycatchs)
                            {
                                if (!(video.Director.ToLower().Contains(filter)) && catchs.Contains(video)) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {

                            foreach (Video video in copycatchs)
                            {
                                int count = 0;
                                foreach (string actor in video.Actors)
                                {
                                    if ((actor.ToLower().Contains(filter))) count++;
                                }
                                if (count == 0 && catchs.Contains(video)) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Video video in copycatchs)
                            {
                                if (!(video.Studio.ToLower().Contains(filter)) && catchs.Contains(video)) catchs.Remove(video);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "6")
                        {
                            //filtro sería la resolución
                            string symbol;
                            Console.WriteLine("Ingrese su opción:\n(1) Mayor al filtro\n(2) Menor al filtro\n(3) Igual al filtro");
                            symbol = Console.ReadLine();
                            int n;
                            bool ool;
                            ool = int.TryParse(filter, out n);
                            if (ool == true)
                            {
                                foreach (Video video in copycatchs)
                                {
                                    if (symbol == "1" || symbol.ToLower() == "mayor")
                                    {
                                        if (video.Dimension <= n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else if (symbol == "2" || symbol.ToLower() == "menor")
                                    {
                                        if (video.Dimension >= n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else if (symbol == "3" || symbol.ToLower() == "igual")
                                    {
                                        if (video.Dimension != n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error. Esa opción no existe.");
                                    }
                                }
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }
                            else
                            {
                                Console.WriteLine("ERROR. El filtro ingresado debe ser un número");
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }

                        }
                        else if (choice2 == "7")
                        {
                            //filtro seria la nota
                            string symbol;
                            Console.WriteLine("Ingrese su opción:\n(1) Mayor al filtro\n(2) Menor al filtro\n(3) Igual al filtro");
                            symbol = Console.ReadLine();
                            int n;
                            bool ool;
                            ool = int.TryParse(filter, out n);
                            if (ool == true)
                            {
                                foreach (Video video in copycatchs)
                                {
                                    if (symbol == "1" || symbol.ToLower() == "mayor")
                                    {
                                        if (GetQualification(video) <= n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else if (symbol == "2" || symbol.ToLower() == "menor")
                                    {
                                        if (GetQualification(video) >= n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else if (symbol == "3" || symbol.ToLower() == "igual")
                                    {
                                        if (GetQualification(video) != n && catchs.Contains(video)) catchs.Remove(video);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error. Esa opción no existe.");
                                    }
                                }
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }
                            else
                            {
                                Console.WriteLine("ERROR. El filtro ingresado debe ser un número");
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Director\n(4) Actor\n(5) Estudio\n(6) Resolución\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchs.Count() > 0)
                    {
                        Console.WriteLine("Seleccione el video deseado");
                        foreach (Video video in catchs)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchs.IndexOf(video) + 1, video.Name, video.Director, video.Gender);
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
                                    Console.WriteLine("Ingrese un número para seleccionar video\n");
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
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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
                    List<Song> copycatchsSongs = new List<Song>(catchsSongs);
                    Console.WriteLine("Ingrese el criterio de filtro para la canción");
                    Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1" && catchsSongs.Count > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Song song in copycatchsSongs)
                            {
                                if (!(song.Name.ToLower().Contains(filter)) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "2")
                        {
                            foreach (Song song in copycatchsSongs)
                            {
                                if (!(song.Gender.ToLower().Contains(filter)) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Song song in catchsSongs)
                            {
                                if (!(song.Artist.ToLower().Contains(filter)) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Song song in copycatchsSongs)
                            {
                                if (!(song.Album.ToLower().Contains(filter)) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            bool ex;
                            if (filter.ToLower() == "true")
                            {
                                ex = true;
                                foreach (Song song in copycatchsSongs)
                                {
                                    if ((song.ExpliciT != ex) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                }
                            }
                            else if (filter.ToLower() == "false")
                            {
                                ex = false;
                                foreach (Song song in copycatchsSongs)
                                {
                                    if ((song.ExpliciT != ex) && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                }
                            }
                            else Console.WriteLine("El filtro no es válido para esta categoría");
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "6")
                        {
                            //filtro sería la resolución
                            string symbol;
                            Console.WriteLine("Ingrese su opción\n(1) Mayor al filtro\n(2) Menor al filtro\n(3) Igual al filtro");
                            symbol = Console.ReadLine();
                            int n;
                            bool ool;
                            ool = int.TryParse(filter, out n);
                            if (ool == true)
                            {
                                foreach (Song song in copycatchsSongs)
                                {
                                    if (symbol == "1" || symbol.ToLower() == "mayor")
                                    {
                                        if (song.Dimension <= n && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                    }
                                    else if (symbol == "2" || symbol.ToLower() == "menor")
                                    {
                                        if (song.Dimension >= n && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                    }
                                    else if (symbol == "3" || symbol.ToLower() == "igual")
                                    {
                                        if (song.Dimension != n && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error. Esa opción no existe.");
                                    }
                                }
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }
                            else
                            {
                                Console.WriteLine("ERROR. El filtro ingresado debe ser un número");
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }

                        }
                        else if (choice2 == "7")
                        {
                            //filtro sería la nota
                            string symbol;
                            Console.WriteLine("Ingrese su opción\n(1) Mayor al filtro\n(2) Menor al filtro\n(3) Igual al filtro");
                            symbol = Console.ReadLine();
                            int n;
                            bool ool;
                            ool = int.TryParse(filter, out n);
                            if (ool == true)
                            {
                                foreach (Song song in copycatchsSongs)
                                {
                                    if (symbol == "1" || symbol.ToLower() == "mayor")
                                    {
                                        if (GetQualification(song) <= n && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                    }
                                    else if (symbol == "2" || symbol.ToLower() == "menor")
                                    {
                                        if (GetQualification(song) >= n && catchsSongs.Contains(song)) catchsSongs.Remove(song); ;
                                    }
                                    else if (symbol == "3" || symbol.ToLower() == "igual")
                                    {
                                        if (GetQualification(song) != n && catchsSongs.Contains(song)) catchsSongs.Remove(song);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error. Esa opción no existe.");
                                    }
                                }
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }
                            else
                            {
                                Console.WriteLine("ERROR. El filtro ingresado debe ser un número");
                                Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                                Console.WriteLine("(1) Nombre\n(2) Género\n(3) Artista\n(4) Album\n(5) Explicit\n(6) Resolucion\n(7) Evaluación");
                                choice2 = Console.ReadLine().ToLower();
                            }

                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe, Volviendo al menu...\n");
                            choice2 = "-1";
                            baduser = true;
                            Thread.Sleep(1000);
                            Console.Clear();
                        }

                    }
                    if (catchsSongs.Count() > 0 && choice != -1 && !baduser)
                    {
                        Console.WriteLine("Seleccione la cancion deseada");
                        foreach (Song song in catchsSongs)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchsSongs.IndexOf(song) + 1, song.Name, song.Artist, song.Gender);
                        }
                        bool numchek = false;
                        while (!numchek)
                        {
                            Console.WriteLine("Ingrese un numero para seleccionar canción\n");
                            numchek = int.TryParse(Console.ReadLine(), out choice);
                            choice--;
                            Console.WriteLine(catchsSongs.Count());
                            if (catchsSongs.Count() > Math.Abs(choice))
                            {
                                return this.Songs.IndexOf(catchsSongs[choice]);
                            }
                            else
                            {
                                Console.WriteLine("Seleccione una canción dentro del rango o ingrese -1 para salir\n");
                            }
                            if (!numchek)
                            {
                                Console.WriteLine("Formato invalido, ingrese un numero:\n");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
                    }
                    Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    return -1;

                case "3": //Series
                    if (this.Series.Count() == 0)
                    {
                        Console.WriteLine("No se encontaron series\n");
                        return -1;
                    }
                    List<Series> catchsSeries = new List<Series>();

                    foreach (Series serie in this.Series)
                    {
                        catchsSeries.Add(serie);
                    }
                    List<Series> copycatchsSeries = new List<Series>(catchsSeries);
                    Console.WriteLine("Ingrese el criterio de filtro para la serie");
                    Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1" && catchsSeries.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }

                        if (choice2 == "1")
                        {
                            foreach (Series serie in copycatchsSeries)
                            {
                                if (!(serie.SerieName.ToLower().Contains(filter)) && catchsSeries.Contains(serie)) catchsSeries.Remove(serie);

                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Series serie in copycatchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Name.ToLower().Contains(filter)) && catchsSeries.Contains(serie)) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Series serie in copycatchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Director.ToLower().Contains(filter)) && catchsSeries.Contains(serie)) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Series serie in copycatchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    foreach (string actor in video.Actors)
                                    {
                                        if (!(actor.ToLower().Contains(filter)) && catchsSeries.Contains(serie)) catchsSeries.Remove(serie);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "5")
                        {
                            foreach (Series serie in copycatchsSeries)
                            {
                                foreach (Video video in serie.Episodes)
                                {
                                    if (!(video.Gender.ToLower().Contains(filter)) && catchsSeries.Contains(serie)) catchsSeries.Remove(serie);
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre serie\n(2) Nombre capítulo\n(3) Director\n(4) Actor\n(5) Género");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsSeries.Count() > 0)
                    {
                        Console.WriteLine("Seleccione la serie deseada");
                        foreach (Series serie in catchsSeries)
                        {
                            Console.WriteLine("{0}: {1}-{2}\n", catchsSeries.IndexOf(serie) + 1, serie.SerieName, serie.NofVideos);
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
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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
                    List<Playlist> copycatchsPlaylists = new List<Playlist>(catchsPlaylists);
                    Console.WriteLine("Ingrese el criterio de filtro para la playlist");
                    Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1" && catchsPlaylists.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Playlist playlist in copycatchsPlaylists)
                            {
                                if (!(playlist.PlaylistName.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);

                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "2")
                        {
                            foreach (Playlist playlist in copycatchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Name.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Name.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "3")
                        {
                            foreach (Playlist playlist in copycatchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Artist.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Director.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                    foreach (string actor in video.Actors)
                                    {
                                        if (!(actor.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                    }
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "4")
                        {
                            foreach (Playlist playlist in copycatchsPlaylists)
                            {
                                foreach (Song song in playlist.Songs)
                                {
                                    if (!(song.Gender.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                }
                                foreach (Video video in playlist.Videos)
                                {
                                    if (!(video.Gender.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                                }
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }
                        else if (choice2 == "5")
                        {
                            foreach (Playlist playlist in copycatchsPlaylists)
                            {
                                if (!(playlist.Userowner.Nickname.ToLower().Contains(filter)) && catchsPlaylists.Contains(playlist)) catchsPlaylists.Remove(playlist);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre playlist\n(2) Canción o video contenido\n(3) Artista (compositor/director/actor)\n(4) Género contenido\n(5) NickName del creador");
                            choice2 = Console.ReadLine().ToLower();

                        }


                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }

                    if (catchsPlaylists.Count() > 0)
                    {
                        Console.WriteLine("Seleccione la playlist deseada");
                        foreach (Playlist playlist in catchsPlaylists)
                        {
                            Console.WriteLine("{0}: {1}\n", catchsPlaylists.IndexOf(playlist) + 1, playlist.PlaylistName);
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
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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
                    List<Album> copycatchsAlbum = new List<Album>(catchsAlbum);

                    Console.WriteLine("Ingrese el criterio de filtro para el album");
                    Console.WriteLine("(1) Nombre álbum\n(2) Canción contenida\n(3) Artista contenido\n(4) Género contenido\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1" && catchsAlbum.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Album album in copycatchsAlbum)
                            {
                                if (!(album.Name.ToLower().Contains(filter)) && catchsAlbum.Contains(album)) catchsAlbum.Remove(album);
                            }


                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre álbum\n(2) Canción contenida\n(3) Artista contenido\n(4) Género contenido");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Album album in copycatchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Name.ToLower().Contains(filter)) && catchsAlbum.Contains(album)) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre álbum\n(2) Canción contenida\n(3) Artista contenido\n(4) Género contenido");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Album album in copycatchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Artist.ToLower().Contains(filter)) && catchsAlbum.Contains(album)) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre álbum\n(2) Canción contenida\n(3) Artista contenido\n(4) Género contenido");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Album album in copycatchsAlbum)
                            {
                                foreach (Song song in album.Songs)
                                {
                                    if (!(song.Gender.ToLower().Contains(filter)) && catchsAlbum.Contains(album)) catchsAlbum.Remove(album);
                                }
                            }

                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre álbum\n(2) Canción contenida\n(3) Artista contenido\n(4) Género contenido");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsAlbum.Count() > 0)
                    {
                        Console.WriteLine("Seleccione el album deseado");
                        foreach (Album album in catchsAlbum)
                        {
                            Console.WriteLine("{0}: {1}-{2}\n", catchsAlbum.IndexOf(album) + 1, album.Name, album.NumberSongs);
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
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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
                    List<Karaoke> copycatchsKaraoke = new List<Karaoke>(catchsKaraoke);
                    Console.WriteLine("Ingrese el criterio de filtro para el Karaoke");
                    Console.WriteLine("(1) Nombre canción\n(2) Artista canción\n(3) Género canción\n(4) Álbum canción\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();

                    while (choice2 != "-1" && catchsKaraoke.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Karaoke karaoke in copycatchsKaraoke)
                            {
                                if (!(karaoke.Name.ToLower().Contains(filter)) && catchsKaraoke.Contains(karaoke)) catchsKaraoke.Remove(karaoke);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre canción\n(2) Artista canción\n(3) Género canción\n(4) Álbum canción");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Karaoke karaoke in copycatchsKaraoke)
                            {
                                if (!(karaoke.Artist.ToLower().Contains(filter)) && catchsKaraoke.Contains(karaoke)) catchsKaraoke.Remove(karaoke);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre canción\n(2) Artista canción\n(3) Género canción\n(4) Álbum canción");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Karaoke karaoke in copycatchsKaraoke)
                            {
                                if (!(karaoke.Gender.ToLower().Contains(filter)) && catchsKaraoke.Contains(karaoke)) catchsKaraoke.Remove(karaoke);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre canción\n(2) Artista canción\n(3) Género canción\n(4) Álbum canción");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Karaoke karaoke in copycatchsKaraoke)
                            {
                                if (!(karaoke.Album.ToLower().Contains(filter)) && catchsKaraoke.Contains(karaoke)) catchsKaraoke.Remove(karaoke);
                            }

                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre canción\n(2) Artista canción\n(3) Género canción\n(4) Álbum canción");
                            choice2 = Console.ReadLine().ToLower();
                        }

                        else
                        {
                            Console.WriteLine("Esa opción no existe");
                            choice2 = "-1";
                        }
                    }
                    if (catchsKaraoke.Count() > 0)
                    {
                        Console.WriteLine("Seleccione el karaoke deseado");
                        foreach (Karaoke karaoke in catchsKaraoke)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchsKaraoke.IndexOf(karaoke) + 1, karaoke.Name, karaoke.Artist, karaoke.Gender);
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
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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
                    List<Lesson> copycatchsLessons = new List<Lesson>(catchsLessons);

                    Console.WriteLine("Ingrese el criterio de filtro para el clases");
                    Console.WriteLine("(1) Nombre clase\n(2) Asignatura\n(3) Curso (PK,K,1-8,I,II,II,IV)\n(4) Nombre profesor\n(-1) Salir");
                    choice2 = Console.ReadLine().ToLower();
                    while (choice2 != "-1" && catchsLessons.Count() > 0)
                    {
                        Console.WriteLine("Ingrese el filtro del archivo o -1 para salir\n");
                        string filter = Console.ReadLine().ToLower();
                        if (filter == "-1")
                        {
                            return -1;
                        }
                        if (choice2 == "1")
                        {
                            foreach (Lesson lesson in copycatchsLessons)
                            {
                                if (!(lesson.Name.ToLower().Contains(filter)) && catchsLessons.Contains(lesson)) catchsLessons.Remove(lesson);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre clase\n(2) Asignatura\n(3) Curso (PK,K,1-8,I,II,II,IV)\n(4) Nombre profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "2")
                        {
                            foreach (Lesson lesson in copycatchsLessons)
                            {
                                if (!(lesson.Subject.ToLower().Contains(filter)) && catchsLessons.Contains(lesson)) catchsLessons.Remove(lesson);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre clase\n(2) Asignatura\n(3) Curso (PK,K,1-8,I,II,II,IV)\n(4) Nombre profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "3")
                        {
                            foreach (Lesson lesson in copycatchsLessons)
                            {
                                if (!(lesson.Course.ToLower().Contains(filter)) && catchsLessons.Contains(lesson)) catchsLessons.Remove(lesson);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre clase\n(2) Asignatura\n(3) Curso (PK,K,1-8,I,II,II,IV)\n(4) Nombre profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }
                        else if (choice2 == "4")
                        {
                            foreach (Lesson lesson in copycatchsLessons)
                            {
                                if (!(lesson.Lessons.Director.ToLower().Contains(filter)) && catchsLessons.Contains(lesson)) catchsLessons.Remove(lesson);
                            }
                            Console.WriteLine("Ingrese otro criterio de búsqueda o -1 para salir");
                            Console.WriteLine("(1) Nombre clase\n(2) Asignatura\n(3) Curso (PK,K,1-8,I,II,II,IV)\n(4) Nombre profesor");
                            choice2 = Console.ReadLine().ToLower();
                        }

                    }
                    if (catchsLessons.Count() > 0)
                    {
                        Console.WriteLine("Seleccione la clase deseada");
                        foreach (Lesson lesson in catchsLessons)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", catchsLessons.IndexOf(lesson) + 1, lesson.Name, lesson.Subject, lesson.Course);
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
                    else
                    {
                        Console.WriteLine("No se encontraron coincidencias, volviendo al menu...\n");
                        Thread.Sleep(1000);
                        return -1;
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

        public void AddToQueue(User user, Song song)
        {
            user.Queque.Add(song);
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
            if (video.Qualification.Count()!=0)
            {
                return video.Qualification.Average();
            }
            else
            {
                return 0;
            }
        }
        public double GetQualification(Song song)//listo
        {
            if (song.Qualification.Count() != 0)
            {
                return song.Qualification.Average();
            }
            else return 0;
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
            Console.WriteLine("\tEl tamaño del video solictado es:{0} Bytes\n", video.FileSize);
        }//listo

        public void GetInstrinsicInformation(Song song)
        {
            Console.WriteLine("{0}\n",song.Name);
            Console.WriteLine("\tLa duracion de la cancion solicitada es{0}\n",song.Length);
            Console.WriteLine("\tEl tamaño de la cancion solictada es:{0} Bytes\n",song.FileSize);
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
            Console.WriteLine("\tLa calificacion que posee la cancion solicitada es:{0}\n", this.GetQualification(song));
        }//listo

        public void Follow(string key, List<User> users, User caller, List<Teacher> teachers)
        {
            int choice = 0;
            int choice2 = 0;
            string choice3;
            int choice4 = 0;
            Playlist p = new Playlist();
            Album a = new Album();
            Artist ar = new Artist();
            Series s = new Series();
            Teacher t = new Teacher();

            switch (key)
            {
                case "Users":
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione el usuario que quiere ver sus playlist o -1 para salir");
                        foreach (User user in users)
                        {
                            Console.WriteLine("{0}: {1} {2}\n", users.IndexOf(user) + 1, user.Name, user.Lastname);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar un usuario\n");
                            }
                        }
                        try
                        {
                            p = users[choice2 - 1].ShowPlaylistSong();

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow...\n");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            Console.WriteLine("Seleccione un usuario dentro del rango o ingrese -1 para salir\n");
                            choice = 0;
                        }

                        if (p != null)
                        {
                            int countplay = 0;
                            foreach (Playlist playlist in users[choice2 - 1].MyPlaylist)
                            {
                                if (playlist.Publicornot == "private")
                                {
                                    countplay += 1;
                                }
                            }
                            if (caller.FollowUsers.Contains(users[choice2 - 1]))
                            {
                                Console.WriteLine("Ya esta siguiendo a esta playlist\n");
                                Console.WriteLine("¿Desea intentar con otro usuario?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else 
                            {
                                if (caller.MembershipType == "pago")
                                {
                                    caller.FollowUsers.Add(users[choice2 - 1]);
                                    Console.WriteLine("Follow realizado correctamente\n");
                                    Console.WriteLine("¿Desea seguir a otro usuario?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú...");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú...");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                }
                               else if (caller.MembershipType =="no pago" && countplay==0)
                                {
                                    caller.FollowUsers.Add(users[choice2 - 1]);
                                    Console.WriteLine("Follow realizado correctamente\n");
                                    Console.WriteLine("¿Desea seguir a otro usuario?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú,,,");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú,,,,");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else 
                                {
                                    Console.WriteLine("No puede seguir este usuario, ya que usted no es premium y el usuario contiene listas privadas\n");
                                    Console.WriteLine("¿Desea intentar seguir a otro usuario?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú...");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú...");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    

                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;

                case "Albums":
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione el álbum que quiere ver sus canciones o -1 para salir\n");
                        foreach (Album album in albums)
                        {
                            Console.WriteLine("{0}: {1}\n", albums.IndexOf(album) + 1, album.Name);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar un album\n");
                            }
                        }
                        try
                        {
                            a=albums[choice2 - 1].ShowAlbumsSong();
                            
                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow....");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            Console.WriteLine("Seleccione un album dentro del rango o ingrese -1 para salir\n");
                            choice = 0;
                        }

                        if (a != null)
                        {
                            if (caller.FollowAlbums.Contains(a))
                            {
                                Console.WriteLine("Ya esta siguiendo a este álbum");
                                Console.WriteLine("¿Desea intentar con otro álbum?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú..");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else if (this.albums.Count() != 0)
                            {
                                caller.FollowAlbums.Add(a);
                                Console.WriteLine("Follow realizado correctamente");
                                Console.WriteLine("¿Desea seguir otro album?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;
                case "Playlists":
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione la playlist que desee ver o -1 para salir");
                        foreach (Playlist playlist in playlists)
                        {
                            Console.WriteLine("{0}: {1}-{2}\n", playlists.IndexOf(playlist) + 1, playlist.PlaylistName, playlist.Userowner);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar una playlist\n");
                            }
                        }
                        try
                        {
                            p = playlists[choice2 - 1].ShowPlaylist();

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow\n");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            Console.WriteLine("Seleccione una playlist dentro del rango o ingrese -1 para salir\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            choice = 0;
                        }

                        if (p != null)
                        {
                            if (caller.FollowPlaylist.Contains(p))
                            {
                                Console.WriteLine("Ya esta siguiendo a esta playlist");
                                Console.WriteLine("¿Desea intentar con otra playlist?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else
                            {
                                if (caller.MembershipType == "pago")
                                {
                                    caller.FollowPlaylist.Add(p);
                                    Console.WriteLine("Follow realizado correctamente");
                                    Console.WriteLine("¿Desea seguir a otra playlist?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú");
                                        break;
                                    }
                                }
                                else if (caller.MembershipType == "no pago" && p.Publicornot == "public")
                                {
                                    caller.FollowUsers.Add(users[choice2 - 1]);
                                    Console.WriteLine("Follow realizado correctamente");
                                    Console.WriteLine("¿Desea seguir a otro usuario?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú...\n");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú....\n");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("No puede seguir esta playlist, ya que usted no es premium y la playlist es privada\n");
                                    Console.WriteLine("¿Desea intentar seguir a otra playlist?\n(1) Si\n(2) No");
                                    choice3 = Console.ReadLine();
                                    if (choice3 == "1" || choice3.ToLower() == "si")
                                    {
                                        choice4 = 0;
                                    }
                                    else if (choice3 == "2" || choice3.ToLower() == "no")
                                    {
                                        Console.WriteLine("Saliendo al menú...\n");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion inválida, volviendo al menú...\n");
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                        break;
                                    }
                                    

                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;
                case "Artists":
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione el artista que desee ver  o -1 para salir\n");
                        foreach (Artist artist in artists)
                        {
                            Console.WriteLine("{0} {1}\n", artists.IndexOf(artist) + 1, artist.Name);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar un artista\n");
                            }
                        }
                        try
                        {
                            ar = artists[choice2 - 1].ShowArtist();

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow...\n");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            Console.WriteLine("Seleccione un artista dentro del rango o ingrese -1 para salir\n");
                            choice = 0;
                        }

                        if (ar != null)
                        {
                            if (caller.FollowArtist.Contains(ar))
                            {
                                Console.WriteLine("Ya esta siguiendo a este artista\n");
                                Console.WriteLine("¿Desea intentar con otro artista?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else if (this.artists.Count() != 0)
                            {
                                caller.FollowArtist.Add(ar);
                                Console.WriteLine("Follow realizado correctamente");
                                Console.WriteLine("¿Desea seguir otro artista?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;
                case "Series":
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione la serie que desee ver  o -1 para salir\n");
                        foreach (Series serie in series)
                        {
                            Console.WriteLine("{0}: {1}-{3}\n", series.IndexOf(serie) + 1, serie.SerieName, serie.NofVideos);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar una serie\n");
                            }
                        }
                        try
                        {
                            s = series[choice2 - 1].ShowSerie();

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow...\n");
                                Thread.Sleep(1000);
                                Console.Clear();
                            }
                            Console.WriteLine("Seleccione una serie dentro del rango o ingrese -1 para salir\n");
                            choice = 0;
                        }

                        if (s != null)
                        {
                            if (caller.FollowSeries.Contains(s))
                            {
                                Console.WriteLine("Ya esta siguiendo esta serie\n");
                                Console.WriteLine("¿Desea intentar con otra serie?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...\n");
                                    Console.WriteLine("Saliendo de Follow...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Console.WriteLine("Saliendo de Follow...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                            }
                            else if (this.series.Count()!=0)
                            {
                                caller.FollowSeries.Add(s);
                                Console.WriteLine("Follow realizado correctamente\n");
                                Console.WriteLine("¿Desea seguir otra serie?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú...");
                                    Console.WriteLine("Saliendo de Follow...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú...");
                                    Console.WriteLine("Saliendo de Follow...\n");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;

                case "Teacher":
                    if (teachers.Count()==0)
                    {
                        Console.WriteLine("No existen profesores volviendo al menu...\n");
                        Thread.Sleep(1000);
                        Console.Clear();

                        break;
                    }
                    while (choice4 == 0)
                    {
                        Console.WriteLine("Seleccione el profesor que desee ver  o -1 para salir");
                        foreach (Teacher teacher in teachers)
                        {
                            Console.WriteLine("{0}: {1}-{2}-{3}\n", teachers.IndexOf(teacher) + 1, teacher.Name, teacher.Lastname, teacher.Course);
                        }
                        while (choice2 == 0)
                        {
                            try
                            {
                                choice2 = int.Parse(Console.ReadLine());
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("Ingrese un numero para seleccionar un profesor\n");
                            }
                        }
                        try
                        {
                            t = teachers[choice2 - 1].ShowTeacher();

                        }
                        catch (ArgumentOutOfRangeException)
                        {
                            if (choice == -1)
                            {
                                Console.WriteLine("Saliendo de Follow");
                            }
                            Console.WriteLine("Seleccione un profesor dentro del rango o ingrese -1 para salir\n");
                            choice = 0;
                        }

                        if (t != null)
                        {
                            if (caller.FollowTeachers.Contains(t))
                            {
                                Console.WriteLine("Ya esta siguiendo este profesor");
                                Console.WriteLine("¿Desea intentar con otro profesor?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú");
                                    break;
                                }
                            }
                            else
                            {
                                caller.FollowTeachers.Add(t);
                                Console.WriteLine("Follow realizado correctamente");
                                Console.WriteLine("¿Desea seguir otro profesor?\n(1) Si\n(2) No");
                                choice3 = Console.ReadLine();
                                if (choice3 == "1" || choice3.ToLower() == "si")
                                {
                                    choice4 = 0;
                                }
                                else if (choice3 == "2" || choice3.ToLower() == "no")
                                {
                                    Console.WriteLine("Saliendo al menú");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Opcion inválida, volviendo al menú");
                                    break;
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Volviendo al menu...\n");
                            Thread.Sleep(1000);
                            Console.Clear();
                            break;
                        }

                    }
                    break;

                default:
                    Console.WriteLine("Formato invalido, volviendo al menu...\n");
                    Thread.Sleep(1000);
                    Console.Clear();
                    break;
            }
        }

        public void Download(Song song, User user)//listo
        {
            int count = 0;
            foreach (Song s in user.DownloadSongs)
            {
                if (s == song)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                string destination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), Path.GetFileName(song.Route));
                string source = song.Route;
                System.IO.File.Copy(source, destination, true);
                user.DownloadSongs.Add(song);
                Console.WriteLine($"Descarga exitosa de la canción {song.Name}");
            }
            else
            {
                Console.WriteLine($"Error. La canción {song.Name} ya se encuentra en sus descargas");
            }    
        }
        
    }

}
