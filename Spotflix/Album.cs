﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    class Album : IOrderPlaylist
    {
        private string name;
        private List<string> artists = new List<string>();
        private int numberSongs;
        private List<Song> songs = new List<Song>();

        public Album(string name, List<string> artists, int numberSongs, List<Song> songs)
        {
            this.name = name;
            this.artists = artists;
            this.numberSongs = numberSongs;
            this.songs = songs;
        }

        public string Name { get => name; set => name = value; }
        public List<string> Artists { get => artists; set => artists = value; }
        public int NumberSongs { get => numberSongs; set => numberSongs = value; }
        public List<Song> Songs { get => songs; set => songs = value; }

        public void OrderByAlphabet(bool up, string mediaFile)
        {
            if (artists.Count() != 0 && songs.Count != 0)
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
            else Console.WriteLine("No se han encontrado artistas o canciones");
        }


        public void OrderByDate(bool up, string mediaFile)
        {
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
            else Console.WriteLine("No se han encontrado artistas o canciones");
        }

        

        public void OrderByLength(bool up, string mediaFile)
        {
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
            else Console.WriteLine("No se han encontrado artistas o canciones");
        }

        

        public void OrderByQualification(bool up, string mediaFile)
        {
            if (artists.Count() != 0 && songs.Count != 0)
            {
                if (up)
                {
                    this.songs = songs.OrderBy(song => song.Qualification).ToList();
                }
                else
                {
                    this.songs = songs.OrderByDescending(song => song.Qualification).ToList();
                }
            }
            else Console.WriteLine("No se han encontrao artistas o canciones");
        }
    
    }
}