using System.Collections.Generic;
using Curate.Data.Models;
using Curate.Data.ViewModels.Blogs;
using Curate.Data.ViewModels.Podcasts;

namespace Curate.Data.ViewModels.Composites
{
    public class HomePage
    {

        public List<Video> FeaturedVideos { get; set; }

        public List<Post> FeaturedNyambo { get; set; }

        public List<Blog> FeaturedBlogs { get; set; }

        public List<Podcast> FeaturedPodcasts { get; set; }

        public List<VideoChannel> FeaturedBchannels { get; set; }

        public List<Tag> FeaturedTags { get; set; }

        public List<VideoPlaylist> FeaturedBplaylist { get; set; }

        /* TODO
         
         - Featured Entity, Event, Topic etc
         - Social Media (Insta, FB, Twitter)
         - WhatsApp Memes
         
         */
    }
}
