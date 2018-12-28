using Microservices.FileSystem.ApplicationCore.Entities;

namespace Microservices.FileSystem.ApplicationCore.Dtos
{
    public class FileMetadataDto
    {
        public FileMetadataDto(FileMetadata i, byte[] data)
        {
            FileSystemId = i.FileSystemId;
            Name = i.Name;
            Data = data;
        }
        public FileMetadataDto(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }

        public string FileSystemId { get; }

        public string Name { get; }

        public byte[] Data { get; }
    }
}