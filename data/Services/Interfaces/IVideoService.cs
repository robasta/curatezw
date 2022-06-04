using Curate.Data.ViewModels.Article;

namespace Curate.Data.Services.Interfaces
{
    public interface IVideoService
    {
        ArticleViewModel GetVideo(int id);
        ArticleViewModel SaveVideo(ArticleViewModel articleViewModel);
    }
}
