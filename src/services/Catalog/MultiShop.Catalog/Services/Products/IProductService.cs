using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.Products
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductDto createProductDto);
        Task<ProductDto> UpdateAsync(string id, UpdateProductDto updateProductDto);
        Task<ProductDto> GetByIdAsync(string id);
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetByCategoryAsync(string categoryId);
        Task DeleteAsync(string id);
    }
} 