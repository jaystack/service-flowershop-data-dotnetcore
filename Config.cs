using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemEndpoints.Models;

namespace Service.Flowershop.Data
{
    public class Config
    {
        public string MongoUri { get; set; }

        public string MongoDatabase { get; set; }

        public List<Endpoint> hosts
        {
            get; set;
        }
    }
}
