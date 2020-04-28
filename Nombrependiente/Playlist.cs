﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    public class Playlist : Song, IOrderPlaylist
    {
        private int numberSongs;
        List<Song> songs = new List<Song>();

        public Playlist(int numberSongs, List<Song> songs, string artist, string album, bool expliciT, int currentSecond, int length, int fileSize, string name, string gender, int year, string category, int numberOfReproductions, List<int> rankings, int mediaId, string relations, List<int> qualification, string quality, string dimension, object image) : base(artist, album, expliciT, currentSecond, length, fileSize, name, gender, year, category, numberOfReproductions, rankings, mediaId, relations, qualification, quality, dimension, image)
        {
            this.numberSongs  =  numberSongs;
            this.songs = songs;
            this.artist = artist;
            this.album = album;
            this.expliciT = expliciT;
            this.currentSecond = currentSecond;
            this.length = length;
            this.fileSize = fileSize;
            this.name = name;
            this.gender = gender;
            this.year = year;
            this.category = category;
            this.numberOfReproductions = numberOfReproductions;
            this.rankings = rankings;
            this.mediaId = mediaId;
            this.relations = relations;
            this.qualification = qualification;
            this.quality = quality;
            this.dimension = dimension;
            this.image = image;
        }

        public int NumberSongs { get => numberSongs; set => numberSongs = value; }
        public List<Song> Songs { get => songs; set => songs = value; }


        public void Mixture (int seconds)
        {
            Console.WriteLine($"Mezclando la cnación {seconds} segundos");
        }

        public void Add(Song song)
        {
            int counter = 0;
            foreach (Song s in songs)
            {
                if (song==s)
                {
                    counter +=  1;
                }
            }
            if (counter == 0)
            {
                songs.Add(song);
                Console.WriteLine($"Se ha agregado la canción {song.Name}");
            }
            else
            {
                Console.WriteLine("La canción ya se encuentra en su playList. ¿Desea agregarla de todas formas?\nOpción 1: Sí\nOpción 2: No");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "Sí") Songs.Add(song);
            }
        }
        
        public void Delete (Song song)
        {
            foreach (Song s in songs)
            {
                if (s == song)
                {
                    Songs.Remove(song);
                    Console.WriteLine($"Se ha eliminado la canción {song.Name}");
                }
            }
        }
        public void Next() //Falta hacer este método
        {
            Console.WriteLine("Pasando a la siguiente canción");
        }

        public void OrderAlphabet()        
        {
            List<string> names = new List<string>();
            List<Song> newSongs = new List<Song>();
            foreach (Song song in songs)
            {
                names.Add(song.Name);
            }
            names.Sort();

            foreach (Song song in songs)
            {
                foreach (string name in names)
                {
                    if (song.Name == name)
                    {
                        newSongs.Add(song);
                    }
                }
            }
            Songs = newSongs;
            Console.WriteLine("Se ha ordenado su playlist de acuerdo a los nombres de las canciones");
        }

        public void OrderByLength()
        {
            List<int> lenghts = new List<int>();
            List<Song> newSongs = new List<Song>();
            foreach (Song song in songs)
            {
                lenghts.Add(song.Length);
            }
            lenghts.Sort();

            foreach (Song song in songs)
            {
                foreach (int lenght in lenghts)
                {
                    if (song.Length == lenght)
                    {
                        newSongs.Add(song);
                    }
                }
            }
            songs = newSongs;
            Console.WriteLine("Se ha ordenado su playlist de acuerdo al largo de las canciones");
        }

        public void OrderPlaylist(MediaFile mediaFile, int posicion)//Falta hacer este método
        {
            //Dictionary<int,Song> newEpisodes = new Dictionary<int,Song>();
            Console.WriteLine("Ordenando de acuerdo a los parámetros entregados");
        }

        public void Previous() //Falta hacer este método
        {
            Console.WriteLine("Pasando al video anterior");
        }

    }
}
