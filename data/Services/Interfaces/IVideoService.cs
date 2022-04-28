using Curate.Data.Models;
using System.Collections.Generic;

namespace Curate.Data.Services.Interfaces
{
    public interface IVideoService
    {
        IEnumerable<Video> GetFeaturedVideos();
        Video GetVideo(int id);
        VideoPlaylist GetPlaylist(int id);
        void CreateChannel(VideoChannel channel);
        IEnumerable<VideoChannel> GetAllChannels();
    }
}
