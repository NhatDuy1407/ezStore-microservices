using MongoDB.Bson;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservices.FileSystem.ApplicationCore.Entities
{
    public class FileMetadata : ModelEntity<ObjectId>
    {
        public string Name { get; set; }
        public string FileSystemId { get; set; }
    }
}