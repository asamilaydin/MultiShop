namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public record UpdateProductDto
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public bool IsActive { get; init; }
        public string CategoryId { get; init; }
    }
} 