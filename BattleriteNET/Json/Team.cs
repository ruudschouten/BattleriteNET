using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Team {
        [JsonProperty("data")] public object Data { get; set; }
    }
}
