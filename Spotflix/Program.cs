using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Program
    {
        static void Main(string[] args)     
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            int num = 1;
            int code = 1000;
            string switcher = "0";
            string stopper = "7";

            while (switcher != stopper)
            {
                Console.WriteLine("Si desea:\n\t(1)Registrarse\n\t(2)Iniciar Sesion\n\t(5)salir de la busqueda\n");
                switcher = Console.ReadLine();

                switch (switcher)
                {
                    case "1":
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
                        Console.WriteLine("\n¿Desea ser user o admin?\n");
                        string res = Console.ReadLine();
                        if (res.ToLower() == "user")
                        {
                            Console.WriteLine("\nIngrese su Gmail\n");
                            string gm = Console.ReadLine();
                            Console.WriteLine("\nIngrese su nombre de usuario\n");
                            string nic = Console.ReadLine();
                            Console.WriteLine("\n¿Desea utilizar el programa gratiuto o pagado?\n");
                            string member = Console.ReadLine();

                            User u1 = new User(num, gm, nic, h, member, a, b, c, d, e, f, g);
                            Gate.SingUser(u1);
                            num++;
                        }
                        if (res.ToLower() == "admin")
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
                                Gate.SingAdmin(t1);
                                code++;
                            }
                        }
                        break;
                    case "2":                   
                        Console.WriteLine("Si es admin ingrese ad, si es user ingrese us\n");
                        string o = Console.ReadLine();
                        if (o.ToLower() == "us")
                        {
                            Console.WriteLine("Ingrese su nombre de usuario o Gmail\n");
                            string n = Console.ReadLine();
                            Console.WriteLine("Ingrese su contraseña\n");
                            string p = Console.ReadLine();
                            Gate.LogAsUser(n, p);
                        }
                        if (o.ToLower() == "ad")
                        {
                            Console.WriteLine("Ingrese su codigo de admin\n");
                            string NN = Console.ReadLine();
                            int nn = Convert.ToInt32(NN);
                            Console.WriteLine("Ingrese su contraseña\n");
                            string pp = Console.ReadLine();
                            Gate.LogAsAdmin(nn, pp);
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
