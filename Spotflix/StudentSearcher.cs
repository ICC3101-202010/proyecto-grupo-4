using Microsoft.WindowsAPICodePack.Dialogs;
using Spotflix.Media_Related;
using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spotflix
{
    public static class StudentSearcher
    {
        private static MediaPlayer mediaPlayer;

        public static MediaPlayer MediaPlayer { get => mediaPlayer; set => mediaPlayer = value; }
        public static void Smartlist(Playlist playlist)
        {
            string bigfilter = playlist.Filter;
            HashSet<Lesson> lessons = new HashSet<Lesson>();
            bigfilter = bigfilter.ToLower();
            if (bigfilter.Contains("or"))
            {

                string[] separator = { "or" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (item.Contains("and"))
                    {
                        string[] sep = { "and" };
                        string[] subfilters = item.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string subitem in subfilters)
                        {
                            if (lessons.Count() == 0)
                            {
                                lessons.UnionWith(SearchLesson(subitem));
                            }
                            else
                            {
                                lessons.IntersectWith(SearchLesson(subitem));
                            }
                        }    
                    }
                    else
                    {
                        lessons.UnionWith(SearchLesson(item));

                    }
                }
            }
            else if (bigfilter.Contains("and"))
            {
                string[] separator = { "and" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (lessons.Count() == 0)
                    {
                        lessons.UnionWith(SearchLesson(item));
                    }
                    else
                    {
                        lessons.IntersectWith(SearchLesson(item));
                    }
                }
            }
            else
            {
                lessons.UnionWith(SearchLesson(bigfilter));
            }
            playlist.Lessons = lessons.ToList();
        }
        public static void Brain(string bigfilter)
        {
            bigfilter = bigfilter.ToLower();
            HashSet<Lesson> lessons = new HashSet<Lesson>();
            HashSet<Teacher> teachers = new HashSet<Teacher>();
            HashSet<Student> students = new HashSet<Student>();

            if (bigfilter.Contains("or"))
            {
                string[] separator = { "or" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (item.Contains("and"))
                    {
                        string[] sep = { "and" };
                        string[] subfilters = item.Split(sep, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string subitem in subfilters)
                        {
                            if (teachers.Count() == 0)
                            {
                                teachers.UnionWith(SearchTeacher(subitem));
                            }
                            else
                            {
                                teachers.IntersectWith(SearchTeacher(subitem));
                            }
                            if (students.Count() == 0)
                            {
                                students.UnionWith(SearchStudent(subitem));
                            }
                            else
                            {
                                students.IntersectWith(SearchStudent(subitem));
                            }
                            if (lessons.Count() == 0)
                            {
                                lessons.UnionWith(SearchLesson(subitem));
                            }
                        }

                    }
                    else
                    {
                        students.UnionWith(SearchStudent(item));
                        teachers.UnionWith(SearchTeacher(item));
                        lessons.UnionWith(SearchLesson(item));

                    }
                }
            }
            else if (bigfilter.Contains("and"))
            {
                string[] separator = { "and" };
                string[] filters = bigfilter.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in filters)
                {
                    if (teachers.Count() == 0)
                    {
                        teachers.UnionWith(SearchTeacher(item));
                    }
                    else
                    {
                        teachers.IntersectWith(SearchTeacher(item));
                    }
                    if (students.Count() == 0)
                    {
                        students.UnionWith(SearchStudent(item));
                    }
                    else
                    {
                        students.IntersectWith(SearchStudent(item));
                    }
                    if (lessons.Count() == 0)
                    {
                        lessons.UnionWith(SearchLesson(item));
                    }

                }
            }
            else
            {
                students.UnionWith(SearchStudent(bigfilter));
                teachers.UnionWith(SearchTeacher(bigfilter));
                lessons.UnionWith(SearchLesson(bigfilter));
            }
            Gate.Foundstudents = students;
            Gate.Foundteachers = teachers;
            MediaPlayer.Foundlessons = lessons;

        }
        
        public static HashSet<Teacher> SearchTeacher(string filter)
        {
            HashSet<Teacher> found = new HashSet<Teacher>();
            if (filter.Contains(":"))
            {
                filter = filter.Replace(" ", "");
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "name":
                        foreach (Teacher teacher in Gate.Teachers)
                        {
                            if (teacher.Name.ToLower().Contains(caser[1])|| teacher.Lastname.ToLower().Contains(caser[1]))
                            {
                                found.Add(teacher);
                            }
                        }
                        break;
                    case "curse":
                        
                        foreach (Teacher teacher in Gate.Teachers)
                        {
                            string combindedString = string.Join(",", teacher.Course);
                            if (combindedString.ToLower().Contains(caser[1]))
                            {
                                found.Add(teacher);
                            }
                        }
                        break;
                    case "subject":

                        foreach (Teacher teacher in Gate.Teachers)
                        {
                            string combindedString = string.Join(",", teacher.Subjects);
                            if (combindedString.ToLower().Contains(caser[1]))
                            {
                                found.Add(teacher);
                            }
                        }
                        break;
                    case "nickname":

                        foreach (Teacher teacher in Gate.Teachers)
                        {
                            if (teacher.Nickname.ToLower().Contains(caser[1]))
                            {
                                found.Add(teacher);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Student> SearchStudent(string filter)
        {
            HashSet<Student> found = new HashSet<Student>();
            if (filter.Contains(":"))
            {
                filter = filter.Replace(" ", "");
                string[] caser = filter.Split(':');
                switch (caser[0])
                {
                    case "name":
                        foreach (Student student in Gate.Students)
                        {
                            if (student.Name.ToLower().Contains(caser[1]) || student.Lastname.ToLower().Contains(caser[1]))
                            {
                                found.Add(student);
                            }
                        }
                        break;
                    case "curse":

                        foreach (Student student in Gate.Students)
                        {
                            if (student.Curse.ToLower().Contains(caser[1]))
                            {
                                found.Add(student);
                            }
                        }
                        break;
                    case "subject":

                        foreach (Student student in Gate.Students)
                        { 
                            string combindedString = string.Join(",", student.Subjects);
                            if (combindedString.ToLower().Contains(caser[1]))
                            {
                                found.Add(student);
                            }
                        }
                        break;
                    case "nickname":

                        foreach (Student student in Gate.Students)
                        {
                            if (student.Nickname.ToLower().Contains(caser[1]))
                            {
                                found.Add(student);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
        public static HashSet<Lesson> SearchLesson(string filter)
        {
            HashSet<Lesson> found = new HashSet<Lesson>();
            filter = filter.Replace(" ", "");
            if (filter.Contains(":"))
            {
                string[] caser = filter.Split(':');

                switch (caser[0])
                {
                    case "teacher":
                        foreach (Lesson lesson in MediaPlayer.Lessons)
                        {
                            if (lesson.Teacher.Name.ToLower().Contains(caser[1]) || lesson.Teacher.Lastname.ToLower().Contains(caser[1]) || lesson.Teacher.Nickname.ToLower().Contains(caser[1]))
                            {
                                found.Add(lesson);
                            }
                        }
                        break;
                    case "name":
                        foreach (Lesson lesson in MediaPlayer.Lessons)
                        {
                            if (lesson.Name.ToLower().Contains(caser[1]))
                            {
                                found.Add(lesson);
                            }
                        }
                        break;
                    case "subject":
                        foreach (Lesson lesson in MediaPlayer.Lessons)
                        {
                            if (lesson.Subject.ToLower().Contains(caser[1]))
                            {
                                found.Add(lesson);
                            }
                        }
                        break;
                    case "curse":
                        foreach (Lesson lesson in MediaPlayer.Lessons)
                        {
                            if (lesson.Course.ToLower().Contains(caser[1]))
                            {
                                found.Add(lesson);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            return found;
        }
    }
}

