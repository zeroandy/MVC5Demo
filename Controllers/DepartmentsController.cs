using MVC5Demo.Models;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace MVC5Demo.Controllers
{
    public class DepartmentsController : BaseController
    {
        DepartmentRepository repoDepart;
        PersonRepository repoPerson;

        public DepartmentsController()
        {
            repoDepart = RepositoryHelper.GetDepartmentRepository();
            repoPerson = RepositoryHelper.GetPersonRepository(repoDepart.UnitOfWork);
        }
        // GET: Departments
        public ActionResult Index()
        {

            return View(repoDepart.All());
        }

        public ActionResult Details(int? id)
        {

            return View(repoDepart.GetDepartmentByID(id.Value));
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p=>p.FirstName), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                repoDepart.Add(department);
                repoDepart.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p=>p.FirstName), "ID", "FirstName");

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return this.HttpNotFound();
            }

            var item = repoDepart.GetDepartmentByID(id.Value);
            ViewBag.InstructorID = new SelectList(repoPerson.All().OrderBy(p=>p.FirstName), "ID", "FirstName", item.InstructorID);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = repoDepart.GetDepartmentByID(id);

                item.InjectFrom(department);


                repoDepart.UnitOfWork.Commit();

                return RedirectToAction("Index");
            }

            var newItem = repoDepart.GetDepartmentByID(id);

            ViewBag.InstructorID = new SelectList(repoPerson.All(), "ID", "FirstName", newItem.InstructorID);

            return View(newItem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = repoDepart.GetDepartmentByID(id.Value);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection frmc)
        {
            if (ModelState.IsValid)
            {
                var item = repoDepart.GetDepartmentByID(id);

                if (item == null)
                {
                    return HttpNotFound();
                }

                repoDepart.Delete(item);
                repoDepart.UnitOfWork.Commit();



                return RedirectToAction("Index");
            }

            return View();
        }


    }
}