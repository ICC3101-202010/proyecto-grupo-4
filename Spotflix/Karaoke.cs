using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Karaoke : Song
    {
        List<string> lyrics=new List<string>();

        public Karaoke( List<string> lyrics, string artist, string album, bool expliciT, string name, string gender, int year, object image, string route) : base(artist, album, expliciT, name, gender, year, image, route)
        {
            this.lyrics = lyrics;
        }

        public List<string> Lyrics { get => lyrics; set => lyrics = value; }
    }
}