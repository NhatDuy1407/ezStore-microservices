using Microservices.FileSystem.ApplicationCore.Dtos;
using Microservices.FileSystem.ApplicationCore.Entities;
using Ws4vn.Microservices.ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.FileSystem.ApplicationCore.Services.Queries
{
    public class FileSystemQueries : IFileSystemQueries
    {
        private readonly IDataAccessReadOnlyService _readOnlyService;

        public FileSystemQueries(IDataAccessReadOnlyService readOnlyService)
        {
            this._readOnlyService = readOnlyService;
        }

        public Task<List<FileMetadataDto>> GetLogs()
        {
            return Task.FromResult(this._readOnlyService.Repository<FileMetadata>().Get().Select(i => new FileMetadataDto(i)).ToList());
        }
    }
}