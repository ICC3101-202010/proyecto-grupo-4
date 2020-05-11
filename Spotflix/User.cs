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
        private List<Song> downloadSongs = new List<Song>();

        private int screenNumber;
        private List<Playlist> likedPlaylist = new List<Playlist>();
        private List<Playlist> myPlaylist = new List<Playlist>();
        private List<User> followUsers = new List<User>();
        private List<Album> followAlbums = new List<Album>();
        private List<Playlist> followPlaylist = new List<Playlist>();
        private List<Artist> followArtist = new List<Artist>();
        private List<Series> followSeries = new List<Series>();
        



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
        public User() { }

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
        public List<Playlist> MyPlaylist { get => myPlaylist; set => myPlaylist = value; }
        public List<User> FollowUsers { get => followUsers; set => followUsers = value; }
        public List<Album> FollowAlbums { get => followAlbums; set => followAlbums = value; }
        public List<Playlist> FollowPlaylist { get => followPlaylist; set => followPlaylist = value; }
        public List<Artist> FollowArtist { get => followArtist; set => followArtist = value; }
        public List<Series> FollowSeries { get => followSeries; set => followSeries = value; }
        public List<Song> DownloadSongs { get => downloadSongs; set => downloadSongs = value; }

        public void AddToFavorite(Song song) //listo
        {
            if (LikedSongs.Count() == 0)
            {
                LikedSongs.Add(song);
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
                        LikedSongs.Add(song);
                    }
                }
            }
        }

        public void AddToFavorite(Video video) // listo
        {
            if (LikedVideos.Count() == 0)
            {
                LikedVideos.Add(video);
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
                        LikedVideos.Add(video);
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

            foreach (Playlist p in myPlaylist)
            {
                foreach (Song cancion in p.Songs)
                {
                    if (so.Song == cancion) counter += 1;
                }
            }
            if (counter == 0)
            {
                so.PlayList.Songs.Add(so.Song);
                Console.WriteLine($"Se ha agregado la canción {so.Song.Name} a su Playlist {so.PlayList.PlaylistName}");
                foreach (Playlist p in myPlaylist)
                {
                    if (p.PlaylistName==so.PlayList.PlaylistName) p.Songs.Add(so.Song);
                }
            }
            else
            {
                Console.WriteLine("La canción ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    so.PlayList.Songs.Add(so.Song);
                    Console.WriteLine($"Se ha agregado la canción {so.Song.Name} a su Playlist {so.PlayList.PlaylistName}");
                    foreach (Playlist p in myPlaylist)
                    {
                        if (p.PlaylistName == so.PlayList.PlaylistName) p.Songs.Add(so.Song);
                    }
                }
            }
        }

        public void OnDeleteSong(object source, SongEventArgs so)
        {
            int counter = 0;

            foreach (Playlist p in myPlaylist)
            {
                foreach (Song cancion in p.Songs)
                {
                    if (so.Song == cancion) counter += 1;
                }
            }
            if (counter != 0)
            {
                so.PlayList.Songs.Remove(so.Song);
                Console.WriteLine($"Se ha eliminado la canción {so.Song.Name} a su Playlist {so.PlayList.PlaylistName}");
                foreach (Playlist p in myPlaylist)
                {
                    if (p.PlaylistName == so.PlayList.PlaylistName) p.Songs.Remove(so.Song);
                }
            }
            else
            {
                Console.WriteLine("La canción no se encuentra en su playList.");
                
            }
        }

        public void OnAddVideo(object source,VideoEventArgs so)
        {
            int counter = 0;

            foreach (Playlist p in myPlaylist)
            {
                foreach (Video video in p.Videos)
                {
                    if (so.Video == video) counter += 1;
                }
            }
            if (counter == 0)
            {
                so.PlayList.Videos.Add(so.Video);
                Console.WriteLine($"Se ha agregado el video {so.Video.Name} a su Playlist {so.PlayList.PlaylistName}");
                foreach (Playlist p in myPlaylist)
                {
                    if (p.PlaylistName == so.PlayList.PlaylistName) p.Videos.Add(so.Video);
                }
            }
            else
            {
                Console.WriteLine("El video ya se encuentra en su playList. ¿Desea agregarlo de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí")
                {
                    so.PlayList.Videos.Add(so.Video);
                    Console.WriteLine($"Se ha agregado el video {so.Video.Name} a su Playlist {so.PlayList.PlaylistName}");
                    foreach (Playlist p in myPlaylist)
                    {
                        if (p.PlaylistName == so.PlayList.PlaylistName) p.Videos.Add(so.Video);
                    }
                }
            }
        }

        public void OnDeleteVideo(object source, VideoEventArgs so)
        {
            int counter = 0;

            foreach (Playlist p in myPlaylist)
            {
                foreach (Video video in p.Videos)
                {
                    if (so.Video == video) counter += 1;
                }
            }
            if (counter != 0)
            {
                so.PlayList.Videos.Remove(so.Video);
                Console.WriteLine($"Se ha eliminado el video {so.Video.Name} a su Playlist {so.PlayList.PlaylistName}");
                foreach (Playlist p in myPlaylist)
                {
                    if (p.PlaylistName == so.PlayList.PlaylistName) p.Videos.Remove(so.Video);
                }
            }
            else
            {
                Console.WriteLine("El video no se encuentra en su playList.");

            }
        }
        public Playlist ShowPlaylistSong()
        {
            int choice = 0;

            if (MyPlaylist.Count() != 0)
            {
                Console.WriteLine("Seleccione una playlist:\n");
                while (choice != -1)
                {
                    foreach (Playlist play in this.MyPlaylist)
                    {
                        Console.WriteLine("\t{0} {1}\n", this.MyPlaylist.IndexOf(play) + 1, play.PlaylistName);
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
                            foreach(Song playy in MyPlaylist[choice-1].Songs)
                            {
                                Console.WriteLine("\t{0} {1}\n", this.MyPlaylist[choice-1].Songs.IndexOf(playy) + 1, playy.Name);
                            }
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
                Console.WriteLine("No se encontraron playlist");
                return null;
            }
        }
    }

}
