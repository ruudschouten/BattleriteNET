using System.Collections.Generic;

namespace BattleriteNET.Data {
    public class Hero {
        private static readonly Dictionary<string, string> heroes = new Dictionary<string, string> {
            {"467463015", "Lucie"}, //ID 1
            {"259914044", "Sirius"}, //ID 2
            {"842211418", "Iva"}, //ID 3
            {"65687534", "Jade"}, //ID 4
            {"550061327", "Ruh Kaan"}, //ID 5
            {"1908945514", "Oldur"}, //ID 6
            {"1", "Ashka"}, //ID 7
            {"369797039", "Varesh"}, //ID 8
            {"44962063", "Pearl"}, //ID 9
            {"154382530", "Taya"}, //ID 10
            {"1134478706", "Poloma"}, //ID 11
            {"1208445212", "Croak"}, //ID 12
            {"1606711539", "Freya"}, //ID 13
            {"39373466", "Jumong"}, //ID 14
            {"763360732", "Shifu"}, //ID 15
            {"1377055301", "Ezmo"}, //ID 16
            {"1422481252", "Bakko"}, //ID 17
            {"1318732017", "Rook"}, //ID 18
            {"1649551456", "Pestilus"}, //ID 19
            {"870711570", "Destiny"}, //ID 20
            {"1749055646", "Raigon"}, //ID 21
            {"543520739", "Blossom"}, //ID 22
            {"1667608978", "Unnamed23"}, //ID 23
            {"366351234", "Unnamed24"}, //ID 24
            {"1463164578", "Thorn"}, //ID 25
        };

        public static string GetById(string id) {
            string hero;
            heroes.TryGetValue(id, out hero);
            return hero;
        }
    }
}