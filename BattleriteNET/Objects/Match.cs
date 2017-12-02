using System.Collections.Generic;
using BattleriteNET.Data;
using BattleriteNET.Json;
using Newtonsoft.Json;

namespace BattleriteNET.Objects {
    public class Match {
        /// <summary>
        /// Match
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Match ID
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Time of match played
        /// </summary>
        public string CreatedAt { get; }

        /// <summary>
        /// Duration of match in seconds
        /// </summary>
        public long Duration { get; }

        /// <summary>
        /// Game Mode
        /// </summary>
        public string GameMode { get; }

        /// <summary>
        /// Version of the game
        /// </summary>
        public string PatchVersion { get; }

        /// <summary>
        /// Region Shard
        /// </summary>
        public string ShardId { get; }

        /// <summary>
        /// Identifies the studio and game
        /// </summary>
        public string TitleId { get; }

        /// <summary>
        /// Stats particular to the match
        /// </summary>
        public MapStats Stats { get; }

        /// <summary>
        /// See Match.Asset
        /// </summary>
        public List<Asset> Assets { get; set; } = new List<Asset>();

        /// <summary>
        /// See Roster
        /// </summary>
        public List<Roster> Rosters { get; } = new List<Roster>();

        /// <summary>
        /// See Round
        /// </summary>
        public List<Round> Rounds { get; } = new List<Round>();

//        /// <summary>
//        /// Participants who took place in the match
//        /// </summary>
//        public List<Participant> Participants { get; } = new List<Participant>();

        /// <summary>
        /// Participants that are spectating
        /// </summary>
        public List<Participant> Spectators { get; } = new List<Participant>();

        public Match(string id, Matches.Attribute att, Matches.Relationship rel, List<Included> inc) {
            Type = "Match";
            Id = id;
            CreatedAt = att.CreatedAt;
            Duration = att.Duration;
            GameMode = att.GameMode;
            PatchVersion = att.PatchVersion;
            ShardId = att.ShardId;
            TitleId = att.TitleId;
            Stats = new MapStats(att.Stats.MapID, att.Stats.Type);
            var participants = new List<Participant>();
            foreach (var included in inc) {
                if (included.Type.ToLower().Contains("participant")) {
                    participants.Add(new Participant(included));
                }
            }
            foreach (var asset in rel.Assets.Data) {
                var a = inc.Find(x => x.Id == asset.Id);
                Assets.Add(new Asset(a));
            }
            foreach (var roster in rel.Rosters.Data) {
                var r = inc.Find(x => x.Id == roster.Id);
                Rosters.Add(new Roster(r, participants));
            }
            foreach (var rounds in rel.Rounds.Data) {
                var r = inc.Find(x => x.Id == rounds.Id);
                Rounds.Add(new Round(r, Rosters));
            }
            foreach (var spectator in rel.Spectators.Data) {
                var s = inc.Find(x => x.Id == spectator.Id);
                Spectators.Add(new Participant(s));
            }
        }

        public class MapStats {
            public string Map => Maps.GetById(MapID);

            public string MapID { get; }
            public string Type { get; }

            public MapStats(string mapId, string type) {
                MapID = mapId;
                Type = type;
            }
        }

        public class Asset {
            /// <summary>
            /// ID of Asset
            /// </summary>
            public string Id { get; set; }

            /// <summary>
            /// Asset
            /// </summary>
            public string Type { get; set; } = "Asset";

            /// <summary>
            /// Time of Telemetry creation
            /// </summary>
            public string CreatedAt { get; }

            /// <summary>
            /// NA
            /// </summary>
            public string Description { get; }

            /// <summary>
            /// Telemetry.json
            /// </summary>
            public string Filename { get; } = "Telemetry.json";

            /// <summary>
            /// application/json
            /// </summary>
            public string ContentType { get; } = "application/json";

            /// <summary>
            /// Telemetry
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Link to Telemetry.json file
            /// </summary>
            public string URL { get; }

            /// <summary>
            /// Region Shard
            /// </summary>
            public string ShardID { get; }

            public Asset(string id) {
                Id = id;
            }

            public Asset(Included inc) {
                Id = inc.Id;
                CreatedAt = inc.Attributes.CreatedAt;
                Description = inc.Attributes.Description;
                Name = inc.Attributes.Name;
                URL = inc.Attributes.URL;
                ShardID = inc.Attributes.ShardId;
            }
        }
    }
}