using Ws4vn.Microservicess.ApplicationCore.Entities;
using System.Collections.Generic;

namespace Microservices.Setting.API.ViewModels
{
    public class CountryViewModel : ViewModelIntIdEntity
    {
        public string Name { get; internal set; }

        public IEnumerable<ProvinceViewModel> Provinces { get; internal set; }
    }
}
