using Service.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EncountersService
    {
        APICaller api = new APICaller();

        public async Task<EncountersResponseModel> GetAllEncounters(Guid userId)
        {
            var response = await api.GetAllEncounters(userId);
            return response;
        }
    }
}
