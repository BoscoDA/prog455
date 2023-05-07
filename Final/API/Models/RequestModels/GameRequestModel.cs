using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace API.Models.RequestModels
{
    public class GameRequestModel
    {
        [JsonPropertyName("player_id")]
        public string? PlayerID { get; set; }

        [JsonPropertyName("game_id")]
        public Guid GameID { get; set; }

        [JsonPropertyName("encounter")]
        public EncounterModel? Pokemon { get; set; }

        [JsonPropertyName("correct")]
        public bool? Correct { get; set; }

        [JsonPropertyName("end")]
        public bool? End { get; set; }
    }
}
