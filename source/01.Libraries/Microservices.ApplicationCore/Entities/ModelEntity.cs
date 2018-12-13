﻿using System;

namespace Ws4vn.Microservices.ApplicationCore.Entities
{
    public class ModelEntity<T> : ViewModelEntity<T>
    {
        public ModelEntity()
        {
            CreatedDate = DateTime.Now;
        }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public bool Deleted { get; set; }
    }
}