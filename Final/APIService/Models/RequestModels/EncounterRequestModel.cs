using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIService.Models.RequestModels
{
    public class EncounterRequestModel
    {
        [JsonPropertyName("user_id")]
        public Guid UserID { get; set; }
    }
}
