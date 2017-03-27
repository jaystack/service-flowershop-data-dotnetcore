﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using Service.Flowershop.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SystemEndpoints;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Service.Flowershop.Data.Controllers
{
    [Route("/[controller]")]
    public class DataController : Controller
    {
        private readonly ILogger<DataController> logger;
        private readonly IOptions<Config> config;
        private MongoClient client;
        private IMongoDatabase db;

        public DataController(ILogger<DataController> loggerAccessor, IOptions<Config> optionsAccessor)
        {
            IStore store = new Store(optionsAccessor.Value.hosts);
            logger = loggerAccessor;
            config = optionsAccessor;
            client = new MongoClient("mongodb://" + store.GetServiceAddress(optionsAccessor.Value.MongoUri));
            db = client.GetDatabase(config.Value.MongoDatabase);
        }

        [HttpGet]
        [Route("/[controller]/categories")]
        public IEnumerable<Category> Categories()
        {
            return db.GetCollection<Category>("categories").Find(_ => true).ToList();
        }

        [HttpGet("/[controller]/flowers/{catName}")]
        public IEnumerable<Flower> Flowers(string catName)
        {
            return db.GetCollection<Flower>("flowers").Find(p => p.Category == catName).ToList();
        }

        [HttpGet]
        [Route("/[controller]/flowers")]
        public IEnumerable<Flower> Flowers()
        {
            return db.GetCollection<Flower>("flowers").Find(_ => true).ToList();
        }

        [HttpGet("/[controller]/flower({fId})")]
        public Flower Flower(string fId)
        {
            return db.GetCollection<Flower>("flowers").Find(p => p._id == fId).FirstOrDefault();
        }

        [HttpPost("/[controller]/order")]
        public IActionResult Order(string flowers, string customerName, string customerAddress)
        {
            logger.LogDebug("oids: " + flowers);

            var parsedOids = JsonConvert.DeserializeObject<string[]>(flowers);

            var flowerList = db.GetCollection<Flower>("flowers").Find(p => parsedOids.Contains(p._id)).ToList();

            var order = new Order()
            {
                CustomerName = customerName,
                CustomerAddress = customerAddress,
                Orders = flowerList.ToArray(),
                OrderPrice = flowerList.Sum(p => p.Price),
            };

            var orders = db.GetCollection<Order>("orders");

            orders.InsertOne(order);

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
