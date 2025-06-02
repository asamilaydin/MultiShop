using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MultiShop.Catalog.Entities.Common;

namespace MultiShop.Catalog.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public string CategoryId { get; set; }
        
        [BsonIgnore]
        public Category Category { get; set; }
        [BsonIgnore]
        public ProductDetail ProductDetail { get; set; }
        [BsonIgnore]
        public ICollection<ProductImage> ProductImages { get; set; }
    }
} 