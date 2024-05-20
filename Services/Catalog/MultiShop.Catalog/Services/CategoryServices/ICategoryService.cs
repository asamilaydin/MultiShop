using System;
using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllCategoryAsync();

		Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);

        Task UpdateCategoryAsync(UpdateCategoryDto cCategoryDto);

        Task DeleteCategoryAsync(string id);

		Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);

    }
}

