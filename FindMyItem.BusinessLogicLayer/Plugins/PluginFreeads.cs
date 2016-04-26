using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginFreeads : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='col-md-8 col-sm-7 col-xs-12 blank_pright']//h1//strong";

        public PluginFreeads(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}