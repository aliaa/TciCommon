using AliaaCommon;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TciCommon.Models
{
    [MongoIndex(new string[] { nameof(Province) })]
    [MongoIndex(new string[] { nameof(Name) }, Unique = true)]
    [CollectionSave(WriteLog = true)]
    public class City : MongoEntity
    {
        public string Name { get; set; }

        public ObjectId Province { get; set; }

        public GeoPosition Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
