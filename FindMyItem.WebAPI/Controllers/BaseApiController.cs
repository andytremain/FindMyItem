using System.Collections.Generic;
using System.Web.Http;
using FindMyItem.Domain;

using BLL = FindMyItem.BusinessLogicLayer;

namespace FindMyItem.WebAPI.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IEnumerable<Site> GetCachedSites()
        {
            var loader = new BLL.SiteLoaderBLL();

            return loader.GetCacheSites();
        }
    }
}
