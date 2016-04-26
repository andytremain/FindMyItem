using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginLoot : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='ads-number']";

        public PluginLoot(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) {  }
    }
}