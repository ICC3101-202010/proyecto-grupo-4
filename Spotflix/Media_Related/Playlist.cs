using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Playlist
    {
        List<Song> songs = new List<Song>();
        List<Video> videos = new List<Video>();
        List<Karaoke> karaokes = new List<Karaoke>();
        List<Lesson> lessons = new List<Lesson>();
        private string playlistName;
        User userowner;
        private string publicornot;
        private Image image;
        private string filter = "";



        public Playlist() { }


        public List<Song> Songs { get => songs; set => songs = value; }
        public List<Video> Videos { get => videos; set => videos = value; }
        public string PlaylistName { get => playlistName; set => playlistName = value; }
        public User Userowner { get => userowner; set => userowner = value; }
        public string Publicornot { get => publicornot; set => publicornot = value; }
        public Image Image { get => image; set => image = value; }
        public string Filter { get => filter; set => filter = value; }
        public List<Karaoke> Karaokes { get => karaokes; set => karaokes = value; }
        public List<Lesson> Lessons { get => lessons; set => lessons = value; }
    }
}
