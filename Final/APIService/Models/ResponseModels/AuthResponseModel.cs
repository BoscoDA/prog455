using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIService.Models.ResponseModels
{
    public class AuthResponseModel : ResponseBase
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
}
