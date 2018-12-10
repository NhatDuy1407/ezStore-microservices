using ezStore.WareHouse.API.ViewModels;
using ezStore.WareHouse.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.WareHouse.API.Mappers
{
    public static class WareHouseViewMapper
    {
        public static WareHouseViewModel DtoToViewModel(WareHouseDto dto)
        {
            return new WareHouseViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Address = dto.Address,
                City = dto.City,
                CountryId = dto.CountryId,
                ProvinceId = dto.ProvinceId,
                PhoneNumber = dto.PhoneNumber,
                PostalCode = dto.PostalCode,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<WareHouseViewModel> DtoToViewModels(IEnumerable<WareHouseDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
