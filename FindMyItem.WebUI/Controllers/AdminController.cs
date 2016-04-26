using System.Linq;
using System.Web.Mvc;
using FindMyItem.Domain;
using FindMyItem.REST;

namespace FindMyItem.WebUI.Controllers
{
    public class AdminController : BaseController
    {
        private readonly IRestCommands _serverRestClient;

        public AdminController(IRestCommands serverRestClient)
        {
            _serverRestClient = serverRestClient;
        }

        public ActionResult Index()
        {
            var status = _serverRestClient.GetCacheStatus();

            if (status == null) return View(); // TODO: needs error view

            ViewBag.CachePath = status.CachePath;
            ViewBag.CacheFileExists = status.CacheFileExists;
            ViewBag.CacheInMemory = status.InMemory;

            var allSites = _serverRestClient.GetCachedSites();

            if (allSites == null) return View(); // TODO: needs error view

            ViewBag.ActiveSites = allSites.Where(o => o.Enabled.Equals(true)).ToList();
            ViewBag.DisabledSites = allSites.Where(o => o.Enabled.Equals(false)).ToList();

            return View();
        }

        public ActionResult CacheSite()
        {
            var siteCached = _serverRestClient.CacheSite();
            var activeSites = _serverRestClient.GetCachedSites().ToList().Where(o => o.Status == SiteStatus.Active);
            var activeWithErrors = _serverRestClient.GetDisabledSites().ToList().Where(o => o.Status == SiteStatus.ActiveWithError); 
            var disabledSites = _serverRestClient.GetDisabledSites().ToList().Where(o => o.Status == SiteStatus.Disabled);

            ViewBag.SiteCached = siteCached;
            ViewBag.ActiveSites = activeSites;
            ViewBag.ActiveWithErrors = activeWithErrors;
            ViewBag.DisabledSites = disabledSites;

            return View("Index");
        }
    }
}
