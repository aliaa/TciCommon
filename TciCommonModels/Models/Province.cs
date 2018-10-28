using AliaaCommon;
using System;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = true)]
    public class Province : MongoEntity
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
    }
}
