using System.Collections.Generic;

namespace BattleriteNET.Data {
    public class Hero {
        private static readonly Dictionary<string, string> heroes = new Dictionary<string, string> {
            {"467463015", "Lucie"},
            {"259914044", "Sirius"},
            {"842211418", "Iva"},
            {"65687534", "Jade"},
            {"550061327", "Ruh Kaan"},
            {"1908945514", "Oldur"},
            {"1", "Ashka"},
            {"369797039", "Varesh"},
            {"44962063", "Pearl"},
            {"154382530", "Taya"},
            {"1134478706", "Poloma"},
            {"1208445212", "Croak"},
            {"1606711539", "Freya"},
            {"39373466", "Jumong"},
            {"763360732", "Shifu"},
            {"1377055301", "Ezmo"},
            {"1422481252", "Bakko"},
            {"1318732017", "Rook"},
            {"1649551456", "Pestilus"},
            {"1749055646", "Raigon"},
            {"543520739", "Blossom"},
            {"1463164578", "Thorn"},
            {"870711570", "Destiny"},
            {"613085868", "Alysia"},
        };

        public static string GetById(string id) {
            string hero;
            heroes.TryGetValue(id, out hero);
            return hero;
        }
    }
}