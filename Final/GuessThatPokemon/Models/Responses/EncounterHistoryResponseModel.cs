using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GuessThatPokemon.Models.Responses
{
    public class EncounterHistoryResponseModel : ResponseBase
    {
        [JsonPropertyName("encounters")]
        public List<EncounterHistoryModel> Encounters { get; set; }
    }
}
