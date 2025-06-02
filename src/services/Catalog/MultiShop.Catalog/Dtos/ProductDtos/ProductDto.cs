using System;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public record ProductDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public bool IsActive { get; init; }
        public string CategoryId { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
        
        // Navigation property DTOs
        public CategoryDto Category { get; init; }
        public ProductDetailDto ProductDetail { get; init; }
        public ICollection<ProductImageDto> ProductImages { get; init; }
    }
} 