using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Spotflix
{
    [Serializable]
    public class User : Person //Falta considerar fin de subscripcion y pagos mensuales
    {
        private int userID;
        private string gmail;
        private string nickname;
        private string membershipType;
        private bool premiunSongs;
        private bool premiunVideo;
        private List<Song> likedSongs = new List<Song>();
        private List<Video> likedVideos = new List<Video>();
        private int screenNumber;
        private List<Playlist> likedPlaylist = new List<Playlist>();


        public User(int userID, string gmail, string nickname, string password, string name, string lastName, int age, string country, string city, string street, string postalCode)
        {
            this.userID = userID;
            this.Gmail = gmail;
            this.Nickname = nickname;
            this.Password = password;
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
        public string MembershipType { get => membershipType; set => membershipType = value; }
        public bool PremiunSongs { get => premiunSongs; set => premiunSongs = value; }
        public bool PremiunVideo { get => premiunVideo; set => premiunVideo = value; }
        public List<Song> LikedSongs { get => likedSongs; set => likedSongs = value; }
        public List<Video> LikedVideos { get => likedVideos; set => likedVideos = value; }
        public int ScreenNumber { get => screenNumber; set => screenNumber = value; }
        public List<Playlist> LikedPlaylist { get => likedPlaylist; set => likedPlaylist = value; }

        public void AddToFavorite(Song song) //listo
        {
            if (LikedSongs.Count() == 0)
            {
                LikedSongs.Append(song);
            }
            else
            {
                foreach (Song i in LikedSongs)
                {
                    if (song.Artist == i.Artist && song.Name == i.Name)
                    {

                    }
                    else
                    {
                        LikedSongs.Append(song);
                    }
                }
            }
        }

        public void AddToFavorite(Video video) // listo
        {
            if (LikedVideos.Count() == 0)
            {
                LikedVideos.Append(video);
            }
            else
            {
                foreach (Video i in LikedVideos)
                {
                    if (video.Actors == i.Actors && video.Name == i.Name)
                    {

                    }
                    else
                    {
                        LikedVideos.Append(video);
                    }
                }
            }
        }


        public Playlist FavoritePlaylist() //falta
        {
            throw new NotImplementedException();
        }

        /* public void Follow()
         {
             MediaPlayer.Follow();
         }
         public void Close()
         {
             MediaPlayer.Close();
         }
         public void DownloadSong()
         {
             MediaPlayer.DownloadSong();
         }
         public void AddFile(Song song)
         {
             MediaPlayer.AddFile();
         }
         public void AddFile(Video video)
         {
             MediaPlayer.AddFile();
         }
         */
        public void OnAddSong(object source, SongEventArgs so)
        {
            int counter = 0;
            foreach (Song s in so.PlayList.Songs)
            {
                if (so.Song == s)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                so.PlayList.Songs.Add(so.Song);
                Console.WriteLine($"Se ha agregado la canción {so.Song.Name} a su Playlist {so.PlayList.PlaylistName}");
            }
            else
            {
                Console.WriteLine("La canción ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    so.PlayList.Songs.Add(so.Song);
                    Console.WriteLine($"Se ha agregado la canción {so.Song.Name} a su Playlist {so.PlayList.PlaylistName}");
                }
            }
        }

        public void OnDeleteSong(object source, SongEventArgs so)
        {
            int count = 0;
            foreach (Song s in so.PlayList.Songs)
            {
                if (s == so.Song)
                {
                    count += 1;

                }
            }
            if (count != 0)
            {
                so.PlayList.Songs.Remove(so.Song);
                Console.WriteLine($"Se ha eliminado la canción {so.Song.Name} de su Playlist {so.PlayList.PlaylistName}");
            }
            else Console.WriteLine("La canción no se encontraba en su PlayList.");
        }

        public void OnAddVideo(object source, VideoEventArgs so)
        {
            int counter = 0;
            foreach (Video v in so.PlayList.Videos)
            {
                if (so.Video == v)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                so.PlayList.Videos.Add(so.Video);
                Console.WriteLine($"Se ha agregado el video {so.Video.Name} a su Playlist {so.PlayList.PlaylistName}");
            }
            else
            {
                Console.WriteLine("El video ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    so.PlayList.Videos.Add(so.Video);
                    Console.WriteLine($"Se ha agregado el video {so.Video.Name} a su Playlist {so.PlayList.PlaylistName}");
                }
            }
        }

        public void OnDeleteVideo(object source, VideoEventArgs so)
        {
            int counter = 0;
            foreach (Video v in so.PlayList.Videos)
            {
                if (v == so.Video)
                {
                    counter += 1;
                }
            }
            if (counter != 0)
            {
                so.PlayList.Videos.Remove(so.Video);
                Console.WriteLine($"Se ha eliminado el video {so.Video.Name} de su Playlist {so.PlayList.PlaylistName}");
            }
            else Console.WriteLine("El video no se encontraba en su PlayList");
        }

    }

}
