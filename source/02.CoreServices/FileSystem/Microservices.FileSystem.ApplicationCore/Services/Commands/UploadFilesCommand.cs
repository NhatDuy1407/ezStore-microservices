using Microservices.FileSystem.ApplicationCore.Dtos;
using System.Collections.Generic;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.ApplicationCore.Services.Commands
{
    public class UploadFilesCommand : ICommand
    {
        public UploadFilesCommand(List<FileMetadataDto> fileMetadatas)
        {
            FileMetadatas = fileMetadatas;
        }

        public List<FileMetadataDto> FileMetadatas { get; set; }

        public bool Validate(IValidationContext validationContext)
        {
            return true;
        }
    }
}
