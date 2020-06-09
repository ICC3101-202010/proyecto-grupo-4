using Spotflix.User_Related;
using System;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Lesson
    {
        private string name;
        private string course; //PK,K,1-8,I,II,II,IV
        private string subject;
        private Video lessons;
        private Teacher teacher;
        private string homeWork; //Path del PDF
        private int currentSecond;
        private byte[] bytes;


        public Lesson(string name, string subject, string course, int currentSecond, Video lessons, Teacher teacher, byte[] bytes, string homeWork)
        {
            this.name = name;
            this.course = course;
            this.subject = subject;
            this.currentSecond = currentSecond;
            this.lessons = lessons;
            this.teacher = teacher;
            this.bytes = bytes;
            this.homeWork = homeWork;
        }

        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }
        public string Course { get => course; set => course = value; }
        public Video Lessons { get => lessons; set => lessons = value; }
        public Teacher Teacher { get => teacher; set => teacher = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Name { get => name; set => name = value; }
        public string HomeWork { get => homeWork; set => homeWork = value; }
        public byte[] Bytes { get => bytes; set => bytes = value; }
    }
}
