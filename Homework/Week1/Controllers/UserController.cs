using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week1.Models;

namespace Week1.Controllers
{
    public class UserController : Controller
    {
        // needs to be static so the list of users persists through the lifetime of the application
        static List<UserModel> users = new List<UserModel>();

        // GET: UserController
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            //returned view needs the user associated with the id passed in
            return View(users.Where(d => d.Id == id).FirstOrDefault());
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View(new UserModel());
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                var newUser = new UserModel();
                newUser.FirstName = collection["FirstName"];
                newUser.LastName = collection["LastName"];
                newUser.Age = Int32.Parse(collection["Age"]);
                newUser.Occupation = collection["Occupation"];

                users.Add(newUser);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(users.Where(d => d.Id == id).FirstOrDefault());
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                var editedUser = users.Where(d => d.Id == id).FirstOrDefault();
                editedUser.FirstName = collection["FirstName"];
                editedUser.LastName = collection["LastName"];
                editedUser.Age = Int32.Parse(collection["Age"]);
                editedUser.Occupation = collection["Occupation"];

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult YearBorn(int id)
        {
            return View(users.Where(d => d.Id == id).FirstOrDefault());
        }
    }
}
