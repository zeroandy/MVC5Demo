using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;

namespace MVC5Demo.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var data = new List<Person>()
            {
                new Person() {Id = 1, Name = "A", Age = 18},
                new Person() {Id = 2, Name = "B", Age = 19},
                new Person() {Id = 3, Name = "C", Age = 20},
                new Person() {Id = 4, Name = "D", Age = 21},

            };


            return View(data);
        }
    }
}