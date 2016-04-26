using System.Web.Http;

namespace FindMyItem.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "SimpleApi",
                routeTemplate: "{controller}/{action}"
            );

            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "{controller}/{category}/{item}"
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
