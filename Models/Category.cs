using MongoDB.Bson.Serialization.Attributes;

namespace Service.Flowershop.Data.Models
{
    public class Category : ModelBase
    {
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("DisplayName")]
        public string DisplayName { get; set; }
    }
}
