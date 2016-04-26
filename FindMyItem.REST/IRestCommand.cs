using System.Collections.Generic;
using FindMyItem.Domain;

namespace FindMyItem.REST
{
    public interface IRestCommands
    {
        // Admin
        bool CacheSite();
        CacheStatus GetCacheStatus();
        IEnumerable<Site> GetCachedSites();
        IEnumerable<Site> GetDisabledSites();
            
        // Search
        SearchResult Search(string category, string item);

        // Categories
        IEnumerable<Category> GetCategories();
    }
}
