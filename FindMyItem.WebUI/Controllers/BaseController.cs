using System;
using System.Reflection;
using System.Web.Mvc;

using log4net;

namespace FindMyItem.WebUI.Controllers
{
    public class BaseController : Controller
    {
        private static readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().GetType());

        public void LogError(string message, Exception ex)
        {
            _log.Error(message, ex);
        }

        public void LogInfo(string message)
        {
            _log.Info(message);
        }
    }
}
