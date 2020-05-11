using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
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
        
    }
}
