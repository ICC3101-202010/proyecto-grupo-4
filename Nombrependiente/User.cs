using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spotflix
{
    public class User:Person //Falta considerar fin de subscripcion y pagos mensuales
    {
        private int userID;
        private string gmail;
        private string nickname;
        private string password;
        private string membershipType;
        private bool premiunSongs;
        private bool premiunVideo;
        private List<Song> likedSongs = new List<Song>();
        private List<Video> likedVideos = new List<Video>();
        private List<MediaFile> queue = new List<MediaFile>();
        private int screenNumber;
        public User(int userID, string gmail, string nickname, string password, string membershipType,bool premiunSongs,bool premiunVideo,List<Song> likedSongs,
            List<Video> likedvideos,List<MediaFile> queue, int screenNumber,string name, string lastName, int age, string country,string city,string street, string postalCode)
        {
            this.userID = userID;
            this.Gmail = gmail;
            this.Nickname = nickname;
            this.Password = password;
            this.MembershipType = membershipType;
            this.PremiunSongs = premiunSongs;
            this.PremiunVideo = premiunVideo;
            this.LikedSongs = likedSongs;
            this.LikedVideos = likedvideos;
            this.Queue = queue;
            this.ScreenNumber = screenNumber;
            this.Name = name;
            this.Lastname = lastName;
            this.Age = age;
            this.Country = country;
            this.City = city;
            this.Street = street;
            this.PostalCode = postalCode;
        }

        public int UserID { get => userID; set => userID = value; }
        public string Gmail { get => gmail; set => gmail = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public string Password { get => password; set => password = value; }
        public string MembershipType { get => membershipType; set => membershipType = value; }
        public bool PremiunSongs { get => premiunSongs; set => premiunSongs = value; }
        public bool PremiunVideo { get => premiunVideo; set => premiunVideo = value; }
        public List<Song> LikedSongs { get => likedSongs; set => likedSongs = value; }
        public List<Video> LikedVideos { get => likedVideos; set => likedVideos = value; }
        public List<MediaFile> Queue { get => queue; set => queue = value; }
        public int ScreenNumber { get => screenNumber; set => screenNumber = value; }

        public void AddToFavorite(MediaFile mediaFile)
        {

        }
        public Playlist FavoritePlaylist() 
        {
            throw new NotImplementedException();
        }


    }
}