using FindMyItem.Domain;
using FindMyItem.Common.Helpers;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginAdmart : PluginBaseBLL, IPlugin
    {
        private const string HTML_OBJECT_XPATH = "//li[@class='active']";

        public PluginAdmart(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }

        public new void Process()
        {
            if (HtmlNode != null)
            {
                string numberString = StringHelpers.GetNumbersFromString(HtmlNode.InnerText);

                CreateResult(numberString);
            }
        }
    }
}