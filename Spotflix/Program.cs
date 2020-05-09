using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WMPLib;

namespace Spotflix
{
    public class Program
    {
        static void Main(string[] args)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            Admin admin = new Admin();
            Teacher teacher = new Teacher();
            int num = 1;
            int code = 1000;
            string switcher = "0";
            string stopper = "7";

            while (switcher != stopper)
            {
                Console.WriteLine("Si desea:\n\t(1)Registrarse\n\t(2)Iniciar Sesion\n\t(5)Salir de la busqueda\n");
                switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1": //Registrarse
                        Console.WriteLine("\nIngrese su nombre\n ");
                        string a = Console.ReadLine();
                        Console.WriteLine("\nIngrese su apellido\n ");
                        string b = Console.ReadLine();
                        Console.WriteLine("\nIngrese su edad\n ");
                        string C = Console.ReadLine();
                        int c = Convert.ToInt32(C);
                        Console.WriteLine("\nIngrese su pais de origen\n ");
                        string d = Console.ReadLine();
                        Console.WriteLine("\nIngrese su ciudad de origen\n ");
                        string e = Console.ReadLine();
                        Console.WriteLine("\nIngrese su calle\n ");
                        string f = Console.ReadLine();
                        Console.WriteLine("\nIngrese su código postal\n ");
                        string G = Console.ReadLine();
                        int g = Convert.ToInt32(G);
                        Console.WriteLine("\nIngrese su contraseña\n ");
                        string h = Console.ReadLine();
                        Console.WriteLine("\n¿Desea ser administrador?\n");
                        string res = Console.ReadLine();
                        if (res.ToLower() == "no")
                        {
                            Console.WriteLine("\nIngrese su Gmail\n");
                            string gm = Console.ReadLine();
                            Console.WriteLine("\nIngrese su nombre de usuario\n");
                            string nic = Console.ReadLine();

                            User u1 = new User(num, gm, nic, h, a, b, c, d, e, f, g);
                            Gate.SingUser(u1);
                            num++;
                        }
                        if (res.ToLower() == "si")
                        {
                            Admin a1 = new Admin(code);
                            Gate.SingAdmin(a1);
                            Console.WriteLine("Desea tener un curso sobre alguna materia?\n");
                            string mat = Console.ReadLine();
                            if (mat.ToLower() == "si")
                            {
                                Console.WriteLine("Diga el nombre del curso\n");
                                string cur = Console.ReadLine();
                                Teacher t1 = new Teacher(code, cur, a, b, c, d, e, f, g, h);
                                Gate.SingTeacher(t1);
                                code++;
                            }
                        }
                        break;
                    case "2": //iniciar sesion
                        string switcher2 = "0";
                        string stopper2 = "4";
                        while (switcher2 != stopper2)
                        {
                            Console.WriteLine("Ingrese:\n\t(1)Para usuario\n\t(2)Para administrador\n\t(3)Para profesor\n\t(4)Para salir\n");
                            switcher2 = Console.ReadLine();
                            switch (switcher2)
                            {
                                case "1": //usuario
                                    Console.WriteLine("Ingrese su nombre de usuario o Gmail\n");
                                    string n = Console.ReadLine();
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string p = Console.ReadLine();
                                    Gate.LogAsUser(n, p);
                                    if (Gate.LogAsUser(n, p))
                                    {
                                        string switcherusr = "0";
                                        string stopperusr = "20";
                                        while (switcherusr != stopperusr)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Buscar por videos\n\t(2)Buscar por canciones\n\t(3)Buscar por series\n\t(4)Buscar por playlist\n\t(5)Reproducir por videos\n\t(6)Reproducir por cancion\n\t(7)Reproducir por series\n\t(8)Reproducir por playlist\n\t(9)Convertirse en Premium\n\t(15)Hacer una PlayList de canciones\n\t(16)Añadir a la cola\n\t(17)Seguir a otro usuario\n\t(19)salir de la busqueda\n");
                                            switcherusr = Console.ReadLine();

                                            switch (switcherusr)
                                            {
                                                case "1": //buscar y reproducir videos
                                                    mediaPlayer.Search("1");
                                                    int variable1 = mediaPlayer.Search("1");
                                                    if (variable1 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.videos[variable1].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "2": //buscar y reproducir canciones
                                                    mediaPlayer.Search("2");
                                                    int variable2 = mediaPlayer.Search("2");
                                                    if (variable2 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.songs[variable2].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "3": //buscar y reproducir series
                                                    mediaPlayer.Search("3");
                                                    int variable3 = mediaPlayer.Search("3");
                                                    if (variable3 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.series[variable3].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "4": //buscar y reproducir playlist
                                                    mediaPlayer.Search("4");
                                                    int variable4 = mediaPlayer.Search("4");
                                                    if (variable4 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.playlists[variable4].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
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
                                                    //algo.convertirseenpremium();


                                                    break;

                                                case "15": //crear playlist
                                                    mediaPlayer.CreatePlaylist();
                                                    break;
                                                case "16": //añadir a la cola
                                                    mediaPlayer.AddToQueue(mediaPlayer.Songs);
                                                    break;
                                                case "17": //seguir a otras personas
                                                    mediaPlayer.Follow();
                                                    break;

                                                case "19":
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
                                    string NN = Console.ReadLine();
                                    int nn = Convert.ToInt32(NN);
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string pp = Console.ReadLine();
                                    Gate.LogAsAdmin(nn, pp);
                                    if (Gate.LogAsAdmin(nn, pp))
                                    {
                                        string switcherad = "0";
                                        string stopperad = "20";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Buscar por videos\n\t(2)Buscar por canciones\n\t(3)Buscar por series\n\t(4)Buscar por playlist\n\t(5)Reproducir por videos\n\t(6)Reproducir por cancion\n\t(7)Reproducir por series\n\t(8)Reproducir por playlist\n\t(9)Importar cancion\n\t(10)Importar video\n\t(11)Remover cacnion\n\t(12)Remover video\n\t(13)Descargar cancion/video\n\t(15)Hacer una PlayList de canciones\n\t(16)Añadir a la cola\n\t(17)Seguir a otro usuario\n\t(19)salir de la busqueda\n");
                                            switcherad = Console.ReadLine();

                                            switch (switcherad)
                                            {
                                                case "1": //busca video
                                                    mediaPlayer.Search("1");
                                                    int variable1 = mediaPlayer.Search("1");
                                                    if (variable1 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.videos[variable1].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "2": //busca cancion
                                                    mediaPlayer.Search("2");
                                                    int variable2 = mediaPlayer.Search("2");
                                                    if (variable2 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.songs[variable2].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "3": //buscar serie
                                                    mediaPlayer.Search("3");
                                                    int variable3 = mediaPlayer.Search("3");
                                                    if (variable3 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.series[variable3].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "4": //buscar playlist
                                                    mediaPlayer.Search("4");
                                                    int variable4 = mediaPlayer.Search("4");
                                                    if (variable4 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.playlists[variable4].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "5": //mostrar videos
                                                    mediaPlayer.ShowVideos();
                                                    break;
                                                case "6": //mostrar canciones
                                                    mediaPlayer.ShowSongs();
                                                    break;
                                                case "7": //mostrar series
                                                    mediaPlayer.ShowSeries();
                                                    break;
                                                case "8": //mostrar playlist
                                                    mediaPlayer.ShowPlaylists();
                                                    break;
                                                case "9": //importar cancion
                                                    admin.Import(song, mediaPlayer);
                                                    break;
                                                case "10": //importar video
                                                    admin.Import(video, mediaPlayer);
                                                    break;
                                                case "11": //remover cancion
                                                    admin.Remove(song, mediaPlayer);
                                                    break;
                                                case "12": //remover video
                                                    admin.Remove(video, mediaPlayer);
                                                    break;
                                                case "13": //descargar
                                                    mediaPlayer.Download();
                                                    break;
                                                case "15": //crear playlist
                                                    mediaPlayer.CreatePlaylist();
                                                    break;
                                                case "16": //añadir a la cola
                                                    mediaPlayer.AddToQueue(mediaPlayer.Songs);
                                                    break;
                                                case "17": //seguir usuarios
                                                    mediaPlayer.Follow();
                                                    break;

                                                case "19":
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
                                    string MM = Console.ReadLine();
                                    int mm = Convert.ToInt32(MM);
                                    Console.WriteLine("Ingrese su contraseña\n");
                                    string ññ = Console.ReadLine();
                                    Gate.LogAsTeacher(mm, ññ);
                                    if (Gate.LogAsTeacher(mm, ññ))
                                    {
                                        string switcherad = "0";
                                        string stopperad = "20";
                                        while (switcherad != stopperad)
                                        {
                                            Console.WriteLine("Si desea:\n\t(1)Buscar por videos\n\t(2)Buscar por canciones\n\t(3)Buscar por series\n\t(4)Buscar por playlist\n\t(5)Reproducir por videos\n\t(6)Reproducir por cancion\n\t(7)Reproducir por series\n\t(8)Reproducir por playlist\n\t(9)Importar cancion\n\t(10)Importar video\n\t(11)Remover cacnion\n\t(12)Remover video\n\t(13)Descargar cancion/video\n\t(14)Añadir archivo a curso\n\t(15)Eliminar archivos del curso\n\t(16)Hacer una PlayList de canciones\n\t(17)Añadir a la cola\n\t(18)Seguir a otro usuario\n\t(19)salir de la busqueda\n");
                                            switcherad = Console.ReadLine();

                                            switch (switcherad)
                                            {
                                                case "1": //buscar y reproducir videos
                                                    mediaPlayer.Search("1");
                                                    int variable1 = mediaPlayer.Search("1");
                                                    if (variable1 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.videos[variable1].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "2": //buscar y reproducir canciones
                                                    mediaPlayer.Search("2");
                                                    int variable2 = mediaPlayer.Search("2");
                                                    if (variable2 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.songs[variable2].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "3": //buscar y reproducir series
                                                    mediaPlayer.Search("3");
                                                    int variable3 = mediaPlayer.Search("3");
                                                    if (variable3 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.series[variable3].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "4": // buscar y reproducir playlist
                                                    mediaPlayer.Search("4");
                                                    int variable4 = mediaPlayer.Search("4");
                                                    if (variable4 == -1) break;
                                                    else
                                                    {
                                                        mediaPlayer.Play(mediaPlayer.playlists[variable4].Route);
                                                    }
                                                    //por aqui deberia estar la opcion de pausar y stop
                                                    break;
                                                case "5": //mostrar videos
                                                    mediaPlayer.ShowVideos();
                                                    break;
                                                case "6": //mostrar canciones
                                                    mediaPlayer.ShowSongs();
                                                    break;
                                                case "7": //mostrar series
                                                    mediaPlayer.ShowSeries();
                                                    break;
                                                case "8": //mostrar playlist
                                                    mediaPlayer.ShowPlaylists();
                                                    break;
                                                case "9": //importar canciones
                                                    admin.Import(song, mediaPlayer);
                                                    break;
                                                case "10": //importar videos
                                                    admin.Import(video, mediaPlayer);
                                                    break;
                                                case "11": //remover canciones
                                                    admin.Remove(song, mediaPlayer);
                                                    break;
                                                case "12": //remover videos
                                                    admin.Remove(video, mediaPlayer);
                                                    break;
                                                case "13": //descargar
                                                    mediaPlayer.Download();
                                                    break;
                                                case "14": //añadir archivos al curso 
                                                    teacher.Add(MediaFile,course);
                                                    break;
                                                case "15": //eliminar archivos de curso
                                                    teacher.Delete(MediaFile, course);
                                                    break;
                                                case "16": //crear playlist
                                                    mediaPlayer.CreatePlaylist();
                                                    break;
                                                case "17": //añadir a la fila
                                                    mediaPlayer.AddToQueue(mediaPlayer.Songs);
                                                    break;
                                                case "18": //seguir usuarios
                                                    mediaPlayer.Follow();
                                                    break;

                                                case "19":
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
                        break;
                    case "4":
                        break;
                    case "5":
                        break;

                default:
                        Console.WriteLine("Ingrese una opcion valida");
                break;
                }

            }
            
            
            
        }
    }
}
