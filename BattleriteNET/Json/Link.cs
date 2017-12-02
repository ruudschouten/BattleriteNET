using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Link {
        [JsonProperty("schema")] public string Schema { get; set; }
        [JsonProperty("self")] public string Self { get; set; }
        [JsonProperty("next")] public string Next { get; set; }
    }
}
