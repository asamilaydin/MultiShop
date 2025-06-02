namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public record CreateCategoryDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
    }
} 