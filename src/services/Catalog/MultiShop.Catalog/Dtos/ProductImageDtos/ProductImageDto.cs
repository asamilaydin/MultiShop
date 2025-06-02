using System;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public record ProductImageDto
    {
        public string Id { get; init; }
        public string ImagePath { get; init; }
        public string AltText { get; init; }
        public bool IsMain { get; init; }
        public int DisplayOrder { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
        public string ProductId { get; init; }
        
        // Navigation property DTO
        public ProductDto Product { get; init; }
    }
} 