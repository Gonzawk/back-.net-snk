using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using CatalogApi.Services;
using CatalogApi.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Configuración de MongoDB
builder.Services.AddSingleton<IMongoClient>(new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
builder.Services.AddScoped<IMongoDatabase>(serviceProvider =>
{
    var client = serviceProvider.GetRequiredService<IMongoClient>();
    return client.GetDatabase("productos_catalogo"); // El nombre de tu base de datos
});

// Agregar servicios para la API
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();  // Esta línea es la que registramos correctamente

// Agregar controladores
builder.Services.AddControllers();  // Esta línea es necesaria para registrar los controladores

// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Habilitar Swagger solo en el entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Mapear controladores
app.MapControllers();  // Esto mapea los controladores a las rutas

app.Run();
