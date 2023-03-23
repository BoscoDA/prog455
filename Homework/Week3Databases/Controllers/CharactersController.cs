using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week3Databases;
using Week3Databases.Services;

namespace Week3Databases.Controllers
{
    public class CharactersController : Controller
    {
        private PROG455FA23Entities db = new PROG455FA23Entities();
        private Service CharacterService = new Service();

        // GET: Characters
        public ActionResult Index()
        {
            try
            {
                var characters = CharacterService.ReturnCharacterList();

                return View(characters);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Character character = CharacterService.ReturnCharacter(id);

                if (character == null)
                {
                    return HttpNotFound();
                }

                return View(character);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            try
            {
                return View(new Character());
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Element_Type,Job_Class,ATK,DEF,Mana,HP_Initial,HP_Max,NPC")] Character character)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CharacterService.CreateCharacter(character);
                    return RedirectToAction("Index");
                }

                return View(character);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Character character = CharacterService.ReturnCharacter(id);

                if (character == null)
                {
                    return HttpNotFound();
                }

                return View(character);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Element_Type,Job_Class,ATK,DEF,Mana,HP_Initial,HP_Max,NPC")] Character character)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    CharacterService.EditCharacter(character);
                    return RedirectToAction("Index");
                }

                return View(character);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Character character = CharacterService.ReturnCharacter(id);

                if (character == null)
                {
                    return HttpNotFound();
                }

                return View(character);
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CharacterService.DeleteCharacter(id);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error", ex);
            }
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
