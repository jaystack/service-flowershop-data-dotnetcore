using MongoDB.Bson.Serialization.Attributes;

namespace Service.Flowershop.Data.Models
{
    public class User : ModelBase
    {
        [BsonElement("UserName")]
        public string UserName { get; set; }

        [BsonElement("Password")]
        public string Password { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }
    }
}
