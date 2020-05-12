using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
    public class Series
    {
        private int nofVideos;
        private string serieName;
        private List<Video> episodes = new List<Video>();

        public Series(int nofVideos, List<Video> episodes, string serieName)
        {
            this.nofVideos = nofVideos;
            this.episodes = episodes;
            this.serieName = serieName;
        }
        public Series() { }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }
        public string SerieName { get => serieName; set => serieName = value; }

        public Series ShowSerie()
        {
            int choice = 0;
            int choice2 = 0;
            if (episodes.Count() > 0)
            {

                foreach (Video v in episodes)
                {
                    Console.WriteLine("{0}: {1}-{2}-{3}\n", episodes.IndexOf(v) + 1, v.Name, v.Director, v.Gender);
                }

                Console.WriteLine($"¿Desea agregar esta serie o desea ver más opciones\n(1) Agregar serie {serieName}\n(2) Ver más series");

                while (choice2 == 0)
                {
                    try
                    {
                        choice2 = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ingrese un numero para seleccionar su decisión\n");
                    }
                }
                try
                {
                    if (choice2 == 1)
                    {
                        return this;
                    }

                    else return null;

                }
                catch (ArgumentOutOfRangeException)
                {
                    if (choice == -1)
                    {
                        return null;
                    }
                    Console.WriteLine("Seleccione una opción  dentro del rango o ingrese -1 para salir\n");
                }
                return null;

            }
            else
            {
                Console.WriteLine("No se encontraron capítulos en la serie");
                return null;
            }

        }
    }


    
}
