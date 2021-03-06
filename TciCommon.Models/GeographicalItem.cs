﻿using EasyMongoNet;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TciCommon.Models
{
    [Serializable]
    [CollectionIndex(new string[] { nameof(Name) })]
    public abstract class GeographicalItem : MongoEntity
    {
        [Required]
        [DisplayName("نام")]
        public string Name { get; set; }

        [DisplayName("موقعیت جغرافیایی")]
        public GeoPosition Location { get; set; }
        
        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("توضیح")]
        public string Description { get; set; }
    }
}