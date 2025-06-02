using System;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public record ProductDetailDto
    {
        public string Id { get; init; }
        public string Size { get; init; }
        public string Color { get; init; }
        public string Material { get; init; }
        public string Brand { get; init; }
        public string Manufacturer { get; init; }
        public string WarrantyPeriod { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
        public string ProductId { get; init; }
        
        // Navigation property DTO
        public ProductDto Product { get; init; }
    }
} 