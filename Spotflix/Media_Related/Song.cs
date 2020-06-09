using System;
using System.Drawing;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Song : MediaFile
    {
        protected string artist;
        protected string album;
        protected bool expliciT;

        //Constructor
        public Song()
        {

        }

        public Song(string artist, string album, bool expliciT, string name, string genre, int year, Image image, byte[] bytes,TimeSpan lenght,long size, int code)
        {
            this.code = code;
            this.artist = artist;
            this.album = album;
            this.expliciT = expliciT;
            this.name = name;
            this.genre = genre;
            this.year = year;
            this.Image = image;
            this.bytes = bytes;
            this.length = lenght;
            this.fileSize = size;
            this.Letter = "S";
        }

        //Setters and getters
        public string Artist { get => artist; set => artist = value; }
        public string Album { get => album; set => album = value; }
        public bool ExpliciT { get => expliciT; set => expliciT = value; }

    }
}
