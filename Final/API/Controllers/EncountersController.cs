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

        /// <summary>
        /// Handles HTTP GET requests to retrieve all encounters for a given user ID.
        /// </summary>
        /// <param name="model">An EncounterRequestModel object containing the user ID for the encounters to retrieve</param>
        /// <returns>
        /// If retrieval is successful, returns an HTTP 200 OK response with an EncounterHistoryResponseModel object
        /// containing a success status, a message, and a list of EncounterHistoryModel objects representing the retrieved encounters.
        /// If retrieval fails due to an exception, returns an HTTP 400 Bad Request response with an EncounterHistoryResponseModel object
        /// containing a false success status, an error message, and a null list of EncounterHistoryModel objects.
        /// </returns>
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
