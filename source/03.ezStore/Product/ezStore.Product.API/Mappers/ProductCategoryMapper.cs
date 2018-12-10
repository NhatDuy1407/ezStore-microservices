using ezStore.Product.API.ViewModels;
using ezStore.Product.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.API.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryViewModel DtoToViewModel(ProductCategoryDto dto)
        {
            return new ProductCategoryViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ProductCategoryViewModel> DtoToViewModels(IEnumerable<ProductCategoryDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
