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
        private Video lessons;
        private Teacher teacher;
        private int currentSecond;

        public Lesson(string name, string subject, string course, int currentSecond, Video lessons, Teacher teacher)
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
        public Video Lessons { get => lessons; set => lessons = value; }
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Name { get => name; set => name = value; }

        
    }
}