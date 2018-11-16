using Microservice.Setting.API.ViewModels;
using Microservice.Setting.Domain.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Setting.API.Mappers
{
    public static class LocationViewMapper
    {
        public static CountryViewModel DtoToViewModel(CountryDto dto)
        {
            return new CountryViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<CountryViewModel> DtoToViewModels(IEnumerable<CountryDto> dtos)
        {
            return dtos.Select(DtoToViewModel);
        }
    }
}
