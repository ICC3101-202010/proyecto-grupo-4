using Spotflix.User_Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    [Serializable]
    public class HomeWork
    {
        private Student student;
        private string teachermail;
        private byte[] bytes;

        public HomeWork(Student student, string teachermail, byte[] bytes)
        {
            this.student = student;
            this.teachermail = teachermail;
            this.bytes = bytes;
        }

        public Student Student { get => student; set => student = value; }
        public string Teachermail { get => teachermail; set => teachermail = value; }
        public byte[] Bytes { get => bytes; set => bytes = value; }
    }
}
