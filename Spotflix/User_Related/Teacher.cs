using Microsoft.WindowsAPICodePack.Shell;
using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using Spotflix.Media_Related;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;

namespace Spotflix.User_Related
{
    [Serializable]
    public class Teacher : Person
    {

        private List<string> courses = new List<string>(); //Una profesora puede tener distintos cursos
        private List<string> subjects = new List<string>(); //Una profesora puede tener distintas asignaturas
        private string code; //Teacher2020
        private string gmail;
        private string nickname;
        int teacherID;
        private List<Lesson> lessons = new List<Lesson>();

        public Teacher() { }


        public Teacher(int teacherID, string nickname, string name, string lastname, string gmail, string code, List<string> courses, string password, int age, List<string> subjects)
        {
            this.nickname = nickname;
            this.name = name;
            this.lastname = lastname;
            this.gmail = gmail;
            this.code = code;
            this.courses = courses;
            this.password = password;
            this.age = age;
            this.teacherID = teacherID;
            this.subjects = subjects;
        }


        public List<string> Course { get => courses; set => courses = value; }
        public string Code { get => code; set => code = value; }
        public string Gmail { get => gmail; set => gmail = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public List<Lesson> Lessons { get => lessons; set => lessons = value; }
        public int TeacherID { get => teacherID; set => teacherID = value; }
        public List<string> Subjects { get => subjects; set => subjects = value; }

        public static Video ImportVideoT(string path, string subject, string course, MediaPlayer media)
        {
            byte[] bytes = File.ReadAllBytes(path);
            TagLib.File file = TagLib.File.Create(path);
            var ffProbe = new NReco.VideoInfo.FFProbe();
            ffProbe.IncludeFormat = true;
            var videoinfo = ffProbe.GetMediaInfo(path);
            Video video = new Video(subject, course, media.Lesson.Count() + 1);
            media.Lesson.Add(video);
            return video;

        }
        public static Lesson ImportLesson(string lessonname, string subject, string course, int num, Video vid, Teacher t, byte[] ruta, string pdf)
        {
            Lesson lesson = new Lesson(lessonname, subject, course, 0, vid, t, ruta, pdf);
            t.Lessons.Add(lesson);
            return lesson;
        }
    }
}
