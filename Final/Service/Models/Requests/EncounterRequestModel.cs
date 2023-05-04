using System.Text.Json.Serialization;

namespace Service.Models.Requests
{
    public class EncounterRequestModel
    {
        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }
    }
}
