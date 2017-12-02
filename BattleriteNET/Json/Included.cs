using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Included {
        [JsonProperty("attributes")] public Attribute Attributes { get; set; }
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("links")] public Link Links { get; set; }
        [JsonProperty("relationships")] public Relationship Relationships { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        public partial class Relationship {
            [JsonProperty("assets")] public Assets Assets { get; set; }
            [JsonProperty("participants")] public Assets Participants { get; set; }
            [JsonProperty("player")] public Player Player { get; set; }
            [JsonProperty("team")] public Team Team { get; set; }
        }
    }
}
