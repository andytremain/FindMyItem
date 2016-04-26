using System.Web.Mvc;

namespace FindMyItem.WebUI.Controllers
{
    public class ErrorController : BaseController
    {
        //
        // GET: /Error/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        public ActionResult HttpError404()
        {
            ViewBag.ErrorMessage = "The page requested could not be found.";
            return View("Index");
        }

        public ActionResult HttpError500()
        {
            ViewBag.ErrorMessage = "Sorry but we've encountered a server error.";
            return View("Index");
        }

        public ActionResult General()
        {
            ViewBag.ErrorMessage = "Error occured.";
            return View("Index");
        }
    }
}
