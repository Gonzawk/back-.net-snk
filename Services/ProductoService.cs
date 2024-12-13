using MongoDB.Bson;
using MongoDB.Driver;
using CatalogApi.Models;
using System.Collections.Generic;

namespace CatalogApi.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IMongoCollection<Producto> _productosCollection;
        private readonly IMongoCollection<Categoria> _categoriasCollection;

        public ProductoService(IMongoDatabase database)
        {
            _productosCollection = database.GetCollection<Producto>("productos");
            _categoriasCollection = database.GetCollection<Categoria>("categorias");
        }

        // Obtener todos los productos
        public List<Producto> GetAllProductos()
        {
            return _productosCollection.Find(p => true).ToList();
        }

        // Obtener un producto por su ID
        public Producto GetProductoById(ObjectId id)
        {
            return _productosCollection.Find(p => p.Id == id).FirstOrDefault();
        }

        // Obtener productos por categoría
        public List<Producto> GetProductosPorCategoria(ObjectId categoriaId)
        {
            return _productosCollection.Find(p => p.CategoryId == categoriaId).ToList();
        }

        // Crear un nuevo producto
        public Producto CreateProducto(Producto producto)
        {
            _productosCollection.InsertOne(producto);
            return producto;
        }

        // Actualizar un producto existente
        public Producto UpdateProducto(ObjectId id, Producto producto)
        {
            _productosCollection.ReplaceOne(p => p.Id == id, producto);
            return producto;
        }

        // Eliminar un producto por su ID
        public void DeleteProducto(ObjectId id)
        {
            _productosCollection.DeleteOne(p => p.Id == id);
        }
    }
}
