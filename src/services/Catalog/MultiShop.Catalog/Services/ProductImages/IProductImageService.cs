using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImages
{
    public interface IProductImageService
    {
        Task<ProductImageDto> CreateAsync(CreateProductImageDto createProductImageDto);
        Task<ProductImageDto> UpdateAsync(string id, UpdateProductImageDto updateProductImageDto);
        Task<ProductImageDto> GetByIdAsync(string id);
        Task<IEnumerable<ProductImageDto>> GetByProductIdAsync(string productId);
        Task<IEnumerable<ProductImageDto>> GetAllAsync();
        Task DeleteAsync(string id);
        Task DeleteAllByProductIdAsync(string productId);
    }
} 