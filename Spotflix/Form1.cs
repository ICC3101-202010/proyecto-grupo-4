using Spotflix.Media_Related;
using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using WMPLib;

namespace Spotflix
{
    public partial class Form1 : Form
    {
        //OBJETOS
        User currentUser;
        Student currentStudent;
        Teacher currentTeacher;
        MediaPlayer mediaPlayer = new MediaPlayer();
        MediaFile currentlyPlaying;
        Lesson currentlyLessonPlaying;
        int index;
        int lyric=0;

        //SERIALIZACIONES
        private void SaveSong()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Songs.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Songs);
                    stream.Close();
                }


            }
            catch (IOException)
            {
                SaveSong();
            }

        }
        private void LoadSong()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Songs.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Songs = (List<Song>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveVideo()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Videos.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Videos);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveVideo();
            }

        }
        private void LoadVideo()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Videos.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Videos = (List<Video>)formatter.Deserialize(stream);
                stream.Close();
             }
        }

        private void SaveVideoT()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\VideosT.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Lesson);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveVideoT();
            }

        }
        private void LoadVideoT()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\VideosT.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Lesson = (List<Video>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveLesson()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Lesson.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Lessons);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {

                SaveLesson();
            }

        }
        private void LoadLesson()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Lesson.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Lessons = (List<Lesson>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveKaroke()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Karaokes.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Karaokes);
                    stream.Close();
                }

            }
            catch (IOException)
            {
                SaveKaroke();
            }

        }
        private void LoadKaraoke()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Karaokes.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Karaokes = (List<Karaoke>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveSeries()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Series.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {

                    formatter.Serialize(stream, mediaPlayer.Series);
                    stream.Close();
                }

            }
            catch (System.IO.IOException)
            {
                SaveSeries();
            }

        }
        private void LoadSeries()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Series.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Series = (List<Serie>)formatter.Deserialize(stream);
                foreach (Serie serie in mediaPlayer.Series)
                {
                    mediaPlayer.VideoChapters.AddRange(serie.Episodes);
                }
                stream.Close();
            }
           
        }

        private void SavePlaylist()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Playlists.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Playlists);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SavePlaylist();
            }

        }
        private void LoadPlaylist()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Playlists.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Playlists = (List<Playlist>)formatter.Deserialize(stream);
                stream.Close();
            }
        }
       
        private void SaveArtist()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Artists.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Artists);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveArtist();
            }

        }
        private void LoadArtist()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Artists.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Artists = (List<Artist>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveAlbum()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Albums.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Albums);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveAlbum();
            }
        }
        private void LoadAlbum()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Albums.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Albums = (List<Album>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveUser()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\User.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, Gate.Users);
                    stream.Close();
                }

            }
            catch (IOException)
            {
                SaveUser();
            }

        }
        private void LoadUser()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\User.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                Gate.Users = (List<User>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveTeacher()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Teacher.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, Gate.Teachers);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveTeacher();
            }

        }
        private void LoadTeacher()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Teacher.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                Gate.Teachers = (List<Teacher>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveStudent()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Student.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, Gate.Students);
                    stream.Close();
                }
                

            }
            catch (IOException)
            {
                SaveStudent();
            }

        }
        private void LoadStudent()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Student.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                Gate.Students = (List<Student>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void SaveHomework()
        {
            try
            {
                string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Homework.bin"));
                IFormatter formatter = new BinaryFormatter();
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    formatter.Serialize(stream, mediaPlayer.Homeworks);
                    stream.Close();
                }   
                

            }
            catch (IOException)
            {
                SaveHomework();
            }

        }
        private void LoadHomework()
        {
            string path = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\Homework.bin"));
            if (File.Exists(path))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                mediaPlayer.Homeworks = (List<HomeWork>)formatter.Deserialize(stream);
                stream.Close();
            }
        }

        private void Save()
        {
            SaveSong();
            SaveVideo();
            SaveKaroke();
            SaveSeries();
            SavePlaylist();
            SaveArtist();
            SaveAlbum();
            SaveUser();
            SaveStudent();
            SaveTeacher();
            SaveVideoT();
            SaveLesson();
            SaveHomework();

        }
        private void Load1()
        {
            LoadSong();
            LoadAlbum();
            LoadKaraoke();
            LoadArtist();
            LoadPlaylist();
            LoadVideo();
            LoadUser();
            LoadSeries();
            LoadStudent();
            LoadTeacher();
            LoadVideoT();
            LoadLesson();
            LoadHomework();
            Player.Tag = "";
        }

        //INICIAR Y CERRAR
        private void Close1()
        {
            Save();
        }

        public Form1()
        {
            InitializeComponent();
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\")))
            {
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, @"..\..\Files\"));
            }            
            LogInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            InitialPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            SignInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            AdminPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            Player.Dock = System.Windows.Forms.DockStyle.Fill;
            LikedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            Player.settings.volume = trackBar1.Value;
            AdminTopPanelHolder.SendToBack();
            Load1();
            index = 0;
            Searcher.MediaPlayer = this.mediaPlayer;
            StudentSearcher.MediaPlayer = this.mediaPlayer;
        }

        private void FromClosing(object sender, FormClosingEventArgs e)
        {
            if (currentUser != null)
            {
                currentUser.CurrentSec = progressBar1.Value;
                if (index < mediaPlayer.Queue.Count())
                {
                    currentUser.Lastsong = mediaPlayer.Queue[index];
                }
            }
            if (currentStudent != null)
            {
                currentStudent.CurrentSec = progressBar2.Value;
                if (index < mediaPlayer.Queuestudent.Count())
                {
                    currentStudent.Lastlesson = mediaPlayer.Queuestudent[index];
                }
            }
            Close1();
        }

        //TEXTBOX CHANGED
        private void TextBoxChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox textbox = (System.Windows.Forms.TextBox)sender;
            textbox.BackColor = System.Drawing.Color.White;

            if (textbox.Text == "actor 1, actor 2, etc..." || textbox.Text == "Card Number" || textbox.Text == "Password" || textbox.Text == "PK,K, 1-8, I, II, III or IV" || textbox.Text == "subject1, subject2, etc...")
            {
                textbox.Clear();
            }
        }

        //BACK BUTTON
        private void BackButtom_Click(object sender, EventArgs e)
        {
            if (SignInPanel.Visible == true || LogInPanel.Visible == true ||  PreferencesPanel.Visible == true || ClassRoomLogInPanel.Visible == true)
            {
                InitialPanel.Visible = true;
                SignInPanel.Visible = false;
                LogInPanel.Visible = false;
                PreferencesPanel.Visible = false;
                ClassRoomLogInPanel.Visible = false;

            }
            else if (AdminTablePanel.Visible == true || PlayerPanel.Visible == true) //Agregar el de user y teacher y el student
            {
                if (PlayerPanel.Visible == true)
                {
                    if (mediaPlayer.Queue.Count()>0 && index>mediaPlayer.Queue.Count())
                    {
                        currentUser.Lastsong = mediaPlayer.Queue[index];
                    }
                    currentUser.CurrentSec = progressBar1.Value;
                }
                AdminPanel.Visible = false;
                PlayerPanel.Visible = false;
                InitialPanel.Visible = true;
                currentUser = null;
                Player.Ctlcontrols.stop();
                Player.URL = "";
                currentlyPlaying = null;
                KaraokeTimer.Stop();
                CurrentSong.Stop();
                NextSong.Stop();

            }
            else if (SongUploaderPanel.Visible == true || VideoUploaderPanel.Visible == true || KaraokeUploadPanel.Visible == true || SerieUploadPanel.Visible == true)
            {
                SongUploaderPanel.Visible = false;
                VideoUploaderPanel.Visible = false;
                KaraokeUploadPanel.Visible = false;
                SerieUploadPanel.Visible = false;
                AdminTablePanel.Visible = true;
            }
            else if (EditProfilePanel.Visible == true)
            {
                EditProfilePanel.Visible = false;
                PlayerPanel.Visible = true;
                ProfilImageMainPictureBox.Image = currentUser.Profileimage;
                NameLastNameLabel.Text = currentUser.Name + " " + currentUser.Lastname;
                PlayerBack.Visible = true;
                PlayerBack.BringToFront();
                EditProfileButton.Visible = true;
                EditProfileButton.BringToFront();
                EditPrivateButton.Visible = false;
                EditPublicButton.Visible = false;
                EditCButton.Visible = false;
                EditSButton.Visible = false;
                EditCoursesButton.Visible = false;
                EditSubjectTextBox.Visible = false;
                EditMembershipTarjetaTextBox.Visible = false;
                EditMembershipClaveTextBox.Visible = false;
                EditMembershipLabel.Visible = false;
                EditMembershipButton.Visible = false;
            }
            else if (TeacherPanel.Visible == true || StudentPanel.Visible == true)
            {
                if (StudentPanel.Visible == true)
                {
                    if (mediaPlayer.Queuestudent.Count() > 0&&index > mediaPlayer.Queuestudent.Count())
                    {
                        currentStudent.Lastlesson = mediaPlayer.Queuestudent[index];
                    }
                    currentStudent.CurrentSec = progressBar2.Value;
                }
                TeacherPanel.Visible = false;
                StudentPanel.Visible = false;
                currentUser = null;
                SPlayer.Ctlcontrols.stop();
                SPlayer.URL = "";
                currentlyLessonPlaying = null;
                CurrentLesson.Stop();
                NextLessonTimer.Stop();
                currentlyPlaying = null;
                currentStudent = null;
                currentTeacher = null;
                InitialPanel.Visible = true;
            }
            UserNameTextBox.Text = "";
            UserNameTextBox.BackColor = System.Drawing.Color.Silver;

            PasswordTextBoxLogIn.Text = "";
            PasswordTextBoxLogIn.BackColor = System.Drawing.Color.Silver;

            WrongCredentials.Visible = false;
        }

        //LOG IN
        private void LogInButtom_Click(object sender, EventArgs e)
        {
            LogInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            InitialPanel.Visible = false;
            LogInPanel.Visible = true;


            UserNameTextBox.Text = "";
            UserNameTextBox.BackColor = System.Drawing.Color.Silver;

            PasswordTextBoxLogIn.Text = "";
            PasswordTextBoxLogIn.BackColor = System.Drawing.Color.Silver;

            WrongCredentials.Visible = false;
        }

        private void LogInLogInButtom_Click(object sender, EventArgs e)//Trabajando
        {
            string name = UserNameTextBox.Text;
            string password = PasswordTextBoxLogIn.Text;
            User user = Gate.LogAsUser(name, password);
            if (name == "Spotflix" && password == "123")
            {
                LogInPanel.Visible = false;
                AdminPanel.Visible = true;
                AdminTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            }
            else if (user == null)
            {
                WrongCredentials.Visible = true;
            }
            else
            {
                this.currentUser = user;
                LogInPanel.Visible = false;
                PlayerPanel.Visible = true;
                ProfilImageMainPictureBox.Image = currentUser.Profileimage;
                NameLastNameLabel.Text = currentUser.Name + " " + currentUser.Lastname;
                PlayerBack.Visible = true;
                PlayerBack.BringToFront();
                EditProfileButton.Visible = true;
                EditProfileButton.BringToFront();
                NewPlaylistTable.Visible = false;
                FullandMinimizeScreenButtom.Tag = "full";
                FullandMinimizeScreenButtom.BackgroundImage = Spotflix.Properties.Resources.full_screen;
                Star1Button.Tag = "no";
                Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star2Button.Tag = "no";
                Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star3Button.Tag = "no";
                Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star4Button.Tag = "no";
                Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star5Button.Tag = "no";
                Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                LikeSongorVideo.Tag = "no";
                LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                QuequeButton.Tag = "no";
                QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                ForYouButton.Tag = "no";
                ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                LikesButtom.Tag = "no";
                LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ForYouButtom.Tag = "no";
                ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                AlbumsButtom.Tag = "no";
                AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ArtistsButtom.Tag = "no";
                ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                FollowsButtom.Tag = "no";
                FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);

                foreach (User i in Gate.Retornar())
                {
                    if (i.Nickname == name)
                    {
                        EditGmailTextBox.Text = i.Gmail;
                    }
                }
                initializePlayer();
            }
        }

        private void TeacherStudentButtom_Click(object sender, EventArgs e)
        {
            if (TeacherStudentButton.Tag.ToString() == "off")
            {
                CurseTextBox2.Text = "PK,K, 1-8, I, II, III or IV";
                CurseTextBox2.BackColor = System.Drawing.Color.Silver;
                SubjectTextBox2.Text = "subject1, subject2, etc...";
                SubjectTextBox2.BackColor = System.Drawing.Color.Silver;
                CodeTextBox2.Text = "";
                CodeTextBox2.BackColor = System.Drawing.Color.Silver;
                NewCredentialsPanel.Visible = true;
                TeacherStudentButton.Tag = "on";
                TeacherStudentButton.BackgroundImage = Spotflix.Properties.Resources.study_white;
            }
            else
            {
                CurseTextBox2.Text = "PK,K, 1-8, I, II, III or IV";
                CurseTextBox2.BackColor = System.Drawing.Color.Silver;
                SubjectTextBox2.Text = "subject1, subject2, etc...";
                SubjectTextBox2.BackColor = System.Drawing.Color.Silver;
                CodeTextBox2.Text = "";
                CodeTextBox2.BackColor = System.Drawing.Color.Silver;
                NewCredentialsPanel.Visible = false;
                TeacherStudentButton.Tag = "off";
                TeacherStudentButton.BackgroundImage = Spotflix.Properties.Resources.study_red;
            }
        }

        //SIGN IN
        private void SignInButtom_Click(object sender, EventArgs e)
        {
            NewCredentialsPanel.Visible = false;
            SignInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            InitialPanel.Visible = false;
            SignInPanel.Visible = true;
            ProfilePicture.Image = ProfilePicture.InitialImage;

            SignInNameTextBox.Text = "";
            SignInNameTextBox.BackColor = System.Drawing.Color.Silver;
            SingInLastnameTextBox.Text = "";
            SingInLastnameTextBox.BackColor = System.Drawing.Color.Silver;
            SignInAgeTextBox.Text = "";
            SignInAgeTextBox.BackColor = System.Drawing.Color.Silver;
            SignInEmailTextBox.Text = "";
            SignInEmailTextBox.BackColor = System.Drawing.Color.Silver;
            SignInUsernameTextBox.Text = "";
            SignInUsernameTextBox.BackColor = System.Drawing.Color.Silver;
            SignInPasswordTextBox.Text = "";
            SignInPasswordTextBox.BackColor = System.Drawing.Color.Silver;
            TeacherStudentButton.Tag = "off";
            TeacherStudentButton.BackgroundImage = Spotflix.Properties.Resources.study_red;

            EmptyFieldsLabel.Visible = false;
            InvalidFormatLabel.Visible = false;
            UserCredentialLabel.Visible = false;
        }

        private void SignInSignInButtom_Click(object sender, EventArgs e)
        {
            string name = SignInNameTextBox.Text;
            string lastname = SingInLastnameTextBox.Text;
            bool numcheck;
            int age=0;
            numcheck = int.TryParse(SignInAgeTextBox.Text, out age);
            string email = SignInEmailTextBox.Text;
            string password = SignInPasswordTextBox.Text;
            string username = SignInUsernameTextBox.Text;
            Image profileimage = ProfilePicture.Image;
            UserCredentialLabel.Visible = false;
            InvalidFormatLabel.Visible = false;
            EmptyFieldsLabel.Visible = false;
            WrongCodeLabel.Visible = false;
            if (TeacherStudentButton.Tag.ToString() == "off")
            {
                if (!Gate.checkUsername(username) || !Gate.CheckGmail(email))
                {
                    UserCredentialLabel.Visible = true;
                }
                if ((!numcheck && SignInAgeTextBox.Text != "")||age<=0)
                {
                    InvalidFormatLabel.Visible = true;
                }
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(lastname) || SignInAgeTextBox.Text == "")
                {
                    EmptyFieldsLabel.Visible = true;
                }
                else if (Gate.checkUsername(username) && Gate.CheckGmail(email) && numcheck&&age>0)
                {
                    User user = new User(email, username, password, "no pago", name, lastname, age, profileimage, "privado");
                    if (ProfilePicturePathTextBox.Text != "")
                    {
                        user.Profileimage = new Bitmap(ProfilePicturePathTextBox.Text);
                    }
                    Gate.SingUser(user);
                    this.currentUser = user;
                    initializePlayer();
                    SignInPanel.Visible = false;
                    PreferencesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                    PreferencesPanel.Visible = true;
                }
            }
            else
            {
                string code = CodeTextBox2.Text;
                List<string> subjects = SubjectTextBox2.Text.Split(',').ToList();

                if (!Gate.checkUsername(username) || !Gate.CheckGmail(email))
                {
                    UserCredentialLabel.Visible = true;
                }
                if ((!numcheck && SignInAgeTextBox.Text != "")||age<=0)
                {
                    InvalidFormatLabel.Visible = true;
                }
                if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(name) || String.IsNullOrEmpty(lastname) || SignInAgeTextBox.Text == "" || String.IsNullOrEmpty(code) || subjects == null || SubjectTextBox2.Text == "subject1, subject2, etc...")
                {
                    EmptyFieldsLabel.Visible = true;
                }
                else if (Gate.checkUsername(username) && Gate.CheckGmail(email) && numcheck && code == "Teacher2020"&&age>0)
                {
                    int cursecheck = 0;
                    List<string> curse = CurseTextBox2.Text.Split(',').ToList();
                    foreach (string c in curse)
                    {
                        if (c == "PK" || c == "K" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "I" || c == "II" || c == "III" || c == "IV")
                        {
                            cursecheck += 1;
                        }
                    }
                    if (cursecheck == curse.Count())
                    {
                        User user = new User(email, username, password, "no pago", name, lastname, age, profileimage, "privado");
                        Teacher teacher= new Teacher(Gate.Teachers.Count() + 1, username, name, lastname, email, code, curse, password, age, subjects);
                        Gate.Teachers.Add(teacher);

                        if (ProfilePicturePathTextBox.Text != "")
                        {
                            user.Profileimage = new Bitmap(ProfilePicturePathTextBox.Text);
                        }
                        Gate.SingUser(user);
                        this.currentUser = user;
                        initializePlayer();
                        SignInPanel.Visible = false;
                        PreferencesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                        PreferencesPanel.Visible = true;
                    }
                    else
                    {
                        InvalidFormatLabel.Visible = true;
                    }

                }
                else if (Gate.checkUsername(username) && Gate.CheckGmail(email) && numcheck && code == "Student2020"&&age>0)
                {
                    string curse = CurseTextBox2.Text;
                    if (curse == "PK" || curse == "K" || curse == "1" || curse == "2" || curse == "3" || curse == "4" || curse == "5" || curse == "6" || curse == "7" || curse == "8" || curse == "I" || curse == "II" || curse == "III" || curse == "IV")
                    {
                        User user = new User(email, username, password, "no pago", name, lastname, age, profileimage, "privado");
                        Student student = new Student(Gate.Students.Count() + 1, email, username, password, name, lastname, age, curse, subjects, code);
                        Gate.Students.Add(student);
                        if (ProfilePicturePathTextBox.Text != "")
                        {
                            user.Profileimage = new Bitmap(ProfilePicturePathTextBox.Text);
                        }
                        Gate.SingUser(user);
                        this.currentUser = user;
                        initializePlayer();
                        SignInPanel.Visible = false;
                        PreferencesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                        PreferencesPanel.Visible = true;
                    }
                    else
                    {
                        InvalidFormatLabel.Visible = true;
                    }
                }
                else if ((code != "Student2020" || code != "Teacher2020") && numcheck)
                {
                    WrongCodeLabel.Visible = true;
                }
            }
            SaveUser();
            SaveTeacher();
            SaveStudent();
        }

        private void ProfilePictureButtom_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                ProfilePicture.Image = new Bitmap(path);
                ProfilePicture.BackgroundImage = null;
                ProfilePicturePathTextBox.Text = path;
                ProfilePicture.Visible = true;
            }
        }

        //PREFERENCIAS (falta revisar y que se actualicen según base de datos)
        private void PreferencesButtomChange(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            if (button.Tag.ToString() == "no")
            {
                button.Tag = "yes"; //cuando tenga yes, es porque el usuario seleccionó esa opción (cuando ponga continue, agregar esas cosas en el usuario). 
                button.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                button.Tag = "no";
                button.BackColor = System.Drawing.Color.Black;
            }
        }

        private void ContinueButtom_Click(object sender, EventArgs e)
        {
            PreferencesPanel.Visible = false;
            PlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            PlayerPanel.Visible = true;
            ProfilImageMainPictureBox.Image = currentUser.Profileimage;
            NameLastNameLabel.Text = currentUser.Name + " " + currentUser.Lastname;
            PlayerBack.Visible = true;
            PlayerBack.BringToFront();
            EditProfileButton.Visible = true;
            EditProfileButton.BringToFront();
            NewPlaylistTable.Visible = false;
            FullandMinimizeScreenButtom.Tag = "full";
            FullandMinimizeScreenButtom.BackgroundImage = Spotflix.Properties.Resources.full_screen;
            Star1Button.Tag = "no";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star2Button.Tag = "no";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star3Button.Tag = "no";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star4Button.Tag = "no";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star5Button.Tag = "no";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            LikeSongorVideo.Tag = "no";
            LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
            QuequeButton.Tag = "no";
            QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
            ForYouButton.Tag = "no";
            ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            LikesButtom.Tag = "no";
            LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            ForYouButtom.Tag = "no";
            ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            AlbumsButtom.Tag = "no";
            AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            ArtistsButtom.Tag = "no";
            ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            FollowsButtom.Tag = "no";
            FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            HashSet<Song> foundsongs = new HashSet<Song>();
            HashSet<Video> foundvideo = new HashSet<Video>();

            foreach (Video video in mediaPlayer.Videos)
            {
                foreach (string actor in video.Actors)
                {
                    if (actor == "Zac Efron" && ArtistButton1.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Genne Simons" && ArtistButton6.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Zendaya" && ArtistButton8.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Hugh Jackmann" && ArtistButton7.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                }
                if (video.Genre == "Comedy" && GenreMovieButton1.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Adventures" && GenreMovieButton2.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Drama" && GenreMovieButton3.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Animation" && GenreMovieButton4.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Family" && GenreMovieButton5.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Documentary" && GenreMovieButton6.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Thriller" && GenreMovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Action" && GenreMovieButton8.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Forrest Gump" && MovieButton1.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if ((video.Name == "Orphan" || video.Genre == "Terror") && MovieButton2.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Miracle in cell N7" && MovieButton3.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Moana" && MovieButton4.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "The Impossible" && MovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "The Greatest Showman" && MovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Da Vinci Code" && MovieButton6.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Spirit" && MovieButton5.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
            }
            foreach (Video video in mediaPlayer.VideoChapters)
            {
                foreach (string actor in video.Actors)
                {
                    if (actor == "Zac Efron" && ArtistButton1.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Genne Simons" && ArtistButton6.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Zendaya" && ArtistButton8.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                    if (actor == "Hugh Jackmann" && ArtistButton7.Tag.ToString() == "yes")
                    {
                        foundvideo.Add(video);
                    }
                }
                if (video.Genre == "Comedy" && GenreMovieButton1.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Adventures" && GenreMovieButton2.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Drama" && GenreMovieButton3.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Animation" && GenreMovieButton4.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Family" && GenreMovieButton5.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Documentary" && GenreMovieButton6.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Thriller" && GenreMovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Genre == "Action" && GenreMovieButton8.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Forrest Gump" && MovieButton1.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if ((video.Name == "Orphan" || video.Genre == "Terror") && MovieButton2.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Miracle in cell N7" && MovieButton3.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Moana" && MovieButton4.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "The Impossible" && MovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "The Greatest Showman" && MovieButton7.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Da Vinci Code" && MovieButton6.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
                if (video.Name == "Spirit" && MovieButton5.Tag.ToString() == "yes")
                {
                    foundvideo.Add(video);
                }
            }
            foreach (Song song in mediaPlayer.Songs)
            {
                if (song.Artist == "Mazapan" && ArtistButton2.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Artist == "Morat" && ArtistButton3.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Artist == "Wisin" && ArtistButton4.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Artist == "Alicia Keys" && ArtistButton5.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Artist == "Hugh Jackmann" && ArtistButton7.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Album == "Moana" && MovieButton4.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Album == "Spirit" && MovieButton5.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Album == "The Greatest Showman" && MovieButton7.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Artist == "Mazapan" && ArtistButton2.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Latin" && GenreSongButton1.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Rock" && GenreSongButton2.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Pop" && GenreSongButton3.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Classic" && GenreSongButton4.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Christian" && GenreSongButton5.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Cumbia" && GenreSongButton6.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Jazz" && GenreSongButton7.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if (song.Genre == "Reggaeton" && GenreSongButton8.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Album == "Colgando en tus manos" || song.Name == "Colgando en tus manos" || song.Artist == "Carlos Baute") && SongButtom1.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Album == "Mar adentro" || song.Name == "Mar adentro" || song.Artist == "Mision pais") && SongButtom2.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Album == "Una cerveza" || song.Name == "Una cerveza" || song.Artist == "Rafaga") && SongButtom3.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Name == "Bajo la mesa" || song.Artist == "Morat" || song.Artist == "Sebastian Yatra") && SongButtom4.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Album == "Rock and Roll all nite" || song.Name == "Rock and Roll all nite" || song.Artist == "Kiss") && SongButtom5.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Album == "Ahi vamos" || song.Name == "Carvana" || song.Artist == "Gustavo Cerati") && SongButtom6.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Genre == "Kids" ||song.Artist == "Mazapan") && SongButtom7.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
                if ((song.Genre == "Classic" || song.Name == "Cannon in D Major" || song.Artist == "Johann Pachelbel") && SongButtom8.Tag.ToString() == "yes")
                {
                    foundsongs.Add(song);
                }
            }
            currentUser.Songprefered.AddRange(foundsongs.ToList());
            currentUser.Videoprefered.AddRange(foundvideo.ToList());
            SaveUser();
        }

        private void Visiblepreferenceschange(object sender, EventArgs e)
        {
            System.Windows.Forms.Button button = (System.Windows.Forms.Button)sender;
            button.Tag = "no";
            button.BackColor = System.Drawing.Color.Black;
        }

        
        //ADMINISTRADOR
        //Agregar canciones
        private void AddSongsButtom_Click(object sender, EventArgs e)
        {
            pictureBoxSong.Image = pictureBoxSong.InitialImage;
            pictureBoxSong.Visible = false;

            SongNameTextBox.Text = "";
            SongNameTextBox.BackColor = System.Drawing.Color.Silver;

            ArtistNameSongTextBox.Text = "";
            ArtistNameSongTextBox.BackColor = System.Drawing.Color.Silver;

            AlbumNameSongTextBox.Text = "";
            AlbumNameSongTextBox.BackColor = System.Drawing.Color.Silver;

            GenreSongTextBox.Text = "";
            GenreSongTextBox.BackColor = System.Drawing.Color.Silver;

            YearSongTextBox.Text = "";
            YearSongTextBox.BackColor = System.Drawing.Color.Silver;

            ExplicitTextBoxSong.Text = "";
            SongPathTextBox.Text = "";
            LoadImagePathTextBox.Text = "";
            NoExplicitContentButtomSong.BackColor = System.Drawing.Color.Gray;
            ExplicitContentButtomSong.BackColor = System.Drawing.Color.Gray;

            VideoUploaderPanel.Visible = false;
            KaraokeUploadPanel.Visible = false;
            AdminTablePanel.Visible = false;
            SongUploaderPanel.Visible = true;
            SerieUploadPanel.Visible = false;
            EmptyFieldsSongLabel.Visible = false;
            EmptyFieldsSongLabel.Visible = false;
            EmptyFieldsSongLabel.Visible = false;
            InvalidFormatSongLabel.Visible = false;
            SongAlredyOnDataBaseLabel.Visible = false;
            SuccessSongLabel.Visible = false;
            SongUploaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void ExplicitContentButtomSong_Click(object sender, EventArgs e)
        {
            NoExplicitContentButtomSong.BackColor = System.Drawing.Color.Gray;
            ExplicitContentButtomSong.BackColor = System.Drawing.Color.Gray;
            Button button = (Button)sender;
            button.BackColor = System.Drawing.Color.White;
            ExplicitTextBoxSong.Text = button.Text;
        }

        private void LoadSongButtom_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "mp3 files(*.mp3)|*.mp3|wav files(*.wav)|*.wav";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                SongPathTextBox.Text = path;
                TagLib.File file = TagLib.File.Create(path);
                if (!String.IsNullOrEmpty(file.Tag.Title))
                {
                    SongNameTextBox.Text = file.Tag.Title;
                }
                if (file.Tag.Performers == null)
                {
                    ArtistNameSongTextBox.Text = file.Tag.Performers.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Album))
                {
                    AlbumNameSongTextBox.Text = file.Tag.Album;
                }
                if (file.Tag.Genres == null)
                {
                    GenreSongTextBox.Text = file.Tag.Genres.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Year.ToString()))
                {
                    YearSongTextBox.Text = file.Tag.Year.ToString();
                }
                SuccessSongLabel.Visible = true;
            }
        }

        private void LoadImageSong_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                pictureBoxSong.Image = new Bitmap(path);
                SongUploaderPanel.Text = path;
                pictureBoxSong.Visible = true;
            }
        }

        private void UploadSongButtom_Click(object sender, EventArgs e)
        {
            string path = SongPathTextBox.Text;
            string songname = SongNameTextBox.Text;
            string songartistname = ArtistNameSongTextBox.Text;
            string songalbumname = AlbumNameSongTextBox.Text;
            string genre = GenreSongTextBox.Text;
            EmptyFieldsSongLabel.Visible = false;
            InvalidFormatSongLabel.Visible = false;
            SongAlredyOnDataBaseLabel.Visible = false;
            bool numcheck;
            bool explicit1;
            int year=0;
            if (ExplicitTextBoxSong.Text == "Explicit content")
            {
                explicit1 = true;
            }
            else
            {
                explicit1 = false;
            }
            numcheck = int.TryParse(YearSongTextBox.Text, out year);
            if (String.IsNullOrEmpty(songname) || String.IsNullOrEmpty(songartistname) || String.IsNullOrEmpty(songalbumname) || String.IsNullOrEmpty(genre) || String.IsNullOrEmpty(path))
            {
                EmptyFieldsSongLabel.Visible = true;
            }
            else if (!numcheck||year<=0)
            {
                InvalidFormatSongLabel.Visible = true;
            }
            else
            {
                bool succes = Admin.ImportSong(path, songname, songartistname, songalbumname, genre, year, explicit1, pictureBoxSong.Image, mediaPlayer);
                if (succes)
                {
                    SaveSong();
                    SaveAlbum();
                    SaveArtist();
                    foreach (Playlist playlist in mediaPlayer.Playlists)
                    {
                        Searcher.Smartlist(playlist);
                    }
                    SavePlaylist();
                    AdminTablePanel.Visible = true;
                    SongUploaderPanel.Visible = false;
                }
                else
                {
                    SongAlredyOnDataBaseLabel.Visible = true;
                }
            }

        }

        //Videos
        private void AddVideoButtom_Click(object sender, EventArgs e)
        {
            PictureVideoHolder.Image = PictureVideoHolder.InitialImage;
            PictureVideoHolder.Visible = false;
            VideoNameTextBox.Text = "";
            VideoNameTextBox.BackColor = System.Drawing.Color.Silver;

            VideoDirectorTextBox.Text = "";
            VideoDirectorTextBox.BackColor = System.Drawing.Color.Silver;

            VideoActorsTextBox.Text = "actor 1, actor 2, etc...";
            VideoActorsTextBox.BackColor = System.Drawing.Color.Silver;

            VideoGenreTextBox.Text = "";
            VideoGenreTextBox.BackColor = System.Drawing.Color.Silver;

            VideoYearTextBox.Text = "";
            VideoYearTextBox.BackColor = System.Drawing.Color.Silver;

            VideoStudioTextBox.Text = "";
            VideoStudioTextBox.BackColor = System.Drawing.Color.Silver;

            VideoMinimunAgeTextBox.Text = "";
            VideoMinimunAgeTextBox.BackColor = System.Drawing.Color.Silver;

            VideoPathTextBox.Text = "";
            VideoImagePathTextBox.Text = "";
            SongUploaderPanel.Visible = false;
            SerieUploadPanel.Visible = false;
            KaraokeUploadPanel.Visible = false;
            AdminTablePanel.Visible = false;
            VideoUploaderPanel.Visible = true;
            SuccessVideoLabel.Visible = false;
            InvalidFormatVideoLabel.Visible = false;
            EmptyFieldVideoLabel.Visible = false;
            VideoAlredyOnDataBaseLabel.Visible = false;
            VideoUploaderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void SelectVideoButtom_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mp4 files(*.mp4)|*.mp4";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                VideoPathTextBox.Text = path;
                TagLib.File file = TagLib.File.Create(path);
                if (!String.IsNullOrEmpty(file.Tag.Title))
                {
                    VideoNameTextBox.Text = file.Tag.Title;
                }
                if (!String.IsNullOrEmpty(file.Tag.FirstPerformer))
                {
                    VideoDirectorTextBox.Text = file.Tag.FirstPerformer.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Publisher))
                {
                    VideoStudioTextBox.Text = file.Tag.Album;
                }
                if (file.Tag.Genres == null)
                {
                    VideoGenreTextBox.Text = file.Tag.Genres.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Year.ToString()))
                {
                    VideoYearTextBox.Text = file.Tag.Year.ToString();
                }
                if (file.Tag.Performers == null)
                {
                    VideoActorsTextBox.Text = file.Tag.Performers.ToString();
                }
                SuccessVideoLabel.Visible = true;
            }
        }

        private void SelectedImageButtomVideo_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                PictureVideoHolder.Image = new Bitmap(path);
                VideoImagePathTextBox.Text = path;
                PictureVideoHolder.Visible = true;
            }
        }

        private void UploadVideoButtom_Click(object sender, EventArgs e)
        {
            string path = VideoPathTextBox.Text;

            string videoname = VideoNameTextBox.Text;
            string directorname = VideoDirectorTextBox.Text;
            List<string> actors = VideoActorsTextBox.Text.Split(',').ToList();
            string genre = VideoGenreTextBox.Text;
            string studio = VideoStudioTextBox.Text;
            EmptyFieldVideoLabel.Visible = false;
            VideoAlredyOnDataBaseLabel.Visible = false;
            InvalidFormatVideoLabel.Visible = false;
            bool numcheck;
            bool numcheck2;
            int year=0;
            int ageFilter=0;
            numcheck = int.TryParse(VideoYearTextBox.Text, out year);
            numcheck2 = int.TryParse(VideoMinimunAgeTextBox.Text, out ageFilter);

            if (String.IsNullOrEmpty(videoname) || String.IsNullOrEmpty(directorname) || actors == null || String.IsNullOrEmpty(genre) || String.IsNullOrEmpty(path) || String.IsNullOrEmpty(studio) || VideoActorsTextBox.Text == "actor 1, actor 2, etc...")
            {
                EmptyFieldVideoLabel.Visible = true;
            }
            else if (!numcheck || !numcheck2||year<=0||ageFilter<=0)
            {
                InvalidFormatVideoLabel.Visible = true;
            }
            else
            {
                bool succes = Admin.ImportVideo(path, videoname, directorname, actors, genre, year, ageFilter, studio, PictureVideoHolder.Image, mediaPlayer);
                if (succes)
                {

                    SaveVideo();
                    SaveAlbum();
                    SaveArtist();
                    foreach (Playlist playlist in mediaPlayer.Playlists)
                    {
                        Searcher.Smartlist(playlist);
                    }
                    SavePlaylist();
                    AdminTablePanel.Visible = true;
                    VideoUploaderPanel.Visible = false;
                }
                else
                {
                    SongAlredyOnDataBaseLabel.Visible = true;
                }
            }
        }

        //Karaoke
        private void LoadSongKaraokeButton_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.Filter = "mp3 files(*.mp3)|*.mp3|wav files(*.wav)|*.wav";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                KaraokePathTextBox.Text = path;
                TagLib.File file = TagLib.File.Create(path);
                if (!String.IsNullOrEmpty(file.Tag.Title))
                {
                    KaraokeNameTextBox.Text = file.Tag.Title;
                }
                if (file.Tag.Performers == null)
                {
                    KaraokeArtistTextBox.Text = file.Tag.Performers.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Album))
                {
                    KaraokeAlbumTextBox.Text = file.Tag.Album;
                }
                if (file.Tag.Genres == null)
                {
                    KaraokeGenreTextBox.Text = file.Tag.Genres.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Year.ToString()))
                {
                    KaraokeYearTextBox.Text = file.Tag.Year.ToString();
                }
                KaraokeSuccesLabel.Visible = true;
            }
        }

        private void ImageKaraokeButton_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                KaraokeImage.Image = new Bitmap(path);
                KaraokeUploadPanel.Text = path;
                KaraokeImage.Visible = true;
            }
        }

        private void UpLoadKaraokeButtom_Click(object sender, EventArgs e)
        {
            string path = KaraokePathTextBox.Text;

            string karaokename = KaraokeNameTextBox.Text;
            string karaokeartistname = KaraokeArtistTextBox.Text;
            string karaokealbumname = KaraokeAlbumTextBox.Text;
            string genre = KaraokeGenreTextBox.Text;
            string lyricpath = KaraokeLyricsPathTextBox.Text;
            KaraokeEmptyLabel.Visible = false;
            KaraokeInvalidFormatLabel.Visible = false;
            KaraokeAlredyOnDataBaseLabel.Visible = false;

            bool numcheck = false;
            bool explicit1;
            int year=0;
            if (ExplicitTextBoxKaraoke.Text == "Explicit content")
            {
                explicit1 = true;
            }
            else
            {
                explicit1 = false;
            }
            numcheck = int.TryParse(KaraokeYearTextBox.Text, out year);
            if (String.IsNullOrEmpty(karaokename) || String.IsNullOrEmpty(karaokeartistname) || String.IsNullOrEmpty(karaokealbumname) || String.IsNullOrEmpty(genre) || String.IsNullOrEmpty(path))
            {
                KaraokeEmptyLabel.Visible = true;
            }
            else if (!numcheck||year<=0)
            {
                KaraokeInvalidFormatLabel.Visible = true;
            }
            else
            {
                bool succes = Admin.ImportKaraoke(lyricpath, path, karaokename, karaokeartistname, karaokealbumname, genre, year, explicit1, KaraokeImage.Image, mediaPlayer);
                if (succes)
                {
                    SaveKaroke();
                    SaveAlbum();
                    SaveArtist();
                    foreach (Playlist playlist in mediaPlayer.Playlists)
                    {
                        Searcher.Smartlist(playlist);
                    }
                    SavePlaylist();
                    AdminTablePanel.Visible = true;
                    KaraokeUploadPanel.Visible = false;
                }
                else
                {
                    KaraokeAlredyOnDataBaseLabel.Visible = true;
                }
            }
        }

        private void KaraokeLyricsButton_Click(object sender, EventArgs e)//Super pendiente
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "srt files(*.srt)|*.srt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                KaraokeLyricsPathTextBox.Text = path;
                LyricSuccessLabel.Visible = true;
            }
        }

        private void AddKaraokeButtom_Click(object sender, EventArgs e)
        {
            KaraokeImage.Image = KaraokeImage.InitialImage;
            KaraokeNoExplicitContentButton.BackColor = System.Drawing.Color.Gray;
            KaraokeExplicitContentButton.BackColor = System.Drawing.Color.Gray;
            KaraokeImage.Visible = false;
            KaraokeNameTextBox.Text = "";
            KaraokeNameTextBox.BackColor = System.Drawing.Color.Silver;

            KaraokeArtistTextBox.Text = "";
            KaraokeArtistTextBox.BackColor = System.Drawing.Color.Silver;

            KaraokeAlbumTextBox.Text = "";
            KaraokeAlbumTextBox.BackColor = System.Drawing.Color.Silver;

            KaraokeGenreTextBox.Text = "";
            KaraokeGenreTextBox.BackColor = System.Drawing.Color.Silver;

            KaraokeYearTextBox.Text = "";
            KaraokeYearTextBox.BackColor = System.Drawing.Color.Silver;

            KaraokePathTextBox.Text = "";
            KaraokeImagePathTextBox.Text = "";
            ExplicitTextBoxKaraoke.Text = "";
            SongUploaderPanel.Visible = false;
            VideoUploaderPanel.Visible = false;
            AdminTablePanel.Visible = false;
            SerieUploadPanel.Visible = false;
            KaraokeUploadPanel.Visible = true;
            KaraokeEmptyLabel.Visible=false;
            KaraokeSuccesLabel.Visible = false;
            LyricSuccessLabel.Visible = false;
            KaraokeAlredyOnDataBaseLabel.Visible = false;
            KaraokeInvalidFormatLabel.Visible = false;
            KaraokeUploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void KaraokeExplicitContentButton_Click(object sender, EventArgs e)
        {
            KaraokeNoExplicitContentButton.BackColor = System.Drawing.Color.Gray;
            KaraokeExplicitContentButton.BackColor = System.Drawing.Color.Gray;
            Button button = (Button)sender;
            button.BackColor = System.Drawing.Color.White;
            ExplicitTextBoxKaraoke.Text = button.Text;
        }

        //Series
        private void AddSeriesButtom_Click(object sender, EventArgs e)
        {
            SerieImage.Image = SerieImage.InitialImage;
            SerieImage.Visible = false;
            SerieNameTextBox.ReadOnly = false;
            ChapterSeasonSerieTextbox.ReadOnly = false;
            SelectedImageButtomVideoSerie.Enabled = true;

            SerieNameTextBox.Text = "";
            SerieNameTextBox.BackColor = System.Drawing.Color.Silver;
            VideoSerieNameTextBox.Text = "";
            VideoSerieNameTextBox.BackColor = System.Drawing.Color.Silver;

            DirectorSerieNameTextBox.Text = "";
            DirectorSerieNameTextBox.BackColor = System.Drawing.Color.Silver;

            ActorsSerieNamesTextBox.Text = "actor 1, actor 2, etc...";
            ActorsSerieNamesTextBox.BackColor = System.Drawing.Color.Silver;

            GenreSerieTextBox.Text = "";
            GenreSerieTextBox.BackColor = System.Drawing.Color.Silver;

            YearSerieTextBox.Text = "";
            YearSerieTextBox.BackColor = System.Drawing.Color.Silver;

            StudioSerieTExtBox.Text = "";
            StudioSerieTExtBox.BackColor = System.Drawing.Color.Silver;

            MinimumAgeSerieTextBox.Text = "";
            MinimumAgeSerieTextBox.BackColor = System.Drawing.Color.Silver;

            ChapterSeasonSerieTextbox.Text = "";
            ChapterSeasonSerieTextbox.BackColor = System.Drawing.Color.Silver;

            SeriePathTextBox.Text = "";
            SerieImagePathTextBox.Text = "";
            SongUploaderPanel.Visible = false;
            KaraokeUploadPanel.Visible = false;
            AdminTablePanel.Visible = false;
            VideoUploaderPanel.Visible = false;
            SerieEmptyFieldVideoLabel.Visible = false;
            SerieVideoAlredyOnDataBaseLabel.Visible = false;
            SerieInvalidFormatVideoLabel.Visible = false;
            SuccessVideoUploadLabel.Visible = false;
            MinimumonevideoSerieLabel.Visible = false;
            SerieUploadPanel.Visible = true;
            SerieUploadPanel.Dock = System.Windows.Forms.DockStyle.Fill;
        }

        private void AddVideoToSerieButtom_Click(object sender, EventArgs e)
        {
            string seriename = SerieNameTextBox.Text;
            int season=0;
            string path = SeriePathTextBox.Text;
            string videoname = VideoSerieNameTextBox.Text;
            string directorname = DirectorSerieNameTextBox.Text;
            List<string> actors = ActorsSerieNamesTextBox.Text.Split(',').ToList();
            string genre = GenreSerieTextBox.Text;
            string studio = StudioSerieTExtBox.Text;
            SerieEmptyFieldVideoLabel.Visible = false;
            SerieVideoAlredyOnDataBaseLabel.Visible = false;
            SerieInvalidFormatVideoLabel.Visible = false;
            SuccessVideoUploadLabel.Visible = false;
            MinimumonevideoSerieLabel.Visible = false;
            bool numcheck;
            bool numcheck2;
            bool numcheck3;
            int year=0;
            int ageFilter=0;
            numcheck = int.TryParse(YearSerieTextBox.Text, out year);
            numcheck2 = int.TryParse(MinimumAgeSerieTextBox.Text, out ageFilter);
            numcheck3 = int.TryParse(ChapterSeasonSerieTextbox.Text, out season);

            if (String.IsNullOrEmpty(videoname) || String.IsNullOrEmpty(directorname) || YearSerieTextBox.Text == "" || MinimumAgeSerieTextBox.Text == "" || ChapterSeasonSerieTextbox.Text == "" || actors == null || ActorsSerieNamesTextBox.Text == "actor 1, actor 2, etc..." || String.IsNullOrEmpty(genre) || String.IsNullOrEmpty(path) || String.IsNullOrEmpty(studio) || string.IsNullOrEmpty(seriename))
            {
                SerieEmptyFieldVideoLabel.Visible = true;
            }
            else if ((!numcheck && YearSerieTextBox.Text != "") || (!numcheck2 && MinimumAgeSerieTextBox.Text != "" ) || (!numcheck3 && ChapterSeasonSerieTextbox.Text != "" )||year<=0||ageFilter<0||season<=0)
            {
                SerieInvalidFormatVideoLabel.Visible = true;
            }
            else
            {
                foreach (Serie s in mediaPlayer.Series)
                {
                    if (s.SerieName == seriename && s.Season == season)
                    {
                        if (s.Image != null)
                        {
                            SerieImage.Image = s.Image;
                            SerieImage.Visible = true;
                            SelectedImageButtomVideoSerie.Enabled = false;
                            SelectedImageButtomVideoSerie.Enabled = false;
                        }
                    }
                }

                bool succes = Admin.ImportVideoSerie(seriename, season, path, videoname, directorname, actors, genre, year, ageFilter, studio, SerieImage.Image, mediaPlayer);
                if (succes)
                {
                    SaveVideo();
                    SaveSeries();
                    SaveArtist();
                    foreach (Playlist playlist in mediaPlayer.Playlists)
                    {
                        Searcher.Smartlist(playlist);
                    }
                    SavePlaylist();
                    SerieNameTextBox.ReadOnly = true;
                    ChapterSeasonSerieTextbox.ReadOnly = true;
                    SelectedImageButtomVideoSerie.Enabled = false;
                    VideoSerieNameTextBox.Text = "";
                    VideoSerieNameTextBox.BackColor = System.Drawing.Color.Silver;

                    DirectorSerieNameTextBox.Text = "";
                    DirectorSerieNameTextBox.BackColor = System.Drawing.Color.Silver;

                    ActorsSerieNamesTextBox.Text = "actor 1, actor 2, etc...";
                    ActorsSerieNamesTextBox.BackColor = System.Drawing.Color.Silver;

                    GenreSerieTextBox.Text = "";
                    GenreSerieTextBox.BackColor = System.Drawing.Color.Silver;

                    YearSerieTextBox.Text = "";
                    YearSerieTextBox.BackColor = System.Drawing.Color.Silver;

                    StudioSerieTExtBox.Text = "";
                    StudioSerieTExtBox.BackColor = System.Drawing.Color.Silver;

                    MinimumAgeSerieTextBox.Text = "";
                    MinimumAgeSerieTextBox.BackColor = System.Drawing.Color.Silver;

                    SeriePathTextBox.Text = "";
                    SuccessVideoUploadLabel.Visible = true;
                }
                else
                {
                    SerieVideoAlredyOnDataBaseLabel.Visible = true;

                }
            }
        }

        private void SelectedImageButtomVideoSerie_Click(object sender, EventArgs e)
        {
            SerieInvalidFormatVideoLabel.Visible = false;
            SerieEmptyFieldVideoLabel.Visible = false;
            string seriename = SerieNameTextBox.Text;
            int season=0;
            bool numcheck3;
            numcheck3 = int.TryParse(ChapterSeasonSerieTextbox.Text, out season);
            if (ChapterSeasonSerieTextbox.Text == "" || string.IsNullOrEmpty(seriename))
            {
                SerieEmptyFieldVideoLabel.Visible = true;
            }
            else if ((!numcheck3 && ChapterSeasonSerieTextbox.Text != "")||season<=0)
            {
                SerieInvalidFormatVideoLabel.Visible = true;
            }
            else
            {
                foreach (Serie s in mediaPlayer.Series)
                {
                    if (s.SerieName == SerieNameTextBox.Text && s.Season == season)
                    {
                        if (s.Image != null)
                        {
                            SerieImage.Image = s.Image;
                            SerieImage.Visible = true;
                            SelectedImageButtomVideoSerie.Enabled = false;
                            SerieNameTextBox.ReadOnly = true;
                            ChapterSeasonSerieTextbox.ReadOnly = true;
                        }
                    }
                }
                if (SelectedImageButtomVideoSerie.Enabled == true)
                {
                    OpenFileDialog dialog = new OpenFileDialog();
                    dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string path = dialog.FileName;
                        SerieImage.Image = new Bitmap(path);
                        SerieImagePathTextBox.Text = path;
                        SerieImage.Visible = true;
                    }
                }
            }    
        }

        private void SelectedVideoButtom_Click(object sender, EventArgs e)
        {
            AdminTablePanel.Visible = false;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mp4 files(*.mp4)|*.mp4";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                SeriePathTextBox.Text = path;
                TagLib.File file = TagLib.File.Create(path);
                if (!String.IsNullOrEmpty(file.Tag.Title))
                {
                    VideoSerieNameTextBox.Text = file.Tag.Title;
                }
                if (!String.IsNullOrEmpty(file.Tag.FirstPerformer))
                {
                    DirectorSerieNameTextBox.Text = file.Tag.FirstPerformer.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Publisher))
                {
                    StudioSerieTExtBox.Text = file.Tag.Album;
                }
                if (file.Tag.Genres == null)
                {

                    GenreSerieTextBox.Text = file.Tag.Genres.ToString();
                }
                if (!String.IsNullOrEmpty(file.Tag.Year.ToString()))
                {
                    YearSerieTextBox.Text = file.Tag.Year.ToString();
                }
                if (file.Tag.Performers == null)
                {
                    ActorsSerieNamesTextBox.Text = file.Tag.Performers.ToString();
                }
            }
        }

        private void UploadSerieButtom_Click(object sender, EventArgs e)
        {
            MinimumonevideoSerieLabel.Visible = false;
            string seriename = SerieNameTextBox.Text;
            int season;
            bool listo = false;

            SerieEmptyFieldVideoLabel.Visible = false;
            SerieVideoAlredyOnDataBaseLabel.Visible = false;
            SerieInvalidFormatVideoLabel.Visible = false;
            SuccessVideoUploadLabel.Visible = false;
            MinimumonevideoSerieLabel.Visible = false;

            bool numcheck3;

            numcheck3 = int.TryParse(ChapterSeasonSerieTextbox.Text, out season);

            foreach (Serie s in mediaPlayer.Series)
            {
                if (s.SerieName == seriename && s.Season == season)
                {
                    listo = true;
                }
                else
                {
                    listo = false;
                }
            }

            if (listo)
            {
                AdminTablePanel.Visible = true;
                SerieUploadPanel.Visible = false;
                SaveArtist();
                SaveSeries();
            }
            else
            {
                MinimumonevideoSerieLabel.Visible = true;
            }
        }

        //USUARIO
        //Editar perfil
        private void EditProfileButton_Click(object sender, EventArgs e)
        {
            if (currentUser.PrivPubl == "privado")
            {
                EditPrivateButton.BackColor = System.Drawing.Color.White;
                EditPrivateButton.Tag = "si";
                EditPublicButton.BackColor = System.Drawing.Color.Silver;
                EditPublicButton.Tag = "no";
            }
            else
            {
                EditPrivateButton.BackColor = System.Drawing.Color.Silver;
                EditPrivateButton.Tag = "no";
                EditPublicButton.BackColor = System.Drawing.Color.White;
                EditPublicButton.Tag = "si";
            }
            EditCButton.Visible = false;
            EditSButton.Visible = false;
            EditCoursesButton.Visible = false;
            EditSubjectTextBox.Visible = false;
            InstructionTeacher.Visible = false;
            EditProfilePicture.Image = currentUser.Profileimage;
            PlayerPanel.Visible = false;
            CLabel.Visible = false;
            SLabel.Visible = false;
            EditProfilePanel.Visible = true;
            EditProfilePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            foreach (User i in Gate.Retornar())
            {
                if (i.Gmail == EditGmailTextBox.Text)
                {
                    EditProfilePicture.BackgroundImage = i.Profileimage;
                }
                else if (i.Gmail == SignInEmailTextBox.Text)
                {
                    EditProfilePicture.BackgroundImage = i.Profileimage;
                }
            }
            foreach (Teacher j in Gate.RetornarTeacher())
            {
                if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                {

                    EditCButton.Visible = true;
                    EditSButton.Visible = true;
                    EditCoursesButton.Visible = true;
                    EditSubjectTextBox.Visible = true;
                    InstructionTeacher.Visible = true;
                    EditSubjectTextBox.Text = "subject1, subject2, etc...";
                    EditSubjectTextBox.BackColor = System.Drawing.Color.Silver;
                    EditCoursesButton.Text = "PK,K, 1-8, I, II, III or IV";
                    EditCoursesButton.BackColor = System.Drawing.Color.Silver;
                    CLabel.Text = "";
                    SLabel.Text = "";
                }
            }
            foreach (Student s in Gate.RetornarStudent())
            {
                if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                {

                    EditCButton.Visible = true;
                    EditCoursesButton.Visible = true;
                    EditSubjectTextBox.Visible = true;
                    InstructionTeacher.Visible = true;
                    EditSubjectTextBox.Text = "subject1, subject2, etc...";
                    EditSubjectTextBox.BackColor = System.Drawing.Color.Silver;
                    EditCoursesButton.Text = "PK,K, 1-8, I, II, III or IV";
                    EditCoursesButton.BackColor = System.Drawing.Color.Silver;
                    CLabel.Text = "";
                    SLabel.Text = "";
                }
            }
            EditPrivateButton.Visible = true;
            EditPublicButton.Visible = true;
            EditMembershipTarjetaTextBox.Visible = true;
            EditMembershipClaveTextBox.Visible = true;
            EditMembershipLabel.Visible = true;
            EditMembershipButton.Visible = true;
            EditMembershipTarjetaTextBox.Text = "";
            EditMembershipTarjetaTextBox.BackColor = System.Drawing.Color.Silver;
            EditMembershipClaveTextBox.Text = "";
            EditMembershipClaveTextBox.BackColor = System.Drawing.Color.Silver;
            EditMembershipLabel.Text = "";
            EditNickNameTextBox.Text = "";
            EditNickNameTextBox.BackColor = System.Drawing.Color.Silver;
            EditPasswordTextBox.Text = "";
            EditPasswordTextBox.BackColor = System.Drawing.Color.Silver;
            EditPasswordLabel.Text = "";
            EditNickNameLabel.Text = "";
            EditPrivacyLabel.Text = "";
        }

        private void EditNicknameButton_Click(object sender, EventArgs e)
        {
            if (EditNickNameTextBox.Text == "")
            {
                EditNickNameLabel.Text = "Empty label";
            }
            else
            {
                bool repetido = false;
                string newNick = EditNickNameTextBox.Text;
                foreach (User k in Gate.Retornar())
                {
                    if (newNick == k.Nickname)
                    {
                        repetido = true;
                    }
                }
                if (repetido)
                {
                    EditNickNameLabel.Text = "That username is busy";
                }
                else
                {
                    foreach (User i in Gate.Retornar())
                    {

                        if (i.Gmail == EditGmailTextBox.Text && EditNickNameTextBox.Text != "")
                        {
                            bool np = Gate.ChangeNickName(i.Nickname, i.Password, newNick);
                            if (np)
                            {
                                foreach (Teacher j in Gate.RetornarTeacher())
                                {
                                    if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                                    {
                                        j.Nickname = newNick;
                                        SaveUser();
                                        SaveTeacher();
                                    }
                                }
                                foreach (Student s in Gate.RetornarStudent())
                                {
                                    if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                                    {
                                        s.Nickname = newNick;
                                        SaveUser();
                                        SaveStudent();
                                    }
                                }
                                EditNickNameLabel.Text = "Username has been changed";
                                EditNickNameTextBox.Text = "";
                                EditNickNameTextBox.BackColor = System.Drawing.Color.Silver;
                            }
                            else
                            {
                                EditNickNameLabel.Text = "Username change failed";
                                EditNickNameTextBox.Text = "";
                                EditNickNameTextBox.BackColor = System.Drawing.Color.Silver;
                            }
                        }
                        else if (i.Gmail == SignInEmailTextBox.Text && EditNickNameTextBox.Text != "")
                        {
                            bool np = Gate.ChangeNickName(i.Nickname, i.Password, newNick);
                            if (np)
                            {
                                EditNickNameLabel.Text = "Username has been changed";
                                EditNickNameTextBox.Text = "";
                                EditNickNameTextBox.BackColor = System.Drawing.Color.Silver;
                                foreach (Teacher j in Gate.RetornarTeacher())
                                {
                                    if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                                    {
                                        j.Nickname = newNick;
                                        SaveUser();
                                        SaveTeacher();
                                    }
                                }
                                foreach (Student s in Gate.RetornarStudent())
                                {
                                    if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                                    {
                                        s.Nickname = newNick;
                                        SaveUser();
                                        SaveStudent();
                                    }
                                }
                            }
                            else
                            {
                                EditNickNameLabel.Text = "Username change failed";
                                EditNickNameTextBox.Text = "";
                                EditNickNameTextBox.BackColor = System.Drawing.Color.Silver;
                            }
                        }

                    }
                }
            }
        }

        private void PasswordEditProfileButton_Click(object sender, EventArgs e)
        {
            string newpassword = EditPasswordTextBox.Text;
            if (EditPasswordTextBox.Text == "")
            {
                EditPasswordLabel.Text = "Empty label";
            }
            else
            {
                foreach (User i in Gate.Retornar())
                {
                    if (i.Gmail == EditGmailTextBox.Text && newpassword != "")
                    {
                        bool np = Gate.ChangePassword(i.Nickname, i.Password, newpassword);
                        if (np)
                        {
                            EditPasswordLabel.Text = "Password has been changed";
                            EditPasswordTextBox.Text = "";
                            EditPasswordTextBox.BackColor = System.Drawing.Color.Silver;
                            foreach (Teacher j in Gate.RetornarTeacher())
                            {
                                if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                                {
                                    j.Password = newpassword;
                                    SaveUser();
                                }
                            }
                            foreach (Student s in Gate.RetornarStudent())
                            {
                                if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                                {
                                    s.Password = newpassword;
                                    SaveUser();
                                }
                            }
                        }
                        else
                        {
                            EditPasswordLabel.Text = "Password change failed";
                            EditPasswordTextBox.Text = "";
                            EditPasswordTextBox.BackColor = System.Drawing.Color.Silver;
                        }
                    }
                    else if (i.Gmail == SignInEmailTextBox.Text && newpassword != "")
                    {
                        bool np = Gate.ChangePassword(i.Nickname, i.Password, newpassword);
                        if (np && EditPasswordTextBox.Text != "")
                        {
                            EditPasswordLabel.Text = "Password has been changed";
                            EditPasswordTextBox.Text = "";
                            EditPasswordTextBox.BackColor = System.Drawing.Color.Silver;
                            foreach (Teacher j in Gate.RetornarTeacher())
                            {
                                if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                                {
                                    j.Password = newpassword;
                                    SaveUser();
                                    SaveTeacher();
                                }
                            }
                            foreach (Student s in Gate.RetornarStudent())
                            {
                                if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                                {
                                    s.Password = newpassword;
                                    SaveUser();
                                    SaveStudent();
                                }
                            }
                        }
                        else
                        {
                            EditPasswordLabel.Text = "Password change failed";
                            EditPasswordTextBox.Text = "";
                            EditPasswordTextBox.BackColor = System.Drawing.Color.Silver;
                        }
                    }
                }
            }
        }

        private void EditMembershipButton_Click(object sender, EventArgs e)
        {
            if (EditMembershipTarjetaTextBox.Text == "" || EditMembershipClaveTextBox.Text == "")
            {
                EditMembershipLabel.Text = "Empty label";
            }
            else
            {
                int number=0;
                bool numcheck = int.TryParse(EditMembershipTarjetaTextBox.Text, out number);
                foreach (User i in Gate.Retornar())
                {
                    if (numcheck&&number>0)
                    {
                        if (i.Gmail == EditGmailTextBox.Text && EditMembershipTarjetaTextBox.Text != "" && EditMembershipClaveTextBox.Text != "")
                        {
                            bool np = Gate.ChangeMembership(i.Nickname, i.Password);
                            if (np)
                            {
                                EditMembershipLabel.Text = "It has been converted to Premium";
                                EditMembershipClaveTextBox.Text = "";
                                EditMembershipClaveTextBox.BackColor = System.Drawing.Color.Silver;
                                EditMembershipTarjetaTextBox.Text = "";
                                EditMembershipTarjetaTextBox.BackColor = System.Drawing.Color.Silver;
                                SaveUser();
                            }
                            else
                            {
                                EditMembershipLabel.Text = "You are no longer Premium";
                                EditMembershipClaveTextBox.Text = "";
                                EditMembershipClaveTextBox.BackColor = System.Drawing.Color.Silver;
                                EditMembershipTarjetaTextBox.Text = "";
                                EditMembershipTarjetaTextBox.BackColor = System.Drawing.Color.Silver;
                                SaveUser();
                            }
                        }
                        else if (i.Gmail == SignInEmailTextBox.Text && EditMembershipTarjetaTextBox.Text != "" && EditMembershipClaveTextBox.Text != "")
                        {
                            bool np = Gate.ChangeMembership(i.Nickname, i.Password);
                            if (np)
                            {
                                EditMembershipLabel.Text = "It has been converted to Premium";
                                EditMembershipClaveTextBox.Text = "";
                                EditMembershipClaveTextBox.BackColor = System.Drawing.Color.Silver;
                                EditMembershipTarjetaTextBox.Text = "";
                                EditMembershipTarjetaTextBox.BackColor = System.Drawing.Color.Silver;
                                SaveUser();
                            }
                            else
                            {
                                EditMembershipLabel.Text = "You are no longer Premium";
                                EditMembershipClaveTextBox.Text = "";
                                EditMembershipClaveTextBox.BackColor = System.Drawing.Color.Silver;
                                EditMembershipTarjetaTextBox.Text = "";
                                EditMembershipTarjetaTextBox.BackColor = System.Drawing.Color.Silver;
                                SaveUser();
                            }
                        }
                    }
                    else
                    {
                        EditMembershipLabel.Text = "Invalid card";
                    }
                }
            }
        }

        private void EditProfilePhotoButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                EditProfilePicture.Image = new Bitmap(path);
                EditProfilePicture.Visible = true;
                foreach (User i in Gate.Retornar())
                {
                    if (i.Gmail == SignInEmailTextBox.Text)
                    {
                        i.Profileimage = EditProfilePicture.Image;
                        SaveUser();
                    }
                    else if (i.Gmail == EditGmailTextBox.Text)
                    {
                        i.Profileimage = EditProfilePicture.Image;
                        SaveUser();
                    }
                }
            }
        }

        private void EditPrivateButton_Click(object sender, EventArgs e)
        {
            EditPrivacyLabel.Text = "";
            EditPrivacyLabel.Visible = false;
            if (EditPrivateButton.Tag.ToString() == "no")
            {
                EditPrivateButton.Tag = "si";
                EditPrivateButton.BackColor = System.Drawing.Color.White;
                EditPublicButton.Tag = "no";
                EditPublicButton.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                EditPrivateButton.Tag = "no";
                EditPrivateButton.BackColor = System.Drawing.Color.Silver;
            }
            foreach (User i in Gate.Retornar())
            {
                if (i.Gmail == SignInEmailTextBox.Text)
                {
                    if (i.PrivPubl == "privado")
                    {
                        EditPrivacyLabel.Text = "You are already a private user";
                        EditPrivacyLabel.Visible = true;
                    }
                    else if (i.PrivPubl == "publico")
                    {
                        i.PrivPubl = "privado";
                        EditPrivacyLabel.Text = "Now you are a private user";
                        EditPrivacyLabel.Visible = true;
                        foreach (User user in Gate.Users)
                        {
                            if (user.FollowUsers.Any(u => u.Equals(i)))
                            {
                                user.FollowUsers.Remove(i);
                            }
                        }
                        SaveUser();
                    }
                }
                else if (i.Gmail == EditGmailTextBox.Text)
                {
                    if (i.PrivPubl == "privado")
                    {
                        EditPrivacyLabel.Text = "You are already a private user";
                        EditPrivacyLabel.Visible = true;
                    }
                    else if (i.PrivPubl == "publico")
                    {
                        i.PrivPubl = "privado";
                        EditPrivacyLabel.Text = "Now you are a private user";
                        EditPrivacyLabel.Visible = true;
                        foreach (User user in Gate.Users)
                        {
                            if (user.FollowUsers.Contains(i))
                            {
                                user.FollowUsers.Remove(i);
                            }
                        }
                        SaveUser();
                    }
                }
            }
        }

        private void EditPublicButton_Click(object sender, EventArgs e)
        {
            if (EditPublicButton.Tag.ToString() == "no")
            {
                EditPublicButton.Tag = "si";
                EditPublicButton.BackColor = System.Drawing.Color.White;
                EditPrivateButton.Tag = "no";
                EditPrivateButton.BackColor = System.Drawing.Color.Silver;
            }
            else
            {
                EditPublicButton.Tag = "no";
                EditPublicButton.BackColor = System.Drawing.Color.Silver;
            }
            foreach (User i in Gate.Retornar())
            {
                if (i.Gmail == SignInEmailTextBox.Text)
                {
                    if (i.PrivPubl == "publico")
                    {
                        EditPrivacyLabel.Text = "You are already a public user";
                        EditPrivacyLabel.Visible = true;
                    }
                    else if (i.PrivPubl == "privado")
                    {
                        i.PrivPubl = "publico";
                        SaveUser();
                        EditPrivacyLabel.Text = "Now you are a public user";
                        EditPrivacyLabel.Visible = true;
                    }
                }
                else if (i.Gmail == EditGmailTextBox.Text)
                {
                    if (i.PrivPubl == "publico")
                    {
                        EditPrivacyLabel.Text = "You are already a public user";
                        EditPrivacyLabel.Visible = true;
                    }
                    else if (i.PrivPubl == "privado")
                    {
                        i.PrivPubl = "publico";
                        SaveUser();
                        EditPrivacyLabel.Text = "Now you are a public user";
                        EditPrivacyLabel.Visible = true;
                    }
                }
            }
        }

        private void EditCButton_Click(object sender, EventArgs e)
        {
            CLabel.Visible = false;
            foreach (Teacher j in Gate.RetornarTeacher())
            {
                if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                {
                    if (EditCoursesButton.Text != "PK,K, 1-8, I, II, III or IV" && EditCoursesButton.Text != "")
                    {
                        int cursecheck = 0;
                        List<string> curse = EditCoursesButton.Text.Split(',').ToList();
                        foreach (string c in curse)
                        {
                            if (c == "PK" || c == "K" || c == "1" || c == "2" || c == "3" || c == "4" || c == "5" || c == "6" || c == "7" || c == "8" || c == "I" || c == "II" || c == "III" || c == "IV")
                            {
                                cursecheck += 1;
                            }
                        }
                        if (cursecheck == curse.Count())
                        {
                            j.Course = curse;
                            CLabel.Text = "Successful changes!";
                            EditCoursesButton.Text = "PK,K, 1-8, I, II, III or IV";
                            EditCoursesButton.BackColor = System.Drawing.Color.Silver;
                            CLabel.Visible = true;
                        }
                        else
                        {
                            CLabel.Text = "Invalid format";
                            CLabel.Visible = true;
                        }
                    }
                    else if (EditCoursesButton.Text != "PK,K, 1-8, I, II, III or IV" && EditCoursesButton.Text == "")
                    {
                        CLabel.Text = "Empty field";
                        CLabel.Visible = true;
                    }

                }
            }
            foreach (Student s in Gate.RetornarStudent())
            {
                if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                {
                    if (EditCoursesButton.Text != "PK,K, 1-8, I, II, III or IV" && EditCoursesButton.Text != "")
                    {
                        string curse = EditCoursesButton.Text;
                        if (curse == "PK" || curse == "K" || curse == "1" || curse == "2" || curse == "3" || curse == "4" || curse == "5" || curse == "6" || curse == "7" || curse == "8" || curse == "I" || curse == "II" || curse == "III" || curse == "IV")
                        {
                            s.Curse = curse;
                            CLabel.Text = "Successful changes!";
                            EditCoursesButton.Text = "PK,K, 1-8, I, II, III or IV";
                            EditCoursesButton.BackColor = System.Drawing.Color.Silver;
                            CLabel.Visible = true;
                        }
                        else
                        {
                            CLabel.Text = "Invalid format";
                            CLabel.Visible = true;
                        }
                    }
                    else if (EditCoursesButton.Text != "PK,K, 1-8, I, II, III or IV" && EditCoursesButton.Text == "")
                    {
                        CLabel.Text = "Empty field";
                        CLabel.Visible = true;
                    }
                }
            }
        }

        private void EditSButton_Click(object sender, EventArgs e)
        {
            SLabel.Visible = false;
            foreach (Teacher j in Gate.RetornarTeacher())
            {
                if (j.Gmail == EditGmailTextBox.Text || j.Gmail == SignInEmailTextBox.Text)
                {
                    if (EditSubjectTextBox.Text != "subject1, subject2, etc..." && EditSubjectTextBox.Text != "")
                    {
                        List<string> subjects = EditSubjectTextBox.Text.Split(',').ToList();
                        j.Subjects = subjects;
                        SLabel.Text = "Successful changes!";
                        EditSubjectTextBox.Text = "subject1, subject2, etc...";
                        EditSubjectTextBox.BackColor = System.Drawing.Color.Silver;
                        SLabel.Visible = true;
                    }
                    else if (EditSubjectTextBox.Text != "subject1, subject2, etc..." && EditSubjectTextBox.Text == "")
                    {
                        SLabel.Text = "Empty field";
                        SLabel.Visible = true;
                    }
                }
            }
            foreach (Student s in Gate.RetornarStudent())
            {
                if (s.Gmail == EditGmailTextBox.Text || s.Gmail == SignInEmailTextBox.Text)
                {
                    if (EditSubjectTextBox.Text != "subject1, subject2, etc..." && EditSubjectTextBox.Text != "")
                    {
                        List<string> subjects = EditSubjectTextBox.Text.Split(',').ToList();
                        s.Subjects = subjects;
                        SLabel.Text = "Successful changes!";
                        EditSubjectTextBox.Text = "subject1, subject2, etc...";
                        EditSubjectTextBox.BackColor = System.Drawing.Color.Silver;
                        SLabel.Visible = true;
                    }
                    else if (EditSubjectTextBox.Text != "subject1, subject2, etc..." && EditSubjectTextBox.Text == "")
                    {
                        SLabel.Text = "Empty field";
                        SLabel.Visible = true;
                    }

                }
            }
        }

        //REPRODUCTOR
        //Play
        private void PlayButton_Click(object sender, EventArgs e)
        {
            if (PlayPausaButtom.Tag.ToString() == "pause")
            {
                Player.Ctlcontrols.pause();
                PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
                PlayPausaButtom.Tag = "play";
            }
            else
            {
                Player.Ctlcontrols.play();

                PlayPausaButtom.BackgroundImage = Properties.Resources.pausa140;
                PlayPausaButtom.Tag = "pause";
            }
        }

        //Pantalla completa
        private void FullandMinimizeScreenButtom_Click(object sender, EventArgs e)
        {
            if (PlayPausaButtom.Tag.ToString() == "pause")
            {
                PlayPausaButtom.PerformClick();
                using (BigScreen bigScreen = new BigScreen(mediaPlayer.Queue, currentlyPlaying, mediaPlayer, Player.Ctlcontrols.currentPosition, progressBar1.Value, index, lyric, trackBar1.Value, progressBar1.Maximum))
                {
                    if (bigScreen.ShowDialog() == DialogResult.OK)
                    {
                    }
                    mediaPlayer = bigScreen.MediaPlayer;
                    currentlyPlaying = bigScreen.CurrentlyPlaying;
                    lyric = bigScreen.Lyric;
                    index = bigScreen.Index;
                    trackBar1.Value = bigScreen.getSound();
                    progressBar1.Value = bigScreen.getSecond();
                    Player.Ctlcontrols.currentPosition = bigScreen.getSecond() + 0.5;
                    PlayPausaButtom.PerformClick();
                }
            }
            else
            {
                using (BigScreen bigScreen = new BigScreen(mediaPlayer.Queue, currentlyPlaying, mediaPlayer, Player.Ctlcontrols.currentPosition, progressBar1.Value, index, lyric, trackBar1.Value, progressBar1.Maximum))
                {
                    if (bigScreen.ShowDialog() == DialogResult.OK)
                    {
                    }
                    mediaPlayer = bigScreen.MediaPlayer;
                    currentlyPlaying = bigScreen.CurrentlyPlaying;
                    lyric = bigScreen.Lyric;
                    index = bigScreen.Index;
                    trackBar1.Value = bigScreen.getSound();
                    progressBar1.Value = bigScreen.getSecond();
                    Player.Ctlcontrols.currentPosition = bigScreen.getSecond() + 0.5;
                }
            }

        }

        //Paneles laterales + Queque
        private void LikesButtom_Click(object sender, EventArgs e)
        {
            Button currentpanel = (Button)sender;
            LikedPanel.Visible = true;
            LikedPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            LikesdataGrid.Rows.Clear();
            switch (currentpanel.Text)
            {
                case "                         QuequeButtom":
                    if (QuequeButton.Tag.ToString() == "no")
                    {
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_azul;
                        QuequeButton.Tag = "si";
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesdataGrid.Columns[0].HeaderText = "Queue";
                        LikesdataGrid.Columns[1].HeaderText = "Name";
                        LikesdataGrid.Columns[2].HeaderText = "Duration";
                        foreach (MediaFile mediaFile in mediaPlayer.Queue)
                        {
                            string output = string.Format("{0}:{1:00}", (int)mediaFile.Length.TotalMinutes, mediaFile.Length.Seconds);
                            LikesdataGrid.Rows.Add(mediaFile.Image, mediaFile.Name, output);
                        }
                        LikedPanel.BringToFront();
                        break;
                    }
                    else
                    {
                        LikedPanel.Visible = false;
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        QuequeButton.Tag = "no";
                        break;
                    }
                case "For you":
                    if (ForYouButton.Tag.ToString() == "no")
                    {
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        ForYouButton.Tag = "si";
                        ForYouButton.BackColor = System.Drawing.Color.Silver;
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesdataGrid.Columns[0].HeaderText = "Preferences media";
                        LikesdataGrid.Columns[1].HeaderText = "Name";
                        LikesdataGrid.Columns[2].HeaderText = "Duration";
                        foreach (Song song in currentUser.Songprefered)
                        {
                            string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                            LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                        }
                        foreach (Video video in currentUser.Videoprefered)
                        {
                            string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                            LikesdataGrid.Rows.Add(video.Image, video.Name, output);
                        }
                        break;
                    }
                    else
                    {
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButton.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }
                case "Favorites":
                    if (LikesButtom.Tag.ToString() == "no")
                    {
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        LikesButtom.Tag = "si";
                        LikesButtom.BackColor = System.Drawing.Color.Silver;
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesdataGrid.Columns[0].HeaderText = "Liked media";
                        LikesdataGrid.Columns[1].HeaderText = "Name";
                        LikesdataGrid.Columns[2].HeaderText = "Duration";
                        foreach (Song song in currentUser.LikedSongs)
                        {
                            string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                            LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                        }
                        foreach (Video video in currentUser.LikedVideos)
                        {
                            string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                            LikesdataGrid.Rows.Add(video.Image, video.Name, output);
                        }
                        foreach (Karaoke Karaoke in currentUser.LikedKarokes)
                        {
                            string output = string.Format("{0}:{1:00}", (int)Karaoke.Length.TotalMinutes, Karaoke.Length.Seconds);
                            LikesdataGrid.Rows.Add(Karaoke.Image, Karaoke.Name, output);
                        }
                        break;
                    }
                    else
                    {
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesButtom.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }

                case "Playlist/Series":
                    if (ForYouButtom.Tag.ToString() == "no")
                    {
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        ForYouButtom.Tag = "si";
                        ForYouButtom.BackColor = System.Drawing.Color.Silver;
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesdataGrid.Columns[0].HeaderText = "Followed playlist/series";
                        LikesdataGrid.Columns[1].HeaderText = "name";
                        LikesdataGrid.Columns[2].HeaderText = "N of mediafiles";
                        foreach (Playlist playlist in currentUser.FollowPlaylist)
                        {
                            LikesdataGrid.Rows.Add(playlist.Image, playlist.PlaylistName, playlist.Songs.Count() + playlist.Videos.Count()+playlist.Karaokes.Count());
                        }
                        foreach (Serie serie in currentUser.FollowSeries)
                        {
                            LikesdataGrid.Rows.Add(serie.Image, serie.SerieName, serie.NofVideos);
                        }
                        break;
                    }
                    else
                    {
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }

                case "Users":
                    if (FollowsButtom.Tag.ToString() == "no")
                    {
                        FollowsButtom.Tag = "si";
                        FollowsButtom.BackColor = System.Drawing.Color.Silver;
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesdataGrid.Columns[0].HeaderText = "Followed users";
                        LikesdataGrid.Columns[1].HeaderText = "Nickname";
                        LikesdataGrid.Columns[2].HeaderText = "N of playlist";
                        foreach (User user in currentUser.FollowUsers)
                        {
                            LikesdataGrid.Rows.Add(user.Profileimage, user.Name, user.MyPlaylist.Count());
                        }
                        break;
                    }
                    else
                    {
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }

                case "Albums":
                    if (AlbumsButtom.Tag.ToString() == "no")
                    {
                        AlbumsButtom.Tag = "si";
                        AlbumsButtom.BackColor = System.Drawing.Color.Silver;
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21); 
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);

                        LikesdataGrid.Columns[0].HeaderText = "Followed albums";
                        LikesdataGrid.Columns[1].HeaderText = "name";
                        LikesdataGrid.Columns[2].HeaderText = "N of mediafiles";
                        foreach (Album album in currentUser.FollowAlbums)
                        {
                            LikesdataGrid.Rows.Add(album.Songs[0].Image, album.Name, album.Songs.Count());
                        }
                        break;
                    }
                    else
                    {
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }

                case "Artist":
                    if (ArtistsButtom.Tag.ToString() == "no")
                    {
                        QuequeButton.Tag = "no";
                        QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        ForYouButton.Tag = "no";
                        ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        LikesButtom.Tag = "no";
                        LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ForYouButtom.Tag = "no";
                        ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        AlbumsButtom.Tag = "no";
                        AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        FollowsButtom.Tag = "no";
                        FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "si";
                        ArtistsButtom.BackColor = System.Drawing.Color.Silver;
                        LikesdataGrid.Columns[0].HeaderText = "Followed artist";
                        LikesdataGrid.Columns[1].HeaderText = "name";
                        LikesdataGrid.Columns[2].HeaderText = "N of songs";
                        foreach (Artist artist in currentUser.FollowArtist)
                        {
                            LikesdataGrid.Rows.Add(artist.Songs[0].Image, artist.Name, artist.Songs.Count());
                        }
                        break;
                    }
                    else
                    {
                        ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        ArtistsButtom.Tag = "no";
                        LikedPanel.Visible = false;
                        break;
                    }

                default:
                    break;
            }

            if (Player.Tag.ToString() == currentpanel.Text)
            {
                PlayerPanel.Visible = true;
                PlayerBack.Visible = true;
                PlayerBack.BringToFront();
                EditProfileButton.Visible = true;
                EditProfileButton.BringToFront();
                PlayerPanel.BringToFront();
            }
            else
            {
                if (ExtraPanel.Controls.GetChildIndex(LikedPanel) != 0)
                {
                    LikedPanel.BringToFront();
                }
            }
            Player.Tag = currentpanel.Text;
            foreach (DataGridViewRow row in LikesdataGrid.Rows)
            {
                row.MinimumHeight = 50;
            }
        }

        //CustomPlay
        private void CustomPlay()
        {
            if (index < mediaPlayer.Queue.Count())
            {
                NextSong.Start();
                Player.Ctlcontrols.stop();

                MediaFile mediafile = mediaPlayer.Queue[index];
                currentlyPlaying = mediafile;
                mediaPlayer.Play(mediafile);
                Player.URL = currentlyPlaying.Name + ".mp4";

                Star1Button.Tag = "no";
                Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star2Button.Tag = "no";
                Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star3Button.Tag = "no";
                Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star4Button.Tag = "no";
                Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                Star5Button.Tag = "no";
                Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
                LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                LikeSongorVideo.Tag = "no";
                QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                QuequeButton.Tag = "no";

                bool karaoke = mediaPlayer.Karaokes.Any(u => u.Bytes.SequenceEqual(mediafile.Bytes));
                if (karaoke)
                {
                    lyric = 0;
                    Karaoke aux = mediaPlayer.Karaokes.Where(u => u.Bytes.SequenceEqual(mediafile.Bytes)).FirstOrDefault();
                    KaraokeTimer.Enabled = true;
                    KaraokeTimer.Start();
                    if (Convert.ToDouble(aux.Lyrics[lyric]) == 0)
                    {
                        KaraokeTimer.Interval = 1000;
                    }
                    else
                    {
                        double a = Convert.ToDouble(aux.Lyrics[lyric]);
                        a += Convert.ToDouble(aux.Lyrics[lyric + 2]) / 2;
                        KaraokeTimer.Interval = Convert.ToInt32(Math.Truncate(a));
                    }
                    karaokeText.SelectionAlignment = HorizontalAlignment.Center;
                    karaokeText.Text = aux.Lyrics[lyric + 1];
                    karaokeText.Text += aux.Lyrics[lyric + 3];
                    karaokeText.Text += aux.Lyrics[lyric + 5];
                    karaokeText.Visible = true;
                    karaokeText.BringToFront();
                }
                else
                {
                    karaokeText.Visible = false;
                    karaokeText.SendToBack();
                    lyric = 0;
                }

                if (currentUser.LikedSongs.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)) || currentUser.LikedVideos.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)) || currentUser.LikedKarokes.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)))
                {
                    LikeSongorVideo.Tag = "si";
                    LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_rojo;
                }
                else
                {
                    LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                    LikeSongorVideo.Tag = "no";
                }

                double secs = Math.Truncate(currentlyPlaying.Length.TotalSeconds);
                progressBar1.Value = 0;
                progressBar1.Maximum = Convert.ToInt32(secs);
                NextSong.Interval = progressBar1.Maximum * 1000;
                Player.URL = currentlyPlaying.Name + ".mp4";
                Player.Ctlcontrols.play();
                NextSong.Enabled = true;
                string output = string.Format("{0}:{1:00}", (int)currentlyPlaying.Length.TotalMinutes, currentlyPlaying.Length.Seconds);
                ReproductorPictureBox.Image = currentlyPlaying.Image;
                ToName.Text = currentlyPlaying.Name;
                ToAlbum.Text = output;
                ToArtist.Text = currentlyPlaying.Genre;
                GC.Collect();
            }
        }

        //Revisar video
        public void videoChecker()
        {
            foreach (Video video in mediaPlayer.Videos)
            {
                mediaPlayer.Play(video);
                Player.URL = video.Name + ".mp4";
                Player.Ctlcontrols.play();
                Player.Dock = System.Windows.Forms.DockStyle.Fill;
                video.Dimension = Player.Width.ToString() + "x" + Player.Height.ToString();
                Player.Ctlcontrols.stop();
            }
            foreach (Video video in mediaPlayer.VideoChapters)
            {
                mediaPlayer.Play(video);
                Player.URL = video.Name + ".mp4";
                Player.Ctlcontrols.play();
                Player.Dock = System.Windows.Forms.DockStyle.Fill;
                video.Dimension = Player.Width.ToString() + "x" + Player.Height.ToString();
                Player.Ctlcontrols.stop();
            }
        }

        //Iniciar Player
        public void initializePlayer()
        {
            index = 0;
            videoChecker();
            ToArtist.Text = "";
            ToAlbum.Text = "";
            ToName.Text = "";
            LikesdataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            SearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            PlayerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            Player.BringToFront();
            if (currentUser.Lastsong != null)
            {
                mediaPlayer.Queue.Add(currentUser.Lastsong);
                CustomPlay();
                Player.Ctlcontrols.stop();
                CurrentSong.Stop();
                NextSong.Stop();
                KaraokeTimer.Stop();
                Player.Ctlcontrols.currentPosition += currentUser.CurrentSec;
                if (progressBar1.Value + currentUser.CurrentSec > progressBar1.Maximum)
                {
                    progressBar1.Value = 0;
                }
                else
                {
                    progressBar1.Value += currentUser.CurrentSec;
                }
                PlayPausaButtom.BackgroundImage = Spotflix.Properties.Resources.play_130;
                PlayPausaButtom.Tag = "play";

            }
            PlaylistsDataGrid.Rows.Clear();
            foreach (Playlist playlist in currentUser.MyPlaylist)
            {
                PlaylistsDataGrid.Rows.Add(playlist.Image, playlist.PlaylistName, playlist.Songs.Count() + playlist.Videos.Count()+playlist.Karaokes.Count());
            }
        }

        //Back
        private void BackPlayer_Click(object sender, EventArgs e)
        {
            if (index >= 1)
            {
                index--;
                CustomPlay();
            }
            else
            {
                CustomPlay();
            }
        }

        //Next
        private void NextPlay_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.Queue.Count() > index + 1)
            {
                index++;
                CustomPlay();
            }
            else
            {
                CustomPlay();
            }
        }

        private void NextSong_Tick(object sender, EventArgs e)
        {
            index++;
            CustomPlay();
        }

        //Volumen
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            Player.settings.volume = trackBar1.Value;
        }

        //Cambios de estado
        private void Player_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (currentlyPlaying is null)
            {

            }
            else
            {
                if (e.newState == 8)
                {
                    currentlyPlaying.NumberOfReproductions++;
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

        //Poner me gusta
        private void LikeSongorVideo_Click(object sender, EventArgs e)
        {
            if (currentlyPlaying != null)
            {
                if (LikeSongorVideo.Tag.ToString() == "si")
                {
                    LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                    LikeSongorVideo.Tag = "no";
                }
                else
                {
                    LikeSongorVideo.Tag = "si";
                    LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_rojo;
                }
                Song song = null;
                Video video = null;
                Karaoke karaoke = null;
                karaoke = mediaPlayer.Karaokes.Where(u => u.Name == currentlyPlaying.Name).FirstOrDefault();
                song = mediaPlayer.Songs.Where(u => u.Name == currentlyPlaying.Name).FirstOrDefault();
                video = mediaPlayer.Videos.Where(u => u.Name == currentlyPlaying.Name).FirstOrDefault();
                if (video is null)
                {
                    video = mediaPlayer.VideoChapters.Where(u => u.Name == currentlyPlaying.Name).FirstOrDefault();
                }
                if (currentUser.LikedSongs.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)) || currentUser.LikedVideos.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)) || currentUser.LikedKarokes.Any(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)))
                {
                    if (song is null && karaoke is null)
                    {
                        currentUser.LikedVideos.Remove(video);
                        video.Likes--;
                    }
                    else if (karaoke is null)
                    {
                        song.Likes--;
                        currentUser.LikedSongs.Remove(song);
                    }
                    else
                    {
                        karaoke.Likes--;
                        currentUser.LikedKarokes.Remove(karaoke);
                    }
                }
                else
                {
                    if (song is null && karaoke is null)
                    {
                        currentUser.LikedVideos.Add(video);
                        video.Likes++;
                    }
                    else if (karaoke is null)
                    {
                        song.Likes++;
                        currentUser.LikedSongs.Add(song);
                    }
                    else
                    {
                        karaoke.Likes++;
                        currentUser.LikedKarokes.Add(karaoke);
                    }
                }
            }
            else
            {

                LikeSongorVideo.Tag = "no";
                LikeSongorVideo.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
            }

            SaveUser();
            SaveSong();
            SaveVideo();
            SaveKaroke();
            SaveSeries(); 
        }

        //Timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
        }

        //Realizar búsquedas
        private void ExploreButtom_Click(object sender, EventArgs e)
        {
            SearchPanel.Visible = true;
            if (ExtraPanel.Controls.GetChildIndex(SearchPanel) == 0)
            {
                Player.BringToFront();
            }
            else
            {
                MediaSearcherData.Rows.Clear();
                ArtistSearcherData.Rows.Clear();
                PlaylistSearcherData.Rows.Clear();
                AlbumsSearcherData.Rows.Clear();
                SearcherUsersData.Rows.Clear();

                SearchPanel.BringToFront();
                SearchTextBox.Text = "Search";
                SearcherTableResults.Visible = false;
                QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                QuequeButton.Tag = "no";
                ForYouButton.Tag = "no";
                ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                LikesButtom.Tag = "no";
                LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ForYouButtom.Tag = "no";
                ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                AlbumsButtom.Tag = "no";
                AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ArtistsButtom.Tag = "no";
                ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                FollowsButtom.Tag = "no";
                FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text != "")
            {
                MediaSearcherData.Visible = true;
                PlaylistSearcherData.Visible = true;
                AlbumsSearcherData.Visible = true;
                SearcherUsersData.Visible = true;
                ArtistSearcherData.Visible = true;

                MediaSearcherData.Rows.Clear();
                PlaylistSearcherData.Rows.Clear();
                AlbumsSearcherData.Rows.Clear();
                SearcherUsersData.Rows.Clear();
                ArtistSearcherData.Rows.Clear();

                Searcher.Brain(SearchTextBox.Text);
                foreach (Song song in mediaPlayer.Foundsongs)
                {
                    string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                    MediaSearcherData.Rows.Add(song.Image, song.Name, output);
                }
                foreach (Video video in mediaPlayer.Foundvideos)
                {
                    string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                    MediaSearcherData.Rows.Add(video.Image, video.Name, output);
                }
                foreach (Karaoke karaoke in mediaPlayer.Foundkaraokes)
                {
                    string output = string.Format("{0}:{1:00}", (int)karaoke.Length.TotalMinutes, karaoke.Length.Seconds);
                    MediaSearcherData.Rows.Add(karaoke.Image, karaoke.Name, output);
                }
                foreach (DataGridViewRow row in MediaSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }

                MediaSearcherData.Columns[0].HeaderText = "Found media";
                MediaSearcherData.Columns[1].HeaderText = "Name";
                MediaSearcherData.Columns[2].HeaderText = "Duration";

                foreach (Playlist playlist in mediaPlayer.Foundplaylist)
                {
                    if (playlist.Publicornot == "public")
                    {
                        PlaylistSearcherData.Rows.Add(playlist.Image, playlist.PlaylistName, playlist.Videos.Count() + playlist.Songs.Count()+playlist.Karaokes.Count());
                    }
                }
                foreach (Serie serie in mediaPlayer.Foundseries)
                {
                    PlaylistSearcherData.Rows.Add(serie.Image, serie.SerieName, serie.Episodes.Count());
                }
                foreach (DataGridViewRow row in PlaylistSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                PlaylistSearcherData.Columns[0].HeaderText = "Found playlist/series";
                PlaylistSearcherData.Columns[1].HeaderText = "name";
                PlaylistSearcherData.Columns[2].HeaderText = "N of mediafiles";

                foreach (Album album in mediaPlayer.Foundalbums)
                {
                    string aux = String.Join(",", album.Artists);
                    AlbumsSearcherData.Rows.Add(album.Songs[0].Image, album.Name, aux);
                }
                foreach (DataGridViewRow row in AlbumsSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                AlbumsSearcherData.Columns[0].HeaderText = "Found albums";
                AlbumsSearcherData.Columns[1].HeaderText = "name";
                AlbumsSearcherData.Columns[2].HeaderText = "Aritst";

                foreach (User user in Gate.Foundusers)
                {
                    if (user.PrivPubl == "publico" && !user.Equals(currentUser))
                    {
                        SearcherUsersData.Rows.Add(user.Profileimage, user.Nickname, user.Age);
                    }
                }
                foreach (DataGridViewRow row in SearcherUsersData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                SearcherUsersData.Columns[0].HeaderText = "Found users";
                SearcherUsersData.Columns[1].HeaderText = "Nickname";
                SearcherUsersData.Columns[2].HeaderText = "Age";

                foreach (Artist artist in mediaPlayer.Foundartists)
                {
                    if (artist.Songs.Count > 0)
                    {
                        ArtistSearcherData.Rows.Add(artist.Songs[0].Image, artist.Name, artist.Songs.Count() + artist.Videos.Count() + artist.Karaokes.Count());
                    }
                    else if (artist.Videos.Count > 0)
                    {
                        ArtistSearcherData.Rows.Add(artist.Videos[0].Image, artist.Name, artist.Songs.Count() + artist.Videos.Count() + artist.Karaokes.Count());
                    }
                    else if (artist.Karaokes.Count > 0)
                    {
                        ArtistSearcherData.Rows.Add(artist.Karaokes[0].Image, artist.Name, artist.Songs.Count() + artist.Videos.Count() + artist.Karaokes.Count());
                    }
                }
                foreach (DataGridViewRow row in ArtistSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                ArtistSearcherData.Columns[0].HeaderText = "Found artist";
                ArtistSearcherData.Columns[1].HeaderText = "name";
                ArtistSearcherData.Columns[2].HeaderText = "N of Songs";

                if (mediaPlayer.Songs.Count() == 0 && mediaPlayer.Videos.Count() == 0 && mediaPlayer.Foundkaraokes.Count() == 0)
                {
                    MediaSearcherData.Visible = false;
                }
                else
                {
                    MediaSearcherData.Visible = true;
                }
                if (PlaylistSearcherData.RowCount == 0)
                {
                    PlaylistSearcherData.Visible = false;
                }
                else
                {
                    PlaylistSearcherData.Visible = true;
                }
                if (mediaPlayer.Foundalbums.Count() == 0)
                {
                    AlbumsSearcherData.Visible = false;
                }
                else
                {
                    AlbumsSearcherData.Visible = true;
                }
                if (SearcherUsersData.RowCount == 0)
                {
                    SearcherUsersData.Visible = false;
                }
                else
                {
                    SearcherUsersData.Visible = true;
                }
                if (mediaPlayer.Foundartists.Count() == 0)
                {
                    ArtistSearcherData.Visible = false;
                }
                else
                {
                    ArtistSearcherData.Visible = true;
                }
                SearchPanel.Visible = true;
                SearcherImagePanel.Visible = true;
                SearcherTableResults.Visible = true;
            }
        }

        private void SeerachSmartTextBox_Click(object sender, EventArgs e)
        {
            if (SeerachSmartTextBox.Text == "Search")
            {
                SeerachSmartTextBox.Text = "";
            }
        }

        private void SearchTextBox_Click(object sender, EventArgs e)
        {
            if (SearchTextBox.Text == "Search")
            {
                SearcherTableResults.Visible = true;
                SearchTextBox.Text = "";
            }
        }


        //DataGrid
        private void DataGridClicked(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridView dgw = (DataGridView)sender;
                if (dgw.Columns[0].HeaderText == "Playlist Media" || dgw.Columns[0].HeaderText == "Found media" || dgw.Columns[0].HeaderText == "Liked media" || dgw.Columns[0].HeaderText == "Media" || dgw.Columns[0].HeaderText == "Preferences media" || dgw.Columns[0].HeaderText == "Queue")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Song song = null;
                    Video video = null;
                    Karaoke karaoke = null;
                    song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                    video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                    if (video is null)
                    {
                        video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                    }
                    karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                    if (song is null && karaoke is null)
                    {
                        if (mediaPlayer.Queue.Count == 0)
                        {
                            mediaPlayer.Queue.Add(video);
                        }
                        else
                        {
                            mediaPlayer.Queue.Insert(0, video);
                        }
                    }
                    else if (song is null)
                    {
                        if (mediaPlayer.Queue.Count == 0)
                        {
                            mediaPlayer.Queue.Add(karaoke);
                        }
                        else
                        {
                            mediaPlayer.Queue.Insert(0, karaoke);
                        }
                    }
                    else
                    {
                        if (mediaPlayer.Queue.Count == 0)
                        {
                            mediaPlayer.Queue.Add(song);
                        }
                        else
                        {
                            mediaPlayer.Queue.Insert(0, song);
                        }
                    }
                    foreach (DataGridViewRow row in LikesdataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }
                    CustomPlay();
                    Player.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found playlist/series" || dgw.Columns[0].HeaderText == "Followed playlist/series" || dgw.Columns[0].HeaderText == "Found playlist" || dgw.Columns[0].HeaderText == "My playlists")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Playlist playlist = null;
                    Serie serie = null;
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == name).FirstOrDefault();
                    serie = mediaPlayer.Series.Where(u => u.SerieName == name).FirstOrDefault();
                    if (dgw.Columns[0].HeaderText == "My playlists")
                    {
                        LikesdataGrid.Columns[0].HeaderText = "Playlist Media";
                    }
                    else
                    {
                        LikesdataGrid.Columns[0].HeaderText = "Media";
                    }
                    LikesdataGrid.Columns[1].HeaderText = "Name";
                    LikesdataGrid.Columns[2].HeaderText = "Duration";
                    LikesdataGrid.Rows.Clear();
                    if (playlist is null)
                    {
                        foreach (Video video in serie.Episodes)
                        {
                            string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                            LikesdataGrid.Rows.Add(video.Image, video.Name, output);
                        }
                    }
                    else
                    {
                        foreach (Video video in playlist.Videos)
                        {
                            string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                            LikesdataGrid.Rows.Add(video.Image, video.Name, output);
                        }
                        foreach (Song song in playlist.Songs)
                        {
                            string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                            LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                        }
                        foreach (Karaoke song in playlist.Karaokes)
                        {
                            string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                            LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                        }

                    }
                    foreach (DataGridViewRow row in LikesdataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }

                    LikedPanel.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found users" || dgw.Columns[0].HeaderText == "Followed users")
                {

                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    User user = Gate.Users.Where(u => u.Nickname == name).FirstOrDefault();
                    LikesdataGrid.Columns[0].HeaderText = "Found playlist";
                    LikesdataGrid.Columns[1].HeaderText = "name";
                    LikesdataGrid.Columns[2].HeaderText = "N of mediafiles";
                    LikesdataGrid.Visible = true;
                    LikesdataGrid.Rows.Clear();
                    foreach (Playlist playlist in user.MyPlaylist)
                    {
                        LikesdataGrid.Rows.Add(playlist.Image, playlist.PlaylistName, playlist.Songs.Count() + playlist.Videos.Count() + playlist.Karaokes.Count());
                    }
                    foreach (DataGridViewRow row in LikesdataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }
                    LikedPanel.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found albums" || dgw.Columns[0].HeaderText == "Followed albums")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();

                    Album album = mediaPlayer.Albums.Where(u => u.Name == name).FirstOrDefault();
                    LikesdataGrid.Columns[0].HeaderText = "Media";
                    LikesdataGrid.Columns[1].HeaderText = "name";
                    LikesdataGrid.Columns[2].HeaderText = "Artist";
                    LikesdataGrid.Visible = true;
                    LikesdataGrid.Rows.Clear();
                    foreach (Song song in album.Songs)
                    {
                        string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                        LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                    }
                    foreach (DataGridViewRow row in LikesdataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }
                    LikesdataGrid.Visible = true;
                    LikedPanel.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found artist" || dgw.Columns[0].HeaderText == "Followed artist")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Artist artist = mediaPlayer.Artists.Where(u => u.Name == name).FirstOrDefault();
                    LikesdataGrid.Columns[0].HeaderText = "Media";
                    LikesdataGrid.Columns[1].HeaderText = "name";
                    LikesdataGrid.Columns[2].HeaderText = "Duration";
                    LikesdataGrid.Visible = true;
                    LikesdataGrid.BringToFront();
                    LikesdataGrid.Rows.Clear();
                    foreach (Song song in artist.Songs)
                    {
                        string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                        LikesdataGrid.Rows.Add(song.Image, song.Name, output);
                    }
                    foreach (Karaoke karaoke in artist.Karaokes)
                    {
                        string output = string.Format("{0}:{1:00}", (int)karaoke.Length.TotalMinutes, karaoke.Length.Seconds);
                        LikesdataGrid.Rows.Add(karaoke.Image, karaoke.Name, output);
                    }
                    foreach (Video video in artist.Videos)
                    {
                        string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                        LikesdataGrid.Rows.Add(video.Image, video.Name, output);
                    }
                    foreach (DataGridViewRow row in LikesdataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }
                    LikedPanel.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found lesson"|| dgw.Columns[0].HeaderText == "Lesson"|| dgw.Columns[0].HeaderText == "Your Lessons")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Lesson lesson = null;
                    lesson = mediaPlayer.Lessons.Where(u => u.Name == name).FirstOrDefault();
                    if (lesson !=null)
                    {
                        if (mediaPlayer.Queuestudent.Count()==0)
                        {
                            mediaPlayer.Queuestudent.Add(lesson);
                        }
                        else
                        {
                            mediaPlayer.Queuestudent.Insert(0, lesson);
                        }
                    }
                    foreach (DataGridViewRow row in StudentDataGrid.Rows)
                    {
                        row.MinimumHeight = 50;
                    }
                    LikesdataGrid.Visible = true;
                    CustomPlayStudent();
                    SPlayer.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found teacher")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Teacher teacher = null;
                    teacher = Gate.Teachers.Where(u => u.Name == name).FirstOrDefault();
                    StudentDataGrid.Rows.Clear();
                    if (teacher != null)
                    {
                        StudentDataGrid.Columns[0].HeaderText = "Lesson";
                        StudentDataGrid.Columns[1].HeaderText = "Name";
                        StudentDataGrid.Columns[2].HeaderText = "Teacher";
                        StudentDataGrid.Columns[3].HeaderText = "Course";
                        StudentDataGrid.Columns[4].HeaderText = "Subject";

                        StudentDataGrid.Visible = true;
                        StudentDataGrid.BringToFront();
                        StudentDataGrid.Rows.Clear();
                        foreach (Lesson lesson in teacher.Lessons)
                        {
                            User user = Gate.Users.Where(u => u.Gmail == teacher.Gmail).FirstOrDefault();
                            if (user!=null)
                            {
                                string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                                StudentDataGrid.Rows.Add(output, lesson.Name, lesson.Teacher.Name,lesson.Course,lesson.Subject);
                            }                           
                        }
                        foreach (DataGridViewRow row in StudentDataGrid.Rows)
                        {
                            row.MinimumHeight = 50;
                        }
                    }
                    DataStudentGrid.Visible = true;
                    DataStudentGrid.BringToFront();
                }
                else if (dgw.Columns[0].HeaderText == "Found student")
                {
                    string name = dgw.Rows[e.RowIndex].Cells[1].Value.ToString();
                    Student student = null;
                    StudentDataGrid.Rows.Clear();
                    student = Gate.Students.Where(u => u.Name+" "+u.Lastname == name).FirstOrDefault();
                    if (student != null)
                    {
                        StudentDataGrid.Columns[0].HeaderText = "Lesson";
                        StudentDataGrid.Columns[1].HeaderText = "Name";
                        StudentDataGrid.Columns[2].HeaderText = "Teacher";
                        StudentDataGrid.Columns[3].HeaderText = "Course";
                        StudentDataGrid.Columns[4].HeaderText = "Subject";
                        StudentDataGrid.Visible = true;
                        StudentDataGrid.BringToFront();
                        StudentDataGrid.Rows.Clear();
                        foreach (Lesson lesson in student.LikedLesson)
                        {
                            string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                            StudentDataGrid.Rows.Add(output, lesson.Name, lesson.Teacher.Name,lesson.Course,lesson.Subject);
                        }
                        foreach (DataGridViewRow row in StudentDataGrid.Rows)
                        {
                            row.MinimumHeight = 50;
                        }
                        StudentDataGrid.Visible = true;
                        StudentDataGrid.BringToFront();
                    }
                    DataStudentGrid.Visible = true;
                    DataStudentGrid.BringToFront();
                }
                LikedPanel.Visible = true;
                DataStudentGrid.Visible = true;
                QuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                QuequeButton.Tag = "no";
                ForYouButton.Tag = "no";
                ForYouButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                LikesButtom.Tag = "no";
                LikesButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ForYouButtom.Tag = "no";
                ForYouButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                AlbumsButtom.Tag = "no";
                AlbumsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                ArtistsButtom.Tag = "no";
                ArtistsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                FollowsButtom.Tag = "no";
                FollowsButtom.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            }
        }

        private void DataGridMouseClick(object sender, MouseEventArgs e)
        {
            DataGridView dgw = (DataGridView)sender;
            if (e.Button == MouseButtons.Right && dgw.HitTest(e.X, e.Y).RowIndex >= 0)
            {
                int position = dgw.HitTest(e.X, e.Y).RowIndex;
                if (dgw.Columns[0].HeaderText == "Playlist Media" || dgw.Columns[0].HeaderText == "Found media" || dgw.Columns[0].HeaderText == "Liked media" || dgw.Columns[0].HeaderText == "Media" || dgw.Columns[0].HeaderText == "Preferences media" || dgw.Columns[0].HeaderText == "Queue")
                {
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    mediamenu.Items.Add("Add to queue").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.Items.Add("Add to playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();

                    foreach (Playlist playlist in currentUser.MyPlaylist)
                    {
                        (mediamenu.Items[1] as ToolStripMenuItem).DropDownItems.Add(playlist.PlaylistName).Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    (mediamenu.Items[1] as ToolStripMenuItem).BackColor = System.Drawing.Color.Black;
                    (mediamenu.Items[1] as ToolStripMenuItem).ForeColor = System.Drawing.Color.White;
                    (mediamenu.Items[1] as ToolStripMenuItem).DropDownItemClicked += new ToolStripItemClickedEventHandler(playlist_selected);
                    if (dgw.Columns[0].HeaderText == "Playlist Media")
                    {
                        mediamenu.Items.Add("Remove from playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        foreach (Playlist playlist in currentUser.MyPlaylist)
                        {
                            (mediamenu.Items[2] as ToolStripMenuItem).DropDownItems.Add(playlist.PlaylistName).Name = dgw.Rows[position].Cells[1].Value.ToString();
                        }
                        (mediamenu.Items[2] as ToolStripMenuItem).BackColor = System.Drawing.Color.Black;
                        (mediamenu.Items[2] as ToolStripMenuItem).ForeColor = System.Drawing.Color.White;
                        (mediamenu.Items[2] as ToolStripMenuItem).DropDownItemClicked += new ToolStripItemClickedEventHandler(delete_from_playlist);
                    }

                    mediamenu.Items.Add("View information on the platform about the mediafile").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.Items.Add("View metadata information about the mediafile").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.Items.Add("View intrinsic information about the mediafile").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.Items.Add("Download Song").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(mediamenu_Item_clicked);
                }
                else if (dgw.Columns[0].HeaderText == "Found playlist/series" || dgw.Columns[0].HeaderText == "Followed playlist/series" || dgw.Columns[0].HeaderText == "My playlists" || dgw.Columns[0].HeaderText == "Found playlists")
                {
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    Playlist playlist = null;
                    Serie serie = null;
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == dgw.Rows[position].Cells[1].Value.ToString()).FirstOrDefault();
                    serie = mediaPlayer.Series.Where(u => u.SerieName == dgw.Rows[position].Cells[1].Value.ToString()).FirstOrDefault();
                    mediamenu.Items.Add("Play playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    if (dgw.Columns[0].HeaderText == "My playlists")
                    {
                        mediamenu.Items.Add("Delete playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        if (playlist.Publicornot == "private")
                        {
                            mediamenu.Items.Add("Make playlist public").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        }
                        else
                        {
                            mediamenu.Items.Add("Make playlist private").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        }
                    }
                    else
                    {
                        if (currentUser.FollowPlaylist.Any(u => u.Equals(playlist)) || currentUser.FollowSeries.Any(u => u.Equals(serie)))
                        {
                            mediamenu.Items.Add("Unfollow playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        }
                        else
                        {
                            mediamenu.Items.Add("Follow playlist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                        }
                    }

                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(right_clicked_playlist);
                }
                else if (dgw.Columns[0].HeaderText == "Found users" || dgw.Columns[0].HeaderText == "Followed users")
                {
                    string name = dgw.Rows[position].Cells[1].Value.ToString();
                    User user = Gate.Users.Where(u => u.Nickname == name).FirstOrDefault();
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    if (currentUser.FollowUsers.Any(u => u.Equals(user)))
                    {
                        mediamenu.Items.Add("Unfollow user").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    else
                    {
                        mediamenu.Items.Add("Follow user").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(user_followed);
                }
                else if (dgw.Columns[0].HeaderText == "Found albums" || dgw.Columns[0].HeaderText == "Followed albums")
                {
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    mediamenu.Items.Add("Play album").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    string name = dgw.Rows[position].Cells[1].Value.ToString();
                    Album album = mediaPlayer.Albums.Where(u => u.Name == name).FirstOrDefault();
                    if (currentUser.FollowAlbums.Any(u => u.Equals(album)))
                    {
                        mediamenu.Items.Add("Unfollow album").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    else
                    {
                        mediamenu.Items.Add("Follow album").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }

                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(right_clicked_album);
                }
                else if (dgw.Columns[0].HeaderText == "Found artist" || dgw.Columns[0].HeaderText == "Followed artist")
                {
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    mediamenu.Items.Add("Play artist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    string name = dgw.Rows[position].Cells[1].Value.ToString();
                    Artist artist = mediaPlayer.Artists.Where(u => u.Name == name).FirstOrDefault();
                    if (currentUser.FollowArtist.Any(u => u.Equals(artist)))
                    {
                        mediamenu.Items.Add("Unfollow artist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    else
                    {
                        mediamenu.Items.Add("Follow artist").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(right_clicked_artist);
                }
                else if (dgw.Columns[0].HeaderText == "Found lesson" || dgw.Columns[0].HeaderText == "Lesson" || dgw.Columns[0].HeaderText == "Your Lessons")
                {
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    mediamenu.Items.Add("Add to queue").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(lessonmenu_Item_clicked);
                }
                else if (dgw.Columns[0].HeaderText == "Found teacher")
                {
                    string name = dgw.Rows[position].Cells[1].Value.ToString();
                    Teacher teacher = Gate.Teachers.Where(u => u.Name == name).FirstOrDefault();
                    ContextMenuStrip mediamenu = new System.Windows.Forms.ContextMenuStrip();
                    if (currentStudent.FollowTeachers.Any(u => u.Equals(teacher)))
                    {
                        mediamenu.Items.Add("Unfollow teacher").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    else
                    {
                        mediamenu.Items.Add("Follow teacher").Name = dgw.Rows[position].Cells[1].Value.ToString();
                    }
                    mediamenu.BackColor = System.Drawing.Color.Black;
                    mediamenu.ForeColor = System.Drawing.Color.White;
                    mediamenu.Show(dgw, new Point(e.X, e.Y));
                    mediamenu.ItemClicked += new ToolStripItemClickedEventHandler(teacher_item_clicked);
                }
                else if (dgw.Columns[0].HeaderText == "Found student")
                {

                }
            }
        }

        private void right_clicked_artist(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name.ToString();
            Artist artist = mediaPlayer.Artists.Where(u => u.Name == name).FirstOrDefault();
            switch (e.ClickedItem.ToString())
            {
                case "Play artist":
                    mediaPlayer.Queue.InsertRange(0, artist.Songs);
                    mediaPlayer.Queue.InsertRange(0, artist.Karaokes);
                    mediaPlayer.Queue.InsertRange(0, artist.Videos);
                    ; break;
                case "Follow artist":
                    currentUser.FollowArtist.Add(artist);
                    break;
                case "Unfollow artist":
                    currentUser.FollowArtist.Remove(artist);
                    break;
                default:
                    break;
            }
            SaveUser();
            SaveArtist();
        }

        private void right_clicked_album(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name.ToString();
            Album album = mediaPlayer.Albums.Where(u => u.Name == name).FirstOrDefault();
            switch (e.ClickedItem.ToString())
            {
                case "Play album":
                    mediaPlayer.Queue.InsertRange(0, album.Songs);
                    break;
                case "Follow album":
                    currentUser.FollowAlbums.Add(album);
                    break;
                case "Unfollow album":
                    currentUser.FollowAlbums.Remove(album);
                    break;
                default:
                    break;
            }
            SaveUser();
            SaveAlbum();
        }

        private void user_followed(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name.ToString();
            User user = Gate.Users.Where(u => u.Nickname == name).FirstOrDefault();
            switch (e.ClickedItem.ToString())
            {
                case "Follow user":
                    currentUser.FollowUsers.Add(user);
                    break;
                case "Unfollow user":
                    currentUser.FollowUsers.Remove(user);
                    break;
                default:
                    break;
            }
            SaveUser();
        }

        private void right_clicked_playlist(object sender, ToolStripItemClickedEventArgs e)
        {
            string aux = e.ClickedItem.ToString();
            switch (aux)
            {
                case "Play playlist":
                    string name = e.ClickedItem.Name.ToString();
                    Playlist playlist = null;
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == name).FirstOrDefault();
                    Serie serie = mediaPlayer.Series.Where(u => u.SerieName == name).FirstOrDefault();
                    if (playlist is null)
                    {
                        foreach (Video video in serie.Episodes)
                        {
                            mediaPlayer.Queue.Add(video);
                        }
                    }
                    else
                    {
                        foreach (Video video in playlist.Videos)
                        {
                            mediaPlayer.Queue.Add(video);
                        }
                        foreach (Song song in playlist.Songs)
                        {
                            mediaPlayer.Queue.Add(song);
                        }
                    }
                    break;
                case "Follow playlist":
                    playlist = null;
                    serie = null;
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    serie = mediaPlayer.Series.Where(u => u.SerieName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    if (playlist is null)
                    {
                        currentUser.FollowSeries.Add(serie);
                    }
                    else
                    {
                        currentUser.FollowPlaylist.Add(playlist);
                    }
                    SaveUser();
                    SavePlaylist();
                    SaveSeries();
                    break;
                case "Unfollow playlist":
                    playlist = null;
                    serie = null;
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    serie = mediaPlayer.Series.Where(u => u.SerieName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    if (playlist is null)
                    {
                        currentUser.FollowSeries.Remove(serie);
                    }
                    else
                    {
                        currentUser.FollowPlaylist.Remove(playlist);
                    }
                    SaveUser();
                    SavePlaylist();
                    SaveSeries();
                    break;
                case "Delete playlist":
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    mediaPlayer.Playlists.Remove(playlist);
                    playlist = currentUser.MyPlaylist.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    foreach (User user in Gate.Users)
                    {
                        if (user.FollowPlaylist.Any(u => u.Equals(playlist)))
                        {
                            user.FollowPlaylist.Remove(playlist);
                        }
                    }
                    currentUser.MyPlaylist.Remove(playlist);
                    SaveUser();
                    SavePlaylist();
                    PlaylistsDataGrid.Rows.Clear();
                    foreach (Playlist pl in currentUser.MyPlaylist)
                    {
                        PlaylistsDataGrid.Rows.Add(pl.Image, pl.PlaylistName, pl.Songs.Count() + pl.Videos.Count());
                    }
                    break;
                case "Make playlist public":
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    playlist.Publicornot = "public";
                    playlist = currentUser.MyPlaylist.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    playlist.Publicornot = "public";
                    SaveUser();
                    SavePlaylist();
                    break;
                case "Make playlist private":
                    playlist = mediaPlayer.Playlists.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    foreach (User user in Gate.Users)
                    {
                        if (user.FollowPlaylist.Any(u => u.Equals(playlist)))
                        {
                            user.FollowPlaylist.Remove(playlist);
                        }
                    }
                    playlist.Publicornot = "private";
                    playlist = currentUser.MyPlaylist.Where(u => u.PlaylistName == e.ClickedItem.Name.ToString()).FirstOrDefault();
                    playlist.Publicornot = "private";
                    SaveUser();
                    SavePlaylist();
                    break;
                default:
                    break;
            }
        }

        private void playlist_selected(object sender, ToolStripItemClickedEventArgs e)
        {
            Playlist playlist = null;
            playlist = currentUser.MyPlaylist.Where(u => u.PlaylistName == e.ClickedItem.ToString()).FirstOrDefault();
            if (playlist != null)
            {
                string name = e.ClickedItem.Name.ToString();
                Song song = null;
                Video video = null;
                song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                Karaoke karaoke = null;
                karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                if (video is null)
                {
                    video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                }
                if (song is null && karaoke is null)
                {
                    playlist.Videos.Add(video);
                }
                else if (karaoke is null)
                {
                    playlist.Songs.Add(song);
                }
                else
                {
                    playlist.Karaokes.Add(karaoke);
                }
                PlaylistsDataGrid.Rows.Clear();
                foreach (Playlist pl in currentUser.MyPlaylist)
                {
                    PlaylistsDataGrid.Rows.Add(pl.Image, pl.PlaylistName, pl.Songs.Count() + pl.Videos.Count()+pl.Karaokes.Count());
                }
            }
        }
        private void delete_from_playlist(object sender, ToolStripItemClickedEventArgs e)
        {
            Playlist playlist = null;
            playlist = currentUser.MyPlaylist.Where(u => u.PlaylistName == e.ClickedItem.ToString()).FirstOrDefault();
            if (playlist != null)
            {
                string name = e.ClickedItem.Name.ToString();
                Song song = null;
                Video video = null;
                song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                Karaoke karaoke = null;
                karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                if (video is null)
                {
                    video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                }
                if (song is null && karaoke is null)
                {
                    playlist.Videos.Remove(video);
                }
                else if (karaoke is null)
                {
                    playlist.Songs.Remove(song);
                }
                else
                {
                    playlist.Karaokes.Remove(karaoke);
                }
                PlaylistsDataGrid.Rows.Clear();
                foreach (Playlist pl in currentUser.MyPlaylist)
                {
                    PlaylistsDataGrid.Rows.Add(pl.Image, pl.PlaylistName, pl.Songs.Count() + pl.Videos.Count());
                }
            }
        }

        private void mediamenu_Item_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add to queue":
                    string name = e.ClickedItem.Name.ToString();
                    Song song = null;
                    Video video = null;
                    Karaoke karaoke = null;
                    karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                    song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                    video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                    if (video is null)
                    {
                        video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                    }
                    if (song is null && karaoke is null)
                    {
                        mediaPlayer.Queue.Add(video);
                    }
                    else if (karaoke is null)
                    {
                        mediaPlayer.Queue.Add(song);
                    }
                    else
                    {
                        mediaPlayer.Queue.Add(karaoke);
                    }
                    break;
                case "View information on the platform about the mediafile":
                    name = e.ClickedItem.Name.ToString();
                    song = null;
                    video = null;
                    song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                    video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                    if (video is null)
                    {
                        video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                    }
                    karaoke = null;
                    karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                    if (song is null && karaoke is null)
                    {
                        if (video.Qualification.Count() == 0)
                        {
                            InfoBox infobox = new InfoBox(video.Likes, video.NumberOfReproductions);
                            infobox.ShowDialog();
                        }
                        else
                        {
                            InfoBox infobox = new InfoBox(video.Likes, video.NumberOfReproductions, video.Qualification.Average());
                            infobox.ShowDialog();
                        }
                    }
                    else if (karaoke is null)
                    {
                        if (song.Qualification.Count() == 0)
                        {
                            InfoBox infobox = new InfoBox(song.Likes, song.NumberOfReproductions);
                            infobox.ShowDialog();
                        }
                        else
                        {
                            InfoBox infobox = new InfoBox(song.Likes, song.NumberOfReproductions, song.Qualification.Average());
                            infobox.ShowDialog();
                        }
                    }
                    else
                    {
                        if (karaoke.Qualification.Count() == 0)
                        {
                            InfoBox infobox = new InfoBox(karaoke.Likes, karaoke.NumberOfReproductions);
                            infobox.ShowDialog();
                        }
                        else
                        {
                            InfoBox infobox = new InfoBox(karaoke.Likes, karaoke.NumberOfReproductions, karaoke.Qualification.Average());
                            infobox.ShowDialog();
                        }
                    }
                    break;
                case "View metadata information about the mediafile":
                    name = e.ClickedItem.Name.ToString();
                    song = null;
                    video = null;
                    song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                    video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                    if (video is null)
                    {
                        video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                    }
                    karaoke = null;
                    karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                    if (song is null && karaoke is null)
                    {
                        string actors = string.Join(",", video.Actors.ToArray());
                        InfoBox infobox = new InfoBox(video.Genre, actors, video.Director, video.Studio, video.Year, video.Synopsis, video.AgeFilter);
                        infobox.ShowDialog();

                    }
                    else if (karaoke is null)
                    {
                        InfoBox infobox = new InfoBox(song.Genre, song.Artist, song.Year, song.Album, song.ExpliciT);
                        infobox.ShowDialog();
                    }
                    else
                    {
                        InfoBox infobox = new InfoBox(karaoke.Genre, karaoke.Artist, karaoke.Year, karaoke.Album, karaoke.ExpliciT);
                        infobox.ShowDialog();
                    }
                    break;
                case "View intrinsic information about the mediafile":
                    name = e.ClickedItem.Name.ToString();
                    song = null;
                    video = null;
                    song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                    video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                    if (video is null)
                    {
                        video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                    }
                    karaoke = null;
                    karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                    if (song is null && karaoke is null)
                    {
                        string output = string.Format("{0}:{1:00}", (int)video.Length.TotalMinutes, video.Length.Seconds);
                        InfoBox infobox = new InfoBox(output, $"{ Player.Width }x{ Player.Height}", video.FileSize);
                        infobox.ShowDialog();

                    }
                    else if (karaoke is null)
                    {
                        string output = string.Format("{0}:{1:00}", (int)song.Length.TotalMinutes, song.Length.Seconds);
                        InfoBox infobox = new InfoBox(output, $"{ Player.Width }x{ Player.Height}", song.Bytes.Count());
                        infobox.ShowDialog();

                    }
                    else
                    {
                        string output = string.Format("{0}:{1:00}", (int)karaoke.Length.TotalMinutes, karaoke.Length.Seconds);
                        InfoBox infobox = new InfoBox(output, $"{ Player.Width }x{ Player.Height}", karaoke.Bytes.Count());
                        infobox.ShowDialog();

                    }
                    break;
                case "Download Song":
                    if (currentUser.MembershipType == "pago")
                    {
                        name = e.ClickedItem.Name.ToString();
                        song = null;
                        video = null;
                        song = mediaPlayer.Songs.Where(u => u.Name == name).FirstOrDefault();
                        video = mediaPlayer.Videos.Where(u => u.Name == name).FirstOrDefault();
                        if (video is null)
                        {
                            video = mediaPlayer.VideoChapters.Where(u => u.Name == name).FirstOrDefault();
                        }
                        karaoke = null;
                        karaoke = mediaPlayer.Karaokes.Where(u => u.Name == name).FirstOrDefault();
                        if (song is null)
                        {
                            InfoBox infobox = new InfoBox(1);
                            infobox.ShowDialog();
                        }
                        else
                        {
                            if (karaoke is null)
                            {
                                try
                                {
                                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), Path.GetFileName(song.Name) + ".mp4");
                                    System.IO.File.WriteAllBytes(path, song.Bytes);
                                    InfoBox infobox = new InfoBox(2);
                                    infobox.ShowDialog();
                                }
                                catch (DirectoryNotFoundException)
                                {
                                    InfoBox infobox = new InfoBox(3);
                                    infobox.ShowDialog();
                                }
                            }
                            else
                            {
                                try
                                {
                                    string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), Path.GetFileName(song.Name) + ".mp4");
                                    System.IO.File.WriteAllBytes(path, karaoke.Bytes);
                                    InfoBox infobox = new InfoBox(2);
                                    infobox.ShowDialog();
                                }
                                catch (DirectoryNotFoundException)
                                {
                                    InfoBox infobox = new InfoBox(3);
                                    infobox.ShowDialog();
                                }
                            }
                        }
                    }
                    else
                    {
                        InfoBox infobox = new InfoBox(4);
                        infobox.ShowDialog();
                    }

                    break;

                default:
                    break;
            }
        }

        //Home (se ve lo que se está reproduciendo)
        private void HomeButtom_Click(object sender, EventArgs e)
        {
            if (ExtraPanel.Controls.GetChildIndex(Player) == 0)
            {
                Player.SendToBack();

            }
            else
            {
                Player.BringToFront();

            }
        }

        //Playlist y Smartlist
        private void AddPlaylistButton_Click(object sender, EventArgs e)
        {
            if (NewPlaylistTable.Visible == false)
            {
                NewPlaylistTable.Dock = System.Windows.Forms.DockStyle.Fill;
                NewPlaylistTable.Visible = true;
                NewPlaylistTable.BringToFront();
                NameUseLabel.Visible = false;
                ChoosePublic.Visible = false;
                ChooseanameLabel.Visible = false;
                PublicButton.Tag = "off";
                PrivateButton.Tag = "off";
                PublicButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                PrivateButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                PlayListImagePathTextBox.Text = "";
                PlaylistNameTextBox.Text = "";
                PlaylistNameTextBox.BackColor = System.Drawing.Color.Silver;
                PlaylistpictureBox.Image = null;
                PlaylistpictureBox.BackgroundImage = Spotflix.Properties.Resources.chooseImage;
            }
            else
            {
                NewPlaylistTable.Visible = false;
            }
            PlaylistsDataGrid.Rows.Clear();
            foreach (Playlist pl in currentUser.MyPlaylist)
            {
                PlaylistsDataGrid.Rows.Add(pl.Image, pl.PlaylistName, pl.Songs.Count() + pl.Videos.Count());
            }
        }

        private void LoadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "jpg files(*.jpg)|*.jpg|png files(*.png)|*.png";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                PlaylistpictureBox.Image = new Bitmap(path);
                PlaylistpictureBox.BackgroundImage = null;
                PlayListImagePathTextBox.Text = path;
                PlaylistpictureBox.Visible = true;
            }
        }

        private void PrivateButton_Click(object sender, EventArgs e)
        {
            if (PrivateButton.Tag.ToString() == "off")
            {
                PrivateButton.Tag = "on";
                PublicButton.Tag = "off";
                PrivateButton.BackColor = System.Drawing.Color.Gray;
                PublicButton.BackColor = System.Drawing.Color.FromArgb(45,45,45) ;
            }
            else
            {
                PrivateButton.Tag = "off";
                PrivateButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            }
        }

        private void PublicButton_Click(object sender, EventArgs e)
        {
            if (PublicButton.Tag.ToString() == "off")
            {
                PublicButton.Tag = "on";
                PrivateButton.Tag = "off";
                PublicButton.BackColor = System.Drawing.Color.Gray;
                PrivateButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            }
            else
            {
                PublicButton.Tag = "off";
                PublicButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            string name = PlaylistNameTextBox.Text;
            Image playlistImage = PlaylistpictureBox.Image;
            NameUseLabel.Visible = false;
            ChoosePublic.Text = "You have to choose Public or Private";
            ChoosePublic.Visible = false;
            ChooseanameLabel.Visible = false;
            string publicornot;
            if (string.IsNullOrEmpty(name))
            {
                ChooseanameLabel.Visible = true;
            }
            if (PrivateButton.Tag.ToString() == "off" && PublicButton.Tag.ToString() == "off")
            {
                ChoosePublic.Visible = true;
            }
            if (PublicButton.Tag.ToString() == "on" && currentUser.PrivPubl == "privado")
            {
                ChoosePublic.Text = "Private user. You cannot upload public playlists.";
                ChoosePublic.Visible = true;
                PublicButton.Tag = "off";
                PublicButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
            }
            else if (!string.IsNullOrEmpty(name) && (PrivateButton.Tag.ToString() != "off" || PublicButton.Tag.ToString() != "off"))
            {
                if (PrivateButton.Tag.ToString() == "on")
                {
                    publicornot = "private";
                    SaveUser();
                }
                else
                {
                    publicornot = "public";
                    SaveUser();
                }
                Playlist playlist = null;
                playlist = currentUser.NewPlaylist(publicornot, name, playlistImage);
                if (SearchSmartTable2.Visible == true)
                {
                    playlist.Filter = SeerachSmartTextBox.Text;
                    Searcher.Smartlist(playlist);
                }
                if (playlist is null)
                {
                    NameUseLabel.Visible = true;
                }
                else
                {
                    NewPlaylistTable.Visible = false;
                    mediaPlayer.Playlists.Add(playlist);
                }
                SeerachSmartTextBox.Text = "Search";
                SaveUser();
                SavePlaylist();
                PlaylistsDataGrid.Rows.Clear();
                foreach (Playlist pl in currentUser.MyPlaylist)
                {
                    PlaylistsDataGrid.Rows.Add(pl.Image, pl.PlaylistName, pl.Songs.Count() + pl.Videos.Count());
                }
            }
        }

        private void AddSmartListButton_Click(object sender, EventArgs e)
        {
            if (NewPlaylistTable.Visible == true && SearchSmartTable2.Visible == false)
            {
                SearchSmartTable2.Visible = true;
            }
            else if (SearchSmartTable2.Visible == true)
            {
                SearchSmartTable2.Visible = false;
            }
        }

        //Calificación
        private void Star1Button_Click(object sender, EventArgs e)
        {
            Star1Button.Tag = "si";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star2Button.Tag = "no";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star3Button.Tag = "no";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star4Button.Tag = "no";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star5Button.Tag = "no";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            foreach (Song s in mediaPlayer.Songs)
            {
                if (currentlyPlaying.Code == s.Code && currentlyPlaying.Letter == s.Letter)
                {
                    s.Qualification.Add(1);
                    SaveSong();
                }
            }
            foreach (Video v in mediaPlayer.VideoChapters)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Video v in mediaPlayer.Videos)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Karaoke k in mediaPlayer.Karaokes)
            {
                if (currentlyPlaying.Code == k.Code && currentlyPlaying.Letter == k.Letter)
                {
                    k.Qualification.Add(1);
                    SaveKaroke();
                }
            }
            foreach (Serie s in mediaPlayer.Series)
            {
                if (currentlyPlaying.Code == s.Code)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                        {
                            v.Qualification.Add(1);
                            SaveSeries();
                        }
                    }
                }
            }
        }

        private void Star2Button_Click(object sender, EventArgs e)
        {
            Star1Button.Tag = "si";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star2Button.Tag = "si";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star3Button.Tag = "no";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star4Button.Tag = "no";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star5Button.Tag = "no";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            foreach (Song s in mediaPlayer.Songs)
            {
                if (currentlyPlaying.Code == s.Code && currentlyPlaying.Letter == s.Letter)
                {
                    s.Qualification.Add(2);
                    SaveSong();
                }
            }
            foreach (Video v in mediaPlayer.Videos)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(2);
                    SaveVideo();
                }
            }
            foreach (Video v in mediaPlayer.VideoChapters)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Karaoke k in mediaPlayer.Karaokes)
            {
                if (currentlyPlaying.Code == k.Code && currentlyPlaying.Letter == k.Letter)
                {
                    k.Qualification.Add(2);
                    SaveKaroke();
                }
            }
            foreach (Serie s in mediaPlayer.Series)
            {
                if (currentlyPlaying.Code == s.Code)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                        {
                            v.Qualification.Add(2);
                            SaveSeries();
                        }
                    }
                }
            }

        }

        private void Star3Button_Click(object sender, EventArgs e)
        {
            Star1Button.Tag = "si";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star2Button.Tag = "si";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star3Button.Tag = "si";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star4Button.Tag = "no";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            Star5Button.Tag = "no";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            foreach (Song s in mediaPlayer.Songs)
            {
                if (currentlyPlaying.Code == s.Code && currentlyPlaying.Letter == s.Letter)
                {
                    s.Qualification.Add(3);
                    SaveSong();
                }
            }
            foreach (Video v in mediaPlayer.Videos)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(3);
                    SaveVideo();
                }
            }
            foreach (Video v in mediaPlayer.VideoChapters)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Karaoke k in mediaPlayer.Karaokes)
            {
                if (currentlyPlaying.Code == k.Code && currentlyPlaying.Letter == k.Letter)
                {
                    k.Qualification.Add(3);
                    SaveKaroke();
                }
            }
            foreach (Serie s in mediaPlayer.Series)
            {
                if (currentlyPlaying.Code == s.Code)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                        {
                            v.Qualification.Add(3);
                            SaveSeries();
                        }
                    }
                }
            }

        }

        private void Star4Button_Click(object sender, EventArgs e)
        {
            Star1Button.Tag = "si";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star2Button.Tag = "si";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star3Button.Tag = "si";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star4Button.Tag = "si";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star5Button.Tag = "no";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella;
            foreach (Song s in mediaPlayer.Songs)
            {
                if (currentlyPlaying.Code == s.Code && currentlyPlaying.Letter == s.Letter)
                {
                    s.Qualification.Add(4);
                    SaveSong();
                }
            }
            foreach (Video v in mediaPlayer.Videos)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(4);
                    SaveVideo();
                }
            }
            foreach (Video v in mediaPlayer.VideoChapters)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Karaoke k in mediaPlayer.Karaokes)
            {
                if (currentlyPlaying.Code == k.Code && currentlyPlaying.Letter == k.Letter)
                {
                    k.Qualification.Add(4);
                    SaveKaroke();
                }
            }
            foreach (Serie s in mediaPlayer.Series)
            {
                if (currentlyPlaying.Code == s.Code)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                        {
                            v.Qualification.Add(4);
                            SaveSeries();
                        }
                    }
                }
            }

        }

        private void Star5Button_Click(object sender, EventArgs e)
        {
            Star1Button.Tag = "si";
            Star1Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star2Button.Tag = "si";
            Star2Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star3Button.Tag = "si";
            Star3Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star4Button.Tag = "si";
            Star4Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            Star5Button.Tag = "si";
            Star5Button.BackgroundImage = Spotflix.Properties.Resources.estrella_amarilla;
            foreach (Song s in mediaPlayer.Songs)
            {
                if (currentlyPlaying.Code == s.Code && currentlyPlaying.Letter == s.Letter)
                {
                    s.Qualification.Add(5);
                    SaveSong();
                }
            }
            foreach (Video v in mediaPlayer.Videos)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(5);
                    SaveVideo();
                }
            }
            foreach (Video v in mediaPlayer.VideoChapters)
            {
                if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                {
                    v.Qualification.Add(1);
                    SaveVideo();
                }
            }
            foreach (Karaoke k in mediaPlayer.Karaokes)
            {
                if (currentlyPlaying.Code == k.Code && currentlyPlaying.Letter == k.Letter)
                {
                    k.Qualification.Add(5);
                    SaveKaroke();
                }
            }
            foreach (Serie s in mediaPlayer.Series)
            {
                if (currentlyPlaying.Code == s.Code)
                {
                    foreach (Video v in s.Episodes)
                    {
                        if (currentlyPlaying.Code == v.Code && currentlyPlaying.Letter == v.Letter)
                        {
                            v.Qualification.Add(5);
                            SaveSeries();
                        }
                    }
                }
            }
        }

        //Karaoke
        private void KaraokeTimer_Tick(object sender, EventArgs e)
        {
            lyric += 2;
            if ((lyric + 1) % 3 == 0)
            {
                try
                {
                    Karaoke aux = mediaPlayer.Karaokes.Where(u => u.Bytes.SequenceEqual(currentlyPlaying.Bytes)).FirstOrDefault();
                    KaraokeTimer.Enabled = true;
                    if (Convert.ToDouble(aux.Lyrics[lyric]) == 0)
                    {
                        KaraokeTimer.Interval = 1000;
                    }
                    else
                    {
                        double a = Convert.ToDouble(aux.Lyrics[lyric]);
                        a += Convert.ToDouble(aux.Lyrics[lyric + 2]) / 3;
                        KaraokeTimer.Interval = Convert.ToInt32(Math.Truncate(a));
                    }
                    karaokeText.Text = "";
                    karaokeText.Text += aux.Lyrics[lyric + 1];
                    karaokeText.Text += aux.Lyrics[lyric + 3];
                    karaokeText.Text += aux.Lyrics[lyric + 5];
                    karaokeText.BringToFront();
                }
                catch (IndexOutOfRangeException)
                {
                }
            }
        }

        private void karaokeText_TextChanged(object sender, EventArgs e)
        {

        }


        //MINEDUC
        private void ClassroomInitialButtom_Click(object sender, EventArgs e)
        {
            InitialPanel.Visible = false;
            ClassRoomLogInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ClassRoomLogInPanel.Visible = true;
            UsernameCTextBox.Text = "";
            UsernameCTextBox.BackColor = System.Drawing.Color.Silver;
            PasswordCTextBox.Text = "";
            PasswordCTextBox.BackColor = System.Drawing.Color.Silver;
            WrongCredentialsCLabel.Visible = false;
        }

        //Iniciar sesión
        private void LogInClassRommButtom_Click(object sender, EventArgs e)
        {
            ClassRoomLogInPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ClassRoomLogInPanel.Visible = true;
            UsernameCTextBox.Text = "";
            UsernameCTextBox.BackColor = System.Drawing.Color.Silver;
            PasswordCTextBox.Text = "";
            PasswordCTextBox.BackColor = System.Drawing.Color.Silver;
            WrongCredentialsCLabel.Visible = false;
        }

        private void LogInLogInCButtom_Click(object sender, EventArgs e)
        {
            string name = UsernameCTextBox.Text;
            string password = PasswordCTextBox.Text;
            Student student = Gate.LogAsStudent(name, password);
            Teacher teacher = Gate.LogAsTeacher(name, password);


            if (student == null && teacher != null)
            {
                ClassRoomLogInPanel.Visible = false;
                this.currentTeacher = teacher;
                TeacherPanel.Visible = true;
                SuccessDownloadEmailLabel.Visible = false;
                TeacherPanel.Dock= System.Windows.Forms.DockStyle.Fill;

            }
            else if (student != null && teacher == null)
            {
                this.currentStudent = student;
                foreach (Lesson l in mediaPlayer.Lessons)
                {
                    if (l.Course == currentStudent.Curse)
                    {
                        currentStudent.Yourlesson.Add(l);
                    }
                    foreach(string subject in currentStudent.Subjects)
                    {
                        if (subject == l.Subject && currentStudent.Yourlesson.Any(u => u.Equals(l) == false))
                        {
                            currentStudent.Yourlesson.Add(l);
                        }
                    }
                }
                SaveStudent();
                ClassRoomLogInPanel.Visible = false;
                StudentPanel.Visible = true;
                Teachernamestudentlabel.Text = "";
                VideoCurseLabel.Text = "";
                VideoSubjectLabel.Text = "";
                TeachetPictureBox.Image = null;
                TeachetPictureBox.Image = null;
                UploadHomeWorkPanel.Visible = false;
                TeacherProfilTable.Visible = false;
                SuccessDownloadLael.Visible = false;
                StudentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                LikeLessonButton.Tag = "no";
                LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                FollowTeacherButton.Tag = "no";
                FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow;
                AdLessonQuequeButton.Tag = "no";
                AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                TeacherProfile.Tag = "no";
                TeacherProfile.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                StudentFavoritesButton.Tag = "no";
                StudentFavoritesButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                YourLessonsButton.Tag = "no";
                YourLessonsButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                UploadHomeworkButton2.Tag = "no";
                UploadHomeworkButton2.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                UploadHomeWorkButton.Tag = "no";
                UploadHomeWorkButton.BackColor = System.Drawing.Color.FromArgb(45, 45, 45);
                initializeStudentPlayer();
            }
            else
            {
                WrongCredentialsCLabel.Visible = true;
            }
        }

        //STUDENT
        //Reproductor
        //Inicializar
        public void initializeStudentPlayer()
        {
            CurrentLesson.Stop();
            NextLessonTimer.Stop();
            index = 0;
            SPlayer.BringToFront();
            Teachernamestudentlabel.Text = "";
            VideoCurseLabel.Text = "";
            VideoSubjectLabel.Text = "";
            TeachetPictureBox.Image = null;
            DataStudentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            StudentSearchPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            CentralStudentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            SPlayer.Dock= System.Windows.Forms.DockStyle.Fill;
            SPlayer.Visible = true;
            CentralStudentPanel.BringToFront();
            if (currentStudent.Lastlesson != null)
            {
                mediaPlayer.Queuestudent.Add(currentStudent.Lastlesson);
                CustomPlayStudent();
                SPlayer.Ctlcontrols.stop();
                SPlayer.Ctlcontrols.currentPosition += currentStudent.CurrentSec;
                if (progressBar2.Value + currentStudent.CurrentSec > progressBar2.Maximum)
                {
                    progressBar2.Value = 0;
                }
                else
                {
                    progressBar2.Value += currentStudent.CurrentSec;
                }
                PlayLesson.BackgroundImage = Spotflix.Properties.Resources.play_130;
                PlayLesson.Tag = "play";
            }
            
        }

        //CustomPlay
        private void CustomPlayStudent()
        {
            if (index < mediaPlayer.Queuestudent.Count())
            {
                NextLessonTimer.Start();
                CurrentLesson.Start();
                SPlayer.Ctlcontrols.stop();

                Lesson lesson = mediaPlayer.Queuestudent[index];
                currentlyLessonPlaying = lesson;
                currentlyPlaying = lesson.Lessons;
                mediaPlayer.Play(lesson.Lessons);
                SPlayer.URL = currentlyPlaying.Name+".mp4";

                LikeLessonButton.Tag = "no";
                LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                FollowTeacherButton.Tag = "no";
                FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow;
                AdLessonQuequeButton.Tag = "no";
                AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                SuccessDownloadLael.Visible = false;

                if (currentStudent.LikedLesson.Any(u => u.Bytes.SequenceEqual(currentlyLessonPlaying.Bytes)))
                {
                    LikeLessonButton.Tag = "si";
                    LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_rojo;
                }
                else
                {
                    LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                    LikeLessonButton.Tag = "no";
                }

                if (currentStudent.FollowTeachers.Any(u => u.Gmail.SequenceEqual(currentlyLessonPlaying.Teacher.Gmail)))
                {
                    FollowTeacherButton.Tag = "si";
                    FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow_verde;
                }
                else
                {
                    FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow;
                    FollowTeacherButton.Tag = "no";
                }

                double secs = Math.Truncate(currentlyPlaying.Length.TotalSeconds);
                progressBar2.Value = 0;
                progressBar2.Maximum = Convert.ToInt32(secs);
                NextLessonTimer.Interval = progressBar2.Maximum * 1000;
                SPlayer.URL = currentlyPlaying.Name+".mp4";
                SPlayer.Ctlcontrols.play();
                CurrentLesson.Enabled = true;
                foreach (User u in Gate.Users)
                {
                    if (lesson.Teacher.Gmail == u.Gmail)
                    {
                        TeachetPictureBox.Image = u.Profileimage; ;
                    }
                }
                Teachernamestudentlabel.Text = lesson.Teacher.Name;
                VideoCurseLabel.Text = lesson.Course;
                VideoSubjectLabel.Text = lesson.Subject;
                GC.Collect();
            }
        }

        //Play
        private void PlayLesson_Click(object sender, EventArgs e)
        {
            if (PlayLesson.Tag.ToString() == "pause")
            {
                SPlayer.Ctlcontrols.pause();
                PlayLesson.BackgroundImage = Spotflix.Properties.Resources.play_130;
                PlayLesson.Tag = "play";
            }
            else
            {
                SPlayer.Ctlcontrols.play();

                PlayLesson.BackgroundImage = Properties.Resources.pausa140;
                PlayLesson.Tag = "pause";
            }
        }

        //Mostrar paneles laterales
        private void ShowDataButton_Click(object sender, EventArgs e)
        {
            Button currentpanel = (Button)sender;
            DataStudentGrid.Visible = true;
            DataStudentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            StudentDataGrid.Rows.Clear();
            switch (currentpanel.Text)
            {
                case "                         QuequeButtomS":
                    if (AdLessonQuequeButton.Tag.ToString() == "no")
                    {
                        StudentDataGrid.Rows.Clear();
                        AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_azul;
                        AdLessonQuequeButton.Tag = "si";
                        StudentFavoritesButton.Tag = "no";
                        StudentFavoritesButton.BackColor =System.Drawing.Color.FromArgb(21, 21, 21);
                        YourLessonsButton.Tag = "no";
                        YourLessonsButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);

                        StudentDataGrid.Columns[0].HeaderText = "Queue";
                        StudentDataGrid.Columns[1].HeaderText = "Name";
                        StudentDataGrid.Columns[2].HeaderText = "Teacher";
                        StudentDataGrid.Columns[3].HeaderText = "Subject";
                        StudentDataGrid.Columns[4].HeaderText = "Course";
                        foreach (Lesson lesson in mediaPlayer.Queuestudent)
                        {
                            string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                            StudentDataGrid.Rows.Add(output, lesson.Name, lesson.Teacher.Name+" "+lesson.Teacher.Lastname, lesson.Subject, lesson.Course);

                        }
                        DataStudentGrid.Visible = true;
                        StudentDataGrid.Visible = true;
                        DataStudentGrid.BringToFront();
                        break;
                    }
                    else
                    {
                        DataStudentGrid.Visible = false;
                        AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        AdLessonQuequeButton.Tag = "no";
                        break;
                    }

                case "Favorites":
                    if (StudentFavoritesButton.Tag.ToString() == "no")
                    {
                        StudentDataGrid.Rows.Clear();
                        AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        AdLessonQuequeButton.Tag = "no";
                        StudentFavoritesButton.Tag = "si";
                        StudentFavoritesButton.BackColor = System.Drawing.Color.Silver;
                        YourLessonsButton.Tag = "no";
                        YourLessonsButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        StudentDataGrid.Columns[0].HeaderText = "Liked lesson";
                        StudentDataGrid.Columns[1].HeaderText = "Name";
                        StudentDataGrid.Columns[2].HeaderText = "Teacher";
                        StudentDataGrid.Columns[3].HeaderText = "Course";
                        StudentDataGrid.Columns[4].HeaderText = "Subject";
                        foreach (Lesson lesson in currentStudent.LikedLesson)
                        {
                            string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                            StudentDataGrid.Rows.Add(output, lesson.Name, lesson.Teacher.Name+" "+lesson.Teacher.Lastname, lesson.Course, lesson.Subject);
                        }
                        DataStudentGrid.Visible = true;
                        StudentDataGrid.Visible = true;
                        DataStudentGrid.BringToFront();
                        break;
                    }
                    else
                    {
                        StudentFavoritesButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        StudentFavoritesButton.Tag = "no";
                        DataStudentGrid.Visible = false;
                        break;
                    }

                case "Your Lessons":
                    if (YourLessonsButton.Tag.ToString() == "no")
                    {
                        StudentDataGrid.Rows.Clear();
                        AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
                        AdLessonQuequeButton.Tag = "no";
                        StudentFavoritesButton.Tag = "no";
                        StudentFavoritesButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        YourLessonsButton.Tag = "si";
                        YourLessonsButton.BackColor = System.Drawing.Color.Silver;
                        StudentDataGrid.Columns[0].HeaderText = "Lessons for you";
                        StudentDataGrid.Columns[1].HeaderText = "Name";
                        StudentDataGrid.Columns[2].HeaderText = "Teacher";
                        StudentDataGrid.Columns[3].HeaderText = "Course";
                        StudentDataGrid.Columns[4].HeaderText = "Subject";
                        HashSet<Lesson> les = new HashSet<Lesson>();
                        foreach (Lesson lesson in mediaPlayer.Lessons)
                        {
                            if (lesson.Course.ToLower()==currentStudent.Curse.ToLower()&&currentStudent.Subjects.Contains(lesson.Subject))
                            { 
                                les.Add(lesson);
                            }
                        }
                        foreach (Teacher teacher in currentStudent.FollowTeachers)
                        {
                            foreach (Lesson lesson in teacher.Lessons)
                            {
                                if (!les.Any(u=>u.Name==lesson.Name))
                                {
                                    les.Add(lesson);
                                }
                                
                            }
                        }
                        foreach (Lesson lesson in les)
                        {
                            string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                            string aux = lesson.Teacher.Name + " " + lesson.Teacher.Lastname;
                            StudentDataGrid.Rows.Add(output, lesson.Name, aux, lesson.Course, lesson.Subject);
                        }
                        DataStudentGrid.Visible = true;
                        StudentDataGrid.Visible = true;
                        DataStudentGrid.BringToFront();
                        break;
                    }
                    else
                    {
                        YourLessonsButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                        YourLessonsButton.Tag = "no";
                        StudentDataGrid.Visible = false;
                        break;
                    }

                default:
                    break;
            }
            if (SPlayer.Tag.ToString() == currentpanel.Text)
            {

                StudentPanel.Visible = true;
                StudentPanel.BringToFront();
            }
            else
            {
                if (CentralStudentPanel.Controls.GetChildIndex(DataStudentGrid) != 0)
                {
                    DataStudentGrid.BringToFront();
                }

            }
            SPlayer.Tag = currentpanel.Text;
            foreach (DataGridViewRow row in StudentDataGrid.Rows)
            {
                row.MinimumHeight = 50;
            }
        }

        private void lessonmenu_Item_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.ToString())
            {
                case "Add to queue":
                    string name = e.ClickedItem.Name.ToString();
                    Lesson lesson = null;
                    lesson = mediaPlayer.Lessons.Where(u => u.Name == name).FirstOrDefault();
                    if (lesson != null)
                    {
                        mediaPlayer.Queuestudent.Add(lesson);
                    }
                    break;
                default:
                    break;
            }

        }
        
        private void teacher_item_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string name = e.ClickedItem.Name.ToString();
            Teacher teacher = Gate.Teachers.Where(u => u.Name == name).FirstOrDefault();
            switch (e.ClickedItem.ToString())
            {
                case "Follow teacher":
                    currentStudent.FollowTeachers.Add(teacher);
                    break;
                case "Unfollow teacher":
                    currentStudent.FollowTeachers.Remove(teacher);
                    break;
                default:
                    break;
            }
            SaveUser();
            SaveTeacher();
        }
        
        //Clase anterior
        private void PreviusLesson_Click(object sender, EventArgs e)
        {
            if (index >= 1)
            {
                index--;
                CustomPlayStudent();
            }
            else
            {
                CustomPlayStudent();
            }
        }

        //Clase siguiente
        private void NextLesson_Click(object sender, EventArgs e)
        {
            if (mediaPlayer.Queuestudent.Count() > index + 1)
            {
                index++;
                CustomPlayStudent();
            }
            else
            {
                CustomPlayStudent();
            }
        }

        //Volumen
        private void VolumeLesson_Scroll(object sender, EventArgs e)
        {
            SPlayer.settings.volume = VolumeLesson.Value;
        }

        //Cambiar estado
        private void SPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (currentlyLessonPlaying is null)
            {

            }
            else
            {
                if (e.newState == 8)
                {
                    currentlyLessonPlaying.Lessons.NumberOfReproductions++;
                    progressBar2.Value = 0;
                }
                if (e.newState == 3)
                {
                    PlayLesson.BackgroundImage = Properties.Resources.pausa140;
                    PlayLesson.Tag = "pause";
                    CurrentLesson.Start();
                    NextLessonTimer.Start();
                }
                if (e.newState == 2)
                {
                    PlayLesson.BackgroundImage = Spotflix.Properties.Resources.play_130;
                    PlayLesson.Tag = "play";
                    CurrentLesson.Stop();
                    NextLessonTimer.Stop();
                }
                if (e.newState == 1)
                {
                    PlayLesson.BackgroundImage = Spotflix.Properties.Resources.play_130;
                    PlayLesson.Tag = "play";
                    CurrentLesson.Stop();
                    NextLessonTimer.Stop();
                }
                if (e.newState == 6)
                {
                    progressBar2.Value = 0;
                }
            }
        }

        //Ponerle me gusta a la clase
        private void LikeLessonButton_Click(object sender, EventArgs e)
        {
            if (currentlyLessonPlaying != null)
            {
                if (LikeLessonButton.Tag.ToString() == "si")
                {
                    LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
                    LikeLessonButton.Tag = "no";
                }
                else
                {
                    LikeLessonButton.Tag = "si";
                    LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_rojo;
                }
               
                if (currentStudent.LikedLesson.Any(u => u.Bytes.SequenceEqual(currentlyLessonPlaying.Bytes)))
                {
                    currentStudent.LikedLesson.Remove(currentlyLessonPlaying);
                    currentlyLessonPlaying.Lessons.Likes--;
                }
                else
                {
                    currentStudent.LikedLesson.Add(currentlyLessonPlaying);
                    currentlyLessonPlaying.Lessons.Likes++;
                }
            }
            else
            {

                LikeLessonButton.Tag = "no";
                LikeLessonButton.BackgroundImage = Spotflix.Properties.Resources.corazon_blanco;
            }

            SaveStudent();
            SaveLesson();
            SaveVideoT();
        }

        //Seguir al profesor
        private void FollowTeacherButton_Click(object sender, EventArgs e)
        {
            if (currentlyLessonPlaying != null)
            {
                if (FollowTeacherButton.Tag.ToString() == "si")
                {
                    FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow;
                    FollowTeacherButton.Tag = "no";
                }
                else
                {
                    FollowTeacherButton.Tag = "si";
                    FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow_verde;
                }

                if (currentStudent.FollowTeachers.Any(u => u.Gmail.SequenceEqual(currentlyLessonPlaying.Teacher.Gmail)))
                {
                    currentStudent.FollowTeachers.Remove(currentlyLessonPlaying.Teacher);
                }
                else
                {
                    currentStudent.FollowTeachers.Add(currentlyLessonPlaying.Teacher);
                }
            }
            else
            {

                FollowTeacherButton.Tag = "no";
                FollowTeacherButton.BackgroundImage = Spotflix.Properties.Resources.follow;
            }

            SaveStudent();
            SaveLesson();
            SaveVideoT();
            SaveStudent();
        }

        //Realizar búsquedas
        private void ExploreStudentButton_Click(object sender, EventArgs e)
        {
            AdLessonQuequeButton.BackgroundImage = Spotflix.Properties.Resources.queque_blanco;
            AdLessonQuequeButton.Tag = "no";
            StudentFavoritesButton.Tag = "no";
            StudentFavoritesButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            YourLessonsButton.Tag = "no";
            YourLessonsButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            DataStudentGrid.Visible = false;
            StudentSearchPanel.Visible = true;
            if (CentralStudentPanel.Controls.GetChildIndex(StudentSearchPanel) == 0)
            {
                SPlayer.BringToFront();
            }
            else
            {
                LessonSearcherData.Rows.Clear();
                TeacherSearcherData.Rows.Clear();
                StudentSearcherData.Rows.Clear();
                StudentSearchPanel.BringToFront();
                Searchstextbox.Text = "Search";
                StudentSearcherTableResult.Visible = false;

            }
        }

        private void Searchstextbox_TextChanged(object sender, EventArgs e)
        {
            if (Searchstextbox.Text != "")
            {
                LessonSearcherData.Visible = true;
                TeacherSearcherData.Visible = true;
                StudentSearcherData.Visible = true;

                LessonSearcherData.Rows.Clear();
                TeacherSearcherData.Rows.Clear();
                StudentSearcherData.Rows.Clear();

                StudentSearcher.Brain(Searchstextbox.Text);
                foreach (Lesson lesson in mediaPlayer.Foundlessons)
                {
                    string aux=  lesson.Teacher.Name + " " + lesson.Teacher.Lastname;
                    string output = string.Format("{0}:{1:00}", (int)lesson.Lessons.Length.TotalMinutes, lesson.Lessons.Length.Seconds);
                    LessonSearcherData.Rows.Add(output, lesson.Name, aux, lesson.Course, lesson.Subject);
                }
                foreach (DataGridViewRow row in LessonSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }

                LessonSearcherData.Columns[0].HeaderText = "Found lesson";
                LessonSearcherData.Columns[1].HeaderText = "Name";
                LessonSearcherData.Columns[2].HeaderText = "Teacher";
                LessonSearcherData.Columns[3].HeaderText = "Course";
                LessonSearcherData.Columns[4].HeaderText = "Subject";

                foreach (Teacher teacher in Gate.Foundteachers)
                {
                    string aux = String.Join(",", teacher.Subjects);
                    string aux2 = String.Join(",", teacher.Course);
                    string nickname="";
                    Image n = null;
                    foreach (User u in Gate.Users)
                    {
                        if (teacher.Gmail == u.Gmail)
                        {
                            nickname = u.Nickname;
                            n = u.Profileimage;
                        }


                    }
                    TeacherSearcherData.Rows.Add(n, teacher.Name, teacher.Gmail, aux, aux2);
                }
                foreach (DataGridViewRow row in TeacherSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                TeacherSearcherData.Columns[0].HeaderText = "Found teacher";
                TeacherSearcherData.Columns[1].HeaderText = "Name";
                TeacherSearcherData.Columns[2].HeaderText = "Gmail";
                TeacherSearcherData.Columns[3].HeaderText = "Subjects";
                TeacherSearcherData.Columns[4].HeaderText = "Course";

                foreach (Student student in Gate.Foundstudents)
                {
                    string aux = String.Join(",", student.Subjects);
                    string aux2 = student.Name + " " + student.Lastname;
                    Image n = null;
                    foreach (User u in Gate.Users)
                    {
                        if (student.Gmail == u.Gmail) n = u.Profileimage;

                    }
                    StudentSearcherData.Rows.Add(n, aux2, student.Gmail, aux, student.Curse);
                }
                foreach (DataGridViewRow row in StudentSearcherData.Rows)
                {
                    row.MinimumHeight = 50;
                }
                StudentSearcherData.Columns[0].HeaderText = "Found student";
                StudentSearcherData.Columns[1].HeaderText = "Name";
                StudentSearcherData.Columns[2].HeaderText = "Gmail";
                StudentSearcherData.Columns[3].HeaderText = "Subjects";
                StudentSearcherData.Columns[4].HeaderText = "Course";

                if (mediaPlayer.Foundlessons.Count() == 0)
                {
                    LessonSearcherData.Visible = false;
                }
                else
                {
                    LessonSearcherData.Visible = true;
                }
                if (Gate.Foundstudents.Count() == 0)
                {
                    StudentSearcherData.Visible = false;
                }
                else
                {
                    StudentSearcherData.Visible = true;
                }
                if (Gate.Foundteachers.Count() == 0)
                {
                    TeacherSearcherData.Visible = false;
                }
                else
                {
                    TeacherSearcherData.Visible = true;
                }

                StudentSearchPanel.Visible = true;
                StudentSearcherImagePanel.Visible = true;
                StudentSearcherTableResult.Visible = true;
            }
            if (Searchstextbox.Text == "Search")
            {
                StudentSearcherTableResult.Visible = true;
                Searchstextbox.Text = "";
            }
        }

        private void Searchstextbox_Click(object sender, EventArgs e)
        {
            if (Searchstextbox.Text == "Search")
            {
                StudentSearcherTableResult.Visible = true;
                Searchstextbox.Text = "";
            }
        }
        //Botón home
        private void HomeStudentButton_Click(object sender, EventArgs e)
        {
            if (CentralStudentPanel.Controls.GetChildIndex(SPlayer) == 0)
            {
                SPlayer.SendToBack();
            }
            else
            {
                SPlayer.BringToFront();
            }
        }

        //Descagar tarea
        private void DownloadHomeworkButton2_Click(object sender, EventArgs e)
        {
            SuccessDownloadLael.Visible = false;
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            if (DownloadHomeworkButton2.Tag.ToString() == "no")
            {
                DownloadHomeworkButton2.Tag = "si";
                DownloadHomeworkButton2.BackColor = System.Drawing.Color.Silver;
                if (currentlyLessonPlaying == null)
                {
                    SuccessDownloadLael.Visible = true;
                    SuccessDownloadLael.Text = "You have to reproduce a lesson!";
                }
                else if (currentlyLessonPlaying != null)
                {
                    foreach (string subject in currentStudent.Subjects)
                    {
                        if (subject == currentlyLessonPlaying.Subject)
                        {
                            count2++;
                        }
                    }
                    if (currentStudent.Curse == currentlyLessonPlaying.Course)
                    {
                        count1++;
                    }
                }
                if (count1 != 0 && count2 != 0)
                {
                    try
                    {
                        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(currentlyLessonPlaying.Name) + ".pdf");
                        System.IO.File.WriteAllBytes(path, currentlyLessonPlaying.Bytes);
                        count += 1;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        SuccessDownloadLael.Text = "Error! Couldn´t find suitable Path.";
                        SuccessDownloadLael.Visible = true;
                        count += 1;
                    }
                    if (count != 0)
                    {
                        SuccessDownloadLael.Text = "The homework has been downloaded";
                        SuccessDownloadLael.Visible = true;
                    }
                    else
                    {
                        SuccessDownloadLael.Text = "This lesson has no homework";
                        SuccessDownloadLael.Visible = true;
                    }
                }
                else if (currentlyLessonPlaying != null && (count1 == 0 || count2 == 0))
                {
                    SuccessDownloadLael.Text = "You cannot download this homework because they are not for you!";
                    SuccessDownloadLael.Visible = true;
                }
            }
            else
            {
                DownloadHomeworkButton2.Tag = "no";
                DownloadHomeworkButton2.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                SuccessDownloadLael.Visible = false;
            }
        }

        //Subir tarea
        private void UploadHomeworkButton2_Click(object sender, EventArgs e)
        {
            if (UploadHomeworkButton2.Tag.ToString() == "si")
            {
                UploadHomeWorkPanel.Visible = false;
                UploadHomeworkButton2.Tag = "no";
                UploadHomeworkButton2.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                SuccessDownloadLael.Visible = false;
            }
            else
            {
                WrongEmailLabel.Visible = false;
                PDFSuccessStudentLabel.Visible = false;
                PdfSecretLabel.Text = "";
                ErrorHomeworkLabel.Visible = false;
                UploadHomeWorkPanel.Visible = true;
                UploadHomeWorkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                EditorsStudentPanel.BringToFront();
                UploadHomeWorkPanel.BringToFront();
                TeacherprofileButton.Tag = "no";
                TeacherprofileButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                UploadHomeworkButton2.Tag = "si";
                UploadHomeworkButton2.BackColor = System.Drawing.Color.Silver;
                TeacherEmailtextBox.BackColor = System.Drawing.Color.Silver;
                TeacherEmailtextBox.Text = "";
            }
        }

        private void UploadHomeWorkButton_Click(object sender, EventArgs e)
        {
            WrongEmailLabel.Visible = false;
            string mail = TeacherEmailtextBox.Text;
            bool suceesemail;
            bool succespdf;
            if (mail == "")
            {
                WrongEmailLabel.Text = "You have to put a email!";
                WrongEmailLabel.Visible = true;
                suceesemail = false;
            }
            else
            {
                int count = 0;
                foreach (Teacher t in Gate.Teachers)
                {
                    if (t.Gmail == mail)
                    {
                        count++;
                    }
                }
                if (count == 0)
                {
                    WrongEmailLabel.Text = "This email doesn´t exist!";
                    WrongEmailLabel.Visible = true;

                    suceesemail = false;
                }
                else
                {
                    suceesemail = true;
                }
            }
            if (PdfSecretLabel.Text == "")
            {
                PDFSuccessStudentLabel.Text = "You have to upload a PDF";
                WrongEmailLabel.Visible = true;
                succespdf = false;
            }
            else
            {
                PDFSuccessStudentLabel.Visible = false;
                succespdf = true;

            }
            if (succespdf && suceesemail)
            {
                byte[] bytes = File.ReadAllBytes(PdfSecretLabel.Text);
                HomeWork homeWork = new HomeWork(currentStudent, mail, bytes);
                mediaPlayer.Homeworks.Add(homeWork);
                SaveHomework();
                UploadHomeWorkPanel.Visible = false;
                UploadHomeworkButton2.Tag = "no";
            }
        }

        private void UploadPdfButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "pdf files(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                PdfSecretLabel.Text = path;
                PDFSuccessStudentLabel.Visible = true;
            }
        }

        //Perfil del profesor
        private void TeacherprofileButton_Click(object sender, EventArgs e)
        {
            SuccessDownloadLael.Visible = false;

            if (TeacherprofileButton.Tag.ToString() == "si")
            {
                TeacherProfilTable.Visible = false;
                TeacherprofileButton.Tag = "no";
                SuccessDownloadLael.Visible = false;
                TeacherprofileButton.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
            }
            else if (currentlyLessonPlaying != null)
            {
                TeacherProfilTable.Visible = true;
                TeacherProfilTable.Dock = System.Windows.Forms.DockStyle.Fill;
                UploadHomeworkButton2.Tag = "no";
                UploadHomeworkButton2.BackColor = System.Drawing.Color.FromArgb(21, 21, 21);
                UploadHomeWorkPanel.Visible = false;
                UploadHomeWorkPanel.Dock = System.Windows.Forms.DockStyle.Fill;
                TeacherprofileButton.Tag = "si";
                TeacherprofileButton.BackColor = System.Drawing.Color.Silver;
                TeacherNameTextBox.Text = currentlyLessonPlaying.Teacher.Name;
                TeacherMailTextBox.Text = currentlyLessonPlaying.Teacher.Gmail;
                string aux1 = String.Join(",", currentlyLessonPlaying.Teacher.Course);
                string aux2 = String.Join(",", currentlyLessonPlaying.Teacher.Subjects);
                foreach (User u in Gate.Users)
                {
                    if (u.Gmail == currentlyLessonPlaying.Teacher.Gmail)
                    {
                        TeacherSPictureBox.BackgroundImage = u.Profileimage;
                    }
                }
                TSCurseTextBox.Text = aux1;
                TSSubjectsTextBox.Text = aux2;
            }
            else
            {
                SuccessDownloadLael.Visible = true;
                SuccessDownloadLael.Text = "You have to reproduce a lesson for view your teacher profil!";
                TeacherprofileButton.Tag = "si";
                TeacherprofileButton.BackColor = System.Drawing.Color.Silver;
            }
        }

        //PROFESOR
        //Añadir clases
        private void AddLessonButton_Click(object sender, EventArgs e)
        {
            AddLessonPanel.Visible = true;
            AddLessonPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            LessonNameTextBox.BackColor= System.Drawing.Color.Silver;
            LessonNameTextBox.Text = "";
            CourseTextBox.BackColor= System.Drawing.Color.Silver;
            CourseTextBox.Text = "PK,K, 1-8, I, II, III or IV";
            SubjectLessonTextBox.BackColor = System.Drawing.Color.Silver;
            SubjectLessonTextBox.Text = "";
            EmptyFieldLLabel.Visible = false;
            LeessonAlreadyLabel.Visible = false;
            InvalidFormatLessonLabel.Visible = false;
            VideoLessonLabel.Visible = false;
            PDFLessonLabel.Visible = false;
        }

        private void PDFLButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "pdf files(*.pdf)|*.pdf";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                PdfInvisibleTextBox.Text = path;
                PDFLessonLabel.Visible = true;
            }
        }

        private void VideoLButton_Click(object sender, EventArgs e)
        {
            string subject = SubjectLessonTextBox.Text;
            string course = CourseTextBox.Text;
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "mp4 files(*.mp4)|*.mp4";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = dialog.FileName;
                VideoInvisibleTextBox.Text = path;
                TagLib.File file = TagLib.File.Create(path);
                VideoLessonLabel.Visible = true;
            }
        }

        private void UploadLButton_Click(object sender, EventArgs e)
        {           
            string pathpdf = PdfInvisibleTextBox.Text;
            string pathvideo = VideoInvisibleTextBox.Text;
            string lessonname = LessonNameTextBox.Text;
            string course = CourseTextBox.Text;
            string subject = SubjectLessonTextBox.Text;
            EmptyFieldLLabel.Visible = false;
            LeessonAlreadyLabel.Visible = false;
            LeessonAlreadyLabel.Text = "Lesson alredy on database";
            InvalidFormatLessonLabel.Visible = false;
            InvalidFormatLessonLabel.Text = "Invalid format";
            bool existe = false;
            foreach (Lesson l in currentTeacher.Lessons)
            {
                if (l.Course == course && l.HomeWork == pathpdf && l.Name == lessonname  && l.Subject == subject && l.Teacher == currentTeacher)
                {
                    existe = true;
                }
            }

            if (String.IsNullOrEmpty(pathpdf.ToString()) || String.IsNullOrEmpty(pathvideo) || String.IsNullOrEmpty(lessonname) || course == "PK,K, 1 - 8, I, II, III or IV" || String.IsNullOrEmpty(subject))
            {
                EmptyFieldLLabel.Visible = true;
            }
            else if (course != "PK" && course != "K" && course != "1" && course != "2" && course != "3" && course != "4" && course != "5" && course != "6" && course != "7" && course != "8" && course != "I" && course != "II" && course != "III" && course != "IV")
            {
                InvalidFormatLessonLabel.Visible = true;
            }
            else if(existe)
            {
                LeessonAlreadyLabel.Visible = true;
            }
            else
            {
                int counters = 0;
                int counterc = 0;
                foreach(string s in currentTeacher.Subjects)
                {
                    if (subject == s)
                    {
                        counters += 1;
                    }
                }
                foreach (string c in currentTeacher.Course)
                {
                    if (course == c)
                    {
                        counterc += 1;
                    }
                }

                if(counters!=0 && counterc != 0)
                {
                    Video vid = Teacher.ImportVideoT(pathvideo, subject, course, mediaPlayer); //TeacherFIX
                    byte[] bytes = File.ReadAllBytes(pathpdf);
                    Lesson lesson= Teacher.ImportLesson(lessonname, subject, course, 0, vid, currentTeacher, bytes, pathpdf); 
                    mediaPlayer.Lessons.Add(lesson);
                    Save();
                    AddLessonPanel.Visible = false;
                }
                else 
                {
                    if (counters == 0)
                    {
                        InvalidFormatLessonLabel.Text = "Subject does not belong to your subjects";
                        InvalidFormatLessonLabel.Visible = true;
                    }
                    if (counterc == 0)
                    {
                        LeessonAlreadyLabel.Text = "Course does not belong to your courses";
                        LeessonAlreadyLabel.Visible = true;
                    }
                }
            }
        }

        //Vaciar buzón 
        private void DownloadHomeWorkButton_Click(object sender, EventArgs e)
        {
            SuccessDownloadEmailLabel.Visible = false;
            int count = 0;
            List<HomeWork> h2 = new List<HomeWork>();
            foreach (HomeWork h in mediaPlayer.Homeworks)
            {
                h2.Add(h);
            }
            foreach (HomeWork h in h2)
            {
                if (h.Teachermail == currentTeacher.Gmail)
                {
                    try
                    {
                        string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.GetFileName(h.Student.Gmail) + ".pdf");
                        System.IO.File.WriteAllBytes(path, h.Bytes);
                        count += 1;
                    }
                    catch (DirectoryNotFoundException)
                    {
                        SuccessDownloadEmailLabel.Text = "Error! Couldn´t find suitable Path.";
                        SuccessDownloadEmailLabel.Visible = true;
                        count += 1;
                    }
                    if (mediaPlayer.Homeworks.Contains(h)) mediaPlayer.Homeworks.Remove(h);
                    
                }    
            }
            if (count != 0)
            {
                SuccessDownloadEmailLabel.Text = "Your mailbox has been downloaded";
                SuccessDownloadEmailLabel.Visible = true;
            }
            else
            {
                SuccessDownloadEmailLabel.Text = "Your mailbox is empty";
                SuccessDownloadEmailLabel.Visible = true;
            }
            SaveHomework();
        }

        private void LessonTimer_Tick(object sender, EventArgs e)
        {
            progressBar2.Increment(1);
        }

        private void NextLessonTimer_Tick(object sender, EventArgs e)
        {
            index++;
            CustomPlayStudent();
        }
    }
}