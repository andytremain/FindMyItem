using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginNewsNow: PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//p[@id='totalSearch']";

        public PluginNewsNow(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}