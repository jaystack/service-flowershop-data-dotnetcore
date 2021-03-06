﻿using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Service.Flowershop.Data.Models
{
    public class Order : ModelBase
    {
        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }

        [BsonElement("CustomerAddress")]
        public string CustomerAddress { get; set; }

        [BsonElement("EmailAddress")]
        public string EmailAddress { get; set; }

        [BsonElement("Orders")]
        public Flower[] Orders { get; set; }

        [BsonElement("OrderPrice")]
        public decimal OrderPrice { get; set; }

        [BsonElement("TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [BsonConstructor]
        public Order()
        {
        }
    }
}
