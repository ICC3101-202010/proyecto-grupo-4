using Spotflix.Media_Related;
using System;
using System.Collections.Generic;

namespace Spotflix.User_Related
{
    [Serializable]
    public class Student : Person
    {
        private int userID;
        private string gmail;
        private string nickname;
        private string curse;
        private List<string> subjects = new List<string>(); //Un alumno puede tener distintas asignaturas
        private string code; //Student2020
        private Lesson lastlesson;
        private int currentSec;
        private List<Lesson> likedLesson = new List<Lesson>();
        private List<Lesson> yourlesson = new List<Lesson>();



        private List<Lesson> downloadLesson = new List<Lesson>();
        private List<object> downloadHomeWork= new List<object>();
        private List<Teacher> followTeachers = new List<Teacher>();

        public Student() { }


        public Student(int userID, string gmail, string nickname, string password,  string name, string lastName, int age, string curse, List<string> subjects, string code)
        {
            this.userID = userID;
            this.Gmail = gmail;
            this.Nickname = nickname;
            this.Password = password;
            this.Name = name;
            this.Lastname = lastName;
            this.Age = age;
            this.curse = curse;
            this.subjects = subjects;
            this.code = code;
        }

        public int UserID { get => userID; set => userID = value; }
        public string Gmail { get => gmail; set => gmail = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public List<Teacher> FollowTeachers { get => followTeachers; set => followTeachers = value; }
        public List<Lesson> DownloadLesson { get => downloadLesson; set => downloadLesson = value; }
        public string Curse { get => curse; set => curse = value; }
        public List<string> Subjects { get => subjects; set => subjects = value; }
        public string Code { get => code; set => code = value; }
        public List<object> DownloadHomeWork { get => downloadHomeWork; set => downloadHomeWork = value; }
        public Lesson Lastlesson { get => lastlesson; set => lastlesson = value; }
        public int CurrentSec { get => currentSec; set => currentSec = value; }
        public List<Lesson> LikedLesson { get => likedLesson; set => likedLesson = value; }
        public List<Lesson> Yourlesson { get => yourlesson; set => yourlesson = value; }
    }
}