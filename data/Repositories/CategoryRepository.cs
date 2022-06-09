using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, IRssFeedCategoryRepository
    {
        public CategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {
            
        }
    }
}
