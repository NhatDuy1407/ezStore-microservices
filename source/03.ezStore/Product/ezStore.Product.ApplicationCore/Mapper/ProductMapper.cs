using ezStore.Product.ApplicationCore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.ApplicationCore.Mapper
{
    public static class ProductMapper
    {
        public static Entities.Product DtoToEntity(ProductDto dto)
        {
            return new Entities.Product
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static ProductDto EntityToDto(Entities.Product dto)
        {
            return new ProductDto
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ProductDto> EntityToDtos(IEnumerable<Entities.Product> entities)
        {
            return entities?.Select(EntityToDto);
        }
    }
}
