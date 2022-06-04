#nullable disable

namespace Curate.Data.Models
{
    public partial class CollectionArticle
    {
        public int CollectionId { get; set; }
        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Collection Collection { get; set; }
    }
}
