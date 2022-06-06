using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;

namespace Curate.Data.Services
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TagService(ITagRepository tagRepository, IUnitOfWork unitOfWork)
        {
            _tagRepository = tagRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Tag> GetTag(int id, string includeProperties)
        {
            return  _tagRepository.GetOneByFilter(t=>t.Id == id,includeProperties);
        }

        public async Task<IEnumerable<Tag>> GetFeaturedTags()
        {
            return _tagRepository.All();
        }


        IQueryable<Tag> ITagService.Search(string q)
        {
           return _tagRepository.List(s=> s.Title.ToLower().Contains(q));
        }

        public Tag SaveTag(Tag tag)
        {
            _tagRepository.Add(tag);
            _unitOfWork.CommitAsync();
            return tag;
        }

        public IQueryable<Tag> GetTags()
        {
            return _tagRepository.All();
        }
    }
}
