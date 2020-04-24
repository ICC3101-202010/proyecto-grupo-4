using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public abstract class MediaFile
    {
        //Atributes
        protected int length;
        protected int fileSize;
        protected string name;
        protected string gender;
        protected int year;
        protected string category;
        protected int numberOfReproductions;
        protected List<int> rankings = new List<int>();
        protected int mediaId;
        protected string relations;
        protected List<int> qualification = new List<int>();
        protected string quality;
        protected string dimension;
        protected object image; 
    }
}
