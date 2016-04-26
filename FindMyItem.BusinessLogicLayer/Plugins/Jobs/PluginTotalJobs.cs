using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginTotalJobs : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='page-header-job-count brand-font']";

        public PluginTotalJobs(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}