using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Lesson : MediaFile
    {
        private int course;
        private string subject;
        private List<Video> lessons = new List<Video>();
        private string manager;// = Manager; //Lo dejamos asi mientras
        public Lesson(int course, string subject, string manager)
        {
            this.course = course;
            this.subject = subject;
            this.manager = manager;
        }
        public int Course { get => course; set => course = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Manager { get => manager; set => manager = value; }
        public List<Video> Lessons { get => lessons; set => lessons = value; }
    }
}