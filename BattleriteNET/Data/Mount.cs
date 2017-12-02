using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleriteNET.Data {
    public class Mount {
        //TODO: Add entries
        private static Dictionary<long, string> mounts = new Dictionary<long, string> {
            {0, "Not yet implemented"}
        };

        public static string GetById(long id) {
            string mount;
            mounts.TryGetValue(id, out mount);
//            return mount;
            return mounts[0];
        }
    }
}