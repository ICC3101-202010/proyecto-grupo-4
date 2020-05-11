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
        public static bool CheckGmail(string gmail)
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
        public static bool checkUsernameA(string userName)
        {
            if (managers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Admin admin_T in managers)
                {
                    if (admin_T.Namea == userName)
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
        public static bool CheckGmailA(string gmail)
        {
            if (managers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Admin admin_T in managers)
                {
                    if (admin_T.Gmaila == gmail)
                    {
                        Console.WriteLine("El mail {0} ya esta en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool checkUsernameP(string userName)
        {
            if (teachers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Teacher teacher_T in teachers)
                {
                    if (teacher_T.Nickname == userName)
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
        public static bool CheckGmailP(string gmail)
        {
            if (teachers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Teacher teacher_T in teachers)
                {
                    if (teacher_T.Gmail == gmail)
                    {
                        Console.WriteLine("El mail {0} ya esta en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckCodeA(string code)
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
        public static bool CheckCodeP(string code)
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

        public static void ChangePassword()
        {
            Console.WriteLine("Ingresa tu nombre de usuario: ");
            string usr = Console.ReadLine();
            Console.WriteLine("Ingresa tu contrasena: ");
            string pswd = Console.ReadLine();
            bool result = LogAsUser(usr, pswd);
            if (result == true)
            {
                Console.Write("Ingrese la nueva contrasena: ");
                string newPsswd = Console.ReadLine();
                ChangePassword2(usr, newPsswd);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: " + result + "\n");
            }
        }
       
        public static void ChangePassword2(string usr, string newpsswd)
        {
            foreach (User user in users)
            {
                if (user.Nickname == usr)
                {
                    user.Password = newpsswd;
                }
            }
        }

        public static void MemberShip()
        {
            Console.WriteLine("Ingresa tu Gmail");
            string gm = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña");
            string pas = Console.ReadLine();
            foreach(User um in users)
            {
                if(gm == um.Gmail && pas == um.Password)
                {
                    if (um.MembershipType == "no pago")
                    {
                        Console.WriteLine("Ingrese el numero de tarjeta de credito");
                        string tarjeta = Console.ReadLine();
                        Console.WriteLine("Ingrese la clave");
                        string clave = Console.ReadLine();
                        um.MembershipType = "pago";
                        Console.WriteLine("Usted ya es Premium y puede descargar canciones");
                    }
                    else { Console.WriteLine("Usted ya es Premium"); }
                }
                else { Console.WriteLine("Gmail o contraseña incorrecta"); }
            }
        }
        public static void NoMemberShip()
        {
            Console.WriteLine("Ingresa tu Gmail");
            string gm = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña");
            string pas = Console.ReadLine();
            foreach (User um in users)
            {
                if (gm == um.Gmail && pas == um.Password)
                {
                    if (um.MembershipType == "pago")
                    {
                        Console.WriteLine("Ingrese el numero de tarjeta de credito");
                        string tarjeta = Console.ReadLine();
                        Console.WriteLine("Ingrese la clave");
                        string clave = Console.ReadLine();
                        um.MembershipType = "no pago";
                        Console.WriteLine("Usted ya no es Premium y no puede descargar canciones");
                    }
                    else { Console.WriteLine("Usted no es Premium"); }
                }
                else { Console.WriteLine("Gmail o contraseña incorrecta"); }
            }
        }
    }
}
