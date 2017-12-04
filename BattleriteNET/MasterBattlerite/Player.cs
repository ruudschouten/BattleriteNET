using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.MasterBattlerite {
    public partial class PlayerContainer {
        [JsonProperty("player")]
        public Player Player { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class Player {
        [JsonProperty("avatar")]
        public long Avatar { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public long Title { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
