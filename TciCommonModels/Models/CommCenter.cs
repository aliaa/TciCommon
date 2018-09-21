using AliaaCommon;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TciCommon.Models
{
    [MongoIndex(new string[] { nameof(City) })]
    [MongoIndex(new string[] { nameof(Name) })]
    [BsonIgnoreExtraElements]
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
