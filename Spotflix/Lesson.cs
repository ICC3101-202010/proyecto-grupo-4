using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Lesson 
    {
        private string name;
        private string course; //PK,K,1-8,I,II,II,IV
        private string subject;
        private List<Video> lessons = new List<Video>();
        private Teacher teacher;
        private int currentSecond;

        public Lesson(string name, string subject, string course, int currentSecond, List<Video> lessons, Teacher teacher)
        {
            this.name = name;
            this.course = course;
            this.subject = subject;
            this.currentSecond = currentSecond;
            this.lessons = lessons;
            this.teacher = teacher;
        }
        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }

        public string Course { get => course; set => course = value; }
        public List<Video> Lessons { get => lessons; set => lessons = value; }
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Name { get => name; set => name = value; }

        public void Add(Video lesson)
          {
              int counter = 0;
              foreach(Video l in lessons)
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

          public void Delete(Video lesson)
          {
              foreach (Video l in lessons)
              {
                  if (l == lesson)
                  {
                      lessons.Remove(lesson);
                      Console.WriteLine($"Se ha eliminado la clase {lesson.Name}");
                  }
              }
          }
    }
}