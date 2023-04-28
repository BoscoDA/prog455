using GameStats.Models;
using System.Net.Http.Headers;

namespace GameStats.Service
{
    public class WebServiceClient
    {
        static HttpClient client = new HttpClient();

        public List<GameStatsModel> GetAllStats()
        {
            client.BaseAddress = new Uri("https://localhost:7258/api/Game/get-all");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(client.BaseAddress).Result;

            List<GameStatsModel> stats = new List<GameStatsModel>();

            if (response.IsSuccessStatusCode)
            {
               return response.Content.ReadFromJsonAsync<List<GameStatsModel>>().Result;
            }

            return new List<GameStatsModel>();
        }
    }
}
