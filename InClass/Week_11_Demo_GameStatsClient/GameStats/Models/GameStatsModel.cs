using System.Text.Json.Serialization;

namespace GameStats.Models
{
    public class GameStatsModel
    {
        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonPropertyName("playerName")]
        public string PlayerName { get; set; } = string.Empty;

        [JsonPropertyName("attempts")]
        public int Attempts { get; set; }


        [JsonPropertyName("duration")]
        public int Duration { get; set; }

        [JsonPropertyName("CorrectAnswer")]
        public int CorrectAnswer { get; set; }
    }
}
