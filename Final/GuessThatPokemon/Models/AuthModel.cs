using Service.Decorators;
using System.Text.Json.Serialization;

namespace GuessThatPokemon.Models
{
    public class AuthModel
    {
        [StringSize(3)]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [StringSize(9)]
        [Password]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}
