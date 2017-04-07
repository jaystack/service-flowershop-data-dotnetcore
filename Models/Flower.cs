using MongoDB.Bson.Serialization.Attributes;

namespace Service.Flowershop.Data.Models
{
    public class Flower : ModelBase
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("ImageUrl")]
        public string ImageUrl { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }
    }
}
