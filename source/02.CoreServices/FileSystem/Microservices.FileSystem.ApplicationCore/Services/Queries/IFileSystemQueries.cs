using Microservices.FileSystem.ApplicationCore.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microservices.FileSystem.ApplicationCore.Services.Queries
{
    public interface IFileSystemQueries
    {
        Task<List<FileMetadataDto>> GetLogs();
    }
}