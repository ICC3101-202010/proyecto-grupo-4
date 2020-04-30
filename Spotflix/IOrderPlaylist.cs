using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    interface IOrderPlaylist
    {
        void OrderByDate(bool up, string mediaFile);
        void OrderByLength(bool up, string mediaFile);
        void OrderByAlphabet(bool up, string mediaFile);
        void OrderByQualification(bool up, string mediaFile);
    }
}
