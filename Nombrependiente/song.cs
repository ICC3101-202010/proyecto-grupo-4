using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Song : MediaFile
    {
        private string artist;
        private string album;
        private bool expliciT;
        private int currentSecond;

        public Song(string artist, string album, bool expliciT, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image)
        {
            this.artist = artist;
            this.album = album;
            this.expliciT = expliciT;
            this.currentSecond = currentSecond;
            this.length = length;
            this.fileSize = fileSize;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.category = category;
            this.numberOfReproductions = numberOfReproductions;
            this.rankings = rankings;
            this.mediaId = mediaId;
            this.relations = relations;
            this.qualification = qualification;
            this.quality = quality;
            this.dimension = dimension;
            this.image = image;
        }
        //Constructor
        public string Artist { get => artist; set => artist = value; }
        public string Album { get => album; set => album = value; }
        public bool ExpliciT { get => expliciT; set => expliciT = value; }
        public int CurrentSecond { get => currentSecond; set => currentSecond = value; }
        public int Length { get => length; set => length = value; }
        public int FileSize { get => fileSize; set => fileSize = value; }
        public string Name { get => name; set => name = value; }
        public string Gender { get => gender; set => gender = value; }
        public int Year { get => year; set => year = value; }
        public string Category { get => category; set => category = value; }
        public int NumberOfReproductions { get => numberOfReproductions; set => numberOfReproductions = value; }
        public List<int> Rankings { get => rankings; set => rankings = value; }
        public int MediaId { get => mediaId; set => mediaId = value; }
        public string Relations { get => relations; set => relations = value; }
        public List<int> Qualification { get => qualification; set => qualification = value; }
        public string Quality { get => quality; set => quality = value; }
        public string Dimension { get => dimension; set => dimension = value; }
        public object Image { get => image; set => image = value; }
        //Setters and getters
        public Song Downnload(Song song)
        {
            return song; 
        }
    }
}
