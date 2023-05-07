using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace APIService.Models
{
    public class EncounterHistoryModel
    {
        [JsonPropertyName("pokedex_num")]
        public int PokedexNum { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type_1")]
        public string Type1 { get; set; }

        [JsonPropertyName("type_2")]
        public string Type2 { get; set; }

        [JsonPropertyName("ability")]
        public string Ability { get; set; }

        [JsonPropertyName("ability_description")]
        public string AbilDesc { get; set; }

        [JsonPropertyName("location")]
        public string Location { get; set; }

        [JsonPropertyName("sprite")]
        public string Sprite { get; set; }

        [JsonPropertyName("caught")]
        public bool Caught { get; set; }

        [JsonPropertyName("time_caught")]
        public DateTime TimeStamp { get; set; }

        public EncounterHistoryModel(EncounterHistoryRecordModel record) 
        {
            PokedexNum = record.PokedexNum;
            Name = record.Name;
            Type1 = record.Type1;
            Type2 = record.Type2;
            Ability = record.Ability;
            AbilDesc = record.AbilDesc;
            Location = record.Location;
            Sprite = record.Sprite;
            Caught = record.Caught;
            TimeStamp = record.TimeStamp;
        }
    }
}
