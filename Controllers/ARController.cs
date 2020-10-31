using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;

namespace MVC5Demo.Controllers
{
    public class ARController : Controller
    {
        DepartmentRepository repoDepart;

        public ARController()
        {
            repoDepart = RepositoryHelper.GetDepartmentRepository();
        }

        // GET: AR
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewTest2()
        {
            return View("Index");
        }

        public ActionResult ViewTest3()
        {
            return View("TEMP");
        }

        public ActionResult ViewTest4()
        {
            return PartialView("Index");
        }

        public ActionResult ContentTest()
        {
            return Content("<root> 123 </root>", "text/xml", Encoding.GetEncoding("big5"));
        }

        public ActionResult FileTest(bool dl = false)
        {
            if (dl)
            {
                return File(Server.MapPath("~/Content/download.jpg"), "image/jpg", "MyAA.jpg");
            }
            else
            {
                return File(Server.MapPath("~/Content/download.jpg"), "image/jpg");
            }
        }

        public ActionResult JsonTest()
        {
            repoDepart.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repoDepart.GetDepartmentByID(1);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult JsonTest2()
        {
            repoDepart.UnitOfWork.Context.Configuration.LazyLoadingEnabled = false;
            var data = repoDepart.GetDepartmentByID(1);
            return Json(data);
        }
    }
}