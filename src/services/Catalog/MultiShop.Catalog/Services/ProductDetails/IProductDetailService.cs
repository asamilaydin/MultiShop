using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetails
{
    public interface IProductDetailService
    {
        Task<ProductDetailDto> CreateAsync(CreateProductDetailDto createProductDetailDto);
        Task<ProductDetailDto> UpdateAsync(string id, UpdateProductDetailDto updateProductDetailDto);
        Task<ProductDetailDto> GetByIdAsync(string id);
        Task<ProductDetailDto> GetByProductIdAsync(string productId);
        Task<IEnumerable<ProductDetailDto>> GetAllAsync();
        Task DeleteAsync(string id);
    }
} 