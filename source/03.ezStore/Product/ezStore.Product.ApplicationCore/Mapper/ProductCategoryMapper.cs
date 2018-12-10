using ezStore.Product.ApplicationCore.Dtos;
using ezStore.Product.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ezStore.Product.ApplicationCore.Mapper
{
    public static class ProductCategoryMapper
    {
        public static ProductCategory DtoToEntity(ProductCategoryDto dto)
        {
            return new ProductCategory
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static ProductCategoryDto EntityToDto(ProductCategory dto)
        {
            return new ProductCategoryDto
            {
                Id = dto.Id,
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<ProductCategoryDto> EntityToDtos(IEnumerable<ProductCategory> entities)
        {
            return entities == null ? null : entities.Select(EntityToDto);
        }
    }
}
