using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleriteNET.Data {
    public class Emote {
        //TODO: Add entries
        private static Dictionary<long, string> emotes = new Dictionary<long, string> {
            {0, "Not yet implemented"}
        };

        public static string GetById(long id) {
            string emote;
            emotes.TryGetValue(id, out emote);
//            return emote;
            return emotes[0];
        }
    }
}