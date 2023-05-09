using GuessThatPokemon.Models;
using GuessThatPokemon.Models.Requests;
using GuessThatPokemon.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GuessThatPokemon
{
    public class APICaller
    {
        private static APICaller? _instance;

        private readonly HttpClient client = new HttpClient();
        private readonly string ApiUrl = "https://localhost:7267/api/";

        public static APICaller Instance()
        {
            if (_instance == null)
            {
                _instance = new APICaller();
            }
            return _instance;
        }

        /// <summary>
        /// Generic method used for deserializing response from the API calls
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        private T? Deserialize<T>(string? json)
        {
            return (json != null ? JsonSerializer.Deserialize<T>(json) : default(T));
        }

        /// <summary>
        /// Reusable method for making requests to the api using the url, verb and request provide
        /// </summary>
        /// <param name="url"></param>
        /// <param name="verb"></param>
        /// <param name="requestBody"></param>
        /// <returns></returns>
        private async Task<string?> MakeRequest(string url, HttpMethod verb, object requestBody)
        {
            string body = JsonSerializer.Serialize(requestBody);
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = verb,
                RequestUri = new Uri(url),
                Content = new StringContent(body, Encoding.UTF8, "application/json"),
            };

            var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result ?? null;
        }

        /// <summary>
        /// Makes a API request to the NewGame endpoint of the API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<GameResponseModel?> NewGame(string id)
        {
            try
            {
                string url = ApiUrl + "game/new-game";
                GameRequestModel request = new GameRequestModel()
                {
                    PlayerID = id

                };

                string? result = await MakeRequest(url, HttpMethod.Post, request);
                GameResponseModel? response = Deserialize<GameResponseModel?>(result);

                if (response == null)
                {
                    return new GameResponseModel()
                    {
                        Message = "Something went wrong...",
                        Success = false
                    };
                }

                return response;
            }
            catch (Exception ex)
            {
                return new GameResponseModel()
                {
                    Message = "Something went wrong...",
                    Success = false
                };
            }
        }

        /// <summary>
        /// Makes a API call to the End endpoint of the API
        /// </summary>
        /// <param name="gameId"></param>
        /// <param name="playerId"></param>
        /// <param name="pokemon"></param>
        /// <param name="hasWon"></param>
        /// <returns></returns>
        public async Task<GameResponseModel?> End(Guid gameId, string playerId, EncounterModel pokemon, bool hasWon)
        {
            string url = ApiUrl + "game/end";
            GameRequestModel? request = new GameRequestModel()
            {
                GameID = gameId,
                PlayerID = playerId,
                Pokemon = pokemon,
                Correct = hasWon,
                End = true
            };

            string? result = await MakeRequest(url, HttpMethod.Post, request);
            GameResponseModel? responseModel = Deserialize<GameResponseModel?>(result);
            return responseModel;
        }

        /// <summary>
        /// Makes a API request to the Signup endpoint of the API
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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
            return response ?? new AuthResponseModel() { Success = false, Id = "" };
        }

        /// <summary>
        /// Makes a API request to the Login endpoint of the API
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
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

        /// <summary>
        /// makes a API request to the GetAllEncounters endpoint of the API
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public async Task<EncounterHistoryResponseModel?> GetAllEncounters(Guid userID)
        {
            string url = ApiUrl + "encounters/get-all-by-user-id";
            EncounterHistoryRequestModel model = new EncounterHistoryRequestModel()
            {
                UserID = userID
            };
            string? result = await MakeRequest(url, HttpMethod.Get, model);
            EncounterHistoryResponseModel? response = Deserialize<EncounterHistoryResponseModel>(result);
            return response;
        }
    }
}
