using Spotflix.Media_Related;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Spotflix.User_Related
{
    [Serializable]
    public class User :Person
    {
        private string gmail;
        private string nickname;
        private string membershipType;
        private string privpubl;
        private Image profileimage = Properties.Resources.perfil;
        private List<Song> likedSongs = new List<Song>();
        private List<Video> likedVideos = new List<Video>();
        private List<Karaoke> likedKarokes = new List<Karaoke>();        
        private MediaFile lastsong;
        private int currentSec;

        private List<Playlist> myPlaylist = new List<Playlist>();
        private List<User> followUsers = new List<User>();
        private List<Album> followAlbums = new List<Album>();
        private List<Playlist> followPlaylist = new List<Playlist>();
        private List<Artist> followArtist = new List<Artist>();
        private List<Serie> followSeries = new List<Serie>();
        private List<Teacher> followTeachers = new List<Teacher>();
        private List<Song> songprefered = new List<Song>();
        private List<Video> videoprefered = new List<Video>();


        public User(string gmail, string nickname, string password, string membershipType, string name, string lastName, int age, Image profileimage, string privpubl)
        {
            this.Gmail = gmail;
            this.Nickname = nickname;
            this.Password = password;
            this.Name = name;
            this.Lastname = lastName;
            this.Age = age;
            this.membershipType = membershipType;
            this.profileimage = profileimage;
            this.privpubl = privpubl;
        }
        public User() { }

        public string Gmail { get => gmail; set => gmail = value; }
        public string PrivPubl { get => privpubl; set => privpubl = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string MembershipType { get => membershipType; set => membershipType = value; }
        public List<Song> LikedSongs { get => likedSongs; set => likedSongs = value; }
        public List<Video> LikedVideos { get => likedVideos; set => likedVideos = value; }
        public List<Playlist> MyPlaylist { get => myPlaylist; set => myPlaylist = value; }
        public List<User> FollowUsers { get => followUsers; set => followUsers = value; }
        public List<Album> FollowAlbums { get => followAlbums; set => followAlbums = value; }
        public List<Playlist> FollowPlaylist { get => followPlaylist; set => followPlaylist = value; }
        public List<Artist> FollowArtist { get => followArtist; set => followArtist = value; }
        public List<Serie> FollowSeries { get => followSeries; set => followSeries = value; }
        public List<Teacher> FollowTeachers { get => followTeachers; set => followTeachers = value; }
        public Image Profileimage { get => profileimage; set => profileimage = value; }
        public int CurrentSec { get => currentSec; set => currentSec = value; }
        public MediaFile Lastsong { get => lastsong; set => lastsong = value; }
        public List<Song> Songprefered { get => songprefered; set => songprefered = value; }
        public List<Video> Videoprefered { get => videoprefered; set => videoprefered = value; }
        public List<Karaoke> LikedKarokes { get => likedKarokes; set => likedKarokes = value; }

        public Playlist NewPlaylist(string publicornot, string name, Image image)
        {
            int count = 0;
            foreach (Playlist p in this.myPlaylist)
            {
                if (p.PlaylistName == name)
                {
                    count++;
                }
            }
            if (count == 0)
            {
                Playlist p = new Playlist();
                p.PlaylistName = name;
                p.Publicornot = publicornot;
                if (image != null)
                {
                    p.Image = image;
                }
                else
                {
                    p.Image = Spotflix.Properties.Resources.chooseImage;
                }
                this.myPlaylist.Add(p);
                return p;

            }
            else
            {
                return null;
            }
        }

    }
}
