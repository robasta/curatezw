using System;
using System.Collections.Generic;
using System.Linq;
using Curate.Data.Models;
using Curate.Data.ViewModels.Video;

namespace Curate.Data.ViewModels.Article
{
    public class ArticleViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public string Blurb { get; set; }
        public string Slug { get; set; }

        public DateTime? LastModifiedDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public List<TagArticle> TagsArticles { get; set; }
        public List<CollectionArticle> CollectionArticles { get; set; }
        public  int FeedId { get; set; }
        public string TagList { get; set; }
        public string CollectionList { get; set; }
        public VideoViewModel Video { get; set; }

        public void SetTagList()
        {
            if (TagsArticles.Any())
            {
                TagList = TagsArticles.Select(t => t.Tag.Title).Aggregate((tag, next) => tag + "," + next);
            }
        }
        public void SetCollectionList()
        {
            if (CollectionArticles.Any())
            {
                CollectionList = CollectionArticles.Select(t => t.Collection.Title).Aggregate((collection, next) => collection + "," + next);
            }
        }
    }
}