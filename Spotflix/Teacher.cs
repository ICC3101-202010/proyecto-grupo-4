﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WMPLib;

namespace Spotflix
{
    [Serializable]
    public class Teacher : Person
    {
       
        private string course;
        private string code;
        private string passw;
        private string gmail;
        private string nickname;
        List<Lesson> lessons = new List<Lesson>();
        WindowsMediaPlayer music = new WindowsMediaPlayer();
        WindowsMediaPlayer player = new WindowsMediaPlayer();



        public Teacher(string nickname, string name, string lastname, string gmail, string code, string course, string passw)
        {
            this.nickname = nickname;
            this.name = name;
            this.lastname = lastname;
            this.gmail = gmail;
            this.code = code;
            this.course = course;
            this.passw = passw;
        }
        
        public string Course { get => course; set => course = value; }
        public string Code { get => code; set => code = value; }
        public string Passw { get => passw; set => passw = value; }
        public string Gmail { get => gmail; set => gmail = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public List<Lesson> Lessons { get => lessons; set => lessons = value; }

        public Teacher() { }
        public void ImportLesson(MediaPlayer mediaPlayer)
        {
            int count = 0;
            int choice;
            int countofvideos = 1;
            string route;
            bool succes = false;
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
            Console.WriteLine("Para añadir canciones de forma mas facil, estas deben estar en el siguiente directorio\n{0}\n", dir);
            string[] filters = new[] { "*.mp4" };
            string[] filePaths = filters.SelectMany(f => Directory.GetFiles(dir, f)).ToArray();
            Console.WriteLine("Seleccione la cancion a añadir:\n");
            foreach (string file in filePaths)
            {
                Console.WriteLine("{0} {1}\n", countofvideos, Path.GetFileName(file));
                countofvideos++;
            }
            succes = int.TryParse(Console.ReadLine(), out choice);

            if (succes && (filePaths.Count() >= (choice - 1)))
            {
                route = filePaths[choice - 1];
            }
            else
            {
                route = null;
            }
            if (route == null)
            {
                Console.WriteLine("Input invalido, volviendo al menu...");
            }
            else
            {
                TimeSpan lenght = TimeSpan.FromSeconds(player.newMedia(route).duration);
                Console.WriteLine("A continuacion ingrese los datos del video:\n");
                Console.WriteLine("Ingrese el nombre del profesor\n");
                string director = Console.ReadLine();
                string studio = "colegio";
                string genre = "clase";
                Console.WriteLine("Ingrese el año del video");
                int year = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese el nombre del video");
                string name = Console.ReadLine();
                string image = null;
                string stopper = "0";
                List<String> actors = new List<string>(); //Los actores del colegio son contenidos
                while (stopper == "0")
                {
                    Console.WriteLine("Ingrese los contenidos:(Ingrese 0 cuando haya terminado)\n");
                    string temp = Console.ReadLine();
                    if (temp != "0") actors.Append(temp);
                }
                Console.WriteLine("Ingrese desde que edad se puede ver el video: \n");
                string age = Console.ReadLine();
                string destination = Path.Combine(Environment.CurrentDirectory + @"\Lessons", Path.GetFileName(filePaths[choice - 1]));
                System.IO.File.Copy(route, destination, true);
                long fileSize = new System.IO.FileInfo(destination).Length;
                Video video = new Video(actors, age, director, studio, name, genre, image, year, destination);
                video.Route = destination;
                video.FileSize = fileSize;
                Console.WriteLine("A continuación, ingrese los datos de la clase");
                Console.WriteLine("Ingrese la asignatura de la clase");
                string subject= Console.ReadLine();
                Console.WriteLine("Ingrese el curso de la clase");
                string coursec = Console.ReadLine();
                Lesson lesson = new Lesson(name, subject, coursec, 0, video, this);
                if (mediaPlayer.Lessons.Count() == 0)
                {
                    mediaPlayer.Lessons.Add(lesson);
                    this.lessons.Add(lesson);
                }
                    
            
                else
                {
                    foreach (Lesson i in mediaPlayer.Lessons)
                    {
                        if (i == lesson)
                        {
                            count++;
                        }

                    }
                    if (count == 0)
                    {
                        mediaPlayer.Lessons.Add(lesson);
                        this.lessons.Add(lesson);
                    }
                    else Console.WriteLine("Esa clase ya existe");
                }
            }
        }
        public void ShowTeacher()
        {
            Console.WriteLine($"Nombre: {name}; Curso: {course}");
            foreach (Lesson lesson in lessons)
            {
                Console.WriteLine($"Asignatura: {lesson.Subject}; Nombre: {lesson.Name}");
            }
        }
    }
}
