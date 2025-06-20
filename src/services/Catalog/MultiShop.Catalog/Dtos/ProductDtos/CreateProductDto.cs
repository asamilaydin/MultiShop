namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public record CreateProductDto
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public int Stock { get; init; }
        public string CategoryId { get; init; }
    }
} 