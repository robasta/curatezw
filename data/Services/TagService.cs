using System.Collections.Generic;
using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;

namespace Curate.Data.Services
{
    public class TagService: ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<Tag> GetTag(int id, string includeProperties)
        {
            return  _tagRepository.GetOneByFilter(t=>t.Id == id,includeProperties);
        }

        public async Task<IEnumerable<Tag>> GetFeaturedTags()
        {
            return _tagRepository.All();
        }
    }
}
