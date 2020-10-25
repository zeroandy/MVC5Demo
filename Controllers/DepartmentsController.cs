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
    public class DepartmentsController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        // GET: Departments
        public ActionResult Index()
        {

            return View(db.Department.ToList() );
        }

        public ActionResult Details(int? id)
        {

            return View(db.Department.Find(id));
        }

        public ActionResult Create()
        {
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p=>p.FirstName), "ID", "FirstName");
            return View();
        }

        [HttpPost]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p=>p.FirstName), "ID", "FirstName");

            return View(department);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return this.HttpNotFound();
            }
            var item = db.Department.Find(id);
            ViewBag.InstructorID = new SelectList(db.Person.OrderBy(p=>p.FirstName), "ID", "FirstName", item.InstructorID);

            return View(item);
        }

        [HttpPost]
        public ActionResult Edit(int id, DepartmentEdit department)
        {
            if (ModelState.IsValid)
            {
                var item = db.Department.Find(id);

                item.InjectFrom(department);

                //item.Budget = department.Budget;
                //item.Name = department.Name;
                //item.StartDate = department.StartDate;
                //item.InstructorID = department.InstructorID;

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            var newItem = db.Department.Find(id);

            ViewBag.InstructorID = new SelectList(db.Person, "ID", "FirstName", newItem.InstructorID);

            return View(newItem);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var item = db.Department.Find(id);

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
                var item = db.Department.Find(id);

                if (item == null)
                {
                    return HttpNotFound();
                }

                db.Department.Remove(item);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}