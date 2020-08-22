using EasyMongoNet;
using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;

namespace TciCommon.Models
{
    [CollectionIndex(new string[] { nameof(Province) })]
    [CollectionIndex(new string[] { nameof(Name) }, Unique = true)]
    [CollectionSave(WriteLog = true)]
    public class City : MongoEntity
    {
        [Required]
        public string Name { get; set; }

        public ObjectId Province { get; set; }

        public GeoPosition Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
