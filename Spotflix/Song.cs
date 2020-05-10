using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Song : MediaFile, IGo
    {
        protected string artist;
        protected string album;
        protected bool expliciT;
        protected new object image = null;

        //Constructor
        public Song(string artist, string album, bool expliciT, string name, string gender, int year,  object image, string route)
        {
            this.artist = artist;
            this.album = album;
            this.expliciT = expliciT;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.image = image;
            this.route = route;
        }

        //Setters and getters
        public string Artist { get => artist; set => artist = value; }
        public string Album { get => album; set => album = value; }
        public bool ExpliciT { get => expliciT; set => expliciT = value; }


        //Métodos herdados de IGo 
        public void Gofowards(int seconds) //Método no listo
        {
            Console.WriteLine($"Adelantando la canción {seconds} segundos");
        }

        public void GoBackwards(int seconds) //Método no listo
        {
            Console.WriteLine($"Retrocediendo la canción {seconds} segundos");
        }

        public void ChangeQuality(string quality) //Método no listo
        {
            Console.WriteLine($"Cambiando la calidad de la canción a: {quality}");
        }
    }
}
