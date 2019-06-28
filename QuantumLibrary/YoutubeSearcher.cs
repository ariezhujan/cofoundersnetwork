using System.Collections.Generic;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;

namespace YoutubeSearch
{
    public class YoutubeSearcher
    {
        private readonly string _apiKey;

        public YoutubeSearcher(string apiKey)
        {
            _apiKey = apiKey;
        }

        public YoutubeSearchResult Search(YoutubeSearchRequest searchRequest)
        {
            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = _apiKey,
                ApplicationName = GetType().ToString()
            });

            SearchResource.ListRequest request = CreateYoutubeSearchRequest(youtubeService, searchRequest);
            var searchListResponse = request.Execute();

            var videos = new List<Google.Apis.YouTube.v3.Data.SearchResult>();
            var channels = new List<Google.Apis.YouTube.v3.Data.SearchResult>();
            var playlists = new List<Google.Apis.YouTube.v3.Data.SearchResult>();

            foreach (var searchResult in searchListResponse.Items)
            {
                switch (searchResult.Id.Kind)
                {
                    case "youtube#video":
                        videos.Add(searchResult);
                        break;

                    case "youtube#channel":
                        channels.Add(searchResult);
                        break;

                    case "youtube#playlist":
                        playlists.Add(searchResult);
                        break;
                }
            }

            return new YoutubeSearchResult
            {
                Videos = videos,
                Channels = channels,
                PlayLists = playlists
            };
        }

        private SearchResource.ListRequest CreateYoutubeSearchRequest(YouTubeService youtubeService, YoutubeSearchRequest searchRequest)
        {
            var request = youtubeService.Search.List("snippet");
            request.Q = searchRequest.Q;
            request.MaxResults = searchRequest.MaxResults;
            request.ChannelId = searchRequest.ChannelId;
            request.ChannelType = searchRequest.ChannelType;
            request.EventType = searchRequest.EventType;
            request.ForContentOwner = searchRequest.ForContentOwner;
            request.ForDeveloper = searchRequest.ForDeveloper;
            request.ForMine = searchRequest.ForMine;
            request.Location = searchRequest.Location;
            request.LocationRadius = searchRequest.LocationRadius;
            request.OnBehalfOfContentOwner = searchRequest.OnBehalfOfContentOwner;
            request.Order = searchRequest.Order;
            request.PageToken = searchRequest.PageToken;
            request.PublishedAfter = searchRequest.PublishedAfter;
            request.PublishedBefore = searchRequest.PublishedBefore;
            request.RegionCode = searchRequest.RegionCode;
            request.RelatedToVideoId = searchRequest.RelatedToVideoId;
            request.RelevanceLanguage = searchRequest.RelevanceLanguage;
            request.SafeSearch = searchRequest.SafeSearch;
            request.TopicId = searchRequest.TopicId;
            request.Type = searchRequest.Type;
            request.VideoCaption = searchRequest.VideoCaption;
            request.VideoDefinition = searchRequest.VideoDefinition;
            request.VideoDimension = searchRequest.VideoDimension;
            request.VideoDuration = searchRequest.VideoDuration;
            request.VideoEmbeddable = searchRequest.VideoEmbeddable;
            request.VideoLicense = searchRequest.VideoLicense;
            request.VideoSyndicated = searchRequest.VideoSyndicated;
            request.VideoType = searchRequest.VideoType;
            return request;
        }

        public static YoutubeSearch.YoutubeSearchResult Search(string searchTerm)
        {
            var searcher = new YoutubeSearch.YoutubeSearcher("AIzaSyAhFFL3ItKKnuPtdHh8vq5cqpaccsXQGPY");
            var searchRequest = new YoutubeSearch.YoutubeSearchRequest
            {
                Q = searchTerm,
                MaxResults = 30,
                RelevanceLanguage = "en"//,
                //VideoType = SearchResource.ListRequest.VideoTypeEnum.Any,
                //VideoDimension = SearchResource.ListRequest.VideoDimensionEnum.Any,
                //SafeSearch = SearchResource.ListRequest.SafeSearchEnum.Strict
                // ...
                // Add here all properties that needed in the request. See description of all supported properties in SearchRequest class
            };

            int count = 1;
            return searcher.Search(searchRequest);
        }        
    }
}
