using System.Collections.Generic;
using Curate.Data.Models;
using X.PagedList;

namespace Curate.Data.ViewModels
{
    public class NyamboListViewModel
    {
        public NyamboListViewModel(IEnumerable<Post> posts, int page, int pageSize, int totalCount)
        {
            List<NyamboViewModel> nyamboViewModels = new List<NyamboViewModel>();
            foreach (var post in posts)
            {
                nyamboViewModels.Add(new NyamboViewModel(post));
            }
            PagedList = new StaticPagedList<NyamboViewModel>(nyamboViewModels, page, pageSize, totalCount);
        }
        public IPagedList<NyamboViewModel> PagedList { get; set; }
        public int PostCount => PagedList.Count;
    }
}
