using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginLocanto  : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='js-result_count']";

        public PluginLocanto(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}