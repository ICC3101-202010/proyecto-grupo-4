using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class OrderByEventArgs: EventArgs
    {
        public bool Up {get; set; }
        public Playlist PlayList { get; set; }
        public string MediaFile { get; set; }
        public string Option { get; set; }
    }
}
