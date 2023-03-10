using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Week4Databases;
using Week4Databases.Services;

namespace Week4Databases.Controllers
{
    public class CharactersController : Controller
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();
        private Service CharacterService = new Service();

        // GET: Characters
        public ActionResult Index()
        {
            var characters = CharacterService.ReturnCharacterList();

            if(characters == null)
            {
                return View();
            }

            return View(db.Characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
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

            if(character.Maps == null)
            {
                character.Maps = new List<Map>();
            }

            return View(character);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View("Create", new Character());
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Element_Type,Job_Class,ATK,DEF,Mana,HP_Initial,HP_Max,NPC")] Character character)
        {
            if (ModelState.IsValid)
            {
                CharacterService.CreateCharacter(character);
                return RedirectToAction("Index");
            }

            return View(new Character());
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
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

            return View(character); ;
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Element_Type,Job_Class,ATK,DEF,Mana,HP_Initial,HP_Max,NPC")] Character character)
        {
            if (ModelState.IsValid)
            {
                CharacterService.EditCharacter(character);
                return RedirectToAction("Index");
            }

            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CharacterService.DeleteCharacter(id);

            return RedirectToAction("Index");
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
