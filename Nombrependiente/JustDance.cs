using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class JustDance : Video
    {
        private int nofVideos;
        private List<Video> episodes = new List<Video>(); 
        public JustDance(int nofVideos) { this.nofVideos  =  nofVideos;  }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }
    }
}
