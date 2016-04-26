using System;

namespace FindMyItem.Domain.Feeds
{
    public class FeedResultBO : IFeedResult
    {
        public string Title { get; set; }
        public string AdvertURL { get; set; }
        public string ImageURL { get; set; }

        public bool Valid(string item)
        {
            return !String.IsNullOrEmpty(Title)
                        && Title.ToLower().Contains(item)
                            && !String.IsNullOrEmpty(AdvertURL);
        }
    }
}
