namespace FindMyItem.Domain
{
    public interface ISearch
    {
        WebSiteSearchResult Search(SearchEnquiry enq);
    }
}
