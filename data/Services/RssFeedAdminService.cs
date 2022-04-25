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
using Curate.Data.ViewModels.RssFeed;
using Microsoft.Extensions.Logging;

namespace Curate.Data.Services
{
    public class RssFeedAdminService : IRssFeedAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRssFeedRepository _feedRepository;
        private readonly IRssFeedArticleRepository _feedArticleRepository;
        private readonly IRssFeedCategoryRepository _feedCategoryRepository;
        private readonly IRssFeedErrorRepository _feedErrorRepository;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public RssFeedAdminService(IUnitOfWork unitOfWork, IRssFeedRepository feedRepository, IRssFeedArticleRepository feedArticleRepository, ILogger<RssFeedAdminService> logger, IMapper mapper, IRssFeedCategoryRepository feedCategoryRepository, IRssFeedErrorRepository feedErrorRepository)

        {
            _unitOfWork = unitOfWork;
            _feedRepository = feedRepository;
            _feedArticleRepository = feedArticleRepository;
            _logger = logger;
            _mapper = mapper;
            _feedCategoryRepository = feedCategoryRepository;
            _feedErrorRepository = feedErrorRepository;
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
                //var feed= _feedRepository.List(f => f.Id == feed.Id).First();
                link = data.Link;
                feed.ImageUrl = data.ImageUrl;
                feed.LastUpdated = DateTime.Now;
                feed.Blurb = data.Description;
                feed.Title = data.Title;

                _feedRepository.Update(feed);

                foreach (var item in data.Items)
                {
                   var article =  new RssFeedArticle
                    {
                        Body = item.Content,
                        Url = item.Link??item.Id,
                        PublishDate = DateTime.Parse(item.PublishingDateString),
                        LastModifiedDate = DateTime.Now,
                        IsProcessed = false,
                        Title = item.Title,
                        RssFeedId = feed.Id,
                    };
                   _feedArticleRepository.Add(article);
                }
            }
            catch (Exception ex)
            {
                var feedError = new RssFeedError
                {
                    ErrorDate = DateTime.Now,
                    ErrorMessage = ex.Message,
                    Url = feed.XmlUrl,
                    RssFeedId = feed.Id,
                    RssFeedTitle = feed.Title
                };
                _feedErrorRepository.Add(feedError);
                _logger.LogError(ex,"Feed error");
            }
            

        }

        public async Task<bool> ScanAllRssFeeds()
        {
            var tasks = new List<Task>();
            var rssFeeds = _feedRepository.List(x=>x.Blocked == false).ToList();
            foreach (var item in rssFeeds)
            {
                tasks.Add(ProcessRssFeed(item));
            }
            Task.WhenAll(tasks).Wait();
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
            var categories = _feedCategoryRepository.All("RssFeedSubtypes,RssFeedSubtypes.RssFeeds");
            var viewModel = _mapper.Map<List<FeedCategoryViewModel>>(categories);
          
            return viewModel;
        }

        public FeedViewModel GetFeed(int feedId)
        {
            var rssFeed =  _feedRepository.GetOneByFilter(i => i.Id == feedId && !i.Blocked, "RssFeedArticles"); //,RssFeedSubType,RssFeedSubType.ParentType
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
                                RssFeedSubTypeId = outline.SubTypeId,
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
