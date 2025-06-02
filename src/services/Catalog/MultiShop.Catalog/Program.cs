using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using MultiShop.Catalog.Context;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Repositories;
using MultiShop.Catalog.Services.Categories;
using MultiShop.Catalog.Services.Products;
using MultiShop.Catalog.Settings;
using MultiShop.Catalog.Services.ProductImages;
using MultiShop.Catalog.Services.ProductDetails;
using MultiShop.Catalog.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register services using the extension method
builder.Services.AddCatalogServices(builder.Configuration);

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "MultiShop Catalog API", 
        Version = "v1",
        Description = "MultiShop e-ticaret uygulamasının Catalog mikroservisi API'si",
        Contact = new OpenApiContact
        {
            Name = "MultiShop Team",
            Email = "info@multishop.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiShop Catalog API V1");
        c.RoutePrefix = string.Empty; // Ana sayfada Swagger'ı göster
    });


app.UseAuthorization();
app.MapControllers();

app.Run();
