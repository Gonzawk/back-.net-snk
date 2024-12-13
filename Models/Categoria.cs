using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;

namespace CatalogApi.Models
{
    public class Categoria
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("category_name")]
        public string Name { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        // Cambiar la propiedad para ser una lista de ObjectId en lugar de Producto
        [BsonElement("products")]
        public List<ObjectId> ProductIds { get; set; }  // Lista de ObjectId que representa los productos relacionados
    }
}
