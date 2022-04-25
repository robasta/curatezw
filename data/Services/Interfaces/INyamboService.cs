using System.Collections.Generic;
using System.Threading.Tasks;
using Curate.Data.Models;

namespace Curate.Data.Services.Interfaces
{
    public interface INyamboService
    {
        Task<IEnumerable<Post>> GetPagedNyambo(int page, int pageSize);
        Task<Post> GetNyamboById(string id);
        Post GetRandomNyambo();

        Task<int> GetNyamboCount();
        void AddNyambo(string message);
    }
}
