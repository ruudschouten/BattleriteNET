using System.Collections.Generic;

namespace BattleriteNET.Data {
    public class Maps {

        private static Dictionary<string, string> maps = new Dictionary<string, string> {
            {"D57BBC373C35B426E93CB844B3C67C12", "Mount Araz - Day"},
            {"AB201E3B9454141FE9C9352CC296AD61", "Mount Araz - Night"},
            {"02EF7F035729241EF81A9BC09463DD00", "Orman Temple - Day"},
            {"3482480FED2AC482AA7DA471C1990591", "Orman Temple - Night"},
            {"80D7970B6650D41108D71083ECF0E49E", "Sky Ring - Day"},
            {"417DE573937D74E39BF40EB6CF82670B", "Sky Ring - Night"},
            {"975402A5539C6491789B36DC4D26D566", "Blackstone Arena - Day"},
            {"319DDC57E70174B6C85EF137BAF34E9E", "Blackstone Arena - Night"},
            {"1C67FA3426A324D39BED64501C46C1E6", "Dragon Garden - Day"},
            {"FFFFE4774561141D49B46892B5CBACFA", "Dragon Garden - Night"},
        };

        public static string GetById(string id) {
            string map;
            maps.TryGetValue(id, out map);
            return map;
        }
    }
}