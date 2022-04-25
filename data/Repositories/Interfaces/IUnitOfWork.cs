using System.Threading.Tasks;

namespace Curate.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> CommitAsync();
    }
}
