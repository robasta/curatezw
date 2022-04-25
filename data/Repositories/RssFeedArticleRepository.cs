using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;

namespace Curate.Data.Repositories
{
    public class RssFeedArticleRepository : Repository<RssFeedArticle>, IRssFeedArticleRepository
    {
        public RssFeedArticleRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
