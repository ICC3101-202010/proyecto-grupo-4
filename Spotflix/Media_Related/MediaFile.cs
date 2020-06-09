using System;
using System.Collections.Generic;
using System.Drawing;

namespace Spotflix.Media_Related
{
    [Serializable]
    public abstract class MediaFile
    {
        //Atributes
        protected TimeSpan length;
        protected long fileSize;
        protected string name;
        protected string genre;
        protected int year;
        protected int code;
        private string letter;
        protected int numberOfReproductions =0;
        protected List<int> qualification = new List<int>(); //Calificación (1-5)
        protected string dimension ;
        protected Image image;
        protected byte[] bytes;
        protected int likes = 0;
        public byte[] Bytes { get => bytes; set => bytes = value; }
        public TimeSpan Length { get => length; set => length = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
        public string Name { get => name; set => name = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Year { get => year; set => year = value; }
        public int NumberOfReproductions { get => numberOfReproductions; set => numberOfReproductions = value; }
        public List<int> Qualification { get => qualification; set => qualification = value; }
        public string Dimension { get => dimension; set => dimension = value; }
        public Image Image { get => image; set => image = value; }
        public int Likes { get => likes; set => likes = value; }
        public int Code { get => code; set => code = value; }
        public string Letter { get => letter; set => letter = value; }
    }
}
