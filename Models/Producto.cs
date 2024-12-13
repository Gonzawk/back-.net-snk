using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CatalogApi.Models
{
    public class Producto
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("model")]
        public string Model { get; set; }

        [BsonElement("color")]
        public string Color { get; set; }

        [BsonElement("img_url")]
        public string ImgUrl { get; set; }

        // Relación con Categoría a través de ObjectId
        [BsonElement("category")]
        public ObjectId CategoryId { get; set; }
    }

}
