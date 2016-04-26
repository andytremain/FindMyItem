using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginVivaStreet : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//th[@class='selected toolbar_tab_selected ']//strong";

        public PluginVivaStreet(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}