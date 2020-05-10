using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WMPLib;



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
        



        /*
        public void ImportSong(MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count2 = 0;
            //aqui deberiamos poder importar una cancion
            Console.WriteLine("A continuacion ingrese los datos de la cancion:\n");
            Console.WriteLine("Ingrese el nombre del artista:\n");
            string artist = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del album:\n");
            string album = Console.ReadLine();
            bool response=true;
            bool aux = false;
            while (response)
            {
                Console.WriteLine("Ingrese si la cancion posee contenido explicito(no apto para menores Y/N\n");
                string expliciT=Console.ReadLine();
                if (expliciT=="Y")
                {
                    bool aux = true;
                    response = false;
                }
                else if (expliciT=="N")
                {
                    bool aux = false;
                    response = false;
                }
                else
                {
                    Console.WriteLine("Ingrese una opcion valida\n");                   
                }
            }
            file
            Console.WriteLine(filePath);
            Console.WriteLine("Ingrese el genero de la cancion");
            string genre = Console.ReadLine();
            Console.WriteLine("Ingrese el año de la cancion");
            int year = int.Parse(Console.ReadLine());
            string image = null;
            string destination = Environment.CurrentDirectory;
            System.IO.File.Copy(filePath, destination, true);
            Song song = new Song(artist, album, aux, name, genre, year, image, destination);
            if (mediaPlayer.Songs.Count() == 0)
            {
                mediaPlayer.Songs.Add(song);
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
                    foreach (Album a in mediaPlayer.Albums)
                    {
                        if (a.Name == song.Album)
                        {
                            count2++; 
                            a.Songs.Add(song);
                            if (a.Artists.Contains(song.Artist)==false) a.Artists.Add(song.Artist);
                            a.NumberSongs += 1;

                        }
                    }
                    if (count2 == 0)
                    {
                        List<string> artists = new List<string>();
                        artists.Add(song.Artist);
                        List<Song> songs = new List<Song>();
                        songs.Add(song);
                        Album al = new Album(song.Album, artists,  1, songs);
                        mediaPlayer.Albums.Add(al);
                    }
                }
                else Console.WriteLine("Esa canción ya existe");
            }
        }*/
        public void ImportVideo(Video video,MediaPlayer mediaPlayer)
        {
            int count = 0;
            Console.WriteLine("Ingrese el nombre ");
            if (mediaPlayer.Videos.Count() == 0)
            {
                mediaPlayer.Videos.Add(video);
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
                if (count == 0) mediaPlayer.Videos.Add(video);
                else Console.WriteLine("Ese video ya existe");

            }
        }
        public void Import(Karaoke karaoke, MediaPlayer mediaPlayer)
        {
            int count = 0;
            //aqui deberiamos poder importar una karaoke (cnación + letra)
            if (mediaPlayer.Karaokes.Count() == 0)
            {
                mediaPlayer.Karaokes.Add(karaoke);
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
                if (count == 0) mediaPlayer.Karaokes.Add(karaoke);
                else Console.WriteLine("Ese karaoke ya existe");

            }

        }

        public void ImportSerie(MediaPlayer mediaPlayer, string seriename)
        {
            Series serie = new Series(0, null, seriename);
            //Aqui deberiamos poder importar una serie (solo nombre, videos se agregan despues)
            int count = 0;
            if (mediaPlayer.Series.Count() == 0)
            {
                mediaPlayer.Series.Add(serie);
            }
            else
            {
                foreach (Series i in mediaPlayer.Series)
                {
                    if (i.SerieName == seriename)
                    {
                        count++;
                    }

                }
                if (count == 0) mediaPlayer.Series.Add(serie);
                else Console.WriteLine("Esa serie ya existe\n");
            }
        }

        public void Remove(Song song, MediaPlayer mediaPlayer)
        {
            int count = 0;
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
                }
                if (count == 0) Console.WriteLine("Esa cancion no existe\n");
            }

        }



        public void Remove(Video video, MediaPlayer mediaPlayer)
        {
            int count = 0;
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
                }
                if (count == 0) Console.WriteLine("Ese video no existe\n");
            }

        }

        public void Remove(Karaoke karaoke, MediaPlayer mediaPlayer)
        {
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
        public void OnAddVideoSerie(object source, VideoSerieEventArgs v) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
        {

            v.Serie.Episodes.Add(v.Video);
            Console.WriteLine($"Se ha agregado el video {v.Video.Name} a la serie {v.Serie.SerieName}");

        }

        public void OnDeleteVideoSerie(object source, VideoSerieEventArgs v) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
        {

            v.Serie.Episodes.Remove(v.Video);
            Console.WriteLine($"Se ha eliminado el video {v.Video.Name} a la serie {v.Serie.SerieName}");
        }


    }
}