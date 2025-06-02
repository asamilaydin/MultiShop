using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.Products;

namespace MultiShop.Catalog.Services.ProductDetails
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IRepository<ProductDetail> _productDetailRepository;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductDetailService(
            IRepository<ProductDetail> productDetailRepository,
            IProductService productService,
            IMapper mapper)
        {
            _productDetailRepository = productDetailRepository;
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<ProductDetailDto> CreateAsync(CreateProductDetailDto createProductDetailDto)
        {
            // Ürün kontrolü
            await _productService.GetByIdAsync(createProductDetailDto.ProductId);

            // Ürüne ait detay kontrolü
            var filter = Builders<ProductDetail>.Filter.Eq(x => x.ProductId, createProductDetailDto.ProductId);
            var existingDetail = await _productDetailRepository.FindOneAsync(filter);
            
            if (existingDetail != null)
                throw new Exception($"Product detail for product {createProductDetailDto.ProductId} already exists");

            var productDetail = _mapper.Map<ProductDetail>(createProductDetailDto);
            productDetail = await _productDetailRepository.InsertOneAsync(productDetail);
            return _mapper.Map<ProductDetailDto>(productDetail);
        }

        public async Task<ProductDetailDto> UpdateAsync(string id, UpdateProductDetailDto updateProductDetailDto)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(x => x.Id, id);
            var existingDetail = await _productDetailRepository.FindOneAsync(filter);
            
            if (existingDetail == null)
                throw new Exception($"Product detail with id {id} not found");

            _mapper.Map(updateProductDetailDto, existingDetail);
            
            var update = Builders<ProductDetail>.Update
                .Set(x => x.Color, existingDetail.Color)
                .Set(x => x.Size, existingDetail.Size)
                .Set(x => x.Material, existingDetail.Material);

            var updatedDetail = await _productDetailRepository.FindOneAndUpdateAsync(filter, update);
            return _mapper.Map<ProductDetailDto>(updatedDetail);
        }

        public async Task<ProductDetailDto> GetByIdAsync(string id)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(x => x.Id, id);
            var productDetail = await _productDetailRepository.FindOneAsync(filter);
            
            if (productDetail == null)
                throw new Exception($"Product detail with id {id} not found");

            return _mapper.Map<ProductDetailDto>(productDetail);
        }

        public async Task<ProductDetailDto> GetByProductIdAsync(string productId)
        {
            // Ürün kontrolü
            await _productService.GetByIdAsync(productId);

            var filter = Builders<ProductDetail>.Filter.Eq(x => x.ProductId, productId);
            var productDetail = await _productDetailRepository.FindOneAsync(filter);
            
            if (productDetail == null)
                throw new Exception($"Product detail for product {productId} not found");

            return _mapper.Map<ProductDetailDto>(productDetail);
        }

        public async Task<IEnumerable<ProductDetailDto>> GetAllAsync()
        {
            var filter = Builders<ProductDetail>.Filter.Empty;
            var productDetails = await _productDetailRepository.FindAsync(filter);
            return _mapper.Map<IEnumerable<ProductDetailDto>>(productDetails);
        }

        public async Task DeleteAsync(string id)
        {
            var filter = Builders<ProductDetail>.Filter.Eq(x => x.Id, id);
            var productDetail = await _productDetailRepository.FindOneAndDeleteAsync(filter);
            
            if (productDetail == null)
                throw new Exception($"Product detail with id {id} not found");
        }
    }
} 