using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Player {
        [JsonProperty("data")] public PlayerData Data { get; set; }
    }
    public partial class PlayerData {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
    }
}
