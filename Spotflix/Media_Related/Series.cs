using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Spotflix.Media_Related
{
    [Serializable]
    public class Serie
    {
        private int nofVideos;
        private string serieName;
        private int season;
        private List<Video> episodes = new List<Video>();
        private Image image;
        private int code;

        public Serie(int nofVideos, List<Video> episodes, string serieName, int season, Image image,int code)
        {
            this.nofVideos = nofVideos;
            this.episodes = episodes;
            this.serieName = serieName;
            this.season = season;
            this.image = image;
            this.code = code;
        }
        public Serie() { }
        public int NofVideos { get => nofVideos; set => nofVideos = value; }
        public List<Video> Episodes { get => episodes; set => episodes = value; }
        public string SerieName { get => serieName; set => serieName = value; }
        public int Season { get => season; set => season = value; }
        public Image Image { get => image; set => image = value; }
        public int Code { get => code; set => code = value; }
    }
}
