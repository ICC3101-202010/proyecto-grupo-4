using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class VideoSerieEventArgs : EventArgs
    {
        public Video Video { get; set; }
        public Series Serie { get; set; }
    }
}