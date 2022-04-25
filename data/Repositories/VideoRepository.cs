using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
