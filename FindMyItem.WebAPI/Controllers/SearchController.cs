using System;
using System.Diagnostics;
using System.Web.Http;

using FindMyItem.BusinessLogicLayer;
using FindMyItem.Domain;

namespace FindMyItem.WebAPI.Controllers
{
    public class SearchController : BaseApiController
    {
        [HttpGet]
        [Route("search/{category}/{item}")]
        public SearchResult Search(string category, string item)
        {
            var res = new SearchResult();

            CategoryType cat;

            if (!Enum.TryParse(category, true, out cat)) return null;

            var enq = new SearchEnquiry() {CategoryId = (int)cat, Item = item};

            var sw = new Stopwatch();

            sw.Start();

            res.Results = SearchBLL.Search(enq, GetCachedSites());

            sw.Stop();

            res.SearchTime = sw.Elapsed;

            return res;
        }
    }
}
