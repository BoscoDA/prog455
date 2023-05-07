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

        public async Task<IActionResult> Index()
        {
            try
            {
                //Check if the user logged in
                if (!IsLoggedIn)
                {
                    return RedirectToAction("Login", "Auth");
                }

                Random rand = new Random();
                GameFormModel model = new GameFormModel();

                //Set up new game on database and gets its id
                var NewGameResponse = await api.NewGame(UserID);

                if (!NewGameResponse.Success)
                {
                    ModelState.AddModelError("", NewGameResponse.Message);
                    return View(model);
                }

                // Create new game
                var gm = new GameModel(NewGameResponse.GameId.Value, NewGameResponse.Encounter);


                gameModel = gm;
                ViewBag.Game = gm;
                return View(model);
            }
            catch (Exception ex)
            {
                DBLogger.Log("ERROR", "An execption was thrown by Game Index()", ex);
                return View("Error", ex);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm]GameFormModel model)
        {
            try
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


                bool end = gameService.HasWin(gm.Encounter.Name, model.Guess) || gameService.HasEnd(gm.Guesses.Count);


                if (end)
                {
                    bool won = gameService.HasWin(gm.Encounter.Name, model.Guess);
                    var response = await api.End(gm.Id, UserID, gm.Encounter, won);

                    if (!response.Success)
                    {
                        // Some unknown problem has occured
                        ModelState.AddModelError("", response.Message);
                        return View(model);
                    }
                    if (end)
                    {
                        gm = null;
                        gameModel = gm;
                        ViewBag.Game = gm;
                        return RedirectToAction("Index", "EncounterHistory");
                    }
                }

                model.Guess = "";

                gameModel = gm;
                ViewBag.Game = gm;
                return View(model);
            }
            catch(Exception ex) 
            {
                DBLogger.Log("ERROR", "An execption was thrown by Game Index()", ex);
                return View("Error", ex);
            }
            
        }
    }
}
