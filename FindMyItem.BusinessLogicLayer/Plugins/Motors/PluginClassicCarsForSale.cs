using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginClassicCarsForSale  : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='smaller']";

        public PluginClassicCarsForSale(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}