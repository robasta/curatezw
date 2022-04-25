using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class RssFeedErrorRepository : Repository<RssFeedError>, IRssFeedErrorRepository
    {
        public RssFeedErrorRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
