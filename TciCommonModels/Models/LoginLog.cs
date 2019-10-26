using AliaaCommon;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = false, UnifyChars = false)]
    [CollectionOptions(Capped = true, MaxSize = 10000000)]
    [MongoIndex(new string[] { nameof(UserId) })]
    [MongoIndex(new string[] { nameof(Username) })]
    [MongoIndex(new string[] { nameof(IP) })]
    [MongoIndex(new string[] { nameof(Date) }, new MongoIndexType[] { MongoIndexType.Descending })]
    public class LoginLog : MongoEntity
    {
        public ObjectId UserId { get; set; }
        [DisplayNameX("نام کاربری")]
        public string Username { get; set; }
        [DisplayNameX("تاریخ")]
        public DateTime Date { get; set; } = DateTime.Now;
        public string IP { get; set; }
        public bool Sucess { get; set; }
        public bool FromAndroid { get; set; }
    }
}
