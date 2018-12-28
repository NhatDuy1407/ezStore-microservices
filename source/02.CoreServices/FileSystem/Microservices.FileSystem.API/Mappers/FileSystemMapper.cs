using Microservices.FileSystem.API.ViewModels;
using Microservices.FileSystem.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Microservices.FileSystem.API.Mappers
{
    public static class FileSystemMapper
    {
        public static FileSystemViewModel DtoToViewModel(FileMetadataDto dto)
        {
            return new FileSystemViewModel(dto);
        }

        public static IEnumerable<FileSystemViewModel> DtoToViewModels(IEnumerable<FileMetadataDto> dtos)
        {
            return dtos?.Select(DtoToViewModel);
        }
    }
}
