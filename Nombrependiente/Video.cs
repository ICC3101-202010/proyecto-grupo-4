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
        protected string studio;
        protected int currentSecond;
        protected List<string> actors = new List<string>();

        public Video(List<string> actors, int ageFilter, string director, string synopsis, string studio, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image)
        {
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.synopsis = synopsis;
            this.studio  = studio;
            this.currentSecond = currentSecond;
            this.length = length;
            this.fileSize = fileSize;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.category = category;
            this.numberOfReproductions = numberOfReproductions;
            this.rankings = rankings;
            this.mediaId = mediaId;
            this.relations = relations;
            this.qualification = qualification;
            this.quality = quality;
            this.dimension = dimension;
            this.image = image;
        }

        public List<string> Actors { get => actors; set => actors = value; }
        protected int AgeFilter { get => ageFilter; set => ageFilter = value; }
        protected string Director { get => director; set => director = value; }
        protected string Synopsis { get => synopsis; set => synopsis = value; }
        protected string Studio { get => studio; set => studio = value; }
        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }
        public int Length { get => length; set => length = value; }
        public int FileSize { get => fileSize; set => fileSize = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Year { get => year; set => year = value; }
        public string Category { get => category; set => category = value; }
        public int NumberOfReproductions { get => numberOfReproductions; set => numberOfReproductions = value; }
        public List<int> Rankings { get => rankings; set => rankings = value; }
        public int MediaId { get => mediaId; set => mediaId = value; }
        public string Relations { get => relations; set => relations = value; }
        public List<int> Qualification { get => qualification; set => qualification = value; }
        public string Quality { get => quality; set => quality = value; }
        public string Dimension { get => dimension; set => dimension = value; }
        public object Image { get => image; set => image = value; }

        public void Gofowards(int seconds) //Falta terminar este método
        {
            Console.WriteLine($"Adelantando video {seconds} segundos");
        }

        public void GoBackwards(int seconds) //Falta hacer este método
        {
            Console.WriteLine($"Retrocediendo video {seconds} segundos");
        }

        public void ChangeQuality(string quality) //Falta hacer este método
        {
            Console.WriteLine($"Cambiando a la calidad del video a: {quality}");
        }
    }
}