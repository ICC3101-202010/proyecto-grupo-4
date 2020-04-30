using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    interface IGo
    {
        void Gofowards(int seconds);
        void GoBackwards(int seconds);
        void ChangeQuality(string quality);
    }
}
