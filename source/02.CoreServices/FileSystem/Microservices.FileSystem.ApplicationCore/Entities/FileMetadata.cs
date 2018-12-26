using MongoDB.Bson;
using System;
using Ws4vn.Microservices.ApplicationCore.Entities;

namespace Microservices.FileSystem.ApplicationCore.Entities
{
    public class FileMetadata : ModelEntity<ObjectId>
    {
        public DateTime Date { get; set; }
        public string FileSystemId { get; set; }
    }
}