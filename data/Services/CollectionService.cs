using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;

namespace Curate.Data.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly IRepository<Collection> _collectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CollectionService(IRepository<Collection> collectionRepository, IUnitOfWork unitOfWork)
        {
            _collectionRepository = collectionRepository;
            _unitOfWork = unitOfWork;
        }

        public Collection GetCollection(int id)
        {
            return _collectionRepository.GetOneByFilter(c=>c.Id == id, "CollectionArticles.Article.TagArticles.Tag");
        }

        public void InsertCollection(Collection collection)
        {
            _collectionRepository.Add(collection);
            _unitOfWork.CommitAsync();
        }

        public void UpdateCollection(Collection collection)
        {
            _collectionRepository.Update(collection);
            _unitOfWork.CommitAsync();
        }
    }
}
