// using Microsoft.EntityFrameworkCore; // No longer needed
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
// using MultiShop.Discount.Context; // No longer needed for EFCore context
using MultiShop.Discount.Context; // Added for DapperContext
using MultiShop.Discount.Services;
using MultiShop.Discount.Repositories;

namespace MultiShop.Discount.Extensions
{
    public static class ServiceRegistrationExtensions
    {
         public static IServiceCollection AddDiscountServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register DapperContext
            services.AddSingleton<DapperContext>();

            // Register Services & Repositories
            services.AddScoped<ICouponService, CouponService>();
            services.AddScoped<ICouponRepository, CouponRepository>();
            
            return services;
        }
    }
} 