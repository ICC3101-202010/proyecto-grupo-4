using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class SongEventArgs: EventArgs
    {
        public Song Song { get; set; }
        public Playlist PlayList { get; set; }
    }
}
