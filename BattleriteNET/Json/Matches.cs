using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Matches {
        [JsonProperty("data")] public List<Match> Data { get; set; }
        [JsonProperty("included")] public List<Included> Included { get; set; }
        [JsonProperty("links")] public Link Links { get; set; }
        [JsonProperty("meta")] public Meta MatchMeta { get; set; }
        public partial class Meta { }
        public partial class Match {
            [JsonProperty("attributes")] public Attribute Attributes { get; set; }
            [JsonProperty("id")] public string Id { get; set; }
            [JsonProperty("links")] public Link Links { get; set; }
            [JsonProperty("relationships")] public Relationship Relationships { get; set; }
            [JsonProperty("type")] public string Type { get; set; }
        }
        public partial class Relationship {
            [JsonProperty("assets")] public Assets Assets { get; set; }
            [JsonProperty("rosters")] public Assets Rosters { get; set; }
            [JsonProperty("rounds")] public Assets Rounds { get; set; }
            [JsonProperty("spectators")] public Assets Spectators { get; set; }
        }
        public partial class Attribute {
            [JsonProperty("createdAt")] public string CreatedAt { get; set; }
            [JsonProperty("duration")] public long Duration { get; set; }
            [JsonProperty("gameMode")] public string GameMode { get; set; }
            [JsonProperty("patchVersion")] public string PatchVersion { get; set; }
            [JsonProperty("shardId")] public string ShardId { get; set; }
            [JsonProperty("stats")] public MapStats Stats { get; set; }
            [JsonProperty("titleId")] public string TitleId { get; set; }
        }
        public partial class MapStats {
            [JsonProperty("mapID")] public string MapID { get; set; }
            [JsonProperty("type")] public string Type { get; set; }
        }
    }
}
