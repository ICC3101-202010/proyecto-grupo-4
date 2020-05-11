using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WMPLib;
using System.IO;
using System.Text;

namespace Spotflix
{
    [Serializable]
    public class Admin : Person
    {

        private string code;
        private string pass;
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        public Admin()
        {

        }
        public Admin(string code, string pass) { this.code = code; this.pass = pass; }
        public string Code { get => code; set => code = value; }
        public string Pass { get => pass; set => pass = value; }

        
        public void Import(MediaPlayer mediaPlayer)
        {
            WindowsMediaPlayer player = new WindowsMediaPlayer();
            int count = 0;
            int count2 = 0;
            int count3 = 0;
            int countofsongs = 1;
            int choice;
            string route;
            bool succes;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
            Console.WriteLine("Para añadir canciones de forma mas facil, estas deben estar en el siguiente directorio\n{0}\n", dir);
            string[] filePaths = Directory.GetFiles(dir, "*.mp3", SearchOption.TopDirectoryOnly);

            Console.WriteLine("Seleccione la cancion a añadir:\n");
            foreach (string file in filePaths)
            {
                Console.WriteLine("{0} {1}\n",countofsongs,Path.GetFileName(file));
                countofsongs++;
            }
            succes = int.TryParse(Console.ReadLine(),out choice);

            if (succes&&(filePaths.Count()>=(choice-1)))
            {
                route = filePaths[choice-1];
            }
            else
            {
                route = null;
            }
            if (route == null)
            {
                Console.WriteLine("Input invalido, volviendo al menu...");
            }
            else
            {
                TimeSpan lenght = TimeSpan.FromSeconds(player.newMedia(route).duration);
                Console.WriteLine("A continuacion ingrese los datos de la cancion:\n");
                Console.WriteLine("Ingrese el nombre del artista:\n");
                string artist = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del album:\n");
                string album = Console.ReadLine();
                bool response = true;
                bool aux = false;
                while (response)
                {
                    Console.WriteLine("Ingrese si la cancion posee contenido explicito(no apto para menores Y/N\n");
                    string expliciT = Console.ReadLine();
                    if (expliciT == "Y")
                    {
                        aux = true;
                        response = false;
                    }
                    else if (expliciT == "N")
                    {
                        aux = false;
                        response = false;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opcion valida\n");
                    }
                }
                Console.WriteLine("Ingrese el genero de la cancion");
                string genre = Console.ReadLine();
                Console.WriteLine("Ingrese el año de la cancion");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre de la cancion");
                string name = Console.ReadLine();
                string image = null;
                Console.WriteLine(Environment.CurrentDirectory);
                string destination = Path.Combine(Environment.CurrentDirectory+ @"\Songs", Path.GetFileName(filePaths[choice - 1]));
                System.IO.File.Copy(route, destination, true);
                Song song = new Song(artist, album, aux, name, genre, year, image, destination);
                song.Route = destination;
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
                        classa = new Artist(karaokesa, songsa, videosa, namea);
                        mediaPlayer.Artists.Add(classa);
                    }
                    List<string> artists = new List<string>();
                    artists.Add(song.Artist);
                    List<Song> songs = new List<Song>();
                    songs.Add(song);
                    Album al = new Album(song.Album, artists, 1, songs);
                    mediaPlayer.Albums.Add(al);
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
                            classa = new Artist(karaokesa, songsa, videosa, namea);
                            mediaPlayer.Artists.Add(classa);
                        }
                        foreach (Album a in mediaPlayer.Albums)
                        {
                            if (a.Name == song.Album)
                            {
                                count2++;
                                a.Songs.Add(song);
                                if (a.Artists.Contains(song.Artist) == false) a.Artists.Add(song.Artist);
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
                    }
                    else Console.WriteLine("Esa canción ya existe");
                }
            }
        }
        public void ImportSong(Video video, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            //aqui deberiamos poder importar un video
            if (mediaPlayer.Videos.Count() == 0)
            {
                mediaPlayer.Videos.Add(video);
                foreach (Artist a in mediaPlayer.Artists)
                {
                    if (a.Name == video.Director) count3++;
                }
                if (count3 == 0)
                {
                    namea = video.Director;
                    videosa.Add(video);
                    classa = new Artist(karaokesa,songsa, videosa, namea);
                    mediaPlayer.Artists.Add(classa);
                }
                foreach (string actor in video.Actors)
                {
                    int count2 = 0;
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == actor) count2++;
                    }
                    namea = actor;
                    videosa.Add(video);
                    classa = new Artist(karaokesa,songsa, videosa, namea);
                    if (count2 == 0) mediaPlayer.Artists.Add(classa);
                }
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
                        namea = video.Director;
                        videosa.Add(video);
                        classa = new Artist(karaokesa,songsa, videosa, namea);
                        mediaPlayer.Artists.Add(classa);
                    }
                    foreach (string actor in video.Actors)
                    {
                        int count2 = 0;
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (a.Name == actor) count2++;
                        }
                        namea = actor;
                        videosa.Add(video);
                        classa = new Artist(karaokesa, songsa, videosa, namea);
                        if (count2 == 0) mediaPlayer.Artists.Add(classa);
                    }
                }
                else Console.WriteLine("Ese video ya existe");
            }
        }
        public void ImportVideo(Karaoke karaoke, MediaPlayer mediaPlayer)
        {
            int count3 = 0;
            Artist classa;
            string namea;
            List<Karaoke> karaokesa = new List<Karaoke>();
            List<Video> videosa = new List<Video>();
            List<Song> songsa = new List<Song>();

            int count = 0;
            //aqui deberiamos poder importar una karaoke (cnación + letra)
        }



        public void Remove(Song song, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count2 = 0;
            //aqui deberiamos poder remover una cancion
            if (mediaPlayer.Songs.Count() == 0)
            {
                Console.WriteLine("No hay canciones para eliminar\n");
            }
            else
            {
                foreach (Song i in mediaPlayer.Songs)
                {
                    if (i.Name == song.Name && i.Artist == song.Artist)
                    {
                        mediaPlayer.Songs.Remove(song);
                        count++;
                        foreach (Album a in mediaPlayer.Albums)
                        {
                            if (a.Name == song.Album)
                            {
                                a.Songs.Remove(song);
                                if (a.Artists.IndexOf(song.Artist) == 1) a.Artists.Remove(song.Artist);
                                a.NumberSongs -= 1;
                            }
                        }
                    }
                    if (i.Artist == song.Artist) count2++;
                }
                foreach(Karaoke k in mediaPlayer.Karaokes)
                {
                    if (k.Artist == song.Artist) count2++;
                }
                if (count2 == 1)
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == song.Artist) mediaPlayer.Artists.Remove(a);
                    }
                }
                if (count == 0) Console.WriteLine("Esa cancion no existe\n");
            }
        }


        public void Remove(Video video, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count2 = 0;
            //aqui deberiamos poder remover un video
            if (mediaPlayer.Videos.Count() == 0)
            {
                Console.WriteLine("No hay videos para eliminar\n");
            }
            else
            {
                foreach (Video i in mediaPlayer.Videos)
                {
                    if (i.Name == video.Name && i.Director == video.Director)
                    {
                        mediaPlayer.Videos.Remove(video);
                        count++;
                    }
                    if (i.Director == video.Director) count2++;

                }
                foreach (Series s in mediaPlayer.Series)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (v.Director == video.Director) count2++;
                    }
                }

                foreach (Artist a in mediaPlayer.Artists)
                {
                    int count3 = 0;
                    foreach (Video i in mediaPlayer.Videos)
                    {
                        if (i.Name == video.Name)
                        {
                            foreach (string actor in i.Actors)
                            {
                                if (actor == a.Name) count3++;
                            }

                        }
                        
                    }
                    foreach (Series s in mediaPlayer.Series)
                    {
                        foreach (Video v in s.Episodes)
                        {
                            if (v.Name == video.Name)
                            {
                                foreach (string actor in v.Actors)
                                {
                                    if (actor == a.Name) count3++;
                                }

                            }
                            
                        }
                    }
                    if (count3 == 1) mediaPlayer.Artists.Remove(a);
                }
                if (count2 == 1)
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == video.Director) mediaPlayer.Artists.Remove(a);
                    }
                }
                if (count == 0) Console.WriteLine("Ese video no existe\n");

            }
        }

        public void Remove(Karaoke karaoke, MediaPlayer mediaPlayer)
        {
            int count2 = 0;
            int count = 0;
            //aqui deberiamos poder remover un karaoke
            if (mediaPlayer.Karaokes.Count() == 0)
            {
                Console.WriteLine("No hay karaokes para eliminar\n");
            }
            else
            {
                foreach (Karaoke i in mediaPlayer.Karaokes)
                {
                    if (i.Name == karaoke.Name && i.Artist == karaoke.Artist)
                    {
                        mediaPlayer.Karaokes.Remove(karaoke);
                        count++;
                    }
                    if (i.Artist == karaoke.Artist) count2++;

                }
                if (count2 == 1)
                {
                    foreach (Artist a in mediaPlayer.Artists)
                    {
                        if (a.Name == karaoke.Artist) mediaPlayer.Artists.Remove(a);
                    }

                }
                if (count == 0) Console.WriteLine("Ese karaoke no existe\n");
            }
        }


        public void RemoveSerie(MediaPlayer mediaPlayer, string seriename)
        {
            int count = 0;
            //aqui deberiamos poder remover un karaoke
            if (mediaPlayer.Series.Count() == 0)
            {
                Console.WriteLine("No hay series para eliminar\n");
            }
            else
            {
                foreach (Series i in mediaPlayer.Series)
                {
                    if (i.SerieName == seriename)
                    {
                        mediaPlayer.Series.Remove(i);
                        count++;
                    }
                }
                if (count == 0) Console.WriteLine("Esa serie no existe\n");
            }

        }
        public void OnAddVideoSerie(object source, VideoSerieEventArgs v) 
        {
            int count3 = 0;
            Artist classa;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            foreach (Artist a in v.Mediaplayer.Artists)
            {
                if (a.Name == v.Video.Director) count3++;
            }
            if (count3 == 0)
            {
                namea = v.Video.Director;
                videosa.Add(v.Video);
                classa = new Artist(karaokesa, songsa, videosa, namea);
                v.Mediaplayer.Artists.Add(classa);
            }
            foreach (string actor in v.Video.Actors)
            {
                int count2 = 0;
                foreach (Artist a in v.Mediaplayer.Artists)
                {
                    if (a.Name == actor) count2++;
                }
                namea = actor;
                videosa.Add(v.Video);
                classa = new Artist(karaokesa, songsa, videosa, namea);
                if (count2 == 0) v.Mediaplayer.Artists.Add(classa);
            }
            v.Serie.Episodes.Add(v.Video);
            Console.WriteLine($"Se ha agregado el video {v.Video.Name} a la serie {v.Serie.SerieName}");
        }

        public void OnDeleteVideoSerie(object source, VideoSerieEventArgs v) 
        {
            v.Serie.Episodes.Remove(v.Video);
            Console.WriteLine($"Se ha eliminado el video {v.Video.Name} a la serie {v.Serie.SerieName}");
            int count2 = 0;
            
            foreach (Video i in v.Mediaplayer.Videos)
            {
                if (i.Director == v.Video.Director) count2++;
            }
            foreach (Series s in v.Mediaplayer.Series)
            {
                foreach (Video video in s.Episodes)
                {
                    if (v.Video.Director == video.Director) count2++;
                }
            }

            foreach (Artist a in v.Mediaplayer.Artists)
            {
                int count3 = 0;
                foreach (Video i in v.Mediaplayer.Videos)
                {
                    if (i.Name == v.Video.Name)
                    {
                        foreach (string actor in i.Actors)
                        {
                            if (actor == a.Name) count3++;
                        }

                    }

                }
                foreach (Series s in v.Mediaplayer.Series)
                {
                    foreach (Video video in s.Episodes)
                    {
                        if (v.Video.Name == video.Name)
                        {
                            foreach (string actor in video.Actors)
                            {
                                if (actor == a.Name) count3++;
                            }

                        }
                    }
                }
                if (count3 == 1) v.Mediaplayer.Artists.Remove(a);
            }
            if (count2 == 1)
            {
                foreach (Artist a in v.Mediaplayer.Artists)
                {
                    if (a.Name == v.Video.Director) v.Mediaplayer.Artists.Remove(a);
                }
            }
        }


    }
}