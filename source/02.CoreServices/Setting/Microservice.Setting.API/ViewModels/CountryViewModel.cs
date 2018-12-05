using Microservice.Core.Models;
using System.Collections.Generic;

namespace Microservice.Setting.API.ViewModels
{
    public class CountryViewModel : ViewModelStringIdEntity
    {
        public string Name { get; internal set; }

        public IEnumerable<ProvinceViewModel> Provinces { get; internal set; }
    }
}
