using System.Text.Json.Serialization;

namespace GuessThatPokemon.Models.Requests
{
    public class EncounterHistoryRequestModel
    {
        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }
    }
}
