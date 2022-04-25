using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Curate.Data.Models;
using Curate.Data.Repositories.Interfaces;
using Curate.Data.Services.Interfaces;
using Curate.Data.Utils;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Video = Curate.Data.Models.Video;

namespace Curate.Data.Services
{
    public class YoutubeApiService: IYoutubeApiService
    {
        private readonly YouTubeService _youTubeService;
        private readonly IVideoRepository _videoRepository;
        private readonly IVideoChannelRepository _videoChannelRepository;
        private readonly IVideoPlaylistRepository _videoPlaylistRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public YoutubeApiService(IVideoRepository videoRepository, IMapper mapper, IVideoPlaylistRepository videoPlaylistRepository, IUnitOfWork unitOfWork, IVideoChannelRepository videoChannelRepository)
        {
            _videoRepository = videoRepository;
            _mapper = mapper;
            _videoPlaylistRepository = videoPlaylistRepository;
            _unitOfWork = unitOfWork;
            _videoChannelRepository = videoChannelRepository;
            _youTubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = "AIzaSyDdNzf1ppCLC6NnaHWHhQRbXOZk_5owU_g",
                ApplicationName = this.GetType().ToString()
            });
        }
        public async Task<Video> GetVideoById(string videoId)
        {
            var videoRequest = _youTubeService.Videos.List("snippet,contentDetails");
            videoRequest.Id = videoId;
            var videoResponse = await videoRequest.ExecuteAsync();
            var youtubeVideo = videoResponse.Items.First();
            var curateVideo = _mapper.Map<Video>(youtubeVideo);

            return curateVideo;
        }

        public async Task<VideoPlaylist> GetPlaylistById(string playListId)
        {
            var playlistRequest = _youTubeService.Playlists.List("snippet,contentDetails");
            playlistRequest.Id = playListId;
            var playlistResponse = await playlistRequest.ExecuteAsync();
            var youtubePlaylist = playlistResponse.Items.First();
            var videoPlaylist = _mapper.Map<VideoPlaylist>(youtubePlaylist);
            videoPlaylist.LastModifiedDate = DateTime.Now;
            VideoChannel playlistChannel = null;
            var nextPageToken = "";
            while (nextPageToken != null)
            {
                var playlistItemsListRequest = _youTubeService.PlaylistItems.List("snippet,contentDetails");
                playlistItemsListRequest.PlaylistId = playListId;
                playlistItemsListRequest.MaxResults = 50;
                playlistItemsListRequest.PageToken = nextPageToken;

                var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();

                foreach (var playlistItem in playlistItemsListResponse.Items)
                {
                    var curateVideo = _mapper.Map<Video>(playlistItem);
                    curateVideo.LastModifiedDate = DateTime.Now;

                    if (playlistChannel == null && !string.IsNullOrWhiteSpace(playlistItem.Snippet.ChannelId))
                    {
                        playlistChannel = new VideoChannel
                        {
                            YoutubeChannelId = playlistItem.Snippet.ChannelId,
                            Slug = playlistItem.Snippet.ChannelTitle.GenerateSlug(),
                            Title = playlistItem.Snippet.ChannelTitle,
                            Url = $"https://www.youtube.com/channel/{playlistItem.Snippet.ChannelId}"
                        };
                        var channel = _videoChannelRepository.List(c => c.YoutubeChannelId == playlistItem.Snippet.ChannelId).FirstOrDefault();
                        if (channel != null)
                        {
                            playlistChannel = channel;
                        }
                    }
                    videoPlaylist.Channel = playlistChannel;
                    curateVideo.Channel = playlistChannel;
                    var videoPlaylistVideo = new VideoPlaylistVideo { Video = curateVideo};
                    if (playlistItem.Snippet.Position != null)
                    {
                        videoPlaylistVideo.Position = (int)playlistItem.Snippet.Position;
                    }
                    videoPlaylist.VideoPlaylistVideos.Add(videoPlaylistVideo);
                    
                }
                nextPageToken = playlistItemsListResponse.NextPageToken;
            }
            return videoPlaylist;
        }

        public async Task AddVideoOrPlaylist(string url)
        {
            var playlistId = YoutubeHelper.GetPlaylistIdFromUrl(url);
            if (string.IsNullOrWhiteSpace(playlistId))
            {
                var videoId = YoutubeHelper.GetVideoIdFromUrl(url);
                if (!string.IsNullOrWhiteSpace(videoId))
                {
                    var video = await GetVideoById(videoId);
                    _videoRepository.Add(video);
                }
            }
            else
            {
                var playlist = await GetPlaylistById(playlistId);
               _videoPlaylistRepository.Add(playlist);
            }

            await  _unitOfWork.CommitAsync();
        }


    }
}
