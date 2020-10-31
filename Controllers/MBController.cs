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

        [ParpareDepartmentListForDropDownList]
        public ActionResult CoursesBatchEdit(bool isEditMode = false)
        {
            ViewData.Model = repoCourse.All();

            ViewBag.isEditMode = isEditMode;

            //ViewBag.DepartmentList = repoDepart.All().Select(p => new { p.DepartmentID, p.Name }).ToList();


            return View();
        }

        [ParpareDepartmentListForDropDownList]
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

            //ViewBag.DepartmentID = new SelectList(repoDepart.All(), "DepartmentID", "Name");

            return View(repoCourse.All());
        }

        [HttpPost]
        public ActionResult CourseBatchEditLazyBinding(FormCollection form, bool IsEditMode = false)
        {
            List<CourseEditView> data = new List<CourseEditView>();

            //try
            //{
            //    UpdateModel(data);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            if (TryUpdateModel(data))
            {
                foreach (var item in data)
                {
                    var course = repoCourse.All().FirstOrDefault(p => p.CourseID == item.CourseID);
                    course.InjectFrom(item);
                }
                repoCourse.UnitOfWork.Commit();

                TempData["CourseBatchEditResult"] = "批次更新成功！";

                return RedirectToAction("CoursesBatchEdit");
            }

            ViewBag.IsEditMode = IsEditMode;

            ViewBag.DepartmentID = new SelectList(repoDepart.All(), "DepartmentID", "Name");

            return View("CoursesBatchEdit", repoCourse.All());
        }
    }

    public class ParpareDepartmentListForDropDownListAttribute : ActionFilterAttribute
    {
        DepartmentRepository repo = RepositoryHelper.GetDepartmentRepository();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.Controller.ViewBag.DepartmentList = repo.All().Select(p => new { p.DepartmentID, p.Name }).ToList();

            base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);
        }
    }
}