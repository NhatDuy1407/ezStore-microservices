﻿using Microservice.Core.Models;

using System;

namespace ezStore.Product.Infrastructure.Entities
{
    public class Manufacture : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
