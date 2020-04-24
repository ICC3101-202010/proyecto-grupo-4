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
        private List<Video> episodes = new List<Video>();
        public Series(int nofVideos) { this.nofVideos = nofVideos; }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }
    }
}
