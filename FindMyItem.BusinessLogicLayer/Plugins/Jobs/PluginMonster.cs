using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginMonster : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//div[@class='col-xs-12 jsresultsheader']//h2[@class='page-title visible-xs']";

        public PluginMonster(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) {  }
    }
}