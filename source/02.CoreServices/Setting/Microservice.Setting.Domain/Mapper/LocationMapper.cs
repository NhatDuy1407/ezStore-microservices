using Microservice.Setting.Domain.Dtos;
using Microservice.Setting.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservice.Setting.Domain.Mapper
{
    public static class LocationMapper
    {
        public static Country DtoToEntity(CountryDto dto)
        {
            return new Country
            {
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                UpdatedDate = DateTime.Now
            };
        }

        public static CountryDto EntityToDto(Country dto)
        {
            return new CountryDto
            {
                Id = dto.Id.ToString(),
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static ProvinceDto EntityToDto(Province dto)
        {
            return new ProvinceDto
            {
                Id = dto.CountryId.ToString(),
                Name = dto.Name,
                CreatedBy = dto.CreatedBy,
                UpdatedBy = dto.UpdatedBy,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate,
            };
        }

        public static IEnumerable<CountryDto> EntityToDtos(IEnumerable<Country> entities)
        {
            return entities == null ? null : entities.Select(EntityToDto);
        }

        public static IEnumerable<ProvinceDto> EntityToDtos(IEnumerable<Province> entities)
        {
            return entities == null ? null : entities.Select(EntityToDto);
        }
    }
}
