using AliaaCommon;
using EasyMongoNet;
using System;

namespace TciCommon.Models
{
    [Serializable]
    [CollectionIndex(new string[] { nameof(Name) })]
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