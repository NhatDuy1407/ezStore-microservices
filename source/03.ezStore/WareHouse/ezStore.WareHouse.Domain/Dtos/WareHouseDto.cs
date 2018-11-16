using Microservice.Core.Models;

namespace ezStore.WareHouse.Domain.Dtos
{
    public class WareHouseDto : ModelGuidIdEntity
    {
        public string Name { get; internal set; }
    }
}
