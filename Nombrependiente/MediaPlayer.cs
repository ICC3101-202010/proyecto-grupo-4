using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public static class MediaPlayer
    {
        private static List<Song> songs = new List<Song>();
        private static List<Video> videos = new List<Video>();
        private static List<Lesson> lessons = new List<Lesson>();
        private static List<User> users = new List<User>();
        private static List<Manager> managers = new List<Manager>();
        private static List<int> states = new List<int>(); //State es el segundo donde el usuario cuyo index corresponde al de su int quedo
        public static List<Song> Songs { get => songs; set => songs = value; }
        public static List<Video> Videos { get => videos; set => videos = value; }
        public static List<Lesson> Lessons { get => lessons; set => lessons = value; }
        public static List<User> Users { get => users; set => users = value; }
        public static List<Manager> Managers { get => managers; set => managers = value; }
        public static List<int> States { get => states; set => states = value; }

        public static bool SingUser(User user)//listo
        {
            if (users.Count() == 0)
            {
                users.Append(user);
                return true;
            }
            foreach (User user_T in Users)
            {
                if (user_T.Nickname == user.Nickname)
                {
                    Console.WriteLine("El nombre de usuario {0} ya esta en uso\n", user.Nickname);
                    return false;
                }
                else if (user_T.Gmail == user.Gmail)
                {
                    Console.WriteLine("El Email {0} ya esta en uso\n", user.Gmail);
                    return false;
                }
            }
            users.Add(user);
            return true;
        }
        public static bool SingAdmin(Manager manager) //Listo
        {
            if (managers.Count()==0)
            {
                managers.Append(manager);
                return true;
            }
            foreach (Manager manager_T in managers)
            {
                if (manager_T.Code == manager.Code)
                {
                    Console.WriteLine("El Administrador con este codigo ya existe\n");
                    return false;
                }
            }
            managers.Add(manager);
            return true;
            
        }
        public static bool LogAsUser(string email_nickname, string password) //listo
        {
            if (users.Count()==0)
            {
                Console.WriteLine("No existen usuarios registrados\n");
                return false;
            }
            foreach (User user in Users)
            {
                if ((user.Nickname==email_nickname||user.Gmail==email_nickname) && user.Password==password)
                {
                    return true;
                }
            }
            Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
            return false;
        }
        public static bool LogAsAdmin(int code, string password) //listo
        {
            if (managers.Count()==0)
            {
                Console.WriteLine("No hay ningun administrador registrado\n");
                return false;
            }
            foreach (Manager manager in managers)
            {
                if (manager.Code==code&&manager.Password==password)
                {
                    return true;
                }
            }
            Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
            return false;
        }
        public static void SaveInfo() //Pendiente
        {
            Console.WriteLine("Este metodo se supone que guarda el tiempo en el que el usuario cerro (Deberia escuchar a un evento de close)\n");
        }
        public static void Loadinfo() //Pendiente
        {
            Console.WriteLine("Este metodo se supone que carga el tiempo donde el usuario termino cerrando la cancion/video (Deberia escuchar a un evento de Log in as User)\n");
        }
        public static void CreateRecommendedList()
        {
            Console.WriteLine("Metodo muy dificil pa pensarlo ahora\n");
        }

        public static void Play(Song song)
        {
            foreach (Song song_T in songs)
            {
                if (song.MediaId == song_T.MediaId)
                {
                    Console.WriteLine("Este metodo reproduce una cancion\n");
                }
            }  
        }
        public static void Play(Video video)
        {
            foreach (Video video_T in videos)
            {
                if (video.MediaId == video_T.MediaId)
                {
                    Console.WriteLine("Este metodo reproduce un video\n");
                }
            }
        }

        public static void Stop(Song song)
        {
            foreach (Song song_T in songs)
            {
                if (song.MediaId == song_T.MediaId)
                {
                    Console.WriteLine("Este metodo para las canciones y las parte desde 0\n");
                }
            }
            
        }

        public static void Stop(Video video)
        {
            foreach (Video video_T in videos)
            {
                if (video.MediaId == video_T.MediaId)
                {
                    Console.WriteLine("Este metodo para los videos y las parte desde 0\n");
                }
            }
            
        }
        public static void Pause(Song song)
        {
            foreach (Song song_T in songs)
            {
                if (song.MediaId == song_T.MediaId)
                {
                    Console.WriteLine("Este metodo le pone pausa a las canciones\n");
                }
            }
        }
        public static void Pause(Video video)
        {
            foreach (Video video_T in videos)
            {
                if (video.MediaId == video_T.MediaId)
                {
                    Console.WriteLine("Este metodo le pone pausa a los videos\n");
                }
            }
        }



        public static MediaFile Search(List<string> filters, bool condition)
        {
            throw new NotImplementedException();
        }

        public static void CreatePlaylist(List<Song> songs)
        {
            throw new NotImplementedException();
        }

        public static void CreatePlaylist(List<Video> videos)
        {
            throw new NotImplementedException();
        }

        public static void AddToQueue(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public static void Qualify(int qualification)
        {
            throw new NotImplementedException();
        }

        public static double GetQualification()
        {
            throw new NotImplementedException();
        }

        public static object[] GetMetadata(MediaFile mediafile)
        {
            throw new NotImplementedException();
        }

        public static List<string> GetPlataformInformation()
        {
            throw new NotImplementedException();
        }

        public static List<string> GetIntrinsicInformation()
        {
            throw new NotImplementedException();
        }

        public static void Follow(MediaPlayer mediaplayer)
        {
            throw new NotImplementedException();
        }
    }


    /*public int GenderSearch(List<string> genders)
    {
        int count = 0;
        foreach (Song song in Songs)
        {
            foreach (string gender in genders)
            {
                if (song.Gender == gender)
                {
                    count += 1;
                }
            }
        }
        Console.WriteLine($"Se han encontrado {count} canciones de ese género");
        return count;
    }
    public int ArtistSearch(List<string> artists)
    {
        int count = 0;
        foreach (Song song in Songs)
        {
            foreach (string artist in artists)
            {
                if (song.Artist == artist)
                {
                    count += 1;
                }
            }
        }
        Console.WriteLine($"Se han encontrado {count} canciones de ese artista");
        return count;
    }
    */

}
