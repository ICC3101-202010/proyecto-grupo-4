using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Gate
    {
        private static List<User> users = new List<User>();
        private static List<Manager> managers = new List<Manager>();
        private static List<int> states = new List<int>(); //State es el segundo donde el usuario cuyo index corresponde al de su int quedo
        public static bool SingUser(User user)//listo
        {
            if (users.Count() == 0)
            {
                users.Append(user);
                return true;
            }
            foreach (User user_T in users)
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
            if (managers.Count() == 0)
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
            if (users.Count() == 0)
            {
                Console.WriteLine("No existen usuarios registrados\n");
                return false;
            }
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
        public static bool LogAsAdmin(int code, string password) //listo
        {
            if (managers.Count() == 0)
            {
                Console.WriteLine("No hay ningun administrador registrado\n");
                return false;
            }
            foreach (Manager manager in managers)
            {
                if (manager.Code == code && manager.Password == password)
                {
                    return true;
                }
            }
            Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
            return false;
        }
    }
}
