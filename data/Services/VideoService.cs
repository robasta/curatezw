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
        private readonly IVideoChannelRepository _videoChannelRepository;
        private readonly IUnitOfWork _unitOfWork;
        public VideoService(IVideoRepository videoRepository, IVideoPlaylistRepository videoPlaylistRepository, IVideoChannelRepository videoChannelRepository, IUnitOfWork unitOfWork)
        {
            _videoRepository = videoRepository;
            _videoPlaylistRepository = videoPlaylistRepository;
            _videoChannelRepository = videoChannelRepository;
            _unitOfWork = unitOfWork;
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
            _videoChannelRepository.Add(channel);
            _unitOfWork.CommitAsync();
        }

        public IEnumerable<VideoChannel> GetAllChannels()
        {
            return _videoChannelRepository.All();
        }
    }
}
