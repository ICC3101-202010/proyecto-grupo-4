using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class OrderByAEventArgs : EventArgs
    {
        public bool Up { get; set; }
        public Album Album { get; set; }
        public string Option { get; set; }
    }
}