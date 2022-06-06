using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface ICollectionService
    {
        Collection GetCollection(int id);
        void InsertCollection(Collection collection);
        void UpdateCollection(Collection collection);
    }
}