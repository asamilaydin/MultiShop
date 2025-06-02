using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Common;

namespace MultiShop.Catalog.Entities
{
    public class ProductImage : BaseEntity
    {
        public string ImagePath { get; set; }
        public string AltText { get; set; }
        public bool IsMain { get; set; }
        public int DisplayOrder { get; set; }
        public string ProductId { get; set; }
        
        [BsonIgnore]
        public Product Product { get; set; }
    }
} 