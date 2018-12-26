using Microservices.FileSystem.API.Mappers;
using Microservices.FileSystem.API.ViewModels;
using Microservices.FileSystem.ApplicationCore.Services.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservices.FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class FileSystemController : Controller
    {
        private readonly IFileSystemQueries _loggingQueries;

        public FileSystemController(IFileSystemQueries loggingQueries)
        {
            _loggingQueries = loggingQueries;
        }

        // GET api/values
        [HttpGet]
        [Route("Logs")]
        public Task<List<FileSystemViewModel>> Logs()
        {
            return Task.FromResult(FileSystemMapper.DtoToViewModels(_loggingQueries.GetLogs().Result).ToList());
        }
    }
}