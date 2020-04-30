using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Karaoke : Video, IOrderPlaylist
    {
        private int nofVideos;
        private List<Video> episodes = new List<Video>();
        public Karaoke(int nofVideos, List<Video> episodes, List<string> actors, int ageFilter, string director, string synopsis, string studio, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image) : base(actors, ageFilter, director, synopsis, studio, currentSecond, length, fileSize, name, gender, year, category, numberOfReproductions, rankings, mediaId, relations, qualification, quality, dimension, image)
        {
            this.nofVideos = nofVideos;
            this.episodes = episodes;
            this.actors = actors;
            this.ageFilter = ageFilter;
            this.director = director;
            this.synopsis = synopsis;
            this.studio = studio;
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

        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }

        public void Next() //Falta hacer este método
        {
            Console.WriteLine("Pasando al siguiente video");
        }

        public void OrderAlphabet(bool up)
        {
            List<string> names = new List<string>();
            List<Video> newEpisodes = new List<Video>();
            foreach (Video video in episodes)
            {
                names.Add(video.Name);
            }
            names.Sort();

            foreach (Video video in episodes)
            {
                foreach (string name in names)
                {
                    if (video.Name == name)
                    {
                        newEpisodes.Add(video);
                    }
                }
            }
            episodes=newEpisodes;
            Console.WriteLine("Videos de karaoke ordenados de forma correcta según su nombre.");
        }

        public void OrderByLength(bool up)
        {
            List<int> lenghts = new List<int>();
            List<Video> newEpisodes = new List<Video>();
            foreach (Video video in episodes)
            {
                lenghts.Add(video.Length);
            }
            lenghts.Sort();

            foreach (Video video in episodes)
            {
                foreach (int lenght in lenghts)
                {
                    if (video.Length == lenght)
                    {
                        newEpisodes.Add(video);
                    }
                }
            }
            episodes = newEpisodes;
        }

        public void OrderByDate(bool up) //Falta hacer este método
        {
            //Dictionary<int,Video> newEpisodes = new Dictionary<int,Video>();
            Console.WriteLine("Ordenando de acuerdo a los parámetros entregados");
        }

        public void Previous() //Falta hacer este método
        {
            Console.WriteLine("Pasando al video anterior");
        }
    }
}
