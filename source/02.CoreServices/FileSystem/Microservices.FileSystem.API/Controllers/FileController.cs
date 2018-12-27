using Microservices.FileSystem.ApplicationCore.Dtos;
using Microservices.FileSystem.ApplicationCore.Services.Commands;
using Microservices.FileSystem.ApplicationCore.Services.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Threading.Tasks;
using Ws4vn.Microservices.ApplicationCore.Interfaces;

namespace Microservices.FileSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class FileController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IFileSystemQueries _fileQueries;

        public FileController(ICommandBus commandBus, IFileSystemQueries fileQueries)
        {
            _commandBus = commandBus;
            _fileQueries = fileQueries;
        }

        // GET api/values
        [HttpGet]
        [Route("{id}")]
        [ResponseCache(Duration = 18000)]
        public FileResult GetFileById(string id)
        {
            var document = _fileQueries.GetFileById(id).Result;
            return File(document.Data, MediaTypeNames.Application.Octet, document.Name);
        }

        [HttpPut]
        public Task Put(IFormCollection form)
        {
            var fileMetadatas = GetDetailFromFormCollection(form);
            _commandBus.ExecuteAsync(new UploadFilesCommand(fileMetadatas) ).Wait();
            return Task.CompletedTask;
        }

        private List<FileMetadataDto> GetDetailFromFormCollection(IFormCollection form)
        {
            List<FileMetadataDto> result = new List<FileMetadataDto>();
            foreach (var file in form.Files)
            {
                using (var br = new BinaryReader(file.OpenReadStream()))
                {
                    var data = br.ReadBytes((int)file.OpenReadStream().Length);
                    result.Add(new FileMetadataDto(file.FileName, data));
                }
            }

            return result;
        }
    }
}