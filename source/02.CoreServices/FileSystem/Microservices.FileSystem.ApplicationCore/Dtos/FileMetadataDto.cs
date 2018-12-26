using Microservices.FileSystem.ApplicationCore.Entities;

namespace Microservices.FileSystem.ApplicationCore.Dtos
{
    public class FileMetadataDto
    {
        public FileMetadataDto(FileMetadata i)
        {
            FileSystemId = i.FileSystemId;
        }

        public string FileSystemId { get; }
    }
}