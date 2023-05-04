using GuessThatPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace GuessThatPokemon.Controllers
{
    public class AuthController : BaseController
    {
        AuthService service = new AuthService();

        public IActionResult Login()
        {
            if(IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // Show login page
            return View(new AuthModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(AuthModel model)
        {
            // On bad model
            if (!ModelState.IsValid)
            {
                // Bad Signup
                model.Password = string.Empty;
                return View(model);
            }

            var response = await service.Login(model.Username, model.Password);
            model.Password = string.Empty;
            if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }

            UserID = response.Id;
            // Show login page
            return RedirectToAction("Index","Home");
        }

        public IActionResult SignUp() 
        {
            if (IsLoggedIn)
            {
                return RedirectToAction("Index", "Home");
            }
            // Show login page
            return View(new AuthModel());
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(AuthModel model) 
        {
            // On bad model
            if (!ModelState.IsValid)
            {
                // Bad Signup
                model.Password = string.Empty;
                return View(model);
            }

            //Try to resgister
            var response = await service.SignUp(model.Username, model.Password);
            model.Password = string.Empty;
            if (!response.Success)
            {
                ModelState.AddModelError("", response.Message);
                return View(model);
            }

            UserID = response.Id;

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout() 
        {
            UserID = "";

            return RedirectToAction("Index", "Home");
        }
    }
}
