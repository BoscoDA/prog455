using Microsoft.AspNetCore.Mvc;
using APIService.Models;
using APIService.Data_Access_Layers;
using APIService.Models.RequestModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private DAL _dataService = new DAL();
        private Random _random = new Random();

        [HttpGet]
        [Route("get-by-id")]
        public PokemonModel GetById([FromBody] PokemonRequestModel model)
        {

            var pokemon = _dataService.GetById(model.PokemonID);
            var location = _dataService.GetLocationsMetByPokemonId(model.PokemonID);
            if(location.Count <= 0)
            {
                pokemon.LocationMet = "Evolution";
            }
            else
            {
                pokemon.LocationMet = location[_random.Next(0, location.Count)];
            }

            return pokemon;

        }
    }
}
