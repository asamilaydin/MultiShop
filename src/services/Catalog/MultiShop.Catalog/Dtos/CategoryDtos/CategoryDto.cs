using System;
using System.Collections.Generic;
using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record CategoryDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedDate { get; init; }
        public DateTime? UpdatedDate { get; init; }
        
        // Navigation property DTOs
        public ICollection<ProductDto> Products { get; init; }
    }
} 