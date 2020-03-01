using AliaaCommon;
using EasyMongoNet;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TciCommon.Models
{
    [CollectionIndex(new string[] { nameof(City) })]
    [CollectionIndex(new string[] { nameof(Name) })]
    [BsonIgnoreExtraElements]
    [CollectionSave(WriteLog = true)]
    public class CommCenter : MongoEntity
    {

        [DisplayNameX("نام")]
        public string Name { get; set; }

        [DisplayNameX("شهر")]
        public ObjectId City { get; set; }

        [DisplayNameX("نام مسئول")]
        public string ResponderName { get; set; }

        [DisplayNameX("تلفن مسئول")]
        public string Phone { get; set; }

        [DisplayNameX("شماره همراه مسئول")]
        public string SupervisorMobile { get; set; }

        [DisplayNameX("آدرس")]
        public string Address { get; set; }

        [DisplayNameX("موقعیت جغرافیایی")]
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
