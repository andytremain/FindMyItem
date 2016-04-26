using FindMyItem.Domain;
using FindMyItem.Common.Helpers;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginPistonheads : PluginBaseBLL, IPlugin
    {
        public PluginPistonheads(Site site, string item, CategoryType cat)
            : base(site, item, cat) {  }

        public new void Process()
        {            
            var htmlObject = base.WebDoc.GetElementbyId("search-numfound");

            if (htmlObject != null)
            {
                string numberString = StringHelpers.GetNumbersFromString(htmlObject.InnerText);

                base.CreateResult(numberString);
            }
        }
    }
}