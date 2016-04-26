using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginReed : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='page-h1-title']//span[@class='count']";
        
        public PluginReed(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}