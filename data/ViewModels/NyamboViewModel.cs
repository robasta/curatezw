using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using Curate.Data.Models;
using Curate.Data.Utils;

namespace Curate.Data.ViewModels
{
    public class NyamboViewModel
    {
        public NyamboViewModel(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Body = FormatWhatsAppPost(post.Body);
            RelativeUrl = string.Format(SiteConstants.RouteTemplates.NyamboDetail, post.Id, post.Slug);
            AbsoluteUrl = SiteConstants.NyamboBaseUrl + RelativeUrl;
            LastModifiedDate = post.LastModifiedDate.GetValueOrDefault();
            Tags = post.TagPosts?.Select(t => new TagViewModel(t?.Tag));
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }

        public string RelativeUrl { get; set; }
        public string AbsoluteUrl { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public IEnumerable<TagViewModel> Tags { get; set; }

        public string HtmlEncodedUrl => WebUtility.HtmlEncode(AbsoluteUrl);

        private string FormatWhatsAppPost(string body)
        {
            string formattedBody = body.Replace("\n", "<br/>");

            var boldMatches = Regex.Matches(formattedBody, "\\*(.*?)\\*");
            foreach (Match boldMatch in boldMatches)
            {
                var newValue = "<b>" + boldMatch.Value.Substring(1, boldMatch.Value.Length - 2) + "</b>";
                formattedBody = formattedBody.Replace(boldMatch.Value, newValue);
            }

            var italicMatches = Regex.Matches(formattedBody, "_(.*?)_");
            foreach (Match italicMatch in italicMatches)
            {
                var newValue = "<i>" + italicMatch.Value.Substring(1, italicMatch.Value.Length - 2) + "</i>";
                formattedBody = formattedBody.Replace(italicMatch.Value, newValue);
            }

            return formattedBody;
        }
    }
}