#nullable disable

namespace Curate.Data.Models
{
    public partial class TagRssFeedArticle
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public virtual RssFeedArticle Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
