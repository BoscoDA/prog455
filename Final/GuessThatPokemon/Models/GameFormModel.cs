using System.ComponentModel.DataAnnotations;

namespace GuessThatPokemon.Models
{
    public class GameFormModel
    {
        [Required]
        public string Guess { get; set; }

        public GameFormModel()
        {
            Guess = "";
        }
    }
}
