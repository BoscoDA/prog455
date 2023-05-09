using System.Text.Json.Serialization;

namespace GuessThatPokemon.Models
{
    public class EncounterModel
    {
        [JsonPropertyName("id")]
        public Guid ID { get; set; }

        [JsonPropertyName("pokedex_num")]
        public int PokedexNum { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("type_1")]
        public string? Type1 { get; set; }

        [JsonPropertyName("type_2")]
        public string? Type2 { get; set; }

        [JsonPropertyName("ability")]
        public string? Ability { get; set; }

        [JsonPropertyName("ability_description")]
        public string? AbilDesc { get; set; }

        [JsonPropertyName("location")]
        public string? Location { get; set; }

        [JsonPropertyName("sprite")]
        public string? Sprite { get; set; }

        [JsonPropertyName("caught")]
        public bool Caught { get; set; }
    }
}
