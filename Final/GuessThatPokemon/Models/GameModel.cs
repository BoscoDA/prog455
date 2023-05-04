using Newtonsoft.Json;
using Service.Models;

namespace GuessThatPokemon.Models
{
    public class GameModel
    {
        [JsonProperty("id")]
        public Guid Id { get; private set; }

        [JsonProperty("answer")]
        public PokemonModel Answer { get; set; }

        [JsonProperty("guesses")]
        public List<string> Guesses { get; set; }

        public GameModel()
        {
            Answer = new PokemonModel();
            Guesses = new List<string>();
        }

        public GameModel(Guid id, PokemonModel answer)
        {
            Id = id;
            Answer = answer;
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
