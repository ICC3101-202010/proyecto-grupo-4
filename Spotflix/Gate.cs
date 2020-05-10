using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Spotflix
{
    public class Gate
    {
        private static List<User> users = new List<User>();
        private static List<Admin> managers = new List<Admin>();
        private static List<Teacher> teachers = new List<Teacher>();
        private static List<int> states = new List<int>(); //State es el segundo donde el usuario cuyo index corresponde al de su int quedo
        public static bool checkUsername(string userName)
        {
            if (users.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (User user_T in users)
                {
                    if (user_T.Nickname == userName)
                    {
                        Console.WriteLine("El nombre de usuario {0} ya esta en uso\n", userName);
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
        public static bool checkGmail(string gmail)
        {
            if (users.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (User user_T in users)
                {
                    if (user_T.Gmail == gmail)
                    {
                        Console.WriteLine("El mail {0} ya esta en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }//True si es valido False si ya existe
        public static bool checkCodeA(string code)
        {
            if (managers.Count() == 0)
            {
                return true;
            }
            foreach (Admin manager_T in managers)
            {
                if (manager_T.Code == code)
                {
                    Console.WriteLine("El Administrador con este codigo ya existe\n");
                    return false;
                }

            }
            return true;
        }//True si es valido False si ya existe
        public static bool checkCodeP(string code)
        {
            if (teachers.Count() == 0)
            {
                return true;
            }
            foreach (Teacher teacher_T in teachers)
            {
                if (teacher_T.Code == code)
                {
                    Console.WriteLine("El Profesor con este codigo ya existe\n");
                    return false;
                }
            }
            return true;
        }
        public static void SingUser(User user)//listo
        {
            users.Add(user);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }
        public static void SingAdmin(Admin manager) //Listo
        {
            managers.Add(manager);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }
        public static void SingTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }
        public static bool LogAsUser(string email_nickname, string password) //listo
        {
            if (users.Count() == 0)
            {
                Console.WriteLine("No existen usuarios registrado con esas caracteristicas\n");
                return false;
            }
            else
            {
                foreach (User user in users)
                {
                    if ((user.Nickname == email_nickname || user.Gmail == email_nickname) && user.Password == password)
                    {
                        return true;
                    }
                }
                Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
                return false;
            }
        }
        public static bool LogAsAdmin(string code, string password) //listo
        {
            if (managers.Count() == 0)
            {
                Console.WriteLine("No hay ningun administrador registrado con esas caracteristicas\n");
                return false;
            }
            foreach (Admin manager in managers)
            {
                if (manager.Code == code && manager.Pass == password)
                {
                    return true;
                }
            }
            Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
            return false;
        }
        public static bool LogAsTeacher(string code, string password) //listo
        {
            if (teachers.Count() == 0)
            {
                Console.WriteLine("No hay ningun profesor registrado con esas caracteristicas\n");
                return false;
            }
            foreach (Teacher teacher in teachers)
            {
                if (teacher.Code == code && teacher.Passw == password)
                {
                    return true;
                }
            }
            Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
            return false;
        }

        //Metodos Serializar:
        static private void SaveUser(List<User> users)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoUsuarios", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, users);
            stream.Close();
        }

        static private List<User> LoadUser()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoUsuarios", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<User> users = (List<User>)formatter.Deserialize(stream);
            stream.Close();
            return users;
        }
        static private void SaveAdmin(List<Admin> managers)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAdministradores", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, managers);
            stream.Close();
        }

        static private List<Admin> LoadAdmin()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoAdministradores", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Admin> managers = (List<Admin>)formatter.Deserialize(stream);
            stream.Close();
            return managers;
        }
        static private void SaveTeacher(List<Teacher> teachers)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivosProfesores", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, teachers);
            stream.Close();
        }

        static private List<Teacher> LoadTeacher()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("ArchivoProfesores", FileMode.Open, FileAccess.Read, FileShare.Read);
            List<Teacher> teachers = (List<Teacher>)formatter.Deserialize(stream);
            stream.Close();
            return teachers;
        }
    }
}
