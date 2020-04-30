using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Album:IOrderPlaylist
    {
        private string name;
        private List<string> artists=new List<string>();
        private int numberSongs;
        private List<Song> songs = new List<Song>();

        public void OrderAlphabet(bool up)
        {
            List<string> temp = new List<string>();
            if (artists.Count()!=0 && songs.Count!=0)
            {
                if (up)
                {
                    this.songs = songs.OrderBy(song => song.Name).ToList();
                }
                else
                {
                    this.songs = songs.OrderByDescending(song => song.Name).ToList();
                }
            }
        }

        public void OrderByDate(bool up)
        {
            List<string> temp = new List<string>();
            if (artists.Count() != 0 && songs.Count != 0)
            {
                if (up)
                {
                    this.songs = songs.OrderBy(song => song.Year).ToList();
                }
                else
                {
                    this.songs = songs.OrderByDescending(song => song.Year).ToList();
                }
            }
        }


        public void OrderByLength(bool up)
        {
            List<string> temp = new List<string>();
            if (artists.Count() != 0 && songs.Count != 0)
            {
                if (up)
                {
                    this.songs = songs.OrderBy(song => song.Length).ToList();
                }
                else
                {
                    this.songs = songs.OrderByDescending(song => song.Length).ToList();
                }
            }
        }

    }






}
