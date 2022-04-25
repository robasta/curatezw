using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class RssFeedCategoryRepository : Repository<RssFeedType>, IRssFeedCategoryRepository
    {
        public RssFeedCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
