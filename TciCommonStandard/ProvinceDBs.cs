using EasyMongoNet;
using System.Collections.Generic;

namespace TciPM.Classes
{
    public class ProvinceDBs
    {
        private readonly Dictionary<string, IDbContext> DBs = new Dictionary<string, IDbContext>();

        public void Add(string provincePrefix, IDbContext db)
        {
            if (DBs.ContainsKey(provincePrefix))
                DBs.Remove(provincePrefix);
            DBs.Add(provincePrefix, db);
        }

        public IDbContext this[string provincePrefix] => DBs[provincePrefix];

        public IEnumerable<string> Keys => DBs.Keys;
    }
}