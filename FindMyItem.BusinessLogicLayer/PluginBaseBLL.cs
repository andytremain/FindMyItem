using System;
using System.Linq;
using System.Net;
using HtmlAgilityPack;

using FindMyItem.Domain;
using FindMyItem.Common.Exceptions;
using FindMyItem.Common.Helpers;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public abstract class PluginBaseBLL : IPlugin
    {
        protected Site _site;
        protected string _item;
        protected CategoryType _cat;

        protected PluginBaseBLL(Site siteInfo, string item, CategoryType cat, string xPath = "")
        {
            _site = siteInfo;
            _item = item;
            _cat = cat;        

            // Get search uri from the category
            var searchUrl = _site.Categories.Where(o => o.CategoryType.Equals(_cat))
                                               .Select(p => p.URL).FirstOrDefault();            

            SearchUrl = String.Format(searchUrl, item);

            // Get search html doc
            WebDoc = new HtmlDocument();

            //wc.Proxy = new WebProxy("117.163.227.43:8123");
            //var page = wc.DownloadString(SearchUrl);

            var webGet = new HtmlWeb();
            WebDoc = webGet.Load(SearchUrl);

            HtmlNode = null;

            // Check the default xPath if not check the category
            if (!String.IsNullOrEmpty(xPath))
                GetNode(xPath);
            else
            {
                var catXPath = _site.Categories.Where(o => o.CategoryType.Equals(_cat))
                                               .Select(p => p.CountNode).FirstOrDefault();

                if (!String.IsNullOrEmpty(catXPath)) GetNode(catXPath);
            }
        }

        #region Public Methods

        public void CreateResult(string count)
        {
            var itemCount = Convert.ToInt32(count);

            Result = CreateNewResult();

            Result.ItemCount = itemCount;
        }

        public string GetCountNodeFromSettings()
        {
            return _site.Categories.Where(o => o.CategoryType.Equals(_site.CountNode))
                                                .Select(o => o.CountNode).FirstOrDefault();
        }

        protected void GetNode(string xPath)
        {
            var htmlNode = WebDoc.DocumentNode.SelectSingleNode(xPath);

            if (htmlNode != null)
                HtmlNode = htmlNode;
            else
            {
                var message = string.Format("{0} : Cannot find  - {1}", GetType().Name, xPath);

                throw new HtmlObjectNotFoundException(message);
            }
        }

        public void Process()
        {
            if (HtmlNode == null) return;

            var numberString = StringHelpers.GetNumbersFromString(HtmlNode.InnerText.Replace(_item, String.Empty));
            CreateResult(numberString);
        }      

        #endregion

        #region Private Methods

        private WebSiteSearchResult CreateNewResult()
        {
            return new WebSiteSearchResult(_site.Name, _cat, _item, 0, SearchUrl);
        }

        #endregion

        #region Properties

        public HtmlNode GetCategoryCountNode
        { 
            get
            {
                SiteCategory catProp = _site.Categories.Where(o => o.CategoryType.Equals(_cat)).FirstOrDefault();

                return this.WebDoc.DocumentNode.SelectSingleNode(catProp.CountNode);
            }
        }

        public WebSiteSearchResult Result { get; set; }
        public HtmlDocument WebDoc { get; set; }
        public HtmlNode HtmlNode { get; private set; }
        public string SearchUrl { get; set; }

        #endregion       
    }
}
