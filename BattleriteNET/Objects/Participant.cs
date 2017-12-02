using System;
using System.Text;
using BattleriteNET.Data;
using BattleriteNET.Json;

namespace BattleriteNET.Objects {
    public class Participant {
        /// <summary>
        /// Same as ID of Roster
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Participants
        /// </summary>
        public string Type { get; } = "participants";

        /// <summary>
        /// Hero ID
        /// </summary>
        public string ActorId { get; }

        /// <summary>
        /// Hero name
        /// </summary>
        public string Hero => Data.Hero.GetById(ActorId);

        /// <summary>
        /// See Participant.Player
        /// </summary>
        public Player ParticipantPlayer { get; }

        /// <summary>
        /// See Participant.Stats
        /// </summary>
        public ParticipantStats Stats { get; }

        public Participant(string id) {
            Id = id;
        }

        public Participant(Included inc) {
            Id = inc.Id;
            Type = inc.Type;
            ActorId = inc.Attributes.Actor;
            ParticipantPlayer = new Player(inc.Relationships.Player.Data.Id);
            var stats = inc.Attributes.Stats;
            Stats = new ParticipantStats(Id, stats.Side, stats.WinningTeam, stats.Score, stats.Kills, stats.Deaths,
                stats.TimeAlive, stats.DamageDone, stats.DamageReceived,
                stats.HealingDone, stats.HealingReceived, stats.DisablesDone, stats.DisablesReceived,
                stats.EnergyGained, stats.EnergyUsed, stats.AbilityUses, stats.Attachment,
                stats.Outfit, stats.Emote, stats.Mount);
        }

        public Participant(string id, string actorId, Player player, ParticipantStats stats) {
            Id = id;
            ActorId = actorId;
            ParticipantPlayer = player;
            Stats = stats;
        }

        public class Player {
            /// <summary>
            /// UID of Player
            /// </summary>
            public string Id { get; }

            /// <summary>
            /// Player
            /// </summary>
            public string Type { get; } = "Player";

            public Player(string id) {
                Id = id;
            }
        }

        public class ParticipantStats {
            public string UserID { get; }

            /// <summary>
            /// Side the participant is playing on
            /// </summary>
            public long Side { get; }

            public long WinningTeam { get; }
            public long Score { get; }
            public long Kills { get; }
            public long Deaths { get; }
            public long TimeAlive { get; }
            public long DamageDone { get; }
            public long DamageReceived { get; }
            public long HealingDone { get; }
            public long HealingReceived { get; }
            public long DisablesDone { get; }
            public long DisablesReceived { get; }
            public long EnergyGained { get; }
            public long EnergyUsed { get; }
            public long AbilityUses { get; }
            public long Attachment { get; }
            public long OutfitId { get; }
            public long EmoteId { get; }
            public long MountId { get; }

            public string Outfit => Data.Outfit.GetById(OutfitId);

            public string Emote => Data.Emote.GetById(EmoteId);

            public string Mount => Data.Mount.GetById(MountId);

            public ParticipantStats(string userId, long side, long winningTeam, long score, long kills, long deaths,
                long timeAlive, long damageDone, long damageReceived, long healingDone, long healingReceived,
                long disablesDone,
                long disablesRec, long energyGained, long energyUsed, long abilityUses, long attachment, long outfit,
                long emote, long mount) {
                UserID = userId;
                Side = side;
                WinningTeam = winningTeam;
                Score = score;
                Kills = kills;
                Deaths = deaths;
                TimeAlive = timeAlive;
                DamageDone = damageDone;
                DamageReceived = damageReceived;
                HealingDone = healingDone;
                HealingReceived = healingReceived;
                DisablesDone = disablesDone;
                DisablesReceived = disablesRec;
                EnergyGained = energyGained;
                EnergyUsed = energyUsed;
                AbilityUses = abilityUses;
                Attachment = attachment;
                OutfitId = outfit;
                EmoteId = emote;
                MountId = mount;
            }

            public override string ToString() {
                StringBuilder builder = new StringBuilder();
                if (UserID != null) {
                    TimeSpan t = TimeSpan.FromMilliseconds((double) (TimeAlive * 1000));
                    builder.Append($"**UID** {UserID}");
                    builder.Append($"\t**Score** {Score}\n");
                    builder.Append($"**Ability uses** {AbilityUses}");
                    builder.Append($"\t**Time alive** {t.Minutes:D2}m:{t.Seconds:D2}s\n");
                    builder.Append($"**Damage**\tDone: {DamageDone}\tReceived: {DamageReceived}\n");
                    builder.Append($"**Healing**\tDone: {HealingDone}\tReceived: {HealingReceived}\n");
                    builder.Append($"**Disables**\tDone: {DisablesDone}\tReceived: {DisablesReceived}\n");
                    builder.Append($"**Energy**\tUsed: {EnergyUsed}\tGained: {EnergyGained}\n");
                    builder.Append($"**Kills** {Kills}\t**Deaths** {Deaths}\n");
                }
                if (OutfitId != null) {
                    builder.Append($"\n**Outfit ID**: {OutfitId}\t");
                    builder.Append($"**Mount ID**: {MountId}\t");
                    builder.Append($"**Emote ID**: {EmoteId}\t");
                }
                string s = builder.ToString();
                return builder.ToString();
            }
        }
    }
}