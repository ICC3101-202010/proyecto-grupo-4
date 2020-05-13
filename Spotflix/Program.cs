using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using System.Runtime.InteropServices;
using System.Windows.Forms.VisualStyles;
using Microsoft.WindowsAPICodePack.Shell;
using System.Diagnostics.Eventing.Reader;

namespace Spotflix
{
    public class Program
    {
        //Metodos Serializar:
                    //Setup
            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();
            List<Teacher> teachers = new List<Teacher>();
            List<Song> Songs = new List<Song>();
            List<Video> Videos = new List<Video>();
            List<Lesson> Lessons = new List<Lesson>();
            List<Series> Series = new List<Series>();
            List<Playlist> Playlists = new List<Playlist>();
            List<Karaoke> Karaokes = new List<Karaoke>();
            List<Album> Albums = new List<Album>();
        static private void SaveUser(List<User> users)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoUsuarios.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, users);
            stream.Close();
        }
        static private List<User> LoadUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoUsuarios.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<User> users = (List<User>)formatter.Deserialize(stream);
            stream.Close();
            return users;
        }
        static private void SaveAdmin(List<Admin> managers)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAdministradores.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, managers);
            stream.Close();
        }
        static private List<Admin> LoadAdmin()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAdministradores.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Admin> managers = (List<Admin>)formatter.Deserialize(stream);
            stream.Close();
            return managers;
        }
        static private void SaveTeacher(List<Teacher> teachers)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivosProfesores.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, teachers);
            stream.Close();
        }
        static private List<Teacher> LoadTeacher()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivosProfesores.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Teacher> teachers = (List<Teacher>)formatter.Deserialize(stream);
            stream.Close();
            return teachers;
        }
        static private void SaveSong(List<Song> Songs)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoCanciones.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Songs);
            stream.Close();
        }
        static private List<Song> LoadSong()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoCanciones.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Song> Songs = (List<Song>)formatter.Deserialize(stream);
            stream.Close();
            return Songs;
        }
        static private void SaveVideo(List<Video> Videos)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoVideos.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Videos);
            stream.Close();
        }
        static private List<Video> LoadVideo()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoVideos.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Video> Videos = (List<Video>)formatter.Deserialize(stream);
            stream.Close();
            return Videos;
        }
        static private void SaveLesson(List<Lesson> Lessons)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoClases.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Lessons);
            stream.Close();
        }
        static private List<Lesson> LoadLesson()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoClases.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Lesson> Lessons = (List<Lesson>)formatter.Deserialize(stream);
            stream.Close();
            return Lessons;
        }
        static private void SavePlaylist(List<Playlist> Playlists)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoPlaylist.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Playlists);
            stream.Close();
        }
        static private List<Playlist> LoadPlaylist()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoPlaylist.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Playlist> PLaylists = (List<Playlist>)formatter.Deserialize(stream);
            stream.Close();
            return PLaylists;
        }
        static private void SaveSerie(List<Series> Series)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoSeries.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Series);
            stream.Close();
        }
        static private List<Series> LoadSerie()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoSeries.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Series> Series = (List<Series>)formatter.Deserialize(stream);
            stream.Close();
            return Series;
        }
        static private void SaveKaraoke(List<Karaoke> Karaokes)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoKaraoke.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Karaokes);
            stream.Close();
        }
        static private List<Karaoke> LoadKaraoke()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoKaraoke.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Karaoke> Karaokes = (List<Karaoke>)formatter.Deserialize(stream);
            stream.Close();
            return Karaokes;
        }
        static private void SaveAlbum(List<Album> Albums)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAlbum.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, Albums);
            stream.Close();
        }
        static private List<Album> LoadAlbum()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAlbum.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Album> Albums = (List<Album>)formatter.Deserialize(stream);
            stream.Close();
            return Albums;
        }

        //MAIN
        static void Main(string[] args)
        {
            //constructores
            MediaPlayer mediaPlayer = new MediaPlayer();
            Admin admin = new Admin();
            User user = new User();
            Teacher teacher = new Teacher();
            Playlist play = new Playlist();
            Album album = new Album();
  


            //Setup
            List<User> users = new List<User>();
            List<Admin> admins = new List<Admin>();
            List<Teacher> teachers = new List<Teacher>();
            List<Song> Songs = new List<Song>();
            List<Video> Videos = new List<Video>();
            List<Lesson> Lessons = new List<Lesson>();
            List<Series> Series = new List<Series>();
            List<Playlist> Playlists = new List<Playlist>();
            List<Karaoke> Karaokes = new List<Karaoke>();
            List<Album> Albums = new List<Album>();
            //CARGAR TODO

            
            
            string archivouser = @"\ArchivoUsuarios.bin";
            string pathu = Directory.GetCurrentDirectory() + archivouser;
            if (File.Exists(pathu))
            {
                users = LoadUser();
                Gate.Users = users;
            }
            else { }
            string archivoadmin = @"\ArchivoAdministradores.bin";
            string patha = Directory.GetCurrentDirectory() + archivoadmin;
            if (File.Exists(patha))
            {
                admins = LoadAdmin();
                Gate.Managers = admins;
            }
            else { }
            string archivoteacher = @"\ArchivosProfesores.bin";
            string patht = Directory.GetCurrentDirectory() + archivoteacher;
            if (File.Exists(patht))
            {
                
                teachers = LoadTeacher();
                Gate.Teachers = teachers;
            }
            else { }
            string archivosong = @"\ArchivoCanciones.bin";
            string paths = Directory.GetCurrentDirectory() + archivosong;
            if (File.Exists(paths))
            {
                Songs = LoadSong();
                mediaPlayer.Songs = Songs;
            }
            else { }

            string archivovideo = @"\ArchivoVideos.bin";
            string pathv = Directory.GetCurrentDirectory() + archivovideo;
            if (File.Exists(pathv))
            {
                Videos = LoadVideo();
                mediaPlayer.Videos = Videos;
            }
            else { }


            string archivolesson = @"\ArchivoClases.bin";
            string pathl = Directory.GetCurrentDirectory() + archivolesson;
            if (File.Exists(pathl))
            {
                Lessons = LoadLesson();
                mediaPlayer.Lessons = Lessons;
            }
            else { }


            string archivoplay = @"\ArchivoPlaylist.bin";
            string pathp = Directory.GetCurrentDirectory() + archivoplay;
            if (File.Exists(pathp))
            {
                Playlists = LoadPlaylist();
                mediaPlayer.Playlists = Playlists;
            }
            else { }


            string archivoserie = @"\ArchivoSeries.bin";
            string pathse = Directory.GetCurrentDirectory() + archivoserie;
            if (File.Exists(pathse))
            {
                Series = LoadSerie();
                mediaPlayer.Series = Series;
            }
            else { }


            string archivokarak = @"\ArchivoKaraoke.bin";
            string pathk = Directory.GetCurrentDirectory() + archivokarak;
            if (File.Exists(pathk))
            {
                Karaokes = LoadKaraoke();
                mediaPlayer.Karaokes = Karaokes;
            }
            else { }

            string archivoalbum = @"\ArchivoAlbum.bin";
            string pathal = Directory.GetCurrentDirectory() + archivoalbum;
            if (File.Exists(pathal))
            {
                Albums = LoadAlbum();
                mediaPlayer.Albums = Albums;
            }
            else { }
            

            mediaPlayer.AddVideoSerie += admin.OnAddVideoSerie;
            mediaPlayer.DeleteVideoSerie += admin.OnDeleteVideoSerie;
            mediaPlayer.AddSong += user.OnAddSong;
            mediaPlayer.DeleteSong += user.OnDeleteSong;
            mediaPlayer.AddVideo += user.OnAddVideo;
            mediaPlayer.DeleteVideo += user.OnDeleteVideo;
            mediaPlayer.OrderBy += play.OnOrderBy;
            mediaPlayer.OrderByA += album.OnOrderByA;

            
            string switcher = "0";
            string stopper = "3";

            while (switcher != stopper)
            {
                Console.WriteLine("Si desea:\n\t(1)Registrarse\n\t(2)Iniciar Sesion\n\t(3)Salir del programa\n");
                switcher = Console.ReadLine();
                Console.Clear();
                switch (switcher)
                {
                    case "1": //Registrarse
                        string register = "0";
                        Console.WriteLine("Si desea:\n\t(1)Registrarse como usuario\n\t(2)Registrarse como administrador\n\t(3)Registrarse como profesor\n\t(4)Cualquier caracter para volver al menu");
                        register = Console.ReadLine();
                        Console.Clear();
                        switch (register)
                        {
                            case "1": //usuario
                                Console.WriteLine("Ingrese su nombre: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Ingrese su apellido: ");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("Ingrese su edad: ");
                                int age = -1;
                                while (age == -1)
                                {
                                    try
                                    {
                                        age = int.Parse(Console.ReadLine());
                                        if (age < 1)
                                        {
                                            Console.WriteLine("Ingrese una edad valida");
                                            age = -1;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Formato invalido\nIngrese un numero como edad");
                                    }
                                }
                                Console.WriteLine("Ingrese su pais de origen:");
                                string country = Console.ReadLine();
                                Console.WriteLine("Ingrese su ciudad de origen:");
                                string city = Console.ReadLine();
                                Console.WriteLine("Ingrese su calle:");
                                string street = Console.ReadLine();
                                Console.WriteLine("Ingrese su código postal:");

                                int PostalCode = -1;
                                while (PostalCode == -1)
                                {
                                    try
                                    {
                                        PostalCode = int.Parse(Console.ReadLine());
                                        if (PostalCode < 1)
                                        {
                                            Console.WriteLine("Ingrese un codigo valido");
                                            PostalCode = -1;
                                        }
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Formato invalido\nIngrese un numero como codigo postal");
                                    }
                                }


                                bool nickcheck = false;
                                bool mailcheck = false;
                                bool passcheck = false;
                                string nickName = "";
                                string gmail = "";
                                string passWord = "";
                                while (!mailcheck)
                                {
                                    Console.WriteLine("Ingrese su Gmail:");
                                    gmail = Console.ReadLine();
                                    mailcheck = Gate.CheckGmail(gmail);
                                    mailcheck = !String.IsNullOrEmpty(gmail);
                                }
                                while (!nickcheck)
                                {
                                    Console.WriteLine("Ingrese su nombre de usuario:");
                                    nickName = Console.ReadLine();
                                    nickcheck = Gate.checkUsername(nickName);
                                    nickcheck = !String.IsNullOrEmpty(nickName);
                                }
                                while (!passcheck)
                                {
                                    Console.WriteLine("Ingrese su contraseña:");
                                    passWord = Console.ReadLine();
                                    passcheck = !String.IsNullOrEmpty(passWord);
                                    if (!passcheck)
                                    {
                                        Console.WriteLine("Ingrese una contraseña no vacia");
                                    }
                                }

                                if (nickcheck && mailcheck)
                                {
                                    int num = Gate.Users.Count() - 1;
                                    User u1 = new User(num, gmail, nickName, passWord, "no pago", name, lastName, age, country, city, street, PostalCode);
                                    Gate.SingUser(u1);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                    num++;
                                }
                                
                                break;
                            case "2": //administrador
                                Console.WriteLine("Ingrese el codigo para registrarse como admin");
                                string key = Console.ReadLine();
                                if (key == "123")
                                {
                                    bool nickchecka = false;
                                    bool mailchecka = false;
                                    bool passcheck1 = false;
                                    string nickNamea = "";
                                    string gmaila = "";
                                    string passWorda = "";
                                    while (!mailchecka)
                                    {
                                        Console.WriteLine("Ingrese su Gmail");
                                        gmaila = Console.ReadLine();
                                        mailchecka = Gate.CheckGmailA(gmaila);
                                    }
                                    while (!nickchecka)
                                    {
                                        Console.WriteLine("Ingrese su nombre de usuario");
                                        nickNamea = Console.ReadLine();
                                        nickchecka = Gate.checkUsernameA(nickNamea);
                                    }
                                    while (!passcheck1)
                                    {
                                        Console.WriteLine("Ingrese su contraseña");
                                        passWorda = Console.ReadLine();
                                        passcheck1 = !String.IsNullOrEmpty(passWorda);
                                        if (!passcheck1)
                                        {
                                            Console.WriteLine("Ingrese una contraseña no vacia");
                                        }
                                    }

                                    if (nickchecka && mailchecka)
                                    {
                                        Admin a1 = new Admin(nickNamea, gmaila, key, passWorda);
                                        Gate.SingAdmin(a1);
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Codigo invalido, volviendo al menu...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                break;
                            case "3": //profesor
                                Console.WriteLine("Ingrese el codigo para registrarse como profesor:");
                                string key_T = Console.ReadLine();
                                if (key_T == "321")
                                {
                                    bool nickcheckp = false;
                                    bool mailcheckp = false;
                                    bool passcheck2 = false;
                                    string nickNamep = "";
                                    string gmailp = "";
                                    string namet="";
                                    string lastname = "";
                                    string passWordp = "";
                                    while (!mailcheckp)
                                    {
                                        Console.WriteLine("Ingrese su Gmail:");
                                        gmailp = Console.ReadLine();
                                        mailcheckp = Gate.CheckGmailP(gmailp);
                                    }
                                    while (!nickcheckp)
                                    {
                                        Console.WriteLine("Ingrese su nombre de usuario:");
                                        nickNamep = Console.ReadLine();
                                        nickcheckp = Gate.checkUsernameP(nickNamep);
                                    }
                                    Console.WriteLine("Ingrese su nombre:");
                                    namet = Console.ReadLine();
                                    Console.WriteLine("Ingrese su apellido:");
                                    lastname = Console.ReadLine();

                                    while (!passcheck2)
                                    {
                                        Console.WriteLine("Ingrese su contraseña");
                                        passWordp = Console.ReadLine();
                                        passcheck2 = !String.IsNullOrEmpty(passWordp);
                                        if (!passcheck2)
                                        {
                                            Console.WriteLine("Ingrese una contraseña no vacia");
                                        }
                                    }
                                    if (nickcheckp && mailcheckp)
                                    {
                                        Console.WriteLine("Ingrese el curso que desea tener(PK,K,1-8,I,II,II,IV):");
                                        string curso = Console.ReadLine();
                                        Teacher t1 = new Teacher(nickNamep, namet, lastname, gmailp, key_T, curso, passWordp);
                                        Gate.SingTeacher(t1);
                                        Thread.Sleep(1000);
                                        Console.Clear();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Codgio invalido, volviendo al menu...");
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                break;
                            default:
                                Console.WriteLine("Volviendo al menu...");
                                Thread.Sleep(1000);
                                Console.Clear();
                                break;
                        }
                        break;
                    case "2": //iniciar sesion
                        string switcher2 = "0";
                        string stopper2 = "4";
                        while (switcher2 != stopper2)
                        {
                            Console.WriteLine("Iniciar sesion:\n\t(1)Para usuario\n\t(2)Para administrador\n\t(3)Para profesor\n\t(4)Atras\n");
                            switcher2 = Console.ReadLine();
                            Console.Clear();
                            switch (switcher2)
                            {
                                case "1": //usuario

                                    Console.WriteLine("Ingrese su nombre de usuario o Gmail");
                                    string n = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña");
                                    string p = Console.ReadLine();
                                    Console.Clear();
                                    user = Gate.LogAsUser(n, p);
                                    if (user!=null)
                                    {
                                        string switcherusr = "0";
                                        string stopperusr = "6";
                                        while (switcherusr != stopperusr)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Pestaña buscar y reproducir\n\t(2)Pestaña Informacion\n\t(3)Pestaña comunidad\n\t(4)Pestaña Playlist\n\t(5)Pestaña Follows\n\t(6)Atras\n");
                                            switcherusr = Console.ReadLine();
                                            switch (switcherusr)
                                            {
                                                case "1"://Ok
                                                    bool searshstopper = false;
                                                    while (!searshstopper)
                                                    {
                                                        Console.WriteLine("Si desea:\n\t(0)Buscador generico\n\t(1)Buscar videos\n\t(2)Buscar canciones\n\t(3)Buscar por Series\n\t(4)Buscar por playlist\n\t(5)Buscar por Album\n\t(6)Buscar por karaokes\n\t(7)Buscar por clases(Lessons)\n\t(8)Buscar y reproducir añadiendo a la cola\n\t(9)Para volver al menu\n");
                                                        string searchandplay = Console.ReadLine();
                                                        Console.Clear();
                                                        switch (searchandplay)
                                                        {
                                                            case "0":
                                                                List<int> choice = mediaPlayer.GenericSearch();
                                                                if (choice.Contains(-1))
                                                                {
                                                                    break;
                                                                }
                                                                if (choice[0] == 1)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Videos[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 2)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Songs[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 3)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Lessons[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 4)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Karaokes[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 5)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Playlists[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 6)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Albums[choice[1]], user);
                                                                }
                                                                else if (choice[0] == 7)
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Series[choice[1]], user);
                                                                }
                                                                break;
                                                            case "1":
                                                                int variable1 = mediaPlayer.Search("1");
                                                                if (variable1 == -1)
                                                                {
                                                                    break;
                                                                }
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Videos[variable1], user);
                                                                }
                                                                break;
                                                            case "2":
                                                                int variable2 = mediaPlayer.Search("2");
                                                                if (variable2 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Songs[variable2],user);
                                                                }
                                                                break;
                                                            case "3":
                                                                int variable3 = mediaPlayer.Search("3");
                                                                if (variable3 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Series[variable3], user);
                                                                }
                                                                break;
                                                            case "4":
                                                                int variable4 = mediaPlayer.Search("4");
                                                                if (variable4 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Playlists[variable4], user);
                                                                }
                                                                break;
                                                            case "5":
                                                                int variable5 = mediaPlayer.Search("5");
                                                                if (variable5 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Albums[variable5], user);
                                                                }
                                                                break;
                                                            case "6":
                                                                int variable6 = mediaPlayer.Search("6");
                                                                if (variable6 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Karaokes[variable6], user);
                                                                }
                                                                break;
                                                            case "7":
                                                                int variable7 = mediaPlayer.Search("7");
                                                                if (variable7 == -1) break;
                                                                else
                                                                {
                                                                    mediaPlayer.Play(mediaPlayer.Lessons[variable7], user);
                                                                }
                                                                break;
                                                            case "8":
                                                                mediaPlayer.Play(user);
                                                                break;
                                                            case "9":
                                                                searshstopper = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Opcion invalida intente nuevamente...");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                        }

                                                    }
                                                    break;
                                                case "2"://Ok
                                                    bool infostopper = false;
                                                    while (!infostopper)
                                                    {
                                                        Console.WriteLine("Si desea:\n\t(1)Conocer informacion de una cancion\n\t(2)Conocer informacion de un video\n\t(3)Volver al menu principal\n");
                                                        string infofilter = Console.ReadLine();
                                                        Console.Clear();
                                                        switch (infofilter)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Si desea:\n\t(1)Ver calificacion de una cancion\n\t(2)Ver informacion de una cancion\n\t(3)Ver informacion intrinseca de una cancion\n\t(4)Ver informacion de la plataforma de una cancion\n\t()Cualquier otro caracter para volver al Menu anterior\n");
                                                                string songfilter = Console.ReadLine();
                                                                int var = 0;
                                                                switch (songfilter)
                                                                {

                                                                    case "1":
                                                                        var = mediaPlayer.Search("2");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetQualification(mediaPlayer.Songs[mediaPlayer.Search("2")]);
                                                                        }
                                                                        break;
                                                                    case "2":
                                                                        var= mediaPlayer.Search("2");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetMetadata(mediaPlayer.Songs[mediaPlayer.Search("2")]);
                                                                        }
                                                                        break;
                                                                    case "3":
                                                                        var = mediaPlayer.Search("2");
                                                                        if (var==-1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetInstrinsicInformation(mediaPlayer.Songs[mediaPlayer.Search("2")]);
                                                                        }
                                                                        break;
                                                                    case "4":
                                                                        var = mediaPlayer.Search("2");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetPlataformInformation(mediaPlayer.Songs[mediaPlayer.Search("2")]);
                                                                        }
                                                                        break;
                                                                    default:
                                                                        Console.Clear();
                                                                        break;
                                                                }
                                                                break;
                                                            case"2":
                                                                Console.WriteLine("Si desea:\n\t(1)Ver calificacion de un video\n\t(2)Ver informacion de un video\n\t(3)Ver informacion intrinseca de un video\n\t(4)Ver informacion de la plataforma de un video\n\t()Cualquier otro caracter para volver al Menu anterior\n");
                                                                string videofilter = Console.ReadLine();
                                                                switch (videofilter)
                                                                {
                                                                    case "1":
                                                                        var = mediaPlayer.Search("1");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetQualification(mediaPlayer.Songs[mediaPlayer.Search("1")]);
                                                                        }
                                                                        break;
                                                                    case "2":
                                                                        var = mediaPlayer.Search("1");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetMetadata(mediaPlayer.Songs[mediaPlayer.Search("1")]);
                                                                        }
                                                                        break;
                                                                    case "3":
                                                                        var = mediaPlayer.Search("1");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetInstrinsicInformation(mediaPlayer.Songs[mediaPlayer.Search("1")]);
                                                                        }
                                                                        break;
                                                                    case "4":
                                                                        var = mediaPlayer.Search("1");
                                                                        if (var == -1)
                                                                        {
                                                                            Console.WriteLine("No se encontraron coincidencias");
                                                                        }
                                                                        else
                                                                        {
                                                                            mediaPlayer.GetPlataformInformation(mediaPlayer.Songs[mediaPlayer.Search("1")]);
                                                                        }
                                                                        break;
                                                                    default:
                                                                        Console.Clear();
                                                                        break;
                                                                }
                                                                break;
                                                            case "3":
                                                                infostopper = true;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Opcion invalida intente nuevamente...");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "3"://ok
                                                    bool comunitystopper = false;
                                                    while (!comunitystopper)
                                                    {
                                                        Console.WriteLine("Si desea:\n\t(1)Seguir a\n\t(2)Editar perfil\n\t(3)Calificar o descargar archivo multimedia\n\t(4)Volver al menu principal\n");
                                                        string comunityfilter = Console.ReadLine();
                                                        Console.Clear();
                                                        switch (comunityfilter)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Si desea:\n\t(1)Seguir a un Usuario\n\t(2)Seguir a un album\n\t(3)Seguir a una playlist\n\t(4)Seguir a un Artista\n\t(5)series\n\t(6)Seguir a un profesor\n\t()Cualquier otro caracter para volver al menu anterior\n");
                                                                string follow = Console.ReadLine();
                                                                switch (follow)
                                                                {
                                                                    case "1":
                                                                        mediaPlayer.Follow("Users", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    case "2":
                                                                        mediaPlayer.Follow("Albums", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    case "3":
                                                                        mediaPlayer.Follow("Playlists", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    case "4":
                                                                        mediaPlayer.Follow("Artists", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    case "5":
                                                                        mediaPlayer.Follow("Series", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    case "6":
                                                                        mediaPlayer.Follow("Teacher", Gate.Users, user, Gate.Teachers);
                                                                        break;
                                                                    default:
                                                                        Console.WriteLine("Volviendo al menu anterior...");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                        break;
                                                                }
                                                                break;
                                                            case "2":
                                                                Console.WriteLine("Si desea:\n\t(1)Hacerse premium\n\t(2)Dejar de ser premium\n\t(3)Cambiar contraseña\n\t(4)Editar perfil\n\t()Cualquier otro caracter para volver al menu anterior\n");
                                                                string profile = Console.ReadLine();
                                                                switch (profile)
                                                                {
                                                                    case "1":
                                                                        Gate.MemberShip();
                                                                        break;
                                                                    case "2":
                                                                        Gate.NoMemberShip();
                                                                        break;
                                                                    case "3":
                                                                        Gate.ChangePassword();
                                                                        break;
                                                                    case "4":
                                                                        Gate.ChangeProfile(user);
                                                                        break;
                                                                    default:
                                                                        Console.WriteLine("Volviendo al menu anterior...");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                        break;
                                                                }
                                                                break;
                                                            case "3":
                                                                Console.WriteLine("Si desea:\n\t(1)Calificar Cancion\n\t(2)Calificar Video\n\t(3)Descargar Cancion\n\t()Cualquier otro caracter para volver al menu anterior\n");
                                                                string qualify = Console.ReadLine();
                                                                switch (qualify)
                                                                {
                                                                    case "1":
                                                                        mediaPlayer.Qualify(mediaPlayer.Songs[mediaPlayer.Search("2")]);
                                                                        break;
                                                                    case "2":
                                                                        mediaPlayer.Qualify(mediaPlayer.Videos[mediaPlayer.Search("1")]);
                                                                        break;
                                                                    case "3":
                                                                        if (user.MembershipType == "pago")
                                                                        {
                                                                            mediaPlayer.Download(mediaPlayer.Songs[mediaPlayer.Search("2")], user);
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("El usuario es no pago, no puede descargar canciones\n");
                                                                        }
                                                                        break;
                                                                    default:
                                                                        Console.WriteLine("Volviendo al menu anterior...");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                        break;
                                                                }

                                                                break;
                                                            case "4":
                                                                comunitystopper = true ;
                                                                break;
                                                            default:
                                                                Console.WriteLine("Opcion invalida intente nuevamente...");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "4":
                                                    bool playliststopper = false;
                                                    while (!playliststopper)
                                                    {
                                                        Console.WriteLine("Si desea:\n\t(1)Crear o editar playlist de canciones\n\t(2)Crear o editar playlist de videos\n\t(3)Ordernar Playlist\n\t(4)Ordenar album\n\t(5)Crear playlist de canciones basada en tus preferencias\n\t(6)Crear playlist de videos basada en tus preferencias\n\t(7)Para volver al menu anterior\n");
                                                        string playlistfilter = Console.ReadLine();
                                                        switch (playlistfilter)
                                                        {
                                                            case "1":
                                                                Console.WriteLine("Si desea agregar una cancion presione a y si desea eliminarla presione e");
                                                                string what = Console.ReadLine();
                                                                if (what.ToLower() == "a")
                                                                {
                                                                    mediaPlayer.CreatePlaylistS(Gate.Users[user.UserID], "agregar");
                                                                }
                                                                else  if (what.ToLower() == "e")
                                                                {
                                                                    mediaPlayer.CreatePlaylistS(Gate.Users[user.UserID], "eliminar");
                                                                }
                                                                else { Console.WriteLine("Comando no encontrado"); }
                                                                break;
                                                            case "2":
                                                                Console.WriteLine("Si desea agregar un video presione a y si desea eliminarla presione e");
                                                                string whata = Console.ReadLine();
                                                                if (whata.ToLower() == "a")
                                                                {
                                                                    mediaPlayer.CreatePlaylistV(Gate.Users[user.UserID], "agregar");
                                                                }
                                                                else if (whata.ToLower() == "e")
                                                                {
                                                                    mediaPlayer.CreatePlaylistV(Gate.Users[user.UserID], "eleminar");
                                                                }
                                                                else { Console.WriteLine("Comando no encontrado"); }
                                                                break;
                                                            case "3":
                                                                Console.WriteLine("Si desea:\n\t(1)Para cancion\n\t(2)Para video\n\t()Cualquier caracter para volver al menu anterior");
                                                                string videoorsong = Console.ReadLine();
                                                                string mode;
                                                                string up;
                                                                bool up1;
                                                                string namep1;
                                                                string mode1;
                                                                string up2;
                                                                bool up3;
                                                                string namep2;
                                                                if (videoorsong == "1")
                                                                {
                                                                    Console.WriteLine("Si desea:\n\t(1)Ordernar alfabeticamente\n\t(2)ordenar por fecha\n\t(3)Por duracion\n\t(4)Por calificacion\n\t()Cualquier caracter para volver al menu anterior");
                                                                    mode = Console.ReadLine();
                                                                    Console.WriteLine("Si desea: \n\t(1)Ordenar mayor a menor\n\t()Cualquier otro caracter para menor a mayor\n");
                                                                    up = Console.ReadLine();
                                                                    if (up == "1")
                                                                    {
                                                                        up1 = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        up1 = false;
                                                                    }
                                                                    Console.WriteLine("Ingrese el nombre de la playlist a ordenar");
                                                                    namep1 = Console.ReadLine();
                                                                    if (mode == "1")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("song", namep1, up1, "Alphabet", user);
                                                                    }
                                                                    if (mode == "2")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("song", namep1, up1, "Date", user);
                                                                    }
                                                                    if (mode == "3")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("song", namep1, up1, "Lenght", user);
                                                                    }
                                                                    if (mode == "4")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("song", namep1, up1, "Qualification", user);
                                                                    }
                                                                }
                                                                else if (videoorsong == "2")
                                                                {
                                                                    Console.WriteLine("Si desea:\n\t(1)Ordernar alfabeticamente\n\t(2)ordenar por fecha\n\t(3)Por duracion\n\t(4)Por calificacion\n\t()Cualquier caracter para volver al menu anterior");
                                                                    mode1 = Console.ReadLine();
                                                                    Console.WriteLine("Si desea: \n\t(1)Ordenar mayor a menor\n\t()Cualquier otro caracter para menor a mayor\n");
                                                                    up2 = Console.ReadLine();
                                                                    if (up2 == "1")
                                                                    {
                                                                        up3 = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        up3 = false;
                                                                    }
                                                                    Console.WriteLine("Ingrese el nombre de la playlist a ordenar o crear");
                                                                    namep2 = Console.ReadLine();
                                                                    if (mode1 == "1")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("video", namep2, up3, "Alphabet", user);
                                                                    }
                                                                    if (mode1 == "2")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("video", namep2, up3, "Date", user);
                                                                    }
                                                                    if (mode1 == "3")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("video", namep2, up3, "Lenght", user);
                                                                    }
                                                                    if (mode1 == "4")
                                                                    {
                                                                        mediaPlayer.PlayListStarter("video", namep2, up3, "Qualification", user);
                                                                    }
                                                                }
                                                                break;
                                                            case "4":
                                                                Console.WriteLine("Si desea:\n\t(1)Ordernar alfabeticamente\n\t(2)ordenar por fecha\n\t(3)Por duracion\n\t(4)Por calificacion\n\t()Cualquier caracter para volver al menu anterior");
                                                                string modea = Console.ReadLine();
                                                                Console.WriteLine("Si desea: \n\t(1)Ordenar mayor a menor\n\t()Cualquier otro caracter para menor a mayor\n");
                                                                string upa = Console.ReadLine();
                                                                string namea;
                                                                bool upa1;
                                                                if (upa == "1")
                                                                {
                                                                    upa1 = true;
                                                                }
                                                                else
                                                                {
                                                                    upa1 = false;
                                                                }
                                                                Console.WriteLine("Ingrese el nombre del album a ordenar");
                                                                namea = Console.ReadLine();
                                                                if (modea == "1")
                                                                {
                                                                    mediaPlayer.AlbumStarter(namea, upa1, "Alphabet");
                                                                }
                                                                if (modea == "2")
                                                                {
                                                                    mediaPlayer.AlbumStarter(namea, upa1, "Date");
                                                                }
                                                                if (modea == "3")
                                                                {
                                                                    mediaPlayer.AlbumStarter(namea, upa1, "Lenght");
                                                                }
                                                                if (modea == "4")
                                                                {
                                                                    mediaPlayer.AlbumStarter(namea, upa1, "Qualification");
                                                                }
                                                                break;
                                                            case "5":
                                                                List<Song> temp = mediaPlayer.CreateRecommendedListS(user);
                                                                Console.WriteLine("Estas son las canciones de la playlist generada automaticamente:\n");
                                                                foreach (Song song in temp)
                                                                {
                                                                    Console.WriteLine(song.Name);
                                                                }
                                                                bool anwser = false;                                                                
                                                                while (!anwser)
                                                                {
                                                                    Console.WriteLine("Desea añadir la playlist a sus playlist? Y/N");
                                                                    string response = Console.ReadLine();
                                                                    if (response=="Y")
                                                                    {
                                                                        string name = "";
                                                                        bool nullcheck = false;
                                                                        while (!nullcheck)
                                                                        {
                                                                            Console.WriteLine("Ingrese el nombre de la playlist:\n");
                                                                            name = Console.ReadLine();
                                                                            nullcheck = !String.IsNullOrEmpty(name);
                                                                            if (!nullcheck)
                                                                            {
                                                                                Console.WriteLine("Ingreso un nombre vacio, Intente nuevamete...\n");
                                                                            }
                                                                        }
                                                                        Console.WriteLine("Si desea:\n\t(1) Sea publica\n\t(2) Sea privada\n*Advertencia inputs erroneos se tomaran como privada*\n");
                                                                        string publicornot = Console.ReadLine();
                                                                        if (publicornot=="1")
                                                                        {
                                                                            publicornot = "public";
                                                                        }
                                                                        else
                                                                        {
                                                                            publicornot = "private";
                                                                        }
                                                                        Playlist tempplaylist = new Playlist(temp, name, user,publicornot);
                                                                        user.MyPlaylist.Add(tempplaylist);
                                                                        anwser = true;
                                                                    }
                                                                    else if (response=="N")
                                                                    {
                                                                        Console.WriteLine("Volviendo al menu anterior...");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                        anwser = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Opcion invalida, intente nuevamente...\n");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                    }
                                                                }
                                                                break;
                                                            case "6":
                                                                List<Video> tempv = mediaPlayer.CreateRecommendedListV(user);
                                                                Console.WriteLine("Estos son los videos de la playlist generada automaticamente:\n");
                                                                foreach (Video video in tempv)
                                                                {
                                                                    Console.WriteLine(video.Name);
                                                                }
                                                                bool anwserv = false;
                                                                while (!anwserv)
                                                                {
                                                                    Console.WriteLine("Desea añadir la playlist a sus playlist? Y/N");
                                                                    string response = Console.ReadLine();
                                                                    if (response == "Y")
                                                                    {
                                                                        string name = "";
                                                                        bool nullcheck = false;
                                                                        while (!nullcheck)
                                                                        {
                                                                            Console.WriteLine("Ingrese el nombre de la playlist:\n");
                                                                            name = Console.ReadLine();
                                                                            nullcheck = !String.IsNullOrEmpty(name);
                                                                            if (!nullcheck)
                                                                            {
                                                                                Console.WriteLine("Ingreso un nombre vacio, Intente nuevamete...\n");
                                                                            }
                                                                        }
                                                                        Console.WriteLine("Si desea:\n\t(1) Sea publica\n\t(2) Sea privada\n*Advertencia inputs erroneos se tomaran como privada*\n");
                                                                        string publicornot = Console.ReadLine();
                                                                        if (publicornot == "1")
                                                                        {
                                                                            publicornot = "public";
                                                                        }
                                                                        else
                                                                        {
                                                                            publicornot = "private";
                                                                        }
                                                                        Playlist tempplaylist = new Playlist(tempv, name, user,publicornot);
                                                                        user.MyPlaylist.Add(tempplaylist);
                                                                        anwserv = true;
                                                                    }
                                                                    else if (response == "N")
                                                                    {
                                                                        Console.WriteLine("Volviendo al menu anterior...");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                        anwserv = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Opcion invalida, intente nuevamente...\n");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                    }
                                                                }
                                                                break;
                                                            case "7":
                                                                playliststopper = true;
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                            default:
                                                                Console.WriteLine("Opcion invalida intente nuevamente...");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "5":
                                                    bool followstopper = false;
                                                    while (!followstopper)
                                                    {
                                                        Console.WriteLine("Si desea:\n\t(1)Reproducir tus playlist\n\t(2)Reproducir playlist de tus usarios seguidos\n\t(3)Reproducir cancion de album de tus seguidos\n\t(4)Reproducir cancion o video de tus artistas seguidos\n\t(5)Reproducir tus series seguidas\n\t(6)Reproducir clase de tus profesores seguidos\n\t(7)Volver al menu principal\n");
                                                        string followfilter = Console.ReadLine();
                                                        switch (followfilter)
                                                        {
                                                            case "1"://Listo
                                                                if (user.MyPlaylist.Count()!=0)
                                                                {
                                                                    bool success = false;
                                                                    int pchoice = 0;
                                                                    Console.WriteLine("Seleccione la playlist a escuchar:\n");
                                                                    foreach (Playlist playlist in user.MyPlaylist)
                                                                    {
                                                                        Console.WriteLine("({0}) {1}\n", user.MyPlaylist.IndexOf(playlist)+1, playlist.PlaylistName);
                                                                    }
                                                                    while (!success)
                                                                    {
                                                                        success = int.TryParse(Console.ReadLine(), out pchoice);
                                                                        if (!success)
                                                                        {
                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                            Thread.Sleep(1000);
                                                                        }
                                                                        else
                                                                        {
                                                                            pchoice--;
                                                                        }
                                                                        if (user.MyPlaylist.Count() >= Math.Abs(pchoice))
                                                                        {
                                                                            Console.WriteLine("Hola");
                                                                            mediaPlayer.Play((user.MyPlaylist[pchoice]), user);
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                            Thread.Sleep(1000);
                                                                            success = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No tienes playlists, volviendo al menu anterior...\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }                                
                                                                break;
                                                            case "2"://Listo
                                                                if (user.FollowUsers.Count()!=0)
                                                                {
                                                                    bool success2 = false;
                                                                    int uchoice = 0;
                                                                    Console.WriteLine("Seleccione el usuario:\n");
                                                                    foreach (User followed in user.FollowUsers)
                                                                    {
                                                                        Console.WriteLine("({0}) {1}\n", user.FollowUsers.IndexOf(followed)+1, followed.Name);
                                                                    }
                                                                    while (!success2)
                                                                    {
                                                                        success2 = int.TryParse(Console.ReadLine(), out uchoice);
                                                                        if (!success2)
                                                                        {
                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            uchoice--;
                                                                        }
                                                                        if (user.FollowUsers.Count() >= Math.Abs(uchoice))
                                                                        {
                                                                            if (user.FollowUsers[uchoice].MyPlaylist.Count()!=0)
                                                                            {
                                                                                bool internesuccess = false;
                                                                                int intern = 0;
                                                                                Console.WriteLine("Seleccione la playlist a escuchar:\n");
                                                                                foreach (Playlist playlist in user.FollowUsers[uchoice].MyPlaylist)
                                                                                {
                                                                                    Console.WriteLine("({0}) {1}\n", user.FollowUsers[uchoice].MyPlaylist.IndexOf(playlist)+1, playlist.PlaylistName);
                                                                                }
                                                                                while (!internesuccess)
                                                                                {
                                                                                    internesuccess = int.TryParse(Console.ReadLine(), out intern);
                                                                                    if (!internesuccess)
                                                                                    {
                                                                                        Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        intern--;
                                                                                    }
                                                                                    if (user.FollowUsers.Count() >= intern)
                                                                                    {
                                                                                        mediaPlayer.Play(user.FollowUsers[uchoice].MyPlaylist[intern], user);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                        internesuccess = false;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("El usuario seguido no tiene playlists, volviendo al menu anterior..\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                            success2 = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("no tienes usuario seguidos, volviendo al menu anterior..\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }                                                               
                                                                break;
                                                            case "4"://Artistas
                                                                if (user.FollowArtist.Count()!=0)
                                                                {
                                                                    Console.WriteLine("Si desea:\n\t(1)Reproducir videos del artista(2)Reproduciir canciones del artista()Cualquier caracter para volver al menu anterior\n");
                                                                    string sov = Console.ReadLine();
                                                                    if (sov=="1")
                                                                    {
                                                                        bool success3 = false;
                                                                        int achoice = 0;
                                                                        Console.WriteLine("Seleccione el artista a escuchar:\n");
                                                                        foreach (Artist artist in user.FollowArtist)
                                                                        {
                                                                            Console.WriteLine("({0}) {1}\n", user.FollowArtist.IndexOf(artist)+1, artist.Name);
                                                                        }
                                                                        while (!success3)
                                                                        {
                                                                            success3 = int.TryParse(Console.ReadLine(), out achoice);
                                                                            if (!success3)
                                                                            {
                                                                                Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                            }
                                                                            else
                                                                            {
                                                                                achoice--;
                                                                            }
                                                                            if (user.FollowArtist.Count() >= Math.Abs(achoice))
                                                                            {
                                                                                if (user.FollowArtist[achoice].Videos.Count() != 0)
                                                                                {
                                                                                    bool successintern = false;
                                                                                    int schoiceintern = 0;
                                                                                    Console.WriteLine("Seleccione el video a ver:\n");
                                                                                    foreach (Video video in user.FollowArtist[achoice].Videos)
                                                                                    {
                                                                                        Console.WriteLine("({0}) {1}\n", user.FollowArtist[achoice].Videos.IndexOf(video), video.Name);
                                                                                    }
                                                                                    while (!successintern)
                                                                                    {
                                                                                        successintern = int.TryParse(Console.ReadLine(), out schoiceintern);
                                                                                        if (!successintern)
                                                                                        {
                                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                            Thread.Sleep(1000);
                                                                                            Console.Clear();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            schoiceintern--;
                                                                                        }
                                                                                        if (user.FollowArtist.Count() >= schoiceintern)
                                                                                        {
                                                                                            mediaPlayer.Play((user.FollowArtist[achoice].Songs[schoiceintern]), user);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                            Thread.Sleep(1000);
                                                                                            Console.Clear();
                                                                                            successintern = false;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("El artista seguido no tiene videos, volviendo al menu anterior..\n");
                                                                                    Thread.Sleep(1000);
                                                                                    Console.Clear();
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                                success3 = false;
                                                                            }


                                                                        }
                                                                    }
                                                                    else if (sov=="2")
                                                                    {
                                                                        bool success3 = false;
                                                                        int achoice = 0;
                                                                        Console.WriteLine("Seleccione el artista a escuchar:\n");
                                                                        foreach (Artist artist in user.FollowArtist)
                                                                        {
                                                                            Console.WriteLine("({0}) {1}\n", user.FollowArtist.IndexOf(artist)+1, artist.Name);
                                                                        }
                                                                        while (!success3)
                                                                        {
                                                                            success3 = int.TryParse(Console.ReadLine(), out achoice);
                                                                            if (!success3)
                                                                            {
                                                                                Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                            }
                                                                            else
                                                                            {
                                                                                achoice--;
                                                                            }
                                                                            if (user.FollowPlaylist.Count() >= Math.Abs(achoice))
                                                                            {
                                                                                if (user.FollowArtist[achoice].Songs.Count() != 0)
                                                                                {
                                                                                    bool successintern = false;
                                                                                    int schoiceintern = 0;
                                                                                    Console.WriteLine("Seleccione la cancion a escuchar:\n");
                                                                                    foreach (Song song in user.FollowArtist[achoice].Songs)
                                                                                    {
                                                                                        Console.WriteLine("({0}) {1}\n", user.FollowArtist[achoice].Songs.IndexOf(song)+1, song.Name);
                                                                                    }
                                                                                    while (!successintern)
                                                                                    {
                                                                                        successintern = int.TryParse(Console.ReadLine(), out schoiceintern);
                                                                                        if (!successintern)
                                                                                        {
                                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                            Thread.Sleep(1000);
                                                                                            Console.Clear();
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            schoiceintern--;
                                                                                        }
                                                                                        if (user.FollowArtist.Count() >= schoiceintern)
                                                                                        {
                                                                                            mediaPlayer.Play((user.FollowArtist[achoice].Songs[schoiceintern]), user);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                            Thread.Sleep(1000);
                                                                                            Console.Clear();
                                                                                            successintern = false;
                                                                                        }
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    Console.WriteLine("El artista seguido no tiene canciones, volviendo al menu anterior..\n");
                                                                                    Thread.Sleep(1000);
                                                                                    Console.Clear();
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                                success3 = false;
                                                                            }


                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("Volviendo al menu anterior..\n");
                                                                        Thread.Sleep(1000);
                                                                        Console.Clear();
                                                                    }
                                                               
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No tienes artistas seguidos, volviendo al menu anterior..\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }
                                                                break;
                                                            case "3"://Albums
                                                                if (user.FollowAlbums.Count()!=0)
                                                                {                                                                   
                                                                    bool success3 = false;
                                                                    int achoice = 0;
                                                                    Console.WriteLine("Seleccione el album a escuchar:\n");
                                                                    foreach (Album item in user.FollowAlbums)
                                                                    {
                                                                        Console.WriteLine("({0}) {1}\n", user.FollowAlbums.IndexOf(item)+1, item.Name);
                                                                    }
                                                                    while (!success3)
                                                                    {
                                                                        success3 = int.TryParse(Console.ReadLine(), out achoice);
                                                                        if (!success3)
                                                                        {
                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            achoice--;
                                                                        }
                                                                        if (user.FollowAlbums.Count() >= Math.Abs(achoice))
                                                                        {
                                                                            if (user.FollowAlbums[achoice].Songs.Count() != 0)
                                                                            {
                                                                                bool successintern = false;
                                                                                int schoiceintern = 0;
                                                                                Console.WriteLine("Seleccione la cancion a escuchar:\n");
                                                                                foreach (Song song in user.FollowAlbums[achoice].Songs)
                                                                                {
                                                                                    Console.WriteLine("({0}) {1}\n", user.FollowAlbums[achoice].Songs.IndexOf(song)+1, song.Name);
                                                                                }
                                                                                while (!successintern)
                                                                                {
                                                                                    successintern = int.TryParse(Console.ReadLine(), out schoiceintern);
                                                                                    if (!successintern)
                                                                                    {
                                                                                        Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        schoiceintern--;
                                                                                    }
                                                                                    if (user.FollowAlbums.Count() >= Math.Abs(schoiceintern))
                                                                                    {
                                                                                        mediaPlayer.Play((user.FollowAlbums[achoice].Songs[schoiceintern]), user);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                        successintern = false;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("El album seguido no tiene canciones, volviendo al menu anterior..\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                            success3 = false;
                                                                        }
                                                                    }                                                                    
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No tienes albums seguidos, volviendo al menu anterior..\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }
                                                                break;
                                                            case "5"://Series
                                                                if (user.FollowSeries.Count() != 0)
                                                                {
                                                                    bool success = false;
                                                                    int pchoice = 0;
                                                                    Console.WriteLine("Seleccione la serie a ver:\n");
                                                                    foreach (Series serie in user.FollowSeries)
                                                                    {
                                                                        Console.WriteLine("({0}) {1}\n", user.FollowSeries.IndexOf(serie)+1, serie.SerieName);
                                                                    }
                                                                    while (!success)
                                                                    {
                                                                        success = int.TryParse(Console.ReadLine(), out pchoice);
                                                                        if (!success)
                                                                        {
                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            pchoice--;
                                                                        }
                                                                        if (user.FollowSeries.Count() >= Math.Abs(pchoice))
                                                                        {
                                                                            mediaPlayer.Play((user.FollowSeries[pchoice]), user);
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                            success = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No tienes series seguida, volviendo al menu anterior...\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }
                                                                break;
                                                            case "6"://teachers
                                                                if (user.FollowTeachers.Count()!=0)
                                                                {
                                                                    bool success3 = false;
                                                                    int achoice = 0;
                                                                    Console.WriteLine("Seleccione el profesor:\n");
                                                                    foreach (Teacher item in user.FollowTeachers)
                                                                    {
                                                                        Console.WriteLine("({0}) {1}\n", user.FollowTeachers.IndexOf(item)+1, item.Name);
                                                                    }
                                                                    while (!success3)
                                                                    {
                                                                        success3 = int.TryParse(Console.ReadLine(), out achoice);
                                                                        if (!success3)
                                                                        {
                                                                            Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                        }
                                                                        else
                                                                        {
                                                                            achoice--;
                                                                        }
                                                                        if (user.FollowTeachers.Count() >= Math.Abs(achoice))
                                                                        {
                                                                            if (user.FollowTeachers[achoice].Lessons.Count() != 0)
                                                                            {
                                                                                bool successintern = false;
                                                                                int schoiceintern = 0;
                                                                                Console.WriteLine("Seleccione el video a ver:\n");
                                                                                foreach (Lesson les in user.FollowTeachers[achoice].Lessons)
                                                                                {
                                                                                    Console.WriteLine("({0}) {1}\n", user.FollowTeachers[achoice].Lessons.IndexOf(les)+1, les.Name);
                                                                                }
                                                                                while (!successintern)
                                                                                {
                                                                                    successintern = int.TryParse(Console.ReadLine(), out schoiceintern);
                                                                                    if (!successintern)
                                                                                    {
                                                                                        Console.WriteLine("Formato invalido, ingrese un numero...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        schoiceintern--;
                                                                                    }
                                                                                    if (user.FollowArtist.Count() >= schoiceintern)
                                                                                    {
                                                                                        mediaPlayer.Play((user.FollowTeachers[achoice].Lessons[schoiceintern]), user);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                                        Thread.Sleep(1000);
                                                                                        Console.Clear();
                                                                                        successintern = false;
                                                                                    }
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("El artista seguido no tiene videos, volviendo al menu anterior..\n");
                                                                                Thread.Sleep(1000);
                                                                                Console.Clear();
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            Console.WriteLine("Seleccione una opcion dentro del rango...\n");
                                                                            Thread.Sleep(1000);
                                                                            Console.Clear();
                                                                            success3 = false;
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("No tienes profesores seguidos, volviendo al menu anterior...\n");
                                                                    Thread.Sleep(1000);
                                                                    Console.Clear();
                                                                }
                                                                
                                                                break;
                                                            case "7":
                                                                followstopper = true;
                                                                Console.Clear();
                                                                break;
                                                            default:
                                                                Console.WriteLine("Opcion invalida intente nuevamente...");
                                                                Thread.Sleep(1000);
                                                                Console.Clear();
                                                                break;
                                                        }
                                                    }
                                                    break;
                                                case "6":
                                                    Console.Clear();
                                                    break;
                                                default:
                                                    Console.WriteLine("Opcion invalida intente nuevamente...");
                                                    Thread.Sleep(1000);
                                                    Console.Clear();
                                                    break;
                                                   
 
                                            }
                                        }
                                    }
                                    else { Thread.Sleep(1000); Console.Clear(); }
                                    break;

                                case "2": //Administrador
                                    Console.WriteLine("Ingrese su codigo de administrador");
                                    string nn = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña");
                                    string pp = Console.ReadLine();
                                    Console.Clear();
                                    if (Gate.LogAsAdmin(nn, pp))
                                    {
                                        string switcherad = "0";
                                        string stopperad = "6";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Importar cancion\n\t(2)Importar video\n\t(3)Importar un karaoke\n\t(4)Añadir o eliminar video existente a una Serie\n\t(5)Cambiar su contraseña\n\t(6)Atras\n");
                                            switcherad = Console.ReadLine();
                                            Console.Clear();
                                            switch (switcherad)
                                            {
                                                case "1": //importar cancion
                                                    admin.ImportSong(mediaPlayer);
                                                    break;
                                                case "2": //importar video
                                                    admin.ImportVideo(mediaPlayer);
                                                    break;
                                                case "3": //importar karaoke
                                                    admin.ImportKaraoke(mediaPlayer);
                                                    break;
                                                case "4":
                                                    Console.WriteLine("Diga Add si quiere añadir o Delete si quiere eliminar");
                                                    string op = Console.ReadLine().ToLower() ;
                                                    Console.WriteLine("Diga el nombre de la serie");
                                                    string ser = Console.ReadLine();
                                                    Console.WriteLine("Diga el nombre del director");
                                                    string dir = Console.ReadLine();
                                                    Console.WriteLine("Ingrese el nombre del video ya existente");
                                                    string vide = Console.ReadLine();
                                                    mediaPlayer.VideoSerieStarter(op, ser, vide, dir, mediaPlayer);
                                                    break;
                                                case "5": //cambiar contraseña
                                                    Gate.ChangePassword();
                                                    break;
                                                case "6":
                                                    Console.Clear();
                                                    break;

                                                default:
                                                    Console.WriteLine("Ingrese una opcion valida");
                                                    break;
                                            }
                                        }
                                    }
                                    else { Thread.Sleep(1000); Console.Clear(); }
                                    break;

                                case "3": //profesor

                                    Console.WriteLine("Ingrese su codigo de profesor");
                                    string mm = Console.ReadLine();
                                    Console.WriteLine("Ingrese su Gmail");
                                    string gm = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña");
                                    string ññ = Console.ReadLine();
                                    Console.Clear();
                                    if (Gate.LogAsTeacher(mm, ññ))
                                    {
                                        int posiciont = -1;
                                        foreach (Teacher te in Gate.Teachers)
                                        {
                                            posiciont++;
                                            if (gm == te.Gmail)
                                            {
                                                break;
                                            }
                                        } 
                                        string switcherad = "0";
                                        string stopperad = "3";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Importar clase\n\t(2)Editar su perfil\n\t(3)Atras\n");
                                            switcherad = Console.ReadLine();
                                            Console.Clear();
                                            switch (switcherad)
                                            {
                                                case "1": //importar videos
                                                    teacher.ImportLesson(mediaPlayer);
                                                    break;
                                                case "2":
                                                    Gate.ChangeTeacher(Gate.Teachers[posiciont]);
                                                    break;
                                                case "3":
                                                    Console.Clear();
                                                    break;
                                                default:
                                                    Console.WriteLine("Ingrese una opcion valida");
                                                    break;
                                            }
                                        }
                                    }
                                    else { Thread.Sleep(1000); Console.Clear(); }
                                    break;
                                case "4":
                                    break;
                                default:
                                    Console.WriteLine("Ingrese una opcion valida");
                                    break;
                            }
                        }
                        break;
                    case "3":

                        if (Gate.Users.Count()!=0)
                        {
                            SaveUser(Gate.Users);
                        }
                        if (Gate.Managers.Count()!=0)
                        {
                            SaveAdmin(Gate.Managers);
                        }
                        if (Gate.Teachers.Count()!=0)
                        {
                            SaveTeacher(Gate.Teachers);
                        }
                        if (mediaPlayer.Songs.Count()!=0)
                        {
                            SaveSong(mediaPlayer.Songs);
                        }
                        if (mediaPlayer.Videos.Count()!=0)
                        {
                            SaveVideo(mediaPlayer.Videos);
                        }
                        if (mediaPlayer.Lessons.Count()!=0)
                        {
                            SaveLesson(mediaPlayer.Lessons);
                        }
                        if (mediaPlayer.Playlists.Count()!=0)
                        {
                            SavePlaylist(mediaPlayer.Playlists);
                        }
                        if (mediaPlayer.Series.Count()!=0)
                        {
                            SaveSerie(mediaPlayer.Series);
                        }
                        if (mediaPlayer.Karaokes.Count()!=0)
                        {
                            SaveKaraoke(mediaPlayer.Karaokes);
                        }
                        if (mediaPlayer.Albums.Count()!=0)
                        {
                            SaveAlbum(mediaPlayer.Albums);
                        }
                        
    
                        switcher = "3";
                        break;

                    default:
                        Console.WriteLine("Ingrese una opción valida\n");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }


        }
    }

}
