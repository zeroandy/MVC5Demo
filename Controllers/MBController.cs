using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;
using Omu.ValueInjecter;

namespace MVC5Demo.Controllers
{
    public class MBController : Controller
    {
        DepartmentRepository repoDepart;
        private CourseRepository repoCourse;

        public MBController()
        {
            repoDepart = RepositoryHelper.GetDepartmentRepository();
            repoCourse = RepositoryHelper.GetCourseRepository();
        }
        // GET: MB
        public ActionResult Index(int id = 1)
        {
            if (id > 3)
            {
                var data = repoDepart.GetDepartmentByID(id);
                ViewData.Model = data;
            }
            else
            {
                var data = repoDepart.GetDepartmentByID(1);
                ViewData.Model = data;
            }

            ViewData["Key1"] = "Hello";
            ViewBag.Key2 = "World";

            TempData["Message"] = "2020/10/31";

            return View();
        }

        public ActionResult ReadTempData()
        {
            return View();
        }

        public ActionResult CoursesBatchEdit(bool isEditMode = false)
        {
            ViewData.Model = repoCourse.All();

            ViewBag.isEditMode = isEditMode;

            return View();
        }

        [HttpPost]
        public ActionResult CoursesBatchEdit(List<CourseEditView> data, bool isEditMode = false)
        {
            if (ModelState.IsValid)
            {
                foreach (var course in data)
                {
                    var newcourse = repoCourse.All().FirstOrDefault(p => p.CourseID.Equals(course.CourseID));
                    newcourse.InjectFrom(course);
                }

                repoCourse.UnitOfWork.Commit();

                TempData["CoursesBatchEditResult"] = "CoursesBatchEdit Completed!!";


                return RedirectToAction("CoursesBatchEdit");
            }

            ViewBag.isEditMode = isEditMode;

            return View(repoCourse.All());
        }
    }
}