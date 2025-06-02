using Microsoft.OpenApi.Models;
using MultiShop.Discount.Extensions; // We'll create this for service registrations

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();

// Register services using the extension method (will be created soon)
builder.Services.AddDiscountServices(builder.Configuration);

// AutoMapper - We'll move this to the extension method later
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo 
    { 
        Title = "MultiShop Discount API", 
        Version = "v1",
        Description = "MultiShop e-ticaret uygulamasının Discount mikroservisi API'si",
        Contact = new OpenApiContact
        {
            Name = "MultiShop Team",
            Email = "info@multishop.com"
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MultiShop Discount API V1");
        c.RoutePrefix = string.Empty; 
    });
}


app.UseAuthorization();
app.MapControllers();

app.Run(); 