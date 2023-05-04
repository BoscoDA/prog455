using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PokemonModel
    {
        [JsonPropertyName("pokedex_number")]
        public int? PokedexNumber { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type_1")]
        public string? Type1 { get; set; }

        [JsonPropertyName("type_2")]
        public string? Type2 { get; set; }

        [JsonPropertyName("ability")]
        public string? Ability { get; set; }

        [JsonPropertyName("ability_description")]
        public string? AbilityDescription { get; set; }

        [JsonPropertyName("sprite_location")]
        public string? SpriteLocation { get; set; }

        [JsonPropertyName("outline_location")]
        public string? OutlineLocation { get; set; }

        [JsonPropertyName("location_met")]
        public string? LocationMet { get; set; }


    }
}
