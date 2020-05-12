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


namespace Spotflix
{
    [Serializable]
    public class Admin : Person
    {

        private string code;
        private string pass;
        private string gmaila;
        private string namea;
        private List<Song> downloadSongs = new List<Song>();

        public Admin()
        {

        }
        public Admin(string namea, string gmaila, string code, string pass) { this.Namea = namea; this.Gmaila = gmaila; this.code = code; this.pass = pass; }
        public string Code { get => code; set => code = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Gmaila { get => gmaila; set => gmaila = value; }
        public string Namea { get => namea; set => namea = value; }
        public List<Song> DownloadSongs { get => downloadSongs; set => downloadSongs = value; }

        public void ImportSong(MediaPlayer mediaPlayer)
        {
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
            string[] filters = new[] { "*.wav" };
            string[] filePaths = filters.SelectMany(f => Directory.GetFiles(dir, f)).ToArray();

            Console.WriteLine("Seleccione la cancion a añadir:\n");
            foreach (string file in filePaths)
            {
                Console.WriteLine("{0} {1}\n", countofsongs, Path.GetFileName(file));
                countofsongs++;
            }
            succes = int.TryParse(Console.ReadLine(), out choice);

            if (succes && (filePaths.Count() >= (choice - 1)))
            {
                route = filePaths[choice - 1];
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
                //TimeSpan lenght = TimeSpan.FromSeconds(player.newMedia(route).duration);
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
                string destination = Path.Combine(Environment.CurrentDirectory + @"\Songs", Path.GetFileName(filePaths[choice - 1]));
                System.IO.File.Copy(route, destination, true);
                long fileSize = new System.IO.FileInfo(destination).Length;
                Song song = new Song(artist, album, aux, name, genre, year, image, destination);
                song.Route = destination;
                song.FileSize = fileSize;
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
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (song.Artist == a.Name && a.Songs.IndexOf(song) == 0) a.Songs.Add(song);

                        }

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
                        else
                        {
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (song.Artist == a.Name && a.Songs.IndexOf(song) == 0) a.Songs.Add(song);

                            }

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
        }//Listo
        public void ImportVideo(MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count3 = 0;
            int choice;
            int countofvideos = 1;
            Artist classa;
            string route;
            bool succes = false;
            string namea;
            List<Song> songsa = new List<Song>();
            List<Video> videosa = new List<Video>();
            List<Karaoke> karaokesa = new List<Karaoke>();
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            Console.WriteLine("Para añadir canciones de forma mas facil, estas deben estar en el siguiente directorio\n{0}\n", dir);
            string[] filters = new[] { "*.mp4" };
            string[] filePaths = filters.SelectMany(f => Directory.GetFiles(dir, f)).ToArray();
            Console.WriteLine("Seleccione la cancion a añadir:\n");
            foreach (string file in filePaths)
            {
                Console.WriteLine("{0} {1}\n", countofvideos, Path.GetFileName(file));
                countofvideos++;
            }
            succes = int.TryParse(Console.ReadLine(), out choice);

            if (succes && (filePaths.Count() >= (choice - 1)))
            {
                route = filePaths[choice - 1];
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
                //TimeSpan lenght = TimeSpan.FromSeconds(player.newMedia(route).duration);
                Console.WriteLine("A continuacion ingrese los datos de la cancion:\n");
                Console.WriteLine("Ingrese el nombre del director\n");
                string director = Console.ReadLine();
                Console.WriteLine("Ingrese el nombre del estudio:\n");
                string studio = Console.ReadLine();
                Console.WriteLine("Ingrese el genero del video");
                string genre = Console.ReadLine();
                Console.WriteLine("Ingrese el año del vdieo");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del video");
                string name = Console.ReadLine();
                string image = null;
                string stopper = "0";
                List<String> actors = new List<string>();
                while (stopper == "0")
                {
                    Console.WriteLine("Ingrese los actores:(Ingrese 0 cuando haya terminado)\n");
                    string temp = Console.ReadLine();
                    if (temp != "0") actors.Append(temp);
                }
                Console.WriteLine("Ingrese desde que edad se puede ver el video: \n");
                string age = Console.ReadLine();
                string destination = Path.Combine(Environment.CurrentDirectory + @"\Videos", Path.GetFileName(filePaths[choice - 1]));
                System.IO.File.Copy(route, destination, true);
                long fileSize = new System.IO.FileInfo(destination).Length;
                Video video = new Video(actors, age, director, studio, name, genre, image, year, destination);
                video.Route = destination;
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
                        namea = video.Director;
                        videosa.Add(video);
                        classa = new Artist(karaokesa, songsa, videosa, namea);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (video.Director == a.Name && a.Videos.IndexOf(video) == 0) a.Videos.Add(video);

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
                        videosa.Add(video);
                        classa = new Artist(karaokesa, songsa, videosa, namea);
                        if (count2 == 0) mediaPlayer.Artists.Add(classa);
                        else
                        {
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (actor == a.Name && a.Videos.IndexOf(video) == 0) a.Videos.Add(video);

                            }
                        }
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
                            classa = new Artist(karaokesa, songsa, videosa, namea);
                            mediaPlayer.Artists.Add(classa);
                        }
                        else
                        {
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (video.Director == a.Name && a.Videos.IndexOf(video) == 0) a.Videos.Add(video);

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
                            videosa.Add(video);
                            classa = new Artist(karaokesa, songsa, videosa, namea);
                            if (count2 == 0) mediaPlayer.Artists.Add(classa);
                            else
                            {
                                foreach (Artist a in mediaPlayer.Artists)
                                {
                                    if (actor == a.Name && a.Videos.IndexOf(video) == 0) a.Videos.Add(video);

                                }
                            }
                        }
                    }
                    else Console.WriteLine("Ese video ya existe");
                }
            }
        }//Listo
        public void ImportKaraoke(MediaPlayer mediaPlayer)
        {
            int count = 0;
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
            string[] filters = new[] { "*.mp3", "*.wav" };
            string[] filePaths = filters.SelectMany(f => Directory.GetFiles(dir, f)).ToArray();

            Console.WriteLine("Seleccione la cancion de karaoke a añadir:\n");
            foreach (string file in filePaths)
            {
                Console.WriteLine("{0} {1}\n", countofsongs, Path.GetFileName(file));
                countofsongs++;
            }
            succes = int.TryParse(Console.ReadLine(), out choice);

            if (succes && (filePaths.Count() >= (choice - 1)))
            {
                route = filePaths[choice - 1];
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
                Console.WriteLine("A continuacion ingrese los datos de la cancion del karaoke:\n");
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
                string destination = Path.Combine(Environment.CurrentDirectory + @"\Karaoke", Path.GetFileName(filePaths[choice - 1]));
                System.IO.File.Copy(route, destination, true);
                long fileSize = new System.IO.FileInfo(destination).Length;


                Console.WriteLine("Ingrese la ruta del archivo txt con la letra de la canción que quiere agregar");
                string file = Console.ReadLine();
                List<string> lyrics = System.IO.File.ReadLines(file).ToList();


                Karaoke karaoke = new Karaoke(lyrics, artist, album, aux, name, genre, year, image, destination);
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
                        classa = new Artist(karaokesa, songsa, videosa, namea);
                        mediaPlayer.Artists.Add(classa);
                    }
                    else
                    {
                        foreach (Artist a in mediaPlayer.Artists)
                        {
                            if (karaoke.Artist == a.Name && a.Karaokes.IndexOf(karaoke) == 0) a.Karaokes.Add(karaoke);

                        }
                    }
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
                            classa = new Artist(karaokesa, songsa, videosa, namea);
                            mediaPlayer.Artists.Add(classa);
                        }
                        else
                        {
                            foreach (Artist a in mediaPlayer.Artists)
                            {
                                if (karaoke.Artist == a.Name && a.Karaokes.IndexOf(karaoke) == 0) a.Karaokes.Add(karaoke);

                            }
                        }
                    }
                    else Console.WriteLine("Esa canción ya existe");
                }
            }
        }//Listo


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
                if (a.Name.ToLower() == v.Video.Director.ToLower()) count3++;
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
                    if (a.Name.ToLower() == actor.ToLower()) count2++;
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
                if (i.Director.ToLower() == v.Video.Director.ToLower()) count2++;
            }
            foreach (Series s in v.Mediaplayer.Series)
            {
                foreach (Video video in s.Episodes)
                {
                    if (v.Video.Director.ToLower() == video.Director.ToLower()) count2++;
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