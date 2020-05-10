using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;



namespace Spotflix
{
    [Serializable]
    public class Admin : Person
    {

        private string code;
        private string pass;
        WindowsMediaPlayer music = new WindowsMediaPlayer();

        public Admin(string code, string pass) { this.code = code; this.pass = pass; }
        public string Code { get => code; set => code = value; }
        public string Pass { get => pass; set => pass = value; }
        //private IWavePlayer waveOut;
        //private Mp3FileReader mp3FileReader;

        /*
        private IWavePlayer waveOut;
        private Mp3FileReader mp3FileReader;
        private void PlayMp3()
        {
            this.waveOut = new WaveOut(); // or new WaveOutEvent() if you are not using WinForms/WPF
            this.mp3FileReader = new Mp3FileReader("myfile.mp3");
            this.waveOut.Init(mp3FileReader);
            this.waveOut.Play();
            this.waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            this.waveOut.Dispose();
            this.mp3FileReader.Dispose();
        }
        */

        public Admin()
        {
            //aqui deberiamos poder guardar la cancion, esto es de prueba, no funciona
            //InitializeComponent();
            //music.URL = "musica.mp3";
        }


        public void Import(Song song, MediaPlayer mediaPlayer)
        {
            int count = 0;
            int count2 = 0;
            //aqui deberiamos poder importar una cancion
            if (mediaPlayer.Songs.Count() == 0)
            {
                mediaPlayer.Songs.Append(song);
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
                    mediaPlayer.Songs.Append(song);
                    foreach (Album a in mediaPlayer.Albums)
                    {
                        if (a.Name == song.Album)
                        {
                            count2++; 
                            a.Songs.Append(song);
                            if (a.Artists.Contains(song.Artist)==false) a.Artists.Append(song.Artist);
                            a.NumberSongs += 1;

                        }
                    }
                    if (count2 == 0)
                    {
                        List<string> artists = new List<string>();
                        artists.Append(song.Artist);
                        List<Song> songs = new List<Song>();
                        songs.Append(song);
                        Album al = new Album(song.Album, artists,  1, songs);
                        mediaPlayer.Albums.Append(al);
                    }
                }
                else Console.WriteLine("Esa canción ya existe");
            }
        }
        public void Import(Video video, MediaPlayer mediaPlayer)
        {
            int count = 0;
            //aqui deberiamos poder importar un video
            if (mediaPlayer.Videos.Count() == 0)
            {
                mediaPlayer.Videos.Append(video);
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
                if (count == 0) mediaPlayer.Videos.Append(video);
                else Console.WriteLine("Ese video ya existe");

            }
        }
        public void Import(Karaoke karaoke, MediaPlayer mediaPlayer)
        {
            int count = 0;
            //aqui deberiamos poder importar una karaoke (cnación + letra)
            if (mediaPlayer.Karaokes.Count() == 0)
            {
                mediaPlayer.Karaokes.Append(karaoke);
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
                if (count == 0) mediaPlayer.Karaokes.Append(karaoke);
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
                mediaPlayer.Series.Append(serie);
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
                if (count == 0) mediaPlayer.Series.Append(serie);
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