using System.Threading.Tasks;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface IYoutubeApiService
    {
        Task<Google.Apis.YouTube.v3.Data.Video> GetVideoById(string videoId);
        Task<VideoPlaylist> GetPlaylistById(string playListId);

        Task AddVideoOrPlaylist(string url);
    }
}
