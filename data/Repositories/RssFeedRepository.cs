using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class RssFeedRepository : Repository<RssFeed>, IRssFeedRepository
    {
        public RssFeedRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
