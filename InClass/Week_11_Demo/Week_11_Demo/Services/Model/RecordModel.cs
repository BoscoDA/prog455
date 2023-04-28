using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Services.Model
{
    public  class RecordModel
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
