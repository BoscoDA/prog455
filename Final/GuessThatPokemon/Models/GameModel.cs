using Newtonsoft.Json;

namespace GuessThatPokemon.Models
{
    public class GameModel
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("encounter")]
        public EncounterModel? Encounter { get; set; }

        [JsonProperty("guesses")]
        public List<string> Guesses { get; set; }

        public GameModel()
        {
            Guesses = new List<string>();
        }

        public GameModel(Guid id, EncounterModel answer)
        {
            Id = id;
            Encounter = answer;
            Guesses = new List<string>();
        }

        public void AddGuess(string guess)
        {
            Guesses.Add(guess);
        }

        public static GameModel? FromJson(string? json)
        {
            if (string.IsNullOrWhiteSpace(json)) { return null; }
            return JsonConvert.DeserializeObject<GameModel>(json);
        }
        public string toJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
