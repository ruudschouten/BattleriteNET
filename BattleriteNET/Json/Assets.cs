using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Assets {
        [JsonProperty("data")]
        public Asset[] Data { get; set; }
    }

    public partial class Asset {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
