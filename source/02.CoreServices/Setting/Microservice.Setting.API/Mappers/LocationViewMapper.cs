using Microservice.Setting.API.ViewModels;
using Microservice.Setting.ApplicationCore.Dtos;
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
                Provinces = DtoToViewModels(dto.Provinces),
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<CountryViewModel> DtoToViewModels(IEnumerable<CountryDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }

        public static ProvinceViewModel DtoToViewModel(ProvinceDto dto)
        {
            return new ProvinceViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ProvinceViewModel> DtoToViewModels(IEnumerable<ProvinceDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
