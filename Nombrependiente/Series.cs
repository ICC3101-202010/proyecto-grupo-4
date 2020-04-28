using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Series_Videos:Video, IOrderPlaylist 
    {
        private int nofVideos;
        private List<Video> videos = new List<Video>();
        public Series_Videos(int nofVideos, List<Video> videos, List<string> actors, int ageFilter, string director, string synopsis, string studio, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image) : base(actors, ageFilter, director, synopsis, studio, currentSecond, length, fileSize, name, gender, year, category, numberOfReproductions, rankings, mediaId, relations, qualification, quality, dimension, image)
        {
            this.nofVideos = nofVideos;
            this.videos = videos;
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
        public List<Video> Episodes { get => videos; set => videos = value; }

        public void Add(Video video)
        {
            int counter = 0;
            foreach (Video v in videos)
            {
                if (video == v)
                {
                    counter += 1;
                }
            }
            if (counter == 0)
            {
                videos.Add(video);
                Console.WriteLine($"Se ha agregado el video {video.Name}");
            }
            else
            {
                Console.WriteLine("El video ya se encuentra en su playList. ¿Desea agregarlo de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí") videos.Add(video);
            }
        }

        public void Delete(Video video)
        {
            foreach (Video v in videos)
            {
                if (v == video)
                {
                    videos.Remove(video);
                    Console.WriteLine($"Se ha eliminado la canción {video.Name}");
                }
            }
        }

        public void Next() //Falta hacer este método
        {
            Console.WriteLine("Pasando al siguiente video");
        }

        public void OrderAlphabet()
        {
            List<string> names = new List<string>();
            List<Video> newVideos = new List<Video>();
            foreach (Video video in videos)
            {
                names.Add(video.Name);
            }
            names.Sort();

            foreach (Video video in videos)
            {
                foreach (string name in names)
                {
                    if (video.Name == name)
                    {
                        newVideos.Add(video);
                    }
                }
            }
            videos = newVideos;
            Console.WriteLine("Videos ordenados de forma correcta según su nombre.");
        }

        public void OrderByLength()
        {
            List<int> lenghts = new List<int>();
            List<Video> newVideos = new List<Video>();
            foreach (Video video in videos)
            {
                lenghts.Add(video.Length);
            }
            lenghts.Sort();

            foreach (Video video in videos)
            {
                foreach (int lenght in lenghts)
                {
                    if (video.Length == lenght)
                    {
                        newVideos.Add(video);
                    }
                }
            }
            videos = newVideos;
        }

        public void OrderPlaylist(MediaFile mediaFile, int position) //Falta hacer este método
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
