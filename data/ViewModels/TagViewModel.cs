using System.Collections.Generic;
using System.Net;
using Curate.Data.Models;
using Curate.Data.Utils;

namespace Curate.Data.ViewModels
{
    public class TagViewModel
    {
        public TagViewModel()
        {

        }
        public TagViewModel(Tag tag)
        {
            Id = tag.Id;
            Title = tag.Title;
            Description = tag.Description;
            RelativeUrl = string.Format(SiteConstants.RouteTemplates.TagDetail, tag.Id, tag.Slug);
            AbsoluteUrl = SiteConstants.NyamboBaseUrl + RelativeUrl;
            NyamboList = new List<NyamboViewModel>();
            if (tag.TagPosts!= null)
            {
                foreach (var post in tag.TagPosts)
                {
                    NyamboList.Add(new NyamboViewModel(post.Post));
                }
            }
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string RelativeUrl { get; set; }
        public string AbsoluteUrl { get; set; }
        public List<NyamboViewModel> NyamboList { get; set; }
        public string HtmlEncodedUrl => WebUtility.HtmlEncode(AbsoluteUrl);

    }
}