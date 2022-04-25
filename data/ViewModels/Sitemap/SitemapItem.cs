using System;

namespace Curate.Data.ViewModels.Sitemap
{
    public class SitemapItem
    {
        private DateTime? _lastModified;
        private ChangeFrequency? _changeFrequency;
        
        public SitemapItem(string url)
        {
            Url = url;
        }

        public string Url { get; set; }

        public DateTime? LastModified
        {
            get { return _lastModified ?? (_lastModified = DateTime.Now); }
            set
            {
                _lastModified = value;
            } 
        }

        public ChangeFrequency? ChangeFrequency
        {
            get { return _changeFrequency ?? (_changeFrequency = Curate.Data.ViewModels.Sitemap.ChangeFrequency.Monthly); } 
            set { _changeFrequency = value; }
        }

        public float? Priority { get; set; }
    }
}
