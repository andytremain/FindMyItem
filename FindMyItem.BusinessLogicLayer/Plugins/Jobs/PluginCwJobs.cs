using FindMyItem.Domain;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginCwJobs : PluginBaseBLL
    {
        private const string HTML_OBJECT_XPATH = "//span[@class='page-header-job-count brand-font']";

        public PluginCwJobs(Site site, string item, CategoryType cat)
            : base(site, item, cat, HTML_OBJECT_XPATH) { }
    }
}