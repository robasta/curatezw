using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface ITagService
    {
        Task<Tag> GetTag(int id, string includeProperties);
        Task<IEnumerable<Tag>> GetFeaturedTags();
        IQueryable<Tag>  Search(string q);
    }
}
