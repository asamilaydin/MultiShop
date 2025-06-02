namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public record UpdateProductDetailDto
    {
        public string Id { get; init; }
        public string Size { get; init; }
        public string Color { get; init; }
        public string Material { get; init; }
        public string Brand { get; init; }
        public string Manufacturer { get; init; }
        public string WarrantyPeriod { get; init; }
        public string ProductId { get; init; }
    }
} 