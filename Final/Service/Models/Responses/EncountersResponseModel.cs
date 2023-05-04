using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Models.Responses
{
    public class EncountersResponseModel : ResponseBase
    {
        [JsonPropertyName("encounters")]
        public List<EncounterRecordModel> Encounters { get; set; }
    }
}
