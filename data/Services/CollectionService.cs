using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
            return  _collectionRepository.All("CollectionArticles.Article.TagArticles.Tag,CollectionArticles.Article.Video");
        }

        public Collection GetCollection(int id)
        {
            return _collectionRepository.GetOneByFilter(c=>c.Id == id, "CollectionArticles.Article.TagArticles.Tag");
        }

        IQueryable<Collection> ICollectionService.Search(string q)
        {
            return _collectionRepository.List(s => s.Title.ToLower().Contains(q));
        }

        public async Task<Collection> InsertCollection(Collection collection)
        {
            collection.Slug = collection.Title.GenerateSlug();
            _collectionRepository.Add(collection);
            var savedCount = await _unitOfWork.CommitAsync();
            return collection;
        }

        public async Task<Collection> UpdateCollection(Collection collection)
        {
            _collectionRepository.Update(collection);
           var savedCount = await _unitOfWork.CommitAsync();
           return collection;
        }

    }
}
