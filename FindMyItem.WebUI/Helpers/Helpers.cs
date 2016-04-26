using System.Collections.Generic;
using System.Web;

using FindMyItem.Common;
using FindMyItem.Domain;

using BLL = FindMyItem.BusinessLogicLayer;
using SearchViewModel = FindMyItem.WebUI.Models.SearchViewModel;

namespace FindMyItem.WebUI.Helpers
{
    public class Helpers 
    {
        public static Dictionary<CategoryType, SearchViewModel> GetRecentSearches()
        {
            Dictionary<CategoryType, SearchViewModel> returnValue = new Dictionary<CategoryType,SearchViewModel>();

            //var t = FindMyItem.BusinessLogicLayer.SessionHelpers.GetSessionRecentSearches();          

            if (HttpContext.Current.Session[Constants.RECENT_SEARCHES] != null)
            {
                returnValue = (Dictionary<CategoryType, SearchViewModel>)HttpContext.Current.Session[Constants.RECENT_SEARCHES];
            }

            return returnValue;
        }     
    }
}