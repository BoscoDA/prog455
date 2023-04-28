using System.Text.Json.Serialization;

namespace LeoAPI.Model
{
    
    public class GameApiModel
    {
        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonPropertyName("playerName")]
        public string PlayerName { get; set; } = string.Empty;

        [JsonPropertyName("attempts")]
        public int Attempts { get; set; }

        [JsonPropertyName("startTime")]
        public DateTime StartTime { get; set; }

        [JsonPropertyName("endTime")]
        public DateTime EndTime { get; set; }

        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("CorrectAnswer")]
        public int CorrectAnswer { get; set; }

    }
}
