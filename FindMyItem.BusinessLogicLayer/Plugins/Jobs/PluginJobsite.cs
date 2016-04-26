using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginJobsite  : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='searchResultsHeader']/h1";

        public PluginJobsite(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}