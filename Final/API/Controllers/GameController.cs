using APIService;
using APIService.Models.RequestModels;
using APIService.Models.ResponseModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        GameService _service = new GameService();

        [HttpPost]
        [Route("new-game")]
        public IActionResult NewGame([FromBody] GameRequestModel model)
        {
            Guid? user = new Guid(model.PlayerID);
            
            var response = _service.NewGame(user.Value);

            return Ok(new GameResponseModel()
            {
                Message = "New game created.",
                Success = true,
                GameId = response.GameId,
                Pokemon = response.Pokemon
            });

        }

        [HttpPost]
        [Route("guess")]
        public IActionResult Guess([FromBody]GameRequestModel model)
        {
            if (model.End.Value)
            {
                var game = _service.GetGameById(model.GameID);
                if (game == null)
                {
                    return NotFound(new GameResponseModel()
                    {
                        Message = "Game not found.",
                        Success = false,
                        GameId = null,
                        Pokemon = null
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
    }
}
