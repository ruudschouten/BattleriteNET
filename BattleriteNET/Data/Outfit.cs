using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleriteNET.Data {
    public class Outfit {
        //TODO: Add entries
        private static Dictionary<long, string> outfits = new Dictionary<long, string> {
            {0, "Not yet implemented"}
        };

        public static string GetById(long id) {
            string outfit;
            outfits.TryGetValue(id, out outfit);
//            return outfit;
            return outfits[0];
        }
    }
}