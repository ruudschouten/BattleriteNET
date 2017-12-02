using System.Collections.Generic;
using BattleriteNET.Json;

namespace BattleriteNET.Objects {
    public class Round {
        /// <summary>
        /// Round ID
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Round Index
        /// </summary>
        public long Ordinal { get; }
        /// <summary>
        /// List of participants
        /// </summary>
        public List<Participant> Participants { get; } = new List<Participant>();
        /// <summary>
        /// Stats particular to the round
        /// </summary>
        public long WinningTeam { get; }
        /// <summary>
        /// Length of the match
        /// </summary>
        public long Duration { get; }
        public Round(string id) {
            Id = id;
        }

        public Round(Included inc/*, List<Participant> participants*/) {
            Id = inc.Id;
            Ordinal = inc.Attributes.Ordinal;
//            foreach (var participant in inc.Relationships.Participants.Data) {
//                Participants.Add(participants.Find(x => x.Id == participant.Id));
//            }
            WinningTeam = inc.Attributes.Stats.WinningTeam;
            Duration = inc.Attributes.Duration;
        }

        public Round(Included inc, List<Roster> rosters) {
            Id = inc.Id;
            Ordinal = inc.Attributes.Ordinal;
            foreach (var roster in rosters) {
                foreach (var participant in roster.Participants) {
                    Participants.Add(participant);
                }
            }
            //            foreach (var participant in inc.Relationships.Participants.Data) {
            //                Participants.Add(participants.Find(x => x.Id == participant.Id));
            //            }
            WinningTeam = inc.Attributes.Stats.WinningTeam;
            Duration = inc.Attributes.Duration;
        }
    }
}
