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
        static List<Person> data = new List<Person>()
            {
                new Person() {Id = 1, Name = "A", Age = 18},
                new Person() {Id = 2, Name = "B", Age = 19},
                new Person() {Id = 3, Name = "C", Age = 20},
                new Person() {Id = 4, Name = "D", Age = 21},

            };

        // GET: Test
        public ActionResult Index()
        {
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {
            if (ModelState.IsValid)
            {
                data.Add(person);

                return RedirectToAction("Index");
            }

            return View(person);

        }

        public ActionResult Edit(int id)
        {

            return View(data.FirstOrDefault(p=> p.Id.Equals(id)));
        }

        [HttpPost]
        public ActionResult Edit(int id, Person person)
        {
            if (ModelState.IsValid)
            {
                var tmp = data.FirstOrDefault(p => p.Id.Equals(id));
                if (tmp != null)
                {
                    tmp.Name = person.Name;
                    tmp.Age = person.Age;
                }
                return RedirectToAction("Index");
            }

            return View(person);
        }

        public ActionResult Delete(int id)
        {
            var tmp = data.FirstOrDefault(p => p.Id.Equals(id));
            return View(tmp);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection fc)
        {
            if (ModelState.IsValid)
            {
                data.Remove(data.FirstOrDefault(p => p.Id.Equals(id)));

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var tmp = data.FirstOrDefault(p => p.Id.Equals(id));
            return View(tmp);
        }
    }
}