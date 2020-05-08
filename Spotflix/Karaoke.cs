using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Karaoke : Song
    {
        private int nofVideos;
        private List<Video> videos = new List<Video>();


        public Karaoke(int nofVideos, List<Video> videos,string artist, string album, bool expliciT, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image, string route) : base(artist, album, expliciT, currentSecond, length, fileSize, name, gender, year, category, numberOfReproductions, rankings, mediaId, relations, qualification, quality, dimension, image, route)
        {
            this.nofVideos = nofVideos;
            this.videos = videos;
        }

        public void Add(Video video) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
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
                Console.WriteLine($"Se ha agregado el video {video.Name} a Karaoke");
            }
            else
            {
                Console.WriteLine("El video ya es parte de Karaoke. ¿Desea agregarlo de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí") videos.Add(video);
            }
        }

        public void Delete(Video video) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
        {
            foreach (Video v in videos)
            {
                if (v == video)
                {
                    videos.Remove(video);
                    Console.WriteLine($"Se ha eliminado el video {video.Name} de Karaoke");
                }
            }
        }
    }
}