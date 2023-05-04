using Service.Models;
using Service.Models.Requests;
using Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Service
{
    public class APICaller
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string ApiUrl = "https://localhost:7267/api/";

        public APICaller() 
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Asp-Net MVC");
        }

        private T? Deserialize<T>(string? json)
        {
            try
            {
                return (json != null ? JsonSerializer.Deserialize<T>(json) : default(T));
            }
            catch (Exception ex)
            {
                // Error has occured
                return default(T);
            }
        }

        private async Task<string?> MakeRequest(string url, HttpMethod verb, object requestBody)
        {
            string body = JsonSerializer.Serialize(requestBody);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = verb,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            try
            {
                var response = await client.SendAsync(request);
                var result = await response.Content.ReadAsStringAsync();
                return result ?? null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<GameResponseModel?> NewGame(string id)
        {
            string url = ApiUrl + "game/new-game";
            GameRequestModel request = new GameRequestModel()
            {
                PlayerID = id,
            };
            string? result = await MakeRequest(url, HttpMethod.Post, request);
            GameResponseModel? response = Deserialize<GameResponseModel?>(result);
            return response;
        }

        public async Task<GameResponseModel?> Guess(Guid gameId, string playerId, PokemonModel pokemon, bool win, bool end)
        {
            string url = ApiUrl + "game/guess";
            GameRequestModel? request = new GameRequestModel()
            {
                GameID = gameId,
                PlayerID = playerId,
                Pokemon = pokemon,
                Correct = win,
                End = end
            };

            string? result = await MakeRequest(url, HttpMethod.Post, request);
            GameResponseModel? responseModel = Deserialize<GameResponseModel?>(result);
            return responseModel;
        }
        
        public async Task<PokemonModel?> GetPokemon(int id, bool auth)
        {
            string url = ApiUrl + "Pokemon/get-by-id";
            PokemonRequestModel model = new PokemonRequestModel()
            {
                Authorized = auth,
                PokemonID = id
            };

            string? result = await MakeRequest(url, HttpMethod.Get, model);
            PokemonModel? response = Deserialize<PokemonModel>(result);
            return response;
        }

        public async Task<AuthResponseModel?> Signup(string username, string password)
        {
            string url = ApiUrl + "auth/signup";
            AuthRequestModel model = new AuthRequestModel()
            {
                Username = username,
                Password = password
            };

            string? result = await MakeRequest(url, HttpMethod.Post, model);
            AuthResponseModel? response = Deserialize<AuthResponseModel?>(result);
            return response;
        }

        public async Task<AuthResponseModel?> Login(string username, string password)
        {
            string url = ApiUrl + "auth/login";
            AuthRequestModel model = new AuthRequestModel()
            {
                Username = username,
                Password = password
            };
            string? result = await MakeRequest(url, HttpMethod.Post, model);
            AuthResponseModel? response = Deserialize<AuthResponseModel>(result);
            return response;
        }

        public async Task<EncountersResponseModel?> GetAllEncounters(Guid userID)
        {
            string url = ApiUrl + "encounters/get-all";
            EncounterRequestModel model = new EncounterRequestModel()
            {
                UserID = userID
            };
            string? result = await MakeRequest(url, HttpMethod.Get, model);
            EncountersResponseModel? response = Deserialize<EncountersResponseModel>(result);
            return response;
        }
    }
}
