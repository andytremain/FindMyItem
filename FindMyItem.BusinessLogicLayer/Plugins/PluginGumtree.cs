using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginGumtree : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//h1[@class='form-row-label space-mbxs']";

        public PluginGumtree(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}