using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class VideoChannelRepository : Repository<VideoChannel>, IVideoChannelRepository
    {
        public VideoChannelRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
