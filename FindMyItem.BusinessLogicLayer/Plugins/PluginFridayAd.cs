using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginFridayAd : PluginBaseBLL
    {
        public PluginFridayAd(Site site, string item, CategoryType cat)
            : base(site, item, cat) { }
    }
}
