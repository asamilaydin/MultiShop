using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.Categories
{
    public interface ICategoryService
    {
        Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto);
        Task<CategoryDto> UpdateAsync(string id, UpdateCategoryDto updateCategoryDto);
        Task<CategoryDto> GetByIdAsync(string id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task DeleteAsync(string id);
    }
} 