using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Spotflix
{
    public class Video : MediaFile
    {
        private int ageFilter;
        private string director;
        private string synopsis;
        private string studio;
        private int currentSecond;
        private List<string> actors = new List<string>();

        public List<string> Actors { get => actors; set => actors = value; }
        protected int AgeFilter { get => ageFilter; set => ageFilter = value; }
        protected string Director { get => director; set => director = value; }
        protected string Synopsis { get => synopsis; set => synopsis = value; }
        protected string Studio { get => studio; set => studio = value; }
        protected int CurrentSecond { get => currentSecond; set => currentSecond = value; }
    }
}