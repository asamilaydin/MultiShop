namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record UpdateCategoryDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public bool IsActive { get; init; }
    }
} 