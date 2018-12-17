using ezStore.Product.API.ViewModels;
using ezStore.Product.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.API.Mappers
{
    public static class ManufactureMapper
    {
        public static ManufactureViewModel DtoToViewModel(ManufactureDto dto)
        {
            return new ManufactureViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ManufactureViewModel> DtoToViewModels(IEnumerable<ManufactureDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
