using System;
using System.Collections.Generic;
using Curate.Data.ViewModels.News;

namespace Curate.Data.ViewModels.Composites
{
    public class Topic
    {
        public bool IsPublished { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public List<MinimalArticle> Articles { get; set; }
        public string Blurb { get; set; }
        public List<ArticleEntity> Entities { get; set; }
        public List<string> Tags { get; set; }
        public string ImageUrl { get; set; }
        public List<Models.Video> Videos { get; set; }
        public List<string> References { get; set; }
        public string PindulaWikiUrl { get; set; }
        public string WikipediaUrl { get; set; }
        public string CurateKbUrl { get; set; } // this will happen, it has to happen
        public List<string> Aliases { get; set; }
    }
}