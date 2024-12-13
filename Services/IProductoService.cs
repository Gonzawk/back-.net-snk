using CatalogApi.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CatalogApi.Services
{
    public interface IProductoService
    {
        List<Producto> GetAllProductos();
        Producto GetProductoById(ObjectId id);
        List<Producto> GetProductosPorCategoria(ObjectId categoriaId);
        Producto CreateProducto(Producto producto);
        Producto UpdateProducto(ObjectId id, Producto producto);
        void DeleteProducto(ObjectId id);
    }
}
