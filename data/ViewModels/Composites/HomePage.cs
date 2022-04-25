using System.Collections.Generic;
using Curate.Data.Models;
using Curate.Data.ViewModels.Blogs;
using Curate.Data.ViewModels.News;
using Curate.Data.ViewModels.Podcasts;

namespace Curate.Data.ViewModels.Composites
{
    public class HomePage
    {
        public List<MinimalArticle> BreakingNews { get; set; }
        public List<MinimalArticle> PopularNews { get; set; }

        public List<MinimalArticle> FeaturedNews { get; set; }

        public List<Video> FeaturedVideos { get; set; }

        public List<Post> LatestNyambo { get; set; }

        public List<Blog> FeaturedBlogs { get; set; }

        public List<Podcast> FeaturedPodcasts { get; set; }

        /* TODO
         
         - Featured Entity, Event, Topic etc
         - Social Media (Insta, FB, Twitter)
         - WhatsApp Memes
         
         */
    }
}
