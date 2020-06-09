using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace Spotflix
{
    public class Gate
    {
        private static List<User> users = new List<User>();
        
        private static List<Teacher> teachers = new List<Teacher>();

        private static List<Student> students = new List<Student>();

        private static List<int> states = new List<int>(); //State es el segundo donde el usuario cuyo index corresponde al de su int quedo
        private static HashSet<User> foundusers = new HashSet<User>();
        private static HashSet<Teacher> foundteachers = new HashSet<Teacher>();
        private static HashSet<Student> foundstudents = new HashSet<Student>();

        public static List<User> Users { get => users; set => users = value; }
        public static List<Teacher> Teachers { get => teachers; set => teachers = value; }
        public static List<Student> Students { get => students; set => students = value; }
        public static HashSet<User> Foundusers { get => foundusers; set => foundusers = value; }
        public static HashSet<Teacher> Foundteachers { get => foundteachers; set => foundteachers = value; }
        public static HashSet<Student> Foundstudents { get => foundstudents; set => foundstudents = value; }

        public static List<User> Retornar()
        {
            return Users;
        }
        public static List<Teacher> RetornarTeacher()
        {
            return Teachers;
        }
        public static List<Student> RetornarStudent()
        {
            return Students;
        }

        public static bool checkUsername(string userName)
        {
            if (Users.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (User user_T in Users)
                {
                    if (user_T.Nickname == userName)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
            }
            return true;
        }//True si es valido False si ya existe
        public static bool CheckGmail(string gmail)
        {
            if (Users.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (User user_T in Users)
                {
                    if (user_T.Gmail == gmail)
                    {
                        return false;
                    }
                }
            }
            return true;
        }//True si es valido False si ya existe


        public static void SingUser(User user)//listo
        {
            Users.Add(user);
        }

        public static User LogAsUser(string email_nickname, string password) //listo
        {
            if (Users.Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (User user in Users)
                {
                    if ((user.Nickname == email_nickname || user.Gmail == email_nickname) && user.Password == password)
                    {
                        return user;
                    }
                }
                return null;
            }
        }

        public static Student LogAsStudent(string email_nickname, string password) //listo
        {
            if (students.Count() == 0)
            {
                return null;
            }
            else
            {
                foreach (Student student in students)
                {
                    if ((student.Nickname == email_nickname || student.Gmail == email_nickname) && student.Password == password)
                    {
                        return student;
                    }
                }
                return null;
            }
        }

        public static Teacher LogAsTeacher(string email_nickname, string password) //listo
        {
            if (Teachers.Count() == 0)
            {
                return null;
            }
            foreach (Teacher teacher in Teachers)
            {
                if ((teacher.Nickname == email_nickname || teacher.Gmail==email_nickname) && teacher.Password == password)
                {
                    return teacher;
                }
            }
            return null;
        }

        public static bool ChangePassword(string usr, string pswd, string newPsswd)
        {
            User user = LogAsUser(usr, pswd);
            if (user != null)
            {
                ChangePassword2(usr, newPsswd);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ChangePassword2(string usr, string newpsswd)
        {
            foreach (User user in Users)
            {
                if (user.Nickname == usr)
                {
                    user.Password = newpsswd;
                }
            }
        }

        public static bool ChangeNickName(string usr, string pswd, string newNick)
        {
            User user = LogAsUser(usr, pswd);
            if (user != null)
            {
                foreach (User us in Users)
                {
                    if(us.Nickname == newNick)
                    {
                        return false;
                    }
                }
                ChangeNickName2(usr, newNick);
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void ChangeNickName2(string usr, string newNick)
        {
            foreach (User user in Users)
            {
                if (user.Nickname == usr )
                {
                    user.Nickname = newNick;
                }
            }
        }

        public static bool ChangeMembership(string usr, string pswd)
        {
            User user = LogAsUser(usr, pswd);
            if (user != null)
            {
                foreach (User us in Users)
                {
                    if (us.MembershipType == "no pago")
                    {
                        us.MembershipType = "pago";
                        return true;
                    }
                    else if (us.MembershipType == "pago")
                    {
                        us.MembershipType = "no pago";
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
