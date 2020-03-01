using EasyMongoNet;
using System;
using System.Collections.Generic;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = true)]
    [Serializable]
    public class Province : MongoEntity
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
        public List<string> Applications { get; set; } = new List<string>();
    }
}
