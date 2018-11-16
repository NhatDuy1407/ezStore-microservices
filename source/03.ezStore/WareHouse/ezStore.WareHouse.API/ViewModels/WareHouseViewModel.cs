using Microservice.Core.Models;
using System;
namespace ezStore.WareHouse.API.ViewModels
{
    public class WareHouseViewModel : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
