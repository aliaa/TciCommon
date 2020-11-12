using EasyMongoNet;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TciCommon.Models
{
    [CollectionIndex(new string[] { nameof(City) })]
    [CollectionIndex(new string[] { nameof(Name) })]
    [BsonIgnoreExtraElements]
    [CollectionSave(WriteLog = true)]
    public class CommCenter : MongoEntity
    {
        [Required]
        [DisplayName("نام")]
        public string Name { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [DisplayName("شهر")]
        public string City { get; set; }

        [DisplayName("نام مسئول")]
        public string ResponderName { get; set; }

        [DisplayName("تلفن مسئول")]
        public string Phone { get; set; }

        [DisplayName("شماره همراه مسئول")]
        public string SupervisorMobile { get; set; }

        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("موقعیت جغرافیایی")]
        public GeoPosition Location { get; set; }

        public int CompareTo(object obj)
        {
            return this.Name.CompareTo((obj as CommCenter).Name);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
