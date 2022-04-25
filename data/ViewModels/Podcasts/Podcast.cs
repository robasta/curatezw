using System;

namespace Curate.Data.ViewModels.Podcasts
{
    public class Podcast
    {

        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Excerpt { get; set; }

        public DateTime Date { get; set; }
    }
}
