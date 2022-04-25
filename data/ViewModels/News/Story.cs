using System;
using System.Collections.Generic;
using System.Linq;

namespace Curate.Data.ViewModels.News
{
    public class Story
    {
        public Story()
        {
            Guid g = System.Guid.NewGuid();
            Guid = g.ToString().Split('-').First();
        }
        public MinimalArticle Article { get; set; }

        public string Guid
        {
            get;
            set;
        }

        public List<MinimalArticle> RelatedArticles { get; set; }
        public List<ArticleEntity> Entities { get; set; }   
        public IEnumerable<string> EntitiesWithCounts { get; set; }
    }
    
}