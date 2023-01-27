using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZooClassDemo.Models;

namespace ZooClassDemo.Controllers
{
    public class AnimalController : Controller
    {
        static List<AnimalModel> animals;

        // GET: Animal
        public ActionResult Index()
        {
            if(animals == null)
            {
                animals = new List<AnimalModel>();
            }

            return View(animals);
        }

        // GET: Animal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Animal/Create
        public ActionResult Create()
        {
            return View(new AnimalModel());
        }

        // POST: Animal/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var newAnimal = new AnimalModel();
                newAnimal.Name = collection["Name"];
                newAnimal.Id = Int32.Parse(collection["Id"]);
                animals.Add(newAnimal);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Animal/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Animal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Animal/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
