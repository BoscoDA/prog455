using GuessThatPokemon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol;
using Service;
using System.Reflection;

namespace GuessThatPokemon.Controllers
{
    public class GameController : BaseController
    {
        GameService gameService = new GameService();

        public GameModel? gameModel
        {
            get
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    if (!HttpContext.Session.TryGetValue("GameModel", out byte[]? data))
                    {
                        HttpContext.Session.SetString("GameModel", new GameModel().toJson());
                    }
                    return GameModel.FromJson(HttpContext.Session.GetString("GameModel")) ?? null;
                }
                return null;
            }
            set
            {
                if (HttpContext != null && HttpContext.Session.IsAvailable)
                {
                    if (value == null)
                    {
                        HttpContext.Session.SetString("GameModel", string.Empty);
                    }
                    else
                    {
                        HttpContext.Session.SetString("GameModel", value.toJson());
                    }
                }
                else
                {
                    if (HttpContext == null)
                    {
                        throw new NullReferenceException("HttpContext is null.");
                    }
                    else
                    {
                        throw new Exception("HttpContext is inaccessible.");
                    }
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //Check if the user logged in
            if(!IsLoggedIn)
            {
                return RedirectToAction("Login", "Auth");
            }

            Random rand = new Random();
            GameFormModel model = new GameFormModel();

            //Set up new game on database and gets its id
            var NewGameResponse = await gameService.NewGame(UserID);

            if(!NewGameResponse.Success) 
            {
                ModelState.AddModelError("", "An unknown error has occured...");
                return View(model);
            }

            // Create new game
            var gm = new GameModel(NewGameResponse.GameId.Value, NewGameResponse.Pokemon);


            gameModel = gm;
            ViewBag.Game = gm;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]GameFormModel model)
        {
            var gm = gameModel;

            if (!ModelState.IsValid)
            {
                model.Guess = string.Empty;
                gameModel = gm;
                ViewBag.Game = gm;
                return View(model);
            }

            

            gm.AddGuess(model.Guess);

            var response = await gameService.Guess(gm.Id, UserID, gm.Answer, model.Guess, gm.Guesses.Count);
            if (!response.Success)
            {
                // Some unknown problem has occured
                ModelState.AddModelError("", "An unknown error has occured...");
                return View(model);
            }

            bool end = gameService.HasWin(gm.Answer.Name, model.Guess) || gameService.HasEnd(gm.Guesses.Count);
            if (end)
            {
                gm = null;
                gameModel = gm;
                ViewBag.Game = gm;
                return RedirectToAction("Index", "Home");
            }
            model.Guess = "";

            gameModel = gm;
            ViewBag.Game = gm;
            return View(model);
        }
    }
}
