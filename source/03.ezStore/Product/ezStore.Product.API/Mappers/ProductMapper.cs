using ezStore.Product.API.ViewModels;
using ezStore.Product.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.API.Mappers
{
    public static class ProductMapper
    {
        public static ProductViewModel DtoToViewModel(ProductDto dto)
        {
            return new ProductViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ProductViewModel> DtoToViewModels(IEnumerable<ProductDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
