using Spotflix.Media_Related;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Spotflix.User_Related
{
    public static class Admin
    {

        //private static string username = "Spotflix";
        //private static string password = "MbJcMm2020";

        public static bool ImportSong(string path,string name,string artistname,  string albumname,string genre, int year,bool explicit1, Image image, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            List<Serie> seriesa = new List<Serie>();
            byte[] bytes = File.ReadAllBytes(path);
            TagLib.File file = TagLib.File.Create(path);
            var ffProbe = new NReco.VideoInfo.FFProbe();
            ffProbe.IncludeFormat = true;
            var songinfo = ffProbe.GetMediaInfo(path);
            TimeSpan duration = songinfo.Duration;
            long size = file.Length;



            Song song = new Song(artistname, albumname, explicit1, name, genre, year, image, bytes, duration, size, mediaPlayer.Songs.Count()+1) ;

            if (mediaPlayer.Songs.Count() == 0)
            {
                mediaPlayer.Songs.Add(song);
                foreach (Artist a in mediaPlayer.Artists)
                {
                    if (a.Name == song.Artist) count3++;
                }
                if (count3 == 0)
                {
                    namea = song.Artist;
                    songsa.Add(song);
                    classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                    mediaPlayer.Artists.Add(classa);
                }
                else
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (song.Artist == a.Name && a.Songs.Any(u => u.Equals(song) == false)) a.Songs.Add(song);

                    }

                }
                List<string> artists = new List<string>();
                artists.Add(song.Artist);
                List<Song> songs = new List<Song>();
                songs.Add(song);
                Album al = new Album(song.Album, artists, 1, songs);
                mediaPlayer.Albums.Add(al);
                return true;
            }
            else
            {
                foreach (Song i in mediaPlayer.Songs)
                {
                    if (i.Name == song.Name && i.Artist == song.Artist)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    mediaPlayer.Songs.Add(song);
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == song.Artist) count3++;
                    }
                    if (count3 == 0)
                    {
                        namea = song.Artist;
                        songsa.Add(song);
                        classa = new Artist(karaokesa, songsa, videosa, namea,seriesa);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (song.Artist == a.Name && !a.Songs.Any(u => u.Equals(song)))
                            {
                                a.Songs.Add(song);
                            }
                        }

                    }
                    foreach (Album a in mediaPlayer.Albums)
                    {
                        if (a.Name == song.Album)
                        {
                            count2++;
                            a.Songs.Add(song);
                            if (!a.Artists.Any(u => u.Equals(song.Artist)))
                            {
                                a.Artists.Add(song.Artist);
                            }
                            a.NumberSongs += 1;

                        }
                    }
                    if (count2 == 0)
                    {
                        List<string> artists = new List<string>();
                        artists.Add(song.Artist);
                        List<Song> songs = new List<Song>();
                        songs.Add(song);
                        Album al = new Album(song.Album, artists, 1, songs);
                        mediaPlayer.Albums.Add(al);
                    }
                    return true;
                }
                else return false;
            }
        }
        
        public static bool ImportVideo(string path, string videoname, string directorname, List<string> actors, string genre, int year, int  ageFilter, string studio, Image PictureVideoHolder, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            List<Serie> seriesa = new List<Serie>();
            string dimension="";
            byte[] bytes = File.ReadAllBytes(path);
            TagLib.File file = TagLib.File.Create(path);
            var ffProbe = new NReco.VideoInfo.FFProbe();
            ffProbe.IncludeFormat = true;
            var videoinfo = ffProbe.GetMediaInfo(path);

            TimeSpan duration = videoinfo.Duration;
            long size = file.Length;
            long fileSize = new System.IO.FileInfo(path).Length;
            Video video = new Video(actors, ageFilter,directorname, studio, videoname, genre, PictureVideoHolder, year, bytes, duration,size, mediaPlayer.Videos.Count() +1,dimension);
            video.FileSize = fileSize;
            if (mediaPlayer.Videos.Count() == 0)
            {
                mediaPlayer.Videos.Add(video);
                foreach (Artist a in mediaPlayer.Artists)
                {
                    if (a.Name == video.Director) count3++;
                }
                if (count3 == 0)
                {
                    List<Video> videosa = new List<Video>();

                    namea = video.Director;
                    videosa.Add(video);
                    classa = new Artist(karaokesa, songsa, videosa, namea,seriesa);
                    mediaPlayer.Artists.Add(classa);
                }
                else
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (video.Director == a.Name && !a.Videos.Any(u => u.Equals(video)))
                        {
                            a.Videos.Add(video);
                        }
                    }
                }
                foreach (string actor in video.Actors)
                {
                    int count2 = 0;
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == actor) count2++;
                    }
                    namea = actor;
                    
                    if (count2 == 0)
                    {
                        List<Video> videosa = new List<Video>();
                        videosa.Add(video);
                        classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (actor == a.Name && !a.Videos.Any(u => u.Equals(video)))
                            {
                                a.Videos.Add(video);
                            }
                        }
                    }
                }
                return true;
            }
            else
            {
                foreach (Video i in mediaPlayer.Videos)
                {
                    if (i.Name == video.Name && i.Director == video.Director)
                    {
                        count++;
                    }

                }
                if (count == 0)
                {
                    mediaPlayer.Videos.Add(video);
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == video.Director) count3++;
                    }
                    if (count3 == 0)
                    {
                        List<Video> videosa = new List<Video>();

                        namea = video.Director;
                        videosa.Add(video);
                        classa = new Artist(karaokesa, songsa, videosa, namea,seriesa);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (video.Director == a.Name && !a.Videos.Any(u => u.Equals(video)))
                            {
                                a.Videos.Add(video);
                            }
                        }
                    }
                    foreach (string actor in video.Actors)
                    {
                        List<Video> videosa = new List<Video>();
                        int count2 = 0;
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (a.Name == actor) count2++;
                        }
                        namea = actor;
                        
                        if (count2 == 0)
                        {
                            videosa.Add(video);
                            classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                            mediaPlayer.Artists.Add(classa);
                        }
                        else
                        {
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (actor == a.Name && !a.Videos.Any(u => u.Equals(video)))
                                {
                                    a.Videos.Add(video);
                                }
                            }
                        }
                    }
                    return true;
                }
                else return false;
            }
        }
        private static List<string> ProcessLyics(string path)
        {
            string[] aux =File.ReadAllText(path).Split('\n');
            int cont = 0;
            List<string> returnable = new List<string>();
            double realinterval=0;
            string line="";
            foreach (string item in aux)
            {

                if (cont==1)
                {
                    string[] separator = { "-->" };
                    string[] timers = item.Split(separator,StringSplitOptions.RemoveEmptyEntries);
                    timers[0] = timers[0].Replace(" ", "");
                    timers[1]= timers[1].Replace("\r","");
                    timers[1] = timers[1].Replace(" ", "");
                    char[] array = timers[0].ToCharArray();
                    array[8] = '.' ;
                    char [] array1=timers[1].ToCharArray();
                    array1[8] = '.';
                    string s = new string(array);
                    string s2 = new string(array1);
                    realinterval = (TimeSpan.Parse(s2).TotalMilliseconds- TimeSpan.Parse(s).TotalMilliseconds);

                }
                if (item=="\r")
                {
                    returnable.Add(realinterval.ToString());
                    returnable.Add(line);
                    cont = -1;
                }
                else
                {
                    line = item + "\n";
                }
                cont++;
            }
            return returnable;
        }
        public static bool ImportKaraoke(string lpath, string path, string name, string artistname, string albumname, string genre, int year, bool explicit1, Image image, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            List<string> lyrics = ProcessLyics(lpath);
            List<Serie> seriesa = new List<Serie>();

            byte[] bytes = File.ReadAllBytes(path);
            TagLib.File file = TagLib.File.Create(path);
            var ffProbe = new NReco.VideoInfo.FFProbe();
            ffProbe.IncludeFormat = true;
            var karaokeinfo = ffProbe.GetMediaInfo(path);
            TimeSpan duration = karaokeinfo.Duration;
            long size = file.Length;

            Karaoke karaoke = new Karaoke(lyrics, artistname, albumname, explicit1, name, genre, year, image, bytes, duration, size, mediaPlayer.Karaokes.Count()+1);

            if (mediaPlayer.Karaokes.Count() == 0)
            {
                mediaPlayer.Karaokes.Add(karaoke);
                foreach (Artist a in mediaPlayer.Artists)
                {
                    if (a.Name == karaoke.Artist) count3++;
                }
                if (count3 == 0)
                {
                    namea = karaoke.Artist;
                    karaokesa.Add(karaoke);
                    classa = new Artist(karaokesa, songsa, videosa, namea,seriesa);
                    mediaPlayer.Artists.Add(classa);
                }
                else
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (karaoke.Artist == a.Name && !a.Karaokes.Any(u => u.Equals(karaoke)))
                        {
                            a.Karaokes.Add(karaoke);
                        }
                    }
                }
                List<string> artists = new List<string>();
                artists.Add(karaoke.Artist);
                List<Karaoke> karaokes = new List<Karaoke>();
                karaokes.Add(karaoke);
                return true;
            }
            else
            {
                foreach (Karaoke i in mediaPlayer.Karaokes)
                {
                    if (i.Name == karaoke.Name && i.Artist == karaoke.Artist)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    mediaPlayer.Karaokes.Add(karaoke);
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == karaoke.Artist) count3++;
                    }
                    if (count3 == 0)
                    {
                        namea = karaoke.Artist;
                        karaokesa.Add(karaoke);
                        classa = new Artist(karaokesa, songsa, videosa, namea,seriesa);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (karaoke.Artist == a.Name && !a.Karaokes.Any(u => u.Equals(karaoke)))
                            {
                                a.Karaokes.Add(karaoke);
                            }
                        }
                    }
                    return true;
                }
                else return false;
            }
        }



        public static bool ImportVideoSerie(string serieName, int season, string path, string videoname, string directorname, List<string> actors, string genre, int year, int ageFilter, string studio, Image PictureSerieHolder, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();


            byte[] bytes = File.ReadAllBytes(path);

            TagLib.File file = TagLib.File.Create(path);
            var ffProbe = new NReco.VideoInfo.FFProbe();
            ffProbe.IncludeFormat = true;
            var videoinfo = ffProbe.GetMediaInfo(path);
            TimeSpan duration = videoinfo.Duration;
            long size = file.Length;
            long fileSize = new System.IO.FileInfo(path).Length;
            Video video = new Video(actors, ageFilter, directorname, studio, videoname, genre, year, bytes, duration, size, 0,0);
            video.FileSize = fileSize;
            int chapternumber;
            Serie serie = new Serie();
            int count4 = 0;
            if (mediaPlayer.Series.Count() != 0)
            {
                foreach (Serie s in mediaPlayer.Series)
                {
                    if (s.SerieName == serieName && s.Season == season)
                    {
                        count4++;
                        if (s.Episodes.Count() == 0)
                        {
                            video.Code = s.NofVideos + 1;
                            video.Chapter = s.NofVideos + 1;
                            chapternumber = video.Chapter;
                            video.Image = PictureSerieHolder;
                            s.Episodes.Add(video);
                            s.NofVideos += 1;
                            mediaPlayer.VideoChapters.Add(video);
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (a.Name == video.Director)
                                {
                                    count3++;
                                }
                                
                            }
                            if (count3 == 0)
                            {
                                List<Serie> seriesa = new List<Serie>();
                                namea = video.Director;
                                seriesa.Add(s);
                                classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                                mediaPlayer.Artists.Add(classa);
                            }
                            else
                            {
                                foreach (Artist a in mediaPlayer.Artists)
                                {
                                    if (video.Director == a.Name && !a.Series.Any(u => u.Equals(s)))
                                    {
                                        a.Series.Add(s);
                                    }
                                }
                            }
                            foreach (string actor in video.Actors)
                            {
                                List<Serie> seriesa = new List<Serie>();
                                int count2 = 0;
                                foreach (Artist a in mediaPlayer.Artists)
                                {
                                    if (a.Name == actor) count2++;
                                }
                                namea = actor;
                                seriesa.Add(s);
                                classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                                if (count2 == 0) mediaPlayer.Artists.Add(classa);
                                else
                                {
                                    foreach (Artist a in mediaPlayer.Artists)
                                    {
                                        if (actor == a.Name && !a.Series.Any(u => u.Equals(s)))
                                        {
                                            a.Series.Add(s);
                                        }
                                    }
                                }
                            }
                            return true;
                        }
                        else
                        {
                            foreach (Video v in s.Episodes)
                            {
                                if (v.Director == directorname && v.Name == videoname)
                                {
                                    count++;
                                }
                            }

                            if (count == 0)
                            {
                                video.Code = s.NofVideos + 1;
                                video.Chapter = s.NofVideos + 1;
                                chapternumber = video.Chapter;
                                video.Image = PictureSerieHolder;
                                s.Episodes.Add(video);
                                s.NofVideos += 1;
                                mediaPlayer.VideoChapters.Add(video);

                                foreach (Artist a in mediaPlayer.Artists)
                                {
                                    if (a.Name == video.Director) count3++;
                                }
                                if (count3 == 0)
                                {
                                    List<Serie> seriesa = new List<Serie>();
                                    namea = video.Director;
                                    seriesa.Add(s);
                                    classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                                    mediaPlayer.Artists.Add(classa);
                                }
                                else
                                {
                                    foreach (Artist a in mediaPlayer.Artists)
                                    {
                                        if (video.Director == a.Name && !a.Series.Any(u => u.Equals(s)))
                                        {
                                            a.Series.Add(s);
                                        }
                                    }
                                }
                                foreach (string actor in video.Actors)
                                {
                                    List<Serie> seriesa = new List<Serie>();
                                    int count2 = 0;
                                    foreach (Artist a in mediaPlayer.Artists)
                                    {
                                        if (a.Name == actor) count2++;
                                    }
                                    namea = actor;
                                    seriesa.Add(serie);
                                    classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                                    if (count2 == 0) mediaPlayer.Artists.Add(classa);
                                    else
                                    {
                                        foreach (Artist a in mediaPlayer.Artists)
                                        {
                                            if (actor == a.Name && !a.Series.Any(u => u.Equals(s)))
                                            {
                                                a.Series.Add(s);
                                            }
                                        }
                                    }
                                }
                                return true;
                            }
                            else return false;
                        }

                    }
                }
            }           
            if (count4 == 0)
            {
                serie.SerieName = serieName;
                serie.Season = season;
                serie.Image = PictureSerieHolder;
                video.Code = 1;
                video.Chapter = 1;
                chapternumber = video.Chapter;
                video.Image = PictureSerieHolder;
                serie.Episodes.Add(video);
                serie.NofVideos = 1;
                mediaPlayer.VideoChapters.Add(video);
                serie.Code = mediaPlayer.Series.Count() + 1;
                mediaPlayer.Series.Add(serie);
                foreach (Artist a in mediaPlayer.Artists)
                {
                    if (a.Name == video.Director) count3++;
                }
                if (count3 == 0)
                {
                    List<Serie> seriesa = new List<Serie>();
                    namea = video.Director;
                    seriesa.Add(serie);
                    classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                    mediaPlayer.Artists.Add(classa);
                }
                else
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (video.Director == a.Name && !a.Series.Any(u => u.Equals(serie)))
                        {
                            a.Series.Add(serie);
                        }
                    }
                }
                foreach (string actor in video.Actors)
                {
                    int count2 = 0;
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == actor) count2++;
                    }
                    List<Serie> seriesa = new List<Serie>();
                    namea = actor;
                    seriesa.Add(serie);
                    classa = new Artist(karaokesa, songsa, videosa, namea, seriesa);
                    if (count2 == 0) mediaPlayer.Artists.Add(classa);
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (actor == a.Name && !a.Series.Any(u => u.Equals(serie)))
                            {
                                a.Series.Add(serie);
                            }

                        }
                    }
                }
                return true;

            }
            return false;

        }

    }
}
