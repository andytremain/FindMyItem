using System;
using System.Reflection;
using FindMyItem.Domain;
using FindMyItem.Common;
using System.Web;

namespace FindMyItem.BusinessLogicLayer.Plugins
{
    public class PluginBLL
    {
        private readonly Site _site;
        private readonly string _item;
        private readonly CategoryType _cat;

        public PluginBLL(Site site, string item, CategoryType cat)
        {
            _site = site;
            _item = HttpUtility.UrlDecode(item);
            _cat = cat;
        }

        public WebSiteSearchResult Search()
        {
            var assembly = Assembly.GetExecutingAssembly();

            try
            {
                dynamic instance = assembly.CreateInstance(_site.PluginName, false, BindingFlags.CreateInstance, null,
                                                        new object[] { _site, _item, _cat }, null, new object[] { });

                instance.Process();

                Type classType = instance.GetType();
                var property = classType.GetProperty(Constants.FIELD_RESULT);

                return (WebSiteSearchResult)property.GetValue(instance, null);
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
    }
}
