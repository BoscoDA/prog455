using APIService;
using APIService.Models;
using APIService.Models.RequestModels;
using APIService.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncountersController : ControllerBase
    {
        EncountersService _service = new EncountersService();

        [HttpGet]
        [Route("get-all")]
        public IActionResult Index([FromBody]EncounterRequestModel model)
        {
            List<EncounterRecordModel> encounters = _service.GetAllEncounters(model.UserID);
            return Ok(new EncountersResponseModel()
            {
                Message = "Encounters grabbed successfully.",
                Success = true,
                Encounters = encounters
            });
        }
    }
}
