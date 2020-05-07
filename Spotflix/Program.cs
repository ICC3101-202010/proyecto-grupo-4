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
            while (true)
            {
                Console.WriteLine("\nSi desdea registrarse presione a\n");
                Console.WriteLine("Si desea iniciar sesion presione b\n");

                Console.WriteLine("\nSi desea cerrar el programa presione z\n");
                string answer = Console.ReadLine();

                if (answer.ToLower()=="a")
                {
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
                        Random rnds = new Random();
                        int nume = rnds.Next(1,1000);
                        User u1 = new User(nume, gm, nic, h, member, a, b, c, d, e, f, g);
                        Gate.SingUser(u1);
                    }
                    if (res.ToLower() == "admin")
                    {
                        Random rnds = new Random();
                        int code = rnds.Next(10000, 100000);
                        Admin a1 = new Admin(code);
                        Gate.SingAdmin(a1);
                    }
                }
                if (answer.ToLower() == "b")
                {
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
                }

                if (answer.ToLower()=="z")
                {
                    break;
                }
            }
        }
    }
}
