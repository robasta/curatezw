using System.Collections.Generic;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface ICollectionService
    {
        IEnumerable<Collection> GetCollections();
        Collection GetCollection(int id);
        void InsertCollection(Collection collection);
        void UpdateCollection(Collection collection);
    }
}