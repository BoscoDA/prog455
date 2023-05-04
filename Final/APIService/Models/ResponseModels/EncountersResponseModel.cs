using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIService.Models.ResponseModels
{
    public class EncountersResponseModel : ResponseBase
    {
        [JsonPropertyName("encounters")]
        public List<EncounterRecordModel>? Encounters { get; set; }
    }
}
