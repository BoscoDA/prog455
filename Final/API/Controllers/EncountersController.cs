using API.Models.RequestModels;
using API.Models.ResponseModels;
using APIService;
using APIService.Models;
using Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncountersController : ControllerBase
    {
        DBLogger _logger = DBLogger.Instance();
        EncountersService _service = new EncountersService();

        [HttpGet]
        [Route("get-all-by-user-id")]
        public IActionResult Index([FromBody]EncounterRequestModel model)
        {
            try
            {
                List<EncounterHistoryRecordModel> records = _service.GetAllEncounters(model.UserID);

                List<EncounterHistoryModel> encounters = new List<EncounterHistoryModel>();

                foreach(var record in records)
                {
                    encounters.Add(new EncounterHistoryModel(record));
                }

                return Ok(new EncounterHistoryResponseModel()
                {
                    Message = "Encounters grabbed successfully.",
                    Success = true,
                    Encounters = encounters
                });
            }
            catch (Exception ex)
            {
                _logger.Log("ERROR","Exception thrown by GetAllEncounters()", ex);
                return BadRequest(new EncounterHistoryResponseModel()
                {
                    Message = "Exception was thrown.",
                    Success = false,
                    Encounters = null
                });
            }
            
        }
    }
}
