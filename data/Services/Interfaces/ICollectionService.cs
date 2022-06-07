using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface ICollectionService
    {
        IEnumerable<Collection> GetCollections();
        Collection GetCollection(int id);
        IQueryable<Collection> Search(string q);
        Task<Collection> InsertCollection(Collection collection);
        Task<Collection> UpdateCollection(Collection collection);

    }
}