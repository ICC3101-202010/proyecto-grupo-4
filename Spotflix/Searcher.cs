using Microsoft.WindowsAPICodePack.Dialogs;
using Spotflix.Media_Related;
using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotflix
{
    public static class Searcher
    {
        private static MediaPlayer mediaPlayer;

        public static MediaPlayer MediaPlayer { get => mediaPlayer; set => mediaPlayer = value; }
        public static void Smartlist (Playlist playlist)
        {
            string bigfilter = playlist.Filter;
            HashSet<Song> songs = new HashSet<Song>();
            HashSet<Video> videos = new HashSet<Video>();
            HashSet<Karaoke> karaokes = new HashSet<Karaoke>();
            bigfilter = bigfilter.ToLower();
            if (bigfilter.Contains("or"))
            {

                string[] separator = { "or" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (item.Contains("and"))
                    {
                        string[] sep = { "and" };
                        string[] subfilters = item.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string subitem in subfilters)
                        {
                            if (songs.Count()==0)
                            {
                                songs.UnionWith(SearchSong(subitem));
                            }
                            else
                            {
                                songs.IntersectWith(SearchSong(subitem));
                            }
                            if (videos.Count()==0)
                            {
                                videos.UnionWith(SearchVideo(subitem));
                            }
                            else
                            {
                                videos.IntersectWith(SearchVideo(subitem));
                            }
                            if (karaokes.Count()==0)
                            {
                                karaokes.UnionWith(SearchKaraoke(subitem));
                            }
                            else
                            {
                                karaokes.IntersectWith(SearchKaraoke(subitem));
                            }
                        }
                    }
                    else
                    {
                        songs.UnionWith(SearchSong(item));
                        videos.UnionWith(SearchVideo(item));
                        karaokes.UnionWith(SearchKaraoke(item));

                    }
                }
            }
            else if (bigfilter.Contains("and"))
            {
                string[] separator = { "and" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (songs.Count() == 0)
                    {
                        songs.UnionWith(SearchSong(item));
                    }
                    else
                    {
                        songs.IntersectWith(SearchSong(item));
                    }
                    if (videos.Count() == 0)
                    {
                        videos.UnionWith(SearchVideo(item));
                    }
                    else
                    {
                        videos.IntersectWith(SearchVideo(item));
                    }
                    if (karaokes.Count() == 0)
                    {
                        karaokes.UnionWith(SearchKaraoke(item));
                    }
                    else
                    {
                        karaokes.IntersectWith(SearchKaraoke(item));
                    }
                }
            }
            else
            {
                songs.UnionWith(SearchSong(bigfilter));
                karaokes.UnionWith(SearchKaraoke(bigfilter));
                videos.UnionWith(SearchVideo(bigfilter));
            }
            playlist.Songs = songs.ToList();
            playlist.Videos = videos.ToList();
            playlist.Karaokes = karaokes.ToList();
        }
        public static void Brain(string bigfilter)
        {
            bigfilter = bigfilter.ToLower();
            HashSet<Song> songs = new HashSet<Song>();
            HashSet<Video> videos = new HashSet<Video>();
            HashSet<Serie> series = new HashSet<Serie>();
            HashSet<Playlist> playlist = new HashSet<Playlist>();
            HashSet<Album> albums = new HashSet<Album>();
            HashSet<Karaoke> karaokes = new HashSet<Karaoke>();
            HashSet<User> users = new HashSet<User>();
            HashSet<Artist> artist = new HashSet<Artist>();

            if (bigfilter.Contains("or"))
            {

                string[] separator = { "or" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (item.Contains("and"))
                    {
                        string[] sep = { "and" };
                        string[] subfilters = item.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string subitem in subfilters)
                        {
                            if (artist.Count()==0)
                            {
                                artist.UnionWith(SearchArtist(subitem));
                            }
                            else
                            {
                                artist.IntersectWith(SearchArtist(subitem));
                            }
                            if (users.Count()==0)
                            {
                                users.UnionWith(SearchUser(subitem));
                            }
                            else
                            {
                                users.IntersectWith(SearchUser(subitem));
                            }
                            if (songs.Count() == 0)
                            {
                                songs.UnionWith(SearchSong(subitem));
                            }
                            else
                            {
                                songs.IntersectWith(SearchSong(subitem));
                            }
                            if (videos.Count() == 0)
                            {
                                videos.UnionWith(SearchVideo(subitem));
                            }
                            else
                            {
                                videos.IntersectWith(SearchVideo(subitem));
                            }
                            if (playlist.Count() == 0)
                            {
                                playlist.UnionWith(SearchPlaylist(subitem));
                            }
                            else
                            {
                                playlist.IntersectWith(SearchPlaylist(subitem));
                            }
                            if (albums.Count() == 0)
                            {
                                albums.UnionWith(SearchAlbum(subitem));
                            }
                            else
                            {
                                albums.IntersectWith(SearchAlbum(subitem));
                            }
                            if (karaokes.Count() == 0)
                            {
                                karaokes.UnionWith(SearchKaraoke(subitem));
                            }
                            else
                            {
                                karaokes.IntersectWith(SearchKaraoke(subitem));
                            }
                        }

                    }
                    else
                    {
                        artist.UnionWith(SearchArtist(item));
                        users.UnionWith(SearchUser(item));
                        songs.UnionWith(SearchSong(item));
                        videos.UnionWith(SearchVideo(item));
                        series.UnionWith(SearchSeries(item));
                        playlist.UnionWith(SearchPlaylist(item));
                        albums.UnionWith(SearchAlbum(item));
                        karaokes.UnionWith(SearchKaraoke(item));

                    }
                }
            }
            else if (bigfilter.Contains("and"))
            {
                string[] separator = { "and" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (artist.Count() == 0)
                    {
                        artist.UnionWith(SearchArtist(item));
                    }
                    else
                    {
                        artist.IntersectWith(SearchArtist(item));
                    }
                    if (users.Count() == 0)
                    {
                        users.UnionWith(SearchUser(item));
                    }
                    else
                    {
                        users.IntersectWith(SearchUser(item));
                    }
                    if (songs.Count() == 0)
                    {
                        songs.UnionWith(SearchSong(item));
                    }
                    else
                    {
                        songs.IntersectWith(SearchSong(item));
                    }
                    if (videos.Count() == 0)
                    {
                        videos.UnionWith(SearchVideo(item));
                    }
                    else
                    {
                        videos.IntersectWith(SearchVideo(item));
                    }
                    if (playlist.Count() == 0)
                    {
                        playlist.UnionWith(SearchPlaylist(item));
                    }
                    else
                    {
                        playlist.IntersectWith(SearchPlaylist(item));
                    }
                    if (albums.Count() == 0)
                    {
                        albums.UnionWith(SearchAlbum(item));
                    }
                    else
                    {
                        albums.IntersectWith(SearchAlbum(item));
                    }
                    if (karaokes.Count() == 0)
                    {
                        karaokes.UnionWith(SearchKaraoke(item));
                    }
                    else
                    {
                        karaokes.IntersectWith(SearchKaraoke(item));
                    }


                }
            }
            else
            {
                artist.UnionWith(SearchArtist(bigfilter));
                users.UnionWith(SearchUser(bigfilter));
                songs.UnionWith(SearchSong(bigfilter));
                videos.UnionWith(SearchVideo(bigfilter));
                series.UnionWith(SearchSeries(bigfilter));
                playlist.UnionWith(SearchPlaylist(bigfilter));
                albums.UnionWith(SearchAlbum(bigfilter));
               karaokes.UnionWith(SearchKaraoke(bigfilter));
            }
            MediaPlayer.Foundartists = artist;
            MediaPlayer.Foundsongs = songs;
            MediaPlayer.Foundvideos = videos;
            MediaPlayer.Foundseries = series;
            MediaPlayer.Foundplaylist = playlist;
            MediaPlayer.Foundalbums = albums;
            MediaPlayer.Foundkaraokes = karaokes;
            Gate.Foundusers = users;
        }
        public static HashSet<Artist> SearchArtist(string filter)
        {
            HashSet<Artist> found = new HashSet<Artist>();
            if (filter.Contains(":"))
            {
                filter = filter.Replace(" ", "");
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "name":
                        foreach (Artist artist in MediaPlayer.Artists)
                        {
                            if (artist.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(artist);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<User> SearchUser(string filter)
        {
            HashSet<User> found = new HashSet<User>();
            if (filter.Contains(":"))
            {
                filter = filter.Replace(" ", "");
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "name":
                        foreach (User user in Gate.Users)
                        {
                            if (user.Name.ToLower().Contains(caser[1])&&user.PrivPubl.ToLower()== "publico")
                            {
                                found.Add(user);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Song> SearchSong(string filter)
        {
            HashSet<Song> found = new HashSet<Song>();
            if (filter.Contains(":"))
            {
                filter = filter.Replace(" ", "");
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "artist":
                        foreach (Song song in Searcher.MediaPlayer.Songs)
                        {
                            if (song.Artist.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "name":
                        foreach (Song song in MediaPlayer.Songs)
                        {
                            if (song.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "album":
                        foreach (Song song in MediaPlayer.Songs)
                        {
                            if (song.Album.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "genre":
                        foreach (Song song in MediaPlayer.Songs)
                        {
                            if (song.Genre.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "explicit":
                        foreach (Song song in MediaPlayer.Songs)
                        {
                            if (caser[1] == "True" && song.ExpliciT)
                            {
                                found.Add(song);
                            }
                            else if (caser[1] == "False" && !song.ExpliciT)
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "stars":
                        foreach (Song song in MediaPlayer.Songs)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '<');
                                try
                                {
                                    if (song.Qualification.Average() <= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains("<"))
                            {
                                string case1 = caser[1].Trim('<');
                                try
                                {
                                    if (song.Qualification.Average() < Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '>');
                                try
                                {
                                    if (song.Qualification.Average() >= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                string case1 = caser[1].Trim('>');
                                try
                                {
                                    if (song.Qualification.Average() > Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                string case1 = caser[1].Trim('=');
                                try
                                {
                                    if (song.Qualification.Average() == Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Video> SearchVideo(string filter)
        {
            HashSet<Video> found = new HashSet<Video>();
            filter = filter.Replace(" ", "");
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');

                switch (caser[0])
                {
                    case "director":
                        foreach (Video video in MediaPlayer.Videos)
                        {
                            if (video.Director.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        foreach (Video video in MediaPlayer.VideoChapters)
                        {
                            if (video.Director.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        break;
                    case "name":
                        foreach (Video video in MediaPlayer.Videos)
                        {
                            if (video.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        foreach (Video video in MediaPlayer.VideoChapters)
                        {
                            if (video.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        break;
                    case "genre":
                        foreach (Video video in MediaPlayer.Videos)
                        {
                            if (video.Genre.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        foreach (Video video in MediaPlayer.VideoChapters)
                        {
                            if (video.Genre.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        break;
                    case "studio":
                        foreach (Video video in MediaPlayer.VideoChapters)
                        {
                            if (video.Studio.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        foreach (Video video in MediaPlayer.Videos)
                        {
                            if (video.Studio.ToLower().Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        break;
                    case "actor":
                        foreach (Video video in MediaPlayer.VideoChapters)
                        {
                            if (video.Actors.Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        foreach (Video video in MediaPlayer.Videos)
                        {
                            if (video.Actors.Contains(caser[1]))
                            {
                                found.Add(video);
                            }
                        }
                        break;
                    case "stars":
                        foreach (Video song in MediaPlayer.VideoChapters)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '<');
                                try
                                {
                                    if (song.Qualification.Average() <= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains("<"))
                            {
                                string case1 = caser[1].Trim('<');
                                try
                                {
                                    if (song.Qualification.Average() < Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('>', '=');
                                try
                                {
                                    if (song.Qualification.Average() >= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                string case1 = caser[1].Trim('>');
                                try
                                {
                                    if (song.Qualification.Average() > Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                string case1 = caser[1].Trim('=');
                                try
                                {
                                    if (song.Qualification.Average() == Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                        }
                        foreach (Video song in MediaPlayer.Videos)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=','<');
                                try
                                {
                                    if (song.Qualification.Average() <= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains("<"))
                            {
                                string case1 = caser[1].Trim('<');
                                try
                                {
                                    if (song.Qualification.Average() < Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('>','=');
                                try
                                {
                                    if (song.Qualification.Average() >= Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                string case1 = caser[1].Trim('>');
                                try
                                {
                                    if (song.Qualification.Average() > Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                            else
                            {
                                string case1 = caser[1].Trim('=');
                                try
                                {
                                    if (song.Qualification.Average() == Convert.ToInt32(case1))
                                    {
                                        found.Add(song);
                                    }
                                }
                                catch (FormatException)
                                {
                                    throw;
                                }
                            }
                        }
                        break;
                    case "resolution":
                        foreach (Video song in MediaPlayer.VideoChapters)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '<');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 9)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) <= Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) <= Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                                
                            }
                            else if (caser[1].Contains("<"))
                            {
                                string case1 = caser[1].Trim('<');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) < Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) < Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }

                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '>');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 9)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) >= Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) >= Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                string case1 = caser[1].Trim('>');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) > Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) > Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else
                            {
                                string case1 = caser[1].Trim('=');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) == Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) == Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                        foreach (Video song in MediaPlayer.Videos)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '<');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count()>=9)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) <= Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) <= Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else if (caser[1].Contains("<"))
                            {
                                string case1 = caser[1].Trim('<');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) < Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) < Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                string case1 = caser[1].Trim('=', '>');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 9)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) >= Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) >= Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                string case1 = caser[1].Trim('>');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) > Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) > Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else
                            {

                                string case1 = caser[1].Trim('=');
                                string[] aux = { "0", "0" };
                                if (case1.Contains("x"))
                                {
                                    aux = case1.Split('x');
                                }
                                if (case1.Count() >= 8)
                                {
                                    try
                                    {
                                        string[] checker = song.Dimension.Split('x');
                                        if (Convert.ToInt32(checker[0]) == Convert.ToInt32(aux[0]) && Convert.ToInt32(checker[1]) == Convert.ToInt32(aux[1]))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Serie> SearchSeries(string filter)
        {
            HashSet<Serie> found = new HashSet<Serie>();
            filter = filter.Replace(" ", "");
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');

                switch (caser[0])
                {
                    case "name":
                        foreach (Serie serie in MediaPlayer.Series)
                        {
                            string name = serie.SerieName;
                            if (serie.SerieName.ToLower().Contains(caser[1]))
                            {
                                found.Add(serie);

                            }
                        }
                        break;
                    case "director":
                        foreach (Serie serie in MediaPlayer.Series)
                        {
                            foreach (Video video in serie.Episodes)
                            {
                                if (video.Director.ToLower().Contains(caser[1]))
                                {
                                    found.Add(serie);
                                }

                            }

                        }
                        break;
                    case "genre":
                        foreach (Serie serie in MediaPlayer.Series)
                        {
                            foreach (Video video in serie.Episodes)
                            {
                                if (video.Genre.ToLower().Contains(caser[1]))
                                {
                                    found.Add(serie);
                                }

                            }
                        }
                        break;
                    case "actor":
                        foreach (Serie serie in MediaPlayer.Series)
                        {
                            foreach (Video video in serie.Episodes)
                            {
                                foreach (string actor in video.Actors)
                                {
                                    if (actor.ToLower().Contains(caser[1]))
                                    {
                                        found.Add(serie);
                                    }
                                }
                            }
                        }
                        break;

                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Playlist> SearchPlaylist(string filter)
        {
            HashSet<Playlist> found = new HashSet<Playlist>();
            filter = filter.Replace(" ", "");
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "name":
                        foreach (Playlist playlist in MediaPlayer.Playlists)
                        {
                            if (playlist.PlaylistName.ToLower().Contains(caser[1]))
                            {
                                found.Add(playlist);
                            }
                            foreach (Song song in playlist.Songs)
                            {
                                if (song.Name.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                            foreach (Video video in playlist.Videos)
                            {
                                if (video.Name.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                        }
                        break;
                    case "artist":
                        foreach (Playlist playlist in MediaPlayer.Playlists)
                        {
                            foreach (Song song in playlist.Songs)
                            {
                                if (song.Artist.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                            foreach (Video video in playlist.Videos)
                            {
                                foreach (string actor in video.Actors)
                                {
                                    if (actor.ToLower().Contains(caser[1]))
                                    {
                                        found.Add(playlist);
                                    }
                                }
                                if (video.Director.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                        }
                        break;
                    case "genre":
                        foreach (Playlist playlist in MediaPlayer.Playlists)
                        {
                            foreach (Song song in playlist.Songs)
                            {
                                if (song.Genre.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                            foreach (Video video in playlist.Videos)
                            {
                                if (video.Genre.ToLower().Contains(caser[1]))
                                {
                                    found.Add(playlist);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Album> SearchAlbum(string filter)
        {
            HashSet<Album> found = new HashSet<Album>();
            filter = filter.Replace(" ", "");
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');

                switch (caser[0])
                {
                    case "name":
                        foreach (Album album in MediaPlayer.Albums)
                        {
                            if (album.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(album);
                            }
                            foreach (Song song in album.Songs)
                            {
                                if (song.Name.ToLower().Contains(caser[1]))
                                {
                                    found.Add(album);
                                }
                            }
                        }
                        break;
                    case "artist":
                        foreach (Album album in MediaPlayer.Albums)
                        {
                            foreach (string artist in album.Artists)
                            {
                                if (artist.ToLower().Contains(caser[1]))
                                {
                                    found.Add(album);
                                }
                            }
                        }
                        break;
                    case "genre":
                        foreach (Album album in MediaPlayer.Albums)
                        {
                            foreach (Song song in album.Songs)
                            {
                                if (song.Genre.ToLower().Contains(caser[1]))
                                {
                                    found.Add(album);
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;

        }
        public static HashSet<Karaoke> SearchKaraoke(string filter)
        {
            filter = filter.Replace(" ", "");
            HashSet<Karaoke> found = new HashSet<Karaoke>();
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');

                switch (caser[0])
                {
                    case "artist":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (song.Artist.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "name":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (song.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "album":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (song.Album.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "genre":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (song.Genre.ToLower().Contains(caser[1]))
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "explicit":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (caser[1] == "True" && song.ExpliciT)
                            {
                                found.Add(song);
                            }
                            else if (caser[1] == "False" && !song.ExpliciT)
                            {
                                found.Add(song);
                            }
                        }
                        break;
                    case "stars":
                        foreach (Karaoke song in MediaPlayer.Karaokes)
                        {
                            if (caser[1].Contains("<") && caser[1].Contains("="))
                            {
                                if (caser[1].Count()>2)
                                {
                                    string case1 = caser[1].Trim('<', '=');
                                    try
                                    {
                                        if (song.Qualification.Average() <= Convert.ToInt32(case1))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }

                            }
                            else if (caser[1].Contains("<"))
                            {
                                if (caser[1].Count()>1)
                                {
                                    string case1 = caser[1].Trim('<');
                                    try
                                    {
                                        if (song.Qualification.Average() < Convert.ToInt32(case1))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }

                                }
                            }
                            else if (caser[1].Contains(">") && caser[1].Contains("="))
                            {
                                if (caser[1].Count() > 2)
                                {
                                    string case1 = caser[1].Trim('>','=');
                                    try
                                    {
                                        if (song.Qualification.Average() >= Convert.ToInt32(case1))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else if (caser[1].Contains(">"))
                            {
                                if (caser[1].Count() > 1)
                                {
                                    string case1 = caser[1].Trim('>');
                                    try
                                    {
                                        if (song.Qualification.Average() > Convert.ToInt32(case1))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                            else
                            {
                                if (caser[1].Count() > 1)
                                {
                                    string case1 = caser[1].Trim('=');
                                    try
                                    {
                                        if (song.Qualification.Average() == Convert.ToInt32(case1))
                                        {
                                            found.Add(song);
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        throw;
                                    }
                                }
                            }
                        }
                

                break;
                default:
                        break;
            }
        }

            return found;
        }
    }
}
