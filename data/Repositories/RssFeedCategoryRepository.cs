using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class RssFeedCategoryRepository : Repository<Category>, IRssFeedCategoryRepository
    {
        public RssFeedCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
