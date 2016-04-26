using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginUkClassifieds  : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//font[@color='red']";

        public PluginUkClassifieds(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}