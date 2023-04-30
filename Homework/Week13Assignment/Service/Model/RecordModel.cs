using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Service.Model
{
    public class RecordModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("uniformColor")]
        public int UniformColor { get; set; }

        [JsonPropertyName("gemStone")]
        public string GemStone { get; set; }

        [JsonPropertyName("hp")]
        public int HP { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("depthDived")]
        public int DepthDived { get; set; }
    }
}
