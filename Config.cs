using System.Collections.Generic;
using SystemEndpointsDotnetCore.Models;

namespace Service.Flowershop.Data
{
    public class Config
    {
        public string MongoUri { get; set; }

        public string MongoDatabase { get; set; }

        public List<Endpoint> hosts { get; set; } = new List<Endpoint>();
    }
}
