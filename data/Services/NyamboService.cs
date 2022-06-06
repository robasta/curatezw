using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;

namespace Curate.Data.Services
{
    public class NyamboService:INyamboService
    {

        private readonly IRepository<Post> _postRepository;
        private readonly IRepository<Tag> _tagRepository;

        public NyamboService(IRepository<Post> postRepository, IRepository<Tag> tagRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public async Task<IEnumerable<Post>> GetPagedNyambo(int page, int pageSize)
        {
            var posts = _postRepository.PagedList(p => p.OrderByDescending(n => n.LastModifiedDate), skip: (page -1)*pageSize,
                count: pageSize, includeProperties: "TagPosts.Tag");
            return posts;
        }

        public async Task<Post> GetNyamboById(string id)
        {
            return null;
        }
        
        public async Task<int> GetNyamboCount()
        {
           return _postRepository.All().Count();
        }

        public void AddNyambo(string message)
        {
            var bodyParts = message.Split('|');
            Post post = new Post { Body = bodyParts[0] };
            if (bodyParts.Length > 1)
            {
                string meta = bodyParts[1];
                var titleMatches = Regex.Matches(meta, "\"(.*?)\"");
                if (titleMatches.Count == 1)
                {
                    post.Title = titleMatches[0].Value.Substring(1, titleMatches[0].Value.Length - 2);
                }

                var tagMatches = Regex.Matches(meta, "\\[(.*?)\\]");
                if (tagMatches.Count == 1)
                {
                    var tagList = tagMatches[0].Value.Substring(1, tagMatches[0].Value.Length - 2).Split(',');

                    post.TagPosts = new List<TagPost>();
                    if (tagList.Length > 0)
                    {
                        foreach (string tag in tagList)
                        {
                            string cleanTag = tag;
                            if (tag.StartsWith("["))
                            {
                                cleanTag = tag.Remove(0, 1);
                            }

                            if (tag.EndsWith("]"))
                            {
                                cleanTag = cleanTag.Replace("]", "");
                            }

                            cleanTag = cleanTag.Trim();
                            var dbTag = _tagRepository.List(t => t.Title.ToLower() == cleanTag.ToLower()).FirstOrDefault();
                            if (dbTag == null)
                            {
                                dbTag = new Tag
                                {
                                    Title = cleanTag,
                                    Slug = cleanTag.GenerateSlug(),
                                    Description = string.Empty,
                                    CreatedDate = DateTime.Now,
                                    LastModifiedDate = DateTime.Now
                                };
                                _tagRepository.Add(dbTag);
                            }

                            post.TagPosts.Add(new TagPost { Tag = dbTag });
                        }
                    }
                }
            }

            post.Slug =
                !string.IsNullOrWhiteSpace(post.Title)
                    ? post.Title.GenerateSlug()
                    : post.Body.GenerateSlug(25);
        }

        public Post GetRandomNyambo()
        {
            throw new NotImplementedException();
        }
    }
}
