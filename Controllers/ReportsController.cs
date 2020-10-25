using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;
using MVC5Demo.Models.VIewModel;

namespace MVC5Demo.Controllers
{
    public class ReportsController : Controller
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();

        public ReportsController()
        {
            db.Database.Log = (msg) =>
            {
                Debug.WriteLine("----------------------");
                Debug.WriteLine(msg);
                Debug.WriteLine("----------------------");
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }

        // GET: Reports
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoursesReport1()
        {
            var data = (from c in db.Course
                select new CoursesReport1VM()
                {
                    CourseId = c.CourseID,
                    CourseName = c.Title,
                    StudentCount = c.Enrollments.Count(),
                    TeacherCount = c.Teachers.Count(),
                    AvgGrade = c.Enrollments.Where(e => e.Grade.HasValue).Average(e => e.Grade).Value
                }).ToList();
            return View(data);
        }

        public ActionResult CoursesReport2()
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"select Course.CourseID,Course.Title as CourseName,
(select COUNT(CourseID) from CourseInstructor where (CourseID = Course.CourseID)) as TeacherCount,
(select COUNT(CourseID) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as StudentCount,
(select AVG(CAST(Grade as Float)) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as AvgGrade
from Course ");
            return View("CoursesReport1", data);
        }

        public ActionResult CoursesReport3(int id)
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"select Course.CourseID,Course.Title as CourseName,
(select COUNT(CourseID) from CourseInstructor where (CourseID = Course.CourseID)) as TeacherCount,
(select COUNT(CourseID) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as StudentCount,
(select AVG(CAST(Grade as Float)) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as AvgGrade
from Course
where Course.CourseID = @p0 ", id);
            return View("CoursesReport1", data);
        }
    }
}