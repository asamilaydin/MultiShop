using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Context
{
    public class CatalogContext
    {
        private readonly IMongoDatabase _database;
        private readonly DatabaseSettings _settings;

        public CatalogContext(IOptions<DatabaseSettings> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            _database = client.GetDatabase(_settings.DatabaseName);

            Categories = _database.GetCollection<Category>(_settings.CategoryCollectionName);
            Products = _database.GetCollection<Product>(_settings.ProductCollectionName);
            ProductDetails = _database.GetCollection<ProductDetail>(_settings.ProductDetailCollectionName);
            ProductImages = _database.GetCollection<ProductImage>(_settings.ProductImageCollectionName);
        }

        public IMongoCollection<Category> Categories { get; }
        public IMongoCollection<Product> Products { get; }
        public IMongoCollection<ProductDetail> ProductDetails { get; }
        public IMongoCollection<ProductImage> ProductImages { get; }
    }
} 