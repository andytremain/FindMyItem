using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginExchangeAndMart  : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='product-detail col-sm-6']//span";

        public PluginExchangeAndMart(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}