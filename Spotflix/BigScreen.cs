using Microsoft.WindowsAPICodePack.Shell;
using Spotflix.Media_Related;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotflix
{
    public partial class BigScreen : Form
    {
        List<MediaFile> Queue = new List<MediaFile>();
        MediaFile currentlyPlaying;
        MediaPlayer mediaPlayer;
        int lyric;
        int index;

        public List<MediaFile> Queue1 { get => Queue; set => Queue = value; }
        public MediaFile CurrentlyPlaying { get => currentlyPlaying; set => currentlyPlaying = value; }
        public MediaPlayer MediaPlayer { get => mediaPlayer; set => mediaPlayer = value; }
        public int Lyric { get => lyric; set => lyric = value; }
        public int Index { get => index; set => index = value; }
        public int getSound()
        {
            return BigSound.Value;
        }
        public int getSecond()
        {
            return progressBar1.Value;
        }

        public BigScreen(List<MediaFile> Queue, MediaFile currentlyplayling, MediaPlayer player, double curr,int value, int index, int lyric, int sound,int max)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            this.Queue1 = Queue;
            this.CurrentlyPlaying = currentlyplayling;
            this.MediaPlayer = player;
            this.Index = index;
            SmallScreen.BackgroundImage = Properties.Resources.minimize_screen;
            CustomPlay();
            BigPlayer.Ctlcontrols.currentPosition = curr;
            BigSound.Value = sound;
            progressBar1.Maximum = max;
            BigPlayer.settings.volume = sound;
            PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
            PlayPausaButtom.Tag = "play";
            CustomPlay();
            progressBar1.Value += value;

        }

        private void SmallScreen_Click(object sender, EventArgs e)
        {
            BigPlayer.Ctlcontrols.stop();
            this.Close();
        }
        private void CustomPlay()
        {
            if (Index < MediaPlayer.Queue.Count())
            {
                NextSong.Start();
                BigPlayer.Ctlcontrols.stop();

                MediaFile mediafile = MediaPlayer.Queue[Index];
                CurrentlyPlaying = mediafile;
                MediaPlayer.Play(mediafile);
                BigPlayer.URL = CurrentlyPlaying.Name + ".mp4";
                bool karaoke = MediaPlayer.Karaokes.Any(u => u.Bytes.SequenceEqual(mediafile.Bytes));
                if (karaoke)
                {
                    Lyric = 0;
                    Karaoke aux = MediaPlayer.Karaokes.Where(u => u.Bytes.SequenceEqual(mediafile.Bytes)).FirstOrDefault();
                    KaraokeTimer.Enabled = true;
                    if (Convert.ToDouble(aux.Lyrics[Lyric]) == 0)
                    {
                        KaraokeTimer.Interval = 1000;
                    }
                    else
                    {
                        double a = Convert.ToDouble(aux.Lyrics[Lyric]);
                        a += Convert.ToDouble(aux.Lyrics[Lyric + 2]) / 2;
                        KaraokeTimer.Interval = Convert.ToInt32(Math.Truncate(a));
                    }
                    karaokeText.SelectionAlignment = HorizontalAlignment.Center;
                    karaokeText.Text = aux.Lyrics[Lyric + 1];
                    karaokeText.Text += aux.Lyrics[Lyric + 3];
                    karaokeText.Text += aux.Lyrics[Lyric + 5];
                    karaokeText.Visible = true;
                    karaokeText.BringToFront();
                }
                else
                {
                    karaokeText.Visible = false;
                    karaokeText.SendToBack();
                    Lyric = 0;

                }
                double secs = Math.Truncate(CurrentlyPlaying.Length.TotalSeconds);
                progressBar1.Value = 0;
                progressBar1.Maximum = Convert.ToInt32(secs);
                NextSong.Interval = progressBar1.Maximum * 1000;
                BigPlayer.URL = CurrentlyPlaying.Name + ".mp4";
                BigPlayer.Ctlcontrols.play();
                NextSong.Enabled = true;
                GC.Collect();

            }
        }

        private void BackPlayer_Click(object sender, EventArgs e)
        {
            if (Index >= 1)
            {
                Index--;
                CustomPlay();
            }
            else
            {
                CustomPlay();
            }
        }

        private void NextPlay_Click(object sender, EventArgs e)
        {
            if (MediaPlayer.Queue.Count() > Index + 1)
            {
                Index++;
                CustomPlay();
            }
            else
            {
                CustomPlay();
            }
        }

        private void PlayPausaButtom_Click(object sender, EventArgs e)
        {
            if (PlayPausaButtom.Tag.ToString() == "pause")
            {
                BigPlayer.Ctlcontrols.pause();
                PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
                PlayPausaButtom.Tag = "play";
            }
            else
            {
                BigPlayer.Ctlcontrols.play();

                PlayPausaButtom.BackgroundImage = Properties.Resources.pausa140;
                PlayPausaButtom.Tag = "pause";
            }
        }

        private void BigSound_Scroll(object sender, EventArgs e)
        {
            BigPlayer.settings.volume = BigSound.Value;
        }

        private void NextSong_Tick(object sender, EventArgs e)
        {
            Index++;
            CustomPlay();
        }

        private void KaraokeTimer_Tick(object sender, EventArgs e)
        {
            Lyric += 2;
            if ((Lyric + 1) % 3 == 0)
            {
                try
                {
                    Karaoke aux = MediaPlayer.Karaokes.Where(u => u.Bytes.SequenceEqual(CurrentlyPlaying.Bytes)).FirstOrDefault();
                    KaraokeTimer.Enabled = true;
                    if (Convert.ToDouble(aux.Lyrics[Lyric]) == 0)
                    {
                        KaraokeTimer.Interval = 1000;
                    }
                    else
                    {
                        double a = Convert.ToDouble(aux.Lyrics[Lyric]);
                        a += Convert.ToDouble(aux.Lyrics[Lyric + 2]) / 3;
                        KaraokeTimer.Interval = Convert.ToInt32(Math.Truncate(a));
                    }
                    karaokeText.Text = "";
                    karaokeText.Text += aux.Lyrics[Lyric + 1];
                    karaokeText.Text += aux.Lyrics[Lyric + 3];
                    karaokeText.Text += aux.Lyrics[Lyric + 5];
                    karaokeText.BringToFront();
                }
                catch (IndexOutOfRangeException)
                {

                    throw;
                }

            }
        }

        private void CurrentSong_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }

        private void BigPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (CurrentlyPlaying is null)
            {

            }
            else
            {
                if (e.newState == 8)
                {
                    CurrentlyPlaying.NumberOfReproductions++;
                }
                if (e.newState == 8)
                {
                    progressBar1.Value = 0;
                }
                if (e.newState == 3)
                {
                    PlayPausaButtom.BackgroundImage = Properties.Resources.pausa140;
                    PlayPausaButtom.Tag = "pause";
                    CurrentSong.Start();
                    NextSong.Start();
                    if (KaraokeTimer.Enabled)
                    {
                        KaraokeTimer.Start();
                    }
                }
                if (e.newState == 2)
                {
                    PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
                    PlayPausaButtom.Tag = "play";
                    CurrentSong.Stop();
                    NextSong.Stop();
                    if (KaraokeTimer.Enabled)
                    {
                        KaraokeTimer.Stop();
                    }
                }
                if (e.newState == 1)
                {
                    PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
                    PlayPausaButtom.Tag = "play";
                    CurrentSong.Stop();
                    NextSong.Stop();
                    if (KaraokeTimer.Enabled)
                    {
                        KaraokeTimer.Stop();
                    }
                }
                if (e.newState == 6)
                {
                    progressBar1.Value = 0;
                }
            }
        }
    }
}