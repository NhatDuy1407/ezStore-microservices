﻿using Ws4vn.Microservices.ApplicationCore.Entities;
using MongoDB.Bson;

namespace Microservices.Setting.ApplicationCore.Entities
{
    public class Country : ModelEntity<ObjectId>
    {
        public int AutoId { get; set; }

        public string Name { get; set; }

        public string IsoCode { get; set; }

        public int DisplayOrder { get; set; }

        public bool Published { get; set; }
    }
}
