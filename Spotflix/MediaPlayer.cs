using Spotflix.Media_Related;
using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TagLib.IFD.Tags;

namespace Spotflix
{
    public class MediaPlayer
    {
        public MediaPlayer()
        {

        }
        private HashSet<Song> foundsongs = new HashSet<Song>();
        private HashSet<Video> foundvideos = new HashSet<Video>();
        private HashSet<Serie> foundseries = new HashSet<Serie>();
        private HashSet<Playlist> foundplaylist = new HashSet<Playlist>();
        private HashSet<Album> foundalbums = new HashSet<Album>();
        private HashSet<Karaoke> foundkaraokes = new HashSet<Karaoke>();
        private HashSet<Artist> foundartists = new HashSet<Artist>();
        private List<MediaFile> queue = new List<MediaFile>();
        private HashSet<Lesson> foundlessons = new HashSet<Lesson>();
        private List<Lesson> queuestudent = new List<Lesson>();




        private List<Video> videoChapters =new List<Video>();
        private List<Song> songs = new List<Song>();
        private List<Video> videos = new List<Video>();
        private List<Lesson> lessons = new List<Lesson>();
        private List<Playlist> playlists = new List<Playlist>();
        private List<Serie> series = new List<Serie>();
        private List<Artist> artists = new List<Artist>();
        private List<Karaoke> karaokes = new List<Karaoke>();
        private List<Album> albums = new List<Album>();
        private List<Video> lesson = new List<Video>();
        private List<HomeWork> homeworks = new List<HomeWork>();




        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public List<Lesson> Lessons { get => lessons; set => lessons = value; }
        public List<Playlist> Playlists { get => playlists; set => playlists = value; }
        public List<Serie> Series { get => series; set => series = value; }
        public List<Artist> Artists { get => artists; set => artists = value; }
        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Album> Albums { get => albums; set => albums = value; }
        public HashSet<Song> Foundsongs { get => foundsongs; set => foundsongs = value; }
        public HashSet<Video> Foundvideos { get => foundvideos; set => foundvideos = value; }
        public HashSet<Serie> Foundseries { get => foundseries; set => foundseries = value; }
        public HashSet<Playlist> Foundplaylist { get => foundplaylist; set => foundplaylist = value; }
        public HashSet<Album> Foundalbums { get => foundalbums; set => foundalbums = value; }
        public HashSet<Karaoke> Foundkaraokes { get => foundkaraokes; set => foundkaraokes = value; }
        public List<MediaFile> Queue { get => queue; set => queue = value; }
        public HashSet<Artist> Foundartists { get => foundartists; set => foundartists = value; }
        public List<Video> Lesson { get => lesson; set => lesson = value; }
        public List<Video> VideoChapters { get => videoChapters; set => videoChapters = value; }
        public List<HomeWork> Homeworks { get => homeworks; set => homeworks = value; }
        public HashSet<Lesson> Foundlessons { get => foundlessons; set => foundlessons = value; }
        public List<Lesson> Queuestudent { get => queuestudent; set => queuestudent = value; }

        public void Play(MediaFile mediafile)
        {
            if (!File.Exists(mediafile.Name+".mp4")||!mediafile.Bytes.SequenceEqual(File.ReadAllBytes(mediafile.Name + ".mp4")))
            {
                File.WriteAllBytes(mediafile.Name + ".mp4", mediafile.Bytes);
            }
        }

    }
}
