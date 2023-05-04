using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Models.Requests
{
    public class PokemonRequestModel
    {
        [JsonPropertyName("authorized")]
        public bool Authorized { get; set; }
        [JsonPropertyName("pokemon_id")]
        public int PokemonID { get; set; }
    }
}
