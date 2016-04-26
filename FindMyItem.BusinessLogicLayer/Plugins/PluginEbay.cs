using FindMyItem.Domain;
using FindMyItem.Common.Helpers;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginEbay : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='listingscnt']";

        public PluginEbay(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }

        public new void Process()
        {            
            if (HtmlNode != null)
            {
                string numberString = StringHelpers.GetNumbersFromString(HtmlNode.InnerText);

                base.CreateResult(numberString);
            }
        }
    }
}
