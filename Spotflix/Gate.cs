using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms.VisualStyles;

namespace Spotflix
{
    public class Gate
    {
        private static List<User> users = new List<User>();
        private static List<Admin> managers = new List<Admin>();
        private static List<Teacher> teachers = new List<Teacher>();
        private static List<int> states = new List<int>(); //State es el segundo donde el usuario cuyo index corresponde al de su int quedo

        public static List<User> Users { get => users; set => users = value; }
        public static List<Admin> Managers { get => managers; set => managers = value; }
        public static List<Teacher> Teachers { get => teachers; set => teachers = value; }

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
                        Console.WriteLine("El nombre de usuario {0} ya está en uso\n", userName);
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
                        Console.WriteLine("El mail {0} ya está en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }//True si es valido False si ya existe
        public static bool checkUsernameA(string userName)
        {
            if (Managers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Admin admin_T in Managers)
                {
                    if (admin_T.Namea == userName)
                    {
                        Console.WriteLine("El nombre de usuario {0} ya está en uso\n", userName);
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
            if (Managers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Admin admin_T in Managers)
                {
                    if (admin_T.Gmaila == gmail)
                    {
                        Console.WriteLine("El mail {0} ya está en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool checkUsernameP(string userName)
        {
            if (Teachers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Teacher teacher_T in Teachers)
                {
                    if (teacher_T.Nickname == userName)
                    {
                        Console.WriteLine("El nombre de usuario {0} ya está en uso\n", userName);
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
            if (Teachers.Count() == 0)
            {
                return true;
            }
            else
            {
                foreach (Teacher teacher_T in Teachers)
                {
                    if (teacher_T.Gmail == gmail)
                    {
                        Console.WriteLine("El mail {0} ya está en uso\n", gmail);
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool CheckCodeA(string code)
        {
            if (Managers.Count() == 0)
            {
                return true;
            }
            foreach (Admin manager_T in Managers)
            {
                if (manager_T.Code == code)
                {
                    Console.WriteLine("El Administrador con este código ya existe\n"); //Parece que se puede sacar
                    return false;
                }

            }
            return true;
        }//True si es valido False si ya existe

        public static bool CheckCodeP(string code)
        {
            if (Teachers.Count() == 0)
            {
                return true;
            }
            foreach (Teacher teacher_T in Teachers)
            {
                if (teacher_T.Code == code)
                {
                    Console.WriteLine("El Profesor con este codigo ya existe\n"); //Parece que se puede sacar
                    return false;
                }
            }
            return true;
        }

        public static void SingUser(User user)//listo
        {
            Users.Add(user);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }

        public static void SingAdmin(Admin manager) //Listo
        {
            Managers.Add(manager);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }

        public static void SingTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
            Console.WriteLine("Se ha registrado correctamente!\n");
        }

        public static User LogAsUser(string email_nickname, string password) //listo
        {
            if (Users.Count() == 0)
            {
                Console.WriteLine("No existen usuarios registrado con esas caracteristicas\n");
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
                Console.WriteLine("Nombre de usuario o contraseña incorrecta\n");
                return null;
            }
        }

        public static bool LogAsAdmin(string code, string password) //listo
        {
            if (Managers.Count() == 0)
            {
                Console.WriteLine("No hay ningun administrador registrado con esas caracteristicas\n");
                return false;
            }
            foreach (Admin manager in Managers)
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
            if (Teachers.Count() == 0)
            {
                Console.WriteLine("No hay ningun profesor registrado con esas caracteristicas\n");
                return false;
            }
            foreach (Teacher teacher in Teachers)
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
            User user = LogAsUser(usr, pswd);
            if (user != null)
            {
                Console.Write("Ingrese la nueva contrasena: ");
                string newPsswd = Console.ReadLine();
                ChangePassword2(usr, newPsswd);
            }
            else
            {
                // Mostramos el error
                Console.WriteLine("[!] ERROR: No se logró cambiar la contraseña\n");
                Thread.Sleep(1000);
                Console.Clear();
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

        public static void MemberShip()
        {
            Console.WriteLine("Ingresa tu Gmail");
            string gm = Console.ReadLine();
            Console.WriteLine("Ingresa tu contraseña");
            string pas = Console.ReadLine();
            foreach(User um in Users)
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
            foreach (User um in Users)
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

        public static void ChangeProfile(User user)
        {
            string switu = "0";
            string stopu = "9";
            while(switu!=stopu)
            {
                Console.WriteLine("Desea cambiar:\n\t(1)Su nombre de usuario\n\t(2)Su nombre\n\t(3)Su apellido\n\t(4)Su edad\n\t(5)Su pais\n\t(6)Su ciudad\n\t(7)Su calle\n\t(8)Su codigo postal\n\t(9)Actualizar");
                string opcion = Console.ReadLine();
                Console.Clear();
                switch (switu)
                {
                    case "1"://Nickname
                        Console.WriteLine("Ingrese su nuevo nombre de usuario");
                        string nuevonusuario = Console.ReadLine();
                        foreach(User u in Users)
                        {
                            if (u.Nickname == nuevonusuario)
                            {
                                Console.WriteLine("Ese nombre de usuario ya está utilizado");
                            }
                            else
                            {
                                user.Nickname = nuevonusuario;
                            }
                        }
                        break;
                    case "2": //Name
                        Console.WriteLine("Ingrese su nuevo nombre");
                        string nuevoname = Console.ReadLine();
                        user.Name = nuevoname;
                        break;
                    case "3": //LastName
                        Console.WriteLine("Ingrese su nuevo apellido");
                        string nuevoapellido = Console.ReadLine();
                        user.Lastname = nuevoapellido;
                        break;
                    case "4": //Age int
                        Console.WriteLine("Ingrese su nueva edad");
                        string nuevaedad = Console.ReadLine();
                        int nuevaEdad = Convert.ToInt32(nuevaedad);
                        user.Age = nuevaEdad;
                        break;
                    case "5": //Country
                        Console.WriteLine("Ingrese su nuevo pais");
                        string nuevopais = Console.ReadLine();
                        user.Country = nuevopais;
                        break;
                    case "6": //City
                        Console.WriteLine("Ingrese su nueva ciudad");
                        string nuevaciudad = Console.ReadLine();
                        user.City = nuevaciudad;
                        break;
                    case "7": //Street
                        Console.WriteLine("Ingrese su nueva calle");
                        string nuevacalle = Console.ReadLine();
                        user.Street = nuevacalle;
                        break;
                    case "8": //Código Postal
                        Console.WriteLine("Ingrese su nuevo codigo postal");
                        int  nuevocodigo = int.Parse(Console.ReadLine());
                        user.PostalCode = nuevocodigo;
                        break;
                    case "9":
                        Console.WriteLine("Se ha actualizado correctamente");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }

        public static void ChangeTeacher(Teacher teacher)
        {
            string switu = "0";
            string stopu = "4";
            while (switu != stopu)
            {
                Console.WriteLine("Desea cambiar:\n\t(1)Su nombre de usuario\n\t(2)Su curso\n\t(3)Actualizar");
                switu = Console.ReadLine();
                switch (switu)
                {
                    case "1"://Nickname
                        Console.WriteLine("Ingrese su nuevo nombre de usuario");
                        string nuevonusuariot = Console.ReadLine();
                        foreach (Teacher t in Teachers)
                        {
                            if (t.Nickname == nuevonusuariot)
                            {
                                Console.WriteLine("Ese nombre de usuario ya está utilizado");
                            }
                            else
                            {
                                t.Nickname = nuevonusuariot;
                            }
                        }
                        break;
                    case "2": //Course
                        Console.WriteLine("Ingrese su nuevo curso(PK,K,1-8,I,II,II,IV)");
                        string nuevocurso = Console.ReadLine();
                        teacher.Course = nuevocurso;
                        break;
                    case "3":
                        Console.WriteLine("Se ha actualizado correctamente");
                        Thread.Sleep(1000);
                        Console.Clear();
                        switu = "4";
                        break;

                }
            }
        }
    }
}
