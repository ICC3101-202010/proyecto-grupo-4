using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Lesson : MediaFile, IOrderPlaylist
    {
        private int course;
        private List<Video> lessons = new List<Video>();
        private string manager;// = Manager; //Lo dejamos asi mientras
        private int currentSecond;

        public Lesson(int course,  string manager, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image)
        {
            this.course = course;
            this.manager = manager;
            this.currentSecond = currentSecond;
            this.length = length;
            this.fileSize = fileSize;
            this.name = name;
            this.gender = gender; //Corresponde a la asignatura
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
        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }
        public int Course { get => course; set => course = value; }
        public string Manager { get => manager; set => manager = value; }
        public List<Video> Lessons { get => lessons; set => lessons = value; }
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


        public void Add(Lesson lesson)
        {
            int counter = 0;
            foreach(Lesson l in lessons)
            {
                if (lesson == l)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                lessons.Add(lesson);
                Console.WriteLine($"Se ha agregado la clase {lesson.Name}");
            }
            else
            {
                Console.WriteLine("La clase ya se encuentra en sus clases. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí") lessons.Add(lesson);
            }
        }

        public void Delete(Lesson lesson)
        {
            foreach (Lesson l in lessons)
            {
                if (l == lesson)
                {
                    lessons.Remove(lesson);
                    Console.WriteLine($"Se ha eliminado la clase {lesson.Name}");
                }
            }
        }
        public void Next() //Falta hacer este método
        {
            Console.WriteLine("Pasando a la siguiente clase");
        }

        public void OrderAlphabet()
        {
            List<string> names = new List<string>();
            List<Lesson> newLessons = new List<Lesson>();
            foreach (Lesson lesson in lessons)
            {
                names.Add(lesson.Name);
            }
            names.Sort();

            foreach (Lesson lesson in lessons)
            {
                foreach (string name in names)
                {
                    if (lesson.Name == name)
                    {
                        newLessons.Add(lesson);
                    }
                }
            }
            lessons = newLessons;
            Console.WriteLine("Se han ordenado sus clases de acuerdo a los nombres.");
        }

        public void OrderByLength()
        {
            List<int> lenghts = new List<int>();
            List<Lesson> newLessons = new List<Lesson>();
            foreach (Lesson lesson in lessons)
            {
                lenghts.Add(lesson.Length);
            }
            lenghts.Sort();

            foreach (Lesson lesson in lessons)
            {
                foreach (int lenght in lenghts)
                {
                    if (lesson.Length == lenght)
                    {
                        newLessons.Add(lesson);
                    }
                }
            }
            lessons = newLessons;
            Console.WriteLine("Se han ordenado sus clases de acuerdo al largo.");
        }

        public void OrderPlaylist(MediaFile mediaFile, int posicion)//Falta hacer este método
        {
            //Dictionary<int,Song> newEpisodes = new Dictionary<int,Song>();
            Console.WriteLine("Ordenando de acuerdo a los parámetros entregados");
        }

        public void Previous() //Falta hacer este método
        {
            Console.WriteLine("Pasando al video anterior");
        }

    }
}