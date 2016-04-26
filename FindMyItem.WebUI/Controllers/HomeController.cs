using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Routing;
using System.Web.Mvc;

using FindMyItem.Domain;
using FindMyItem.Common;
using FindMyItem.Managers;
using FindMyItem.REST;
using BLL = FindMyItem.BusinessLogicLayer;
using BLLFeeds = FindMyItem.BusinessLogicLayer.Feeds;
using SearchViewModel = FindMyItem.WebUI.Models.SearchViewModel;

namespace FindMyItem.WebUI.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ISearchManager _searchManager;
        private readonly IRestCommands _serverRestClient;

        public HomeController(ISearchManager searchManager, IRestCommands serverRestClient)
        {
            _searchManager = searchManager;
            _serverRestClient = serverRestClient;
        }

        public ActionResult About()
        {
            ViewBag.Sites = _serverRestClient.GetCachedSites() ?? new List<Site>();

            return View();
        }

        public ActionResult Index()
        {
            var model = new SearchViewModel();

            model.SearchHistory = _searchManager.GetAllSearchHistory();

            //model.TotalRecentSearchCount = model.SearchHistory.SelectMany(o => o.Item).Count();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Item = model.Item.ToLower();

                model.SelectedCategoryTypeEnum = (CategoryType)model.SelectedCategoryId;

                RouteValueDictionary route = ControllerContext.RouteData.Values;

                route.Add("category", model.SelectedCategoryTypeEnum.ToString().ToLower());                
                route.Add("item", model.Item);
                //route.Add("advancedSearch", model.AdvancedSearch);

                return RedirectToAction("Search", route);
            }
            return View(model);
        }

        public ActionResult GetRecentSearch(string category, string item)
        {
            CategoryType cat;
            item = item.ToLower();

            if (Enum.TryParse(category, out cat))
            {
                var search = _searchManager.GetSearch(cat, item);

                if (search == null) return RedirectToAction("Index");

                search.Result.SearchTime = null;

                return View("Index", (SearchViewModel)search);
            }

            return RedirectToAction("Index");
        }

        public ActionResult GoToSite(string url)
        {
            ViewBag.SiteURL = url;

            return View();
        }

        public ActionResult News()
        {
            return View();
        }

        public ActionResult RefreshResults(string category, string item, bool advancedSearch = false)
        {
            CategoryType cat;
            item = item.ToLower();
            //category = StringHelpers.ToTitleCase(category);

            if (!Enum.TryParse<CategoryType>(category, out cat)) return RedirectToAction("Index");

            var route = ControllerContext.RouteData.Values;
            route.Add("category", category);
            route.Add("item", item);

            return RedirectToAction("Search", route);
        }

        public ActionResult RecentSearches()
        {
            return View(_searchManager.GetAllSearchHistory());
        }

        public ActionResult RemoveSearch(string category, string item)
        {
            CategoryType cat;

            item = item.ToLower();

            if (Enum.TryParse<CategoryType>(category, out cat))
            {
                _searchManager.RemoveSearch(cat, item);
            }

            return View("RecentSearches", _searchManager.GetAllSearchHistory());
        }

        public async Task<ActionResult> Search(string category, string item) //, bool advancedSearch = false
        {
            item = item.ToLower();

            var  model = new SearchViewModel(category, item);

            var getWebResTask = _searchManager.Search(category, item);//GetWebsiteResults(enq);

            //if (model.AdvancedSearch) 
            //{
            //    var getFeedResTask = GetFeedResults(enq);

            //    await Task.WhenAll(getWebResTask, getFeedResTask);

            //    model.FeedResult = getFeedResTask.Result; 
            //}
            //else
            //{ 
                await getWebResTask;
            //}            

            model.SearchResult = getWebResTask.Result;

            model.SelectedCategoryTypeEnum = (CategoryType)model.SelectedCategoryId;

            var searchDto = new SearchModelDto()
            {
                CategoryId = (CategoryType)model.SelectedCategoryId,
                Item = model.Item,
                Result = model.SearchResult,
                PrevSearches = model.SearchHistory ?? new HashSet<SearchModelDto>()
            };

            _searchManager.AddSearch(searchDto);

            Session.Add(Constants.RECENT_SEARCHES, _searchManager.GetAllSearchHistory());

            model.SearchHistory = _searchManager.GetAllSearchHistory();

            return View("Index", model);                
        }

        #region Async Methods

        private async Task<FeedSearchResult> GetFeedResults(SearchEnquiry enq)
        {
            var xmlFeed = new BLLFeeds.XMLFeedBLL();

            var task = Task<FeedSearchResult>.Run(() => xmlFeed.GetResults("http://feeds.friday-ad.co.uk/xml/TrovitProductsXML.xml", enq.Item));

            await task;

            return task.Result;
        }

        #endregion
    }
}