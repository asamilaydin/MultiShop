using Microsoft.Extensions.DependencyInjection;
using MultiShop.Catalog.Context;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.Categories;
using MultiShop.Catalog.Services.ProductDetails;
using MultiShop.Catalog.Services.ProductImages;
using MultiShop.Catalog.Services.Products;
using MultiShop.Catalog.Settings; // Assuming DatabaseSettings is in here, if not, adjust namespace

namespace MultiShop.Catalog.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection AddCatalogServices(this IServiceCollection services, IConfiguration configuration)
        {
            // MongoDB Settings
            services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton<CatalogContext>();

            // Repository registrations
            services.AddScoped<IRepository<Category>, Repository<Category>>();
            services.AddScoped<IRepository<Product>, Repository<Product>>();
            services.AddScoped<IRepository<ProductDetail>, Repository<ProductDetail>>();
            services.AddScoped<IRepository<ProductImage>, Repository<ProductImage>>();

            // Service registrations
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductDetailService, ProductDetailService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            
            // AutoMapper (can also be kept here or moved to its own extension if preferred)
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
} 