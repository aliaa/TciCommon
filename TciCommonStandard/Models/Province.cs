using EasyMongoNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TciCommon.Models
{
    [CollectionSave(WriteLog = true)]
    [Serializable]
    public class Province : MongoEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Prefix { get; set; }
        public List<string> Applications { get; set; } = new List<string>();
    }
}
