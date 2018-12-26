using Microservices.FileSystem.ApplicationCore.Dtos;

namespace Microservices.FileSystem.API.ViewModels
{
    public class FileSystemViewModel
    {
        public FileSystemViewModel(FileMetadataDto i)
        {
            FileSystemId = i.FileSystemId;
        }
       
        public string FileSystemId { get; }
    }
}