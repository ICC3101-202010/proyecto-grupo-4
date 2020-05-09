using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;



namespace Spotflix
{
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


        public void Import(Song song,MediaPlayer mediaPlayer) 
        {
            //aqui deberiamos poder importar una cancion
            if (mediaPlayer.Songs.Count() == 0)
            {
               mediaPlayer.Songs.Append(song);  
            }
            foreach (Song i in mediaPlayer.Songs)
            {
                if (i.Name == song.Name && i.Artist == song.Artist)
                {
                    Console.WriteLine("Esa cancion ya existe\n");
                }
                else
                {
                    mediaPlayer.Songs.Append(song);
                }

            }
        }
        public void Import(Video video,MediaPlayer mediaPlayer)
        {
            //aqui deberiamos poder importar una cancion
            if (mediaPlayer.Videos.Count() == 0)
            {
                mediaPlayer.Videos.Append(video);
            }
            foreach (Video i in mediaPlayer.Videos)
            {
                if (i.Name == video.Name && i.Director == video.Director)
                {
                    Console.WriteLine("Ese video ya existe\n");
                }
                else
                {
                    mediaPlayer.Videos.Append(video);
                }

            }
        }
        public void Remove(Song song,MediaPlayer mediaPlayer) 
        {
            //aqui deberiamos poder importar una cancion
            if (mediaPlayer.Songs.Count() == 0)
            {
                Console.WriteLine("No hay canciones para eliminar\n");
            }
            foreach (Song i in mediaPlayer.Songs)
            {
                if (i.Name == song.Name && i.Artist == song.Artist)
                {
                    mediaPlayer.Songs.Remove(song);                    
                }
                else
                {
                    Console.WriteLine("Esa cancion no existe\n");
                }
            }
        }
        public void Remove(Video video,MediaPlayer mediaPlayer)
        {
            //aqui deberiamos poder importar una cancion
            if (mediaPlayer.Videos.Count() == 0)
            {
                Console.WriteLine("No hay videos para eliminar\n");
            }
            foreach (Video i in mediaPlayer.Videos)
            {
                if (i.Name == video.Name && i.Director == video.Director)
                {
                    mediaPlayer.Videos.Remove(video);
                }
                else
                {
                    Console.WriteLine("Ese video no existe\n");
                }
            }
        }

    }
}