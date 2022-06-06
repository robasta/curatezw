using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface ITagService
    {
        Task<Tag> GetTag(int id, string includeProperties);
        IQueryable<Tag> GetTags();
        IQueryable<Tag>  Search(string q);
        Tag SaveTag(Tag tag);
        
    }
}
