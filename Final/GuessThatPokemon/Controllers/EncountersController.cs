using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Models;

namespace GuessThatPokemon.Controllers
{
    public class EncountersController : BaseController
    {
        public EncountersService _service = new EncountersService();

        public async Task<IActionResult> Index()
        {
            if (!IsLoggedIn)
            {
                return RedirectToAction("Login", "Auth");
            }
            List<EncounterRecordModel> _encounters = new List<EncounterRecordModel>();
            var response = await _service.GetAllEncounters(new Guid(UserID));

            _encounters = response.Encounters;
            return View(_encounters);
        }
    }
}
