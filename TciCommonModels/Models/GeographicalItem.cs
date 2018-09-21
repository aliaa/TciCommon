using AliaaCommon;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TciCommon.Models
{
    [Serializable]
    [MongoIndex(new string[] { nameof(Name) })]
    public abstract class GeographicalItem : MongoEntity
    {
        [DisplayNameX("نام")]
        public string Name { get; set; }

        [DisplayNameX("موقعیت جغرافیایی")]
        public GeoPosition Location { get; set; }
        
        [DisplayNameX("آدرس")]
        public string Address { get; set; }

        [DisplayNameX("توضیح")]
        public string Description { get; set; }
    }
}