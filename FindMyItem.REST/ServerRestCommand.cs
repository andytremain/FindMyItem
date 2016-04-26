using System;
using System.Collections.Generic;
using System.Net;
using FindMyItem.Common.Helpers;
using FindMyItem.Domain;
using RestSharp;

namespace FindMyItem.REST
{
    public class RestCommands : IRestCommands
    {
        private readonly RestClient _restClient;

        public RestCommands(string webApiUrl)
        {
            _restClient = new RestClient(webApiUrl);
        }

        public bool CacheSite()
        {
            const string url = "admin/CacheSite";

            return GetResponse<bool>(url);
        }

        public CacheStatus GetCacheStatus()
        {
            const string url = "admin/GetCacheStatus";

            return GetResponse<CacheStatus>(url);
        }

        public IEnumerable<Site> GetCachedSites()
        {
            const string url = "admin/GetCachedSites";

            return GetResponse<List<Site>>(url);
        }

        public IEnumerable<Site> GetDisabledSites()
        {
            const string url = "admin/GetDisabledSites";

            return GetResponse<List<Site>>(url);
        }

        public SearchResult Search(string category, string item)
        {
            var url = String.Format("search/{0}/{1}", category, item);

            return GetResponse<SearchResult>(url);
        }

        public IEnumerable<Category> GetCategories()
        {
            const string url = "search/GetCategories";

            return GetResponse<List<Category>>(url);
        }

        private T GetResponse<T>(string url) where T : new()
        {
            var req = new RestRequest(url, Method.GET) { RequestFormat = DataFormat.Json };

            var response = _restClient.Execute(req);

            return response.StatusCode == HttpStatusCode.OK ? JSON.Deserialize<T>(response.Content) : default(T);
        }
    }
}