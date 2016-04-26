namespace FindMyItem.Domain.Feeds
{
    interface IFeedResult
    {
        bool Valid(string item);
    }
}
