using Service.Models;
using Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class GameService
    {
        APICaller api = new APICaller();
        readonly int maxGuess = 4;
        Random rand = new Random();

        public async Task<PokemonModel> GetPokemon(bool auth)
        {
            int pokemonIndex = rand.Next(1, 151);
            var response = await api.GetPokemon(pokemonIndex,auth);
            return response;
        }

        public async Task<GameResponseModel> NewGame(string id)
        {
            //Create the new game
            var response = await api.NewGame(id);
            if(response == null)
            {
                return new GameResponseModel()
                {
                    Message = "Something went wrong...",
                    Success = false
                };
            };

            return response;
        }

        public async Task<GameResponseModel> Guess(Guid gameId, string playerId, PokemonModel answer, string guess, int guessCount)
        {
            bool win = HasWin(answer.Name, guess);
            bool end = HasEnd(guessCount);
            var response = await api.Guess(gameId, playerId, answer, win, end||win);
            return response;
        }

        public bool HasWin(string answer, string guess)
        {
            return answer.ToLower() == guess.ToLower();
        }

        public bool HasEnd(int count)
        {
            return count + 1 > maxGuess;
        }
    }
}
