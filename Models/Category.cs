using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
