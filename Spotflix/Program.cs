﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Resources;
using WMPLib;

namespace Spotflix
{
    public class Program
    {
        //Metodos Serializar:
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
            Stream stream = new FileStream("ArchivoProfesores.bin", FileMode.Open, FileAccess.Read, FileShare.Read);
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
            MediaPlayer mediaPlayer = new MediaPlayer();
            Admin admin = new Admin();
            User user = new User();

            Teacher teacher = new Teacher();
            List<Video> vid = new List<Video>();
            List<Song> son = new List<Song>();

            Playlist play = new Playlist();
            Album album = new Album();
  



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

            Console.WriteLine("(1)Empezar desde 0\n(2)Cargar archivos serializados");
            string choser = Console.ReadLine();
            if (choser=="(2)")
            {
                string archivouser = @"\ArchivoUsuarios.bin";
                string pathu = Directory.GetCurrentDirectory() + archivouser;
                if (File.Exists(pathu))
                {
                    users = LoadUser();
                }
                else { }
                string archivoadmin = @"\ArchivoAdministradores.bin";
                string patha = Directory.GetCurrentDirectory() + archivoadmin;
                if (File.Exists(patha))
                {
                    admins = LoadAdmin();
                }
                else { }
                string archivoteacher = @"\ArchivoProfesores.bin";
                string patht = Directory.GetCurrentDirectory() + archivoteacher;
                if (File.Exists(patht))
                {
                    teachers = LoadTeacher();
                }
                else { }
                string archivosong = @"\ArchivoCanciones.bin";
                string paths = Directory.GetCurrentDirectory() + archivosong;
                if (File.Exists(paths))
                {
                    Songs = LoadSong();
                }
                else { }


                string archivovideo = @"\ArchivoVideos.bin";
                string pathv = Directory.GetCurrentDirectory() + archivovideo;
                if (File.Exists(pathv))
                {
                    Videos = LoadVideo();
                }
                else { }


                string archivolesson = @"\ArchivoClases.bin";
                string pathl = Directory.GetCurrentDirectory() + archivolesson;
                if (File.Exists(pathl))
                {
                    Lessons = LoadLesson();
                }
                else { }


                string archivoplay = @"\ArchivoPlaylist.bin";
                string pathp = Directory.GetCurrentDirectory() + archivoplay;
                if (File.Exists(pathp))
                {
                    Playlists = LoadPlaylist();
                }
                else { }


                string archivoserie = @"\ArchivoSeries.bin";
                string pathse = Directory.GetCurrentDirectory() + archivoserie;
                if (File.Exists(pathse))
                {
                    Series = LoadSerie();
                }
                else { }


                string archivokarak = @"\ArchivoKaraoke.bin";
                string pathk = Directory.GetCurrentDirectory() + archivokarak;
                if (File.Exists(pathk))
                {
                    Karaokes = LoadKaraoke();
                }
                else { }

                string archivoalbum = @"\ArchivoAlbum.bin";
                string pathal = Directory.GetCurrentDirectory() + archivoalbum;
                if (File.Exists(pathal))
                {
                    Albums = LoadAlbum();
                }
                else { }
            }
               
            

            mediaPlayer.AddVideoSerie += admin.OnAddVideoSerie;
            mediaPlayer.DeleteVideoSerie += admin.OnDeleteVideoSerie;
            mediaPlayer.AddSong += user.OnAddSong;
            mediaPlayer.DeleteSong += user.OnDeleteSong;
            mediaPlayer.AddVideo += user.OnAddVideo;
            mediaPlayer.DeleteVideo += user.OnDeleteVideo;
            mediaPlayer.OrderBy += play.OnOrderBy;
            mediaPlayer.OrderByA += album.OnOrderByA;


            int num = 1;
            string switcher = "0";
            string stopper = "3";

            while (switcher != stopper)
            {
                Console.WriteLine("Si desea:\n\t(1)Registrarse\n\t(2)Iniciar Sesion\n\t(3)Salir del programa\n");
                switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1": //Registrarse
                        string register = "0";
                        Console.WriteLine("Si desea:\n\t(1)Registrarse como usuario\n\t(2)Registrarse como administrador\n\t(3)Registrarse como profesor\n");
                        register = Console.ReadLine();
                        switch (register)
                        {
                            case "1": //usuario
                                Console.WriteLine("Ingrese su nombre: ");
                                string name = Console.ReadLine();
                                Console.WriteLine("Ingrese su apellido: ");
                                string lastName = Console.ReadLine();
                                Console.WriteLine("nIngrese su edad: ");
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
                                Console.WriteLine("\nIngrese su calle:");
                                string street = Console.ReadLine();
                                Console.WriteLine("Ingrese su código postal:");
                                string postalCode = Console.ReadLine();
                                bool nickcheck = false;
                                bool mailcheck = false;
                                string nickName = "";
                                string gmail = "";
                                while (!mailcheck)
                                {
                                    Console.WriteLine("Ingrese su Gmail:");
                                    gmail = Console.ReadLine();
                                    mailcheck = Gate.CheckGmail(gmail);
                                }
                                while (!nickcheck)
                                {
                                    Console.WriteLine("Ingrese su nombre de usuario:");
                                    nickName = Console.ReadLine();
                                    nickcheck = Gate.checkUsername(nickName);
                                }
                                Console.WriteLine("Ingrese su contraseña:");
                                string passWord = Console.ReadLine();
                                if (nickcheck && mailcheck)
                                {
                                    User u1 = new User(num, gmail, nickName, passWord, name, lastName, age, country, city, street, postalCode);
                                    Gate.SingUser(u1);
                                    Thread.Sleep(1000);
                                    Console.Clear();
                                }
                                num++;
                                break;
                            case "2": //administrador
                                Console.WriteLine("Ingrese el codigo para registrarse como admin");
                                string key = Console.ReadLine();
                                if (key == "123")
                                {
                                    bool nickchecka = false;
                                    bool mailchecka = false;
                                    string nickNamea = "";
                                    string gmaila = "";
                                    while (!mailchecka)
                                    {
                                        Console.WriteLine("\nIngrese su Gmail\n");
                                        gmaila = Console.ReadLine();
                                        mailchecka = Gate.CheckGmailA(gmaila);
                                    }
                                    while (!nickchecka)
                                    {
                                        Console.WriteLine("\nIngrese su nombre de usuario\n");
                                        nickNamea = Console.ReadLine();
                                        nickchecka = Gate.checkUsernameA(nickNamea);
                                    }
                                    Console.WriteLine("\nIngrese su contraseña\n ");
                                    string passWorda = Console.ReadLine();
                                    if (nickchecka && mailchecka)
                                    {
                                        Admin a1 = new Admin(nickNamea, gmaila, key, passWorda);
                                        Gate.SingAdmin(a1);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Codigo invalido, volviendo al menu...");
                                    Thread.Sleep(1000);
                                }
                                break;
                            case "3": //profesor
                                Console.WriteLine("Ingrese el codigo para registrarse como profesor:");
                                string key_T = Console.ReadLine();
                                if (key_T == "321")
                                {
                                    bool nickcheckp = false;
                                    bool mailcheckp = false;
                                    string nickNamep = "";
                                    string gmailp = "";
                                    string namet="";
                                    string lastname = "";
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
                                        


                                    Console.WriteLine("Ingrese su contraseña:\n ");
                                    string passWordp = Console.ReadLine();
                                    if (nickcheckp && mailcheckp)
                                    {
                                        Console.WriteLine("Ingrese el curso que desea tener:\n");
                                        string curso = Console.ReadLine();
                                        Teacher t1 = new Teacher(nickNamep, namet, lastname, gmailp, key_T, curso, passWordp);
                                        Gate.SingTeacher(t1);
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
                                Console.WriteLine("Opcion invalida, volviendo al menu...");
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
                            switch (switcher2)
                            {
                                case "1": //usuario

                                    Console.WriteLine("Ingrese su nombre de usuario o Gmail\n");
                                    string n = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string p = Console.ReadLine();
                                    if (Gate.LogAsUser(n, p))
                                    {
                                        
                                        string switcherusr = "0";
                                        string stopperusr = "24";
                                        while (switcherusr != stopperusr)
                                        {
                                            Console.WriteLine("Si desea:\n\t(0)Buscador General para reproducir\n\t(1)Buscar y reproducir videos\n\t(2)Buscar y reproducir canciones\n\t(3)Buscar y reproducir series\n\t(4)Buscar y reproducir playlist\n\t(5)Mostrar videos\n\t(6)Mostrar canciones\n\t(7)Mostrar series\n\t(8)Mostrar playlist\n\t(9)Convertirse en Premium\n\t(10)Añadir canciones a favorito\n\t(11)Añadir videos a favorito\n\t(12)Cambiar contraseña\n\t(13)Calificar una cancion\n\t(14)Calificar un video\n\t(15)Hacer una PlayList de canciones\n\t(16)Hacer una PlayList de videos\n\t(17)Añadir a la cola\n\t(18)Seguir a otro usuario\n\t(19)Saber la calificación de una canción\n\t(20)Saber la calificación de un video\n\t(21)Saber la información de la canción\n\t(22)Saber la información de un video\n\t(23)Saber la información intrínseca de una canción\n\t(24)Saber la información intrínseca de un video\n\t(25)Saber la información en la plataforma de una canción\n\t(26)Saber la información en la plataforma de un video\n\t(32)Atras\n");
                                            switcherusr = Console.ReadLine();

                                            switch (switcherusr)
                                            {
                                                case "0":
                                                    if (mediaPlayer.GenericSearch().Contains(-1)) break;
                                                    else
                                                    {
                                                        List<int> choice = mediaPlayer.GenericSearch();

                                                        if (choice[0] == 1)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Videos[choice[1]]);
                                                        }
                                                        else if (choice[0] == 2)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Songs[choice[1]]);
                                                        }
                                                        else if (choice[0] == 3)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Lessons[choice[1]]);
                                                        }
                                                        else if (choice[0] == 4)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Karaokes[choice[1]]);
                                                        }
                                                        else if (choice[0] == 5)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Playlists[choice[1]]);
                                                        }
                                                        else if (choice[0] == 6)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Albums[choice[1]]);
                                                        }
                                                        else if (choice[0] == 7)
                                                        {
                                                            mediaPlayer.Play(mediaPlayer.Series[choice[1]]);
                                                        }
                                                    }

                                                    break;
                                                /*
                                                case "1": //buscar y reproducir videos
                                                    mediaPlayer.Search("1");
                                                    int variable1 = mediaPlayer.Search("1");
                                                    if (variable1 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.Videos[variable1]);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "2": //buscar y reproducir canciones
                                                    mediaPlayer.Search("2");
                                                    int variable2 = mediaPlayer.Search("2");
                                                    if (variable2 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.Songs[variable2]);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "3": //buscar y reproducir series
                                                    mediaPlayer.Search("3");
                                                    int variable3 = mediaPlayer.Search("3");
                                                    if (variable3 == -1) break;
                                                    else
                                                    {
                                                        //mediaPlayer.Play(mediaPlayer.Series[variable3]);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "4": //buscar y reproducir playlist
                                                    mediaPlayer.Search("4");
                                                    int variable4 = mediaPlayer.Search("4");
                                                    if (variable4 == -1) break;
                                                    else
                                                    {
                                                        //mediaPlayer.Play(mediaPlayer.Playlists[variable4]);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break; */
                                                case "5": //mostrar los videos
                                                    mediaPlayer.ShowVideos();
                                                    break;
                                                case "6": //mostrar las canciones
                                                    mediaPlayer.ShowSongs();
                                                    break;
                                                case "7": //mostrar las series
                                                    mediaPlayer.ShowSeries();
                                                    break;
                                                case "8": //mostrar las playlist
                                                    mediaPlayer.ShowPlaylists();
                                                    break;
                                                case "9": //Premium
                                                    //algo.convertirseenpremium()
                                                    break;
                                                case "10": //agregar cancion a favorito
                                                    mediaPlayer.Search("2");
                                                    int variableadds = mediaPlayer.Search("2");
                                                    if (variableadds == -1) break;
                                                    else
                                                    {
                                                        user.AddToFavorite(mediaPlayer.Songs[variableadds]);
                                                    }
                                                    break;
                                                case "11": //agregar video a favorito
                                                    mediaPlayer.Search("1");
                                                    int variableaddv = mediaPlayer.Search("1");
                                                    if (variableaddv == -1) break;
                                                    else
                                                    {
                                                        user.AddToFavorite(mediaPlayer.Videos[variableaddv]);
                                                    }
                                                    break;
                                                case "12": //cambiar contraseña
                                                    //cambiarcontraseña
                                                    break;
                                                case "13": //calificar una cancion
                                                    mediaPlayer.Search("2");
                                                    int variableqs = mediaPlayer.Search("2");
                                                    if (variableqs == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Qualify(mediaPlayer.Songs[variableqs]);
                                                    }
                                                    break;
                                                case "14": //calificar un video
                                                    mediaPlayer.Search("1");
                                                    int variableqv = mediaPlayer.Search("1");
                                                    if (variableqv == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Qualify(mediaPlayer.Videos[variableqv]);
                                                    }
                                                    break;
                                                case "15": //crear playlist de canciones
                                                    mediaPlayer.CreatePlaylistS(user);
                                                    break;
                                                case "16": //crear playlist de videos
                                                    mediaPlayer.CreatePlaylistV(user);
                                                    break;
                                                case "17": //añadir a la cola
                                                    mediaPlayer.AddToQueue();
                                                    break;
                                                case "18": //seguir a otras personas
                                                   // mediaPlayer.Follow();
                                                    break;

                                                case "19": //calificacion cancion
                                                    mediaPlayer.Search("2");
                                                    int variablegqs = mediaPlayer.Search("2");
                                                    if (variablegqs == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetQualification(mediaPlayer.Songs[variablegqs]);
                                                    }
                                                    break;
                                                case "20": //calificacion video
                                                    mediaPlayer.Search("1");
                                                    int variablegqv = mediaPlayer.Search("1");
                                                    if (variablegqv == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetQualification(mediaPlayer.Videos[variablegqv]);
                                                    }
                                                    break;
                                                case "21":
                                                    mediaPlayer.Search("2");
                                                    int variablegmds = mediaPlayer.Search("2");
                                                    if (variablegmds == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetMetadata(mediaPlayer.Songs[variablegmds]);
                                                    }
                                                    break;
                                                case "22":
                                                    mediaPlayer.Search("1");
                                                    int variablegmdv = mediaPlayer.Search("1");
                                                    if (variablegmdv == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetMetadata(mediaPlayer.Videos[variablegmdv]);
                                                    }
                                                    break;
                                                case "23":
                                                    mediaPlayer.Search("2");
                                                    int variablegiis = mediaPlayer.Search("2");
                                                    if (variablegiis == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetInstrinsicInformation(mediaPlayer.Songs[variablegiis]);
                                                    }
                                                    break;
                                                case "24":
                                                    mediaPlayer.Search("1");
                                                    int variablegiiv = mediaPlayer.Search("1");
                                                    if (variablegiiv == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetInstrinsicInformation(mediaPlayer.Videos[variablegiiv]);
                                                    }
                                                    break;
                                                case "25":
                                                    mediaPlayer.Search("2");
                                                    int variablegpis = mediaPlayer.Search("2");
                                                    if (variablegpis == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetPlataformInformation(mediaPlayer.Songs[variablegpis]);
                                                    }
                                                    break;
                                                case "26":
                                                    mediaPlayer.Search("1");
                                                    int variablegpiv = mediaPlayer.Search("1");
                                                    if (variablegpiv == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.GetPlataformInformation(mediaPlayer.Videos[variablegpiv]);
                                                    }
                                                    break;




                                                case "32":
                                                    break;

                                                default:
                                                    Console.WriteLine("Ingrese una opcion valida");
                                                    break;
                                            }
                                        }
                                    }
                                    break;

                                case "2": //Administrador
                                    Console.WriteLine("Ingrese su codigo de admin\n");
                                    string nn = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string pp = Console.ReadLine();
                                    //Gate.LogAsAdmin(nn, pp);
                                    if (Gate.LogAsAdmin(nn, pp))
                                    {
                                        string switcherad = "0";
                                        string stopperad = "8";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Importar cancion\n\t(2)Importar video\n\t(3)Remover cancion\n\t(4)Remover video\n\t(5)Descargar cancion\n\t(6)Descargar video\n\t(7)Cambiar su contraseña\n\t(8)Atras\n");
                                            switcherad = Console.ReadLine();

                                            switch (switcherad)
                                            {
                                                case "1": //importar cancion
                                                    //admin.ImportSong(mediaPlayer);
                                                    break;
                                                case "2": //importar video
                                                    //admin.Import(mediaPlayer);
                                                    break;
                                                case "3": //emover cancion
                                                    //admin.Remove(mediaPlayer);
                                                    break;
                                                case "4": //remover video
                                                    //admin.Remove(mediaPlayer);
                                                    break;
                                                case "5": //descargar canciones
                                                    mediaPlayer.Search("2");
                                                    int variabledows = mediaPlayer.Search("2");
                                                    if (variabledows == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Download(mediaPlayer.Songs[variabledows]);
                                                    }
                                                    break;
                                                case "6": //descarga video
                                                    mediaPlayer.Search("1");
                                                    int variabledowv = mediaPlayer.Search("1");
                                                    if (variabledowv == -1) break;
                                                    else
                                                    {
                                                        //mediaPlayer.Download(mediaPlayer.Videos[variabledowv]);
                                                    }
                                                    break;
                                                case "7": //cambiar contraseña
                                                    //cambiar contraseña
                                                    break;
                                                case "8":
                                                    break;

                                                default:
                                                    Console.WriteLine("Ingrese una opcion valida");
                                                    break;
                                            }
                                        }
                                    }
                                    break;

                                case "3": //profesor

                                    Console.WriteLine("Ingrese su codigo de profesor\n");
                                    string mm = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string ññ = Console.ReadLine();
                                    //Gate.LogAsTeacher(mm, ññ);
                                    if (Gate.LogAsTeacher(mm, ññ))
                                    {
                                        string switcherad = "0";
                                        string stopperad = "10";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Importar cancion\n\t(2)Importar video\n\t(3)Remover cancion\n\t(4)Remover video\n\t(5)Descargar cancion\n\t(6)Descargar video\n\t(7)Añadir archivo a curso\n\t(8)Eliminar archivos del curso\n\t(9)Cambiar su contraseña\n\t(10)Atras\n");
                                            switcherad = Console.ReadLine();

                                            switch (switcherad)
                                            {
                                                case "1": //importar canciones
                                                    //admin.Import(mediaPlayer);
                                                    break;
                                                case "2": //importar videos
                                                    //admin.Import(mediaPlayer);
                                                    break;
                                                case "3": //remover canciones
                                                    //admin.Remove(mediaPlayer);
                                                    break;
                                                case "4": //remover videos
                                                    //admin.Remove(mediaPlayer);
                                                    break;
                                                case "5": //descargar canciones
                                                    mediaPlayer.Search("2");
                                                    int variabledows = mediaPlayer.Search("2");
                                                    if (variabledows == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Download(mediaPlayer.Songs[variabledows]);
                                                    }
                                                    break;
                                                case "6": //descarga video
                                                    mediaPlayer.Search("1");
                                                    int variabledowv = mediaPlayer.Search("1");
                                                    if (variabledowv == -1) break;
                                                    else
                                                    {
                                                        //mediaPlayer.Download(mediaPlayer.Videos[variabledowv]);
                                                    }
                                                    break;
                                                case "7": //añadir archivos al curso 
                                                    //teacher.Add(MediaFile,course);
                                                    break;
                                                case "8": //eliminar archivos de curso
                                                    //teacher.Delete(MediaFile, course);
                                                    break;
                                                case "9":
                                                    //cambiar constraseña
                                                    break;
                                                case "10":
                                                    break;

                                                default:
                                                    Console.WriteLine("Ingrese una opcion valida");
                                                    break;
                                            }
                                        }
                                    }
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
                        
                        SaveUser(users);
                        SaveAdmin(admins);
                        SaveTeacher(teachers);
                        SaveSong(Songs);
                        SaveVideo(Videos);
                        SaveLesson(Lessons);
                        SavePlaylist(Playlists);
                        SaveSerie(Series);
                        SaveKaraoke(Karaokes);
                        SaveAlbum(Albums);
                        

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
