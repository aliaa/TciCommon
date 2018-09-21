using AliaaCommon;
using System;

namespace TciCommon.Models
{
    public class Province : MongoEntity
    {
        public string Name { get; set; }
        public string Prefix { get; set; }
    }
}
