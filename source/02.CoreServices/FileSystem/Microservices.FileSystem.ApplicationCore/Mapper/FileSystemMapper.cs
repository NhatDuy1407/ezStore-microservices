using Microservices.FileSystem.ApplicationCore.Dtos;
using Microservices.FileSystem.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.FileSystem.ApplicationCore.Mapper
{
    public static class FileSystemMapper
    {
        public static FileMetadata DtoToEntity(FileMetadataDto dto)
        {
            return new FileMetadata
            {
                FileSystemId = dto.FileSystemId,
                UpdatedDate = DateTime.Now
            };
        }

        public static FileMetadataDto EntityToDto(FileMetadata dto)
        {
            return new FileMetadataDto(dto);
        }

        public static IEnumerable<FileMetadataDto> EntityToDtos(IEnumerable<FileMetadata> entities)
        {
            return entities?.Select(EntityToDto);
        }
    }
}
