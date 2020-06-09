using System;
using System.Collections.Generic;
using System.Drawing;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Karaoke : Song
    {
        List<string> lyrics = new List<string>();

        public Karaoke(List<string> lyrics, string artist, string album, bool expliciT, string name, string genre, int year, Image image, byte[] bytes,TimeSpan lenght,long size, int code) : base(artist,album,expliciT, name, genre,year,image, bytes,lenght,size,code)
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
            this.Lyrics = lyrics;
            this.code = code;
            this.Letter = "K";
        }

        public List<string> Lyrics { get => lyrics; set => lyrics = value; }
    }
}
