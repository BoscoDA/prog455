using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIService.Models.ResponseModels
{
    public class GameResponseModel : ResponseBase
    {
        [JsonPropertyName("game_id")]
        public Guid? GameId { get; set; }

        [JsonPropertyName("pokemon")]
        public PokemonModel? Pokemon { get; set; }
    }
}
