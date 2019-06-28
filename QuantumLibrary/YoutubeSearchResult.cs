using System.Collections.Generic;

namespace YoutubeSearch
{
    public class YoutubeSearchResult
    {
        public List<Google.Apis.YouTube.v3.Data.SearchResult> Videos { get; set; }

        public List<Google.Apis.YouTube.v3.Data.SearchResult> Channels { get; set; }

        public List<Google.Apis.YouTube.v3.Data.SearchResult> PlayLists { get; set; }
    }
}
