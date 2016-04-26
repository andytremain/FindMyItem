using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginPreloved : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//p[@id='search-results-sub-title']/b";

        public PluginPreloved(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}