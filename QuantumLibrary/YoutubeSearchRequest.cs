﻿using System;
using Google.Apis.YouTube.v3;

namespace YoutubeSearch
{
    /// <summary>
    /// Class is used for mapping and has the same properties as SearchResource.ListRequest class from Google.Apis.YouTube.v3 library
    /// </summary>
    public class YoutubeSearchRequest
    {
        /// <summary>
        /// The channelId parameter indicates that the API response should only contain resources created
        ///             by the channel
        /// </summary>
        public string ChannelId { get; set; }

        /// <summary>
        /// The channelType parameter lets you restrict a search to a particular type of channel.
        /// </summary>
        public SearchResource.ListRequest.ChannelTypeEnum? ChannelType { get; set; }

        /// <summary>
        /// The eventType parameter restricts a search to broadcast events. If you specify a value for this
        ///             parameter, you must also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.EventTypeEnum? EventType { get; set; }

        /// <summary>
        /// Note: This parameter is intended exclusively for YouTube content partners.
        /// 
        ///              The forContentOwner parameter restricts the search to only retrieve resources owned by the content owner
        ///              specified by the onBehalfOfContentOwner parameter. The user must be authenticated using a CMS account
        ///              linked to the specified content owner and onBehalfOfContentOwner must be provided.
        /// </summary>
        public bool? ForContentOwner { get; set; }

        /// <summary>
        /// The forDeveloper parameter restricts the search to only retrieve videos uploaded via the
        ///             developer's application or website. The API server uses the request's authorization credentials to
        ///             identify the developer. Therefore, a developer can restrict results to videos uploaded through the
        ///             developer's own app or website but not to videos uploaded through other apps or sites.
        /// </summary>
        public bool? ForDeveloper { get; set; }

        /// <summary>
        /// The forMine parameter restricts the search to only retrieve videos owned by the authenticated
        ///             user. If you set this parameter to true, then the type parameter's value must also be set to
        ///             video.
        /// </summary>
        public bool? ForMine { get; set; }

        /// <summary>
        /// The location parameter, in conjunction with the locationRadius parameter, defines a circular
        ///              geographic area and also restricts a search to videos that specify, in their metadata, a geographic
        ///              location that falls within that area. The parameter value is a string that specifies latitude/longitude
        ///              coordinates e.g. (37.42307,-122.08427).
        /// 
        ///              - The location parameter value identifies the point at the center of the area. - The locationRadius
        ///              parameter specifies the maximum distance that the location associated with a video can be from that
        ///              point for the video to still be included in the search results.The API returns an error if your request
        ///              specifies a value for the location parameter but does not also specify a value for the locationRadius
        ///              parameter.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The locationRadius parameter, in conjunction with the location parameter, defines a circular
        ///              geographic area.
        /// 
        ///              The parameter value must be a floating point number followed by a measurement unit. Valid measurement
        ///              units are m, km, ft, and mi. For example, valid parameter values include 1500m, 5km, 10000ft, and
        ///              0.75mi. The API does not support locationRadius parameter values larger than 1000 kilometers.
        /// 
        ///              Note: See the definition of the location parameter for more information.
        /// </summary>
        public string LocationRadius { get; set; }

        /// <summary>
        /// The maxResults parameter specifies the maximum number of items that should be returned in the
        ///             result set.
        /// </summary>
        /// [default: 5]
        ///             [minimum: 0]
        ///             [maximum: 50]
        public long? MaxResults { get; set; }

        /// <summary>
        /// Note: This parameter is intended exclusively for YouTube content partners.
        /// 
        ///              The onBehalfOfContentOwner parameter indicates that the request's authorization credentials identify a
        ///              YouTube CMS user who is acting on behalf of the content owner specified in the parameter value. This
        ///              parameter is intended for YouTube content partners that own and manage many different YouTube channels.
        ///              It allows content owners to authenticate once and get access to all their video and channel data,
        ///              without having to provide authentication credentials for each individual channel. The CMS account that
        ///              the user authenticates with must be linked to the specified YouTube content owner.
        /// </summary>
        public string OnBehalfOfContentOwner { get; set; }

        /// <summary>
        /// The order parameter specifies the method that will be used to order resources in the API
        ///             response.
        /// </summary>
        /// [default: SEARCH_SORT_RELEVANCE]
        public SearchResource.ListRequest.OrderEnum? Order { get; set; }

        /// <summary>
        /// The pageToken parameter identifies a specific page in the result set that should be returned.
        ///             In an API response, the nextPageToken and prevPageToken properties identify other pages that could be
        ///             retrieved.
        /// </summary>
        public string PageToken { get; set; }

        /// <summary>
        /// The publishedAfter parameter indicates that the API response should only contain resources
        ///             created after the specified time. The value is an RFC 3339 formatted date-time value
        ///             (1970-01-01T00:00:00Z).
        /// </summary>
        public DateTime? PublishedAfter { get; set; }

        /// <summary>
        /// The publishedBefore parameter indicates that the API response should only contain resources
        ///             created before the specified time. The value is an RFC 3339 formatted date-time value
        ///             (1970-01-01T00:00:00Z).
        /// </summary>
        public DateTime? PublishedBefore { get; set; }

        /// <summary>
        /// The q parameter specifies the query term to search for.
        /// 
        ///              Your request can also use the Boolean NOT (-) and OR (|) operators to exclude videos or to find videos
        ///              that are associated with one of several search terms. For example, to search for videos matching either
        ///              "boating" or "sailing", set the q parameter value to boating|sailing. Similarly, to search for videos
        ///              matching either "boating" or "sailing" but not "fishing", set the q parameter value to boating|sailing
        ///              -fishing. Note that the pipe character must be URL-escaped when it is sent in your API request. The URL-
        ///              escaped value for the pipe character is %7C.
        /// </summary>
        public string Q { get; set; }

        /// <summary>
        /// The regionCode parameter instructs the API to return search results for the specified country.
        ///             The parameter value is an ISO 3166-1 alpha-2 country code.
        /// </summary>
        public string RegionCode { get; set; }

        /// <summary>
        /// The relatedToVideoId parameter retrieves a list of videos that are related to the video that
        ///             the parameter value identifies. The parameter value must be set to a YouTube video ID and, if you are
        ///             using this parameter, the type parameter must be set to video.
        /// </summary>
        public string RelatedToVideoId { get; set; }

        /// <summary>
        /// The relevanceLanguage parameter instructs the API to return search results that are most
        ///             relevant to the specified language. The parameter value is typically an ISO 639-1 two-letter language
        ///             code. However, you should use the values zh-Hans for simplified Chinese and zh-Hant for traditional
        ///             Chinese. Please note that results in other languages will still be returned if they are highly relevant
        ///             to the search query term.
        /// </summary>
        public string RelevanceLanguage { get; set; }

        /// <summary>
        /// The safeSearch parameter indicates whether the search results should include restricted content
        ///             as well as standard content.
        /// </summary>
        public SearchResource.ListRequest.SafeSearchEnum? SafeSearch { get; set; }

        /// <summary>
        /// The topicId parameter indicates that the API response should only contain resources associated
        ///             with the specified topic. The value identifies a Freebase topic ID.
        /// </summary>
        public string TopicId { get; set; }

        /// <summary>
        /// The type parameter restricts a search query to only retrieve a particular type of resource. The
        ///             value is a comma-separated list of resource types.
        /// </summary>
        /// [default: video,channel,playlist]
        public string Type { get; set; }

        /// <summary>
        /// The videoCaption parameter indicates whether the API should filter video search results based
        ///             on whether they have captions. If you specify a value for this parameter, you must also set the type
        ///             parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoCaptionEnum? VideoCaption { get; set; }

        /// <summary>
        /// The videoCategoryId parameter filters video search results based on their category. If you
        ///             specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public string VideoCategoryId { get; set; }

        /// <summary>
        /// The videoDefinition parameter lets you restrict a search to only include either high definition
        ///             (HD) or standard definition (SD) videos. HD videos are available for playback in at least 720p, though
        ///             higher resolutions, like 1080p, might also be available. If you specify a value for this parameter, you
        ///             must also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoDefinitionEnum? VideoDefinition { get; set; }

        /// <summary>
        /// The videoDimension parameter lets you restrict a search to only retrieve 2D or 3D videos. If
        ///             you specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoDimensionEnum? VideoDimension { get; set; }

        /// <summary>
        /// The videoDuration parameter filters video search results based on their duration. If you
        ///             specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoDurationEnum? VideoDuration { get; set; }

        /// <summary>
        /// The videoEmbeddable parameter lets you to restrict a search to only videos that can be embedded
        ///             into a webpage. If you specify a value for this parameter, you must also set the type parameter's value
        ///             to video.
        /// </summary>
        public SearchResource.ListRequest.VideoEmbeddableEnum? VideoEmbeddable { get; set; }

        /// <summary>
        /// The videoLicense parameter filters search results to only include videos with a particular
        ///             license. YouTube lets video uploaders choose to attach either the Creative Commons license or the
        ///             standard YouTube license to each of their videos. If you specify a value for this parameter, you must
        ///             also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoLicenseEnum? VideoLicense { get; set; }

        /// <summary>
        /// The videoSyndicated parameter lets you to restrict a search to only videos that can be played
        ///             outside youtube.com. If you specify a value for this parameter, you must also set the type parameter's
        ///             value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoSyndicatedEnum? VideoSyndicated { get; set; }

        /// <summary>
        /// The videoType parameter lets you restrict a search to a particular type of videos. If you
        ///             specify a value for this parameter, you must also set the type parameter's value to video.
        /// </summary>
        public SearchResource.ListRequest.VideoTypeEnum? VideoType { get; set; }
    }
}