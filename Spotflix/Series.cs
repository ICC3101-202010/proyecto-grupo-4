using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Series
    {
        private int nofVideos;
        private string serieName;
        private List<Video> videos = new List<Video>();
        public Series(int nofVideos, List<Video> videos, string serieName )
        {
            this.nofVideos = nofVideos;
            this.videos = videos;
            this.serieName = serieName;
        }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => videos; set => videos = value; }
        public string SerieName { get => serieName; set => serieName = value; }

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
                Console.WriteLine($"Se ha agregado el video {video.Name} a la serie {serieName}");
            }
            else
            {
                Console.WriteLine("El video ya es parte de la serie. ¿Desea agregarlo de todas formas?\nOpción 1: Sí\nOpción 2: No");
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
                    Console.WriteLine($"Se ha eliminado el video {video.Name} de la serie {serieName}");
                }
            }
        }
    }
}
