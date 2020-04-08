using AliaaCommon;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using EasyMongoNet;
using System.ComponentModel;

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

        [DisplayName("مرکز")]
        [JsonConverter(typeof(ObjectIdJsonConverter))]
        public ObjectId CommCenter { get; set; }

        [DisplayName("نوع")]
        [BsonRepresentation(BsonType.String)]
        public kafuType Type { get; set; }

        [DisplayName("برند")]
        public string Brand { get; set; }

        [DisplayName("ظرفیت")]
        public int Capacity { get; set; }
    }
}