using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRepository<Video> _videoRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly ITagService _tagService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VideoService(IRepository<Video> videoRepository, IUnitOfWork unitOfWork, IRepository<Article> articleRepository, IMapper mapper, ITagService tagService)
        {
            _videoRepository = videoRepository;
            _unitOfWork = unitOfWork;
            _articleRepository = articleRepository;
            _mapper = mapper;
            _tagService = tagService;
        }
        public ArticleViewModel GetVideo(int id)
        {
            var article = _articleRepository.GetOneByFilter(v=>v.Id == id, includeProperties:"Video, TagArticles.Tag, CollectionArticles.Collection");
            var viewModel = _mapper.Map<ArticleViewModel>(article);
            return viewModel;
        }

        public ArticleViewModel SaveVideo(ArticleViewModel articleViewModel)
        {
            var dbArticle = _articleRepository.GetOneByFilter(v => v.Id == articleViewModel.Id, includeProperties: "TagArticles.Tag, CollectionArticles.Collection");
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
                      dbTag =  _tagService.SaveTag(dbTag);
                    }
                    articleViewModel.TagsArticles.Add(new TagArticle{TagId = dbTag.Id, ArticleId = articleViewModel.Id});
                }
            }
            var article = _mapper.Map<Article>(articleViewModel);
            dbArticle.Title = article.Title;
            dbArticle.Blurb = article.Blurb;
            dbArticle.TagArticles = article.TagArticles;
            dbArticle.LastModifiedDate = DateTime.Now;
            _articleRepository.Update(dbArticle);
            _unitOfWork.CommitAsync();
            return articleViewModel;
        }
    }
}
