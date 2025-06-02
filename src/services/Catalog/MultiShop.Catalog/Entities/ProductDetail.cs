using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Common;

namespace MultiShop.Catalog.Entities
{
    public class ProductDetail : BaseEntity
    {
        public string Size { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Brand { get; set; }
        public string Manufacturer { get; set; }
        public string WarrantyPeriod { get; set; }
        public string ProductId { get; set; }
        
        [BsonIgnore]
        public Product Product { get; set; }
    }
} 