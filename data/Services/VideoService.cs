﻿using System.Collections.Generic;
using System.Linq;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;

namespace Curate.Data.Services
{
    public class VideoService: IVideoService
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoPlaylistRepository _videoPlaylistRepository;
        public VideoService(IVideoRepository videoRepository, IVideoPlaylistRepository videoPlaylistRepository)
        {
            _videoRepository = videoRepository;
            _videoPlaylistRepository = videoPlaylistRepository;
        }
        public Video GetVideo(int id)
        {
            return  _videoRepository.List(v=>v.Id== id).FirstOrDefault();
        }

        public VideoPlaylist GetPlaylist(int id)
        {
            return _videoPlaylistRepository.List(v => v.Id == id).FirstOrDefault();
        }

        public IEnumerable<Video> GetFeaturedVideos()
        {
            throw new System.NotImplementedException();
        }

        public void CreateChannel(VideoChannel channel)
        {
            throw new System.NotImplementedException();
        }
    }
}