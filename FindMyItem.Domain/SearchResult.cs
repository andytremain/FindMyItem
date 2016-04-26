using System.Collections.Generic;

namespace FindMyItem.Domain
{
    public class SearchResult : SearchResultBase
    {
        public List<WebSiteSearchResult> Results { get; set; }
        
        public SearchResult()
        {
            Results = new List<WebSiteSearchResult>();
        }
    }
}
