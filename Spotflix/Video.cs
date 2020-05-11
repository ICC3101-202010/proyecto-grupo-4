using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Video : MediaFile,IGo
    {
        protected int ageFilter;
        protected string director;
        protected string synopsis;
        private string studio;
        protected List<string> actors = new List<string>();

        public Video(List<string> actors, int ageFilter, string director, string synopsis, string studio,int fileSize, string name, string gender,object image, int year, string relations, List<int> qualification, string route)
        {
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.synopsis = synopsis;
            this.Studio  = studio;
            this.fileSize = fileSize;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.image = image;
            this.qualification = qualification;
            this.route = route;
        }


        public List<string> Actors { get => actors; set => actors = value; }
        public int AgeFilter { get => ageFilter; set => ageFilter = value; }
        public string Director { get => director; set => director = value; }
        public string Synopsis { get => synopsis; set => synopsis = value; }
        public string Studio { get => studio; set => studio = value; }

        //Métodos herdados de IGo

        public void Gofowards(int seconds) //Método no listo
        {
            Console.WriteLine($"Adelantando video {seconds} segundos");
        }

        public void GoBackwards(int seconds) //Método no listo
        {
            Console.WriteLine($"Retrocediendo video {seconds} segundos");
        }

        public void ChangeQuality(string quality) //Método no listo
        {
            Console.WriteLine($"Cambiando a la calidad del video a: {quality}");
        }
    }
}