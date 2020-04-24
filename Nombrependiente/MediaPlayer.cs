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

        public static bool SingUser(User user)
        {
            foreach (User user_T in Users)
            {
                if (user_T.Nickname==user.Nickname || user_T.Gmail==user.Gmail)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
