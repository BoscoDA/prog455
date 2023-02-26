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
using Week5AuthenticationAuthorization.Services;
using Week5AuthenticationAuthorization.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace Week5AuthenticationAuthorization.Controllers
{
    public class UsersController : Controller
    {
        private PROG455SP23Entities db = new PROG455SP23Entities();
        private AuthorizationService authorizationService = new AuthorizationService();
        private DBService dbService = new DBService();

        // GET: Users
        public ActionResult Index()
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
                {
                    var currentUser = dbService.GetUserFromDB((string)Session["User_ID"]);

                    if (authorizationService.IsAuthorized("Index", currentUser) == true)
                    {
                        var users = dbService.GetUserListFromDB();
                        return View(users);
                    }

                    return RedirectToAction("Login");
                }
                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch(Exception ex)
            {
                return View("Error", ex); 
            }
            
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
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
                    return RedirectToAction("Login");
                }
            }

            catch(Exception ex)
            {
                LogOut();
                return View("Error", ex);
            }
            
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
                {
                    var currentUser = dbService.GetUserFromDB((string)Session["User_Id"]);

                    if (authorizationService.IsAuthorized("Create", currentUser) == true)
                    {
                        return View(new User());
                    }
                    ViewBag.Message = "Not authorized to use that function.";
                    return RedirectToAction("Index", dbService.GetUserListFromDB());
                }
                else
                {
                    return RedirectToAction("Login", new User());
                }
            }
            catch(Exception ex)
            {
                return View("Error", ex);
            }
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Username,Password,First_Name,Last_Name,Role")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbService.CreateUser(user);
                    return RedirectToAction("Index");
                }

                return View(user);
            }

            catch(Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
                {
                    var currentUser = dbService.GetUserFromDB((string)Session["User_Id"]);
                    if (authorizationService.IsAuthorized("Edit", currentUser) == true)
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

                    ViewBag.Message = "Not authorized to use that function.";
                    return RedirectToAction("Index", dbService.GetUserListFromDB());
                }

                else
                {
                    return RedirectToAction("Login");
                }
            }

            catch(Exception ex)
            {
                return View("Error",ex);
            }

            
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Username,Password,First_Name,Last_Name,Role")] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    dbService.EditUser(user);
                    ModelState.AddModelError("auth", "TEST");
                    return RedirectToAction("Index");
                }
                return View(user);
            }

            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
                {
                    var currentUser = dbService.GetUserFromDB((string)Session["User_Id"]);

                    if (authorizationService.IsAuthorized("Delete", currentUser) == true)
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
                    ViewBag.Message = "Not authorized to use that function.";
                    return RedirectToAction("Index", dbService.GetUserListFromDB());

                }

                else
                {
                    return RedirectToAction("Login");
                }
            }
            catch(Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                dbService.DeleteUser(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
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

        public ActionResult Login()
        {
            try
            {
                if (Session["Authenticated"]?.Equals(true) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(new User());
                }
            }

            catch (Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Username,Password")] User user)
        {
            try
            {
                bool authorized = false;
                var foundUser = dbService.GetUserFromDB(user.Username);

                if (foundUser != null)
                {
                    authorized = SHA256Util.VerifyPasswordWithHash(user.Password, foundUser.Password);
                }

                if (authorized)
                {
                    Session.Add("Authenticated", true);
                    Session.Add("User_Id", foundUser.Username);
                    return RedirectToAction("Index", db.Users.ToList());
                }

                else
                {
                    Session.Add("Authenticated", false);
                    ModelState.AddModelError("Password", "Invalid Credentials");
                    ViewBag.Error = "Invalid credentials";
                    return View(new User());
                }
            }
            catch(Exception ex)
            {
                return View("Error", ex);
            }
            
        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Login");
        }
    }
}
