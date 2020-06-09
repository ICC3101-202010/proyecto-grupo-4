using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Spotflix
{
    public partial class InfoBox : Form
    {

        public InfoBox(int likes,int nofRep)//info of the platform
        {

            InitializeComponent();
            Platforminfo.Visible = true;
            GradeText.Text = "Hasn't been qualified by anyone yet";
            LikeText.Text = likes.ToString();
            RepText.Text = nofRep.ToString();

        }
        public InfoBox(int likes, int nofRep,double grade)//info of the platform
        {
            InitializeComponent();
            GradeText.Text = grade.ToString();

            LikeText.Text = likes.ToString();

            RepText.Text = nofRep.ToString();

            Platforminfo.Visible = true;
        }
        public InfoBox(string genre, string actors, string director,string studio,int year,string synopsis, int age)//meta
        {
            InitializeComponent();
            GenreText.Text = genre;

            DirectorTExt.Text = director;

            ActorsText.Text = actors;

            StudioText.Text = studio;

            MinimunAgeText.Text = age.ToString();

            YearText.Text = year.ToString();
            MetaInfo.Visible = true;

        }
        public InfoBox(string genre, string artist, int year , string album, bool explicit1)//meta
        {
            InitializeComponent();
            GenreText.Text = genre;


            DirectorShow.Text = "Artist:";
            DirectorTExt.Text = artist;


            ActorsShow.Text = "Album:";
            ActorsText.Text = album;


            StudioShow.Text = "Year:";
            StudioText.Text = year.ToString();


            MinimunAgeShow.Text = "Explicit content:";

            MinimunAgeShow.Text = explicit1.ToString();
            YearShow.Visible = false;
            MetaInfo.Visible = true;
        }
        public InfoBox(string duration, string dimension, long filesize)//intrinsic
        {
            InitializeComponent();
            DurationText.Text = duration;
            DimensionText.Text = dimension;
            SizeText.Text = filesize.ToString() + " Bytes";
            InstrinsicInfo.Visible = true;
        }
        public InfoBox(int num)
        {
            InitializeComponent();
            switch (num)
            {
                case 1:
                    CaserTExt.Text = "ERROR -- CANNOT DOWNLOAD VIDEO";
                    break;
                case 2:
                    CaserTExt.Text = "SONG DOWNLOADED SUCCESFULLY";
                    break;
                case 3:
                    CaserTExt.Text = $"ERROR -- COULDN'T FIND SUITABLE PATH";
                    break;
                case 4:
                    CaserTExt.Text = "ERROR -- CANNOT DOWNLOAD\nUSER IS NOT PREMIUM";
                    break;
                default:
                    break;
            }
            CaserShow.Visible = true;
        }

        private void Likeshow_Click(object sender, EventArgs e)
        {

        }
    }
}
