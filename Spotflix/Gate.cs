using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                        foreach(User u in users)
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
                        string nuevocodigo = Console.ReadLine();
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
        public static void ChangeAdmin()
        {
            Console.WriteLine("Ingrese su antiguo nombre");
            string antoguonombre = Console.ReadLine();

            foreach (Admin a in managers)
            {
                if (a.Namea == antoguonombre)
                {
                    Console.WriteLine("Ingrese su nuevo nombre");
                    string nuevonombre = Console.ReadLine();
                    foreach (Admin b in managers)
                    {
                        if (b.Namea == nuevonombre)
                        {
                            Console.WriteLine("Ese nombre ya esta utilizado");
                        }
                        else
                        {
                            b.Namea = nuevonombre;
                        }
                    }
                }   
            }
        }
        /*
        public static void ChangeTeacher()
        {
            string switu = "0";
            string stopu = "4";
            while (switu != stopu)
            {
                Console.WriteLine("Desea cambiar:\n\t(1)Su nombre de usuario\n\t(2)Su apellido\n\t(3)Su curso\n\t(4)Actualizar");
                string opcion = Console.ReadLine();
                Console.Clear();
                switch (switu)
                {
                    case "1"://Nickname
                        Console.WriteLine("Ingrese su nuevo nombre de usuario");
                        string nuevonusuariot = Console.ReadLine();
                        foreach (Teacher t in teachers)
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
                    case "2": //LastName
                        Console.WriteLine("Ingrese su nuevo apellido");
                        string nuevoapellidot = Console.ReadLine();
                        t.Lastname = nuevoapellidot;
                        break;
                    case "3": //Age int
                        Console.WriteLine("Ingrese su nuevo curso");
                        string nuevocurso = Console.ReadLine();
                        int nuevoCurso = Convert.ToInt32(nuevocurso);
                        t.Course = nuevoCurso;
                        break;
                    case "4":
                        Console.WriteLine("Se ha actualizado correctamente");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }*/
    }
}
