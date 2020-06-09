using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Video : MediaFile
    {
        protected int ageFilter;
        protected string director;
        protected string synopsis;
        protected int chapter;
        protected string studio;
        protected string subject;
        protected string course;
        protected List<string> actors = new List<string>();


        public Video()
        {

        }
        public Video(List<string> actors, int ageFilter, string director, string studio, string name, string genre, Image image, int year, byte[] bytes, TimeSpan lenght, long size, int code)
        {
            this.code = code;
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.Studio = studio;
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.image = image;
            this.bytes = bytes;
            this.length = lenght;
            this.fileSize = size;
            this.Letter = "V";
        }
        public Video(List<string> actors, int ageFilter, string director, string studio, string name, string genre, int year, byte[] bytes, TimeSpan lenght, long size,int chapter,int code)
        {
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.Studio = studio;
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.bytes = bytes;
            this.length = lenght;
            this.fileSize = size;
            this.Chapter = chapter;
            this.code = code;
            this.Letter = "SV";
        }
        public Video(string subject, string course, int code)
        {
            this.subject = subject;
            this.course = course;
            this.code = code;
            this.Letter = "SV";
        }
        public List<string> Actors { get => actors; set => actors = value; }
        public int AgeFilter { get => ageFilter; set => ageFilter = value; }
        public string Director { get => director; set => director = value; }
        public string Synopsis { get => synopsis; set => synopsis = value; }
        public string Studio { get => studio; set => studio = value; }
        public int Chapter { get => chapter; set => chapter = value; }
        public string Subject { get => subject; set => subject = value; }
        public string Course { get => course; set => subject = value; }



    }
}
