using API.Models.RequestModels;
using API.Models.ResponseModels;
using APIService;
using Logger;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        DBLogger _logger = DBLogger.Instance();
        GameService _service = new GameService();

        /// <summary>
        /// Handles HTTP POST requests to create a new game for the given player ID.
        /// </summary>
        /// <param name="model">A GameRequestModel object containing the player ID for the new game</param>
        /// <returns>
        /// If creation is successful, returns an HTTP 200 OK response with a GameResponseModel object containing
        /// a success status, a message, a new game ID, and an EncounterModel object representing the newly created
        /// Pokemon encounter.
        /// If creation fails due to an exception, returns an HTTP 400 Bad Request response with a GameResponseModel
        /// object containing a false success status, an error message, an empty game ID, and a null EncounterModel object.
        /// </returns>
        [HttpPost]
        [Route("new-game")]
        public IActionResult NewGame([FromBody] GameRequestModel model)
        {
            try
            {
                Guid? user = new Guid(model.PlayerID!);

                var response = _service.NewGame(user.Value);

                if(response.Id == null ||  response.Id == Guid.Empty) 
                {
                    throw new Exception("Error creating new game.");
                }

                if(response.Encounter == null)
                {
                    throw new Exception("Pokemon encounter could not be created.");
                }

                var encounter = _service.GetEncounterById(response.Encounter);

                return Ok(new GameResponseModel()
                {
                    Message = "New game created.",
                    Success = true,
                    GameId = response.Id,
                    Encounter = new Models.EncounterModel()
                    {
                        ID = encounter.ID,
                        PokedexNum = encounter.PokedexNum,
                        Name = encounter.Name,
                        Type1 = encounter.Type1,
                        Type2 = encounter.Type2,
                        Ability = encounter.Ability,
                        AbilDesc = encounter.AbilDesc,
                        Location = encounter.Location,
                        Sprite = encounter.Sprite,
                        Caught = encounter.Caught
                    }
                });
            }
            catch(Exception ex)
            {
                _logger.Log("ERROR","Exception thrown by NewGame()", ex);
                return BadRequest(new GameResponseModel()
                {
                    Message = "Exception was thrown.",
                    Success = false,
                    GameId = Guid.Empty,
                    Encounter = null
                });
            }
        }

        /// <summary>
        /// Handles HTTP POST requests to end the specified game and update its completion status and associated Pokemon encounter.
        /// </summary>
        /// <param name="model">A GameRequestModel object containing the game ID, a boolean flag indicating whether the game is ending, and a boolean flag indicating whether the player correctly guessed the Pokemon.</param>
        /// <returns>
        /// If the game is successfully updated, returns an HTTP 200 OK response with a GameResponseModel object containing
        /// a success status and a message.
        /// If the game cannot be updated due to an exception or if the specified game ID is not found in the database,
        /// returns an HTTP 404 Not Found response with a GameResponseModel object containing a false success status,
        /// an error message, an empty game ID, and a null EncounterModel object.
        /// </returns>
        [HttpPost]
        [Route("end")]
        public IActionResult End([FromBody]GameRequestModel model)
        {
            try
            {
                if (model.End!.Value)
                {
                    var game = _service.GetGameById(model.GameID);
                    if (game == null)
                    {
                        _logger.Log("WARNING",$"Failed to retrieve game {model.GameID} at {DateTime.Now}.");
                        return NotFound(new GameResponseModel()
                        {
                            Message = $"Unable to locate game {game!.Id}",
                            Success = false,
                            GameId = Guid.Empty,
                            Encounter = null
                        });
                    }

                    game.Completed = true;

                    _service.UpdateRecord(game);

                    var encounter = _service.GetEncounterById(game.Encounter);
                    if (model.Correct == true)
                    {
                        encounter.Caught = true;
                        _service.UpdateEncounter(encounter);
                    }

                }

                return Ok(new GameResponseModel()
                {
                    Message = "Game was updated.",
                    Success = true
                });
            }
            catch(Exception ex)
            {
                _logger.Log("ERROR","Exception thrown by Guess()", ex);
                return BadRequest(new GameResponseModel()
                {
                    Message = "Exception was thrown.",
                    Success = false
                });
            }
            
        }
    }
}
