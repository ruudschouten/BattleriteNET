using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BattleriteNET.Json {
    public partial class Attribute {
        [JsonProperty("actor")] public string Actor { get; set; }
        [JsonProperty("createdAt")] public string CreatedAt { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("duration")] public long Duration { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("ordinal")] public long Ordinal { get; set; }
        [JsonProperty("patchVersion")] public string PatchVersion { get; set; }
        [JsonProperty("shardId")] public string ShardId { get; set; }
        [JsonProperty("stats")] public AttributeStats Stats { get; set; }
        [JsonProperty("titleId")] public string TitleId { get; set; }
        [JsonProperty("URL")] public string URL { get; set; }
        [JsonProperty("won")] public string Won { get; set; }


        public partial class AttributeStats {
            [JsonProperty("abilityUses")] public long AbilityUses { get; set; }
            [JsonProperty("attachment")] public long Attachment { get; set; }
            [JsonProperty("damageDone")] public long DamageDone { get; set; }
            [JsonProperty("damageReceived")] public long DamageReceived { get; set; }
            [JsonProperty("deaths")] public long Deaths { get; set; }
            [JsonProperty("disablesDone")] public long DisablesDone { get; set; }
            [JsonProperty("disablesReceived")] public long DisablesReceived { get; set; }
            [JsonProperty("emote")] public long Emote { get; set; }
            [JsonProperty("energyGained")] public long EnergyGained { get; set; }
            [JsonProperty("energyUsed")] public long EnergyUsed { get; set; }
            [JsonProperty("healingDone")] public long HealingDone { get; set; }
            [JsonProperty("healingReceived")] public long HealingReceived { get; set; }
            [JsonProperty("kills")] public long Kills { get; set; }
            [JsonProperty("mount")] public long Mount { get; set; }
            [JsonProperty("outfit")] public long Outfit { get; set; }
            [JsonProperty("score")] public long Score { get; set; }
            [JsonProperty("side")] public long Side { get; set; }
            [JsonProperty("timeAlive")] public long TimeAlive { get; set; }
            [JsonProperty("userID")] public string UserID { get; set; }
            [JsonProperty("winningTeam")] public long WinningTeam { get; set; }

            public override string ToString() {
                StringBuilder builder = new StringBuilder();
                if (UserID != null) {
                    TimeSpan t = TimeSpan.FromMilliseconds((double)(TimeAlive * 1000));
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
                if (Outfit != null) {
                    builder.Append($"\n**Outfit ID**: {Outfit}\t");
                    builder.Append($"**Mount ID**: {Mount}\t");
                    builder.Append($"**Emote ID**: {Emote}\t");
                }
                string s = builder.ToString();
                return builder.ToString();
            }
        }
    }
}
