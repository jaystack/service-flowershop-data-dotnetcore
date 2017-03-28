using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Flowershop.Data.Models
{
    public class User : ModelBase
    {
        [BsonElement("userName")]
        public string userName { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("email")]
        public string email { get; set; }
    }
}
