using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Feeds
{
    interface IXMLFeed
    {
        FeedSearchResult GetResults(string url, string item);
    }
}
