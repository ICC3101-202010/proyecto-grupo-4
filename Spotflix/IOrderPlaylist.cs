using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    interface IOrderPlaylist
    {
        void OrderByDate(bool up);
        void OrderByLength(bool up);
        void OrderAlphabet(bool up);

    }
}
