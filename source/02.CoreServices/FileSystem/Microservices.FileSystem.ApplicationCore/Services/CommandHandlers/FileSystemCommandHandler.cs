using Microservices.FileSystem.ApplicationCore.Entities;
using Microservices.FileSystem.ApplicationCore.Interfaces;
using Microservices.FileSystem.ApplicationCore.Services.Commands;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.ApplicationCore.Services.CommandHandlers
{
    public class FileSystemCommandHandler : ICommandHandler<UploadFilesCommand>
    {
        private readonly IDataAccessWriteService _writeService;
        private readonly IFSRepository _fsService;

        public FileSystemCommandHandler(IFSRepository fsService, IDataAccessWriteService writeService)
        {
            _writeService = writeService;
            _fsService = fsService;
        }

        public Task ExecuteAsync(UploadFilesCommand command)
        {
            foreach (var item in command.FileMetadatas)
            {
                var id = _fsService.UploadFile(item.Name, item.Data).Result;
                _writeService.Repository<FileMetadata>().Insert(new FileMetadata { Name = item.Name, FileSystemId = id });
                _writeService.SaveChanges();
            }

            return Task.CompletedTask;
        }
    }
}
