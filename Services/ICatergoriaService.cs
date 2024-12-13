using CatalogApi.Models;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CatalogApi.Services
{
    public interface ICategoriaService
    {
        List<Categoria> GetAllCategorias();
        Categoria GetCategoriaById(ObjectId id);
        Categoria CreateCategoria(Categoria categoria);
        Categoria UpdateCategoria(ObjectId id, Categoria categoria);
        void DeleteCategoria(ObjectId id);
    }
}
