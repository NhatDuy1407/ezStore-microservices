﻿using Microservice.Core.Models;
using System;

namespace ezStore.Product.ApplicationCore.Entities
{
    public class ProductCategory : ModelGuidIdEntity
    {
        public ProductCategory()
        {
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }
    }
}