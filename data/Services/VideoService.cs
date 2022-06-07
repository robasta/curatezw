using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;
using Curate.Data.ViewModels.Article;

namespace Curate.Data.Services
{
    public class VideoService: IVideoService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ITagService _tagService;
        private readonly ICollectionService _collectionService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoService(IVideoRepository videoRepository, IUnitOfWork unitOfWork, IArticleRepository articleRepository, IMapper mapper, ITagService tagService, ICollectionService collectionService)
        {
            _unitOfWork = unitOfWork;
            _articleRepository = articleRepository;
            _mapper = mapper;
            _tagService = tagService;
            _collectionService = collectionService;
        }
        public ArticleViewModel GetVideo(int id)
        {
            var article = _articleRepository.GetOneByFilter(v=>v.Id == id, includeProperties: "Video, TagArticles, CollectionArticles, TagArticles.Tag, CollectionArticles.Collection");
            var viewModel = _mapper.Map<ArticleViewModel>(article);
            return viewModel;
        }

        public async Task<ArticleViewModel> SaveVideo(ArticleViewModel articleViewModel)
        {
            var dbArticle = _articleRepository.GetOneByFilter(v => v.Id == articleViewModel.Id, includeProperties: "Video, TagArticles, CollectionArticles, TagArticles.Tag, CollectionArticles.Collection");
            SetTags(articleViewModel);
            SetCollections(articleViewModel);
            var article = _mapper.Map<Article>(articleViewModel);
            dbArticle.Title = article.Title;
            dbArticle.Blurb = article.Blurb;
            dbArticle.TagArticles = article.TagArticles;
            dbArticle.CollectionArticles = article.CollectionArticles;
            dbArticle.LastModifiedDate = DateTime.Now;
            _articleRepository.Update(dbArticle);
            await _unitOfWork.CommitAsync();
            return articleViewModel;
        }

        private void SetTags(ArticleViewModel articleViewModel)
        {
            if (!string.IsNullOrWhiteSpace(articleViewModel.TagList))
            {
                articleViewModel.TagsArticles = new List<TagArticle>();

                var tags = articleViewModel.TagList.Split(',');
                var dbTags = _tagService.GetTags().ToList();
                foreach (var tag in tags)
                {
                    var dbTag = dbTags.FirstOrDefault(t => t.Title.ToLower() == tag.ToLower());
                    if (dbTag == null)
                    {
                        dbTag = new Tag
                        {
                            Title = tag,
                            Slug = tag.GenerateSlug(),
                            Description = string.Empty,
                            CreatedDate = DateTime.Now,
                            LastModifiedDate = DateTime.Now
                        };
                       // dbTag = await _tagService.SaveTag(dbTag);
                    }

                    articleViewModel.TagsArticles.Add(new TagArticle { Tag = dbTag, ArticleId = articleViewModel.Id });
                }
            }
        }

        private void SetCollections(ArticleViewModel articleViewModel)
        {
            if (!string.IsNullOrWhiteSpace(articleViewModel.CollectionList))
            {
                articleViewModel.CollectionArticles = new List<CollectionArticle>();

                var collections = articleViewModel.CollectionList.Split(',');
                var dbCollections = _collectionService.GetCollections().ToList();
                foreach (var collection in collections)
                {
                    var dbCollection = dbCollections.FirstOrDefault(t => t.Title.ToLower() == collection.ToLower());
                    if (dbCollection != null)
                    {
                        articleViewModel.CollectionArticles.Add(new CollectionArticle
                            { CollectionId = dbCollection.Id, ArticleId = articleViewModel.Id });
                    }
                }
            }
        }
    }
}
