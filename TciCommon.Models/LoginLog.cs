using MongoDB.Bson;
using System;
using EasyMongoNet;
using System.ComponentModel;
using MongoDB.Bson.Serialization.Attributes;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = false, Preprocess = false)]
    [CollectionOptions(Capped = true, MaxSize = 10000000)]
    [CollectionIndex(new string[] { nameof(UserId) })]
    [CollectionIndex(new string[] { nameof(Username) })]
    [CollectionIndex(new string[] { nameof(IP) })]
    [CollectionIndex(new string[] { nameof(Date) }, new MongoIndexType[] { MongoIndexType.Descending })]
    public class LoginLog : MongoEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }

        [DisplayName("نام کاربری")]
        public string Username { get; set; }
        [DisplayName("تاریخ")]
        public DateTime Date { get; set; } = DateTime.Now;
        public string IP { get; set; }
        public bool Sucess { get; set; }
        public bool FromAndroid { get; set; }
    }
}
