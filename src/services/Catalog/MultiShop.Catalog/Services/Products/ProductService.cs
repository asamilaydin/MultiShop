using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.Categories;

namespace MultiShop.Catalog.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductService(
            IRepository<Product> productRepository,
            ICategoryService categoryService,
            IMapper mapper)
        {
            _productRepository = productRepository;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            // Kategori kontrolü
            await _categoryService.GetByIdAsync(createProductDto.CategoryId);

            var product = _mapper.Map<Product>(createProductDto);
            
            // İsim kontrolü
            var filter = Builders<Product>.Filter.Eq(x => x.Name, createProductDto.Name);
            var existingProduct = await _productRepository.FindOneAsync(filter);
            
            if (existingProduct != null)
                throw new Exception($"Product with name {createProductDto.Name} already exists");

            product = await _productRepository.InsertOneAsync(product);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> UpdateAsync(string id, UpdateProductDto updateProductDto)
        {
            // Ürün kontrolü
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var existingProduct = await _productRepository.FindOneAsync(filter);
            
            if (existingProduct == null)
                throw new Exception($"Product with id {id} not found");

            // Kategori kontrolü
            if (!string.IsNullOrEmpty(updateProductDto.CategoryId))
            {
                await _categoryService.GetByIdAsync(updateProductDto.CategoryId);
            }

            // İsim çakışması kontrolü
            if (!string.IsNullOrEmpty(updateProductDto.Name))
            {
                var nameFilter = Builders<Product>.Filter.And(
                    Builders<Product>.Filter.Eq(x => x.Name, updateProductDto.Name),
                    Builders<Product>.Filter.Ne(x => x.Id, id)
                );
                var productWithSameName = await _productRepository.FindOneAsync(nameFilter);
                if (productWithSameName != null)
                    throw new Exception($"Product with name {updateProductDto.Name} already exists");
            }

            _mapper.Map(updateProductDto, existingProduct);
            
            var update = Builders<Product>.Update
                .Set(x => x.Name, existingProduct.Name)
                .Set(x => x.Description, existingProduct.Description)
                .Set(x => x.Price, existingProduct.Price)
                .Set(x => x.Stock, existingProduct.Stock)
                .Set(x => x.CategoryId, existingProduct.CategoryId);

            var updatedProduct = await _productRepository.FindOneAndUpdateAsync(filter, update);
            return _mapper.Map<ProductDto>(updatedProduct);
        }

        public async Task<ProductDto> GetByIdAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var product = await _productRepository.FindOneAsync(filter);
            
            if (product == null)
                throw new Exception($"Product with id {id} not found");

            return _mapper.Map<ProductDto>(product);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var filter = Builders<Product>.Filter.Empty;
            var products = await _productRepository.FindAsync(filter);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(string categoryId)
        {
            // Kategori kontrolü
            await _categoryService.GetByIdAsync(categoryId);

            var filter = Builders<Product>.Filter.Eq(x => x.CategoryId, categoryId);
            var products = await _productRepository.FindAsync(filter);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var product = await _productRepository.FindOneAndDeleteAsync(filter);
            
            if (product == null)
                throw new Exception($"Product with id {id} not found");

            // TODO: Ürün detayları ve resimleri de silinmeli
        }
    }
} 