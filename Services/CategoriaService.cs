using MongoDB.Bson;
using MongoDB.Driver;
using CatalogApi.Models;
using System.Collections.Generic;

namespace CatalogApi.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IMongoCollection<Categoria> _categoriasCollection;

        public CategoriaService(IMongoDatabase database)
        {
            _categoriasCollection = database.GetCollection<Categoria>("categorias");
        }

        // Obtener todas las categorías
        public List<Categoria> GetAllCategorias()
        {
            return _categoriasCollection.Find(c => true).ToList();
        }

        // Obtener una categoría por su IDFormatException: Expected a nested document representing the serialized form of a CatalogApi.Models.Producto value, but found a value of type ObjectId instead.
        public Categoria GetCategoriaById(ObjectId id)
        {
            return _categoriasCollection.Find(c => c.Id == id).FirstOrDefault();
        }

        // Crear una nueva categoría
        public Categoria CreateCategoria(Categoria categoria)
        {
            _categoriasCollection.InsertOne(categoria);
            return categoria;
        }

        // Actualizar una categoría existente
        public Categoria UpdateCategoria(ObjectId id, Categoria categoria)
        {
            _categoriasCollection.ReplaceOne(c => c.Id == id, categoria);
            return categoria;
        }

        // Eliminar una categoría por su ID
        public void DeleteCategoria(ObjectId id)
        {
            _categoriasCollection.DeleteOne(c => c.Id == id);
        }
    }
}
