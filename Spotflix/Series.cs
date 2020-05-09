using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Series
    {
        private int nofVideos;
        private string serieName;
        private List<Video> episodes = new List<Video>();

        public Series(int nofVideos, List<Video> episodes, string serieName )
        {
            this.nofVideos = nofVideos;
            this.episodes = episodes;
            this.serieName = serieName;
        }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }
        public string SerieName { get => serieName; set => serieName = value; }




        public void OnAddVideoSerie(object source, VideoSerieEventArgs v) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
        {
            
            v.Serie.episodes.Add(v.Video);
            Console.WriteLine($"Se ha agregado el video {v.Video.Name} a la serie {v.Serie.SerieName}");
            
        }

        public void OnDeleteVideoSerie(object source, VideoSerieEventArgs v) //No se si esto tiene que ir acá porque el administrador lo debería manejar nomas
        {

            v.Serie.episodes.Remove(v.Video);
            Console.WriteLine($"Se ha eliminado el video {v.Video.Name} a la serie {v.Serie.SerieName}");
        }
    }
}
