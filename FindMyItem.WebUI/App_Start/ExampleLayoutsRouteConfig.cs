using System.Web.Routing;

namespace BootstrapMvcSample
{
    public class ExampleLayoutsRouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.MapNavigationRoute<HomeController>("Automatic Scaffolding", c => c.Index());

            //routes.MapNavigationRoute<HomeController>("Example Layouts", c => c.Starter())
            //      .AddChildRoute<HomeController>("Marketing", c => c.Marketing())
            //      .AddChildRoute<HomeController>("Fluid", c => c.Fluid())
            //      .AddChildRoute<HomeController>("Sign In", c => c.SignIn())
            //    ;
        }
    }
}
