using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Flowershop.Data.Models
{
    public class Order : ModelBase
    {
        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }

        [BsonElement("CustomerAddress")]
        public string CustomerAddress { get; set; }

        [BsonElement("Orders")]
        public Flower[] Orders { get; set; }

        [BsonElement("OrderPrice")]
        public decimal OrderPrice { get; set; }

        [BsonConstructor]
        public Order()
        {
        }
    }
}
