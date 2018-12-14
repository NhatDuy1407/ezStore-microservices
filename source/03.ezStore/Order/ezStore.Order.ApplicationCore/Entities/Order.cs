using Ws4vn.Microservicess.ApplicationCore.Entities;
using System;

namespace ezStore.Order.ApplicationCore.Entities
{
    public class Order : ModelGuidIdEntity
    {
        public string Name { get; set; }
    }
}
