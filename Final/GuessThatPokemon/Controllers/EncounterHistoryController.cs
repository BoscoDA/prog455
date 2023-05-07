using GuessThatPokemon.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuessThatPokemon.Controllers
{
    public class EncounterHistoryController : BaseController
    {

        public async Task<IActionResult> Index()
        {
            try
            {
                if (!IsLoggedIn)
                {
                    return RedirectToAction("Login", "Auth");
                }
                var response = await api.GetAllEncounters(new Guid(UserID));
                if (!response.Success)
                {
                    ModelState.AddModelError("", response.Message);
                    return View(new List<EncounterHistoryModel>());
                }
                var _encounters = response.Encounters.OrderByDescending(x => x.TimeStamp);
                return View(_encounters);
            }
            catch (Exception ex)
            {
                DBLogger.Log("ERROR", "An execption was thrown by EcounterHistory Index()", ex);
                return View("Error",ex);
            }
        }
    }
}
