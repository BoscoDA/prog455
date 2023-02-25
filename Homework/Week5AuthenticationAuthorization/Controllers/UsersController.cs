using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using Week5AuthenticationAuthorization;
using Week5AuthenticationAuthorization.Utilities;

namespace Week5AuthenticationAuthorization.Controllers
{
    public class UsersController : Controller
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();

        // GET: Users
        public ActionResult Index()
        {
            var test = Session["Current_User"];
            var currentUser = db.Users.Where(x => x.Username == ((string)test)).FirstOrDefault();

            if (currentUser.Role == "User" || currentUser.Role == "Admin" || currentUser.Role == "Super Admin")
            {
                Session.Add("Authorized", true);
            }

            else
            {
                Session.Add("Authorized", false);
            }

            if (Session["Authorized"]?.Equals(true) == true)
            {
                return View(db.Users.ToList());
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.Users.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var test = Session["Current_User"];
            var currentUser = db.Users.Where(x => x.Username == ((string)test)).FirstOrDefault();

            if(currentUser.Role == "Admin" || currentUser.Role == "Super Admin")
            {
                Session.Add("Authorized", true);
            }

            else
            {
                Session.Add("Authorized", false);
            }

            if (Session["Authorized"]?.Equals(true) == true)
            {
                return View();
            }

            else
            {
                return View("Index", db.Users.ToList());
            }
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,First_Name,Last_Name,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = SHA256Util.CreateHash(user.Password);
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            var test = Session["Current_User"];
            var currentUser = db.Users.Where(x => x.Username == ((string)test)).FirstOrDefault();

            if (currentUser.Role == "Admin" || currentUser.Role == "Super Admin")
            {
                Session.Add("Authorized", true);
            }

            else
            {
                Session.Add("Authorized", false);
            }

            if (Session["Authorized"]?.Equals(true) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return View("Index", db.Users.ToList());
            }            
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,First_Name,Last_Name,Role")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            var test = Session["Current_User"];
            var currentUser = db.Users.Where(x => x.Username == ((string)test)).FirstOrDefault();

            if (currentUser.Role == "Super Admin")
            {
                Session.Add("Authorized", true);
            }

            else
            {
                Session.Add("Authorized", false);
            }

            if (Session["Authorized"]?.Equals(true) == true)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                User user = db.Users.Find(id);
                if (user == null)
                {
                    return HttpNotFound();
                }
                return View(user);
            }

            else
            {
                return View("Index", db.Users.ToList());
            }
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
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

        public ActionResult Login()
        {
            if (Session["Authorized"]?.Equals(true) == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(new User());
            }
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            bool authorized = false;
            var foundUser = db.Users.Where(x => x.Username == user.Username).FirstOrDefault();

            if (foundUser != null)
            {
                authorized = SHA256Util.VerifyPasswordWithHash(user.Password, foundUser.Password);
            }

            if (authorized)
            {
                Session.Add("Authorized", true);
                Session.Add("Current_User", foundUser.Username);
                return View("Index", db.Users.ToList());
            }

            else
            {
                Session.Add("Authorized", false);
                ModelState.AddModelError("Password", "Invalid Credentials");
                ViewBag.Error = "Invalid credentials";
                return View("Login", new User());
            }
        }

        public ActionResult LogOut()
        {
            Session.Add("Authorized", false);

            return RedirectToAction("Login");
        }
    }
}
