using System.Threading.Tasks;
using Curate.Data.ViewModels.Article;

namespace Curate.Data.Services.Interfaces
{
    public interface IVideoService
    {
        ArticleViewModel GetVideo(int id);
        Task<ArticleViewModel> SaveVideo(ArticleViewModel articleViewModel);
    }
}
