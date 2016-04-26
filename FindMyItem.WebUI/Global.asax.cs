using System;
using System.IO;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using FindMyItem.WebUI.Container;
using log4net;

namespace FindMyItem.WebUI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private IWindsorContainer _windsorContainer;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected void Application_Start()
        {
            var configFilePath = Server.MapPath("~/log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new FileInfo(configFilePath));

            log.Info("App started");

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BootstrapSupport.BootstrapBundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);
            BootstrapMvcSample.ExampleLayoutsRouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(System.Web.Optimization.BundleTable.Bundles);

            InitialiseWindsor();
        }

        private void InitialiseWindsor()
        {
            _windsorContainer = new WindsorContainer().Install(FromAssembly.This());

            var controllerFactory = new WindsorControllerFactory(_windsorContainer.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
           // Response.Redirect("~/home");
            var exception = Server.GetLastError();

            log.Error(exception.ToString());
            Response.Clear();

        //    HttpException httpException = exception as HttpException;

        //    if (httpException != null)
        //    {
        //        string action;

        //        switch (httpException.GetHttpCode())
        //        {
        //            case 404:
        //                // page not found
        //                action = "HttpError404";
        //                break;
        //            case 500:
        //                // server error
        //                action = "HttpError500";
        //                break;
        //            default:
        //                action = "General";
        //                break;
        //        }

        //        // clear error on server
        //        Server.ClearError();

                //String.Format("~/Error/{0}/?message={1}", action, exception.Message
        //        Response.Redirect(String.Format("~/Error/{0}", action));
        //    }
        }
    }
}