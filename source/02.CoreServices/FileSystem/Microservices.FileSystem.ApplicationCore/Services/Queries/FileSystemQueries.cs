using Microservices.FileSystem.ApplicationCore.Dtos;
using Microservices.FileSystem.ApplicationCore.Entities;
using Microservices.FileSystem.ApplicationCore.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.ApplicationCore.Services.Queries
{
    public class FileSystemQueries : IFileSystemQueries
    {
        private readonly IDataAccessReadOnlyService _dataAccessReadOnlyService;
        private readonly IFSRepository _fsService;

        public FileSystemQueries(IFSRepository fsService, IDataAccessReadOnlyService dataAccessReadOnlyService)
        {
            _dataAccessReadOnlyService = dataAccessReadOnlyService;
            _fsService = fsService;
        }

        public Task<FileMetadataDto> GetFileById(string id)
        {
            var binaryData = _fsService.GetFile(id).Result;

            var result = new FileMetadataDto(_dataAccessReadOnlyService.Repository<FileMetadata>().Get(i => i.FileSystemId == id).First(), binaryData);

            return Task.FromResult(result);
        }
    }
}