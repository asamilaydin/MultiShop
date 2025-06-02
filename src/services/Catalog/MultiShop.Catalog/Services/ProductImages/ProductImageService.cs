using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.Products;

namespace MultiShop.Catalog.Services.ProductImages
{
    public class ProductImageService : IProductImageService
    {
        private readonly IRepository<ProductImage> _productImageRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductImageService(
            IRepository<ProductImage> productImageRepository,
            IProductService productService,
            IMapper mapper)
        {
            _productImageRepository = productImageRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductImageDto> CreateAsync(CreateProductImageDto createProductImageDto)
        {
            // Ürün kontrolü
            await _productService.GetByIdAsync(createProductImageDto.ProductId);

            var productImage = _mapper.Map<ProductImage>(createProductImageDto);
            productImage = await _productImageRepository.InsertOneAsync(productImage);
            return _mapper.Map<ProductImageDto>(productImage);
        }

        public async Task<ProductImageDto> UpdateAsync(string id, UpdateProductImageDto updateProductImageDto)
        {
            var filter = Builders<ProductImage>.Filter.Eq(x => x.Id, id);
            var existingImage = await _productImageRepository.FindOneAsync(filter);
            
            if (existingImage == null)
                throw new Exception($"Product image with id {id} not found");

            _mapper.Map(updateProductImageDto, existingImage);
            var updatedImage = await _productImageRepository.FindOneAndReplaceAsync(filter, existingImage);
            return _mapper.Map<ProductImageDto>(updatedImage);
        }

        public async Task<ProductImageDto> GetByIdAsync(string id)
        {
            var filter = Builders<ProductImage>.Filter.Eq(x => x.Id, id);
            var productImage = await _productImageRepository.FindOneAsync(filter);
            
            if (productImage == null)
                throw new Exception($"Product image with id {id} not found");

            return _mapper.Map<ProductImageDto>(productImage);
        }

        /* public async Task<IEnumerable<ProductImageDto>> GetByProductIdAsync(string productId)
        {
            // Ürün kontrolü
            await _productService.GetByIdAsync(productId);

            var filter = Builders<ProductImage>.Filter.Eq(x => x.ProductId, productId);
            var options = new FindOptions<ProductImage>
            {
                Sort = Builders<ProductImage>.Sort.Ascending(x => x.DisplayOrder)
            };

            var productImages = await _productImageRepository.FindAsync(filter, options);
            return _mapper.Map<IEnumerable<ProductImageDto>>(productImages);
        }  */

        public async Task<IEnumerable<ProductImageDto>> GetAllAsync()
        {
            var filter = Builders<ProductImage>.Filter.Empty;
            var productImages = await _productImageRepository.FindAsync(filter);
            return _mapper.Map<IEnumerable<ProductImageDto>>(productImages);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProductImage>.Filter.Eq(x => x.Id, id);
            var productImage = await _productImageRepository.FindOneAndDeleteAsync(filter);
            
            if (productImage == null)
                throw new Exception($"Product image with id {id} not found");
        }

        public async Task DeleteAllByProductIdAsync(string productId)
        {
            // Ürün kontrolü
            await _productService.GetByIdAsync(productId);

            var filter = Builders<ProductImage>.Filter.Eq(x => x.ProductId, productId);
            var productImages = await _productImageRepository.FindAsync(filter);

            foreach (var image in productImages)
            {
                await _productImageRepository.DeleteOneAsync(
                    Builders<ProductImage>.Filter.Eq(x => x.Id, image.Id)
                );
            }
        }

        public Task<IEnumerable<ProductImageDto>> GetByProductIdAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
} 