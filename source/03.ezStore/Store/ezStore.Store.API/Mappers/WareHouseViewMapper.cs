﻿using ezStore.WareHouse.API.ViewModels;
using ezStore.WareHouse.Domain.Dtos;
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
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<WareHouseViewModel> DtoToViewModels(IEnumerable<WareHouseDto> dtos)
        {
            return dtos.Select(DtoToViewModel);
        }
    }
}
