using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotflix
{
    interface IPlay
    {
        void Play(MediaFile mediafile);
        void Stop(MediaFile mediafile);
        void Pause(MediaFile mediafile);
        MediaFile Search(List<string> filters, bool condition); //string=filters
        void CreatePlaylist(List<Song> songs);
        void CreatePlaylist(List<Video> videos);
        void AddToQueue(MediaFile mediafile);
        void Qualify(int qualification);
        double GetQualification();
        Object[] GetMetadata(MediaFile mediafile);
        List<string> GetPlataformInformation();
        List<string> GetIntrinsicInformation();


    }
}
