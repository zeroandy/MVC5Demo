﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5Demo.Models;

namespace MVC5Demo.Controllers
{
    public class TestController : BaseController
    {
        static List<MyPerson> data = new List<MyPerson>()
            {
                new MyPerson() {Id = 1, Name = "A", Age = 18},
                new MyPerson() {Id = 2, Name = "B", Age = 19},
                new MyPerson() {Id = 3, Name = "C", Age = 20},
                new MyPerson() {Id = 4, Name = "D", Age = 21},

            };

        // GET: Test
        public ActionResult Index()
        {
            return View(data);
        }

        public ActionResult Create()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MyPerson person)
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
        public ActionResult Edit(int id, MyPerson person)
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