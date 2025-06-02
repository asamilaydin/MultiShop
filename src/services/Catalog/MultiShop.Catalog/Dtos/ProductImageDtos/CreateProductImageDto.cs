namespace MultiShop.Catalog.Dtos.ProductImageDtos
{
    public record CreateProductImageDto
    {
        public string ImagePath { get; init; }
        public string AltText { get; init; }
        public bool IsMain { get; init; }
        public int DisplayOrder { get; init; }
        public string ProductId { get; init; }
    }
} 