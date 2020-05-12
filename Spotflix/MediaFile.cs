using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
    public abstract class MediaFile
    {
        //Atributes
        protected TimeSpan length;
        protected long fileSize;
        protected string name;
        protected string gender;
        protected int year;
        protected int numberOfReproductions=0;
        protected List<int> rankings = new List<int>(); //Ranking en el que se encuentre
        protected int mediaId;
        protected List<int> qualification = new List<int>(); //Calificación (1-5)
        protected string quality;
        protected int dimension;
        protected object image;
        protected string route;
        protected int currentSecond=0;
        private int likes = 0;

        public string Route { get => route; set => route = value; }
        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }
        public TimeSpan Length { get => length; set => length = value; }
        public long FileSize { get => fileSize; set => fileSize = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Year { get => year; set => year = value; }
        public int NumberOfReproductions { get => numberOfReproductions; set => numberOfReproductions = value; }
        public List<int> Rankings { get => rankings; set => rankings = value; }
        public int MediaId { get => mediaId; set => mediaId = value; }
        public List<int> Qualification { get => qualification; set => qualification = value; }
        public string Quality { get => quality; set => quality = value; }
        public int Dimension { get => dimension; set => dimension = value; }
        public object Image { get => image; set => image = value; }
        public int Likes { get => likes; set => likes = value; }
    }
}
