using Microsoft.OpenApi.Models;
using MultiShop.Order.Application;
using MultiShop.Order.Infrastructure;
using MultiShop.Order.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "MultiShop Order API", 
        Version = "v1",
        Description = "MultiShop e-ticaret uygulamasının Order (Sipariş) mikroservisi API'si"
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiShop Order API V1");
        c.RoutePrefix = string.Empty;
    });
}

// app.UseAuthorization();

app.MapOrderEndpoints();

app.Run();