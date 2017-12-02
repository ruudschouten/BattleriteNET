using System.Collections.Generic;
using BattleriteNET.Json;

namespace BattleriteNET.Objects {
    public class Roster {
        /// <summary>
        /// ID of Roster
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Roster
        /// </summary>
        public string Type { get; } = "Roster";
        /// <summary>
        /// See Participants
        /// </summary>
        public List<Participant> Participants { get; } = new List<Participant>();
        /// <summary>
        /// Stats particular to rosters
        /// </summary>
        public System.Object Stats { get; }
        /// <summary>
        /// See Roster.Team
        /// </summary>
        public Team RosterTeam { get; }
        /// <summary>
        /// Indicates if a roster won
        /// </summary>
        public string Won { get; }
        /// <summary>
        /// Region Shard
        /// </summary>
        public string ShardId { get; }

        public Roster(string id) {
            Id = id;
        }

        public Roster(Included inc, List<Participant> participants) {
            Id = inc.Id;
            foreach (var participant in inc.Relationships.Participants.Data) {
                Participants.Add(participants.Find(x => x.Id == participant.Id));
            }
//            Participants = participants;
        }

        public class Team {
            /// <summary>
            /// ID of Team or None
            /// </summary>
            public string Id { get; }
            /// <summary>
            /// Name of Team or None
            /// </summary>
            public string Name { get; }
            /// <summary>
            /// Team
            /// </summary>
            public string Type { get; } = "Team";
            /// <summary>
            /// Identifies the studio and game
            /// </summary>
            public string TitleId { get; }
            /// <summary>
            /// Region Shard
            /// </summary>
            public string ShardId { get; }
            /// <summary>
            /// NA
            /// </summary>
            public System.Object Assets { get; }
        }
    }
}
