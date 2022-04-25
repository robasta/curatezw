using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class VideoPlaylistRepository : Repository<VideoPlaylist>, IVideoPlaylistRepository
    {
        public VideoPlaylistRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
