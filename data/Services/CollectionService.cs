using System.Collections.Generic;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;

namespace Curate.Data.Services
{
    public class CollectionService : ICollectionService
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CollectionService(ICollectionRepository collectionRepository, IUnitOfWork unitOfWork)
        {
            _collectionRepository = collectionRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Collection> GetCollections()
        {
            return _collectionRepository.All("CollectionArticles");
        }

        public Collection GetCollection(int id)
        {
            return _collectionRepository.GetOneByFilter(c=>c.Id == id, "CollectionArticles.Article.TagArticles.Tag");
        }

        public void InsertCollection(Collection collection)
        {
            collection.Slug = collection.Title.GenerateSlug();
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
