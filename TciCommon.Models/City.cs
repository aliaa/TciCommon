using EasyMongoNet;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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

        [BsonRepresentation(BsonType.ObjectId)]
        public string Province { get; set; }

        public GeoPosition Location { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
