using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Karaoke : Song
    {
        private object lyrics;

        public Karaoke(object lyrics, string artist, string album, bool expliciT, string name, string gender, int year, int mediaId, object image, string route) : base(artist, album, expliciT, name, gender, year, mediaId, image, route)
        {
            this.lyrics = lyrics;
        }

        public object Lyrics { get => lyrics; set => lyrics = value; }

    }
}