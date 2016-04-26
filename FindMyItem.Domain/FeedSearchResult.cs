using System.Collections.Generic;
using FindMyItem.Domain.Feeds;

namespace FindMyItem.Domain
{
    public class FeedSearchResult : SearchResultBase
    {
        public List<FeedResultBO> FeedResults { get; set; }

        public FeedSearchResult()
        {
            FeedResults = new List<FeedResultBO>();
        }
    }
}
