using AliaaCommon;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using EasyMongoNet;

namespace TciCommon.Models
{
    [CollectionIndex(new string[] { nameof(CommCenter)})]
    [BsonIgnoreExtraElements]
    public class Kafu : GeographicalItem
    {
        public enum kafuType
        {
            [DisplayNameX("مسی")]
            Copper,
            ONU,
            DLC,
            ODC,
            OLT,
            BTS,
            FAT,
            ONUD,
            ONUS,
        }

        [DisplayNameX("مرکز")]
        [JsonConverter(typeof(ObjectIdJsonConverter))]
        public ObjectId CommCenter { get; set; }

        [DisplayNameX("نوع")]
        [BsonRepresentation(BsonType.String)]
        public kafuType Type { get; set; }

        [DisplayNameX("برند")]
        public string Brand { get; set; }

        [DisplayNameX("ظرفیت")]
        public int Capacity { get; set; }
    }
}