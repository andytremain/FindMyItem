using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using FindMyItem.Domain;
using FindMyItem.BusinessLogicLayer.Plugins;
using FindMyItem.Common.Exceptions;

namespace FindMyItem.BusinessLogicLayer
{
    public class SearcherBLL : ISearch
    {
        private readonly ISearch _searcher;

        public SearcherBLL(ISearch search)
        {
            _searcher = search;
        }

        public WebSiteSearchResult Search(SearchEnquiry enq)
        {
            return _searcher.Search(enq);
        }
    }    
        
    public static class SearchBLL
    {      
        public static WebSiteSearchResult GetWebsiteSearchResult(Site site, string item, CategoryType cat)
        {
            var url = site.Categories.Where(o => o.CategoryType.Equals(cat))
                                     .Select(o => o.URL).FirstOrDefault();

            if (String.IsNullOrEmpty(url)) return null;

            var pluginBLL = new PluginBLL(site, item, cat);
            var res = pluginBLL.Search();

            return res;
        }

        public static List<WebSiteSearchResult> Search(SearchEnquiry enq, IEnumerable<Site> siteList)
        {
            var returnValue = new List<WebSiteSearchResult>();

            if (siteList != null)
            {
                var client = new WebClient();

                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

                var errors = new List<string>();

                var category = (CategoryType)enq.CategoryId;

                siteList = siteList.Where(o => o.Categories.Any(p => p.CategoryType.Equals(category))).ToList();

                System.Threading.Tasks.Parallel.ForEach(siteList, x =>
                    {
                        try
                        {
                            var wsr = GetWebsiteSearchResult(x, enq.Item, category);

                            if (wsr != null) returnValue.Add(wsr);
                        }
                        catch (HtmlObjectNotFoundException ex)
                        {
                            errors.Add(ex.Message);
                        }
                        catch (Exception ex)
                        {

                        }
                    });

                returnValue = returnValue.OrderByDescending(x => x.ItemCount).ToList();
            }
            else
            {
                throw new ApplicationException("Cannot Retrieve cache");
            }

            return returnValue;
        }
    }    
}
