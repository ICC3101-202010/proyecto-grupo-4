﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Video : MediaFile,IGo
    {
        protected int ageFilter;
        protected string director;
        protected string synopsis;
        protected string studio;
        protected List<string> actors = new List<string>();

        public Video(List<string> actors, int ageFilter, string director, string synopsis, string studio, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image, string route)
        {
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.synopsis = synopsis;
            this.studio  = studio;
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
            this.route = route;
        }

        public List<string> Actors { get => actors; set => actors = value; }
        protected int AgeFilter { get => ageFilter; set => ageFilter = value; }
        protected string Director { get => director; set => director = value; }
        protected string Synopsis { get => synopsis; set => synopsis = value; }
        protected string Studio { get => studio; set => studio = value; }

        //Métodos herdados de IGo

        public void Gofowards(int seconds) //Método no listo
        {
            Console.WriteLine($"Adelantando video {seconds} segundos");
        }

        public void GoBackwards(int seconds) //Método no listo
        {
            Console.WriteLine($"Retrocediendo video {seconds} segundos");
        }

        public void ChangeQuality(string quality) //Método no listo
        {
            Console.WriteLine($"Cambiando a la calidad del video a: {quality}");
        }
    }
}