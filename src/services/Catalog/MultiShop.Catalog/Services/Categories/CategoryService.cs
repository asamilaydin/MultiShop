using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;

namespace MultiShop.Catalog.Services.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _mapper.Map<Category>(createCategoryDto);
            
            // İsim kontrolü
            var filter = Builders<Category>.Filter.Eq(x => x.Name, createCategoryDto.Name);
            var existingCategory = await _categoryRepository.FindOneAsync(filter);
            
            if (existingCategory != null)
                throw new Exception($"Category with name {createCategoryDto.Name} already exists");

            // Yeni kategori ekleme
            category = await _categoryRepository.InsertOneAsync(category);
            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<CategoryDto> UpdateAsync(string id, UpdateCategoryDto updateCategoryDto)
        {
            // Kategori kontrolü
            var filter = Builders<Category>.Filter.Eq(x => x.Id, id);
            var existingCategory = await _categoryRepository.FindOneAsync(filter);
            
            if (existingCategory == null)
                throw new Exception($"Category with id {id} not found");

            // İsim çakışması kontrolü
            if (!string.IsNullOrEmpty(updateCategoryDto.Name))
            {
                var nameFilter = Builders<Category>.Filter.And(
                    Builders<Category>.Filter.Eq(x => x.Name, updateCategoryDto.Name),
                    Builders<Category>.Filter.Ne(x => x.Id, id)
                );
                var categoryWithSameName = await _categoryRepository.FindOneAsync(nameFilter);
                if (categoryWithSameName != null)
                    throw new Exception($"Category with name {updateCategoryDto.Name} already exists");
            }

            _mapper.Map(updateCategoryDto, existingCategory);
            
            // MongoDB güncelleme işlemi
            var update = Builders<Category>.Update
                .Set(x => x.Name, existingCategory.Name)
                .Set(x => x.Description, existingCategory.Description);

            var updatedCategory = await _categoryRepository.FindOneAndUpdateAsync(filter, update);
            return _mapper.Map<CategoryDto>(updatedCategory);
        }

        public async Task<CategoryDto> GetByIdAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Id, id);
            var category = await _categoryRepository.FindOneAsync(filter);
            
            if (category == null)
                throw new Exception($"Category with id {id} not found");

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var filter = Builders<Category>.Filter.Empty;
            var categories = await _categoryRepository.FindAsync(filter);
            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Category>.Filter.Eq(x => x.Id, id);
            var category = await _categoryRepository.FindOneAndDeleteAsync(filter);
            
            if (category == null)
                throw new Exception($"Category with id {id} not found");

            // TODO: Ürün-kategori ilişkisi eklendiğinde, 
            // silmeden önce kategoriye bağlı ürün kontrolü yapılacak
        }
    }
} 