using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using FindMyItem.Common;
using FindMyItem.Common.Helpers;
using FindMyItem.Domain;

using BLL = FindMyItem.BusinessLogicLayer;

namespace FindMyItem.WebAPI.Controllers
{
    public class AdminController : BaseApiController
    {
        [HttpGet]
        public bool CacheSite()
        {
            var loader = new BLL.SiteLoaderBLL();

            return loader.LoadSites();
        }

        [HttpGet]
        public CacheStatus GetCacheStatus()
        {
            var retVal = new CacheStatus();

            var cache = System.Web.HttpContext.Current.Cache.Get(Constants.CACHE_NAME);

            var loader = new BLL.SiteLoaderBLL();

            var activeSites = loader.GetSitesList();

            if (cache != null)
            {
                var sitesBO = (IEnumerable<Site>)cache;

                var notLoaded = sitesBO.Select(allSites => allSites.Name)
                                       .Except(activeSites.Select(p => p.Name)).ToList();
            }

            retVal.InMemory = (cache != null);
            retVal.CachePath = CacheHelpers.GetCachePath();
            retVal.CacheFileExists = System.IO.File.Exists(CacheHelpers.GetCachePathWithFilename());

            return retVal;
        }

        [HttpGet]
        public new IEnumerable<Site> GetCachedSites()
        {
            return base.GetCachedSites();
        }

        public IEnumerable<Site> GetDisabledSites()
        {
            return base.GetCachedSites().Where(o => o.Enabled.Equals(false));
        }
    }
}
