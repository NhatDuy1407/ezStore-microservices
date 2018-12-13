using Microservices.ApplicationCore.Entities;

namespace Microservice.Setting.API.ViewModels
{
    public class ProvinceViewModel : ViewModelStringIdEntity
    {
        public string Name { get; internal set; }
    }
}
