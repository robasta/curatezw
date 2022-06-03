using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Serialization;
using AutoMapper;
using CodeHollow.FeedReader;
using Curate.Data.Exceptions;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;
using Curate.Data.ViewModels;
using Curate.Data.ViewModels.RssFeed;
using Microsoft.Extensions.Logging;

namespace Curate.Data.Services
{
    public class RssFeedAdminService : IRssFeedAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRssFeedRepository _feedRepository;
        private readonly IArticleRepository _feedArticleRepository;
        private readonly IRssFeedCategoryRepository _feedCategoryRepository;
        private readonly IYoutubeApiService _youTubeApiService;

        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RssFeedAdminService(IUnitOfWork unitOfWork, IRssFeedRepository feedRepository, IArticleRepository feedArticleRepository, ILogger<RssFeedAdminService> logger, IMapper mapper, IRssFeedCategoryRepository feedCategoryRepository, IYoutubeApiService youTubeService)

        {
            _unitOfWork = unitOfWork;
            _feedRepository = feedRepository;
            _feedArticleRepository = feedArticleRepository;
            _logger = logger;
            _mapper = mapper;
            _feedCategoryRepository = feedCategoryRepository;
            _youTubeApiService = youTubeService;
        }

        private async Task ProcessRssFeed(RssFeed feed)
        {
            var link = feed.HtmlUrl;
            if (feed.Blocked)
            {
                throw new BlockedFeedException(feed);
            }

            try
            {
                var data = await FeedReader.ReadAsync(feed.XmlUrl);
                link = data.Link;
                if (!string.IsNullOrEmpty(data.ImageUrl))
                    feed.ImageUrl = data.ImageUrl;
                if (!string.IsNullOrEmpty(data.Description))
                    feed.Blurb = data.Description;
                if(!string.IsNullOrEmpty(data.Title))
                    feed.Title = data.Title;
                feed.LastUpdated = DateTime.Now;

                _feedRepository.Update(feed);

                foreach (var item in data.Items)
                {
                    var itemUrl = item.Link ?? item.Id;
                    var dbArticle = _feedArticleRepository.List(a => a.Url == itemUrl).FirstOrDefault();
                    if (dbArticle == null)
                    {
                        var article = new Article
                        {
                            Body = item.Content,
                            Url = itemUrl,
                            PublishDate = DateTime.Parse(item.PublishingDateString),
                            LastModifiedDate = DateTime.Now,
                            Title = item.Title,
                            RssFeedId = feed.Id,
                        };

                        if (feed.SubCategory.CategoryId == (int)SourceType.Video)
                        {
                            var videoId = YoutubeHelper.GetVideoIdFromUrl(article.Url);
                            if (!string.IsNullOrWhiteSpace(videoId))
                            {
                                var video = await _youTubeApiService.GetVideoById(videoId);
                                //article. = video;
                            }
                        }

                        _feedArticleRepository.Add(article);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"Feed error");
            }
            

        }

        public async Task<bool> ScanAllRssFeeds()
        {
            var rssFeeds = _feedRepository.List(x=>x.Blocked == false).ToList();
            foreach (var item in rssFeeds)
            {
               await ProcessRssFeed(item);
            }
           return await _unitOfWork.CommitAsync()>0;

        }

        public async Task<bool> ScanOneRssFeed(int feedId)
        {
            var feed = _feedRepository.List(f => f.Id == feedId && !f.Blocked).FirstOrDefault();
            if (feed == null)
                return false;
         
            ProcessRssFeed(feed).Wait();
            return await _unitOfWork.CommitAsync() > 0;
        }

        public List<FeedCategoryViewModel> GetAllCategorizedFeeds()
        {
            var categories = _feedCategoryRepository.All("SubCategorys,SubCategorys.RssFeeds,SubCategorys.RssFeeds.Articles");
            var viewModel = _mapper.Map<List<FeedCategoryViewModel>>(categories);
          
            return viewModel;
        }

        public FeedArticleViewModel GetFeedArticle(int id)
        {
            var Article =
                _feedArticleRepository.GetOneByFilter(i => i.Id == id, "TagArticles.Tag");
            var viewModel = _mapper.Map<FeedArticleViewModel>(Article);
            return viewModel;
        }

        public FeedViewModel GetFeed(int feedId)
        {
            var rssFeed =  _feedRepository.GetOneByFilter(i => i.Id == feedId && !i.Blocked, "Articles"); //,SubCategory,SubCategory.ParentType
            var viewModel =  _mapper.Map<FeedViewModel>(rssFeed);
            return viewModel;
        }

        public async Task<bool> LoadOpmlFile(string filename, bool scan)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Opml));
            using (FileStream fileStream = new FileStream(filename, FileMode.Open))
            {
                var result = (Opml)serializer.Deserialize(fileStream);

                if (result != null)
                {
                    foreach (var outline in result.Body.Outline)
                    {
                        foreach (var feed in outline.Feeds)
                        {
                            var rssFeed = new RssFeed
                            {
                                HtmlUrl = feed.HtmlUrl?.Trim(),
                                Title = feed.Title?.Trim(),
                                XmlUrl = feed.XmlUrl?.Trim(),
                                Url = string.IsNullOrWhiteSpace(feed.HtmlUrl) ? feed.XmlUrl?.Trim() : feed.HtmlUrl?.Trim(),
                                SubCategoryId = outline.SubTypeId,
                            };
                            _feedRepository.Add(rssFeed);

                        }
                    }
                }

                var output = await _unitOfWork.CommitAsync() > 0;
                if (scan)
                {
                    return await ScanAllRssFeeds();
                }

                return output;
            }
        }
    }
}
