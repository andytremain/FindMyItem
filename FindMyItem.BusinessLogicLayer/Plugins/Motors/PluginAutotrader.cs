using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginAutotrader : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//h1[@class='search-form__count js-results-count']";

        public PluginAutotrader(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}