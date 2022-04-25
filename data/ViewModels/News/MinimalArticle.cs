using System;
using System.Collections.Generic;

namespace Curate.Data.ViewModels.News
{
    public class MinimalArticle
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Site { get; set; }

        public DateTime ModifiedDate { get; set; }
        public string Image { get; set; }
        public List<string> Categories { get; set; }
        public string Category { get; set; }
        public int Points { get; set; }
        public List<ArticleEntity> Entities { get; set; }
        public string S3ImageUrl { get; set; }
    }
}