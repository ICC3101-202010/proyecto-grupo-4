using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    interface IOrderPlaylist
    {
        void OrderPlaylist(MediaFile mediaFile, int posicion);
        void OrderByLength();
        void OrderAlphabet();
        void Next();
        void Previous(); 
    }
}
