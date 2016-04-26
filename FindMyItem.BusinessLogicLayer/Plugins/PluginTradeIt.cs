using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginTradeIt : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='list-main-title']//h1";

        public PluginTradeIt(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}