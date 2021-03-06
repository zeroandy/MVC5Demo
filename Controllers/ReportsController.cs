﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;
using MVC5Demo.Models.VIewModel;

namespace MVC5Demo.Controllers
{
    public class ReportsController : BaseController
    {
        private ContosoUniversityEntities db = new ContosoUniversityEntities();
        StringBuilder sb = new StringBuilder();
        public ReportsController()
        {
            db.Database.Log = (msg) =>
            {
                //Debug.WriteLine("----------------------");
                //Debug.WriteLine(msg);
                //Debug.WriteLine("----------------------");
                sb.AppendLine(msg);
                sb.AppendLine("-----------------------------------------");
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
            ViewBag.SQL = sb.ToString();

            return View(data);
        }

        public ActionResult CoursesReport2()
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"select Course.CourseID,Course.Title as CourseName,
(select COUNT(CourseID) from CourseInstructor where (CourseID = Course.CourseID)) as TeacherCount,
(select COUNT(CourseID) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as StudentCount,
(select AVG(CAST(Grade as Float)) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as AvgGrade
from Course ").ToList();

            ViewBag.SQL = sb.ToString();

            return View("CoursesReport1", data);
        }

        public ActionResult CoursesReport3(int id)
        {
            var data = db.Database.SqlQuery<CoursesReport1VM>(@"select Course.CourseID,Course.Title as CourseName,
(select COUNT(CourseID) from CourseInstructor where (CourseID = Course.CourseID)) as TeacherCount,
(select COUNT(CourseID) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as StudentCount,
(select AVG(CAST(Grade as Float)) from Enrollment where (Course.CourseID = Enrollment.CourseID)) as AvgGrade
from Course
where Course.CourseID = @p0 ", id).ToList();

            ViewBag.SQL = sb.ToString();
            return View("CoursesReport1", data);
        }

        public ActionResult CoursesReport4(int id)
        {
            var data = db.GetCourseReport(id).First();

            ViewBag.SQL = sb.ToString();
            return View(data);
        }

        public ActionResult CoursesReport5(int id)
        {
            var data = db.Database.SqlQuery<GetCourseReport_Result>(@"EXEC GetCourseReport @p0", id).First();

            ViewBag.SQL = sb.ToString();
            return View("CoursesReport4", data);
        }
    }
}