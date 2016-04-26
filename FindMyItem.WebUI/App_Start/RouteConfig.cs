using System.Web.Mvc;
using System.Web.Routing;

namespace FindMyItem.WebUI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*staticfile}", new { staticfile = @".*\.(css|js|gif|jpg|png|ico)(/.*)?" });
           // routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute("Search",
                "Search/{category}/{item}",
                new { controller = "Home", action = "Search" }
            ); //, category = UrlParameter.Optional

            routes.MapRoute("GoToSite",
                "{action}/{category}/{siteName}/{item}",
                new { controller = "Home", action = "GoToSite" }
            );

            //routes.MapRoute("RefreshSearchResults",
            //    "RefreshResults/{item}",
            //    new { controller = "Home", action = "Search" }
            //);

            //routes.MapRoute("GetRecentSearch",
            //    "GetRecentSearch/{category}/{item}",
            //    new { controller = "Home", action = "Search" }
            //);

            routes.MapRoute(
                "Pages",
                "{action}",
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}