namespace FindMyItem.Domain
{
    public interface IPlugin
    {
        void Process();
        WebSiteSearchResult Result { get; }
    }
}
