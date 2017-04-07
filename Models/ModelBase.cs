using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Service.Flowershop.Data.Models
{
    public abstract class ModelBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}
