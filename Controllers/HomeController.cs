using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

#if !DEBUG
        [NonAction]
#endif
        [LocalOnly]
        public ActionResult Debug()
        {
            return Content("DEBUG");
        }
    }

    public class LocalOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //var ip = filterContext.HttpContext.Request.UserHostAddress;

            if (!filterContext.HttpContext.Request.IsLocal)
            {
                filterContext.Result = new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}